namespace Game
{
    class TicTacToe
    {
        /*public TicTacToe(char firstMove)
        {
            player = firstMove;
        }*/
        private void ChangeCurentPlayer()
        {
            curentPlayer = curentPlayer == 'X' ? 'O' : 'X';
        }
        public char CheckWiner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Equals(field[i, 0], field[i, 1], field[i, 2]))
                {
                    return field[i, 0];
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (Equals(field[0, j], field[1, j], field[2, j]))
                {
                    return field[0, j];
                }
            }


            if (Equals(field[0, 0], field[1, 1], field[2, 2]))
            {
                return field[0, 0];
            }
            if (Equals(field[2, 0], field[1, 1], field[0, 2]))
            {
                return field[2, 0];
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == '*')
                    {
                        return 'N';
                    }
                }
            }

            return 'T';
        }

        private bool Equals(char a, char b, char c)
        {
            return (a == b && b == c && a != '*');
        }
        public void Move(int i, int j)
        {
            if(field[i,j] == '*')
            {
                field[i, j] = curentPlayer; 
                ChangeCurentPlayer();
            }
        }
        private char[,] field = { { '*', '*', '*' }, { '*', '*', '*' }, { '*', '*', '*' } };
        private char[] pleyers = { 'X', 'O' };

        private char curentPlayer = 'X';
        //private char player;
        public char[,] Field
        {
            get
            {
                return field;
            }
        }
    }
}