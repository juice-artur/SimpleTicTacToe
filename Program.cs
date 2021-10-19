using System;
using Game;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            int i, j;
            while(ttt.CheckWiner() == 'N')
            {
                Draw(ttt.Field);
                Console.WriteLine("Enter I");
                i =  Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter J ");
                j =  Convert.ToInt32(Console.ReadLine());
                ttt.Move(i, j);
                Console.Clear();
            }

            Console.WriteLine("The game ended with a result: " + (ttt.CheckWiner() == 'T' ? "Tie" : "Victory ") +  ttt.CheckWiner());

        }
    }
}
