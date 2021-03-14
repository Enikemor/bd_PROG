using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_PROG.classes
{
    class game
    {
        public int[,] labirint(int size)
        {
            bool[] dead = new bool[4];
            int cellnum=-1;
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
                for (int j = 0; j < size-1; j++)
                {
                    lab[i, j] = 0;
                }
            }
            int x = 1;
            int y = 1;
            lab[x, y] = 1;
            path.Add(new int[2] { x,y});
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
            cellnum =rand.Next(path.Count);
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
            path.Add(new int[2] {x,y});
            cellnum=path.Count-1;
            bool again = false;
//           for (int i = 1; i < size - 1; i = i + 2) 
//           { 
//               for (int j = 1; j < size - 1; j = j + 2) 
//               { 
//                   if (lab[i, j] == 0) 
//                   { again = true; } 
//               } 
//           }

            if (path.Count!=0) 
            { 
                goto Deadend_chek; 
            }
            fin:
            return lab;
        }
    }
}
