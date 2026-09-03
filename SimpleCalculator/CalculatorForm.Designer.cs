namespace SimpleCalculator
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainLayout = new TableLayoutPanel();
            calculatorLayout = new TableLayoutPanel();
            lblPendingCalculation = new Label();
            txtDisplay = new TextBox();
            buttonGrid = new TableLayoutPanel();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnDivide = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMultiply = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnSubstract = new Button();
            btnClear = new Button();
            btn0 = new Button();
            btnDecimal = new Button();
            btnAdd = new Button();
            btnToggleSign = new Button();
            btnClearEntry = new Button();
            btnBackspace = new Button();
            btnEquals = new Button();
            historyLayout = new TableLayoutPanel();
            lblHistory = new Label();
            lstHistory = new ListBox();
            btnClearHistory = new Button();
            mainLayout.SuspendLayout();
            calculatorLayout.SuspendLayout();
            buttonGrid.SuspendLayout();
            historyLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            mainLayout.Controls.Add(calculatorLayout, 0, 0);
            mainLayout.Controls.Add(historyLayout, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(12, 12);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(736, 317);
            mainLayout.TabIndex = 0;
            // 
            // calculatorLayout
            // 
            calculatorLayout.ColumnCount = 1;
            calculatorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            calculatorLayout.Controls.Add(lblPendingCalculation, 0, 0);
            calculatorLayout.Controls.Add(txtDisplay, 0, 1);
            calculatorLayout.Controls.Add(buttonGrid, 0, 2);
            calculatorLayout.Dock = DockStyle.Fill;
            calculatorLayout.Location = new Point(0, 0);
            calculatorLayout.Margin = new Padding(0, 0, 10, 0);
            calculatorLayout.Name = "calculatorLayout";
            calculatorLayout.RowCount = 3;
            calculatorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            calculatorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            calculatorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            calculatorLayout.Size = new Size(475, 317);
            calculatorLayout.TabIndex = 0;
            // 
            // lblPendingCalculation
            // 
            lblPendingCalculation.Dock = DockStyle.Fill;
            lblPendingCalculation.ForeColor = SystemColors.GrayText;
            lblPendingCalculation.Location = new Point(3, 0);
            lblPendingCalculation.Name = "lblPendingCalculation";
            lblPendingCalculation.Size = new Size(469, 28);
            lblPendingCalculation.TabIndex = 0;
            lblPendingCalculation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDisplay
            // 
            txtDisplay.Dock = DockStyle.Fill;
            txtDisplay.Font = new Font("Segoe UI", 20F);
            txtDisplay.Location = new Point(3, 31);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Size = new Size(469, 61);
            txtDisplay.TabIndex = 1;
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.TextChanged += textBox1_TextChanged;
            // 
            // buttonGrid
            // 
            buttonGrid.ColumnCount = 4;
            buttonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonGrid.Controls.Add(btn7, 0, 0);
            buttonGrid.Controls.Add(btn8, 1, 0);
            buttonGrid.Controls.Add(btn9, 2, 0);
            buttonGrid.Controls.Add(btnDivide, 3, 0);
            buttonGrid.Controls.Add(btn4, 0, 1);
            buttonGrid.Controls.Add(btn5, 1, 1);
            buttonGrid.Controls.Add(btn6, 2, 1);
            buttonGrid.Controls.Add(btnMultiply, 3, 1);
            buttonGrid.Controls.Add(btn1, 0, 2);
            buttonGrid.Controls.Add(btn2, 1, 2);
            buttonGrid.Controls.Add(btn3, 2, 2);
            buttonGrid.Controls.Add(btnSubstract, 3, 2);
            buttonGrid.Controls.Add(btnClear, 0, 3);
            buttonGrid.Controls.Add(btn0, 1, 3);
            buttonGrid.Controls.Add(btnDecimal, 2, 3);
            buttonGrid.Controls.Add(btnAdd, 3, 3);
            buttonGrid.Controls.Add(btnToggleSign, 0, 4);
            buttonGrid.Controls.Add(btnClearEntry, 1, 4);
            buttonGrid.Controls.Add(btnBackspace, 2, 4);
            buttonGrid.Controls.Add(btnEquals, 3, 4);
            buttonGrid.Dock = DockStyle.Fill;
            buttonGrid.Location = new Point(0, 90);
            buttonGrid.Margin = new Padding(0);
            buttonGrid.Name = "buttonGrid";
            buttonGrid.RowCount = 5;
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonGrid.Size = new Size(475, 227);
            buttonGrid.TabIndex = 2;
            // 
            // btn7
            // 
            btn7.Dock = DockStyle.Fill;
            btn7.Location = new Point(4, 4);
            btn7.Margin = new Padding(4);
            btn7.Name = "btn7";
            btn7.Size = new Size(110, 37);
            btn7.TabIndex = 0;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += NumberButton_Click;
            // 
            // btn8
            // 
            btn8.Dock = DockStyle.Fill;
            btn8.Location = new Point(122, 4);
            btn8.Margin = new Padding(4);
            btn8.Name = "btn8";
            btn8.Size = new Size(110, 37);
            btn8.TabIndex = 1;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += NumberButton_Click;
            // 
            // btn9
            // 
            btn9.Dock = DockStyle.Fill;
            btn9.Location = new Point(240, 4);
            btn9.Margin = new Padding(4);
            btn9.Name = "btn9";
            btn9.Size = new Size(110, 37);
            btn9.TabIndex = 2;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += NumberButton_Click;
            // 
            // btnDivide
            // 
            btnDivide.Dock = DockStyle.Fill;
            btnDivide.Location = new Point(358, 4);
            btnDivide.Margin = new Padding(4);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(113, 37);
            btnDivide.TabIndex = 3;
            btnDivide.Text = "/";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += btnDivide_Click;
            // 
            // btn4
            // 
            btn4.Dock = DockStyle.Fill;
            btn4.Location = new Point(4, 49);
            btn4.Margin = new Padding(4);
            btn4.Name = "btn4";
            btn4.Size = new Size(110, 37);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += NumberButton_Click;
            // 
            // btn5
            // 
            btn5.Dock = DockStyle.Fill;
            btn5.Location = new Point(122, 49);
            btn5.Margin = new Padding(4);
            btn5.Name = "btn5";
            btn5.Size = new Size(110, 37);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += NumberButton_Click;
            // 
            // btn6
            // 
            btn6.Dock = DockStyle.Fill;
            btn6.Location = new Point(240, 49);
            btn6.Margin = new Padding(4);
            btn6.Name = "btn6";
            btn6.Size = new Size(110, 37);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += NumberButton_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Dock = DockStyle.Fill;
            btnMultiply.Location = new Point(358, 49);
            btnMultiply.Margin = new Padding(4);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(113, 37);
            btnMultiply.TabIndex = 7;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += btnMultiply_Click;
            // 
            // btn1
            // 
            btn1.Dock = DockStyle.Fill;
            btn1.Location = new Point(4, 94);
            btn1.Margin = new Padding(4);
            btn1.Name = "btn1";
            btn1.Size = new Size(110, 37);
            btn1.TabIndex = 8;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += NumberButton_Click;
            // 
            // btn2
            // 
            btn2.Dock = DockStyle.Fill;
            btn2.Location = new Point(122, 94);
            btn2.Margin = new Padding(4);
            btn2.Name = "btn2";
            btn2.Size = new Size(110, 37);
            btn2.TabIndex = 9;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += NumberButton_Click;
            // 
            // btn3
            // 
            btn3.Dock = DockStyle.Fill;
            btn3.Location = new Point(240, 94);
            btn3.Margin = new Padding(4);
            btn3.Name = "btn3";
            btn3.Size = new Size(110, 37);
            btn3.TabIndex = 10;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += NumberButton_Click;
            // 
            // btnSubstract
            // 
            btnSubstract.Dock = DockStyle.Fill;
            btnSubstract.Location = new Point(358, 94);
            btnSubstract.Margin = new Padding(4);
            btnSubstract.Name = "btnSubstract";
            btnSubstract.Size = new Size(113, 37);
            btnSubstract.TabIndex = 11;
            btnSubstract.Text = "-";
            btnSubstract.UseVisualStyleBackColor = true;
            btnSubstract.Click += btnSubtract_Click;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Fill;
            btnClear.Location = new Point(4, 139);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 37);
            btnClear.TabIndex = 12;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btn0
            // 
            btn0.Dock = DockStyle.Fill;
            btn0.Location = new Point(122, 139);
            btn0.Margin = new Padding(4);
            btn0.Name = "btn0";
            btn0.Size = new Size(110, 37);
            btn0.TabIndex = 13;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += NumberButton_Click;
            // 
            // btnDecimal
            // 
            btnDecimal.Dock = DockStyle.Fill;
            btnDecimal.Location = new Point(240, 139);
            btnDecimal.Margin = new Padding(4);
            btnDecimal.Name = "btnDecimal";
            btnDecimal.Size = new Size(110, 37);
            btnDecimal.TabIndex = 14;
            btnDecimal.Text = ".";
            btnDecimal.UseVisualStyleBackColor = true;
            btnDecimal.Click += btnDecimal_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Location = new Point(358, 139);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(113, 37);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnToggleSign
            // 
            btnToggleSign.Dock = DockStyle.Fill;
            btnToggleSign.Location = new Point(4, 184);
            btnToggleSign.Margin = new Padding(4);
            btnToggleSign.Name = "btnToggleSign";
            btnToggleSign.Size = new Size(110, 39);
            btnToggleSign.TabIndex = 16;
            btnToggleSign.Text = "+/-";
            btnToggleSign.UseVisualStyleBackColor = true;
            btnToggleSign.Click += btnToggleSign_Click;
            // 
            // btnClearEntry
            // 
            btnClearEntry.Dock = DockStyle.Fill;
            btnClearEntry.Location = new Point(122, 184);
            btnClearEntry.Margin = new Padding(4);
            btnClearEntry.Name = "btnClearEntry";
            btnClearEntry.Size = new Size(110, 39);
            btnClearEntry.TabIndex = 17;
            btnClearEntry.Text = "CE";
            btnClearEntry.UseVisualStyleBackColor = true;
            btnClearEntry.Click += btnClearEntry_Click;
            // 
            // btnBackspace
            // 
            btnBackspace.Dock = DockStyle.Fill;
            btnBackspace.Location = new Point(240, 184);
            btnBackspace.Margin = new Padding(4);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(110, 39);
            btnBackspace.TabIndex = 18;
            btnBackspace.Text = "Backspace";
            btnBackspace.UseVisualStyleBackColor = true;
            btnBackspace.Click += btnBackspace_Click;
            // 
            // btnEquals
            // 
            btnEquals.Dock = DockStyle.Fill;
            btnEquals.Location = new Point(358, 184);
            btnEquals.Margin = new Padding(4);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(113, 39);
            btnEquals.TabIndex = 19;
            btnEquals.Text = "=";
            btnEquals.UseVisualStyleBackColor = true;
            btnEquals.Click += btnEquals_Click;
            // 
            // historyLayout
            // 
            historyLayout.ColumnCount = 1;
            historyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            historyLayout.Controls.Add(lblHistory, 0, 0);
            historyLayout.Controls.Add(lstHistory, 0, 1);
            historyLayout.Controls.Add(btnClearHistory, 0, 2);
            historyLayout.Dock = DockStyle.Fill;
            historyLayout.Location = new Point(485, 0);
            historyLayout.Margin = new Padding(0);
            historyLayout.Name = "historyLayout";
            historyLayout.RowCount = 3;
            historyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            historyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            historyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            historyLayout.Size = new Size(251, 317);
            historyLayout.TabIndex = 1;
            // 
            // lblHistory
            // 
            lblHistory.Dock = DockStyle.Fill;
            lblHistory.Location = new Point(3, 0);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(245, 32);
            lblHistory.TabIndex = 0;
            lblHistory.Text = "History";
            lblHistory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lstHistory
            // 
            lstHistory.Dock = DockStyle.Fill;
            lstHistory.FormattingEnabled = true;
            lstHistory.ItemHeight = 25;
            lstHistory.Location = new Point(3, 35);
            lstHistory.Name = "lstHistory";
            lstHistory.Size = new Size(245, 235);
            lstHistory.TabIndex = 1;
            lstHistory.SelectedIndexChanged += lstHistory_SelectedIndexChanged;
            // 
            // btnClearHistory
            // 
            btnClearHistory.Dock = DockStyle.Fill;
            btnClearHistory.Location = new Point(3, 277);
            btnClearHistory.Name = "btnClearHistory";
            btnClearHistory.Size = new Size(245, 37);
            btnClearHistory.TabIndex = 2;
            btnClearHistory.Text = "Clear History";
            btnClearHistory.UseVisualStyleBackColor = true;
            btnClearHistory.Click += btnClearHistory_Click;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 341);
            Controls.Add(mainLayout);
            MinimumSize = new Size(620, 360);
            Name = "CalculatorForm";
            Padding = new Padding(12);
            Text = "Simple Calculator";
            mainLayout.ResumeLayout(false);
            calculatorLayout.ResumeLayout(false);
            calculatorLayout.PerformLayout();
            buttonGrid.ResumeLayout(false);
            historyLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel calculatorLayout;
        private Label lblPendingCalculation;
        private TextBox txtDisplay;
        private TableLayoutPanel buttonGrid;
        private Button btn0;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnAdd;
        private Button btnSubstract;
        private Button btnMultiply;
        private Button btnDivide;
        private Button btnEquals;
        private Button btnClear;
        private Button btnDecimal;
        private Button btnBackspace;
        private Button btnToggleSign;
        private Button btnClearEntry;
        private TableLayoutPanel historyLayout;
        private ListBox lstHistory;
        private Label lblHistory;
        private Button btnClearHistory;
    }
}
