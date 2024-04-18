using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.GameLogic;

//namespace TicTacToe.UserInterface
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            char player1Symbol = 'X';
//            char player2Symbol = 'O';
//            bool player2IsComputer = false;

//            TicTacToeGame game = new TicTacToeGame(player1Symbol, player2Symbol, player2IsComputer);
//            game.StartGame();

           
//        }
//    }
//}

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            MorseCodeTranslator translator = new MorseCodeTranslator();

            string textToTranslate = "HELLO WORLD";
            string morseCode = translator.TranslateToMorseCode(textToTranslate);
            Console.WriteLine($"Original text: {textToTranslate}");
            Console.WriteLine($"Morse code: {morseCode}");

            string morseCodeToTranslate = ".... . .-.. .-.. --- / .-- --- .-. .-.. -..";
            string translatedText = translator.TranslateToPlainText(morseCodeToTranslate);
            Console.WriteLine($"Morse code: {morseCodeToTranslate}");
            Console.WriteLine($"Translated text: {translatedText}");
        }
    }
}
