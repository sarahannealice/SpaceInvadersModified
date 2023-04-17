using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Space_Invaders
{
    class Enemies
    {
        private int width, height;
        private int columns, rows;
        private int x, y, space; 

        //default alien size
        public Enemies()
        {
            width = 40;
            height = 40;
            columns = 10;
            rows = 5;
            space = 10;
            x = 150;
            y = 0; 
        }

        //creates alien attributes
        private void CreateControl(Form p)
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(x, y);
            pb.Size = new Size(width, height);
            pb.BackgroundImage = Properties.Resources.alien_pink;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.Name = "Alien";
            p.Controls.Add(pb);
        }

        //generates aliens on-screen controls
        public void CreateSprites(Form p)
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    CreateControl(p);
                    x += width + space; 
                }
                y += height + space;
                x = 150; 
            }
        }
    }
}
