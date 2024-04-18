using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
    public class MorseCodeTranslator
    {
        private Dictionary<char, string> textToMorse = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."}, {'F', "..-."},
            {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
            {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."},
            {'S', "..."}, {'T', "-"}, {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
            {'Y', "-.--"}, {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
            {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
            {' ', "/"}
        };

        private Dictionary<string, char> morseToText;

        public MorseCodeTranslator()
        {
            morseToText = new Dictionary<string, char>();
            foreach (var kvp in textToMorse)
            {
                morseToText.Add(kvp.Value, kvp.Key);
            }
        }

        public string TranslateToMorseCode(string text)
        {
            text = text.ToUpper();
            List<string> morseCodes = new List<string>();
            foreach (char c in text)
            {
                if (textToMorse.ContainsKey(c))
                {
                    morseCodes.Add(textToMorse[c]);
                }
            }
            return string.Join(" ", morseCodes);
        }

        public string TranslateToPlainText(string morseCode)
        {
            List<string> words = new List<string>(morseCode.Split(new[] { " / " }, StringSplitOptions.None));
            List<string> text = new List<string>();
            foreach (string word in words)
            {
                List<string> letters = new List<string>(word.Split(' '));
                foreach (string letter in letters)
                {
                    if (morseToText.ContainsKey(letter))
                    {
                        text.Add(morseToText[letter].ToString());
                    }
                }
                text.Add(" ");
            }
            return string.Join("", text).Trim();
        }
    }
}
