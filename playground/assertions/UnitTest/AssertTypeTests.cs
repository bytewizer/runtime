using System;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
{
    public class AssertTypeTests : TestFixture
    {
        #region IsAssignableFrom
        // TODO: Create IsAssignableForm() extention

        //public void IsAssignableFrom()
        //{
        //    int[] array10 = new int[10];

        //    Assert.IsAssignableFrom(typeof(int[]), array10);
        //}
        #endregion

        #region IsNotAssignableFrom
        //public void IsNotAssignableFrom()
        //{
        //    int[] array10 = new int[10];

        //    Assert.IsNotAssignableFrom(typeof(int[,]), array10);
        //}
        #endregion

        #region IsInstanceOf
        public void IsInstanceOf()
        {
            Assert.IsInstanceOf(typeof(SystemException), new ArgumentException());
        }
        #endregion

        #region IsNotInstanceOf
        public void IsNotInstanceOf()
        {
            Assert.IsNotInstanceOf(typeof(int), "abc123");
        }
        #endregion
    }
}