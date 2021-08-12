namespace Bytewizer.TinyCLR.Assertions
{
	/// <summary>
	/// Class for not equal assertion exceptions.
	/// </summary>
	public class NotEqualAssertionException : AssertionException
	{
		private readonly string expectedMessage = null;

		/// <summary>
		/// Initializes an empty <see cref="NotEqualAssertionException"/> instance.
		/// </summary>
		public NotEqualAssertionException(object expected, object actual)
		{
            expectedMessage = $"Equal assertion failed: [[{expected}]]!=[[{actual}]]";
        }

		/// <summary>
		/// Initializes an empty <see cref="NotEqualAssertionException"/> instance.
		/// </summary>
		public NotEqualAssertionException(object expected, object actual, string message)
			:base(message)
		{
           expectedMessage = $"Equal assertion failed: [[{expected}]]!=[[{actual}]]";
        }

		/// <summary>
		/// The message detailing the assertion failure.
		/// </summary>
		public override string Message
        {
            get 
            {
                return $"{base.Message} {expectedMessage}";
            }
        }
	}
}
