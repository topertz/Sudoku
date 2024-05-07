using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Keszsegfejleszto_logikai_jatek
{
    public partial class Sudoku : Form
    {
        // PlayerData object to store information about a player's performance
        private PlayerData playerResult;
        // Empty file, different types or sizes of Sudoku board will be saved
        string filePath = "";
        // Get the base directory of the application
        static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        // Define relative file paths for storing player scores
        string filePath_classic_easy_9x9 = Path.Combine(baseDirectory, "player_scores_classic_easy_9x9.xml");
        string filePath_classic_medium_9x9 = Path.Combine(baseDirectory, "player_scores_classic_medium_9x9.xml");
        string filePath_classic_hard_9x9 = Path.Combine(baseDirectory, "player_scores_classic_hard_9x9.xml");
        string filePath_symbol_easy_9x9 = Path.Combine(baseDirectory, "player_scores_symbol_easy_9x9.xml");
        string filePath_symbol_medium_9x9 = Path.Combine(baseDirectory, "player_scores_symbol_medium_9x9.xml");
        string filePath_symbol_hard_9x9 = Path.Combine(baseDirectory, "player_scores_symbol_hard_9x9.xml");
        string filePath_classic_easy_6x6 = Path.Combine(baseDirectory, "player_scores_classic_easy_6x6.xml");
        string filePath_classic_medium_6x6 = Path.Combine(baseDirectory, "player_scores_classic_medium_6x6.xml");
        string filePath_classic_hard_6x6 = Path.Combine(baseDirectory, "player_scores_classic_hard_6x6.xml");
        string filePath_symbol_easy_6x6 = Path.Combine(baseDirectory, "player_scores_symbol_easy_6x6.xml");
        string filePath_symbol_medium_6x6 = Path.Combine(baseDirectory, "player_scores_symbol_medium_6x6.xml");
        string filePath_symbol_hard_6x6 = Path.Combine(baseDirectory, "player_scores_symbol_hard_6x6.xml");
        int lineCounter = 1;
        // Handle the click event for the "Save" button
        private void SaveButtonClick(object sender, EventArgs e)
        {
            // Enable the saveButton only if the Sudoku is solved
            if (IsSudokuSolved())
            {
                saveButton.Enabled = true;
            }
            // Check if there is data to save
            if (!gameState)
            {
                MessageBox.Show("Nothing to write yet!", "Datawrite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Check if the game has been finished before saving
            if (!finishButtonClicked)
            {
                MessageBox.Show("You can only save if the FINISH button has been clicked!", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Create a PlayerData object with the player's information
            playerResult = new PlayerData
            {
                LineCounter = lineCounter + ".",
                PlayerName = playerNameTextBox.Text,
                CorrectAnswers = correctNumbers,
                HintCounter = hintCounter,
                ElapsedTime = remainingTimeInSeconds.ToString(),
                BoardDifficulty = GetSelectedDifficulty()
            };
            // Write player scores to XML
            WritePlayerScoresToXML();
            // Write sorted player scores to separate files based on difficulty and board type
            WriteSortedPlayerScoresToDataGridView(GetSelectedDifficulty());
        }
        // Write player scores to XML file
        private void WritePlayerScoresToXML()
        {
            // Format the elapsed time
            string elapsedTime;
            if (remainingTimeInSeconds >= 1 && remainingTimeInSeconds <= 9)
            {
                elapsedTime = "00:0" + remainingTimeInSeconds;
            }
            else
            {
                int minutes = (int)(remainingTimeInSeconds / 60);
                int seconds = (int)(remainingTimeInSeconds % 60);
                elapsedTime = String.Format("{0:00}:{1:00}", minutes, seconds);
            }
            if (GetSelectedSizeType() == "9x9")
            {
                // Set file path based on difficulty and board type
                if (GetSelectedDifficulty() == "easy" && GetSelectedBoardType() == "classic")
                {
                    filePath = filePath_classic_easy_9x9;
                }
                else if (GetSelectedDifficulty() == "medium" && GetSelectedBoardType() == "classic")
                {
                    filePath = filePath_classic_medium_9x9;
                }
                else if (GetSelectedDifficulty() == "hard" && GetSelectedBoardType() == "classic")
                {
                    filePath = filePath_classic_hard_9x9;
                }
                else if (GetSelectedDifficulty() == "easy" && GetSelectedBoardType() == "symbols")
                {
                    filePath = filePath_symbol_easy_9x9;
                }
                else if (GetSelectedDifficulty() == "medium" && GetSelectedBoardType() == "symbols")
                {
                    filePath = filePath_symbol_medium_9x9;
                }
                else if (GetSelectedDifficulty() == "hard" && GetSelectedBoardType() == "symbols")
                {
                    filePath = filePath_symbol_hard_9x9;
                }
            }
            else if (GetSelectedSizeType() == "6x6")
            {
                if (GetSelectedDifficulty() == "easy" && GetSelectedBoardType() == "classic")
                {
                    filePath = filePath_classic_easy_6x6;
                }
                else if (GetSelectedDifficulty() == "medium" && GetSelectedBoardType() == "classic")
                {
                    filePath = filePath_classic_medium_6x6;
                }
                else if (GetSelectedDifficulty() == "hard" && GetSelectedBoardType() == "classic")
                {
                    filePath = filePath_classic_hard_6x6;
                }
                else if (GetSelectedDifficulty() == "easy" && GetSelectedBoardType() == "symbols")
                {
                    filePath = filePath_symbol_easy_6x6;
                }
                else if (GetSelectedDifficulty() == "medium" && GetSelectedBoardType() == "symbols")
                {
                    filePath = filePath_symbol_medium_6x6;
                }
                else if (GetSelectedDifficulty() == "hard" && GetSelectedBoardType() == "symbols")
                {
                    filePath = filePath_symbol_hard_6x6;
                }
            }
            try
            {
                XDocument xmlDoc;
                if (File.Exists(filePath))
                {
                    // Load existing XML file
                    xmlDoc = XDocument.Load(filePath);
                }
                else
                {
                    // Create new XML file if it doesn't exist
                    xmlDoc = new XDocument(new XElement("PlayerScores"));
                }
                // Create XML element for the new player score
                XElement playerScore = new XElement("PlayerScore",
                    new XElement("LineCounter", playerResult.LineCounter),
                    new XElement("PlayerName", playerResult.PlayerName),
                     new XElement("CorrectAnswers", playerResult.CorrectAnswers),
                    new XElement("HintCounter", playerResult.HintCounter),
                    new XElement("ElapsedTime", elapsedTime),
                    new XElement("BoardDifficulty", playerResult.BoardDifficulty)
                );
                // Add the new player score to the XML
                xmlDoc.Element("PlayerScores").Add(playerScore);
                // Save the XML
                xmlDoc.Save(filePath);
                MessageBox.Show("The data was written out in XML.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while writing the XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Write sorted player scores to DataGridView based on difficulty
        private void WriteSortedPlayerScoresToDataGridView(string difficulty)
        {
            // Show the DataGridView
            table.Visible = true;
            try
            {
                // Load XML file
                XDocument xmlDoc = XDocument.Load(filePath);
                IEnumerable<XElement> elements = xmlDoc.Root.Elements("PlayerScore");
                List<PlayerData> playerDataList = new List<PlayerData>();
                lineCounter = 1;
                foreach (XElement element in elements)
                {
                    string elapsedTimeString = (string)element.Element("ElapsedTime");
                    TimeSpan elapsedTime;

                    if (TimeSpan.TryParseExact(elapsedTimeString, @"mm\:ss", CultureInfo.InvariantCulture, out elapsedTime))
                    {
                        // Format the elapsed time
                        string formattedTime;
                        if (elapsedTime.TotalSeconds >= 1 && elapsedTime.TotalSeconds <= 9)
                        {
                            formattedTime = "00:0" + elapsedTime.Seconds;
                        }
                        else
                        {
                            formattedTime = String.Format("{0:00}:{1:00}", elapsedTime.Minutes, elapsedTime.Seconds);
                        }
                        PlayerData player = new PlayerData
                        {
                            LineCounter = lineCounter + ".",
                            PlayerName = (string)element.Element("PlayerName"),
                            CorrectAnswers = (int)element.Element("CorrectAnswers"),
                            HintCounter = (int)element.Element("HintCounter"),
                            ElapsedTime = formattedTime,
                            BoardDifficulty = (string)element.Element("BoardDifficulty")
                        };
                        if (player.BoardDifficulty == difficulty)
                        {
                            playerDataList.Add(player);
                            lineCounter++;
                        }
                    }
                    else
                    {
                        // If the time format is incorrect, continue to the next element
                        continue;
                    }
                }
                // Sort playerDataList based on ElapsedTime and CorrectAnswers
                playerDataList = playerDataList.OrderBy(p => p.ElapsedTime)
                    .ThenByDescending(p => p.CorrectAnswers)
                    .ToList();
                // Reorder and renumber the rows
                lineCounter = 1;
                foreach (PlayerData player in playerDataList)
                {
                    player.LineCounter = lineCounter + ".";
                    lineCounter++;
                }
                table.DataSource = playerDataList;
                // Format the DataGridView column for ElapsedTime
                DataGridViewColumn column = table.Columns["ElapsedTime"];
                if (column != null)
                {
                    column.DefaultCellStyle.Format = @"mm\:ss"; // Set format to minute:second
                }
                if (playerDataList.Count > 0)
                {
                    MessageBox.Show("The data was written in the datagridview " + GetSelectedBoardType() + "_" + difficulty + " data of all players with the shortest elapsed playing time and the highest score for each board type.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No data to display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
