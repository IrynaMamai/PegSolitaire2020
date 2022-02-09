using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Core
{
    public enum State
    {
        OPENED, CLOSED, EATEN
    }

    [Serializable]
    public class Field
    {

        public int RowCount { get; private set; }

        public int ColumnCount { get; private set; }

        public int Score;

        private readonly State[,] tiles;

        private int Maps;

        private DateTime startTime;
        private DateTime finishTime;
      

        private bool check;
        private int _row, _column;
       
    
        public Field(int maps)
        {
            check = false;
            Maps = maps;
            startTime = DateTime.Now;
            switch (Maps)
            {
                case 1:
                    RowCount = 1;
                    ColumnCount = 4;
                    tiles = new State[RowCount, ColumnCount];
                    Maps1();
                    break;
                case 2:
                    RowCount = 4;
                    ColumnCount = 4;
                    tiles = new State[RowCount, ColumnCount];
                    Maps2();
                    break;
                case 3:
                    RowCount = 5;
                    ColumnCount = 5;
                    tiles = new State[RowCount, ColumnCount];
                    Maps3();
                    break;
                case 4:
                    RowCount = 5;
                    ColumnCount = 6;
                    tiles = new State[RowCount, ColumnCount];
                    Maps4();
                    break;
                case 5:
                    RowCount = 7;
                    ColumnCount = 7;
                    tiles = new State[RowCount, ColumnCount];
                    Maps5();
                    break;
                case 6:
                    RowCount = 7;
                    ColumnCount = 7;
                    tiles = new State[RowCount, ColumnCount];
                    Maps6();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }
        }

        private void Maps1()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    tiles[i, j] = State.OPENED;
                }
            }

            tiles[0, 1] = State.EATEN;

            /*
             
             *   * *
            
            */
        }

        private void Maps2()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if ((i == 0 && j < 2) || (i == 3 && j > 1) || (j == 0 && i > 1) || (j == 3 && i < 2))
                        tiles[i, j] = State.CLOSED;
                    else
                        tiles[i, j] = State.OPENED;
                }
            }
            tiles[1, 0] = State.EATEN;

            /*
                * 
              * *
              * * *
              * 
            */
        }

        private void Maps3()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (((i == 0 || i == 4) && j == 2) || i == 2 || ((i == 1 || i == 3) && (j > 0 && j < 4)))
                        tiles[i, j] = State.OPENED;
                    else
                        tiles[i, j] = State.CLOSED;
                }
            }

            tiles[2, 2] = State.EATEN;

            /*
                 * 
               * * *
             * *   * *
               * * *
                 * 
            */
        }

        private void Maps4()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    tiles[i, j] = State.OPENED;
                }
            }

            tiles[1, 1] = State.EATEN;

            /*
             * * * * * * 
             *   * * * *
             * * * * * *
             * * * * * *
             * * * * * *
            */
        }

        private void Maps5()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if ((i >= 2 && i <= 4) || (j >= 2 && j <= 4))
                        tiles[i, j] = State.OPENED;
                    else
                        tiles[i, j] = State.CLOSED;
                }

            }
            tiles[3, 3] = State.EATEN;

            /*
                * * *
                * * *
            * * * * * * * 
            * * *   * * * 
            * * * * * * * 
                * * *
                * * *
            */
        }

        private void Maps6()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (((i <= 1 || i >= 5) && (j == 0 || j == 6)) || ((i == 0 || i == 6) && (j == 1 || j == 5)))
                        tiles[i, j] = State.CLOSED;
                    else
                        tiles[i, j] = State.OPENED;
                }
            }

            tiles[2, 3] = State.EATEN;

            /*
                 * * *    
               * * * * *  
             * * *   * * *
             * * * * * * *
             * * * * * * *
               * * * * *  
                 * * *    
            */
        }

        public State GetTile(int row, int column)
        {
            return tiles[row, column];
        }

        public bool IsSolved()
        {
            var isSolved = 0;
            for (var row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    if (tiles[row, column] == State.OPENED)
                    {
                        isSolved++;
                    }
                }
            }

            if (isSolved == 1)
            {
                return true;
            }
            return false;
        }

        public bool IsLosed()
        {
            var isLosed = 0;
            var Check = 0;
            var Cheak1 = 0;
            for (var row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    Check = 0;
                    if (tiles[row, column] == State.OPENED)
                    { 
                        Cheak1++;
                        if (column - 2 >= 0 && tiles[row, column - 1] == State.OPENED && tiles[row, column - 2] == State.EATEN)
                            Check++;
                        if (column + 2 < ColumnCount && tiles[row, column + 1] == State.OPENED && tiles[row, column + 2] == State.EATEN)
                            Check++;
                        if (row - 2 >= 0 && tiles[row - 1, column] == State.OPENED && tiles[row - 2, column] == State.EATEN)
                            Check++;
                        if (row + 2 < RowCount && tiles[row + 1, column] == State.OPENED && tiles[row + 2, column] == State.EATEN)
                            Check++;


                        if (Check == 0)
                            isLosed++;
                    }


                }
            }


            if (isLosed == Cheak1)
            {  
                return true;
            }


            finishTime = DateTime.Now;

            return false;
        }

       
        public bool MoveTile(int row, int column, char direction)
        {
            if (direction == 'A' && column - 2 >= 0)
            {
                if (tiles[row, column - 1] == State.OPENED && tiles[row, column - 2] == State.EATEN)
                {
                    tiles[row, column] = State.EATEN;
                    tiles[row, column - 1] = State.EATEN;
                    tiles[row, column - 2] = State.OPENED;
                    return true;
                }
            }

            if (direction == 'D' && column + 2 < ColumnCount)
            {
                if (tiles[row, column + 1] == State.OPENED && tiles[row, column + 2] == State.EATEN)
                {
                    tiles[row, column] = State.EATEN;
                    tiles[row, column + 1] = State.EATEN;
                    tiles[row, column + 2] = State.OPENED;
                    return true;
                }
            }

            if (direction == 'W' && row - 2 >= 0)  //Up
            {
                if (tiles[row - 1, column] == State.OPENED && tiles[row - 2, column] == State.EATEN)
                {
                    tiles[row, column] = State.EATEN;
                    tiles[row - 1, column] = State.EATEN;
                    tiles[row - 2, column] = State.OPENED;
                    return true;
                }
            }


            if (direction == 'S' && row + 2 < RowCount)  //Down
            {
                if (tiles[row + 1, column] == State.OPENED && tiles[row + 2, column] == State.EATEN)
                {
                    tiles[row, column] = State.EATEN;
                    tiles[row + 1, column] = State.EATEN;
                    tiles[row + 2, column] = State.OPENED;
                    return true;
                }
            }


            return false;
        }

        public int GetScore()
        {
            if ((RowCount * ColumnCount * 5 - (finishTime - startTime).Seconds) < 0)
                return 0;
            return RowCount * ColumnCount * 5 - (finishTime - startTime).Seconds;
        }

        public void MoveTileForWeb(int row, int column, bool type)
        {
            if (type)
            {
                _row = row;
                _column = column;
                check = true;
            }
            else if(!type && check)
            {
                if (_row == row && _column != column)
                {
                    if (_column - column > 0)   MoveTile(_row, _column, 'A');
                    else                        MoveTile(_row, _column, 'D'); 
                }
                else if (_row != row && _column == column)
                { 
                    if(_row - row > 0)   MoveTile(_row, _column, 'W');
                    else                 MoveTile(_row, _column, 'S');


                }

                check = false;
            }

        }
    }
}
