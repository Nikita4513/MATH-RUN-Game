using Domains_MATH_RUN;
using Domains_MATH_RUN.Domains;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATHRUN_PLAYERMAP.Controllers
{
    class GameController
    {
        public Game Game { get; }
        public int CellSize { get => 50; }
        private SoundPlayer gameOverSound;
        private SoundPlayer stepSound;
        private SoundPlayer wrongAnswerSound;

        public GameController()
        {
            Game = new Game();
            gameOverSound = new SoundPlayer(Resource.gameover);
            stepSound = new SoundPlayer(Resource.step);
            wrongAnswerSound = new SoundPlayer(Resource.wronganswer);

        }

        public void DrawMap(Graphics g, GameForm gameForm, Timer timer, MenuForm menuForm)
        {
            CheckGameState(gameForm, timer, menuForm);
            for (var x = 0; x < Game.Field.Width; x++)
            {
                for (var y = 0; y < Game.Field.Height; y++)
                {
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Wall")
                    {
                        var wallImage = Resource.Wall;
                        g.DrawImage(new Bitmap(wallImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Finish")
                    {
                        var finishImage = Resource.Finish;
                        g.DrawImage(new Bitmap(finishImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Player")
                    {
                        var playerImage = Resource.Player;
                        g.DrawImage(new Bitmap(playerImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Monster")
                    {
                        var monsterImage = Resource.Monster;
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
                "Вопрос: " + Game.CurrentQuestion.Value,
                new Font("Arial", 15),
                new SolidBrush(Color.Aqua),
                new Rectangle(Game.Field.Width * CellSize / 3 , Game.Field.Height * CellSize - 2 * CellSize + 5, 0, 0));

            g.DrawString(
                "HP: " + Game.Scores,
                new Font("Arial", 15),
                new SolidBrush(Color.MistyRose),
                new Rectangle(0, Game.Field.Height * CellSize - 2 * CellSize + 5, 0, 0));

            g.DrawString(
                Game.CurrentQuestion.PossibleAnswers[0] + "◀\t" + Game.CurrentQuestion.PossibleAnswers[1] + "▲\t" + Game.CurrentQuestion.PossibleAnswers[2] + "▶",
                new Font("Arial", 15),
                new SolidBrush(Color.White),
                new Rectangle(Game.Field.Width * CellSize / 4, Game.Field.Height * CellSize - CellSize, Game.Field.Width * CellSize, CellSize));
        }

        public void ControlMovingPLayer(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    ChangeGameStates((int)Answers.FirstAnswer);
                    break;
                case Keys.Up:
                    ChangeGameStates((int)Answers.SecondAnswer);
                    break;
                case Keys.Right:
                    ChangeGameStates((int)Answers.ThirdAnswer);
                    break;
                default:
                    return;
            }
            Game.GetNextQuestion();
        }

        public void MonsterMoveNext()
        {
            stepSound.Play();
            Game.Monster.MoveNext();
        }

        private void ChangeGameStates(int indexAnswer)
        {
            if (Game.CurrentQuestion.IsRightAnswer(Game.CurrentQuestion.PossibleAnswers[indexAnswer]))
            {
                Game.Scores++;
                stepSound.Play();
                Game.Player.MoveNext();
            }
            else
            {
                wrongAnswerSound.Play();
                Game.Scores -= 5;
            }
            
        }

        private void CheckGameState(GameForm gameForm, Timer timer, MenuForm menuForm)
        {
            if (Game.Scores <= 0 || !Game.Field.CreatureOnMap(typeof(Player)))
            {
                timer.Stop();
                gameOverSound.Play();
                var dialogResult = MessageBox.Show("Начать заново?", "Вы проиграли!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    Game.InitializeCurrentLevel();
                    timer.Start();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    gameForm.Close();
                    menuForm.Show();
                }
                return;
            }
            if (!Game.Field.CreatureOnMap(typeof(Finish)))
            {
                gameForm.InitNextLevel();
            }
        }

    }
}
