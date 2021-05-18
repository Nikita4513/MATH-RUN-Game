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
            timer.Interval = 1000;
            timer.Tick += new EventHandler(UpdateMonster);
            KeyDown += new KeyEventHandler(OnPress);
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);
            UpdateStyles();
            Init();
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            var graphic = e.Graphics;
            gameController.DrawMap(graphic, this, timer, menuForm);
        }


        public void Init()
        {
            gameController = new GameController();
            BackgroundImage = new Bitmap(Resource.ground, new Size(gameController.CellSize, gameController.CellSize)); 
            Size = new Size(gameController.Game.Field.Width * gameController.CellSize + 20,
                            gameController.Game.Field.Height * gameController.CellSize + 50);
            timer.Start();            
        }

        public void InitNextLevel()
        {
            gameController.Game.ChangeOnNextLevel();
            BackgroundImage = new Bitmap(Resource.ground, new Size(gameController.CellSize, gameController.CellSize));
            Size = new Size(gameController.Game.Field.Width * gameController.CellSize + 20,
                            gameController.Game.Field.Height * gameController.CellSize + 50);
        }

        public void UpdateMonster(object sender, EventArgs e)
        {
            gameController.Game.Monster.MoveNext();
            Invalidate();
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            gameController.ControlMovingPLayer(e);
            Invalidate();
        }
    }
}
