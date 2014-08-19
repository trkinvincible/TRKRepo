using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    class TicTacToe
    {
        static char[,] m_board = new char [3,3]{
                                        {' ',' ',' '},
                                        {' ',' ',' '},
                                        {' ',' ',' '}};
        public static bool m_win;
        public static System.Collections.Hashtable m_inputHashTable;
        
        static void DisplayBoard()
        {
            char [,] boardOutLine = new char[4,6] {
                                            {' ','A',' ','B',' ','C'},
                                            {'1',' ','|',' ','|',' '},
                                            {'2',' ','|',' ','|',' '},
                                            {'3',' ','|',' ','|',' '}};
            for(int i=0;i<4;i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ----------");
                for (int j = 0; j < 6;j++)
                {
                    Console.Write("{0} ", boardOutLine[i,j]);
                }
            }
        }

        static bool IsBoardFull()
        {
            return false;
        }

        static System.Collections.Hashtable GetHashTable()
        {
            if (TicTacToe.m_inputHashTable == null)
            {
                TicTacToe.m_inputHashTable = new System.Collections.Hashtable();
                TicTacToe.m_inputHashTable.Add("A1","0,0");
                TicTacToe.m_inputHashTable.Add("A2","1,0");
                TicTacToe.m_inputHashTable.Add("A3","2,0");
                TicTacToe.m_inputHashTable.Add("B1","0,1");
                TicTacToe.m_inputHashTable.Add("B2","1,1");
                TicTacToe.m_inputHashTable.Add("B3","2,1");
                TicTacToe.m_inputHashTable.Add("C1","0,2");
                TicTacToe.m_inputHashTable.Add("C2","1,2");
                TicTacToe.m_inputHashTable.Add("C3","2,2");

                return TicTacToe.m_inputHashTable;
            }
            else
            {
                return TicTacToe.m_inputHashTable;
            }
        }
        static void EnterPosition(char side)
        {
            char previousside = '1';
            while (true)
            {
                Console.Write("{0}'s turn:your move:",side);
                String input = Console.ReadLine().ToString();
                if(side == previousside)
                {
                    Console.Write("Not your Turn!!");
                    continue;
                }
                previousside = side;
                if (IsBoardFull() != true)
                {
                    System.Collections.Hashtable tableMapping = TicTacToe.GetHashTable();
                    String position = (String)tableMapping[input];
                    String[] arrayposition = position.Split(',');

                    Int16 row = Int16.Parse(arrayposition[0]);
                    Int16 column = Int16.Parse(arrayposition[1]);

                    if (m_board[row, column] == ' ')
                    {
                        m_board[row, column] = (side == 0 ? 'o' : 'x');
                        TicTacToe.DisplayBoard();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input please re enter");
                    }
                }
            }
        }

        static void CheckWinning()
        {
            String searchH = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    searchH += TicTacToe.m_board[i,j];
                }
            }
            String searchV = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    searchV += TicTacToe.m_board[j, i];
                }
            }
            String searchD1 = "";
            searchH += TicTacToe.m_board[0, 0];
            searchH += TicTacToe.m_board[1, 1];
            searchH += TicTacToe.m_board[2, 1];
            
            String searchD2 = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    searchH += TicTacToe.m_board[i, j];
                }
            }
        }
        static void Main()
        {
            TicTacToe.DisplayBoard();
            int yside = 1;
            while (true)
            {
                yside = ~yside;
                char side = Convert.ToChar(yside);
                TicTacToe.EnterPosition(side);

            }

            Console.ReadKey();
        }
    }
}
