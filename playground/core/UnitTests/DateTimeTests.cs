using System;

using Bytewizer.TinyCLR;
using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Core
{
    public class DateTests : TestFixture
    {
       public void ToEpoch()
        {
            double unixTime = 1642219255522;
            DateTime datetime = new DateTime(2022, 01, 15, 04, 00, 55, 522);

            var time = unixTime.FromEpoch();
            Assert.AreEqual(time, datetime);
        }

        public void FromEpoch()
        {
            double unixTime = 1642219255522;
            DateTime datetime = new DateTime(2022, 01, 15, 04, 00, 55, 522);

            double time = datetime.ToEpoch();
            Assert.AreEqual(time, unixTime);
        }
    }
}