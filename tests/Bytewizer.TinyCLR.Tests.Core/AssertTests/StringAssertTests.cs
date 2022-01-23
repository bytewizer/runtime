#if NanoCLR
using Bytewizer.NanoCLR.Assertions;
#else
using Bytewizer.TinyCLR.Assertions;
#endif

namespace Bytewizer.TestHarness.Assertions
{
    public class StringAssertTests : TestFixture
    {
        #region Contains
        public void Contains()
        {
            string s = "framework";
            string contain = "ork";
            StringAssert.Contains(s, contain);
        }
        #endregion

        #region DoesNotContain
        public void DoesNotContain()
        {
            StringAssert.DoesNotContain("hello", "k");
        }
        #endregion

        #region StartsWith
        public void StartWith()
        {
            string s = "frame work";
            string pattern = @"fra";
            StringAssert.StartsWith(s, pattern);
        }
        #endregion

        #region DoesNotStartWith
        public void DoesNotStartWith()
        {
            string s = "frame work";
            string pattern = @"pak";
            StringAssert.DoesNotStartWith(s, pattern);
        }
        #endregion

        #region EndsWith
        public void EndsWith()
        {
            string s = "framework";
            string pattern = @"ork";
            StringAssert.EndsWith(s, pattern);
        }
        #endregion

        #region DoesNotEndWith
        public void DoesNotEndsWith()
        {
            string s = "framework";
            string pattern = @"por";
            StringAssert.DoesNotEndWith(s, pattern);
        }
        #endregion

        #region AreEqualIgnoringCase
        public void AreEqualIgnoreCase()
        {
            StringAssert.AreEqualIgnoringCase("hello", "HELLO");
        }
        #endregion

        #region AreNotEqualIgnoringCase
        public void AreNotEqualIgnoringCase()
        {
            StringAssert.AreNotEqualIgnoringCase("hello", "HELLO WORLD");
        }
        #endregion
    }
}