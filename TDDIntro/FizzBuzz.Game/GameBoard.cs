﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Game
{
    public class GameBoard
    {
        public string GetWord(int number)
        {
            if (number % 15 == 0)
            {
                return "FizzBuzz";
            }
            if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 ==0)
            {
                return "Buzz";
            }
            return number.ToString();
        }
    }
}
