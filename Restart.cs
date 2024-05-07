using System.Collections.Generic;
using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // Clears the buttons on the Sudoku board
        private void ClearButtons()
        {
            if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                // Clearing buttons for classic numbers Sudoku (9x9)
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (numberButtons[i, j] != null)
                        {
                            this.Controls.Remove(numberButtons[i, j]);
                            numberButtons[i, j].Dispose();
                            numberButtons[i, j] = null;
                        }
                    }
                }
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (symbolButtons[i, j] != null)
                        {
                            this.Controls.Remove(symbolButtons[i, j]);
                            symbolButtons[i, j].Dispose();
                            symbolButtons[i, j] = null;
                        }
                    }
                }
            }
            else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (numberButtons6x6[i, j] != null)
                        {
                            this.Controls.Remove(numberButtons6x6[i, j]);
                            numberButtons6x6[i, j].Dispose();
                            numberButtons6x6[i, j] = null;
                        }
                    }
                }
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (symbolButtons6x6[i, j] != null)
                        {
                            this.Controls.Remove(symbolButtons6x6[i, j]);
                            symbolButtons6x6[i, j].Dispose();
                            symbolButtons6x6[i, j] = null;
                        }
                    }
                }
            }
        }
        // Regenerates the Sudoku board
        private void Regenerate()
        {
            finishButton.Enabled = false;
            table.Visible = false;
            correctNumbers = 0;
            correctAnswers.Text = "Number of correct answers: " + correctNumbers;
            hintCounter = 0;
            helpNumbersCount.Text = "Number of assists: " + hintCounter;
            List<int> emptyCellsRow = new List<int>();
            List<int> emptyCellsColumn = new List<int>();
            // Clear buttons based on configuration
            if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                // Clearing buttons for classic numbers Sudoku (9x9)
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
            }
            else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
            }
            playerNameTextBox.Text = "";
            displayButton.Enabled = true;
            saveButton.Enabled = false;
            prompterButton.Enabled = true;
            playerNameTextBox.Enabled = true;
            boardSizeComboBox.Text = "";
            if (GetSelectedBoardType() == "classic")
            {
                classicRadioButton.Checked = false;
            }
            else
            {
                symbolRadioButton.Checked = false;
            }
            if (GetSelectedDifficulty() == "easy")
            {
                easyRadioButton.Checked = false;
            }
            else if (GetSelectedDifficulty() == "medium")
            {
                mediumRadioButton.Checked = false;
            }
            else
            {
                hardRadioButton.Checked = false;
            }
            remainingTimeInSeconds = 0;
            gameTimer.Stop();
            timeLabel.Text = "0:00";
            if (saveButtonClicked)
            {
                string difficulty = GetSelectedDifficulty();
                WriteSortedPlayerScoresToDataGridView(difficulty);
            }
        }
        // Regenerates the Sudoku board while preserving the current configuration
        private void RegenerateBoard()
        {
            finishButton.Enabled = true;
            table.Visible = false;
            prompterButton.Enabled = true;
            displayButton.Enabled = true;
            correctNumbers = 0;
            correctAnswers.Text = "Number of correct answers: " + correctNumbers;
            hintCounter = 0;
            helpNumbersCount.Text = "Number of assists: " + hintCounter;
            List<int> emptyCellsRow = new List<int>();
            List<int> emptyCellsColumn = new List<int>();
            // Clear buttons and reinitialize the board based on configuration
            if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                // Regenerating board for classic numbers Sudoku (9x9)
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
                InitializeClassicNumbersSudokuBoard();
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
                InitializeSymbolsSudokuBoard();
            }
            else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
                InitializeClassicNumbersSudokuBoard();
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                ClearButtons();
                InitializeSymbolsSudokuBoard();
            }
            saveButton.Enabled = false;
            remainingTimeInSeconds = 0;
            gameTimer.Start();
            timeLabel.Text = "0:00";
            if (saveButtonClicked)
            {
                string difficulty = GetSelectedDifficulty();
                WriteSortedPlayerScoresToDataGridView(difficulty);
            }
        }
    }
}
