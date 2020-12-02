using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    // abstract klassen får man inte skapa objekt utav. Konkret = objekt. I Main går det inte att skapa en instans (ett objekt) av den abstrakta klassen House.
    // abstract klassen är enbart en mall för att hålla gemensamma egenskaper och metoder.
    public abstract class House
    {
        public string HouseGhost { get; set; } // = "Den Tjocke Munkbrodern";
        public string Mascot { get; set; } // = "Grävling";
        public string Members { get; set; } //= null;
        public string Password { get; set; } //= "en ensam trollkarl";


        //METOD 1. Kollar att lösenordet uppfyller kraven: fem bokstäver.
        public static bool NumberOfLetters(string newPassword) // static bool NumberOfLetters(string[] newPassword)
        {
            if (newPassword.Length >= 5)
            {
                return true;
            }
            return false;
        }

        //METOD 2a kollar vokaler. Kan användas för att kolla konsonanter senare.
        public virtual bool IsVowel(char newPassword)
        {
            string vowels = "aeiouyåäöAEIOUYÅÄÖ";
            foreach (char vowel in vowels)
            {
                if (vowel == newPassword)
                {
                    return true;
                }
            }
            return false;
        }

        //METOD 2b. Kollar att lösenordets första bokstav är vokal.
        static bool IsVowelTheFirstChar(string[] newPassword)
        {
            string[] v = { "a", "e", "i", "o", "u", "y", "å", "ä", "ö", "A", "E", "I", "O", "U", "Y", "Å", "Ä", "Ö" };
            string[] vowelList = v;
            string first = vowelList[0];

            for (int i = 1; i < vowelList.Length; i++)
            {
                if (vowelList[i].CompareTo(first) < 0)
                {
                    first = vowelList[i];
                    return true;
                }
            }
            return false;
        }

        //METOD 3. Kollar att lösenordets sista bokstav är konsonant.
        public virtual bool LastCharConsonant(string newPassword)
        {
            char lastLetter = newPassword[newPassword.Length - 1];

            if (!IsVowel(lastLetter) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //METOD 4. Uppfylls de tre kraven?
        public virtual bool CheckPassword(string newPassword, string[] v)
        {

            if (NumberOfLetters(newPassword) == true && IsVowelTheFirstChar(v) == true && LastCharConsonant(newPassword) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //METOD 5. Rawenclaw kräver åtta bokstäver i lösenordet.
        private static bool RawenClawPasswordLetter(string newPassword)
        {
            if (newPassword.Length >= 8)
            {
                return true;
            }
            return false;
        }

        //METOD 6. Rawenclaw kräver konsonant i första och sista bokstaven i lösenordet.
        public virtual bool RawenClawConsonant(string newPassword)
        {
            char lastLetter = newPassword[newPassword.Length - 1];
            char firstLetter = newPassword[newPassword.Length + 0];

            if (!IsVowel(lastLetter) == true && !IsVowel(firstLetter) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //METOD 7. Kontroll av HasCorrectPasswordFormat ("en ensam trollkarl") => true.
        //public bool HasCorrectPasswordFormat(string NewPassword, string PasswordChange)
        //{
        //    bool isPasswordChange = true;
        //}

        public string CheckPasswordFormat { get; private set; }

        public bool SetPassword(string newPassword, string newCorrectPassword)
        {
            bool PasswordChanged = true;
            if (newPassword(newCorrectPassword) == true)
            {
                newPassword = newCorrectPassword;
                PasswordChanged = true;
            }
            else
            {
                PasswordChanged = false;
            }
            return PasswordChanged;
        }
    }
}

   

