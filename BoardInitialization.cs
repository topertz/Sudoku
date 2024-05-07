using System;
using System.Drawing;
using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // Initialize the classic numbers Sudoku board
        private void InitializeClassicNumbersSudokuBoard()
        {
            int size = 20;
            // Check if the selected board size is 9x9
            if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                gameState = true;  // Set the game state to true
                SetSelectedDifficulty();  // Set the selected difficulty level
                GenerateSudoku(); // Generate the Sudoku puzzle
                // Create and position TextBoxes for classic numbers Sudoku
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        // Create TextBox controls for each cell
                        numberButtons[i, j] = new TextBox();
                        numberButtons[i, j].Size = new Size(size, size);
                        // Position TextBoxes based on the Sudoku grid
                        int xOffset = (j / 3) * size;
                        int yOffset = (i / 3) * size;
                        numberButtons[i, j].Location = new Point(j * size + 600 + xOffset, i * size + 60 + yOffset);
                        numberButtons[i, j].BackColor = Color.White;
                        numberButtons[i, j].Text = playBoard[i, j] == 0 ? "" : playBoard[i, j].ToString();
                        numberButtons[i, j].TextChanged += TextChanged;
                        numberButtons[i, j].MouseEnter += MouseEnter;
                        numberButtons[i, j].MouseLeave += MouseLeave;
                        // Disable TextBoxes for filled cells
                        if (numberButtons[i, j].Text != "")
                        {
                            numberButtons[i, j].Enabled = false;
                        }
                        this.Controls.Add(numberButtons[i, j]);
                    }
                }
            }
            // Check if the selected board size is 6x6
            else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                gameState = true;   // Set the game state to true
                SetSelectedDifficulty(); // Set the selected difficulty level
                GenerateSudoku(); // Generate the Sudoku puzzle
                // Create and position TextBoxes for classic numbers Sudoku
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        // Create TextBox controls for each cell
                        numberButtons6x6[i, j] = new TextBox();
                        numberButtons6x6[i, j].Size = new Size(size, size);
                        // Position TextBoxes based on the Sudoku grid
                        int xOffset = (j / 3) * size;
                        int yOffset = (i / 2) * size;
                        numberButtons6x6[i, j].Location = new Point(j * size + 600 + xOffset, i * size + 60 + yOffset);
                        numberButtons6x6[i, j].BackColor = Color.White;
                        numberButtons6x6[i, j].Text = playBoard6x6[i, j] == 0 ? "" : playBoard6x6[i, j].ToString();
                        numberButtons6x6[i, j].TextChanged += TextChanged;
                        numberButtons6x6[i, j].MouseEnter += MouseEnter;
                        numberButtons6x6[i, j].MouseLeave += MouseLeave;
                        // Disable TextBoxes for filled cells
                        if (numberButtons6x6[i, j].Text != "")
                        {
                            numberButtons6x6[i, j].Enabled = false;
                        }
                        this.Controls.Add(numberButtons6x6[i, j]);
                    }
                }
            }
        }

        // Initialize the classic symbols Sudoku board
        private void InitializeSymbolsSudokuBoard()
        {
            int size = 40;
            // Check if the drawSymbolRadioButton is checked and the selected board size is 9x9
            if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                gameState = true;  // Set the game state to true
                SetSelectedDifficulty(); // Set the selected difficulty level
                LoadSymbolImagesWhite(); // Load symbol images with white background
                GenerateSudoku(); // Generate the Sudoku puzzle
                // Create and position Buttons for classic symbols Sudoku
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        // Create Button controls for each cell
                        symbolButtons[i, j] = new Button();
                        symbolButtons[i, j].Size = new Size(size, size);
                        // Position Buttons based on the Sudoku grid
                        int xOffset = (j / 3) * size;
                        int yOffset = (i / 3) * size;
                        symbolButtons[i, j].Location = new Point(j * size + 600 + xOffset, i * size + 60 + yOffset);
                        symbolButtons[i, j].BackColor = Color.White;
                        symbolButtons[i, j].Text = playBoard[i, j] == 0 ? "" : playBoard[i, j].ToString();
                        symbolButtons[i, j].Click += Button_Click;
                        symbolButtons[i, j].MouseEnter += MouseEnter;
                        symbolButtons[i, j].MouseLeave += MouseLeave;
                        // Disable Buttons for filled cells
                        if (symbolButtons[i, j].Text != "")
                        {
                            symbolButtons[i, j].Enabled = false;
                        }
                        this.Controls.Add(symbolButtons[i, j]);
                        // Add symbol images to buttons
                        int symbolIndex = playBoard[i, j];
                        if (symbolIndex >= 1 && symbolIndex < symbolImages.Length)
                        {
                            symbolButtons[i, j].BackgroundImage = symbolImages[symbolIndex];
                            symbolButtons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            symbolButtons[i, j].Text = "";
                        }
                    }
                }
            }
            // Check if the drawSymbolRadioButton is checked and the selected board size is 6x6
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                gameState = true; // Set the game state to true
                SetSelectedDifficulty(); // Set the selected difficulty level
                LoadSymbolImagesWhite(); // Load symbol images with white background
                GenerateSudoku(); // Generate the Sudoku puzzle
                // Create and position Buttons for classic symbols Sudoku
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        // Create Button controls for each cell
                        symbolButtons6x6[i, j] = new Button();
                        symbolButtons6x6[i, j].Size = new Size(size, size);
                        // Position Buttons based on the Sudoku grid
                        int xOffset = (j / 3) * size;
                        int yOffset = (i / 2) * size;
                        symbolButtons6x6[i, j].Location = new Point(j * size + 600 + xOffset, i * size + 60 + yOffset);
                        symbolButtons6x6[i, j].BackColor = Color.White;
                        symbolButtons6x6[i, j].Text = playBoard6x6[i, j] == 0 ? "" : playBoard6x6[i, j].ToString();
                        symbolButtons6x6[i, j].Click += Button_Click;
                        symbolButtons6x6[i, j].MouseEnter += MouseEnter;
                        symbolButtons6x6[i, j].MouseLeave += MouseLeave;
                        // Disable Buttons for filled cells
                        if (symbolButtons6x6[i, j].Text != "")
                        {
                            symbolButtons6x6[i, j].Enabled = false;
                        }
                        this.Controls.Add(symbolButtons6x6[i, j]);
                        // Add symbol images to buttons
                        int symbolIndex = playBoard6x6[i, j];
                        if (symbolIndex >= 1 && symbolIndex < symbolImages6x6.Length)
                        {
                            symbolButtons6x6[i, j].BackgroundImage = symbolImages6x6[symbolIndex];
                            symbolButtons6x6[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            symbolButtons6x6[i, j].Text = "";
                        }
                    }
                }
            }
        }
        // Load images for symbols with white background colors
        private void LoadSymbolImagesWhite()
        {
            // Loading white background symbol images for 9x9 Sudoku board
            if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                try
                {
                    // Load symbol images with white background
                    symbolImages[1] = Properties.Resources.apple_white_background;
                    symbolImages[2] = Properties.Resources.car_white_background;
                    symbolImages[3] = Properties.Resources.banana_white_background;
                    symbolImages[4] = Properties.Resources.peach_white_background;
                    symbolImages[5] = Properties.Resources.mouse_white_background;
                    symbolImages[6] = Properties.Resources.mushrooms_white_background;
                    symbolImages[7] = Properties.Resources.house_white_background;
                    symbolImages[8] = Properties.Resources.pear_white_background;
                    symbolImages[9] = Properties.Resources.bag_white_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages.Length; i++)
                    {
                        if (symbolImages[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
            // Loading white background symbol images for 6x6 Sudoku board
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                try
                {
                    // Load symbol images with white background
                    symbolImages6x6[1] = Properties.Resources.apple_white_background;
                    symbolImages6x6[2] = Properties.Resources.car_white_background;
                    symbolImages6x6[3] = Properties.Resources.banana_white_background;
                    symbolImages6x6[4] = Properties.Resources.peach_white_background;
                    symbolImages6x6[5] = Properties.Resources.mouse_white_background;
                    symbolImages6x6[6] = Properties.Resources.mushrooms_white_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages6x6.Length; i++)
                    {
                        if (symbolImages6x6[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
        }
        // Load images for symbols with green background colors
        private void LoadSymbolImagesGreen()
        {
            // Loading green background symbol images for 9x9 Sudoku board
            if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                try
                {
                    // Load symbol images with green background
                    symbolImages[1] = Properties.Resources.apple_green_background;
                    symbolImages[2] = Properties.Resources.car_green_background;
                    symbolImages[3] = Properties.Resources.banana_green_background;
                    symbolImages[4] = Properties.Resources.peach_green_background;
                    symbolImages[5] = Properties.Resources.mouse_green_background;
                    symbolImages[6] = Properties.Resources.mushrooms_green_background;
                    symbolImages[7] = Properties.Resources.house_green_background;
                    symbolImages[8] = Properties.Resources.pear_green_background;
                    symbolImages[9] = Properties.Resources.bag_green_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages.Length; i++)
                    {
                        if (symbolImages[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
            // Loading green background symbol images for 6x6 Sudoku board
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                try
                {
                    // Load symbol images with green background
                    symbolImages6x6[1] = Properties.Resources.apple_green_background;
                    symbolImages6x6[2] = Properties.Resources.car_green_background;
                    symbolImages6x6[3] = Properties.Resources.banana_green_background;
                    symbolImages6x6[4] = Properties.Resources.peach_green_background;
                    symbolImages6x6[5] = Properties.Resources.mouse_green_background;
                    symbolImages6x6[6] = Properties.Resources.mushrooms_green_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages6x6.Length; i++)
                    {
                        if (symbolImages6x6[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
        }
        // Load images for symbols with red background colors
        private void LoadSymbolImagesRed()
        {
            // Loading red background symbol images for 9x9 Sudoku board
            if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                try
                {
                    // Load symbol images with red background
                    symbolImages[1] = Properties.Resources.apple_red_background;
                    symbolImages[2] = Properties.Resources.car_red_background;
                    symbolImages[3] = Properties.Resources.banana_red_background;
                    symbolImages[4] = Properties.Resources.peach_red_background;
                    symbolImages[5] = Properties.Resources.mouse_red_background;
                    symbolImages[6] = Properties.Resources.mushrooms_red_background;
                    symbolImages[7] = Properties.Resources.house_red_background;
                    symbolImages[8] = Properties.Resources.pear_red_background;
                    symbolImages[9] = Properties.Resources.bag_red_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages.Length; i++)
                    {
                        if (symbolImages[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
            // Loading red background symbol images for 6x6 Sudoku board
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                try
                {
                    // Load symbol images with red background
                    symbolImages6x6[1] = Properties.Resources.apple_red_background;
                    symbolImages6x6[2] = Properties.Resources.car_red_background;
                    symbolImages6x6[3] = Properties.Resources.banana_red_background;
                    symbolImages6x6[4] = Properties.Resources.peach_red_background;
                    symbolImages6x6[5] = Properties.Resources.mouse_red_background;
                    symbolImages6x6[6] = Properties.Resources.mushrooms_red_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages6x6.Length; i++)
                    {
                        if (symbolImages6x6[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
        }
        // Load images for symbols with orange background colors
        private void LoadSymbolImagesOrange()
        {
            // Loading orange background symbol images for 9x9 Sudoku board
            if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                try
                {
                    // Load symbol images with orange background
                    symbolImages[1] = Properties.Resources.apple_orange_background;
                    symbolImages[2] = Properties.Resources.car_orange_background;
                    symbolImages[3] = Properties.Resources.banana_orange_background;
                    symbolImages[4] = Properties.Resources.peach_orange_background;
                    symbolImages[5] = Properties.Resources.mouse_orange_background;
                    symbolImages[6] = Properties.Resources.mushrooms_orange_background;
                    symbolImages[7] = Properties.Resources.house_orange_background;
                    symbolImages[8] = Properties.Resources.pear_orange_background;
                    symbolImages[9] = Properties.Resources.bag_orange_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages.Length; i++)
                    {
                        if (symbolImages[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
            // Loading orange background symbol images for 6x6 Sudoku board
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                try
                {
                    // Load symbol images with orange background
                    symbolImages6x6[1] = Properties.Resources.apple_orange_background;
                    symbolImages6x6[2] = Properties.Resources.car_orange_background;
                    symbolImages6x6[3] = Properties.Resources.banana_orange_background;
                    symbolImages6x6[4] = Properties.Resources.peach_orange_background;
                    symbolImages6x6[5] = Properties.Resources.mouse_orange_background;
                    symbolImages6x6[6] = Properties.Resources.mushrooms_orange_background;
                    // Check if all symbol images are loaded successfully
                    for (int i = 1; i < symbolImages6x6.Length; i++)
                    {
                        if (symbolImages6x6[i] == null)
                        {
                            throw new Exception("Failed to load all images.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading images: " + ex.Message);
                }
            }
        }
    }
}
