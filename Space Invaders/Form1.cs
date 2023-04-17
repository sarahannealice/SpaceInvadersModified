using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            //initial timers are stopped until help menu is closed
            timer1.Stop(); timer2.Stop(); timer3.Stop(); timer4.Stop(); timer5.Stop(); Observer.Stop();
            timer6.Stop(); timer7.Stop(); timer8.Stop(); timer9.Stop();
        }
        List<PictureBox> aliens = new List<PictureBox>();
        List<PictureBox> superAlien = new List<PictureBox>();
        List<PictureBox> delay = new List<PictureBox>();

        const int x = 360, y = 650;
        const int limit = 730;

        int speed = -3;//initial value was -1
        int left = -3;//initial value was -1
        int top = 0;
        int cnt = 0;
        int pts = 0;
        //added by sarah
        int move = 0;//moves super alien
        int cherryCount = 0;//counts how many times player hits cherry bomb (cap 2) -- future mod
        int saCount = 0;//counts how many times player hits super alien (cap 3)

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
                Player.Left -= 3;
            }
            else if (moveRight && Player.Location.X <= limit)
            {
                Player.Left += 3;
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
                    //if so checks if game has been won
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

                    foreach(Control control in this.Controls)
                    {
                        if (control is PictureBox && control.Name == "SuperAlien")
                        {
                            PictureBox sa = (PictureBox)control;
                            if (bullet.Bounds.IntersectsWith(sa.Bounds) && saCount <3)
                            {
                                saCount++;
                                this.Controls.Remove(bullet);
                            } else if (bullet.Bounds.IntersectsWith(sa.Bounds) && saCount >= 3)
                            {
                                this.Controls.Remove(bullet);
                                this.Controls.Remove(sa);
                                superAlien.Remove(sa);
                                pts += 10;
                                Score(pts);
                                saCount = 0;//reset counter
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

            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Alien") count++;
            }

            if (count == 0) YouWon();
        }

        //prints to screen if player wins
        private void YouWon()
        {
            //disabling player
            Player.Enabled = false;

            game = false;

            menu.Visible = true;
            finish.Text = "  You Won!";
            endscore.Text += pts.ToString();
        }

        //if all timers stop prints to screen 'game over' menu
        private void gameOver()
        {
            timer1.Stop(); timer2.Stop(); timer3.Stop(); timer4.Stop(); timer5.Stop(); Observer.Stop(); 
            //added by sarah
            timer6.Stop(); timer7.Stop(); timer8.Stop(); timer9.Stop();

            menu.Visible = true;
            string txt = "score: " + pts.ToString();
            endscore.Text = (txt);
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
            foreach (Control c in this.Controls)
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
            foreach (PictureBox alien in aliens)
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

        //creates alien laser and its attributes
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
            foreach (Control c in this.Controls)
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
                        LoseLife("laser");
                    }
                }
            }
        }

        //reduces number of lives when player is hit by alien-alien laser
        private void LoseLife(string shot)
        {
            Player.Location = new Point(x, y);

            foreach (Control c in this.Controls)
            {
                if (shot == "laser")
                {
                    if (c is PictureBox && c.Name.Contains("Life") && c.Visible == true)
                    {
                        PictureBox player = (PictureBox)c;
                        player.Visible = false;
                        return;
                    }
                } else if (shot == "cherry")
                {
                    gameOver();
                }
            }
            gameOver();
        }



        //--------------------menu event--------------------//
        //the following sections are added code by sarah
        //resource for groupbox menu to restart-quit game
        //https://www.youtube.com/watch?v=V7tEaDgODZI&ab_channel=RohitProgrammingZone

        //restarts application onclick
        private void startover_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        //quits the application onclick
        private void quit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //open help menu
        private void help_Click(object sender, EventArgs e)
        {
            timer1.Stop(); timer2.Stop(); timer3.Stop(); timer4.Stop(); timer5.Stop(); Observer.Stop();
            timer6.Stop(); timer7.Stop(); timer8.Stop(); timer9.Stop();
            helpmenu.Show();
        }


        //closes help menu
        private void closehelp_Click(object sender, EventArgs e)
        {
            timer1.Start(); timer2.Start(); timer3.Start(); timer4.Start(); timer5.Start(); Observer.Start();
            timer6.Start(); timer7.Start(); timer8.Start(); timer9.Start();
            helpmenu.Hide();
        }



        //--------------------super alien code--------------------//
        //create advance alien attributes
        private void SuperAlien()
        {
            //creating array to hold 2 start locations for super alien
            //to then randomize where it will start
            Random r = new Random();
            int[] location = new int[] { -100, 830 };
            int x = location[r.Next(location.Length)];

            PictureBox pb = new PictureBox();
            pb.Location = new Point(x, 0);
            pb.Size = new Size(60, 60);
            pb.BackgroundImage = Properties.Resources.alien_white;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.Name = "SuperAlien";
            this.Controls.Add(pb);

            superAlien.Add(pb);
        }


        //creates super alien laser bomb and its attributes
        //was having issues with image -- https://stackoverflow.com/a/21787257
        private void CherryBomb(PictureBox a)
        {
            PictureBox bomb = new PictureBox();
            bomb.Location = new Point(a.Location.X + a.Width / 3, a.Location.Y + 20);
            bomb.Size = new Size(20, 30);
            bomb.BackgroundImage = Properties.Resources.fireball;
            bomb.BackgroundImageLayout = ImageLayout.Stretch;
            bomb.Name = "CherryBomb";
            bomb.BringToFront();
            this.Controls.Add(bomb);
        }

        //method to add super alien (sarah's code)
        private void InsertSuperAliens(object sender, EventArgs e)
        {

            if (superAlien.Count == 0)
            {
                SuperAlien();
            }
        }

        //moves super alien
        private void SuperAlienMove(object sender, EventArgs e)
        {

            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "SuperAlien")
                {
                    PictureBox sa = (PictureBox)c;

                    if (sa.Location.X == -100)
                    {
                        move = 3;
                        sa.Location = new Point(sa.Location.X + move, sa.Location.Y);
                    }
                    if (sa.Location.X == 830)
                    {
                        move = -3;
                        sa.Location = new Point(sa.Location.X + move, sa.Location.Y);
                    }
                    else
                    {
                        sa.Location = new Point(sa.Location.X + move, sa.Location.Y);
                    }
                }
            }
        }

        private void FireCherry(object sender, EventArgs e)
        {
            if (superAlien.Count > 0)
            {
                CherryBomb(superAlien[0]);
                cherryCount = 0;//reset cherrybomb counter
            }
        }

        //fires cherrybombs
        private void CheckCherry(object sender, EventArgs e)
        {

            //checks if cherrybomb leaves screen without hitting anything
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "CherryBomb")
                {
                    PictureBox cherry = (PictureBox)c;
                    cherry.Top += 7;

                    //reached ground without being destroyed
                    if (cherry.Location.Y >= 700)
                    {
                        this.Controls.Remove(cherry);
                    }
                 
                    //checks-counts if cherrybomb hits player laser and removes both if true
                    /* -- for future modifications
                    foreach (Control ct in this.Controls)
                    {
                        if (ct is PictureBox && ct.Name == "bullet")
                        {
                            PictureBox bullet = (PictureBox)ct;

                            if (cherry.Bounds.IntersectsWith(bullet.Bounds) && cherryCount < 2)
                            {
                                cherryCount++;
                            } else if (cherry.Bounds.IntersectsWith(bullet.Bounds) && cherryCount >= 2)
                            {
                                this.Controls.Remove(cherry);
                                this.Controls.Remove(bullet);
                                pts += 3;
                                Score(pts);
                                cherryCount = 0;//reset cherrybomb counter
                            }
                        }
                    */

                        //checks if cherrybomb hits player
                        //if so call 'loselife' function
                        foreach (Control ctrl in this.Controls)
                        {
                            if (ctrl is PictureBox && ctrl.Name == "Player")
                            {
                                PictureBox player = (PictureBox)ctrl;

                                if (cherry.Bounds.IntersectsWith(player.Bounds))
                                {
                                    this.Controls.Remove(cherry);
                                    LoseLife("cherry");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
