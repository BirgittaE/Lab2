using System.Collections.Generic; 

namespace Lab2
{
    // Den abstracta klassen är enbart en mall för att hålla gemensamma egenskaper och metoder, inte för att skapa en instans (ett objekt)
    public abstract class House
    {
        protected string[] v = { "a", "e", "i", "o", "u", "y", "å", "ä", "ö", "A", "E", "I", "O", "U", "Y", "Å", "Ä", "Ö" };
        public string HouseGhost { get; set; } // = "Den Tjocke Munkbrodern";
        public string Mascot { get; set; } // = "Grävling";
        protected string Password { get; set; } //= "en ensam trollkarl";
        public List<Wizard> Members { get; set; } //= null;
 
      
            // Kolla befintligt lösenord och byte av lösenord! Felaktiga metoder nedan. Läs instruktion. Byt namn till nuvarande lösenord och gammalt lösenord.

            //METOD 1. Kollar att lösenordet uppfyller kraven: fem bokstäver.
            public virtual bool NumberOfLetters(string newPassword) // static bool NumberOfLetters(string[] newPassword)
            {
                if (newPassword.Length >= 5)
                {
                    return true;
                }
                return false;
            }

            //METOD 2a kollar vokaler. Kan användas för att kolla konsonanter senare.
            protected virtual bool IsVowel(char newPassword)
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
            protected bool IsVowelTheFirstChar(string[] newPassword)
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
            protected virtual bool LastCharConsonant(string newPassword)
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
         
        public virtual bool SetPassword(string currentPassword, string password)
        { 
             if (Password.Equals(currentPassword))
             {
                // som ska utvärderas i en metod som kontrollerar lösenordets utformning.
                if (CheckPassword(password, v))
                {
                    this.Password = password;

                    return true;
                } 
                else
                {
                    return false;
                }
             }
             else
             {
                return false;
             } 
        }
    } 
} 