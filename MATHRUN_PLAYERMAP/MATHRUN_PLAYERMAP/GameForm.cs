using MATHRUN_PLAYERMAP.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MATHRUN_PLAYERMAP
{
    public partial class GameForm : Form
    {
        private GameController gameController;

        public GameForm()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timerMonster.Interval = 110;

            timer.Tick += new EventHandler(UpdateMonster);
            //timerMonster.Tick += new EventHandler(UpdateMonster);

            KeyDown += new KeyEventHandler(OnPress);
            //KeyUp += new KeyEventHandler(Update);
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);
            UpdateStyles();
            Init();
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            var graphic = e.Graphics;
            gameController.DrawMap(graphic, this);
            //gameController.DrawQuestion(graphic);
        }


        public void Init()
        {
            gameController = new GameController();
            
            BackgroundImage = new Bitmap(Resource.ground, new Size(gameController.CellSize, gameController.CellSize)); 
            Size = new Size(gameController.Game.Field.Width * gameController.CellSize + 20,
                            gameController.Game.Field.Height * gameController.CellSize + 50);
            //this.MaximumSize = Size;
            //this.MinimumSize = Size;
            timer.Start();            
        }

        public void InitNextLevel()
        {
            gameController.Game.ChangeOnNextLevel();
            BackgroundImage = new Bitmap(Resource.ground, new Size(gameController.CellSize, gameController.CellSize));
            Size = new Size(gameController.Game.Field.Width * gameController.CellSize + 20,
                            gameController.Game.Field.Height * gameController.CellSize + 50);
            //this.MaximumSize = Size;
            //this.MinimumSize = Size;
            timer.Start();
        }

        public void UpdatePlayer(object sender, EventArgs e)
        {
            gameController.Game.Player.MoveNext();
            Invalidate();
        }

        public void UpdateMonster(object sender, EventArgs e)
        {
            gameController.Game.Monster.MoveNext();
            Invalidate();
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            gameController.CheckAnswer(sender, e);
            Invalidate();
        }
    }
}
