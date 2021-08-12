using System;
using System.Collections;
using System.Text;
using System.Threading;

using Bytewizer.TinyCLR.Pipeline;

namespace Bytewizer.Playground.Pipeline
{
    public class Context : IContext
    {
        public string Message { get; set; }

        public void Clear()
        {
        }
    }
}
