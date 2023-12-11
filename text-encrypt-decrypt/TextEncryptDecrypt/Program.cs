namespace TextEncryptDecrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Pași de Decodificare:
                - Eliminați caracterele "^" și "~" din text.
                - Înlocuiți caracterele "{", "}", "(", ")" cu spații.
                - Înlocuiți cifrele cu literele corespunzătoare.
                - Inversați ordinea caracterelor rămase în text.
                - Înlocuiți caracterele cu literele corespunzătoare, utilizând cheile Cheie1 și Cheie2 în mod alternativ.
                  Cheile sunt folosite in cadrul unui algoritm de criptare cu substitutie.
                    Hint 1: Drept autor al tehnicii de criptare, este creditat unul dintre imparatii romani care au trait intre 12 July 100 BC – 15 March 44 BC
                    Hint 2: Fiecare litera din cheie reprezinta de fapt un deplasament, in functie de indexul ei din alfabet
                - Afișați mesajul rezultat.
             */

            string text = "Felicitari ai castigat concursul organizat de Fortech, o companie GlobalLogic.";
            Console.WriteLine($"Original text={text}");

            string encoded = EncoderDecoder.Execute(
                text,
                new EncodeWithAlternateKeysTransformationStep(Constants.Key1),
                new ReverseStringTransformationStep(),
                new ReplaceLettersWithDigitsTransformationStep(),
                new ReplaceStringWithOneOfCharactersTransformationStep(" ", '{', '}', '(', ')'),
                new InsertRandomCharactersTransformationStep(5, '^', '~'));

            Console.WriteLine($"Encoded text={encoded}");

            string decoded = EncoderDecoder.Execute(
                encoded,
                new RemoveCharactersTransformationStep('^', '~'),
                new ReplaceCharactersWithStringTransformationStep(" ", '{', '}', '(', ')'),
                new ReplaceDigitsWithLettersTransformationStep(),
                new ReverseStringTransformationStep(),
                new DecodeWithAlternateKeysTransformationStep(Constants.Key1));

            Console.WriteLine($"Decoded text={decoded}");
        }
    }
}