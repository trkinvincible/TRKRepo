﻿using System;
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
        public static bool m_win = false;
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
                    if(i == 1 && j == 1)
                        Console.Write("{0} ", m_board[0, 0]);
                    else if (i == 1 && j == 3)
                        Console.Write("{0} ", m_board[0, 1]);
                    else if (i == 1 && j == 5)
                        Console.Write("{0} ", m_board[0, 2]);
                    else if (i == 2 && j == 1)
                        Console.Write("{0} ", m_board[1, 0]);
                    else if (i == 2 && j == 3)
                        Console.Write("{0} ", m_board[1, 1]);
                    else if (i == 2 && j == 5)
                        Console.Write("{0} ", m_board[1, 2]);
                    else if (i == 3 && j == 1)
                        Console.Write("{0} ", m_board[2, 0]);
                    else if (i == 3 && j == 3)
                        Console.Write("{0} ", m_board[2, 1]);
                    else if (i == 3 && j == 5)
                        Console.Write("{0} ", m_board[2, 2]);
                    else
                        Console.Write("{0} ", boardOutLine[i,j]);
                }
            }
        }

        static bool IsBoardFull()
        {
            bool isFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m_board[i, j] == ' ')
                    {
                        isFull = false;
                        break;
                    }
                }
            }
            return isFull;
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
            bool enteredwrong = false;
            while (true)
            {
                Console.Write("\n\n{0}'s turn:your move:",side);
                String input = Console.ReadLine().ToString();
                if (side == previousside && enteredwrong != true)
                {
                    Console.Write("Not your Turn!!");
                    continue;
                }
                input = input.ToUpper();

                previousside = side;
                if (IsBoardFull() != true)
                {
                    System.Collections.Hashtable tableMapping = TicTacToe.GetHashTable();
                    String position = (String)tableMapping[input];
                    if (position == null)
                    {
                        Console.WriteLine("Invalid Input please re enter");
                        enteredwrong = true;
                        continue;
                    }
                    String[] arrayposition = position.Split(',');

                    Int16 row = Int16.Parse(arrayposition[0]);
                    Int16 column = Int16.Parse(arrayposition[1]);

                    if (m_board[row, column] == ' ')
                    {
                        m_board[row, column] = (side == 1 ? 'o' : 'x');
                        TicTacToe.DisplayBoard();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input please re enter");
                    }
                }
                else
                {
                    Console.WriteLine("Game Over NoBody Wins!!");
                }
            }
        }

        static bool CheckWinning()
        {
            String searchH = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    searchH += TicTacToe.m_board[i,j];
                }
            }
            String searchV = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    searchV += TicTacToe.m_board[j, i];
                }
            }
            String searchD1 = "";
            searchD1 += TicTacToe.m_board[0, 0];
            searchD1 += TicTacToe.m_board[1, 1];
            searchD1 += TicTacToe.m_board[2, 2];
            
            String searchD2 = "";
            searchD2 += TicTacToe.m_board[0, 2];
            searchD2 += TicTacToe.m_board[1, 1];
            searchD2 += TicTacToe.m_board[2, 0];

            if (searchD1 == "ooo")
            {
                Console.WriteLine("\n\no WINS");
                TicTacToe.m_win = true;
            }
            if (searchD1 == "xxx")
            {
                Console.WriteLine("\n\nx WINS");
                TicTacToe.m_win = true;
            }
            if(searchD2 == "ooo")
            { 
                Console.WriteLine("\n\no WINS");
                TicTacToe.m_win = true;
            }
            if (searchD2 == "xxx")
            {
                Console.WriteLine("\n\nx WINS");
                TicTacToe.m_win = true;
            }
            if(searchH.Substring(0,3) == "ooo"
                ||searchH.Substring(3,3) == "ooo"
                    ||searchH.Substring(6,3) == "ooo")
            {
                Console.WriteLine("\n\no WINS");
                TicTacToe.m_win = true;
            }
            if (searchH.Substring(0, 3) == "xxx"
                || searchH.Substring(3, 3) == "xxx"
                    || searchH.Substring(6, 3) == "xxx")
            {
                Console.WriteLine("\n\nx WINS");
                TicTacToe.m_win = true;
            }
            if (searchV.Substring(0, 3) == "ooo"
                || searchH.Substring(3, 3) == "ooo"
                    || searchH.Substring(6, 3) == "ooo")
            {
                Console.WriteLine("\n\no WINS");
                TicTacToe.m_win = true;
            }
            if (searchV.Substring(0, 3) == "xxx"
                || searchH.Substring(3, 3) == "xxx"
                    || searchH.Substring(6, 3) == "xxx")
            {
                Console.WriteLine("\n\nx WINS");
                TicTacToe.m_win = true;
            }
            return TicTacToe.m_win;
        }
        static void Main()
        {
            TicTacToe.DisplayBoard();
            byte yside = 1;
            while (true)
            {
                yside = (byte)~yside;
                char side = Convert.ToChar(yside);
                TicTacToe.EnterPosition(side);
                if (TicTacToe.CheckWinning() == true)
                    break;
            }

            Console.ReadKey();
        }
    }
}
