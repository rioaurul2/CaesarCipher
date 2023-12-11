using System.Text;

namespace TextEncryptDecrypt
{
    internal abstract class CaesarCipherTransformationStep : TextTransformationStep
    {
        private readonly string _key1;

        public CaesarCipherTransformationStep(
            string key1)
        {
            if (string.IsNullOrEmpty(key1))
            {
                if (string.IsNullOrEmpty(key1))
                {
                    throw new ArgumentNullException(nameof(key1));
                }
            }

            EnsureKeyUsesOnlyAlphabetLetters(keyName: nameof(key1), keyValue: key1);

            _key1 = key1;

            Cipher = new CaesarCipher(Constants.Alphabet);
        }

        public CaesarCipher Cipher { get; }

        protected abstract char ApplyCipherOperation(char input, int shift);

        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                // each letter in the key serves as a shift for the cipher
                // input most likely exceeds the key size
                // a simple way of adjusting the key to the size of the input
                // is to use modulo operator
                char cipher = _key1[i % _key1.Length];//imp
                //idexOfChiper is the position of character
                int indexOfChiper = Constants.Alphabet.IndexOf(cipher);

                char clearTextChar = ApplyCipherOperation(input[i], indexOfChiper);

                output.Append(clearTextChar);
            }

            return output.ToString();
        }

        private static void EnsureKeyUsesOnlyAlphabetLetters(
            string keyName,
            string keyValue)
        {
            char[] nonAlphabeticChars = keyValue
                .ToCharArray()
                .Where(k => !Constants.Alphabet.Contains(k))
                .ToArray();

            if (nonAlphabeticChars.Any())
            {
                string nac = string.Join(",", nonAlphabeticChars);
                throw new ArgumentException(
                    $"The key '{keyName}'='{keyValue}' contains the following non-alphabetic characters: {nac}");
            }
        }
    }
}
