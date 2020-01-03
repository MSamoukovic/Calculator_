namespace Calculator_
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.left = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.expressionTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.dotButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.equallyButton = new System.Windows.Forms.Button();
            this.changeSign = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.WhiteSmoke;
            this.left.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.left.Location = new System.Drawing.Point(87, 69);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(78, 61);
            this.left.TabIndex = 9;
            this.left.Text = "(";
            this.left.UseVisualStyleBackColor = false;
            this.left.Click += new System.EventHandler(this.braceClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.53192F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.53192F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.31611F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.8764F));
            this.tableLayoutPanel2.Controls.Add(this.expressionTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numberTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dotButton, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.zeroButton, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.threeButton, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.twoButton, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.oneButton, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.fourButton, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.fiveButton, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.sixButton, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.nineButton, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.eightButton, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.sevenButton, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.right, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.left, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.clearButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.divideButton, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.multiplyButton, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.subtractButton, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.addButton, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.equallyButton, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.changeSign, 2, 6);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(22, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.47278F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.53846F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.61539F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.48997F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.91691F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(329, 411);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // expressionTextBox
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.expressionTextBox, 4);
            this.expressionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionTextBox.Location = new System.Drawing.Point(3, 15);
            this.expressionTextBox.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.expressionTextBox.Name = "expressionTextBox";
            this.expressionTextBox.ReadOnly = true;
            this.expressionTextBox.Size = new System.Drawing.Size(323, 22);
            this.expressionTextBox.TabIndex = 18;
            this.expressionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numberTextBox
            // 
            this.numberTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.SetColumnSpan(this.numberTextBox, 4);
            this.numberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.numberTextBox.ForeColor = System.Drawing.Color.Black;
            this.numberTextBox.Location = new System.Drawing.Point(3, 36);
            this.numberTextBox.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.ReadOnly = true;
            this.numberTextBox.Size = new System.Drawing.Size(323, 33);
            this.numberTextBox.TabIndex = 17;
            this.numberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dotButton
            // 
            this.dotButton.BackColor = System.Drawing.Color.Gainsboro;
            this.dotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.dotButton.Location = new System.Drawing.Point(3, 344);
            this.dotButton.Name = "dotButton";
            this.dotButton.Padding = new System.Windows.Forms.Padding(0, 0, 0, 13);
            this.dotButton.Size = new System.Drawing.Size(78, 61);
            this.dotButton.TabIndex = 1;
            this.dotButton.Text = ".";
            this.dotButton.UseVisualStyleBackColor = false;
            this.dotButton.Click += new System.EventHandler(this.numberClick);
            // 
            // zeroButton
            // 
            this.zeroButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zeroButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.zeroButton.Location = new System.Drawing.Point(87, 344);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(78, 61);
            this.zeroButton.TabIndex = 2;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = false;
            this.zeroButton.Click += new System.EventHandler(this.numberClick);
            // 
            // threeButton
            // 
            this.threeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.threeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.threeButton.Location = new System.Drawing.Point(171, 276);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(74, 62);
            this.threeButton.TabIndex = 3;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = false;
            this.threeButton.Click += new System.EventHandler(this.numberClick);
            // 
            // twoButton
            // 
            this.twoButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.twoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.twoButton.Location = new System.Drawing.Point(87, 276);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(78, 62);
            this.twoButton.TabIndex = 14;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = false;
            this.twoButton.Click += new System.EventHandler(this.numberClick);
            // 
            // oneButton
            // 
            this.oneButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.oneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.oneButton.Location = new System.Drawing.Point(3, 276);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(78, 62);
            this.oneButton.TabIndex = 13;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = false;
            this.oneButton.Click += new System.EventHandler(this.numberClick);
            // 
            // fourButton
            // 
            this.fourButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fourButton.Location = new System.Drawing.Point(3, 206);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(78, 64);
            this.fourButton.TabIndex = 9;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = false;
            this.fourButton.Click += new System.EventHandler(this.numberClick);
            // 
            // fiveButton
            // 
            this.fiveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fiveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fiveButton.Location = new System.Drawing.Point(87, 206);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(78, 64);
            this.fiveButton.TabIndex = 11;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = false;
            this.fiveButton.Click += new System.EventHandler(this.numberClick);
            // 
            // sixButton
            // 
            this.sixButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.sixButton.Location = new System.Drawing.Point(171, 206);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(74, 64);
            this.sixButton.TabIndex = 12;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = false;
            this.sixButton.Click += new System.EventHandler(this.numberClick);
            // 
            // nineButton
            // 
            this.nineButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.nineButton.Location = new System.Drawing.Point(171, 139);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(74, 61);
            this.nineButton.TabIndex = 9;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = false;
            this.nineButton.Click += new System.EventHandler(this.numberClick);
            // 
            // eightButton
            // 
            this.eightButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.eightButton.Location = new System.Drawing.Point(87, 139);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(78, 61);
            this.eightButton.TabIndex = 10;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = false;
            this.eightButton.Click += new System.EventHandler(this.numberClick);
            // 
            // sevenButton
            // 
            this.sevenButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sevenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.sevenButton.Location = new System.Drawing.Point(3, 139);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(78, 61);
            this.sevenButton.TabIndex = 6;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = false;
            this.sevenButton.Click += new System.EventHandler(this.numberClick);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.WhiteSmoke;
            this.right.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.right.Location = new System.Drawing.Point(171, 69);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(74, 61);
            this.right.TabIndex = 10;
            this.right.Text = ")";
            this.right.UseVisualStyleBackColor = false;
            this.right.Click += new System.EventHandler(this.braceClick);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Gainsboro;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.clearButton.ForeColor = System.Drawing.Color.Black;
            this.clearButton.Location = new System.Drawing.Point(3, 69);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(78, 61);
            this.clearButton.TabIndex = 15;
            this.clearButton.Text = "C";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // divideButton
            // 
            this.divideButton.BackColor = System.Drawing.Color.Gainsboro;
            this.divideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.divideButton.Location = new System.Drawing.Point(251, 69);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(75, 59);
            this.divideButton.TabIndex = 5;
            this.divideButton.Text = "/";
            this.divideButton.UseVisualStyleBackColor = false;
            this.divideButton.Click += new System.EventHandler(this.operatorClick);
            // 
            // multiplyButton
            // 
            this.multiplyButton.BackColor = System.Drawing.Color.Gainsboro;
            this.multiplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.multiplyButton.Location = new System.Drawing.Point(251, 139);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.multiplyButton.Size = new System.Drawing.Size(75, 61);
            this.multiplyButton.TabIndex = 7;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = false;
            this.multiplyButton.Click += new System.EventHandler(this.operatorClick);
            // 
            // subtractButton
            // 
            this.subtractButton.BackColor = System.Drawing.Color.Gainsboro;
            this.subtractButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.subtractButton.Location = new System.Drawing.Point(251, 206);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(75, 63);
            this.subtractButton.TabIndex = 4;
            this.subtractButton.Text = "-";
            this.subtractButton.UseVisualStyleBackColor = false;
            this.subtractButton.Click += new System.EventHandler(this.operatorClick);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Gainsboro;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.addButton.Location = new System.Drawing.Point(251, 276);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 61);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.operatorClick);
            // 
            // equallyButton
            // 
            this.equallyButton.BackColor = System.Drawing.Color.Silver;
            this.equallyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.equallyButton.Location = new System.Drawing.Point(251, 344);
            this.equallyButton.Name = "equallyButton";
            this.equallyButton.Size = new System.Drawing.Size(75, 62);
            this.equallyButton.TabIndex = 16;
            this.equallyButton.Text = "=";
            this.equallyButton.UseVisualStyleBackColor = false;
            this.equallyButton.Click += new System.EventHandler(this.equallyButton_Click);
            // 
            // changeSign
            // 
            this.changeSign.BackColor = System.Drawing.Color.Silver;
            this.changeSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.changeSign.Location = new System.Drawing.Point(171, 344);
            this.changeSign.Name = "changeSign";
            this.changeSign.Size = new System.Drawing.Size(74, 62);
            this.changeSign.TabIndex = 19;
            this.changeSign.Text = "+/-";
            this.changeSign.UseVisualStyleBackColor = false;
            this.changeSign.Click += new System.EventHandler(this.changeSign_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 455);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button equallyButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button dotButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox expressionTextBox;
        private System.Windows.Forms.Button changeSign;
        private System.Windows.Forms.Button right;
    }
}

