using Domains_MATH_RUN.Domains;
using MATHRUN_PLAYERMAP.Domains;
using System;

namespace Domains_MATH_RUN
{
    class Game
    {
        public int Scores { get; set; }
        public Player Player { get; private set; }
        public Monster Monster { get; private set; }
        public Field Field { get; private set; }
        public Question CurrentQuestion { get; private set; }
        public bool IsOver { get; set; }
        private int numberLevel = 0;


        public Game()
        {
            InitializeGame();
        }

        public Question GetNextQuestion()
        {
            CurrentQuestion = new Question(15);
            return CurrentQuestion;
        }

        public bool TryGetNextLevel()
        {
            numberLevel++;
            if (numberLevel >= Levels.AllLevels.Length)
                return false;
            InitializeGame();
            return true;
        }

        public void InitializeCurrentLevel()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            if (numberLevel >= Maps.AllMaps.Length)
                throw new Exception("There are no more levels!");
            Field = new Field(Levels.AllLevels[numberLevel]);
            Scores = 0;
            var playerLocation = Field.GetLocationOf(typeof(Player));
            this.Player = (Player)Field.Map[playerLocation.X, playerLocation.Y];
            var monsterLocation = Field.GetLocationOf(typeof(Monster));
            this.Monster = (Monster)Field.Map[monsterLocation.X, monsterLocation.Y];
            this.CurrentQuestion = new Question(15);
            this.Scores = 10;
        }
    }
}
