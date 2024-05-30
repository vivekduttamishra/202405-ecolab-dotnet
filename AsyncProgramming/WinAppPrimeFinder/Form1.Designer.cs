namespace WinAppPrimeFinder
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.findPrimesButton = new System.Windows.Forms.Button();
            this.totalPrimesTextBox = new System.Windows.Forms.TextBox();
            this.totalPrimesLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.stopButton = new System.Windows.Forms.Button();
            this.findPrimesAsyncButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min";
            // 
            // minTextBox
            // 
            this.minTextBox.Location = new System.Drawing.Point(113, 26);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(150, 31);
            this.minTextBox.TabIndex = 1;
            // 
            // maxTextBox
            // 
            this.maxTextBox.Location = new System.Drawing.Point(364, 29);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(150, 31);
            this.maxTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max";
            // 
            // findPrimesButton
            // 
            this.findPrimesButton.Location = new System.Drawing.Point(751, 32);
            this.findPrimesButton.Name = "findPrimesButton";
            this.findPrimesButton.Size = new System.Drawing.Size(143, 32);
            this.findPrimesButton.TabIndex = 4;
            this.findPrimesButton.Text = "Find Primes";
            this.findPrimesButton.UseVisualStyleBackColor = true;
            this.findPrimesButton.Click += new System.EventHandler(this.findPrimesButton_Click);
            // 
            // totalPrimesTextBox
            // 
            this.totalPrimesTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.totalPrimesTextBox.Location = new System.Drawing.Point(181, 115);
            this.totalPrimesTextBox.Name = "totalPrimesTextBox";
            this.totalPrimesTextBox.ReadOnly = true;
            this.totalPrimesTextBox.Size = new System.Drawing.Size(150, 31);
            this.totalPrimesTextBox.TabIndex = 6;
            // 
            // totalPrimesLabel
            // 
            this.totalPrimesLabel.AutoSize = true;
            this.totalPrimesLabel.Location = new System.Drawing.Point(57, 115);
            this.totalPrimesLabel.Name = "totalPrimesLabel";
            this.totalPrimesLabel.Size = new System.Drawing.Size(107, 25);
            this.totalPrimesLabel.TabIndex = 5;
            this.totalPrimesLabel.Text = "Total Primes";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(68, 180);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(703, 44);
            this.progressBar.TabIndex = 7;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(371, 111);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(143, 32);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // findPrimesAsyncButton
            // 
            this.findPrimesAsyncButton.BackColor = System.Drawing.SystemColors.Info;
            this.findPrimesAsyncButton.Location = new System.Drawing.Point(541, 32);
            this.findPrimesAsyncButton.Name = "findPrimesAsyncButton";
            this.findPrimesAsyncButton.Size = new System.Drawing.Size(194, 32);
            this.findPrimesAsyncButton.TabIndex = 9;
            this.findPrimesAsyncButton.Text = "Find Primes Async";
            this.findPrimesAsyncButton.UseVisualStyleBackColor = false;
            this.findPrimesAsyncButton.Click += new System.EventHandler(this.findPrimesAsyncButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 450);
            this.Controls.Add(this.findPrimesAsyncButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.totalPrimesTextBox);
            this.Controls.Add(this.totalPrimesLabel);
            this.Controls.Add(this.findPrimesButton);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox minTextBox;
        private TextBox maxTextBox;
        private Label label2;
        private Button findPrimesButton;
        private TextBox totalPrimesTextBox;
        private Label totalPrimesLabel;
        private ProgressBar progressBar;
        private Button stopButton;
        private Button findPrimesAsyncButton;
        private System.Windows.Forms.Timer timer;
    }
}