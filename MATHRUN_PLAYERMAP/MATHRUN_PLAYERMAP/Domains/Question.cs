using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATHRUN_PLAYERMAP.Domains
{
    class Question
    {
        public string Value { get; private set; }
        public int RightAnswer { get; set; }
        private char[] MathOperations = new[] { '+', '-', '*', '/' };

        public Question(int maxNumber)
        {
            var rnd = new Random();
            var firstNumber = rnd.Next(maxNumber).ToString();
            var secondNumber = rnd.Next(maxNumber).ToString();
            RightAnswer = int.Parse(firstNumber) + int.Parse(secondNumber);
            Value = string.Join(' ', firstNumber, MathOperations[rnd.Next(4)], secondNumber);
        }

        public bool IsRightAnswer(int answer)
        {
            return answer == RightAnswer;
        }
    }
}
