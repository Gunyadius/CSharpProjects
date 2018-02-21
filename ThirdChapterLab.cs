using System;

namespace ThirdChapterLab
{
    struct Star
    {
        public int x, y, changeX, changeY;
        public char symbol;
        public void Fly()
        {
            x += changeX;
            y += changeY;
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        public void Collide()
        {
            if ((x == 0) || (x == 80) || (x + changeX >= 80) || (x + changeX <= 1))
                changeX = -changeX;
            if ((y == 24) || (y == 0) || (y + changeY >= 24) || (y + changeY <= 1))
                changeY = -changeY;
        }
    }
    class MainClass
    {
        static void CollideStars(Star[] other,int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = i; j < num; j++)
                {
                    if (i != j)
                    {
                        if (other[i].x == other[j].x)
                        {
                            if ((other[i].y + 1 == other[j].y) || (other[i].y - 1 == other[j].y) || (other[i].y == other[j].y))
                            {
                                if (Znak(other[i].changeX, other[j].changeX))
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
                                if ((other[i].x + 1 == other[j].x) && ((other[i].y + 1 == other[j].y) || (other[i].y - 1 == other[j].y)))
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
            if ((x >= 0) && (y >= 0))
                return true;
            else
            {
                if ((x < 0) && (y < 0))
                    return true;
                else
                    return false;
            }
        }
        static int RandomPath(Random rnd2)
        {
            int plus = 1;
            int minus = -1;
            Random rnd3 = new Random();
            if (rnd3.Next(100) > 50)
                return plus*rnd2.Next(1,2);
            else
                return minus*rnd2.Next(1,2);
        }
        static void Main()
        {
            Console.WriteLine("Enter the number of stars: ");
            int number = int.Parse(Console.ReadLine());
            Star[] myStars = new Star[number];
            Console.CursorVisible = false;
            Random rnd2 = new Random();
            Random rnd = new Random();
            for (int i = 0; i < number;i++)
            {
                myStars[i] = new Star();
                myStars[i].x = rnd.Next(1, 80);
                myStars[i].y = rnd.Next(1, 24);
                myStars[i].changeX = RandomPath(rnd2);
                myStars[i].changeY = RandomPath(rnd2);
                myStars[i].symbol = '*';
            }
            while (true)
            {
                CollideStars(myStars,number);
                for (int i = 0; i < number; i++)
                {
                    myStars[i].Collide();
                    myStars[i].Fly();
                }

                System.Threading.Thread.Sleep(40);
                Console.Clear();
            }
        }
    }
}