using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessGame guessGame = new GuessGame(1, 20);
            guessGame.Play();
        }
    }
}
