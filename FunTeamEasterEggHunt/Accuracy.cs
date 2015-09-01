using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunTeamEasterEggHunt
{
    public static class Accuracy
    {
        public static void startTest()
        {
            Console.Clear();
            Utilities.DisplayPrompt();

            Console.CursorVisible = false;
            Utilities.WriteInfoPrompt("3");
            Thread.Sleep(1000);
            Utilities.WriteInfoPrompt("2");
            Thread.Sleep(1000);
            Utilities.WriteInfoPrompt("1");
            Thread.Sleep(1000);
            Utilities.WriteInfoPrompt("START!");
            Console.CursorVisible = true;
            Console.Clear();
            Utilities.ClearConsoleInput();
            Title.DiplayAccuracyIntro();
            Utilities.WriteInfoPrompt("START!");
            
            var start = DateTime.Now.TimeOfDay;

            Console.ReadKey(true);

            var endTime = DateTime.Now.TimeOfDay;
            var result = endTime.Subtract(start);

            Utilities.WriteInfoPrompt(string.Format("Result: {0} seconds | {1} milliseconds",result.Seconds,result.Milliseconds));

            //If the result is within 5 seconds +/- 250 milliseconds count the input.
            if ((result.Milliseconds <= 250 && result.Seconds == 5) || (Math.Abs(1000 - result.Milliseconds) <= 250 && result.Seconds == 4))
            {
                Utilities.WriteInfoPrompt("Hooray!");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Utilities.WriteInfoPrompt("BAD! ");
                Thread.Sleep(2000);
                Console.Clear();
                startTest();
            }

        }
    }
}
