namespace TextEncryptDecrypt
{
    internal class InsertRandomCharactersTransformationStep : TextTransformationStep
    {
        private readonly char[] _characters;
        private readonly int _count;

        public InsertRandomCharactersTransformationStep(
            int count,
            params char[] characters)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive");
            }

            _count = count;
            _characters = characters;
        }

        public override string Transform(string input)
        {
            Random randomizer = new Random();

            for (int i = 0; i < _count; i++)
            {
                int randomIndexOfInsertedChar = randomizer.Next(0, _characters.Length - 1);
                int randomIndexInInput = randomizer.Next(0, input.Length - 1);

                input = input.Insert(randomIndexInInput, _characters[randomIndexOfInsertedChar].ToString());
            }

            return input;
        }
    }
}
