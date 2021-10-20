namespace TicTacToe
{
    class Game
    {
        const char PLAYER_X = 'X';
        const char PLAYER_O = 'O';
        readonly char EMPTY_CELL;
        private int size;
        private char curentPlayer = PLAYER_X;
        private char[,] field;
        private GameState gameState;


        public Game(int sizeField, char emptyCell)
        {
            gameState = GameState.IN_PROGRESS;
            EMPTY_CELL = emptyCell;
            size =  sizeField >= 3? sizeField : 3;
            InitField(size);
        }
        public Game(int sizeField) : this(sizeField, '*')
        {

        }
        public Game() : this(3, '*')
        {

        }

        public char[,] Field
        {
            get
            {
                return field;
            }
        }
        public void Move(int i, int j)
        {
            if (i >= 0 && i < size && j >= 0 && j < size)
            {
                if (field[i, j] == EMPTY_CELL)
                {
                    field[i, j] = curentPlayer;
                    ChangeCurentPlayer();
                }
            }
            CheckState();
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
            curentPlayer = curentPlayer == PLAYER_X ? PLAYER_O : PLAYER_X;
        }
        private void CheckState()
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size - 2; ++j)
                {
                    if (Compare(field[i, j], field[i, j + 1], field[i, j + 2]))
                    {
                        gameState = GameState.WIN;
                        return;
                    }
                }
            }

            for (int i = 0; i < size - 2; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (Compare(field[i, j], field[i + 1, j], field[i + 2, j]))
                    {
                        gameState = GameState.WIN;
                        return;
                    }
                }
            }

            for (int i = 0; i < size - 2; i++)
            {
                for (int j = 0; j < size - 2; j++)
                {
                    if (Compare(field[i, j], field[i + 1, j + 1], field[i + 2, j + 2]))
                    {
                        gameState = GameState.WIN;
                        return;
                    }
                }
            }

            for (int i = 0; i < size - 2; i++)
            {
                for (int j = 2; j < size; j++)
                {
                    if (Compare(field[i, j], field[i + 1, j - 1], field[i + 2, j - 2]))
                    {
                        gameState = GameState.WIN;
                        return;
                    }
                }
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
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    field[i, j] = EMPTY_CELL;
                }
            }
        }
        private bool Compare(char a, char b, char c)
        {
            return (a != EMPTY_CELL && a == b && b == c);
        }
    }
}