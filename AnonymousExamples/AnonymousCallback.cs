using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.LambdaExamples
{
    internal class AnonymousCallback
    {
        /// <summary>
        /// This is the original function Foo that has a common routine and a custom calculation routine
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callbackFunction">References a function that performs the custom display message</param>
        /// <returns></returns>
        public static void DisplayMessage(int timesToRepeatMsg, string message, Action<string> callbackFunction)
        {
            for (int count = 0; count < timesToRepeatMsg; count++)
            {
                // invoke the custom callback function
                callbackFunction(message);
            }
        }

        public static void AppendPuncuationMarks(string msg)
        {
            if (msg.Equals("wtf", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("@$#!");
            else
                Console.WriteLine("{0}!!!!!", msg);
        }

    }
}
