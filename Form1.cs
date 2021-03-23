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
        int lab_size = 20;
        int visible = 11;
        int? curse_step_m;
        int curse_point_m;
        int? curse_step_h;
        int curse_point_h;

        public Form1()
        {

            InitializeComponent();

            grid = new Panel[lab_size - 1, lab_size - 1];
            g = new game();
            g.maze = new labirint(lab_size, g.lvl_stuff, g.monsters);
            p = g.pl;
            lab = g.maze.grid;
            g.pl.x_coord = 1;
            g.pl.x_coord = 1;
            g.pl.hp = g.pl.max_hp;
            g.pl.lvl = 1;
            draw_around(g.pl.x_coord, g.pl.y_coord, grid, lab, visible, true);
            lab_updt(label1, label2, label3);
            //FirstDraw(lab, grid);
            // Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
            this.KeyPreview = true;
            //comboBox1.DataSource = g.pl.stuffs;
           // comboBox1.DisplayMember = "hp_restore";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int lab_size = 62;
            //int[,] 

            // Panel[,] grid = new Panel[lab_size-1,lab_size-1];
            NewGame(false);
        }

        private void NewGame(bool cont)
        {
            lab = g.maze.grid;
            //ReDraw(lab, grid);
            curse_step_h = null;
            curse_step_m = null;
            g.pl.x_coord = 1;
            g.pl.y_coord = 1;
            draw_around(g.pl.x_coord, g.pl.y_coord, grid, lab, visible,false);
            //Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
            if (!cont)
            {
                g.pl.lvl = 1;
                textBox1.Text = "Начинаем заново";
            }
            else 
            {
                textBox1.Text = "Вы спустились ниже";
            }
            g.pl.hp = g.pl.max_hp;
            lab_updt(label1, label2, label3);
            textBox1.Text = "Начинаем заново";
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
                    Draw(lab[i, j], grid[i, j]);

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
        private void Draw(int code, Panel p)
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
            if (lab[g.pl.y_coord - 1, g.pl.x_coord] != 0)
            {
               // Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.y_coord--;
                draw_around(g.pl.x_coord, g.pl.y_coord, grid, lab, visible, false);
                Action();
               // Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
            }
            else
            {
                //выводим сообщение что так нельзя))
            }
            curse_chek(true);
        }

        private void b_d_Click(object sender, EventArgs e)
        {
            if (lab[g.pl.y_coord + 1, g.pl.x_coord] != 0)
            {
               // Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.y_coord++;
                draw_around(g.pl.x_coord, g.pl.y_coord, grid, lab, visible, false);
                Action();
                //Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
            }
            else
            {
                //выводим сообщение что так нельзя))
            }
            curse_chek(true);
        }

        private void b_l_Click(object sender, EventArgs e)
        {
            if (lab[g.pl.y_coord, g.pl.x_coord - 1] != 0)
            {
               // Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.x_coord--;
                draw_around(g.pl.x_coord, g.pl.y_coord, grid, lab, visible, false);
                Action();
               // Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
            }
            else
            {
                //выводим сообщение что так нельзя))
            }
            curse_chek(true);
        }

        private void b_r_Click(object sender, EventArgs e)
        {
            if (lab[g.pl.y_coord, g.pl.x_coord + 1] != 0)
            {
                //Draw(lab[g.pl.y_coord, g.pl.x_coord], grid[g.pl.y_coord, g.pl.x_coord]);
                g.pl.x_coord++;
                draw_around(g.pl.x_coord,g.pl.y_coord,grid,lab, visible, false);
                Action();
               // Draw(3, grid[g.pl.y_coord, g.pl.x_coord]);
            }
            else
            {
                //выводим сообщение что так нельзя))
            }
            curse_chek(true);
        }
        private void Action()
        {
            StringBuilder sb = new StringBuilder();
            if (lab[g.pl.y_coord, g.pl.x_coord] == 2 || lab[g.pl.y_coord, g.pl.x_coord] == 7)
            {
                

                if (lab[g.pl.y_coord, g.pl.x_coord] == 2)
                {
                    button2.Visible = true;
                    button2.Enabled = true;
                    sb.Append(Environment.NewLine + "Под ногами сундук, если хочешь, его можно выкопать, но будь осторожен!");
                }
                else
                {
                    sb.Append(Environment.NewLine + "Вы нашли выход");
                    button6.Visible = true;
                    if (g.pl.has_key)
                    {
                        button6.Enabled = true;
                        sb.Append(Environment.NewLine + "Вы можете выйти");
                    }
                    else
                    { sb.Append(Environment.NewLine + "Вам нужно найти ключ чтобы выйти");
                        button6.Enabled = false;
                    }
                }
                
                textBox1.Text = textBox1.Text + sb.ToString();
                //textBox1.ScrollToCaret();
            }
            else { button2.Visible = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            chest found = new chest();
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
                sb.Append(Environment.NewLine + "Это ключ, проход к след. уровню открыт");
            }
            else
            {
                g.pl.stuffs.Insert(0,found.it);
                label4.Text = "Стоит " + g.pl.stuffs[0].costs + "\n восстанавливает " + g.pl.stuffs[0].hp_restore;
                button3.Enabled = true;

                //comboBox1.DataSource = g.pl.stuffs;
                //comboBox1.DisplayMember = "costs";
                sb.Append(Environment.NewLine + "Вы нашли ..., стоит " + found.it.costs);
            }
            lab_updt(label1, label2, label3);
            
           // comboBox1.DisplayMember = "hp_restore";
            textBox1.Text = textBox1.Text + sb.ToString();
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
            Random rand = new Random();

            if (g.pl.lvl > m.lvl || Math.Abs(m.lvl - g.pl.lvl) * rand.Next() < 0.51)
            { 
                //победа
                sb.Append(Environment.NewLine + "Вы встретились с монстром и победили, уровень повысился");
                g.pl.lvl++;
            }
            else
            {
                //пройгрыш
                g.pl.hp -= m.hp;
                if (g.pl.hp > 0)
                {
                    //добавить действие эффекта(возможно добавить новые поля в игрока)

                    sb.Append(Environment.NewLine + "Вы встретились с монстром и проиграли, осталось здоровья " + g.pl.hp);
                    textBox1.Text += sb.ToString();
                    switch (m.key_word)
                    {
                        case "money1":
                            curse_point_m = 1;
                            curse_step_m = m.lvl*5;
                            break;
                        case "helth1":
                            curse_point_h = 3;
                            curse_step_h = m.lvl*3;
                            break;
                        case "money2":
                            curse_point_m = 5;
                            curse_step_m = m.lvl*2;
                            break;
                        case "helth2":
                            curse_point_h = 7;
                            curse_step_h = m.lvl*2;
                            break;
                        case "money3":
                            curse_point_m = 10;
                            curse_step_m = m.lvl;
                            break;
                        case "helth3":
                            curse_point_h = 10;
                            curse_step_h = m.lvl;
                            break;
                    }
                    curse_chek(false);

                }
                else
                {
                    death();
                }
            }
            lab_updt(label1, label2, label3);
        }
        private void death()
        {
            //сделать проверку на количество денег в коне концов и выдать концовку
            textBox1.Text = "Кажется, это ваше последнее путешествие";
            if (MessageBox.Show("Это было ваше последнее приключение, начать заново?", "Вы мертвы", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                NewGame(false);
            }
            else
            {
                this.Close();

            }


            //вывести диалог с дальнейшими действиями

        }
        private void draw_around(int x, int y, Panel[,] grid, int [,] lab,int size,bool first) 
        {
            if (first) 
            {
                int cell_size = 20;
                int lock_y = 13;
                for (int i = 0; i <= size - 1; i++)
                {
                    int lock_x = 103;

                    for (int j = 0; j <= size - 1; j++)
                    {
                        grid[i, j] = new Panel();
                        grid[i, j].Location = new Point(lock_x, lock_y);
                        grid[i, j].Width = cell_size;
                        grid[i, j].Height = cell_size;
                        this.Controls.Add(grid[i, j]);
                        //Draw(lab[i, j], grid[i, j]);

                        lock_x += cell_size+1;
                    }
                    lock_y += cell_size+1;
                }
            }
            int add_i=-size/2;
            int add_j;
            for (int i = 0; i <= size-1 ; i++) 
            {
                add_j = -size / 2;
                for (int j = 0; j <= size-1; j++) 
                {
                   
                    if (x + add_j >= 0 && x + add_j <= lab_size - 1 && y + add_i >= 0 && y + add_i <= lab_size - 1)
                    {
                        if (i != size / 2  || j != size / 2 )
                        {
                            Draw(lab[y + add_i, x + add_j], grid[i, j]);
                        }
                        else
                        {
                            Draw(3, grid[i, j]);
                        }
                        
                    }
                    else 
                    {
                        Draw(0, grid[i, j]);

                    }
                    add_j++;
                }
                add_i++;
            }
        }
        private void lab_updt(Label lvl, Label helth, Label cash) 
        {
            lvl.Text = "Ваш уровень:  " + g.pl.lvl;
            helth.Text = "Ваше здоровье: " + g.pl.hp+" из "+g.pl.max_hp;
            cash.Text = "Ваш заработок:  " + g.pl.money;
        }

        private void comboBox1_DataSourceChanged(object sender, EventArgs e)
        {
           // comboBox1.Update();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (g.pl.stuffs.Count != 0)
            {
                item i = g.pl.stuffs[0];

                g.pl.stuffs.Insert(g.pl.stuffs.Count , i);
                g.pl.stuffs.RemoveAt(0);

                label4.Text = "Стоит " + g.pl.stuffs[0].costs + "\n восстанавливает " + g.pl.stuffs[0].hp_restore;
            }
            else 
            {
                label4.Text = "Нет предметов в инвентаре";
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (g.pl.stuffs.Count != 0)
            {
                item i = g.pl.stuffs[g.pl.stuffs.Count - 1];
                g.pl.stuffs.Insert(0, i);
                g.pl.stuffs.RemoveAt(g.pl.stuffs.Count-1 );
                
                //g.pl.stuffs.RemoveAt(g.pl.stuffs.Count - 1);
                label4.Text = "Стоит " + g.pl.stuffs[0].costs + "\n восстанавливает " + g.pl.stuffs[0].hp_restore;
                
            }
            else 
            {
                label4.Text = "Нет предметов в инвентаре";
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            item i = g.pl.stuffs[0];
            if ((g.pl.hp + i.hp_restore) > g.pl.max_hp)
            {
                g.pl.hp =g.pl.max_hp;
            }
            else 
            {
                g.pl.hp += i.hp_restore;
            }
            // g.pl.hp += i.hp_restore;
            lab_updt(label1, label2, label3);
            g.pl.stuffs.RemoveAt(0);
            if (g.pl.stuffs.Count != 0) 
            {
                label4.Text = "Стоит " + g.pl.stuffs[0].costs + " восстанавливает " + g.pl.stuffs[0].hp_restore;
            }
            else { label4.Text = "Нет предметов в инвентаре"; button3.Enabled = false; }
        }
        private void curse_chek(bool step) 
        {
            
            if (step)
            {
                if (curse_step_h != null)
                {
                    g.pl.hp -= curse_point_h;
                    if (g.pl.hp <= 0) { death(); }
                    curse_step_h--;
                    if (curse_step_h == 0) { curse_step_h = null; label5.Text = ""; }
                }
                if (curse_step_m != null)
                {
                    g.pl.money -= curse_point_m;
                    curse_step_m--;
                    if (curse_step_m == 0) { curse_step_m = null; label5.Text = ""; }
                }
                lab_updt(label1, label2, label3);
            }
            else 
            {
                
            }
            if (curse_step_h != null)
            {
                label5.Text = "Вы под действием проклятия, каждый шаг отнимает у вас " + curse_point_h + " hp \n осталось " + curse_step_h + " шагов";
            }
           
            if (curse_step_m != null)
            {
                label5.Text = "Вы под действием проклятия, каждый шаг отнимает у вас " + curse_point_m + " монет \n осталось " + curse_step_m + " шагов";
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button6.Visible = false;
            foreach (item i in g.pl.stuffs) 
            {
                g.pl.money += i.costs;
            }
            g.pl.stuffs.Clear();
            label4.Text = "Нет предметов в инвентаре"; button3.Enabled = false;
            MessageBox.Show("На выходе из лабиринта вас ждёт торговец, он любезно покупает то, что вам удалось добыть и не важно, хотите ли вы этого. \nПо итогу, теперь в вашем кошльке "+g.pl.money,"Спускаемся ниже",MessageBoxButtons.OK);
            NewGame(true);
        }
    }
}
