namespace TextEncryptDecrypt
{
    internal class DecodeWithAlternateKeysTransformationStep : CaesarCipherTransformationStep
    {
        public DecodeWithAlternateKeysTransformationStep(
            string key1)
            : base(key1)
        {
        }

        protected override char ApplyCipherOperation(char input, int shift)
        {
            return Cipher.Decode(input, shift);
        }
    }
}
