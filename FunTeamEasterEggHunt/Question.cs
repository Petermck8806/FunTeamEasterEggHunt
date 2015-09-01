using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTeamEasterEggHunt
{
    public class Question
    {
        public string QuestionImage { get; set; }
        public string QuestionPrompt { get; set; }
        public string Answer { get; set; }
        public bool isAnswered = false;
        public int SortOrder;

        public Question()
        {
            QuestionImage = "";
            QuestionPrompt = "";
            Answer = "";
            isAnswered = false;
        }

        public Question(string questionImage, string questionPrompt, string answer, int sortOrder)
        {
            this.QuestionImage = questionImage;
            this.QuestionPrompt = questionPrompt;
            this.Answer = answer;
            this.isAnswered = false;
            this.SortOrder = sortOrder;
        }

        public bool isAnswerCorrect(string answer)
        {
            return isAnswered = answer.Equals(this.Answer);
        }
    }
}
