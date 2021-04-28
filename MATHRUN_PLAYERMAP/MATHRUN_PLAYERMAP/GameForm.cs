using Domains_MATH_RUN;
using MATHRUN_PLAYERMAP.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATHRUN_PLAYERMAP
{
    public partial class GameForm : Form
    {
        //public Image Monster;
        private static Image Background;
        private GameController gameController;
        public GameForm()
        {
            InitializeComponent();
            timer.Interval = 10000000;
            
            timer.Tick += new EventHandler(Update);

            //KeyDown += new KeyEventHandler(OnPress);
            //KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }

        
        
        public void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.DrawImage(Background, 10, 10);
            gameController.DrawMap(g);
        }

        private void Init()
        {
            gameController = new GameController();
            gameController.Game.ChangeOnNextLevel();
            gameController.Game.ChangeOnNextLevel();
            gameController.Game.ChangeOnNextLevel();

            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var cellImage = new Bitmap("C:\\Users\\DNS\\Documents\\GitHub\\MATH-RUN_MAIN\\MATHRUN_PLAYERMAP\\MATHRUN_PLAYERMAP\\Sprites\\Ground\\ground_01.png");
            Background = new Bitmap(cellImage, new Size(gameController.CellSize, gameController.CellSize));
            BackgroundImage = Background;
            Size = new Size(gameController.Game.Field.Width * gameController.CellSize + 20, gameController.Game.Field.Height * gameController.CellSize + 50);
            this.MaximumSize = Size;
            this.MinimumSize = Size;
            timer.Start();            
        }

        public void Update(object sender, EventArgs e)
        {

            Invalidate();
        }
    }
}
