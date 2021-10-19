namespace TicTacToe
{
    class Game : IRender
    {
        readonly char EMPTY_CELL;
        private GameState gameState;

        public Game(int size, char emptyCell)
        {
            gameState = GameState.IN_PROGRESS;
            EMPTY_CELL = emptyCell;
            InitField(size);
        }
        public void Render()
        {

        }
        public bool IsInProgress()
        {
            return gameState == GameState.IN_PROGRESS;
        }
        public char GetWiner()
        {
            ChangeCurentPlayer();
            return curentPlayer;
        }

        public GameState GetStatus()
        {
            return gameState;
        }
        private void ChangeCurentPlayer()
        {
            curentPlayer = curentPlayer == 'X' ? 'O' : 'X';
        }
        private void CheckState()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Compare(field[i, 0], field[i, 1], field[i, 2]))
                {
                    gameState = GameState.WIN;
                    return;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (Compare(field[0, j], field[1, j], field[2, j]))
                {
                    gameState = GameState.WIN;
                    return;
                }
            }


            if (Compare(field[0, 0], field[1, 1], field[2, 2]))
            {
                gameState = GameState.WIN;
                return;
            }
            if (Compare(field[2, 0], field[1, 1], field[0, 2]))
            {
               gameState = GameState.WIN;
               return;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == EMPTY_CELL)
                    {
                        gameState = GameState.IN_PROGRESS;
                        return;
                    }
                }
            }

           gameState = GameState.TIE;
        }

        private void InitField(int size) 
        {
            field = new char[size, size]; 
            for(int i = 0; i < size; ++i)
            {
                for(int j = 0; j < size; ++j)
                {
                    field[i,j] = EMPTY_CELL;
                }
            }
        }
        private bool Compare(char a, char b, char c)
        {
            return (a != EMPTY_CELL && a == b && b == c);
        }
        public void Move(int i, int j)
        {
            if (i >= 0 && i < 3 && j >= 0 && j < 3)
            {
                if (field[i, j] == EMPTY_CELL)
                {
                    field[i, j] = curentPlayer;
                    ChangeCurentPlayer();
                }
            }
            CheckState();
        }
        private char[,] field;
        private char[] pleyers = { 'X', 'O' };

        private char curentPlayer = 'X';
        public char[,] Field
        {
            get
            {
                return field;
            }
        }
    }
}
interface IRender
{
    void Render();
}