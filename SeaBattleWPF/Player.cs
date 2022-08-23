using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    //public enum StateMyShip { empty = 0, ship = 1, shotShip = 2 };
    //public enum StateAlienShip { empty = 0, shotShip = 1, miss = 2 };
    internal class Player
    {
        Random random = new Random();

        private const int sizeField = 10;
        private const int MaxShips = 10;

        internal int numberShips { get; set; } = MaxShips; //Maximal number of ship

        //0("_") - empty, 1("O") - ship, 2("X") - my ship killed
        private int[,] myField = new int[sizeField, sizeField];
        //0("_") - no moved, 1("X") - shot ship, 2("*") - miss
        private int[,] myMoves = new int[sizeField, sizeField];
        //History of move
        //private List<string> history = new List<string>();

        public Player(bool autoInit = true)
        {
            if(autoInit)
                InitAuto();
            else
                zeroingField();
        }       

        public int getSizeField() { return sizeField; }       

        public int getFieldElement(int i, int j) { return myField[i, j]; }

        public void setFieldElement(int i, int j, int value) { myField[i, j] = value; }

        public int getMyMoveElement(int i, int j) { return myMoves[i, j]; }

        public void setMyMoveElement(int i, int j, int value) { myMoves[i, j] = value; }

        //Indecsator for alienField because most often there is an appeal to him 
        //For handler
        internal int this[int i, int j]
        {
            get { return myMoves[i, j]; }
            set { myMoves[i, j] = value; }
        }

        public void InitAuto()
        {
            zeroingField();
            AutoPlacmentShip();            
        }        

        public void zeroingField()
        {
            for (byte i = 0; i < sizeField; i++)
            {
                for (byte j = 0; j < sizeField; j++)
                {
                    myField[i, j] = 0;
                    myMoves[i, j] = 0;
                }
            }
            numberShips = 10;
        }//end zeroingField

        public bool placementShip(int i, int j)
        {
            if (numberShips != 0)
            {
                if (myField[i, j] == 0)
                {
                    if (i > 0 && i < sizeField - 1 && j > 0 && j < sizeField - 1)
                    {
                        if (myField[i + 1, j] == 0 && myField[i - 1, j] == 0 &&
                            myField[i, j + 1] == 0 && myField[i, j - 1] == 0 && myField[i + 1, j + 1] == 0 &&
                            myField[i - 1, j - 1] == 0 && myField[i + 1, j - 1] == 0 && myField[i - 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (i == 0 && j == 0)
                    {
                        if (myField[i + 1, j] == 0 && myField[i, j + 1] == 0 && myField[i + 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (i == sizeField - 1 && j == sizeField - 1)
                    {
                        if (myField[i - 1, j] == 0 && myField[i, j - 1] == 0 && myField[i - 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (i == sizeField - 1 && j == 0)
                    {
                        if (myField[i - 1, j] == 0 && myField[i, j + 1] == 0 && myField[i - 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (i == 0 && j == sizeField - 1)
                    {
                        if (myField[i + 1, j] == 0 && myField[i, j - 1] == 0 && myField[i + 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (i == 0)
                    {
                        if (myField[i, j + 1] == 0 && myField[i, j - 1] == 0 && myField[i + 1, j] == 0 &&
                            myField[i + 1, j + 1] == 0 && myField[i + 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (i == sizeField - 1)
                    {
                        if (myField[i - 1, j] == 0 && myField[i - 1, j + 1] == 0 && myField[i, j - 1] == 0 &&
                            myField[i, j + 1] == 0 && myField[i - 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (j == 0)
                    {
                        if (myField[i + 1, j] == 0 && myField[i - 1, j] == 0 && myField[i, j + 1] == 0 &&
                            myField[i - 1, j + 1] == 0 && myField[i + 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }
                        }
                    }
                    else if (j == sizeField - 1)
                    {
                        if (myField[i - 1, j] == 0 && myField[i + 1, j] == 0 && myField[i, j - 1] == 0 &&
                            myField[i - 1, j - 1] == 0 && myField[i + 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;

                            if (numberShips != 0)
                                return false;
                            else
                            {
                                numberShips = 10;
                                return true;
                            }                                
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }//end ManuallyFill
       
        private void AutoPlacmentShip()
        {
            while (numberShips != 0)
            {
                int i = random.Next(sizeField);
                int j = random.Next(sizeField);

                if (myField[i, j] == 0)
                {
                    if (i > 0 && i < sizeField - 1 && j > 0 && j < sizeField - 1)
                    {
                        if (myField[i + 1, j] == 0 && myField[i - 1, j] == 0 &&
                            myField[i, j + 1] == 0 && myField[i, j - 1] == 0 && myField[i + 1, j + 1] == 0 &&
                            myField[i - 1, j - 1] == 0 && myField[i + 1, j - 1] == 0 && myField[i - 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (i == 0 && j == 0)
                    {
                        if (myField[i + 1, j] == 0 && myField[i, j + 1] == 0 && myField[i + 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (i == sizeField - 1 && j == sizeField - 1)
                    {
                        if (myField[i - 1, j] == 0 && myField[i, j - 1] == 0 && myField[i - 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (i == sizeField - 1 && j == 0)
                    {
                        if (myField[i - 1, j] == 0 && myField[i, j + 1] == 0 && myField[i - 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (i == 0 && j == sizeField - 1)
                    {
                        if (myField[i + 1, j] == 0 && myField[i, j - 1] == 0 && myField[i + 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (i == 0)
                    {
                        if (myField[i , j + 1] == 0 && myField[i , j - 1] == 0 && myField[i + 1, j] == 0 && 
                            myField[i + 1, j + 1] == 0 && myField[i + 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (i == sizeField - 1)
                    {
                        if (myField[i - 1, j] == 0 && myField[i - 1, j + 1] == 0 && myField[i, j - 1] == 0 &&
                            myField[i, j + 1] == 0 && myField[i - 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (j == 0)
                    {
                        if (myField[i + 1, j] == 0 && myField[i - 1, j] == 0 && myField[i, j + 1] == 0 &&
                            myField[i - 1, j + 1] == 0 && myField[i + 1, j + 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                    else if (j == sizeField-1)
                    {
                        if (myField[i - 1, j] == 0 && myField[i + 1, j] == 0 && myField[i, j - 1] == 0 &&
                            myField[i - 1, j - 1] == 0 && myField[i + 1, j - 1] == 0)
                        {
                            myField[i, j] = 1;
                            numberShips--;
                            continue;
                        }
                    }
                }               
            }
            numberShips = 10;
        }//end fillMyField
    }//end class Player
}//end namespace SeaBattle
