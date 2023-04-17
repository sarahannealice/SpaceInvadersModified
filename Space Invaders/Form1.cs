using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menu.Hide();
            new Enemies().CreateSprites(this);
            InsertAliens();
        }    
        List<PictureBox> aliens = new List<PictureBox>();
        List<PictureBox> delay = new List<PictureBox>();

        const int x = 360, y = 650;
        const int limit = 730;

        int speed = -1;
        int left = -1;
        int top = 0;        
        int cnt = 0;
        int pts = 0;

        bool game = true;
        bool moveLeft;
        bool moveRight;
        bool fired;

        //checks if key is pressed
        private void Pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            else if (e.KeyCode == Keys.Space && game && !fired)
            {
                Missile();
                fired = true;
            }
        }

        //checks if key is released
        private void Released(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            else if (e.KeyCode == Keys.Space)
            {
                fired = false;
            }
        }

        //checks if bool moveLeft-moveRight is pressed
        //moves player within preset bounds
        private void PlayerMove(object sender, EventArgs e)
        {
            if (moveLeft && Player.Location.X >= 0)
            {
                Player.Left--;
            }
            else if (moveRight && Player.Location.X <= limit)
            {
                Player.Left++;
            }
        }

        //fires lasers, if it contacts something it checks the object
        //and eliminates the object accordingly (alien or laser)
        //if player laser hits enemy, checks if player wins
        private void FireBullet(object sender, EventArgs e)
        {
            //checks if player laser leaves screen without hitting anything
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Bullet")
                {
                    PictureBox bullet = (PictureBox)c;
                    bullet.Top -= 5;

                    if (bullet.Location.Y <= 0)
                    {
                        this.Controls.Remove(bullet); 
                    }

                    //checks if player laser hits enemy laser and removes both if true
                    foreach (Control ct in this.Controls)
                    {
                        if (ct is PictureBox && ct.Name == "Laser")
                        {
                            PictureBox laser = (PictureBox)ct;

                            if (bullet.Bounds.IntersectsWith(laser.Bounds))
                            {
                                this.Controls.Remove(bullet);
                                this.Controls.Remove(laser);
                                pts++;
                                Score(pts);
                            }
                        }
                    }

                    //checks if player laser hits alien
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is PictureBox && ctrl.Name == "Alien")
                        {
                            PictureBox alien = (PictureBox)ctrl;

                            if (bullet.Bounds.IntersectsWith(alien.Bounds) && !Touched(alien))
                            {
                                this.Controls.Remove(bullet);
                                this.Controls.Remove(alien);
                                aliens.Remove(alien);
                                pts += 5;
                                Score(pts);
                                CheckForWinner();
                            }
                            else if (bullet.Bounds.IntersectsWith(alien.Bounds) && Touched(alien))
                            {
                                this.Controls.Remove(bullet);
                                this.Controls.Remove(alien);
                                delay.Add(alien);
                                pts += 5;
                                Score(pts);
                                CheckForWinner();
                            }
                        }
                    }
                }
            }
        }

        //creates player laser and its attributes
        private void Missile()
        {
            PictureBox bullet = new PictureBox();
            bullet.Location = new Point(Player.Location.X + Player.Width / 2, Player.Location.Y - 20);
            bullet.Size = new Size(5, 20);
            bullet.BackgroundImage = Properties.Resources.player_laser;
            bullet.BackgroundImageLayout = ImageLayout.Stretch;
            bullet.Name = "Bullet";
            this.Controls.Add(bullet);
        }

        //checks number of aliens on screen
        private void CheckForWinner()
        {
            int count = 0; 

            foreach(Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Alien") count++; 
            }

            if (count == 0) YouWon();
        }

        //prints to screen if player wins
        private void YouWon()
        {
            game = false; 

            foreach(Control c in this.Controls)
            {
                if (c is Label && c.Name == "Finish")
                {
                    Label lbl = (Label)c;
                    lbl.Text = "You Won!" + "\n"
                             + "Score: " + pts.ToString(); 
                }
                else
                {
                    c.Visible = false; 
                }
            }
        }

        //if all timers stop prints to screen if player loses
        private void gameOver()
        {
            timer1.Stop(); timer2.Stop(); timer3.Stop(); timer4.Stop(); timer5.Stop(); Observer.Stop();

            menu.Visible = true;
            endscore.Text += pts.ToString();

            /*
            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Name == "Finish")
                {
                    Label lbl = (Label)c;
                    lbl.Text = "Game Over!";
                    game = false;
                }
                else
                {
                    c.Visible = false;
                }
            }
            */
        }

        //method to track player score
        //score is based on aliens and alien-lasers eliminated
        private void Score(int pts)
        {
            labelScore.Text = "Score: " + pts.ToString();
        }

        //method to add alien to screen
        private void InsertAliens()
        {
            foreach(Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Alien")
                {
                    PictureBox alien = (PictureBox)c;
                    aliens.Add(alien); 
                }
            }
        }

        //checks if object touches screen boundaries (left-right)
        private bool Touched(PictureBox a)
        {
            return a.Location.X <= 0 || a.Location.X >= limit;
        }

        //checks if object touches screen bounds and resets direction accordingly
        private void SetDirection(PictureBox a)
        {
            int size = a.Height;

            if (Touched(a))
            {
                top = 1; left = 0; cnt++;

                if (cnt == size)
                {
                    top = 0; left = speed * (-1); Observer.Start();
                }
                else if (cnt == size * 2)
                {
                    top = 0; left = speed; cnt = 0; Observer.Start();
                }
            }
        }

        //**********need to return to comment what this does************//
        private void Observe(object sender, EventArgs e)
        {
            Observer.Stop();

            foreach (PictureBox delayed in delay)
            {
                aliens.Remove(delayed);
            }
            delay.Clear();
        }

        //keeps aliens in lines and moving
        private void AlienMove()
        {            
            foreach(PictureBox alien in aliens)
            {
                alien.Location = new Point(alien.Location.X + left, alien.Location.Y + top);
                SetDirection(alien);
                Collided(alien);                
            }
        }

        //checks if aliens collide with player
        //if so, gameover method is called
        private void Collided(PictureBox a)
        {
            if (a.Bounds.IntersectsWith(Player.Bounds))
            {
                gameOver();
            }
        }

        //method that calls another method to move aliens
        private void MoveAliens(object sender, EventArgs e)
        {
            AlienMove();
        }

        //prints to screen alien laser
        private void Beam(PictureBox a)
        {
            PictureBox laser = new PictureBox();
            laser.Location = new Point(a.Location.X + a.Width / 3, a.Location.Y + 20);
            laser.Size = new Size(5, 20);
            laser.BackgroundImage = Properties.Resources.alien_laser;
            laser.BackgroundImageLayout = ImageLayout.Stretch;
            laser.Name = "Laser";
            this.Controls.Add(laser);
        }

        //method to have random alien shoot laser
        private void StrikeSpan(object sender, EventArgs e)
        {
            Random r = new Random();
            int pick; 

            if (aliens.Count > 0)
            {
                pick = r.Next(aliens.Count);
                Beam(aliens[pick]);
            }
        }

        //checks what happens with alien laser
        //if it leaves screen without touching player/player laser -- remove
        //if it collides with player/player laser, call respective methods
        private void DetectLaser(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Laser")
                {
                    PictureBox laser = (PictureBox)c;
                    laser.Top += 5; 

                    if (laser.Location.Y >= limit)
                    {
                        this.Controls.Remove(laser); 
                    }
                    if (laser.Bounds.IntersectsWith(Player.Bounds))
                    {
                        this.Controls.Remove(laser); 
                        LoseLife(); 
                    }                    
                }
            }
        }

        //reduces number of lives when player is hit by alien-alien laser
        private void LoseLife()
        {
            Player.Location = new Point(x, y);

            foreach(Control c in this.Controls)
            {
                if (c is PictureBox && c.Name.Contains("Life") && c.Visible == true)
                {
                    PictureBox player = (PictureBox)c;
                    player.Visible = false;
                    return;
                }
            }
            gameOver(); 
        }



        //----------menu event----------//
        //resource for groupbox menu to restart-quit game
        //https://www.youtube.com/watch?v=V7tEaDgODZI&ab_channel=RohitProgrammingZone
        private void startover_Click(object sender, EventArgs e)
        {

        }
    }
}
