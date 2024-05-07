using System.Windows.Forms;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // Get the selected board type (numbers or symbols)
        public string GetSelectedBoardType()
        {
            if (drawNumRadioButton)
            {
                return "classic";
            }
            if (drawSymbolRadioButton)
            {
                return "symbols";
            }
            return "classic";
        }
        // Get the selected difficulty level
        public string GetSelectedDifficulty()
        {
            if (easyRadioButton.Checked)
            {
                return "easy";
            }
            else if (mediumRadioButton.Checked)
            {
                return "medium";
            }
            else if (hardRadioButton.Checked)
            {
                return "hard";
            }
            return "easy";
        }
        // Get the selected size type
        private string GetSelectedSizeType()
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                return "9x9";
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                return "6x6";
            }
            else
            {
                return "9x9";
            }
        }
        // Set the time limit based on the selected difficulty level
        public void SetSelectedDifficulty()
        {
            if (boardSizeComboBox.SelectedIndex == 0)
            {
                if (easyRadioButton.Checked)
                {
                    fullTimeInSeconds = 300;
                }
                if (mediumRadioButton.Checked)
                {
                    fullTimeInSeconds = 240;
                }
                if (hardRadioButton.Checked)
                {
                    fullTimeInSeconds = 180;
                }
            }
            else if (boardSizeComboBox.SelectedIndex == 1)
            {
                if (easyRadioButton.Checked)
                {
                    fullTimeInSeconds = 240;
                }
                if (mediumRadioButton.Checked)
                {
                    fullTimeInSeconds = 180;
                }
                if (hardRadioButton.Checked)
                {
                    fullTimeInSeconds = 120;
                }
            }
        }
    }
}
