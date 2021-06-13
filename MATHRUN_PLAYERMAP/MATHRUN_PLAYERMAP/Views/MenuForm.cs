using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATHRUN_PLAYERMAP
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Size = new Size(1000, 600);
            this.MaximumSize = Size;
            this.MinimumSize = Size;

            StartButton.Click += (sender, args) =>
            {
                var gameForm = new GameForm(this);
                gameForm.Show();
                this.Hide();
            };

            ExitButton.Click += (sender, eventArgs) => Close();

            //AboutGameButton.Click += (sender, eventArgs) => new AboutGameForm().Show();


            FormClosing += (sender, eventArgs) =>
            {
                var result = MessageBox.Show("Действительно закрыть?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
        }
    }
}
