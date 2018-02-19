using System;

namespace SecondChapterTask
{
    class Star
    {
        public Star()
        {
            Random rnd = new Random();
            x=rnd.Next(1,80);
            y = rnd.Next(1, 24);
            changeX = 1;
            changeY = 1;
            symbol = '*';
        }
        public Star(int a, int b, int c, int d, char e)
        {
            x = a;
            y = b;
            changeX = c;
            changeY = d;
            symbol = e;
        }
        public void Fly()
        {
            x += changeX;
            y += changeY;
            Console.SetCursorPosition(x,y);
            Console.Write(symbol);
        }
        public void Collide()
        {
            if ((x == 0) || (x == 80) || (x + changeX >= 80) || (x + changeX <= 1))
                changeX = -changeX;
            if ((y == 24) || (y == 0) || (y + changeY >= 24) || (y + changeY <= 1))
                changeY = -changeY;
        }
        public int x, y, changeX, changeY;
        public char symbol;
    }
    class MainProgramm : Star
    {
        static void CollideStars(Star[] other)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = i; j < 8; j++)
                {
                    if (i != j)
                    {
                        if (other[i].x == other[j].x)
                        {
                            if ((other[i].y + 1 == other[j].y)||(other[i].y - 1 == other[j].y)||(other[i].y==other[j].y))
                            {
                                if(Znak(other[i].changeX,other[j].changeX))
                                {
                                    other[i].changeY = -other[i].changeY;
                                    other[j].changeY = -other[j].changeY;
                                }
                                else
                                {
                                    int cur = other[i].changeY;
                                    other[i].changeY = other[j].changeY;
                                    other[j].changeY = cur;
                                    cur = other[i].changeX;
                                    other[i].changeX = other[j].changeX;
                                    other[j].changeX = cur;

                                }
                            }
                        }
                        else
                        {
                            if (other[i].y == other[j].y)
                            {
                                if ((other[i].x + 1 == other[j].x) || (other[i].x - 1 == other[j].x))
                                {
                                    if (Znak(other[i].changeY, other[j].changeY))
                                    {
                                        other[i].changeX = -other[i].changeX;
                                        other[j].changeX = -other[j].changeX;
                                    }
                                    else
                                    {
                                        int cur = other[i].changeY;
                                        other[i].changeY = other[j].changeY;
                                        other[j].changeY = cur;
                                        cur = other[i].changeX;
                                        other[i].changeX = other[j].changeX;
                                        other[j].changeX = cur;
                                    }
                                }
                            }
                            else
                            {
                                if ((other[i].x+1==other[j].x)&&((other[i].y+1==other[j].y)||(other[i].y - 1 == other[j].y)))
                                {
                                    
                                }
                            }
                        }
                    }
                }
            }
        }
        static bool Znak(int x, int y)
        {
            if ((x>=0)&&(y>=0))
                return true;
            else
            {
                if ((x < 0) && (y < 0))
                    return true;
                else
                    return false;
            }
        }
        static void Main()
        {
            Star [] system = new Star[8];
            system[0] = new Star(15, 15, -1, 1, '$');
            system[1] = new Star(5, 15, 1, 1, '#');
            system[2] = new Star(28, 20, 1, 1, '@');
            system[3] = new Star(10, 11, 1, 1, '%');
            system[4] = new Star();
            system[4].symbol = '!';
            system[5] = new Star();
            system[5].symbol = '0';
            system[6] = new Star();
            system[6].symbol = 'W';
            system[7] = new Star();
            system[7].symbol = '?';
            Console.CursorVisible = false;
            while(true)
            {
                CollideStars(system);
                for (int i = 0; i < 8;i++)
                {
                    system[i].Collide();
                    system[i].Fly();
                }

                System.Threading.Thread.Sleep(30);
                Console.Clear();
            }
        }
    }
}
