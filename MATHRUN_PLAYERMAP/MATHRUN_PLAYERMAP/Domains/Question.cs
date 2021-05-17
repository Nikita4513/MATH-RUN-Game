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
        private char[] MathOperations = new[] { '+', '-', '*' };
        private int IndexRightAnswer;
        public char Operation { get; set; }

        public int[] PossibleAnswers { get; private set; }

        public Question(int maxNumber)
        {
            var rnd = new Random();
            var firstNumber = rnd.Next(maxNumber).ToString();
            var secondNumber = rnd.Next(maxNumber).ToString();
            IndexRightAnswer = rnd.Next(3);
            Operation = MathOperations[rnd.Next(3)];
            RightAnswer = Calculate(int.Parse(firstNumber), int.Parse(secondNumber), Operation);
            Value = string.Join(' ', firstNumber, Operation, secondNumber);
            PossibleAnswers = new int[3];
            PossibleAnswers[IndexRightAnswer] = RightAnswer;
            PossibleAnswers[(IndexRightAnswer + 1) % 3] = RightAnswer + rnd.Next(5) + 1;
            PossibleAnswers[(IndexRightAnswer + 2) % 3] = RightAnswer - rnd.Next(5) - 1;

        }

        public bool IsRightAnswer(int answer)
        {
            return answer == RightAnswer;
        }

        private int Calculate(int a, int b, char operation)
        {
            switch (operation)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                default:
                    return a / b;
            }
        }

    }
}
