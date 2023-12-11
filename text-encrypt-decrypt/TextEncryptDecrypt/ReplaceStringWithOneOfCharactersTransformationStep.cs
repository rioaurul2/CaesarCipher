namespace TextEncryptDecrypt
{
    internal class ReplaceStringWithOneOfCharactersTransformationStep : TextTransformationStep
    {
        private readonly char[] _characters;
        private readonly string _toReplace;

        public ReplaceStringWithOneOfCharactersTransformationStep(
            string toReplace,
            params char[] characters)
        {
            _toReplace = toReplace ?? string.Empty;
            _characters = characters;
        }

        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            Random randomizer = new Random();
            while (input.IndexOf(_toReplace, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                int randomIndex = randomizer.Next(0, _characters.Length - 1);
                input = input.Replace(_toReplace, _characters[randomIndex].ToString());
            }
            
            return input;
        }
    }
}
