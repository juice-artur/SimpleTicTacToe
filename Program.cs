using System;
using Game;

namespace InterLink
{
    class Program
    {
        static void Draw(char[,] field)
        {
            Console.WriteLine("-+---+---+---+-");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" | " + field[i, j]);
                }
                Console.Write(" | \n");
                Console.Write("-+---+---+---+-");
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            TicTacToe ttt = new TicTacToe();
            Draw(ttt.Field);
            int i, j;
            while(ttt.CheckWiner() == 'N')
            {
                //Console.Clear();
                Console.WriteLine("Enter I");
                i =  Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter J ");
                j =  Convert.ToInt32(Console.ReadLine());
                ttt.Move(i, j);
                Draw(ttt.Field);
            }

            Console.WriteLine(ttt.CheckWiner());

        }
    }
}
