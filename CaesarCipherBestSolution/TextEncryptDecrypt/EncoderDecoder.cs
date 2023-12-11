namespace TextEncryptDecrypt
{
    internal static class EncoderDecoder
    {
        public static string Execute(string input, params TextTransformationStep[] steps)
        {
            string result = input;
            foreach (TextTransformationStep step in steps)
            {
                result = step.Transform(result);
            }

            return result;
        }
    }
}
