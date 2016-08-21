using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public enum QUESTION_TYPE
    {
        Regular,
        Gold,
        Poop
    }
    public class MultiChoiceQuestion
    {
        public string Question { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string ImageTag { get; set; }
        public string Answer { get; set; }
        public QUESTION_TYPE QuestionType { get; set; }


        //public MultiChoiceQuestion(string question, string a, string b, string c, string d)
        //{
        //    Question = question;
        //    A = a;
        //    B = b;
        //    C = c;
        //    D = d;
        //}
    }
}
