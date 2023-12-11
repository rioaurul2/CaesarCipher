using System.Text;

namespace TextEncryptDecrypt
{
    internal class ReplaceCharactersWithStringTransformationStep : TextTransformationStep
    {
        private readonly char[] _characters;
        private readonly string _replaceWith;

        public ReplaceCharactersWithStringTransformationStep(
            string replaceWith,
            params char[] characters)
        {
            _replaceWith = replaceWith ?? string.Empty;
            _characters = characters;
        }

        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder(input);
            foreach (char c in _characters)
            {
                output.Replace(c.ToString(), _replaceWith);
            }

            return output.ToString();
        }
    }
}
