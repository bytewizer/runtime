using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Diagnostics;

using Bytewizer.TinyCLR.Hosting;
using Bytewizer.TinyCLR.DependencyInjection;
using Bytewizer.TinyCLR.Hosting.Configuration;
using Bytewizer.TinyCLR.Hosting.Configuration.Json;
using GHIElectronics.TinyCLR.IO;
using GHIElectronics.TinyCLR.Devices.Storage;
using GHIElectronics.TinyCLR.Pins;

namespace TinyCLR.Hosting
{
    internal class Program
    {
        public static void Main()
        {
            var sd = StorageController.FromName(SC20100.StorageController.SdCard);
            var drive = FileSystem.Mount(sd.Hdc);

            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    Debug.WriteLine(context.Configuration["person:emergencyContacts:0:phone"]);
                    Debug.WriteLine(context.Configuration["object1:property2:1"]);
                    Debug.WriteLine(context.Configuration["test:start"]);
                    Debug.WriteLine(context.Configuration["test:stop"]);
                    Debug.WriteLine(context.Configuration["DefaultConnection:ConnectionString"]);

                    context.Configuration["person:emergencyContacts:0:phone"] = "NewValue1";

                    services.AddSingleton(typeof(BackgroundQueue));
                    services.AddHostedService(typeof(SensorService));
                    services.AddHostedService(typeof(DisplayService));
                    services.AddHostedService(typeof(MonitorService));
                })
                .ConfigureAppConfiguration((builder) =>
                {
                    var json = @"{""key1"":1,""key2"":""value2"",""object1"":{""property1"":""value1"",""property2"":[2,3,4,5,6,7]}}";
                    
                    builder.AddJsonStream(StringToStream(json));
                    builder.AddJsonFile("test.json", false);
                    builder.AddInMemoryCollection(new Hashtable()
                    {
                        { "test:start", "started" },
                        { "test:stop", "stopped" }
                    });
                });

        public static Stream StringToStream(string str)
        {
            var memStream = new MemoryStream();
            var textWriter = new StreamWriter(memStream);
            textWriter.Write(str);
            textWriter.Flush();
            memStream.Seek(0, SeekOrigin.Begin);

            return memStream;
        }
    }


    internal class BackgroundQueue
    {
        private readonly int _maxQueueCount = 500;
        private readonly Queue _items = new Queue();
        private readonly object _syncLock = new object();

        public int QueueCount
        {
            get
            {
                return _items.Count;
            }
        }

        public void Enqueue(object item)
        {
            if (_items.Count < _maxQueueCount)
            {
                lock (_syncLock)
                {
                    _items.Enqueue(item);
                }
            }
        }

        public object Dequeue()
        {
            if (_items.Count > 0)
            {
                lock (_syncLock)
                {
                    var item = _items.Dequeue();
                    if (item != null)
                    {
                        return item;
                    }
                }
            }

            return null;
        }
    }

    internal class SensorService : BackgroundService
    {
        private readonly Random _random;
        private readonly BackgroundQueue _queue;

        public SensorService(BackgroundQueue queue)
        {
            _queue = queue;
            _random = new Random();
        }

        protected override void ExecuteAsync()
        {
            Debug.WriteLine($"Service '{nameof(SensorService)}' is now running in the background.");

            while (!CancellationRequested)
            {
                try
                {
                    Thread.Sleep(1);
                    var item = FakeSensor();
                    _queue.Enqueue(item);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"An error occurred when enqueueing work item. Exception: {ex}");
                }
            }
        }

        private int FakeSensor()
        {
            Thread.Sleep(_random.Next(100));
            return _random.Next(1000);
        }
    }

    internal class DisplayService : BackgroundService
    {
        private readonly BackgroundQueue _queue;

        public DisplayService(BackgroundQueue queue)
        {
            _queue = queue;
        }

        protected override void ExecuteAsync()
        {
            Debug.WriteLine($"Service '{nameof(DisplayService)}' is now running in the background.");

            while (!CancellationRequested)
            {
                try
                {
                    Thread.Sleep(50);

                    var workItem = _queue.Dequeue();
                    if (workItem == null)
                    {
                        continue;
                    }

                    FakeDisplay(workItem.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"An error occurred when dequeueing sensor item. Exception: {ex}");
                }
            }
        }

        void FakeDisplay(string text)
        {
            //Debug.WriteLine(text);
        }
    }

    internal class MonitorService : SchedulerService
    {
        private readonly BackgroundQueue _queue;

        public MonitorService(BackgroundQueue queue)
            : base(TimeSpan.FromSeconds(1))
        {
            _queue = queue;
        }

        public override void Start()
        {
            Debug.WriteLine($"Service '{nameof(MonitorService)}' is now running in the background.");

            base.Start();
        }

        protected override void ExecuteAsync()
        {
            Debug.WriteLine($"Queue Depth: {_queue.QueueCount}");
        }

        public override void Stop()
        {
            Debug.WriteLine($"Service '{nameof(MonitorService)}' is stopping.");

            base.Stop();
        }
    }

}
