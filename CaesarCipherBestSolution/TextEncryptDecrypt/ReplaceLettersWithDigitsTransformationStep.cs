using System.Text;

namespace TextEncryptDecrypt
{
    internal class ReplaceLettersWithDigitsTransformationStep : TextTransformationStep
    {
        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            char firstLetter = 'A';
            StringBuilder output = new StringBuilder(input);
            for (int digit = 0; digit <= 9; digit++)
            {
                char letter = (char)(firstLetter + digit);
                output.Replace(letter.ToString(), digit.ToString());
            }

            return output.ToString();
        }
    }
}
