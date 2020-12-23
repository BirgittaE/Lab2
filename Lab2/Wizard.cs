using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Wizard
    {
        public string Name { get; set; }
        public Type BloodStatus { get; set; }
        public bool DeathEater { get; set; }

        public bool DumbledoresArmy;
         

        public enum Type
        {
            Renblod = 0,
            Halvblod = 1,
            Mugglarfödd = 2,
            Okänt = 3
        } 
    }
}
