namespace TextEncryptDecrypt
{
    internal class CaesarCipher
    {
        private readonly string _alphabet;
        
        public CaesarCipher(string alphabet)
        {
            if (string.IsNullOrEmpty(alphabet))
            {
                throw new ArgumentNullException(nameof(alphabet));
            }

            _alphabet = alphabet;
        }

        public char Encode(char clearTextChar, int shift)
        {
            if (!_alphabet.Contains(clearTextChar))
            {
                throw new ArgumentException($"Letter '{clearTextChar}' not contained in the alphabet.");
            }

            if (shift < 0)
            {
                throw new ArgumentException($"Shift '{shift}' must be positive.");
            }

            int indexOfClearTextChar = _alphabet.IndexOf(clearTextChar);

            int substitutionIndex = (indexOfClearTextChar + shift) % _alphabet.Length;

            char encryptedChar = _alphabet[substitutionIndex];

            if (!_alphabet.Contains(encryptedChar)) 
            {
                // mostly a self-check, Caesar being a substitution cipher
                // must produce an output that is inside the alphabet
                throw new ArgumentException($"Encrypted letter '{encryptedChar}' not contained in the alphabet.");
            }

            return encryptedChar;
        }

        public char Decode(char encodedChar, int shift)
        {
            if (!_alphabet.Contains(encodedChar))
            {
                throw new ArgumentException($"Encrypted letter '{encodedChar}' not contained in the alphabet.");
            }

            if (shift < 0)
            {
                throw new ArgumentException($"Shift '{shift}' must be positive.");
            }

            int indexOfEncodedChar = _alphabet.IndexOf(encodedChar);

            int substitutionIndex = (indexOfEncodedChar - shift) % _alphabet.Length;

            // given the shift may be bigger that the index,
            // we may need to cycle from the beginning a few times
            // till we reach to an index inside the alphabet
            while (substitutionIndex < 0)
            {
                substitutionIndex = _alphabet.Length + substitutionIndex;
            }

            char clearTextChar = _alphabet[substitutionIndex];

            if (!_alphabet.Contains(clearTextChar))
            {
                // mostly a self-check, Caesar being a substitution cipher
                // must produce an output that is inside the alphabet
                throw new ArgumentException($"Clear text letter '{clearTextChar}' not contained in the alphabet.");
            }

            return clearTextChar;
        }
    }
}
