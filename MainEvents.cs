using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // Handle the TextChanged event for TextBoxes (for classic numbers Sudoku)
        private new void TextChanged(object sender, EventArgs e)
        {
            // Check if the selected board size is 9x9
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Get the TextBox that triggered the event
                TextBox textBox = (TextBox)sender;
                int row = -1, col = -1;
                // Find the row and column of the TextBox in the numberButtons array
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        // Check if the current TextBox is the one in the numberButtons array
                        if (numberButtons[i, j] == textBox)
                        {
                            row = i;
                            col = j;
                            break;
                        }
                    }
                }
                int enteredNumber;
                // Check if the entered text can be parsed into an integer, out keyword return multiple values from a method by modifying one of its
                // input parameters
                if (int.TryParse(textBox.Text, out enteredNumber))
                {
                    if (enteredNumber < 1 || enteredNumber > 9)
                    {
                        // Show a warning message if the entered number is out of range
                        MessageBox.Show("Wrong number! The number must be between 1 and 9!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox.Text = "";
                        return;
                    }
                    playBoard[row, col] = enteredNumber;
                    // Check if the entered number is correct and handle accordingly
                    if (enteredNumber == sudokuBoard[row, col])
                    {
                        if (isHinted)
                        {
                            isHinted = false;
                        }
                        else
                        {
                            if (GetSelectedDifficulty() == "easy")
                            {
                                // Change the appearance of the TextBox for correct answers in easy mode
                                MouseLeave(sender, e);
                                textBox.BackColor = Color.LightGreen;
                                correctNumbers++;
                                correctAnswers.Text = "Number of correct answers: " + correctNumbers;
                                textBox.Enabled = false;
                                // Get empty cells for classic numbers and check if the game is completed
                                List<int> emptyCellsRowEasy = new List<int>();
                                List<int> emptyCellsColumnEasy = new List<int>();
                                (emptyCellsRowEasy, emptyCellsColumnEasy) = GetEmptyCells();
                                if (emptyCellsRowEasy.Count == 0)
                                {
                                    gameTimer.Stop();
                                    prompterButton.Enabled = false;
                                    displayButton.Enabled = false;
                                }
                            }
                            // Check if all cells are filled and stop the game if true
                            List<int> emptyCellsRow;
                            List<int> emptyCellsColumn;
                            correctNumbers++;
                            (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                            if (emptyCellsRow.Count == 0)
                            {
                                gameTimer.Stop();
                                prompterButton.Enabled = false;
                                displayButton.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        if (GetSelectedDifficulty() == "easy")
                        {
                            // Change the appearance of the TextBox for incorrect answers in easy mode
                            MouseEnter(sender, e);
                            textBox.BackColor = Color.Red;
                        }
                    }
                }
            }
            // Check if the selected board size is 6x6
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                // Get the TextBox that triggered the event
                TextBox textBox = (TextBox)sender;
                int row = -1, col = -1;
                // Find the row and column of the TextBox in the numberButtons array
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (numberButtons6x6[i, j] == textBox)
                        {
                            row = i;
                            col = j;
                            break;
                        }
                    }
                }
                int enteredNumber;
                if (int.TryParse(textBox.Text, out enteredNumber))
                {
                    if (enteredNumber < 1 || enteredNumber > 6)
                    {
                        MessageBox.Show("Wrong number! The number must be between 1 and 6!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox.Text = "";
                        return;
                    }
                    playBoard6x6[row, col] = enteredNumber;
                    // Check if the entered number is correct and handle accordingly
                    if (enteredNumber == sudokuBoard6x6[row, col])
                    {
                        if (isHinted)
                        {
                            isHinted = false;
                        }
                        else
                        {
                            if (GetSelectedDifficulty() == "easy")
                            {
                                MouseLeave(sender, e);
                                textBox.BackColor = Color.LightGreen;
                                correctNumbers++;
                                correctAnswers.Text = "Number of correct answers: " + correctNumbers;
                                textBox.Enabled = false;
                                // Get empty cells for classic numbers and check if the game is completed
                                List<int> emptyCellsRowEasy = new List<int>();
                                List<int> emptyCellsColumnEasy = new List<int>();
                                (emptyCellsRowEasy, emptyCellsColumnEasy) = GetEmptyCells();
                                if (emptyCellsRowEasy.Count == 0)
                                {
                                    gameTimer.Stop();
                                    prompterButton.Enabled = false;
                                    displayButton.Enabled = false;
                                }
                            }
                            List<int> emptyCellsRow;
                            List<int> emptyCellsColumn;
                            correctNumbers++;
                            (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                            if (emptyCellsRow.Count == 0)
                            {
                                gameTimer.Stop();
                                prompterButton.Enabled = false;
                                displayButton.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        if (GetSelectedDifficulty() == "easy")
                        {
                            MouseEnter(sender, e);
                            textBox.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            // Check if the selected board size is 9x9
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Get the button that was clicked
                Button clickedButton = sender as Button;
                int enteredSymbol = 0;
                if (clickedButton == null) return;
                // Loop through the symbolButtons array to find the clicked button
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (symbolButtons[i, j] != clickedButton) continue;
                        // Determine the entered symbol based on the current playBoard value
                        enteredSymbol = (playBoard[i, j] == 0) ? 1 : playBoard[i, j] + 1;
                        enteredSymbol = (enteredSymbol == 10) ? 1 : enteredSymbol;
                        // Check if the entered symbol is correct or not and call the appropriate handling methods
                        if (enteredSymbol == sudokuBoard[i, j])
                        {
                            HandleCorrectSymbol(i, j, enteredSymbol);
                        }
                        else
                        {
                            HandleIncorrectSymbol(i, j, enteredSymbol);
                        }
                    }
                }
            }
            // Check if the selected board size is 6x6
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                // Get the button that was clicked
                Button clickedButton = sender as Button;
                int enteredSymbol = 0;
                if (clickedButton == null) return;
                // Loop through the symbolButtons array to find the clicked button
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (symbolButtons6x6[i, j] != clickedButton) continue;
                        // Determine the entered symbol based on the current playBoard value
                        enteredSymbol = (playBoard6x6[i, j] == 0) ? 1 : playBoard6x6[i, j] + 1;
                        enteredSymbol = (enteredSymbol == 7) ? 1 : enteredSymbol;
                        // Check if the entered symbol is correct or not and call the appropriate handling methods
                        if (enteredSymbol == sudokuBoard6x6[i, j])
                        {
                            HandleCorrectSymbol(i, j, enteredSymbol);
                        }
                        else
                        {
                            HandleIncorrectSymbol(i, j, enteredSymbol);
                        }
                    }
                }
            }
        }

        // Handle the Tick event for the game timer
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (fullTimeInSeconds <= 10)
            {
                prompterButton.Enabled = false;
            }
            // Update the remaining time and display it
            fullTimeInSeconds--;
            remainingTimeInSeconds++;
            timeLabel.Text = TimeSpan.FromSeconds(fullTimeInSeconds).ToString(@"mm\:ss");
            // Check if the time has run out
            if (fullTimeInSeconds <= 0)
            {
                gameTimer.Stop();
                prompterButton.Enabled = false;
                displayButton.Enabled = false;
                // Disable buttons based on whether classic numbers or symbols are being used
                if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            numberButtons[i, j].Enabled = false;
                        }
                    }
                }
                else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            symbolButtons[i, j].Enabled = false;
                        }
                    }
                }
                else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            numberButtons6x6[i, j].Enabled = false;
                        }
                    }
                }
                else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            symbolButtons6x6[i, j].Enabled = false;
                        }
                    }
                }
                // Prompt the user with a message indicating that time is up and ask to restart the game
                DialogResult result = MessageBox.Show("Time is up! Click OK button to restart the game!", "Sudoku failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Check if the user clicked OK
                if (result == DialogResult.OK)
                {
                    RegenerateBoard();
                }
            }
        }
    }
}
