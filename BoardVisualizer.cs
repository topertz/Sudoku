using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        int boardSize = 3;
        // Handle the event when the selected index of the board size combobox changes
        private void BoardSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the board size based on the selected index
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                boardSize = 3;
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                boardSize = 2;
            }
            this.Invalidate(); // Invalidate repainting
        }

        // Handle the CheckedChanged event for the draw number RadioButton
        private void NumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Set the drawNumRadioButton flag based on whether the classicRadioButton is checked
            drawNumRadioButton = classicRadioButton.Checked;
            Invalidate();
        }
        // Handle the CheckedChanged event for the draw symbol RadioButton
        private void SymbolRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            drawSymbolRadioButton = symbolRadioButton.Checked;
            Invalidate(); // Invalidate repainting
        }

        // Paint event for custom drawing
        private void SudokuForm_Paint(object sender, PaintEventArgs e)
        {
            // Calculate modified board size
            int modifiedBoardSize = boardSize;
            if (boardSize == 2)
            {
                modifiedBoardSize = boardSize + 1;
            }
            // Draw rectangles based on whether classic numbers or symbols are being used
            if (drawNumRadioButton)
            {
                // Draw rectangles for classic numbers Sudoku
                using (Pen pen1 = new Pen(Color.Black, 10))
                {
                    // Draw rectangles for each block
                    for (int i = 0; i < modifiedBoardSize; i++)
                    {
                        for (int j = 0; j < boardSize; j++)
                        {
                            int startX = 600 + j * modifiedBoardSize * 20 + j * 20;
                            int startY = 60 + i * boardSize * 20 + i * 20;
                            e.Graphics.DrawRectangle(pen1, startX, startY, modifiedBoardSize * 20, boardSize * 20);
                        }
                    }
                }
            }
            if (drawSymbolRadioButton)
            {
                // Draw rectangles for symbol Sudoku
                using (Pen pen2 = new Pen(Color.Black, 5))
                {
                    // Draw rectangles for each block
                    for (int i = 0; i < modifiedBoardSize; i++)
                    {
                        for (int j = 0; j < boardSize; j++)
                        {
                            int startX = 600 + j * modifiedBoardSize * 40 + j * 40;
                            int startY = 60 + i * boardSize * 40 + i * 40;
                            e.Graphics.DrawRectangle(pen2, startX, startY, modifiedBoardSize * 40, boardSize * 40);
                        }
                    }
                }
            }
        }
        // Handle the MouseEnter event for highlighting related cells
        private new void MouseEnter(object sender, EventArgs e)
        {
            // Array of colors to ignore
            Color[] ignoredColors = { Color.LightGreen, Color.Orange, Color.Red };
            if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                // Handle MouseEnter event for classic numbers Sudoku with 9x9 board
                TextBox text = (TextBox)sender;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (numberButtons[i, j] == text)
                        {
                            // Highlight related cells
                            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons[i, rowIndex].BackColor))
                                {
                                    numberButtons[i, rowIndex].BackColor = Color.LightBlue;
                                }
                            }
                            for (int colIndex = 0; colIndex < 9; colIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons[colIndex, j].BackColor))
                                {
                                    numberButtons[colIndex, j].BackColor = Color.LightBlue;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 3) * 3;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 3; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(numberButtons[rowIndex, colIndex].BackColor))
                                    {
                                        numberButtons[rowIndex, colIndex].BackColor = Color.LightBlue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                TextBox text = (TextBox)sender;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (numberButtons6x6[i, j] == text)
                        {
                            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons6x6[i, rowIndex].BackColor))
                                {
                                    numberButtons6x6[i, rowIndex].BackColor = Color.LightBlue;
                                }
                            }
                            for (int colIndex = 0; colIndex < 6; colIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons6x6[colIndex, j].BackColor))
                                {
                                    numberButtons6x6[colIndex, j].BackColor = Color.LightBlue;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 2) * 2;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 2; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(numberButtons6x6[rowIndex, colIndex].BackColor))
                                    {
                                        numberButtons6x6[rowIndex, colIndex].BackColor = Color.LightBlue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                Button button = (Button)sender;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (symbolButtons[i, j] == button)
                        {
                            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons[i, rowIndex].BackColor))
                                {
                                    symbolButtons[i, rowIndex].BackColor = Color.LightBlue;
                                }
                            }
                            for (int colIndex = 0; colIndex < 9; colIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons[colIndex, j].BackColor))
                                {
                                    symbolButtons[colIndex, j].BackColor = Color.LightBlue;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 3) * 3;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 3; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(symbolButtons[rowIndex, colIndex].BackColor))
                                    {
                                        symbolButtons[rowIndex, colIndex].BackColor = Color.LightBlue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                Button button = (Button)sender;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (symbolButtons6x6[i, j] == button)
                        {
                            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons6x6[i, rowIndex].BackColor))
                                {
                                    symbolButtons6x6[i, rowIndex].BackColor = Color.LightBlue;
                                }
                            }
                            for (int colIndex = 0; colIndex < 6; colIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons6x6[colIndex, j].BackColor))
                                {
                                    symbolButtons6x6[colIndex, j].BackColor = Color.LightBlue;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 2) * 2;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 2; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(symbolButtons6x6[rowIndex, colIndex].BackColor))
                                    {
                                        symbolButtons6x6[rowIndex, colIndex].BackColor = Color.LightBlue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        // Handle the MouseLeave event for resetting cell colors
        private new void MouseLeave(object sender, EventArgs e)
        {
            // Array of colors to ignore
            Color[] ignoredColors = { Color.LightGreen, Color.Orange, Color.Red };
            if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                // Handle MouseLeave event for classic numbers Sudoku with 9x9 board
                TextBox text = (TextBox)sender;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (numberButtons[i, j] == text)
                        {
                            // Reset cell colors
                            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons[i, rowIndex].BackColor))
                                {
                                    numberButtons[i, rowIndex].BackColor = Color.White;
                                }
                            }
                            for (int colIndex = 0; colIndex < 9; colIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons[colIndex, j].BackColor))
                                {
                                    numberButtons[colIndex, j].BackColor = Color.White;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 3) * 3;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 3; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(numberButtons[rowIndex, colIndex].BackColor))
                                    {
                                        numberButtons[rowIndex, colIndex].BackColor = Color.White;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                TextBox text = (TextBox)sender;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (numberButtons6x6[i, j] == text)
                        {
                            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons6x6[i, rowIndex].BackColor))
                                {
                                    numberButtons6x6[i, rowIndex].BackColor = Color.White;
                                }
                            }
                            for (int colIndex = 0; colIndex < 6; colIndex++)
                            {
                                if (!ignoredColors.Contains(numberButtons6x6[colIndex, j].BackColor))
                                {
                                    numberButtons6x6[colIndex, j].BackColor = Color.White;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 2) * 2;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 2; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(numberButtons6x6[rowIndex, colIndex].BackColor))
                                    {
                                        numberButtons6x6[rowIndex, colIndex].BackColor = Color.White;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                Button button = (Button)sender;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (symbolButtons[i, j] == button)
                        {
                            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons[i, rowIndex].BackColor))
                                {
                                    symbolButtons[i, rowIndex].BackColor = Color.White;
                                }
                            }
                            for (int colIndex = 0; colIndex < 9; colIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons[colIndex, j].BackColor))
                                {
                                    symbolButtons[colIndex, j].BackColor = Color.White;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 3) * 3;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 3; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(symbolButtons[rowIndex, colIndex].BackColor))
                                    {
                                        symbolButtons[rowIndex, colIndex].BackColor = Color.White;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                Button button = (Button)sender;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (symbolButtons6x6[i, j] == button)
                        {
                            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons6x6[i, rowIndex].BackColor))
                                {
                                    symbolButtons6x6[i, rowIndex].BackColor = Color.White;
                                }
                            }
                            for (int colIndex = 0; colIndex < 6; colIndex++)
                            {
                                if (!ignoredColors.Contains(symbolButtons6x6[colIndex, j].BackColor))
                                {
                                    symbolButtons6x6[colIndex, j].BackColor = Color.White;
                                }
                            }
                            // Highlight the current 3x3 square
                            int startRow = (i / 2) * 2;
                            int startCol = (j / 3) * 3;
                            for (int rowIndex = startRow; rowIndex < startRow + 2; rowIndex++)
                            {
                                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                                {
                                    if (!ignoredColors.Contains(symbolButtons6x6[rowIndex, colIndex].BackColor))
                                    {
                                        symbolButtons6x6[rowIndex, colIndex].BackColor = Color.White;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
