using System.Collections;
using System.Windows.Forms;

namespace MyFirstSnakeGame
{
    class Input
    {
        /*Load List of available Keyboard buttons*/
        private static Hashtable KeyTable = new Hashtable();

        /*Perform a check to see if a particular button is pressed*/
        public static bool KeyPressed(Keys key)
        {
            if (KeyTable[key] == null)
            {
                return false;
            }
            else
            {
                return (bool)KeyTable[key];
            }
        }

        /*Detect if a keyboard button is pressed*/
        public static void ChangeState(Keys key, bool state)
        {
            KeyTable[key] = state;
        }
    }
}
