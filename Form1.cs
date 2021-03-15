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
using static bd_PROG.classes.game;

namespace bd_PROG
{
    public partial class Form1 : Form
    {
        game g;
        player p;
        int[,] lab;
        Panel[,] grid;
        int lab_size = 62;
        
        public Form1()
        {
            
            InitializeComponent();
            
            grid = new Panel[lab_size - 1, lab_size - 1];
            g = new game();
            g.maze = new labirint(lab_size,g.lvl_stuff,g.monsters);
            p = g.pl;
            lab = g.maze.grid;
            FirstDraw(lab, grid);
            Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int lab_size = 62;
            //int[,] 
            lab = g.maze.grid;
            // Panel[,] grid = new Panel[lab_size-1,lab_size-1];
            ReDraw(lab,grid);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) 
            {
                Draw(3, grid[1, 1]);
            }
        }

        private void FirstDraw(int[,] lab, Panel[,] grid) 
        {
            int size = 5;
            int lock_y = 13;
            for (int i = 0; i < lab_size - 1; i++)
            {
                int lock_x = 103;

                for (int j = 0; j < lab_size - 1; j++)
                {
                    grid[i, j] = new Panel();
                    grid[i, j].Location = new Point(lock_x, lock_y);
                    grid[i, j].Width = size;
                    grid[i, j].Height = size;
                    this.Controls.Add(grid[i, j]);
                    Draw(lab[i,j],grid[i,j]);
                    
                    lock_x += size;
                }
                lock_y += size;
            }
        }
        private void ReDraw(int[,] lab, Panel[,] grid) 
        {
            for (int i = 0; i < lab_size - 1; i++)
            { 
                for (int j = 0; j < lab_size - 1; j++) 
                {
                    Draw(lab[i, j], grid[i, j]);
                }
            }
        }
        private void Draw(int code,Panel p) 
        {
            int key;
            if (this.Controls.Contains(p))
            {
                key = this.Controls.GetChildIndex(p);
            }
            else
            {
                this.Controls.Add(p);
                key = this.Controls.GetChildIndex(p);
            }
            switch (code)
            {
                case 1:
                    this.Controls[key].BackColor = Color.White;
                    break;
                case 0:
                    this.Controls[key].BackColor = Color.Black;
                    break;
                case 2:
                    this.Controls[key].BackColor = Color.Red;
                    break;
                case 3:
                    this.Controls[key].BackColor = Color.Green;
                    break;
                case 7:
                    this.Controls[key].BackColor = Color.DarkOrange;
                    break;
            }
        }

        private void b_u_Click(object sender, EventArgs e)
        {
          //  if (lab[g.pl.y_coord - 1, g.pl.x_coord] != 0)
          //  {
                Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.y_coord--;
                Action();
                Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
          //  }
          //  else 
          //  {
          //      //выводим сообщение что так нельзя))
          //  }
        }

        private void b_d_Click(object sender, EventArgs e)
        {
          //  if (lab[ g.pl.y_coord + 1, g.pl.x_coord] != 0)
          //  {
                Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.y_coord++;
                Action();
                Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
          //  }
          //  else
          //  {
          //      //выводим сообщение что так нельзя))
          //  }
        }

        private void b_l_Click(object sender, EventArgs e)
        {
          //  if (lab[ g.pl.y_coord,g.pl.x_coord - 1] != 0)
          //  {
                Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.x_coord--;
                Action();
                Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
           // }
           // else
           // {
                //выводим сообщение что так нельзя))
           // }
        }

        private void b_r_Click(object sender, EventArgs e)
        {
           // if (lab[ g.pl.y_coord, g.pl.x_coord + 1] != 0)
           // {
                Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.x_coord++;
                Action();
                Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
           // }
           // else
           // {
           //     //выводим сообщение что так нельзя))
           // }
        }
        private void Action() 
        {
            if (lab[g.pl.y_coord, g.pl.x_coord] == 2)
            { StringBuilder sb = new StringBuilder();
                button2.Visible = true;
                button2.Enabled = true;
                sb.Append(Environment.NewLine + "Под ногами сундук, если хочешь, его можно выкопать, но будь осторожен!");
                textBox1.Text =textBox1.Text+ sb.ToString();
                //textBox1.ScrollToCaret();
            }
            else { button2.Visible = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            chest found=new chest();
            foreach (chest ch in g.maze.chests)
            {
                if (ch.y_coord == g.pl.x_coord && ch.x_coord == g.pl.y_coord)
                { 
                    found = ch; 
                    break; 
                } 
            }
            //высвободить содержимое
            if (found.it.is_key)
            {
                g.pl.has_key = true;
                sb.Append(Environment.NewLine + "Это ключ, проход к следю уровню открыт");
            }
            else 
            {
                g.pl.stuffs.Add(found.it);
                sb.Append(Environment.NewLine + "Вы нашли ..., стоит "+found.it.costs);
            }
            
            textBox1.Text = textBox1.Text+sb.ToString();
            combat(found.m);
            
            
            lab[g.pl.y_coord, g.pl.x_coord] = 1;
            g.maze.chests.Remove(found);
            button2.Enabled = false;
            button2.Visible = false;
        }
        private void combat(abomination m) 
        {
            //сделать проверку на вступление в бой и победу/пройгрыш
            StringBuilder sb = new StringBuilder();
            //пройгрыш
            g.pl.hp -= m.hp;
            if (g.pl.hp > 0)
            {
                //добавить действие эффекта(возможно добавить новые поля в игрока)
                sb.Append(Environment.NewLine + "Вы встретились с монстром, осталось здоровья " + g.pl.hp);
                textBox1.Text = textBox1.Text + sb.ToString();
            }
            else 
            {
                death();
            }
        }
        private void death() 
        {
            //сделать проверку на количество денег в коне концов и выдать концовку
            textBox1.Text = "Кажется, это ваше последнее путешествие";
         //вывести диалог с дальнейшими действиями
        }
    }
}
