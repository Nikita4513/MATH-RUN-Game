using Domains_MATH_RUN;
using Domains_MATH_RUN.Domains;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATHRUN_PLAYERMAP.Controllers
{
    class GameController
    {
        public Game Game { get; }
        public int CellSize { get => 50; }

        public GameController()
        {
            Game = new Game();
        }

        public void DrawMap(Graphics g, GameForm gameForm)
        {
            CheckGameState(gameForm);
            for (var x = 0; x < Game.Field.Width; x++)
            {
                for (var y = 0; y < Game.Field.Height; y++)
                {
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Wall")
                    {
                        var wallImage = Resource.wall;
                        g.DrawImage(new Bitmap(wallImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Finish")
                    {
                        var finishImage = Resource.finish;
                        g.DrawImage(new Bitmap(finishImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Player")
                    {
                        var playerImage = Resource.player;
                        g.DrawImage(new Bitmap(playerImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Monster")
                    {
                        var monsterImage = Resource.monster;
                        g.DrawImage(new Bitmap(monsterImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                }
            }
            DrawQuestion(g);
        }

        public void DrawQuestion(Graphics g)
        {
            //g.DrawRectangle(new Pen(Color.Red), new Rectangle(new Point(10, 10), new Size(10, 10)));
            g.DrawString(
                "Вопрос: " + Game.CurrentQuestion.Value + "\t\t Очки: " + Game.Scores,
                new Font("Arial", 15),
                new SolidBrush(Color.Aqua),
                new Rectangle(Game.Field.Width * CellSize / 3 , Game.Field.Height * CellSize - 2 * CellSize + 5, Game.Field.Width * CellSize, CellSize));

            g.DrawString(
                Game.CurrentQuestion.PossibleAnswers[0] + "\t\t" + Game.CurrentQuestion.PossibleAnswers[1] + "\t\t" + Game.CurrentQuestion.PossibleAnswers[2],
                new Font("Arial", 15),
                new SolidBrush(Color.White),
                new Rectangle(Game.Field.Width * CellSize / 4, Game.Field.Height * CellSize - CellSize, Game.Field.Width * CellSize, CellSize));
        }

        public void CheckAnswer(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (Game.CurrentQuestion.IsRightAnswer(Game.CurrentQuestion.PossibleAnswers[0]))
                    {
                        Game.Scores++;
                        Game.Player.MoveNext();
                    }
                    else
                        Game.Scores--;
                    break;
                case Keys.Up:
                    if (Game.CurrentQuestion.IsRightAnswer(Game.CurrentQuestion.PossibleAnswers[1]))
                    {
                        Game.Scores++;
                        Game.Player.MoveNext();
                    }
                    else
                        Game.Scores--;
                    break;
                case Keys.Right:
                    if (Game.CurrentQuestion.IsRightAnswer(Game.CurrentQuestion.PossibleAnswers[2]))
                    {
                        Game.Scores++;
                        Game.Player.MoveNext();
                    }
                    else
                        Game.Scores--;
                    break;
                default:
                    return;
            }
            Game.GetNextQuestion();
        }

        private void CheckGameState(GameForm gameForm)
        {
            if (Game.Scores <= 0)
                gameForm.Init();
            try
            {
                Game.Field.GetLocationOf(typeof(Player));
            }
            catch
            {
                gameForm.Init();
            }
            try
            {
                Game.Field.GetLocationOf(typeof(Finish));
            }
            catch
            {
                gameForm.InitNextLevel();
            }
        }

    }
}
