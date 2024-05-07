using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // Get the list of empty cells for classic numbers Sudoku
        private (List<int>, List<int>) GetEmptyCells()
        {
            if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                List<int> emptyCellsRow = new List<int>();
                List<int> emptyCellsColumn = new List<int>();
                // Iterate through the Sudoku grid to find empty cells
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (playBoard[i, j] == 0 || playBoard[i, j] != sudokuBoard[i, j])
                        {
                            emptyCellsRow.Add(i);
                            emptyCellsColumn.Add(j);
                        }
                    }
                }
                return (emptyCellsRow, emptyCellsColumn);
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 0)
            {
                List<int> emptyCellsRow = new List<int>();
                List<int> emptyCellsColumn = new List<int>();
                // Iterate through the Sudoku grid to find empty cells
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (playBoard[i, j] == 0 || playBoard[i, j] != sudokuBoard[i, j])
                        {
                            emptyCellsRow.Add(i);
                            emptyCellsColumn.Add(j);
                        }
                    }
                }
                return (emptyCellsRow, emptyCellsColumn);
            }
            else if (drawNumRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                List<int> emptyCellsRow = new List<int>();
                List<int> emptyCellsColumn = new List<int>();
                // Iterate through the Sudoku grid to find empty cells
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (playBoard6x6[i, j] == 0 || playBoard6x6[i, j] != sudokuBoard6x6[i, j])
                        {
                            emptyCellsRow.Add(i);
                            emptyCellsColumn.Add(j);
                        }
                    }
                }
                return (emptyCellsRow, emptyCellsColumn);
            }
            else if (drawSymbolRadioButton && boardSizeComboBox.SelectedIndex == 1)
            {
                List<int> emptyCellsRow = new List<int>();
                List<int> emptyCellsColumn = new List<int>();
                // Iterate through the Sudoku grid to find empty cells
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (playBoard6x6[i, j] == 0 || playBoard6x6[i, j] != sudokuBoard6x6[i, j])
                        {
                            emptyCellsRow.Add(i);
                            emptyCellsColumn.Add(j);
                        }
                    }
                }
                return (emptyCellsRow, emptyCellsColumn);
            }
            List<int> emptyCellsRow2 = new List<int>();
            List<int> emptyCellsColumn2 = new List<int>();
            return (emptyCellsRow2, emptyCellsColumn2);
        }

        // Generate a classic numbers Sudoku puzzle
        private void GenerateSudoku()
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Solve the Sudoku puzzle
                SolveSudoku();
                // Clone the solved puzzle to create the initial state
                playBoard = (int[,])sudokuBoard.Clone();
                // Set the difficulty level based on user selection
                string difficulty = GetSelectedDifficulty();
                int level = 0;
                switch (difficulty)
                {
                    case "easy":
                        level = easy;
                        break;
                    case "medium":
                        level = medium;
                        break;
                    case "hard":
                        level = hard;
                        break;
                }
                // Calculate the number of cells to be cleared based on difficulty
                int count = 81 - level;
                while (count > 0)
                {
                    // Generate random row and column indices for a cell in the Sudoku grid
                    int rowIndex = random.Next(0, 9); // Generate a random row index between 0 and 8
                    int colIndex = random.Next(0, 9); // Generate a random column index between 0 and 8
                    // Clear a cell if it is not already empty
                    if (playBoard[rowIndex, colIndex] != 0)
                    {
                        playBoard[rowIndex, colIndex] = 0;
                        count--;
                    }
                }
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                // Solve the Sudoku puzzle
                SolveSudoku();
                // Clone the solved puzzle to create the initial state
                playBoard6x6 = (int[,])sudokuBoard6x6.Clone();
                // Set the difficulty level based on user selection
                string difficulty = GetSelectedDifficulty();
                int level = 0;
                switch (difficulty)
                {
                    case "easy":
                        level = easy6x6;
                        break;
                    case "medium":
                        level = medium6x6;
                        break;
                    case "hard":
                        level = hard6x6;
                        break;
                }
                // Calculate the number of cells to be cleared based on difficulty
                int count = 36 - level;
                while (count > 0)
                {
                    int rowIndex = random.Next(0, 6);
                    int colIndex = random.Next(0, 6);
                    // Clear a cell if it is not already empty
                    if (playBoard6x6[rowIndex, colIndex] != 0)
                    {
                        playBoard6x6[rowIndex, colIndex] = 0;
                        count--;
                    }
                }
            }
        }

        // Check if it's safe to place a number in a specific cell
        private bool IsSafe(int row, int col, int num)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                return !UsedInRow(row, num) && !UsedInCol(col, num) && !UsedInBox(row - row % 3, col - col % 3, num);
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                return !UsedInRow(row, num) && !UsedInCol(col, num) && !UsedInBox(row - row % 2, col - col % 3, num);
            }
            return false;
        }
        // Check if a number is used in a specific row
        private bool UsedInRow(int row, int num)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudokuBoard[row, col] == num)
                        return true;
                }
                return false;
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                for (int col = 0; col < 6; col++)
                {
                    if (sudokuBoard6x6[row, col] == num)
                        return true;
                }
            }
            return false;
        }
        // Check if a number is used in a specific column
        private bool UsedInCol(int col, int num)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                for (int row = 0; row < 9; row++)
                {
                    if (sudokuBoard[row, col] == num)
                        return true;
                }
                return false;
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                for (int row = 0; row < 6; row++)
                {
                    if (sudokuBoard6x6[row, col] == num)
                        return true;
                }
            }
            return false;
        }
        // Check if a number is used in a specific 3x3 box
        private bool UsedInBox(int boxStartRow, int boxStartCol, int num)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (sudokuBoard[row + boxStartRow, col + boxStartCol] == num)
                            return true;
                    }
                }
                return false;
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                for (int row = 0; row < 2; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (sudokuBoard6x6[row + boxStartRow, col + boxStartCol] == num)
                            return true;
                    }
                }
                return false;
            }
            return false;
        }

        // Find the first empty location in the Sudoku puzzle
        private bool FindEmptyLocation(out int row, out int col)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                for (row = 0; row < 9; row++)
                {
                    for (col = 0; col < 9; col++)
                    {
                        if (sudokuBoard[row, col] == 0)
                            return true;
                    }
                }
                row = -1;
                col = -1;
                return false;
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                for (row = 0; row < 6; row++)
                {
                    for (col = 0; col < 6; col++)
                    {
                        if (sudokuBoard6x6[row, col] == 0)
                            return true;
                    }
                }
            }
            row = -1;
            col = -1;
            return false;
        }
        // Solve the Sudoku puzzle using backtracking
        private bool SolveSudoku()
        {
            return SolveSudoku(0, 0);
        }
        // Recursive backtracking algorithm to solve the Sudoku puzzle
        private bool SolveSudoku(int row, int col)
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                // Find the next empty location in the puzzle
                if (!FindEmptyLocation(out row, out col))
                    return true;
                // Generate random order of numbers from 1 to 9
                List<int> randomNumbers = Enumerable.Range(1, 9).OrderBy(x => random.Next()).ToList();
                foreach (int num in randomNumbers)
                {
                    if (IsSafe(row, col, num))
                    {
                        // Place the number if it's safe
                        sudokuBoard[row, col] = num;
                        if (SolveSudoku(row, col))
                            return true;
                        // Backtrack if the solution is not valid
                        sudokuBoard[row, col] = 0;
                    }
                }
                return false;
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                // Find the next empty location in the puzzle
                if (!FindEmptyLocation(out row, out col))
                    return true;
                // Generate random order of numbers from 1 to 6
                List<int> randomNumbers = Enumerable.Range(1, 6).OrderBy(x => random.Next()).ToList();
                foreach (int num in randomNumbers)
                {
                    if (IsSafe(row, col, num))
                    {
                        // Place the number if it's safe
                        sudokuBoard6x6[row, col] = num;
                        if (SolveSudoku(row, col))
                            return true;
                        // Backtrack if the solution is not valid
                        sudokuBoard6x6[row, col] = 0;
                    }
                }
                return false;
            }
            return true;
        }
    }
}
