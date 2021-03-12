using System;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class TicTacToe : Form
    {
        static Random rand = new Random();
        PlayerTurn t = new PlayerTurn(false);
        WinState w = new WinState(false);
        static bool AI = false;

        public TicTacToe()
        {
            InitializeComponent();
            whoseTurn(t.Turn);
        }

        //Click handlers for each square
        private void square1_Click(object sender, EventArgs e)
        {
            //Change text to whoever's turn it is
            square1.Text = xoro();
            //Make it unchangeable
            square1.Enabled = false;
            //Check if there is a win
            checkWin(sender, e);
        }

        private void square2_Click(object sender, EventArgs e)
        {
            square2.Text = xoro();
            square2.Enabled = false;
            checkWin(sender, e);
        }

        private void square3_Click(object sender, EventArgs e)
        {
            square3.Text = xoro();
            square3.Enabled = false;
            checkWin(sender, e);
        }

        private void square4_Click(object sender, EventArgs e)
        {
            square4.Text = xoro();
            square4.Enabled = false;
            checkWin(sender, e);
        }

        private void square5_Click(object sender, EventArgs e)
        {
            square5.Text = xoro();
            square5.Enabled = false;
            checkWin(sender, e);
        }

        private void square6_Click(object sender, EventArgs e)
        {
            square6.Text = xoro();
            square6.Enabled = false;
            checkWin(sender, e);
        }

        private void square7_Click(object sender, EventArgs e)
        {
            square7.Text = xoro();
            square7.Enabled = false;
            checkWin(sender, e);
        }

        private void square8_Click(object sender, EventArgs e)
        {
            square8.Text = xoro();
            square8.Enabled = false;
            checkWin(sender, e);
        }

        private void square9_Click(object sender, EventArgs e)
        {
            square9.Text = xoro();
            square9.Enabled = false;
            checkWin(sender, e);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            //Reset each square to a unique value
            //This is so the AI does not have false positives
            square1.Text = "";
            square2.Text = " ";
            square3.Text = "  ";
            square4.Text = "   ";
            square5.Text = "    ";
            square6.Text = "     ";
            square7.Text = "      ";
            square8.Text = "       ";
            square9.Text = "        ";

            //Enable each square
            square1.Enabled = true;
            square2.Enabled = true;
            square3.Enabled = true;
            square4.Enabled = true;
            square5.Enabled = true;
            square6.Enabled = true;
            square7.Enabled = true;
            square8.Enabled = true;
            square9.Enabled = true;

            //Random players turn
            Random rand = new Random();
            t.Turn = Convert.ToBoolean(rand.Next(0, 2));
            whoseTurn(t.Turn);

            //Change won filed variable to false
            w.Won = false;

            //Check win (just only used for the case that AI is active and has starting turn
            checkWin(sender, e);
        }

        //Check for win, check for ties, and start AI's turn (if active)
        private void checkWin(object sender, EventArgs e)
        {
            int o = 0;
            int i = 0;
            //Collect labels into an array
            Label[,] squares = new Label[,] { { square1, square2, square3 }, { square4, square5, square6 }, { square7, square8, square9 } };

            //Horizontal win
            for (i = 0; i < 3; i++)
            {
                //If three in a row are the same (X or O)
                if (squares[i, o].Text == squares[i, o + 1].Text && squares[i, o].Text == squares[i, o + 2].Text && !w.Won)
                {
                    //Call win method
                    win(squares, i, o);
                    //Don't continue
                    return;
                }
            }
            //Reset
            i = 0;

            //Vertical win
            for (o = 0; o < 3; o++)
            {
                //If three in a row are the same (X or O)
                if (squares[i, o].Text == squares[i + 1, o].Text && squares[i, o].Text == squares[i + 2, o].Text && !w.Won)
                {
                    //Call win
                    win(squares, i, o);
                    return;
                }
            }

            i = 0;
            o = 0;

            //If diagonal
            if (squares[i, o].Text == squares[i + 1, o + 1].Text && squares[i, o].Text == squares[i + 2, o + 2].Text && !w.Won)
            {
                win(squares, i, o);
                return;
            }

            //Another diagonal
            else if (squares[i, o + 2].Text == squares[i + 1, o + 1].Text && squares[i, o + 2].Text == squares[i + 2, o].Text && !w.Won)
            {
                win(squares, i, o);
                return;
            }

            //Check for ties
            else if (checkTie(squares) && !w.Won)
            {
                //Call tie
                tie();
                return;
            }

            //Change turns
            whoseTurn(t.Turn);
            
            //If AI is active, AI's turn
            //AI always plays as O
            if (AI && t.Turn == false)
            {
                AITurn(sender, e, squares);
            }
        }

        private void win(Label[,] squares, int i, int o)
        {
            //Set field variable to true
            w.Won = true;
            //Winner is active player when win occurs
            MessageBox.Show(String.Format("Player {0} wins!", xoro()));

            //If winning move was done by PlayerX
            //This could have also used to xoro() method
            if (squares[i, o].Text == "X")
            {
                //Add one to score
                int score = Int32.Parse(XScore.Text);
                score++;
                XScore.Text = score.ToString();
            }

            //If winning move was done by PlayerO
            else if (squares[i, o].Text == "O")
            {
                int score = Int32.Parse(OScore.Text);
                score++;
                OScore.Text = score.ToString();
            }

            //Disable each square
            for (int k = 0; k < 3; k++)
                for (int l = 0; l < 3; l++)
                    squares[k, l].Enabled = false;

            //Change scores to percents
            percents();
        }

        //Tie method
        private void tie()
        {
            //Set field variable to true
            w.Won = true;
            MessageBox.Show("It's a tie.");

            //Add to ties score
            int score = Int32.Parse(TieScore.Text);
            score++;
            TieScore.Text = score.ToString();

            //Update percents
            percents();
        }

        //Check whose turn it is
        private void whoseTurn(bool turn)
        {
            //Change turns
            t.Turn = !t.Turn;
            //Display turn
            turnLabel.Text = String.Format("Player {0}'s Turn", xoro());
        }

        //Return current player
        private string xoro()
        {
            if (t.Turn)
                return "X";
            else
                return "O";
        }

        //Check if tie
        private bool checkTie(Label[,] squares)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int o = 0; o < 3; o++)
                {
                    //If one square is not X or O, then not a tie
                    if (squares[i, o].Text != "X" && squares[i, o].Text != "O")
                    {
                        return false;
                    }
                }
            }
            //If all squares are X or O, then it is a tie
            return true;
        }

        //Update percents
        private void percents()
        {
            //Get all current scores
            float x = Int32.Parse(XScore.Text);
            float tie = Int32.Parse(TieScore.Text);
            float o = Int32.Parse(OScore.Text);

            //Find total games
            float totalGames = x + tie + o;

            //Update percents
            XPercent.Text = (x / totalGames * 100).ToString("N2");
            TiePercent.Text = (tie / totalGames * 100).ToString("N2");
            OPercent.Text = (o /totalGames * 100).ToString("N2");
        }

        //Change AI activity
        private void AICheck_CheckedChanged(object sender, EventArgs e)
        {
            AI = !AI;

            //Call check win in case AI gets starting turn
            if (AI)
                checkWin(sender, e);
        }

        //On AI's turn
        private void AITurn(object sender, EventArgs e, Label[,] squares)
        {
            //Always take center first
            if (square5.Enabled == true)
            {
                square5_Click(sender, e);
                return;
            }

            //Otherwise, check for pairs
            else
            {
                if (checkTwo(sender, e, squares))
                    return;
            }

            //Otherwise pick corner square
            if (square1.Enabled || square3.Enabled || square7.Enabled || square9.Enabled)
            {
                //Loop until square is clicked
                while (true)
                {
                    //Random square
                    Random rand = new Random();
                    int square = rand.Next(1, 5);

                    //If chosen square is enabled, click
                    //Otherwise pick another random square
                    if (square1.Enabled && square == 1)
                    {
                        square1_Click(sender, e);
                        return;
                    }
                    else if (square3.Enabled && square == 2)
                    {
                        square3_Click(sender, e);
                        return;
                    }
                    else if (square7.Enabled && square == 3)
                    {
                        square7_Click(sender, e);
                        return;
                    }
                    else if (square9.Enabled && square == 4)
                    {
                        square9_Click(sender, e);
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //If no other squares are available, click other squares
            else if (square2.Enabled || square4.Enabled || square6.Enabled || square8.Enabled)
            {
                //Loop until square is clicked
                while (true)
                {
                    Random rand = new Random();
                    int square = rand.Next(1, 5);

                    //Same as with other squares
                    //If enabled, click
                    //Otherwise pick other square
                    if (square2.Enabled && square == 1)
                    {
                        square2_Click(sender, e);
                        return;
                    }
                    else if (square4.Enabled && square == 2)
                    {
                        square4_Click(sender, e);
                        return;
                    }
                    else if (square6.Enabled && square == 3)
                    {
                        square6_Click(sender, e);
                        return;
                    }
                    else if (square8.Enabled && square == 4)
                    {
                        square8_Click(sender, e);
                        return;
                    }

                    else
                    {
                        continue;
                    }
                }
            }

            //If not squares are available
            //Check if it is a tie
            else
                checkWin(sender, e);
        }

        //AI's system for blocking and winning
        //Currently, AI's biggest weekness is that it does not
        //Place its own pair as more important than player's
        private bool checkTwo(object sender, EventArgs e, Label[,] squares)
        {
            int square = 0;

            //Check horizontal pairs by going vertically
            if (square == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (squares[i, 0].Text == squares[i, 1].Text)
                    {
                        square = (i + 1) * 3;

                        //Call AI click based on square variable
                        if (AIClick(sender, e, squares, square))
                        {
                            return true;
                        }
                    }
                    else if (squares[i, 1].Text == squares[i, 2].Text)
                    {
                        square = (i * 3) + 1;

                        if (AIClick(sender, e, squares, square))
                        {
                            return true;
                        }
                    }

                    else if (squares[i, 0].Text == squares[i, 2].Text)
                    {
                        square = 2 * (i + 1) + i;

                        if (AIClick(sender, e, squares, square))
                        {
                            return true;
                        }
                    }
                } 
            }

            //Check vertical pairs by going horizontally
            if (square == 0)
            {
                for (int o = 0; o < 3; o++)
                {
                    if (squares[0, o].Text == squares[1, o].Text)
                    {
                        square = o + 7;

                        if (AIClick(sender, e, squares, square))
                        {
                            return true;
                        }
                    }

                    else if (squares[1, o].Text == squares[2, o].Text)
                    {
                        square = o + 1;

                        if (AIClick(sender, e, squares, square))
                        {
                            return true;
                        }
                    }

                    else if (squares[0, o].Text == squares[2, o].Text)
                    {
                        square = o + 4;

                        if (AIClick(sender, e, squares, square))
                        {
                            return true;
                        }
                    }
                }
            }

            //Check diagonal pairs
            if (square == 0)
            {
                for (int i = 0; i < 3; i += 2)
                {
                    for (int o = 0; o < 3; o += 2)
                    {
                        if (squares[i, o].Text == squares[1, 1].Text)
                        {
                            if (i == 0 && o == 0)
                                square = 9;
                            else if (i == 0 && o == 2)
                                square = 7;
                            else if (i == 2 && o == 0)
                                square = 3;
                            else if (i == 2 && o == 2)
                                square = 1;

                            if (AIClick(sender, e, squares, square))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            //V This would never be reached because AI take square5 as soon as possible V
            // if (square == 0)
            // if (squares[0, 0].Text == squares[2, 2].Text || squares[0, 2].Text == squares[2, 0].Text)
            // square = 5;

            return false;
        }

        private bool AIClick(object sender, EventArgs e, Label[,] squares, int square)
        {
            //If square is enabled, click
            //Otherwise, find other square to click
            if (square1.Enabled == true && square == 1)
            {
                square1_Click(sender, e);
                return true;
            }

            else if (square2.Enabled == true && square == 2)
            {
                square2_Click(sender, e);
                return true;
            }

            else if (square3.Enabled == true && square == 3)
            {
                square3_Click(sender, e);
                return true;
            }

            else if (square4.Enabled == true && square == 4)
            {
                square4_Click(sender, e);
                return true;
            }

            else if (square5.Enabled == true && square == 5)
            {
                square5_Click(sender, e);
                return true;
            }

            else if (square6.Enabled == true && square == 6)
            {
                square6_Click(sender, e);
                return true;
            }

            else if (square7.Enabled == true && square == 7)
            {
                square7_Click(sender, e);
                return true;
            }

            else if (square8.Enabled == true && square == 8)
            {
                square8_Click(sender, e);
                return true;
            }

            else if (square9.Enabled == true && square == 9)
            {
                square9_Click(sender, e);
                return true;
            }

            else
                return false;
        }
    }

    //Field variables for player turn
    public class PlayerTurn
    {
        private bool turn;

        public PlayerTurn(bool turn)
        {
            this.turn = turn;
        }

        public bool Turn
        {
            get
            {
                return turn;
            }

            set
            {
                turn = value;
            }
        }
    }

    //Field vatiable for win
    public class WinState
    {
        private bool won;

        public WinState(bool won)
        {
            this.won = won;
        }

        public bool Won
        {
            get
            {
                return won;
            }

            set
            {
                won = value;
            }
        }
    }
}