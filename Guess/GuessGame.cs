using System;

namespace Guess
{
    public class GuessGame
    {
        public int number { get; set; }
        public int triesCount { get; set; }

        // Generuje losową liczbę w zakresie od min do max i przypisuje ją do zmiennej number
        public GuessGame(int min, int max)
        {
            GenerateNumber(min, max);
        }

        // Generuje ponownie losową liczbę w zakresie od min do max i przypisuje ją do zmiennej number
        public int GenerateNumber(int min, int max)
        {
            Random random = new Random();
            number = random.Next(min, max + 1);
            triesCount = 0;

            return number;
        }

        // Jeżeli podana liczba jest równa zgadywanej funkcja zwraca 0
        // Jeżeli podana liczba jest większa od zgadywanej funkcja zwraca 1
        // Jeżeli podana liczba jest mniejsza od zgadywanej funkcja zwraca -1
        public int Guess(int guessNumber)
        {
            triesCount++;

            if(guessNumber > number)
            {
                return 1;
            }
            else if(guessNumber < number)
            {
                return -1;
            }

            return 0;
        }

        // Konwertuje tekst na liczbę
        public bool ReadGuess(string guess, out int result)
        {
            return Int32.TryParse(guess, out result);
        }

        public void Play()
        {
            while(true)
            {
                Console.WriteLine("Podaj liczbę: ");
                int guess;
                while(!ReadGuess(Console.ReadLine(), out guess));

                switch(Guess(guess))
                {
                    case 0:
                        Console.WriteLine("Wygrałeś w " + triesCount + " próbach");
                        Console.ReadKey(false);
                        return;

                    case 1:
                        Console.WriteLine("Za dużo");
                        break;

                    case -1:
                        Console.WriteLine("Za mało");
                        break;
                }
            }
        }
    }
}
