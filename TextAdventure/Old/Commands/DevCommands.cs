using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure.Commands
{
    public static class Dev
    {
        public static string Kill()
        {
            return string.Format("You died");
        }
        public static string SingBirds(string _input = "to the birds")
        {
            return string.Format("You sing {0}", _input);
        }
        public static string Echo(string _input)
        {
            return string.Format("You hear {0} echo back", _input);
        }
        public static string GetCurrentRoom()
        {
            throw new NotImplementedException();
        }
        public static string Num(int num)
        {
            return num.ToString();
        }
        
        public static string DevBlah()
        {
            return "blah";
        }

    }
}
