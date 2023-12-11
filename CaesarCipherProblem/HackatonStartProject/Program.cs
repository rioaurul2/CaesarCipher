using System.Text;

namespace HackatonStartProject
{
    internal class Program
    {
        const string encryptedText = ">&%%S^,Kf*10zc3n5,4QQ1<6NRL43y91^je62<L,OMP!l91PPWRwM;2S^4Zy?*#^XU!hS%;eKQfL%>M^N3K";
        static string decryptedText = encryptedText;

        static void Main(string[] args)
        {
            /*
             Pași de Decodificare:
                - Eliminați caracterele "^" și "~" din text.
                - Înlocuiți caracterele "{", "}", "(", ")" cu spații.
                - Înlocuiți cifrele cu literele corespunzătoare.
                    Hint: 0 corespunde literei "A"
                - Inversați ordinea caracterelor rămase în text.
                - Înlocuiți caracterele cu literele corespunzătoare, utilizând cheia Constants.Key1.
                  Cheile sunt folosite in cadrul unui algoritm de criptare cu substitutie, alfabetul recunoscut fiind specificat in Constants.Alphabet.
                    Hint 1: Drept autor al tehnicii de criptare, este creditat unul dintre imparatii romani care au trait intre 12 July 100 BC – 15 March 44 BC
                    Hint 2: Fiecare litera din cheie reprezinta de fapt un deplasament, in functie de indexul ei din alfabet
                - Afișați mesajul rezultat.
             */
            // TODO: implement decryption

            if (string.IsNullOrWhiteSpace(encryptedText))
            {
                throw new ArgumentNullException(nameof(encryptedText));
            }

            RemoveCharacters();
            Console.WriteLine($"First step result: {decryptedText}");

            ReplaceCharacters();
            Console.WriteLine($"Second step result: {decryptedText}");

            ReplaceNumbers();
            Console.WriteLine($"Third step result: {decryptedText}");

            SwitchCharacters();
            Console.WriteLine($"Fourth step result: {decryptedText}");

            Decrypt();
            Console.WriteLine($"Decrypted text: {decryptedText}\n");

            Console.WriteLine("Pasii metodei de criptare folosind o cheie de tip 'cuvant' presupune:\n" +
                "1.Atribuirea unei valori pentru 'swift' in functie de pozitia characterelor din cuvantul cheie in alfabetul dat astfel 'swift-ul' va fi diferit de la un caracter la altul daca acestea nu sunt identice.\n" +
                "2.Este important de luat in calcul posibilitatea index-ului de a fi in exteriorul array-ului se sugereaza implementarea unor preventii.\n");
        }

        private static void RemoveCharacters()
        {
            var charactersToBeRemoved = new string[] { "^", "~" };

            foreach (string character in charactersToBeRemoved)
            {
                decryptedText = decryptedText.Replace(character, string.Empty);
            }
        }

        private static void ReplaceCharacters()
        {
            var charactersToBeReplaced = new string[] { "{", "}", "(", ")" };

            foreach (string character in charactersToBeReplaced)
            {
                decryptedText = decryptedText.Replace(character, " ");
            }
        }

        private static void ReplaceNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                char replacementChar = (char)('A' + i);
                decryptedText = decryptedText.Replace(i.ToString(), replacementChar.ToString());
            }
        }

        private static void SwitchCharacters()
        {
            StringBuilder output = new StringBuilder();

            var stringArray = decryptedText.ToCharArray();

           Array.Reverse(stringArray);

            for(int i = 0; i < stringArray.Length; i++)
            {
                output.Append(stringArray[i]);
            }

            decryptedText = output.ToString();
        }

        private static void Decrypt()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < decryptedText.Length; i++)
            {
                char cipher = Constants.Key1[i % Constants.Key1.Length];
                int indexOfChiper = Constants.Alphabet.IndexOf(cipher);

                char encodedTextChar = DecryptAlgoritm(decryptedText[i], indexOfChiper);

                output.Append(encodedTextChar);
            }

            decryptedText = output.ToString();
        }

        private static char DecryptAlgoritm(char encodedTextChar, int shift)
        {
            int indexOfEncodedTextChar = Constants.Alphabet.IndexOf(encodedTextChar);

            if (indexOfEncodedTextChar == -1)
            {
                return encodedTextChar;
            }

            int substitutionIndex = (indexOfEncodedTextChar - shift + Constants.Alphabet.Length) % Constants.Alphabet.Length;

            char dencryptedChar = Constants.Alphabet[substitutionIndex];

            if (!Constants.Alphabet.Contains(dencryptedChar))
            {
                throw new ArgumentException($"Decrypted letter '{dencryptedChar}' i not contained in the alphabet.");
            }

            return dencryptedChar;

        }

        //Aceasta parte este doar o procedura de revenire la versiunea anterioara inainte ca textul sa fi fost decriptat

        //private static void Encrypt()
        //{
        //    StringBuilder output = new StringBuilder();

        //    for (int i = 0; i < decryptedText.Length; i++)
        //    {
        //        char cipher = Constants.Key1[i % Constants.Key1.Length];
        //        int indexOfChiper = Constants.Alphabet.IndexOf(cipher);

        //        char encodedTextChar = EncryptAlgoritm(decryptedText[i], indexOfChiper);

        //        output.Append(encodedTextChar);
        //    }

        //    decryptedText = output.ToString();
        //}

        //private static char EncryptAlgoritm(char encodedTextChar, int shift)
        //{
        //    int indexOfEncodedTextChar = Constants.Alphabet.IndexOf(encodedTextChar);

        //    if (indexOfEncodedTextChar == -1)
        //    {
        //        return encodedTextChar;
        //    }

        //    int substitutionIndex = (indexOfEncodedTextChar + shift) % Constants.Alphabet.Length;

        //    char dencryptedChar = Constants.Alphabet[substitutionIndex];

        //    if (!Constants.Alphabet.Contains(dencryptedChar))
        //    {
        //        throw new ArgumentException($"Decrypted letter '{dencryptedChar}' i not contained in the alphabet.");
        //    }

        //    return dencryptedChar;

        //}
    }
}