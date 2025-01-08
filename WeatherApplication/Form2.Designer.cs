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
            day4Label = new Label();
            day5Label = new Label();
            currentDateLbl = new Label();
            timeTimer = new System.Windows.Forms.Timer(components);
            descriptionDay1Label = new Label();
            tempDay1Label = new Label();
            tempDay2Label = new Label();
            descriptionDay2Label = new Label();
            tempDay3Label = new Label();
            descriptionDay3Label = new Label();
            tempDay4Label = new Label();
            descriptionDay4Label = new Label();
            tempDay5Label = new Label();
            descriptionDay5Label = new Label();
            exitBtn = new Button();
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
            day1Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day1Label.ForeColor = Color.FromArgb(210, 219, 229);
            day1Label.Location = new Point(47, 284);
            day1Label.Name = "day1Label";
            day1Label.Size = new Size(261, 61);
            day1Label.TabIndex = 4;
            day1Label.Text = "Donnerstag";
            // 
            // day2Label
            // 
            day2Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day2Label.ForeColor = Color.FromArgb(210, 219, 229);
            day2Label.Location = new Point(338, 284);
            day2Label.Name = "day2Label";
            day2Label.Size = new Size(261, 61);
            day2Label.TabIndex = 5;
            day2Label.Text = "Donnerstag";
            // 
            // day3Label
            // 
            day3Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day3Label.ForeColor = Color.FromArgb(210, 219, 229);
            day3Label.Location = new Point(639, 284);
            day3Label.Name = "day3Label";
            day3Label.Size = new Size(261, 61);
            day3Label.TabIndex = 6;
            day3Label.Text = "Donnerstag";
            // 
            // day4Label
            // 
            day4Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day4Label.ForeColor = Color.FromArgb(210, 219, 229);
            day4Label.Location = new Point(935, 284);
            day4Label.Name = "day4Label";
            day4Label.Size = new Size(261, 61);
            day4Label.TabIndex = 7;
            day4Label.Text = "Donnerstag";
            // 
            // day5Label
            // 
            day5Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            day5Label.ForeColor = Color.FromArgb(210, 219, 229);
            day5Label.Location = new Point(1218, 284);
            day5Label.Name = "day5Label";
            day5Label.Size = new Size(261, 61);
            day5Label.TabIndex = 8;
            day5Label.Text = "Donnerstag";
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
            // descriptionDay1Label
            // 
            descriptionDay1Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionDay1Label.ForeColor = Color.FromArgb(210, 219, 229);
            descriptionDay1Label.Location = new Point(47, 499);
            descriptionDay1Label.Name = "descriptionDay1Label";
            descriptionDay1Label.Size = new Size(261, 161);
            descriptionDay1Label.TabIndex = 15;
            descriptionDay1Label.Text = "Leichter Regenschauer";
            // 
            // tempDay1Label
            // 
            tempDay1Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tempDay1Label.ForeColor = Color.FromArgb(210, 219, 229);
            tempDay1Label.Location = new Point(47, 373);
            tempDay1Label.Name = "tempDay1Label";
            tempDay1Label.Size = new Size(261, 100);
            tempDay1Label.TabIndex = 16;
            tempDay1Label.Text = "35  C";
            // 
            // tempDay2Label
            // 
            tempDay2Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tempDay2Label.ForeColor = Color.FromArgb(210, 219, 229);
            tempDay2Label.Location = new Point(338, 373);
            tempDay2Label.Name = "tempDay2Label";
            tempDay2Label.Size = new Size(261, 100);
            tempDay2Label.TabIndex = 18;
            tempDay2Label.Text = "35  C";
            // 
            // descriptionDay2Label
            // 
            descriptionDay2Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionDay2Label.ForeColor = Color.FromArgb(210, 219, 229);
            descriptionDay2Label.Location = new Point(338, 499);
            descriptionDay2Label.Name = "descriptionDay2Label";
            descriptionDay2Label.Size = new Size(261, 161);
            descriptionDay2Label.TabIndex = 17;
            descriptionDay2Label.Text = "Leichter Regenschauer";
            // 
            // tempDay3Label
            // 
            tempDay3Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tempDay3Label.ForeColor = Color.FromArgb(210, 219, 229);
            tempDay3Label.Location = new Point(639, 373);
            tempDay3Label.Name = "tempDay3Label";
            tempDay3Label.Size = new Size(261, 100);
            tempDay3Label.TabIndex = 20;
            tempDay3Label.Text = "35  C";
            // 
            // descriptionDay3Label
            // 
            descriptionDay3Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionDay3Label.ForeColor = Color.FromArgb(210, 219, 229);
            descriptionDay3Label.Location = new Point(639, 499);
            descriptionDay3Label.Name = "descriptionDay3Label";
            descriptionDay3Label.Size = new Size(261, 161);
            descriptionDay3Label.TabIndex = 19;
            descriptionDay3Label.Text = "Leichter Regenschauer";
            // 
            // tempDay4Label
            // 
            tempDay4Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tempDay4Label.ForeColor = Color.FromArgb(210, 219, 229);
            tempDay4Label.Location = new Point(935, 373);
            tempDay4Label.Name = "tempDay4Label";
            tempDay4Label.Size = new Size(261, 100);
            tempDay4Label.TabIndex = 22;
            tempDay4Label.Text = "35  C";
            // 
            // descriptionDay4Label
            // 
            descriptionDay4Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionDay4Label.ForeColor = Color.FromArgb(210, 219, 229);
            descriptionDay4Label.Location = new Point(935, 499);
            descriptionDay4Label.Name = "descriptionDay4Label";
            descriptionDay4Label.Size = new Size(261, 161);
            descriptionDay4Label.TabIndex = 21;
            descriptionDay4Label.Text = "Leichter Regenschauer";
            // 
            // tempDay5Label
            // 
            tempDay5Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tempDay5Label.ForeColor = Color.FromArgb(210, 219, 229);
            tempDay5Label.Location = new Point(1218, 373);
            tempDay5Label.Name = "tempDay5Label";
            tempDay5Label.Size = new Size(261, 100);
            tempDay5Label.TabIndex = 24;
            tempDay5Label.Text = "35  C";
            // 
            // descriptionDay5Label
            // 
            descriptionDay5Label.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionDay5Label.ForeColor = Color.FromArgb(210, 219, 229);
            descriptionDay5Label.Location = new Point(1218, 499);
            descriptionDay5Label.Name = "descriptionDay5Label";
            descriptionDay5Label.Size = new Size(261, 161);
            descriptionDay5Label.TabIndex = 23;
            descriptionDay5Label.Text = "Leichter Regenschauer";
            // 
            // exitBtn
            // 
            exitBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(1425, 654);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(84, 23);
            exitBtn.TabIndex = 26;
            exitBtn.Text = "Beenden";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = Color.FromArgb(30, 71, 124);
            ClientSize = new Size(1521, 689);
            Controls.Add(exitBtn);
            Controls.Add(tempDay5Label);
            Controls.Add(descriptionDay5Label);
            Controls.Add(tempDay4Label);
            Controls.Add(descriptionDay4Label);
            Controls.Add(tempDay3Label);
            Controls.Add(descriptionDay3Label);
            Controls.Add(tempDay2Label);
            Controls.Add(descriptionDay2Label);
            Controls.Add(tempDay1Label);
            Controls.Add(descriptionDay1Label);
            Controls.Add(currentDateLbl);
            Controls.Add(day5Label);
            Controls.Add(day4Label);
            Controls.Add(day3Label);
            Controls.Add(day2Label);
            Controls.Add(day1Label);
            Controls.Add(sunPicture);
            Controls.Add(weatherLabel);
            MaximizeBox = false;
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)sunPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox sunPicture;
        private Label weatherLabel;
        private Label day1Label;
        private Label day2Label;
        private Label day3Label;
        private Label day4Label;
        private Label day5Label;
        private Label currentDateLbl;
        private System.Windows.Forms.Timer timeTimer;
        private Label descriptionDay1Label;
        private Label tempDay1Label;
        private Label tempDay2Label;
        private Label descriptionDay2Label;
        private Label tempDay3Label;
        private Label descriptionDay3Label;
        private Label tempDay4Label;
        private Label descriptionDay4Label;
        private Label tempDay5Label;
        private Label descriptionDay5Label;
        private Button exitBtn;
    }
}