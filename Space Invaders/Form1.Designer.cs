﻿namespace Space_Invaders
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.Observer = new System.Windows.Forms.Timer(this.components);
            this.labelLives = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.Life2 = new System.Windows.Forms.PictureBox();
            this.Life1 = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.GroupBox();
            this.quit = new System.Windows.Forms.Label();
            this.startover = new System.Windows.Forms.Label();
            this.endscore = new System.Windows.Forms.Label();
            this.finish = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.PlayerMove);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.FireBullet);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.MoveAliens);
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 1500;
            this.timer4.Tick += new System.EventHandler(this.StrikeSpan);
            // 
            // timer5
            // 
            this.timer5.Enabled = true;
            this.timer5.Interval = 1;
            this.timer5.Tick += new System.EventHandler(this.DetectLaser);
            // 
            // Observer
            // 
            this.Observer.Interval = 1;
            this.Observer.Tick += new System.EventHandler(this.Observe);
            // 
            // labelLives
            // 
            this.labelLives.AutoSize = true;
            this.labelLives.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLives.ForeColor = System.Drawing.Color.White;
            this.labelLives.Location = new System.Drawing.Point(12, 710);
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(73, 16);
            this.labelLives.TabIndex = 1;
            this.labelLives.Text = "Lives:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(670, 710);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(95, 16);
            this.labelScore.TabIndex = 6;
            this.labelScore.Text = "Score: 0";
            // 
            // Life2
            // 
            this.Life2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Life2.BackgroundImage")));
            this.Life2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Life2.Location = new System.Drawing.Point(121, 710);
            this.Life2.Name = "Life2";
            this.Life2.Size = new System.Drawing.Size(30, 30);
            this.Life2.TabIndex = 3;
            this.Life2.TabStop = false;
            // 
            // Life1
            // 
            this.Life1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Life1.BackgroundImage")));
            this.Life1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Life1.Location = new System.Drawing.Point(85, 710);
            this.Life1.Name = "Life1";
            this.Life1.Size = new System.Drawing.Size(30, 30);
            this.Life1.TabIndex = 2;
            this.Life1.TabStop = false;
            // 
            // Player
            // 
            this.Player.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Player.BackgroundImage")));
            this.Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player.Location = new System.Drawing.Point(360, 650);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(50, 50);
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // menu
            // 
            this.menu.Controls.Add(this.quit);
            this.menu.Controls.Add(this.startover);
            this.menu.Controls.Add(this.endscore);
            this.menu.Controls.Add(this.finish);
            this.menu.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu.Location = new System.Drawing.Point(231, 202);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(357, 272);
            this.menu.TabIndex = 7;
            this.menu.TabStop = false;
            this.menu.Text = "menu";
            // 
            // quit
            // 
            this.quit.AutoSize = true;
            this.quit.BackColor = System.Drawing.Color.Transparent;
            this.quit.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit.ForeColor = System.Drawing.Color.White;
            this.quit.Location = new System.Drawing.Point(144, 214);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(61, 31);
            this.quit.TabIndex = 3;
            this.quit.Text = "Quit";
            // 
            // startover
            // 
            this.startover.AutoSize = true;
            this.startover.BackColor = System.Drawing.Color.Transparent;
            this.startover.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startover.ForeColor = System.Drawing.Color.White;
            this.startover.Location = new System.Drawing.Point(112, 183);
            this.startover.Name = "startover";
            this.startover.Size = new System.Drawing.Size(128, 31);
            this.startover.TabIndex = 3;
            this.startover.Text = "Start Over";
            this.startover.Click += new System.EventHandler(this.startover_Click);
            // 
            // endscore
            // 
            this.endscore.AutoSize = true;
            this.endscore.BackColor = System.Drawing.Color.Transparent;
            this.endscore.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endscore.ForeColor = System.Drawing.Color.White;
            this.endscore.Location = new System.Drawing.Point(112, 85);
            this.endscore.Name = "endscore";
            this.endscore.Size = new System.Drawing.Size(88, 31);
            this.endscore.TabIndex = 2;
            this.endscore.Text = "score: ";
            this.endscore.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // finish
            // 
            this.finish.AutoSize = true;
            this.finish.BackColor = System.Drawing.Color.Transparent;
            this.finish.Font = new System.Drawing.Font("Sitka Small", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finish.ForeColor = System.Drawing.Color.White;
            this.finish.Location = new System.Drawing.Point(42, 26);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(272, 59);
            this.finish.TabIndex = 0;
            this.finish.Text = "Game Over!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.Life2);
            this.Controls.Add(this.Life1);
            this.Controls.Add(this.labelLives);
            this.Controls.Add(this.Player);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Space Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Released);
            ((System.ComponentModel.ISupportInitialize)(this.Life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer Observer;
        private System.Windows.Forms.Label labelLives;
        private System.Windows.Forms.PictureBox Life1;
        private System.Windows.Forms.PictureBox Life2;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.GroupBox menu;
        private System.Windows.Forms.Label finish;
        private System.Windows.Forms.Label endscore;
        private System.Windows.Forms.Label quit;
        private System.Windows.Forms.Label startover;
    }
}

