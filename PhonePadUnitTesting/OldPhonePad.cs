using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

class Phone
{
    private static Dictionary<char, string> inputPad = new()
    {
        //Simple structure to maintain the characters available in each key
        {'1', "&'(" },
        {'2', "ABC" },
        {'3', "DEF" },
        {'4', "GHI" },
        {'5', "JKL" },
        {'6', "MNO" },
        {'7', "PQRS" },
        {'8', "TUV" },
        {'9', "WXYZ" },
        {'0', " " },
    }; 
    public static String OldPhonePad(string input)
    {
        //The entire method should retun the final text
        StringBuilder text = new StringBuilder();
        int position = 0;

        while (position < input.Length)
        {
            char currentKey = input[position];
            int appearances = 1;
            Debug.WriteLine("Entered the main loop, currently evaluating the pressing of the following key: " + currentKey);
            if (currentKey == '#')
            {
                Debug.WriteLine("Found the # character, exiting: " + currentKey);
                break;
            }
            else if (currentKey == ' ')
            {
                //Spaces represent that we have finished typing a char via a 'pause'
                Debug.WriteLine("Found the ' ' character");
                position++;
                continue;
            }
            else if (currentKey =='*')
            {
                //Remove the last char from the text and go into the next loop
                Debug.WriteLine("Found the '*' character. Text before executing: " + text.ToString());
                if (text.Length > 0)
                {
                    text.Remove(text.Length - 1, 1);
                }
                position++;
                Debug.WriteLine("Found the '*' character. Text after executing: " + text.ToString());
                continue;
            }
            else if (inputPad.ContainsKey(currentKey))
            {
                //Count consecutive appearances
                //Second part of the condition is to avoid Index out of range
                while (input[position] == input[position + appearances] && position + appearances < input.Length)
                {
                    appearances++;
                }

                //Added a cycle capability i.e. if pressed a fourth time the key will return to its first character.
                Debug.WriteLine("Found the "+ currentKey + " character. " +
                    "\nNecessary variables" +
                    "\n Appearances:" + appearances + 
                    "\nLength in the keypad: " + inputPad[currentKey].Length + " " + inputPad[currentKey]);

                if (appearances % inputPad[currentKey].Length != 0)
                {
                    text.Append(inputPad[currentKey][appearances% inputPad[currentKey].Length - 1]);
                }
                else
                {
                    text.Append(inputPad[currentKey][inputPad[currentKey].Length - 1]);
                }
                

            }

            else
            {
                return "There is a bad character in the input!: " + currentKey;
                //Handle strange characters
            }

            //We need to increase the position that we are looking at by the number of appearances the same character had
            Debug.WriteLine("Shifting position at the end of the loop." +
                "\nPosition at the beginning of the loop: " + position + 
                "\nAppearances: " + appearances + 
                "\nNew Position should be: " + position+appearances
              );
            position +=appearances;
        }



        //return the final text
        return text.ToString();
    }

}