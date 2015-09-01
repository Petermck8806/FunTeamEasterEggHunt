using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTeamEasterEggHunt
{
    public enum QuizQuestionsEnum
    {
        Shamu = 1,
        Squares = 2,
        Manute = 3,
        Chess = 4
    }

    public static class Quiz
    {

        public static string ShamuAnswer = "kalina";
        public static string ManuteAnswer = "7,7";
        public static string ChessAnswer = "a5:b6";
        public static string SquaresAnswer = "35";

        public static void StartQuiz()
        {
            string input = "";

            while (!isAnswer(QuizQuestionsEnum.Shamu, input))
            {
                Console.Clear();
                Title.DisplayShamu();
                input = Console.ReadLine();
            }

            input = "";
            while (!isAnswer(QuizQuestionsEnum.Manute, input))
            {
                Console.Clear();
                Title.DisplayManute();
                input = Console.ReadLine();
            }

            Accuracy.startTest();

            input = "";
            while (!isAnswer(QuizQuestionsEnum.Chess, input))
            {
                Console.Clear();
                Title.DisplayChess();
                input = Console.ReadLine();
            }

            input = "";
            while (!isAnswer(QuizQuestionsEnum.Squares, input))
            {
                Console.Clear();
                Title.DisplaySquares();
                input = Console.ReadLine();
            }

            Patience.startTest();


        }

        public static bool isAnswer(QuizQuestionsEnum question, string answer)
        {
            switch (question)
            {
                case QuizQuestionsEnum.Shamu:
                    return ShamuAnswer.Equals(answer.ToLower());
                case QuizQuestionsEnum.Squares:
                    return SquaresAnswer.Equals(answer.ToLower());
                case QuizQuestionsEnum.Manute:
                    return ManuteAnswer.Equals(answer.ToLower());
                case QuizQuestionsEnum.Chess:
                    return ChessAnswer.Equals(answer.ToLower());
                default:
                    return false;
            }
        }
    }
}
