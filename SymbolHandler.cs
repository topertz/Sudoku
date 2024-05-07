using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // Handle the case when the entered symbol is correct
        private void HandleCorrectSymbol(int row, int col, int enteredSymbol)
        {
            if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                // Check the difficulty level and update UI accordingly
                if (GetSelectedDifficulty() == "easy")
                {
                    LoadSymbolImagesGreen();
                    correctNumbers++;
                    correctAnswers.Text = "Number of correct answers: " + correctNumbers;
                    symbolButtons[row, col].Enabled = false;
                    // Get empty cells for symbols and check if the game is completed
                    List<int> emptyCellsRow = new List<int>();
                    List<int> emptyCellsColumn = new List<int>();
                    (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                    if (emptyCellsRow.Count == 1)
                    {
                        gameTimer.Stop();
                        prompterButton.Enabled = false;
                        displayButton.Enabled = false;
                    }
                }
                else
                {
                    // Check if the game is completed
                    List<int> emptyCellsRow = new List<int>();
                    List<int> emptyCellsColumn = new List<int>();
                    (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                    if (emptyCellsRow.Count == 1)
                    {
                        gameTimer.Stop();
                        prompterButton.Enabled = false;
                        displayButton.Enabled = false;
                    }
                }
                // Update the symbol image on the button
                UpdateSymbolImage(row, col, enteredSymbol);
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                // Check the difficulty level and update UI accordingly
                if (GetSelectedDifficulty() == "easy")
                {
                    LoadSymbolImagesGreen();
                    correctNumbers++;
                    correctAnswers.Text = "Number of correct answers: " + correctNumbers;
                    symbolButtons6x6[row, col].Enabled = false;
                    // Get empty cells for symbols and check if the game is completed
                    List<int> emptyCellsRow = new List<int>();
                    List<int> emptyCellsColumn = new List<int>();
                    (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                    if (emptyCellsRow.Count == 1)
                    {
                        gameTimer.Stop();
                        prompterButton.Enabled = false;
                        displayButton.Enabled = false;
                    }
                }
                else
                {
                    // Check if the game is completed
                    List<int> emptyCellsRow = new List<int>();
                    List<int> emptyCellsColumn = new List<int>();
                    (emptyCellsRow, emptyCellsColumn) = GetEmptyCells();
                    if (emptyCellsRow.Count == 1)
                    {
                        gameTimer.Stop();
                        prompterButton.Enabled = false;
                        displayButton.Enabled = false;
                    }
                }
                // Update the symbol image on the button
                UpdateSymbolImage(row, col, enteredSymbol);
            }
        }
        // Handle the case when the entered symbol is incorrect
        private void HandleIncorrectSymbol(int row, int col, int enteredSymbol)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Check the difficulty level and update UI accordingly
                if (GetSelectedDifficulty() == "easy")
                {
                    LoadSymbolImagesRed();
                }
                // Update the symbol image on the button
                UpdateSymbolImage(row, col, enteredSymbol);
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                // Check the difficulty level and update UI accordingly
                if (GetSelectedDifficulty() == "easy")
                {
                    LoadSymbolImagesRed();
                }
                // Update the symbol image on the button
                UpdateSymbolImage(row, col, enteredSymbol);
            }
        }
        // Update the symbol image on the button based on the entered symbol
        private void UpdateSymbolImage(int row, int col, int enteredSymbol)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Check the difficulty level
                if (GetSelectedDifficulty() == "easy")
                {
                    // Load symbol images for easy difficulty level for a 9x9 Sudoku board
                    Bitmap symbolImage = symbolImages[enteredSymbol];
                    symbolButtons[row, col].BackgroundImage = ResizeImage(symbolImage, symbolButtons[row, col].Size);
                    symbolButtons[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    playBoard[row, col] = enteredSymbol;
                }
                else
                {
                    // Load symbol images for other difficulty levels for a Sudoku 9x9 board
                    LoadSymbolImagesWhite();
                    Bitmap symbolImage = symbolImages[enteredSymbol];
                    symbolButtons[row, col].BackgroundImage = ResizeImage(symbolImage, symbolButtons[row, col].Size);
                    symbolButtons[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    playBoard[row, col] = enteredSymbol;
                }
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                // Load symbol images for easy difficulty level for a 6x6 Sudoku board
                if (GetSelectedDifficulty() == "easy")
                {
                    Bitmap symbolImage = symbolImages6x6[enteredSymbol];
                    symbolButtons6x6[row, col].BackgroundImage = ResizeImage(symbolImage, symbolButtons6x6[row, col].Size);
                    symbolButtons6x6[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    playBoard6x6[row, col] = enteredSymbol;
                }
                else
                {
                    // Load symbol images for other difficulty levels for a Sudoku 6x6 board
                    LoadSymbolImagesWhite();
                    Bitmap symbolImage = symbolImages6x6[enteredSymbol];
                    symbolButtons6x6[row, col].BackgroundImage = ResizeImage(symbolImage, symbolButtons6x6[row, col].Size);
                    symbolButtons6x6[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    playBoard6x6[row, col] = enteredSymbol;
                }
            }
        }
        // Resize an image to a specified size
        private Bitmap ResizeImage(Bitmap image, Size size)
        {
            // Check if the selected board size is either 9x9 or 6x6
            if (boardSizeComboBox.SelectedIndex == 0 || boardSizeComboBox.SelectedIndex == 1)
            {
                // Create a new bitmap with the specified size
                Bitmap result = new Bitmap(size.Width, size.Height);
                // Create a graphics object from the result bitmap
                using (Graphics g = Graphics.FromImage(result))
                {
                    // Set interpolation mode for better quality
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // Draw the original image onto the result bitmap with the specified size
                    g.DrawImage(image, 0, 0, size.Width, size.Height);
                }
                // Return the resized image
                return result;
            }
            // Return null if the board size is not recognized
            return null;
        }
    }
}
