using System;
using  TicTacToe;

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
            Game ttt = new Game(3, '*');
            int i, j;
            while(ttt.IsInProgress())
            {
                Draw(ttt.Field);
                Console.WriteLine("Enter I");
                i =  Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter J ");
                j =  Convert.ToInt32(Console.ReadLine());
                ttt.Move(i, j);
                Console.Clear();
            }
            char winer = ttt.GetStatus() == GameState.TIE ? ' ': ttt.GetWiner(); 
            Console.WriteLine("The game ended with a result: " + $"{ttt.GetStatus()}  {winer}");

        }
    }
}
