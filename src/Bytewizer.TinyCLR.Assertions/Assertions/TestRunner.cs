using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Diagnostics;

namespace Bytewizer.TinyCLR.Assertions
{
    /// <summary>
    /// A class provider that builds tests from an assembly.
    /// </summary>
    public class TestRunner
    {
        private readonly ArrayList _actions = new ArrayList();
        private readonly ArrayList _constructors = new ArrayList();

        private long _passCount;
        private long _failCount;
        private long _runTime;

        private Stopwatch _timer;

        /// <summary>
        /// Initializes an instance of the <see cref="TestRunner" /> class with assemblies from current domain.
        /// </summary>
        public TestRunner()
        {
            GetAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// Initializes an instance of the <see cref="TestRunner" /> class.
        /// </summary>
        public TestRunner(Assembly[] assemblies)
        {
            GetAssemblies(assemblies);
        }

        /// <summary>
        /// Method actions inherited from with in the specified assemblies.
        /// </summary>
        public ArrayList Actions { get; private set; } = new ArrayList();

        /// <summary>
        /// Display test results to the debug window.
        /// </summary>
        public Hashtable TestResults { get; private set; } = new Hashtable();

        /// <summary>
        /// Invokes method actions inherited from <see cref="TestFixture"/> class. 
        /// </summary>
        public string Run()
        {
            _timer = Stopwatch.StartNew();

            foreach(Type type in _constructors)
            {
                try
                {
                    Activator.CreateInstance(type);
                }
                catch 
                {
                    throw;
                }
            }

            foreach (MethodInfo method in _actions)
            {
                var action = new TestResult(method.DeclaringType, method);

                try
                {
                    method.Invoke(null, new object[] { });
                    action.Pass = true;
                    _passCount++;
                }
                catch (Exception ex)
                {
                    action.Pass = false;
                    action.Message = ex.Message;
                    _failCount++;
                }
                TestResults.Add(action.ToString(), action);
            }

            _timer.Stop();
            _runTime = _timer.ElapsedMilliseconds;

            return Results();
        }

        /// <summary>
        /// Test results to display in the debug window.
        /// </summary>
        public string Results()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"[TEST] :: Count {TestResults.Count}");

            foreach (DictionaryEntry result in TestResults)
            {
                var testResult = (TestResult)result.Value;

                if (testResult.Pass)
                {
                    sb.AppendLine($"[PASS] :: {testResult.Class.Name} :: {testResult.Method.Name}");
                }
                else
                {
                    sb.AppendLine($"[FAIL] :: {testResult.Class.Name} :: {testResult.Method.Name} :: Message: {testResult.Message}");
                }
            }

            sb.AppendLine($"[TEST] :: Pass {_passCount} :: Fail {_failCount} :: Elapsed {_runTime} ms");

            return sb.ToString();
        }

        private void GetAssemblies(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                GetAssemblies(assembly);
            }
        }

        private void GetAssemblies(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface || type.IsNotPublic)
                    continue;

                if (type.IsSubclassOf(typeof(TestFixture)))
                {
                    MapActions(type);
                    MapConstructors(type);
                }
            }
        }

        private void MapActions(Type type)
        {
            foreach (MethodInfo method in type.GetMethods())
            {
                if (type.IsAbstract || type.IsNotPublic)
                {
                    continue;
                }

                if (method.ReturnType.Equals(typeof(void)))
                {
                    _actions.Add(method);
                }
            }
        }

        private void MapConstructors(Type type)
        {
            ConstructorInfo constructor = type.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                _constructors.Add(type);
            }
        }
    }
}
