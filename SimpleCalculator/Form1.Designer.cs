namespace SimpleCalculator
{
    partial class Form1
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
            txtDisplay = new TextBox();
            btn0 = new Button();
            btn1 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnAdd = new Button();
            btnSubstract = new Button();
            btnMultiply = new Button();
            btnDivide = new Button();
            btnEquals = new Button();
            btnClear = new Button();
            btn2 = new Button();
            SuspendLayout();
            // 
            // txtDisplay
            // 
            txtDisplay.Font = new Font("Segoe UI", 20F);
            txtDisplay.Location = new Point(2, 3);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Size = new Size(150, 61);
            txtDisplay.TabIndex = 0;
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.TextChanged += textBox1_TextChanged;
            // 
            // btn0
            // 
            btn0.Location = new Point(120, 188);
            btn0.Name = "btn0";
            btn0.Size = new Size(112, 34);
            btn0.TabIndex = 1;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += NumberButton_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(2, 148);
            btn1.Name = "btn1";
            btn1.Size = new Size(112, 34);
            btn1.TabIndex = 2;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += NumberButton_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(238, 148);
            btn3.Name = "btn3";
            btn3.Size = new Size(112, 34);
            btn3.TabIndex = 3;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += NumberButton_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(2, 108);
            btn4.Name = "btn4";
            btn4.Size = new Size(112, 34);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += NumberButton_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(120, 108);
            btn5.Name = "btn5";
            btn5.Size = new Size(112, 34);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += NumberButton_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(238, 108);
            btn6.Name = "btn6";
            btn6.Size = new Size(112, 34);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += NumberButton_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(2, 68);
            btn7.Name = "btn7";
            btn7.Size = new Size(112, 34);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += NumberButton_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(120, 68);
            btn8.Name = "btn8";
            btn8.Size = new Size(112, 34);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += NumberButton_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(238, 68);
            btn9.Name = "btn9";
            btn9.Size = new Size(112, 34);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += NumberButton_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(356, 188);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSubstract
            // 
            btnSubstract.Location = new Point(356, 148);
            btnSubstract.Name = "btnSubstract";
            btnSubstract.Size = new Size(112, 34);
            btnSubstract.TabIndex = 11;
            btnSubstract.Text = "-";
            btnSubstract.UseVisualStyleBackColor = true;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(356, 108);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(112, 34);
            btnMultiply.TabIndex = 12;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            // 
            // btnDivide
            // 
            btnDivide.Location = new Point(356, 68);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(112, 34);
            btnDivide.TabIndex = 13;
            btnDivide.Text = "/";
            btnDivide.UseVisualStyleBackColor = true;
            // 
            // btnEquals
            // 
            btnEquals.Location = new Point(238, 188);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(112, 34);
            btnEquals.TabIndex = 14;
            btnEquals.Text = "=";
            btnEquals.UseVisualStyleBackColor = true;
            btnEquals.Click += btnEquals_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(2, 188);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 15;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.Location = new Point(120, 148);
            btn2.Name = "btn2";
            btn2.Size = new Size(112, 34);
            btn2.TabIndex = 16;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += NumberButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn2);
            Controls.Add(btnClear);
            Controls.Add(btnEquals);
            Controls.Add(btnDivide);
            Controls.Add(btnMultiply);
            Controls.Add(btnSubstract);
            Controls.Add(btnAdd);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn1);
            Controls.Add(btn0);
            Controls.Add(txtDisplay);
            Name = "Form1";
            Text = "Simple Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDisplay;
        private Button btn0;
        private Button btn1;
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
        private Button btn2;
    }
}
