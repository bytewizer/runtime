using System;
using System.Reflection;

namespace Bytewizer.TinyCLR.Assertions
{
    /// <summary>
    ///  Represents a test result from each test action.
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Initializes an instance of the <see cref="TestResult" /> class.
        /// </summary>
        public TestResult(Type classType, MethodInfo methodInfo)
        {
            Class = classType;
            Method = methodInfo;
        }

        /// <summary>
        /// Gets or sets pass or fail state.
        /// </summary>
        public bool Pass { get; set; }
        
        /// <summary>
        /// Gets the test class.
        /// </summary>
        public Type Class { get; private set; }
        
        /// <summary>
        /// Gets test action method.
        /// </summary>
        public MethodInfo Method { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="Exception"/> message provided on a failed test actions. 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return $"{Class.Name}:{Method.Name}";
        }
    }
}
