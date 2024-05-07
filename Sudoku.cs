using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // Random number generator
        private Random random = new Random();
        // Grid of Textbox controls numbers in Sudoku 9x9
        private TextBox[,] numberButtons = new TextBox[9, 9];
        // Grid of Button controls numbers in Sudoku 9x9
        private Button[,] symbolButtons = new Button[9, 9];
        // Solved Sudoku board for 9x9 Sudoku
        private int[,] sudokuBoard = new int[9, 9];
        // Not solved Sudoku board for 9x9 Sudoku
        private int[,] playBoard = new int[9, 9];
        // Grid of Textbox controls numbers in Sudoku 6x6
        private TextBox[,] numberButtons6x6 = new TextBox[6, 6];
        // Grid of Button controls numbers in Sudoku 6x6
        private Button[,] symbolButtons6x6 = new Button[6, 6];
        // Solved Sudoku board for 6x6 Sudoku
        private int[,] sudokuBoard6x6 = new int[6, 6];
        // Not solved Sudoku board for 6x6 Sudoku
        private int[,] playBoard6x6 = new int[6, 6];
        // Array of symbol images for a 9x9 Sudoku
        private Bitmap[] symbolImages = new Bitmap[10];
        // Array of symbol images for a 6x6 Sudoku
        private Bitmap[] symbolImages6x6 = new Bitmap[7];
        // Total time in seconds for the game
        private int fullTimeInSeconds;
        // Remaining time in seconds for the game
        private int remainingTimeInSeconds;
        // Count of correct numbers entered by the player
        private int correctNumbers = 0;
        // Count of hints used by the player
        private int hintCounter = 0;
        // Number of filled cells for easy difficulty in a 9x9 Sudoku
        private int easy = 37;
        // Number of filled cells for medium difficulty in a 9x9 Sudoku
        private int medium = 35;
        // Number of filled cells for hard difficulty in a 9x9 Sudoku
        private int hard = 33;
        // Number of filled cells for easy difficulty in a 6x6 Sudoku
        private int easy6x6 = 19;
        // Number of filled cells for medium difficulty in a 6x6 Sudoku
        private int medium6x6 = 17;
        // Number of filled cells for hard difficulty in a 6x6 Sudoku
        private int hard6x6 = 15;
        // State of the game
        private bool gameState = false;
        // Indicates if a hint was used
        private bool isHinted = false;
        // Indicates if the finish button was clicked
        private bool finishButtonClicked = false;
        // Indicates if the start button was clicked
        private bool startButtonClicked = false;
        // Indicates if the display button was clicked
        private bool displayButtonClicked = false;
        // Indicates if the save button was clicked
        private bool saveButtonClicked = false;
        // Indicates if the regenerateBoard button was clicked
        private bool regenerateBoardClicked = false;
        // Indicates if the regenerate button was clicked
        private bool regenerateDataClicked = false;
        // Indicates if the numbers radio button is selected
        private bool drawNumRadioButton = false;
        // Indicates if the symbols radio button is selected
        private bool drawSymbolRadioButton = false;
        public Sudoku()
        {
            InitializeComponent();
        }
        private void Sudoku_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;  // Disable maximizing the form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set form border style to fixed single
            this.Size = new Size(1200, 800); // Set form size to 1200x800 pixels
            this.Paint += SudokuForm_Paint; // Order Paint event
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            // Get the player's name from the text box
            string playerName = playerNameTextBox.Text;
            // Check if required fields are filled and options are selected
            if (playerName == "" || (!drawNumRadioButton && !drawSymbolRadioButton) || (boardSizeComboBox.SelectedIndex != 0 && boardSizeComboBox.SelectedIndex != 1 && boardSizeComboBox.SelectedIndex != 2) || (!easyRadioButton.Checked && !mediumRadioButton.Checked && !hardRadioButton.Checked))
            {
                MessageBox.Show("Please fill in all the required fields to start the game! (PlayerName, BoardTypes, BoardSize, DifficultyLevels)", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Initialize the Sudoku board based on selected options
            if (playerName != "" && drawNumRadioButton == true && boardSizeComboBox.SelectedIndex == 0 && easyRadioButton.Checked == true)
            {
                InitializeClassicNumbersSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawNumRadioButton == true && boardSizeComboBox.SelectedIndex == 0 && mediumRadioButton.Checked == true)
            {
                InitializeClassicNumbersSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawNumRadioButton == true && boardSizeComboBox.SelectedIndex == 0 && hardRadioButton.Checked == true)
            {
                InitializeClassicNumbersSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawSymbolRadioButton == true && boardSizeComboBox.SelectedIndex == 0 && easyRadioButton.Checked == true)
            {
                InitializeSymbolsSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawSymbolRadioButton == true && boardSizeComboBox.SelectedIndex == 0 && mediumRadioButton.Checked == true)
            {
                InitializeSymbolsSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawSymbolRadioButton == true && boardSizeComboBox.SelectedIndex == 0 && hardRadioButton.Checked == true)
            {
                InitializeSymbolsSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawNumRadioButton == true && boardSizeComboBox.SelectedIndex == 1 && easyRadioButton.Checked == true)
            {
                InitializeClassicNumbersSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawNumRadioButton == true && boardSizeComboBox.SelectedIndex == 1 && mediumRadioButton.Checked == true)
            {
                InitializeClassicNumbersSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawNumRadioButton == true && boardSizeComboBox.SelectedIndex == 1 && hardRadioButton.Checked == true)
            {
                InitializeClassicNumbersSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawSymbolRadioButton == true && boardSizeComboBox.SelectedIndex == 1 && easyRadioButton.Checked == true)
            {
                InitializeSymbolsSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawSymbolRadioButton == true && boardSizeComboBox.SelectedIndex == 1 && mediumRadioButton.Checked == true)
            {
                InitializeSymbolsSudokuBoard();
                gameTimer.Start();
            }
            if (playerName != "" && drawSymbolRadioButton == true && boardSizeComboBox.SelectedIndex == 1 && hardRadioButton.Checked == true)
            {
                InitializeSymbolsSudokuBoard();
                gameTimer.Start();
            }
            // Set a flag to indicate that the start button was clicked
            startButtonClicked = true;
            finishButton.Enabled = true;
        }
        // Check if the Sudoku puzzle is solved
        private bool IsSudokuSolved()
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Loop through the playBoard and sudokuBoard to check if they match
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (playBoard[i, j] != sudokuBoard[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                // Loop through the playBoard and sudokuBoard to check if they match
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (playBoard6x6[i, j] != sudokuBoard6x6[i, j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        // Clear the correct answers count
        private void ClearNumbersCorrectAnswers()
        {
            correctNumbers = 0;
            correctAnswers.Text = "Number of correct answers: " + correctNumbers;
        }
        // Clear the help answers count
        private void ClearHelpAnswers()
        {
            hintCounter = 0;
            helpNumbersCount.Text = "Number of assists: " + hintCounter;
        }

        // Handle the Display Button click event
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            if (startButtonClicked)
            {
                displayButtonClicked = true;
            }
            else
            {
                MessageBox.Show("First, click the Start button to continue!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                LoadSymbolImagesWhite();
                finishButton.Enabled = false;  // Disable finish button
                saveButton.Enabled = false;    // Disable save button
                                               // Check if the game is in progress
                if (!gameState)
                {
                    MessageBox.Show("First press the Start button to start the game!", "Start game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Display the Sudoku puzzle numbers or symbols based on the selected option
                if (drawNumRadioButton)
                {
                    // Display numbers for the classic Sudoku puzzle
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            numberButtons[i, j].Text = sudokuBoard[i, j].ToString();
                            numberButtons[i, j].BackColor = Color.White;
                            gameTimer.Stop();
                            numberButtons[i, j].Enabled = false;
                            ClearNumbersCorrectAnswers();
                            ClearHelpAnswers();
                        }
                    }
                    DialogResult valasz;
                    if (MessageBox.Show("Sudoku solved correctly! Click OK button to restart the game!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        RegenerateBoard();
                    }
                }
                else
                {
                    // Display symbols for the puzzle with symbols
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            int symbolIndex = sudokuBoard[i, j];

                            if (symbolIndex >= 1 && symbolIndex < symbolImages.Length)
                            {
                                // Display symbol images
                                symbolButtons[i, j].BackgroundImage = symbolImages[symbolIndex];
                                symbolButtons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                symbolButtons[i, j].Text = "";
                                symbolButtons[i, j].Enabled = false;
                                prompterButton.Enabled = false;
                                gameTimer.Stop();
                                ClearNumbersCorrectAnswers();
                                ClearHelpAnswers();
                                LoadSymbolImagesWhite();
                            }
                        }
                    }
                    DialogResult valasz;
                    if (MessageBox.Show("Sudoku solved correctly! Click OK button to restart the game!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        RegenerateBoard();
                    }
                }
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                LoadSymbolImagesWhite();
                finishButton.Enabled = false;  // Disable finish button
                saveButton.Enabled = false;    // Disable save button
                                               // Check if the game is in progress
                if (!gameState)
                {
                    MessageBox.Show("First press the Start button to start the game!", "Start game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Display the Sudoku puzzle numbers or symbols based on the selected option
                if (drawNumRadioButton)
                {
                    // Display numbers for the classic Sudoku puzzle
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            numberButtons6x6[i, j].Text = sudokuBoard6x6[i, j].ToString();
                            numberButtons6x6[i, j].BackColor = Color.White;
                            gameTimer.Stop();
                            numberButtons6x6[i, j].Enabled = false;
                            ClearNumbersCorrectAnswers();
                            ClearHelpAnswers();
                        }
                    }
                    DialogResult valasz;
                    if (MessageBox.Show("Sudoku solved correctly! Click OK button to restart the game!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        RegenerateBoard();
                    }
                }
                else
                {
                    // Display symbols for the puzzle with symbols
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            int symbolIndex = sudokuBoard6x6[i, j];

                            if (symbolIndex >= 1 && symbolIndex < symbolImages6x6.Length)
                            {
                                // Display symbol images
                                symbolButtons6x6[i, j].BackgroundImage = symbolImages6x6[symbolIndex];
                                symbolButtons6x6[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                symbolButtons6x6[i, j].Text = "";
                                symbolButtons6x6[i, j].Enabled = false;
                                prompterButton.Enabled = false;
                                gameTimer.Stop();
                                ClearNumbersCorrectAnswers();
                                ClearHelpAnswers();
                                LoadSymbolImagesWhite();
                            }
                        }
                    }
                    DialogResult valasz;
                    if (MessageBox.Show("Sudoku solved correctly! Click OK button to restart the game!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        RegenerateBoard();
                    }
                }
            }
        }
        // Update the label displaying the remaining hint count
        private void UpdateHintCounterLabel()
        {
            helpNumbersCount.Text = "Number of assists: " + hintCounter.ToString();
        }
        // Update the label displaying the game timer
        private void UpdateTimeLabel()
        {
            timeLabel.Text = TimeSpan.FromSeconds(fullTimeInSeconds).ToString(@"mm\:ss");
        }
        // Handle the click event for the "Prompter" button
        private void PrompterClick(object sender, EventArgs e)
        {
            // Set the hint flag to true
            isHinted = true;
            // Adjust the timer when using a hint
            fullTimeInSeconds -= 10;
            remainingTimeInSeconds += 10;
            // Check if the game has started
            if (!startButtonClicked)
            {
                MessageBox.Show("Please click the Start button first to start the game!", "Missing Start button", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Increase the hint counter and update the label
                hintCounter++;
                UpdateHintCounterLabel();
            }
            // Get empty cells for either classic numbers or symbols
            List<int> emptyCellsRow = new List<int>();
            List<int> emptyCellsColumn = new List<int>();
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
            }
            int row = 0;
            int col = 0;
            // Use a hint for classic numbers
            if (emptyCellsRow.Count > 0 && drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                // Choose a random empty cell
                int randomIndex = random.Next(0, emptyCellsRow.Count);
                row = emptyCellsRow[randomIndex];
                col = emptyCellsColumn[randomIndex];
                int correctNum = sudokuBoard[row, col];
                // Update the corresponding TextBox with the correct number
                numberButtons[row, col].Text = correctNum.ToString();
                numberButtons[row, col].BackColor = Color.Orange;
                numberButtons[row, col].Enabled = false;
                // Remove the chosen cell from the empty cells list
                emptyCellsRow.RemoveAt(randomIndex);
                emptyCellsColumn.RemoveAt(randomIndex);
                // Update the playBoard and check if all cells are filled
                playBoard[row, col] = correctNum;
                if (emptyCellsRow.Count == 0)
                {
                    UpdateTimeLabel();
                    gameTimer.Stop();
                    prompterButton.Enabled = false;
                    displayButton.Enabled = false;
                }
            }
            // Use a hint for symbols
            else if (emptyCellsRow.Count > 0 && drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                LoadSymbolImagesOrange();
                // Choose a random empty cell
                int randomIndex = random.Next(0, emptyCellsRow.Count);
                row = emptyCellsRow[randomIndex];
                col = emptyCellsColumn[randomIndex];
                int correctSymbol = sudokuBoard[row, col];
                // Update the corresponding Button with the correct symbol
                Bitmap symbolImage = symbolImages[correctSymbol];
                symbolButtons[row, col].BackgroundImage = ResizeImage(symbolImage, symbolButtons[row, col].Size);
                symbolButtons[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                symbolButtons[row, col].Enabled = false;
                // Remove the chosen cell from the empty cells list
                emptyCellsRow.RemoveAt(randomIndex);
                emptyCellsColumn.RemoveAt(randomIndex);
                // Update the playBoard and check if all cells are filled
                playBoard[row, col] = correctSymbol;
                if (emptyCellsRow.Count == 0)
                {
                    UpdateTimeLabel();
                    gameTimer.Stop();
                    prompterButton.Enabled = false;
                    displayButton.Enabled = false;
                }
            }
            else if (emptyCellsRow.Count > 0 && drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                // Choose a random empty cell
                int randomIndex = random.Next(0, emptyCellsRow.Count);
                row = emptyCellsRow[randomIndex];
                col = emptyCellsColumn[randomIndex];
                int correctNum = sudokuBoard6x6[row, col];
                // Update the corresponding TextBox with the correct number
                numberButtons6x6[row, col].Text = correctNum.ToString();
                numberButtons6x6[row, col].BackColor = Color.Orange;
                numberButtons6x6[row, col].Enabled = false;
                // Remove the chosen cell from the empty cells list
                emptyCellsRow.RemoveAt(randomIndex);
                emptyCellsColumn.RemoveAt(randomIndex);
                // Update the playBoard and check if all cells are filled
                playBoard6x6[row, col] = correctNum;
                if (emptyCellsRow.Count == 0)
                {
                    UpdateTimeLabel();
                    gameTimer.Stop();
                    prompterButton.Enabled = false;
                    displayButton.Enabled = false;
                }
            }
            // Use a hint for symbols
            else if (emptyCellsRow.Count > 0 && drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                LoadSymbolImagesOrange();
                // Choose a random empty cell
                int randomIndex = random.Next(0, emptyCellsRow.Count);
                row = emptyCellsRow[randomIndex];
                col = emptyCellsColumn[randomIndex];
                int correctSymbol = sudokuBoard6x6[row, col];
                // Update the corresponding Button with the correct symbol
                Bitmap symbolImage = symbolImages6x6[correctSymbol];
                symbolButtons6x6[row, col].BackgroundImage = ResizeImage(symbolImage, symbolButtons6x6[row, col].Size);
                symbolButtons6x6[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                symbolButtons6x6[row, col].Enabled = false;
                // Remove the chosen cell from the empty cells list
                emptyCellsRow.RemoveAt(randomIndex);
                emptyCellsColumn.RemoveAt(randomIndex);
                // Update the playBoard and check if all cells are filled
                playBoard6x6[row, col] = correctSymbol;
                if (emptyCellsRow.Count == 0)
                {
                    UpdateTimeLabel();
                    gameTimer.Stop();
                    prompterButton.Enabled = false;
                    displayButton.Enabled = false;
                }
            }
        }
        private void RestartGame_Click(object sender, EventArgs e)
        {
            if (startButtonClicked)
            {
                // Set the flag to regenerate game data
                regenerateDataClicked = true;
            }
            else
            {
                // Show a warning message if Start button is not clicked
                MessageBox.Show("First, click the Start button to continue!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Regenerate the game
            Regenerate();
        }
        private void RestartBoard_Click(object sender, EventArgs e)
        {
            if (startButtonClicked)
            {
                // Set the flag to regenerate the game board
                regenerateBoardClicked = true;
                // Regenerate the board
                RegenerateBoard();
            }
            else
            {
                // Show a warning message if Start button is not clicked
                MessageBox.Show("First, click the Start button to continue!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DisableButtons()
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Disable all buttons based on the selected mode
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (drawNumRadioButton)
                        {
                            numberButtons[i, j].Enabled = false;
                        }
                        else if (drawSymbolRadioButton)
                        {
                            symbolButtons[i, j].Enabled = false;
                        }
                    }
                }
            }
            else
            {
                // Disable all buttons based on the selected mode
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (drawNumRadioButton)
                        {
                            numberButtons6x6[i, j].Enabled = false;
                        }
                        else if (drawSymbolRadioButton)
                        {
                            symbolButtons6x6[i, j].Enabled = false;
                        }
                    }
                }
            }

        }
        // Handle the click event for the "Finish" button
        private void FinishClick(object sender, EventArgs e)
        {
            // Disable the display button
            displayButton.Enabled = false;
            // Check if the game state is valid
            if (!gameState)
            {
                // Display a warning message if no data is provided
                MessageBox.Show("You have not provided any data!", "There are no data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Check if the Sudoku puzzle is solved
            if (IsSudokuSolved() && boardSizeComboBox.SelectedIndex == 0)
            {
                // Congratulate the player if the puzzle is solved
                MessageBox.Show("Congratulations! You have solved the Sudoku!", "Sudoku solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameTimer.Stop();
                playerNameTextBox.Enabled = false;
                saveButton.Enabled = true;
                finishButtonClicked = true;
                DisableButtons();
            }
            // Check if the Sudoku puzzle is not solved for a 9x9 board
            else if (!IsSudokuSolved() && boardSizeComboBox.SelectedIndex == 0)
            {
                // Inform the player if the puzzle is not solved
                MessageBox.Show("You lost! You lost the game!", "Sudoku failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameTimer.Stop();
                saveButton.Enabled = false;
                prompterButton.Enabled = true;
                displayButton.Enabled = true;
                RegenerateBoard();
                gameTimer.Start();
            }
            // Check if the Sudoku puzzle is solved for a 6x6 board
            else if (IsSudokuSolved() && boardSizeComboBox.SelectedIndex == 1)
            {
                // Congratulate the player if the puzzle is solved
                MessageBox.Show("Congratulations! You have solved the Sudoku!", "Sudoku solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameTimer.Stop();
                playerNameTextBox.Enabled = false;
                saveButton.Enabled = true;
                finishButtonClicked = true;
                DisableButtons();
            }
            // Check if the Sudoku puzzle is not solved for a 6x6 board
            else if (!IsSudokuSolved() && boardSizeComboBox.SelectedIndex == 1)
            {
                // Inform the player if the puzzle is not solved
                MessageBox.Show("You lost! You lost the game!", "Sudoku failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameTimer.Stop();
                saveButton.Enabled = false;
                prompterButton.Enabled = true;
                displayButton.Enabled = true;
                RegenerateBoard();
                gameTimer.Start();
            }
        }
        // KeyPress event handlers to prevent input in certain textboxes
        private void GreenColorSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void RedColorSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void OrangeColorSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void LightBlueSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void GameRuleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}