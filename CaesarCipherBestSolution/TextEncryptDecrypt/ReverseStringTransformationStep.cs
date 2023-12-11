namespace TextEncryptDecrypt
{
    internal class ReverseStringTransformationStep : TextTransformationStep
    {
        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return new string(input.ToCharArray()
                                   .Reverse()
                                   .ToArray());
        }
    }
}
