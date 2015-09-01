using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTeamEasterEggHunt
{
    public static class Password
    {
        public const string Password1 = "blunderbuss";
        public const string Password2 = "filibuster";
        public const string Password3 = "babaghanoush";
        public const string Password4 = "llewtrahsttocs";
        public const string Password5 = "interiorcrocodilealligator";
        public const string Password6 = "chevroletmovietheater";
        
        public static string[] GetPasswords()
        {
            return new string[] { Password1, Password2, Password3, Password4, Password5, Password6 };
        }
    }
}