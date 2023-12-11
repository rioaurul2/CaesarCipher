namespace TextEncryptDecrypt
{
    internal class EncodeWithAlternateKeysTransformationStep : CaesarCipherTransformationStep
    {
        public EncodeWithAlternateKeysTransformationStep(
            string key1)
            : base(key1)
        {
        }

        protected override char ApplyCipherOperation(char input, int shift)
        {
            return Cipher.Encode(input, shift);
        }
    }
}
