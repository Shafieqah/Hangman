using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _guess;
        private object mysteryWord;
        private int _numberOfLives;
        private string progress;
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {

            _numberOfLives = 6;

            _renderer.Render(5, 5, 6);

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            var nextGuess = Console.ReadLine();

            Random random = new Random();

            string[] listwords = new string[10];
            listwords[0] = "shafieqah";
            listwords[1] = "mesha";
            listwords[2] = "chauntina";
            listwords[3] = "kayla";
            listwords[4] = "angel";
            listwords[5] = "lauren";
            listwords[6] = "rhaadi";
            listwords[7] = "taryn";
            listwords[8] = "sima";
            listwords[9] = "sam";

            var index = random.Next(0, 20);

            string mysteryWord = listwords[index];

            char[] guess = mysteryWord.ToCharArray();


            for (int i = 0; i < guess.Length; i++)
            {

                progress += "_";
                Console.SetCursorPosition(0, 17);

            }
           
            


            while (_numberOfLives > 0)
            {
                _renderer.Render(5, 5, _numberOfLives);
                Console.SetCursorPosition(0, 17);

                char playerGuess = char.Parse(Console.ReadLine());


                char[] ProgressArray = progress.ToCharArray();

                bool correct = false;


                bool v = 0 < guess.Length;

                for (int i = 0; i < guess.Length; i++) 
                {
                    if (guess[i] == playerGuess)
                    {
                        ProgressArray[i] = guess[i];
                        correct = true;
                    }
                }
                progress = new string(ProgressArray);
                Console.SetCursorPosition(0, 18);

                Console.WriteLine(progress);

                if (!correct)
                {
                    _numberOfLives--;
                    _renderer.Render(5, 5, _numberOfLives);
                }
            }

            Console.SetCursorPosition(2, 22);

            if (_numberOfLives == 0)
            {
                Console.WriteLine($"game over");
            }
            else
            {
                Console.WriteLine($"you won with {_numberOfLives} left.");
            }
        }

    }
}
