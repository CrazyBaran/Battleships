using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Battleships
{
    public static class LetterToNumberConverter
    {
        private static Regex AllowedLetters = new Regex("[a-zA-Z]");
        public static int? ToNumber(this char letter)
        {
            if (!AllowedLetters.IsMatch(letter.ToString())) return null;
            return char.ToUpperInvariant(letter) - 64;
        }
    }
}
