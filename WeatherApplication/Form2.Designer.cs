namespace WeatherApplication
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            sunPicture = new PictureBox();
            weatherLabel = new Label();
            day1Label = new Label();
            day2Label = new Label();
            day3Label = new Label();
            label3 = new Label();
            label4 = new Label();
            currentDateLbl = new Label();
            timeTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)sunPicture).BeginInit();
            SuspendLayout();
            // 
            // sunPicture
            // 
            sunPicture.Image = (Image)resources.GetObject("sunPicture.Image");
            sunPicture.InitialImage = (Image)resources.GetObject("sunPicture.InitialImage");
            sunPicture.Location = new Point(826, 0);
            sunPicture.Name = "sunPicture";
            sunPicture.Size = new Size(342, 205);
            sunPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            sunPicture.TabIndex = 3;
            sunPicture.TabStop = false;
            // 
            // weatherLabel
            // 
            weatherLabel.Font = new Font("Verdana", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            weatherLabel.ForeColor = Color.FromArgb(210, 219, 229);
            weatherLabel.Location = new Point(351, 36);
            weatherLabel.Name = "weatherLabel";
            weatherLabel.Size = new Size(408, 140);
            weatherLabel.TabIndex = 2;
            weatherLabel.Text = "Wetter";
            // 
            // day1Label
            // 
            day1Label.AutoSize = true;
            day1Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day1Label.ForeColor = Color.FromArgb(210, 219, 229);
            day1Label.Location = new Point(107, 284);
            day1Label.Name = "day1Label";
            day1Label.Size = new Size(261, 45);
            day1Label.TabIndex = 4;
            day1Label.Text = "Donnerstag";
            // 
            // day2Label
            // 
            day2Label.AutoSize = true;
            day2Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day2Label.ForeColor = Color.FromArgb(210, 219, 229);
            day2Label.Location = new Point(374, 284);
            day2Label.Name = "day2Label";
            day2Label.Size = new Size(261, 45);
            day2Label.TabIndex = 5;
            day2Label.Text = "Donnerstag";
            // 
            // day3Label
            // 
            day3Label.AutoSize = true;
            day3Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day3Label.ForeColor = Color.FromArgb(210, 219, 229);
            day3Label.Location = new Point(641, 284);
            day3Label.Name = "day3Label";
            day3Label.Size = new Size(261, 45);
            day3Label.TabIndex = 6;
            day3Label.Text = "Donnerstag";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(210, 219, 229);
            label3.Location = new Point(908, 284);
            label3.Name = "label3";
            label3.Size = new Size(261, 45);
            label3.TabIndex = 7;
            label3.Text = "Donnerstag";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(210, 219, 229);
            label4.Location = new Point(1175, 284);
            label4.Name = "label4";
            label4.Size = new Size(261, 45);
            label4.TabIndex = 8;
            label4.Text = "Donnerstag";
            // 
            // currentDateLbl
            // 
            currentDateLbl.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentDateLbl.ForeColor = Color.FromArgb(210, 219, 229);
            currentDateLbl.Location = new Point(25, 48);
            currentDateLbl.Name = "currentDateLbl";
            currentDateLbl.Size = new Size(203, 108);
            currentDateLbl.TabIndex = 14;
            // 
            // timeTimer
            // 
            timeTimer.Tick += timeTimer_Tick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 71, 124);
            ClientSize = new Size(1521, 689);
            Controls.Add(currentDateLbl);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(day3Label);
            Controls.Add(day2Label);
            Controls.Add(day1Label);
            Controls.Add(sunPicture);
            Controls.Add(weatherLabel);
            MaximizeBox = false;
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)sunPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox sunPicture;
        private Label weatherLabel;
        private Label day1Label;
        private Label day2Label;
        private Label day3Label;
        private Label label3;
        private Label label4;
        private Label currentDateLbl;
        private System.Windows.Forms.Timer timeTimer;
    }
}