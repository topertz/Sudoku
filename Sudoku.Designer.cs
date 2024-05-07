namespace Keszsegfejleszto_logikai_jatek
{
    partial class Sudoku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            playerNameTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            boardSizeComboBox = new ComboBox();
            label4 = new Label();
            easyRadioButton = new RadioButton();
            mediumRadioButton = new RadioButton();
            hardRadioButton = new RadioButton();
            label5 = new Label();
            gameRuleTextBox = new TextBox();
            startButton = new Button();
            correctAnswers = new Label();
            helpNumbersCount = new Label();
            timeLabel = new Label();
            saveButton = new Button();
            finishButton = new Button();
            prompterButton = new Button();
            displayButton = new Button();
            greenColorSign = new TextBox();
            label6 = new Label();
            redColorSign = new TextBox();
            orangeColorSign = new TextBox();
            groupBox1 = new GroupBox();
            symbolRadioButton = new RadioButton();
            classicRadioButton = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            table = new DataGridView();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // playerNameTextBox
            // 
            playerNameTextBox.Location = new Point(69, 30);
            playerNameTextBox.Margin = new Padding(3, 4, 3, 4);
            playerNameTextBox.Name = "playerNameTextBox";
            playerNameTextBox.Size = new Size(100, 27);
            playerNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 92);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Board types:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 5;
            label3.Text = "Board size:";
            // 
            // boardSizeComboBox
            // 
            boardSizeComboBox.FormattingEnabled = true;
            boardSizeComboBox.Items.AddRange(new object[] { "9x9", "6x6" });
            boardSizeComboBox.Location = new Point(98, 160);
            boardSizeComboBox.Margin = new Padding(3, 4, 3, 4);
            boardSizeComboBox.Name = "boardSizeComboBox";
            boardSizeComboBox.Size = new Size(141, 28);
            boardSizeComboBox.TabIndex = 6;
            boardSizeComboBox.SelectedIndexChanged += BoardSizeComboBox_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 196);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 7;
            label4.Text = "Difficulty levels:";
            // 
            // easyRadioButton
            // 
            easyRadioButton.AutoSize = true;
            easyRadioButton.Location = new Point(131, 197);
            easyRadioButton.Margin = new Padding(3, 4, 3, 4);
            easyRadioButton.Name = "easyRadioButton";
            easyRadioButton.Size = new Size(59, 24);
            easyRadioButton.TabIndex = 8;
            easyRadioButton.TabStop = true;
            easyRadioButton.Text = "easy";
            easyRadioButton.UseVisualStyleBackColor = true;
            // 
            // mediumRadioButton
            // 
            mediumRadioButton.AutoSize = true;
            mediumRadioButton.Location = new Point(131, 229);
            mediumRadioButton.Margin = new Padding(3, 4, 3, 4);
            mediumRadioButton.Name = "mediumRadioButton";
            mediumRadioButton.Size = new Size(85, 24);
            mediumRadioButton.TabIndex = 9;
            mediumRadioButton.TabStop = true;
            mediumRadioButton.Text = "medium";
            mediumRadioButton.UseVisualStyleBackColor = true;
            // 
            // hardRadioButton
            // 
            hardRadioButton.AutoSize = true;
            hardRadioButton.Location = new Point(131, 261);
            hardRadioButton.Margin = new Padding(3, 4, 3, 4);
            hardRadioButton.Name = "hardRadioButton";
            hardRadioButton.Size = new Size(60, 24);
            hardRadioButton.TabIndex = 10;
            hardRadioButton.TabStop = true;
            hardRadioButton.Text = "hard";
            hardRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 300);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 11;
            label5.Text = "Game rules: ";
            // 
            // gameRuleTextBox
            // 
            gameRuleTextBox.BackColor = Color.FromArgb(128, 255, 255);
            gameRuleTextBox.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            gameRuleTextBox.Location = new Point(152, 346);
            gameRuleTextBox.Margin = new Padding(3, 4, 3, 4);
            gameRuleTextBox.Multiline = true;
            gameRuleTextBox.Name = "gameRuleTextBox";
            gameRuleTextBox.Size = new Size(510, 169);
            gameRuleTextBox.TabIndex = 12;
            gameRuleTextBox.Text = "Dear player, welcome to the game called Sudoku. The essence of the game is that the rows, columns and squares cannot have the same number or symbol.";
            gameRuleTextBox.KeyPress += GameRuleTextBox_KeyPress;
            // 
            // startButton
            // 
            startButton.Location = new Point(306, 523);
            startButton.Margin = new Padding(3, 4, 3, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(101, 45);
            startButton.TabIndex = 13;
            startButton.Text = "START";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // correctAnswers
            // 
            correctAnswers.AutoSize = true;
            correctAnswers.Location = new Point(998, 20);
            correctAnswers.Name = "correctAnswers";
            correctAnswers.Size = new Size(202, 20);
            correctAnswers.TabIndex = 14;
            correctAnswers.Text = "Number of correct answers: 0";
            // 
            // helpNumbersCount
            // 
            helpNumbersCount.AutoSize = true;
            helpNumbersCount.Location = new Point(998, 40);
            helpNumbersCount.Name = "helpNumbersCount";
            helpNumbersCount.Size = new Size(141, 20);
            helpNumbersCount.TabIndex = 15;
            helpNumbersCount.Text = "Number of assists: 0";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            timeLabel.Location = new Point(824, 33);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(74, 32);
            timeLabel.TabIndex = 16;
            timeLabel.Text = "0:00";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(1200, 86);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(124, 62);
            saveButton.TabIndex = 17;
            saveButton.Text = "Save data";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButtonClick;
            // 
            // finishButton
            // 
            finishButton.Location = new Point(413, 523);
            finishButton.Margin = new Padding(3, 4, 3, 4);
            finishButton.Name = "finishButton";
            finishButton.Size = new Size(88, 45);
            finishButton.TabIndex = 18;
            finishButton.Text = "FINISH";
            finishButton.UseVisualStyleBackColor = true;
            finishButton.Click += FinishClick;
            // 
            // prompterButton
            // 
            prompterButton.Location = new Point(1200, 158);
            prompterButton.Margin = new Padding(3, 4, 3, 4);
            prompterButton.Name = "prompterButton";
            prompterButton.Size = new Size(124, 60);
            prompterButton.TabIndex = 19;
            prompterButton.Text = "Prompter";
            prompterButton.UseVisualStyleBackColor = true;
            prompterButton.Click += PrompterClick;
            // 
            // displayButton
            // 
            displayButton.Location = new Point(1200, 229);
            displayButton.Margin = new Padding(3, 4, 3, 4);
            displayButton.Name = "displayButton";
            displayButton.Size = new Size(124, 59);
            displayButton.TabIndex = 20;
            displayButton.Text = "Display";
            displayButton.UseVisualStyleBackColor = true;
            displayButton.Click += DisplayButton_Click;
            // 
            // greenColorSign
            // 
            greenColorSign.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            greenColorSign.ForeColor = Color.Green;
            greenColorSign.Location = new Point(260, 92);
            greenColorSign.Margin = new Padding(3, 4, 3, 4);
            greenColorSign.Multiline = true;
            greenColorSign.Name = "greenColorSign";
            greenColorSign.Size = new Size(359, 56);
            greenColorSign.TabIndex = 21;
            greenColorSign.Text = "green color: correct numbers or symbols";
            greenColorSign.KeyPress += GreenColorSign_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(317, 58);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 22;
            label6.Text = "Legend!";
            // 
            // redColorSign
            // 
            redColorSign.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            redColorSign.ForeColor = Color.Red;
            redColorSign.Location = new Point(260, 135);
            redColorSign.Margin = new Padding(3, 4, 3, 4);
            redColorSign.Multiline = true;
            redColorSign.Name = "redColorSign";
            redColorSign.Size = new Size(359, 44);
            redColorSign.TabIndex = 23;
            redColorSign.Text = "red color: incorrect numbers or symbols";
            redColorSign.KeyPress += RedColorSign_KeyPress;
            // 
            // orangeColorSign
            // 
            orangeColorSign.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            orangeColorSign.ForeColor = Color.FromArgb(255, 128, 0);
            orangeColorSign.Location = new Point(260, 171);
            orangeColorSign.Margin = new Padding(3, 4, 3, 4);
            orangeColorSign.Multiline = true;
            orangeColorSign.Name = "orangeColorSign";
            orangeColorSign.Size = new Size(359, 114);
            orangeColorSign.TabIndex = 24;
            orangeColorSign.Text = "orange color: use help for numbers or symbols\r\nlast 10 seconds the Prompter Button is turned off";
            orangeColorSign.KeyPress += OrangeColorSign_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(symbolRadioButton);
            groupBox1.Controls.Add(classicRadioButton);
            groupBox1.Location = new Point(99, 79);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(155, 79);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            // 
            // symbolRadioButton
            // 
            symbolRadioButton.AutoSize = true;
            symbolRadioButton.Location = new Point(6, 45);
            symbolRadioButton.Margin = new Padding(3, 4, 3, 4);
            symbolRadioButton.Name = "symbolRadioButton";
            symbolRadioButton.Size = new Size(84, 24);
            symbolRadioButton.TabIndex = 1;
            symbolRadioButton.TabStop = true;
            symbolRadioButton.Text = "symbols";
            symbolRadioButton.UseVisualStyleBackColor = true;
            symbolRadioButton.CheckedChanged += SymbolRadioButton_CheckedChanged;
            // 
            // classicRadioButton
            // 
            classicRadioButton.AutoSize = true;
            classicRadioButton.Location = new Point(6, 18);
            classicRadioButton.Margin = new Padding(3, 4, 3, 4);
            classicRadioButton.Name = "classicRadioButton";
            classicRadioButton.Size = new Size(72, 24);
            classicRadioButton.TabIndex = 0;
            classicRadioButton.TabStop = true;
            classicRadioButton.Text = "classic";
            classicRadioButton.UseVisualStyleBackColor = true;
            classicRadioButton.CheckedChanged += NumRadioButton_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(1200, 300);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(124, 60);
            button1.TabIndex = 26;
            button1.Text = "Restart game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RestartGame_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1200, 368);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(124, 64);
            button2.TabIndex = 43;
            button2.Text = "Restart board";
            button2.UseVisualStyleBackColor = true;
            button2.Click += RestartBoard_Click;
            // 
            // table
            // 
            table.BackgroundColor = Color.White;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Location = new Point(28, 654);
            table.Margin = new Padding(3, 4, 3, 4);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.RowTemplate.Height = 24;
            table.Size = new Size(735, 361);
            table.TabIndex = 45;
            table.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.Cyan;
            textBox1.Location = new Point(260, 280);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(359, 57);
            textBox1.TabIndex = 46;
            textBox1.Text = "lightblue color: highlight the actual row and column";
            textBox1.KeyPress += LightBlueSign_KeyPress;
            // 
            // Sudoku
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1782, 1055);
            Controls.Add(textBox1);
            Controls.Add(table);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(orangeColorSign);
            Controls.Add(redColorSign);
            Controls.Add(label6);
            Controls.Add(greenColorSign);
            Controls.Add(displayButton);
            Controls.Add(prompterButton);
            Controls.Add(finishButton);
            Controls.Add(saveButton);
            Controls.Add(timeLabel);
            Controls.Add(helpNumbersCount);
            Controls.Add(correctAnswers);
            Controls.Add(startButton);
            Controls.Add(gameRuleTextBox);
            Controls.Add(label5);
            Controls.Add(hardRadioButton);
            Controls.Add(mediumRadioButton);
            Controls.Add(easyRadioButton);
            Controls.Add(label4);
            Controls.Add(boardSizeComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(playerNameTextBox);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Sudoku";
            Text = "Sudoku";
            Load += Sudoku_Load;
            Paint += SudokuForm_Paint;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private Label label1;
        private TextBox playerNameTextBox;
        private Label label2;
        private Label label3;
        private ComboBox boardSizeComboBox;
        private Label label4;
        private RadioButton easyRadioButton;
        private RadioButton mediumRadioButton;
        private RadioButton hardRadioButton;
        private Label label5;
        private TextBox gameRuleTextBox;
        private Button startButton;
        private Label correctAnswers;
        private Label helpNumbersCount;
        private Label timeLabel;
        private Button saveButton;
        private Button finishButton;
        private Button prompterButton;
        private Button displayButton;
        private TextBox greenColorSign;
        private Label label6;
        private TextBox redColorSign;
        private TextBox orangeColorSign;
        private GroupBox groupBox1;
        private RadioButton symbolRadioButton;
        private RadioButton classicRadioButton;
        private Button button1;
        private Button button2;
        private DataGridView table;
        private TextBox textBox1;
    }
}

