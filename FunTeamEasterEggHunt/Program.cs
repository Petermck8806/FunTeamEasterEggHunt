using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.Media;

namespace FunTeamEasterEggHunt
{
    class Program
    {
        static bool endDisplay = false;
        static bool end = false;
        static List<Question> questions;

        static void Main(string[] args)
        {
            Initialize();

            var startScreenThread = new Thread(DisplayStartScreen);
            startScreenThread.Start();

            while (!end)
            {
                Thread.Sleep(5000);
                Utilities.WriteInfoPrompt("\t\t\t\tPress any key to continue.");
                Console.ReadKey(); //press any key to continue.

                DisposeStartScreen();
                startScreenThread.Abort();
                Console.Clear();

                Title.Intro();
                Console.SetCursorPosition(20, 7);

                Utilities.DisplayDelayed("Hello! Welcome to the Hunt! You guys\n\t\t║███shall be tested and put through trials.\n\t\t║███"
                                     + "You guys' brains will be measured.\n\n\t\t║███Only the strong will survive.\n\n\t\t║███"
                                      + "Continue if you dare. Losers will be\n\t\t║███lost in time, like tears in rain.", 20, 7,75);

                Thread.Sleep(22000);

                Console.SetCursorPosition(20, 31);
                Console.Write("Press any key to continue...");

                Console.ReadKey();
                Console.Clear();

                Quiz.StartQuiz();

                Console.Clear();
                Title.DisplayCongrats();

                var pass = Utilities.PromptPassword();

                ExitMethod(pass);

                Console.ReadLine();
            }
        }

        private static void DisposeStartScreen()
        {
            endDisplay = true;
            Console.Clear();
            Console.CursorVisible = true;
        }

        private static void Initialize()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.Title = "CTS Easter Egg Hunt";

            Console.SetWindowSize(85, 40);

        }

        private static void CreateQuestions()
        {
            questions = new List<Question>();

            questions.Add(new Question("Image1",
                                       "What is your name?",
                                       "Peter",1));
            questions.Add(new Question("Image2",
                                       "What is your favorite color?",
                                       "Blue, no green!",2));
            questions.Add(new Question("Image3",
                                       "Some other question?",
                                       "Some other answer.",3));
            questions.Add(new Question("Image4",
                                       "Our fourth question?",
                                       "Our fourth answer.",4));
            questions.Add(new Question("Image5",
                                       "The final questions?",
                                       "The final answer",5));
        }

        private static void DisplayQuestion(Question question)
        {
            //I have not written you!
            //DisplayQuestionImage(question.QuestionImage);
            Console.WriteLine(question.QuestionImage);
            Console.WriteLine(question.QuestionPrompt);
        }

        private static void DisplayStartScreen()
        {
            //play music
            SoundPlayer sp = new SoundPlayer(".\\Music\\Title.wav");
            
            //display start screen
            Console.Clear();
            Title.TitleNoFire();
            Thread.Sleep(2000);
            Console.Clear();
            sp.PlayLooping();
            while (!endDisplay)
            {
                Title.TitleFire1();
                Thread.Sleep(250);
                Console.Clear();
                Title.TitleFire2();
                Thread.Sleep(250);
                Console.Clear();
                Title.TitleFire3();
                Thread.Sleep(250);
                Console.Clear();
            }
        }

        //totally not implemented yet.
        private static void ExitMethod(string password)
        {
            end = true;
            Console.Clear();
            switch(password)
            {
                case Password.Password1:
                    Title.DisplayBookshelf();
                    break;
                case Password.Password2:
                    Title.DisplayBricks();
                    break;
                case Password.Password3:
                    Title.DisplayGrill();
                    break;
                case Password.Password4:
                    Title.DisplayMopCloset();
                    break;
                case Password.Password5:
                    Title.DisplayPaddedRoom();
                    break;
                case Password.Password6:
                    Title.DisplayToolbox();
                    break;
                default:
                    break;
            }
        }
    }
}
