namespace TextEncryptDecrypt
{
    internal class RemoveCharactersTransformationStep 
        : ReplaceCharactersWithStringTransformationStep
    {
        public RemoveCharactersTransformationStep(params char[] characters)
            : base(string.Empty, characters)
        {
        }
    }
}
