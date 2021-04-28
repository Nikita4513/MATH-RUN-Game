using Domains_MATH_RUN.Domains;
using System;

namespace Domains_MATH_RUN
{
    class Game
    {
        public int Scores { get; private set; }
        public Player Player { get; private set; }
        public Field Field { get; private set; }
        private int numberLevel = 0;

        public Game()
        {
            InitializeGame();
        }

        public void ChangeOnNextLevel()
        {
            numberLevel++;
            InitializeGame();
        }

        private void InitializeGame()
        {
            if (numberLevel >= Levels.AllLevels.Length)
                throw new Exception("There are no more levels!");
            Field = new Field(Levels.AllLevels[numberLevel]);
            Scores = 0;
            var playerLocation = Field.GetLocationOf(typeof(Player));
            this.Player = new Player(playerLocation.X, playerLocation.Y, Field);
        }
    }
}
