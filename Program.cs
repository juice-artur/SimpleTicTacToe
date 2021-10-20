using System;
using  TicTacToe;
using System.Linq;

namespace InterLink
{
    class Program
    {
        static void Draw(char[,] field, int size)
        {
            string str = string.Concat(Enumerable.Repeat("-+--", size + 1));
            Console.WriteLine(str);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(" | " + $"{field[i, j]}");
                }
                Console.Write(" |\n");
                Console.Write(str);
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            int size = 3;
            Game ttt = new Game(size, '*');
            int i, j;
            while(ttt.IsInProgress())
            {
                Draw(ttt.Field, size);
                Console.WriteLine("Enter I");
                i =  Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter J ");
                j =  Convert.ToInt32(Console.ReadLine());
                ttt.Move(i, j);
                Console.Clear();
            }
            Draw(ttt.Field, size);
            char winer = ttt.GetStatus() == GameState.TIE ? ' ': ttt.GetWiner(); 
            Console.WriteLine("The game ended with a result: " + $"{ttt.GetStatus().ToString()}  {winer}");

        }
    }
}
