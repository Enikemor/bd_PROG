using bd_PROG.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bd_PROG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game g = new game();
            int lab_size = 62;
            int[,] lab = g.labirint(lab_size);
            Panel[,] grid = new Panel[lab_size-1,lab_size-1];
            int size = 5;
            int lock_y = 13;
            for (int i=0;i<lab_size-1;i++) 
            {
                int lock_x = 103;
                
                for (int j = 0; j < lab_size-1; j++) 
                {
                    grid[i, j] = new Panel();
                    grid[i, j].Location = new Point(lock_x,lock_y) ;
                    grid[i, j].Width = size;
                    grid[i, j].Height = size;
                    switch (lab[i,j])
                    {
                        case 1:
                            grid[i, j].BackColor = Color.White;
                            break;
                        case 0:
                            grid[i, j].BackColor = Color.Black;
                            break;
                    }
                    this.Controls.Add(grid[i, j]);
                    lock_x += size;
                }
                lock_y += size;
            }
        }
    }
}
