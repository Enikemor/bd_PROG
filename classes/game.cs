using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_PROG.classes
{
    public class game
    {
        public labirint maze { get; set; }
        public player pl { get; set; }
        public List<item> lvl_stuff { get; set; }
        public List<abomination> monsters { get; set; }
        public game()
        {
            pl = new player();
            lvl_stuff = new List<item>();
            lvl_stuff.Add(new item() { costs = 0, hp_restore = 20, is_key = true }) ;
            lvl_stuff.Add(new item() { costs = 30, hp_restore = 0, is_key = false });
            lvl_stuff.Add(new item() { costs = 80, hp_restore = 20, is_key = false });
            lvl_stuff.Add(new item() { costs = 300, hp_restore = 20, is_key = false });
            lvl_stuff.Add(new item() { costs = 0, hp_restore = -20, is_key = false });
            lvl_stuff.Add(new item() { costs = 0, hp_restore = 203, is_key = false });
            monsters = new List<abomination>();
            monsters.Add(new abomination() {hp=100, lvl=32,key_word="money1"});
            monsters.Add(new abomination() { hp=150,lvl=10, key_word = "helth1" });
            monsters.Add(new abomination() { hp=90,lvl=12 , key_word = "money2" });
            monsters.Add(new abomination() { hp=67,lvl=12 ,key_word = "none" });
            monsters.Add(new abomination() { hp=44,lvl=1 , key_word = "none" });
            monsters.Add(new abomination() { hp=30,lvl=1 , key_word = "none" });
        }


    }
    public class item
    {
        public int costs;
        public int hp_restore;
        public bool is_key { get; set; }

    }
    public class player
    {
        public int x_coord { get; set; }
        public int y_coord { get; set; }
        public int hp { get; set; }
        public int max_hp => 200 + lvl * 10;
        public int lvl { get; set; }
        public int money { get; set; }
        public bool has_key { get; set; }
        public List<item> stuffs;
        public player()
        {
            x_coord = 1;
            y_coord = 1;
            hp = 100;
            lvl = 1;
            money = 0;
            has_key = false;
            stuffs = new List<item>();
        }
    }
    public class labirint
    {
        public int size { get; set; }
        public int[,] grid => lab_create(size);
        public List<chest> chests { get; set; }
        List<item> items;
        List<abomination> monsters;
        public int[] fin { get; set; }
        public labirint(int size, List<item> items,List<abomination> m)
        {
            this.size = size;
            this.items = items;
            monsters = m;
        }
        void fin_set(int [,] m) 
        {
            fin = new int[2];
            fin[0] = size - 3;
            fin[1] = size - 3;
            m[fin[1],fin[0]] = 7;
        }
        public void SetChests(int[,] grid) 
        {
            chests = new List<chest>();
            chests.Clear();
            Random rand = new Random();
            int x;
            int y;
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(1, size);
                y = rand.Next(1, size);
                if (x % 2 == 0)
                {
                    if (x == 2)
                    {
                        x += 1;
                    }
                    else
                    {
                        x -= 1;
                    }
                }
                if (y % 2 == 0)
                {
                    if (y == 2)
                    {
                        y += 1;
                    }
                    else
                    {
                        y -= 1;
                    }
                }
                if (chests.Count != 0) { chests.Add(new chest(x, y, items[rand.Next(1,items.Count)],monsters[rand.Next(0,monsters.Count)])); }
                else { chests.Add(new chest(x, y, items[0], monsters[rand.Next(0, monsters.Count)])); }
                
                grid[x, y] = 2;
            }
        }
        public int[,] lab_create(int size)
        {
            bool[] dead = new bool[4];
            int cellnum = -1;
            List<int[]> path = new List<int[]>();
            for (int i = 0; i < 3; i++)
            {
                dead[i] = false;
            }
            Random rand = new Random();
            int deadends = 0;
            int[,] lab = new int[size, size];
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    lab[i, j] = 0;
                }
            }
            int x = 1;
            int y = 1;
            lab[x, y] = 1;
            path.Add(new int[2] { x, y });
            cellnum++;
            dead[1] = true;
            dead[3] = true;
            goto Dir_Choosing;

        Coord_Choosing:
            //        x = rand.Next(1, size - 1);
            //        y = rand.Next(1, size - 1);
            //        
            //            if (x % 2 == 0) 
            //            {
            //                if (x == 2)
            //                {
            //                    x += 1;
            //                }
            //                else 
            //                {
            //                    x -= 1;
            //                }
            //            }
            //            if (y % 2 == 0)
            //            {
            //                if (y == 2)
            //                {
            //                    y += 1;
            //                }
            //                else
            //                {
            //                    y -= 1;
            //                }
            //            }
            //            
            cellnum = rand.Next(path.Count);
            x = path[cellnum][0];
            y = path[cellnum][1];

        Deadend_chek:

            if ((x + 2) < (size - 1))
            {
                if (lab[x + 2, y] == 1)
                {
                    dead[0] = true;
                }
                else { dead[0] = false; }
            }
            else { dead[0] = true; }
            if ((x - 2) > (0))
            {
                if (lab[x - 2, y] == 1)
                {
                    dead[1] = true;
                }
                else { dead[1] = false; }
            }
            else { dead[1] = true; }
            if ((y + 2) < (size - 1))
            {
                if (lab[x, y + 2] == 1)
                {
                    dead[2] = true;
                }
                else { dead[2] = false; }
            }
            else { dead[2] = true; }
            if ((y - 2) > (0))
            {
                if (lab[x, y - 2] == 1)
                {
                    dead[3] = true;
                }
                else { dead[3] = false; }
            }
            else { dead[3] = true; }

            if (dead[0] && dead[1] && dead[2] && dead[3])
            {
                //deadend
                deadends++;
                //         cell[0] = x;
                //         cell[1] = y;
                //         int ind = path.;
                path.RemoveAt(cellnum);
                if (path.Count != 0)
                {
                    goto Coord_Choosing;
                }
                else { goto fin; }

            }
        Dir_Choosing:
            bool choosen = false;
            while (!choosen)
            {
                switch (rand.Next(0, 4))
                {
                    case 0:
                        if (!dead[0])
                        {
                            choosen = true;
                            lab[x + 1, y] = 1;
                            lab[x + 2, y] = 1;
                            x = x + 2;
                        }
                        break;
                    case 1:
                        if (!dead[1])
                        {
                            choosen = true;
                            lab[x - 1, y] = 1;
                            lab[x - 2, y] = 1;
                            x = x - 2;
                        }
                        break;
                    case 2:
                        if (!dead[2])
                        {
                            choosen = true;
                            lab[x, y + 1] = 1;
                            lab[x, y + 2] = 1;
                            y = y + 2;
                        }
                        break;
                    case 3:
                        if (!dead[3])
                        {
                            choosen = true;
                            lab[x, y - 1] = 1;
                            lab[x, y - 2] = 1;
                            y = y - 2;
                        }
                        break;
                }
            }
            // cell[0] = x;
            //cell[1] = y;
            path.Add(new int[2] { x, y });
            cellnum = path.Count - 1;
            bool again = false;
            //           for (int i = 1; i < size - 1; i = i + 2) 
            //           { 
            //               for (int j = 1; j < size - 1; j = j + 2) 
            //               { 
            //                   if (lab[i, j] == 0) 
            //                   { again = true; } 
            //               } 
            //           }

            if (path.Count != 0)
            {
                goto Deadend_chek;
            }
        fin:
            SetChests(lab);
            fin_set(lab);
            return lab;
        }

    }
    public class chest
    {
        public int x_coord { get; set; }
        public int y_coord { get; set; }
        public bool trap;
        public item it { get; set; }
        public abomination m { get; set; }
        public chest(int x,int y,item item,abomination monst) 
        {
            x_coord = x;
            y_coord = y;
            it = item;
            m = monst;
        }
        public chest() 
        {
            
        }
    }
    public class abomination 
    {
        public item loot;
        public int hp;
        public int lvl;
        public string key_word;
    }
}
