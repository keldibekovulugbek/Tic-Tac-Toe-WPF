using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    
    public partial class Game : Window
    {
        private char player1= 'X';
        private char player2 ='O';
        private int countPlayer;
        private int count = 0;
        public char[] board = {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        public Game(int countPlayer)
        {
            this.countPlayer=countPlayer;

            InitializeComponent();
        }
        void Print()
        {
            btn1.Content = board[1];
            btn2.Content = board[2];
            btn3.Content = board[3];
            btn4.Content = board[4];
            btn5.Content = board[5];
            btn6.Content = board[6];
            btn7.Content = board[7];
            btn8.Content = board[8];
            btn9.Content = board[9];

        }
        int CheckWinner(char[] board)
        {
            for (int i = 1; i < 8; i += 3)
            {
                if (board[i] == board[i + 1] && board[i] == board[i + 2])
                {
                    if (board[i] == player1)
                    {
                        return -10;
                    }
                    else if (board[i] == player2)
                    {
                        return +10;
                    }
                }
            }
            for (int i = 1; i < 4; i++)
            {
                if (board[i] == board[i + 3] && board[i] == board[i + 6])
                {
                    if (board[i] == player1)
                    {
                        return -10;
                    }
                    else if (board[i] == player2)
                    {
                        return +10;
                    }
                }
            }

            if (board[1] == board[5] && board[1] == board[9])
            {
                if (board[1] == player1)
                {
                    return -10;
                }
                else if (board[1] == player2)
                {
                    return +10;
                }
            }
            if (board[3] == board[5] && board[3] == board[7])
            {
                if (board[3] == player1)
                {
                    return -10;
                }
                else if (board[3] == player2)
                {
                    return +10;
                }
            }
            return 0;
        }
        bool IsMovesHave(char[] board)
        {
            for (int i = 1; i < 10; i++)
                if (board[i] == ' ')
                    return true;
            return false;
        }
        int MiniMax(char[] board, int depth, bool isMax)
        {
            int score = CheckWinner(board);
            if (score == 10)
                return score;
            if (score == -10)
                return score;
            if (IsMovesHave(board) == false)
                return 0;
            if (isMax)
            {
                int best = -1000;
                for (int i = 1; i < 10; i++)
                {
                    if (board[i] == ' ')
                    {
                        board[i] = player2;
                        best = Math.Max(best, MiniMax(board, depth + 1, !isMax));
                        board[i] = ' ';
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int i = 1; i < 10; i++)
                {
                    if (board[i] == ' ')
                    {
                        board[i] = player1;
                        best = Math.Min(best, MiniMax(board, depth + 1, !isMax));
                        board[i] = ' ';
                    }
                }
                return best;
            }
        }
        int FindBestMove(char[] board)
        {
            int bestVal = -1000;
            int bestMove;
            bestMove = -1;

            for (int i = 1; i < 10; i++)
            {

                if (board[i] == ' ')
                {

                    board[i] = player2;
                    int moveVal = MiniMax(board, 0, false);

                    board[i] = ' ';

                    if (moveVal > bestVal)
                    {
                        bestMove = i;
                        bestVal = moveVal;
                    }
                }
            }
            return bestMove;
        }
        void ComputerMove(char[] board)
        {
            board[FindBestMove(board)] = player2;
        }

        private void Move(int place)
        {
            count++;

            if (countPlayer == 1)
            {
                board[place] = player1;
                ComputerMove(board);
            }
            else if(count%2==1)
            {
                board[place]=player1;
            }
            else
            {
                board[place]=player2;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Button_Click_btn1(object sender, RoutedEventArgs e)
        {
            if ((btn1.Content == null || btn1.Content.ToString() == " ")&&CheckWinner(board)==0)
            {
                Move(1);
                Print();
            }
        }
        private void Button_Click_btn2(object sender, RoutedEventArgs e)
        {

            if ((btn2.Content == null || btn2.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(2);
                Print();
            }
        }
        private void Button_Click_btn3(object sender, RoutedEventArgs e)
        {
            if ((btn3.Content == null || btn3.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(3);
                Print();
            }
        }
        private void Button_Click_btn4(object sender, RoutedEventArgs e)
        {
            if ((btn4.Content == null || btn4.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(4);
                Print();
            }
        }
        private void Button_Click_btn5(object sender, RoutedEventArgs e)
        {
            if ((btn5.Content == null || btn5.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(5);
                Print();
            }
        }
        private void Button_Click_btn6(object sender, RoutedEventArgs e)
        {
            if ((btn6.Content == null || btn6.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(6);
                Print();
            }
        }
        private void Button_Click_btn7(object sender, RoutedEventArgs e)
        {
            if ((btn7.Content == null || btn7.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(7);
                Print();
            }
        }
        private void Button_Click_btn8(object sender, RoutedEventArgs e)
        {
            if ((btn8.Content == null || btn8.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(8);
                Print();
            }
        }
        private void Button_Click_btn9(object sender, RoutedEventArgs e)
        {
            if ((btn9.Content == null || btn9.Content.ToString() == " ")&& CheckWinner(board) == 0)
            {
                Move(9);
                Print();
            }
        }
    }
}
