using MATHRUN_PLAYERMAP.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MATHRUN_PLAYERMAP
{
    public partial class GameForm : Form
    {
        private GameController gameController;
        private MenuForm menuForm;

        public GameForm(MenuForm menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            this.CenterToScreen();
            monsterTimer.Interval = 1000;
            monsterTimer.Tick += new EventHandler(UpdateMonster);
            KeyDown += new KeyEventHandler(OnPress);
            FormClosing += (sender, eventArgs) =>
            {
                menuForm.Show();
            };

            DoubleBuffered = true;
            Init();
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            var graphic = e.Graphics;
            gameController.DrawMap(graphic, this, monsterTimer, menuForm);
        }


        public void Init()
        {
            gameController = new GameController();
            BackgroundImage = new Bitmap(Resource.Ground, new Size(gameController.CellSize, gameController.CellSize)); 
            Size = new Size(gameController.Game.Field.Width * gameController.CellSize + 20,
                            gameController.Game.Field.Height * gameController.CellSize + 50);
            monsterTimer.Start();            
        }

        public void InitNextLevel()
        {
            if (!gameController.Game.TryGetNextLevel())
            {
                //monsterTimer.Stop();
                this.Close();
                menuForm.Show();
                return;
            }
            BackgroundImage = new Bitmap(Resource.Ground, new Size(gameController.CellSize, gameController.CellSize));
            Size = new Size(gameController.Game.Field.Width * gameController.CellSize + 20,
                            gameController.Game.Field.Height * gameController.CellSize + 50);
        }

        public void UpdateMonster(object sender, EventArgs e)
        {
            gameController.MonsterMoveNext();
            Invalidate();
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            gameController.ControlMovingPLayer(e);
            Invalidate();
        }
    }
}
