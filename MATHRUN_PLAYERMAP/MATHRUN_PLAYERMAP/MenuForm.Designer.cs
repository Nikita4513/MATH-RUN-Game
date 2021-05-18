
using System.Windows.Forms;

namespace MATHRUN_PLAYERMAP
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.pictureNameGame = new System.Windows.Forms.PictureBox();
            this.AboutGameButton = new System.Windows.Forms.Button();
            this.ButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNameGame)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.ExitButton);
            this.ButtonsPanel.Controls.Add(this.SettingsButton);
            this.ButtonsPanel.Controls.Add(this.StartButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(319, 200);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(336, 229);
            this.ButtonsPanel.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(68, 152);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(193, 38);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Выйти из игры";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(68, 95);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(193, 38);
            this.SettingsButton.TabIndex = 1;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.ForeColor = System.Drawing.Color.Black;
            this.StartButton.Location = new System.Drawing.Point(68, 37);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(193, 42);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Начать игру";
            this.StartButton.UseMnemonic = false;
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // pictureNameGame
            // 
            this.pictureNameGame.Image = ((System.Drawing.Image)(resources.GetObject("pictureNameGame.Image")));
            this.pictureNameGame.Location = new System.Drawing.Point(274, 60);
            this.pictureNameGame.Name = "pictureNameGame";
            this.pictureNameGame.Size = new System.Drawing.Size(431, 97);
            this.pictureNameGame.TabIndex = 1;
            this.pictureNameGame.TabStop = false;
            // 
            // AboutGameButton
            // 
            this.AboutGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AboutGameButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutGameButton.Image")));
            this.AboutGameButton.Location = new System.Drawing.Point(921, 482);
            this.AboutGameButton.Name = "AboutGameButton";
            this.AboutGameButton.Size = new System.Drawing.Size(49, 44);
            this.AboutGameButton.TabIndex = 2;
            this.AboutGameButton.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 547);
            this.Controls.Add(this.AboutGameButton);
            this.Controls.Add(this.pictureNameGame);
            this.Controls.Add(this.ButtonsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.Text = "MATH RUN";
            this.ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureNameGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel ButtonsPanel;
        private Button StartButton;
        private Button ExitButton;
        private Button SettingsButton;
        private PictureBox pictureNameGame;
        private Button AboutGameButton;
    }
}