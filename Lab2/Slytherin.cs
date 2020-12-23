using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Slytherin : House
    {
        // Använder den abstrakta klassen House.

        public Slytherin()
        {  
            HouseGhost = "Blodiga Baronen";
            Mascot = "Orm";
            Password = "Slytherin";
        }

        //METOD  Slytherin kräver konsonant i första och sista bokstaven i lösenordet.

        public override bool NumberOfLetters(string newPassword)
        {
            if (newPassword.Length >= 8)
            {
                return true;
            }
            return false;
        }

        public override bool CheckPassword(string newPassword, string[] v)
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

        public override bool SetPassword(string currentPassword, string password)
        {
            if (Password.Equals(currentPassword))
            { 
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