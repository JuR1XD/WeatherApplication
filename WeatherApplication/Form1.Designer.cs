namespace WeatherApplication
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            weatherLabel = new Label();
            sunPicture = new PictureBox();
            searchText = new TextBox();
            searchBtn = new Button();
            exitBtn = new Button();
            lbCities = new ListBox();
            confirmBtn = new Button();
            denyBtn = new Button();
            placeLabel = new Label();
            descriptionLabel = new Label();
            tempCurrentLabel = new Label();
            newSearchBtn = new Button();
            weekViewBtn = new Button();
            currentDateLbl = new Label();
            timeTimer = new System.Windows.Forms.Timer(components);
            pastWeatherBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)sunPicture).BeginInit();
            SuspendLayout();
            // 
            // weatherLabel
            // 
            weatherLabel.Font = new Font("Verdana", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            weatherLabel.ForeColor = Color.FromArgb(210, 219, 229);
            weatherLabel.Location = new Point(351, 36);
            weatherLabel.Name = "weatherLabel";
            weatherLabel.Size = new Size(408, 140);
            weatherLabel.TabIndex = 0;
            weatherLabel.Text = "Wetter";
            // 
            // sunPicture
            // 
            sunPicture.Image = (Image)resources.GetObject("sunPicture.Image");
            sunPicture.InitialImage = (Image)resources.GetObject("sunPicture.InitialImage");
            sunPicture.Location = new Point(826, 0);
            sunPicture.Name = "sunPicture";
            sunPicture.Size = new Size(342, 205);
            sunPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            sunPicture.TabIndex = 1;
            sunPicture.TabStop = false;
            // 
            // searchText
            // 
            searchText.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchText.Location = new Point(356, 354);
            searchText.Name = "searchText";
            searchText.PlaceholderText = "Bitte geben sie Ihre Stadt ein";
            searchText.Size = new Size(817, 31);
            searchText.TabIndex = 2;
            searchText.KeyUp += searchText_KeyUp;
            // 
            // searchBtn
            // 
            searchBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBtn.Location = new Point(698, 419);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(143, 23);
            searchBtn.TabIndex = 3;
            searchBtn.Text = "Suchen";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(1425, 644);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(84, 23);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "Beenden";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // lbCities
            // 
            lbCities.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCities.FormattingEnabled = true;
            lbCities.ItemHeight = 25;
            lbCities.Location = new Point(478, 333);
            lbCities.Name = "lbCities";
            lbCities.Size = new Size(613, 154);
            lbCities.TabIndex = 5;
            // 
            // confirmBtn
            // 
            confirmBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmBtn.Location = new Point(595, 531);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(75, 23);
            confirmBtn.TabIndex = 6;
            confirmBtn.Text = "OK";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // denyBtn
            // 
            denyBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            denyBtn.Location = new Point(888, 531);
            denyBtn.Name = "denyBtn";
            denyBtn.Size = new Size(98, 23);
            denyBtn.TabIndex = 7;
            denyBtn.Text = "Abbrechen";
            denyBtn.UseVisualStyleBackColor = true;
            denyBtn.Click += denyBtn_Click;
            // 
            // placeLabel
            // 
            placeLabel.Font = new Font("Verdana", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            placeLabel.ForeColor = Color.FromArgb(210, 219, 229);
            placeLabel.Location = new Point(90, 291);
            placeLabel.Name = "placeLabel";
            placeLabel.Size = new Size(779, 263);
            placeLabel.TabIndex = 8;
            placeLabel.TextAlign = ContentAlignment.TopRight;
            placeLabel.Visible = false;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Font = new Font("Verdana", 51.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionLabel.ForeColor = Color.FromArgb(210, 219, 229);
            descriptionLabel.Location = new Point(875, 237);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(619, 217);
            descriptionLabel.TabIndex = 9;
            descriptionLabel.Visible = false;
            // 
            // tempCurrentLabel
            // 
            tempCurrentLabel.Font = new Font("Verdana", 51.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tempCurrentLabel.ForeColor = Color.FromArgb(210, 219, 229);
            tempCurrentLabel.Location = new Point(875, 454);
            tempCurrentLabel.Name = "tempCurrentLabel";
            tempCurrentLabel.Size = new Size(408, 100);
            tempCurrentLabel.TabIndex = 10;
            tempCurrentLabel.Visible = false;
            // 
            // newSearchBtn
            // 
            newSearchBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newSearchBtn.Location = new Point(1316, 644);
            newSearchBtn.Name = "newSearchBtn";
            newSearchBtn.Size = new Size(92, 23);
            newSearchBtn.TabIndex = 11;
            newSearchBtn.Text = "Anderer Ort";
            newSearchBtn.UseVisualStyleBackColor = true;
            newSearchBtn.Click += newSearchBtn_Click;
            // 
            // weekViewBtn
            // 
            weekViewBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            weekViewBtn.Location = new Point(32, 644);
            weekViewBtn.Name = "weekViewBtn";
            weekViewBtn.Size = new Size(123, 23);
            weekViewBtn.TabIndex = 12;
            weekViewBtn.Text = "Wochenansicht";
            weekViewBtn.UseVisualStyleBackColor = true;
            weekViewBtn.Click += weekViewBtn_Click;
            // 
            // currentDateLbl
            // 
            currentDateLbl.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentDateLbl.ForeColor = Color.FromArgb(210, 219, 229);
            currentDateLbl.Location = new Point(32, 36);
            currentDateLbl.Name = "currentDateLbl";
            currentDateLbl.Size = new Size(203, 108);
            currentDateLbl.TabIndex = 13;
            // 
            // timeTimer
            // 
            timeTimer.Tick += timeTimer_Tick;
            // 
            // pastWeatherBtn
            // 
            pastWeatherBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pastWeatherBtn.Location = new Point(1350, 606);
            pastWeatherBtn.Name = "pastWeatherBtn";
            pastWeatherBtn.Size = new Size(159, 23);
            pastWeatherBtn.TabIndex = 14;
            pastWeatherBtn.Text = "Vorheriges Wetter";
            pastWeatherBtn.UseVisualStyleBackColor = true;
            pastWeatherBtn.Click += pastWeatherBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 71, 124);
            ClientSize = new Size(1521, 689);
            Controls.Add(pastWeatherBtn);
            Controls.Add(currentDateLbl);
            Controls.Add(weekViewBtn);
            Controls.Add(newSearchBtn);
            Controls.Add(tempCurrentLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(placeLabel);
            Controls.Add(denyBtn);
            Controls.Add(confirmBtn);
            Controls.Add(lbCities);
            Controls.Add(exitBtn);
            Controls.Add(searchBtn);
            Controls.Add(searchText);
            Controls.Add(sunPicture);
            Controls.Add(weatherLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Wetter App";
            ((System.ComponentModel.ISupportInitialize)sunPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label weatherLabel;
        private PictureBox sunPicture;
        private TextBox searchText;
        private Button searchBtn;
        private Button exitBtn;
        private ListBox lbCities;
        private Button confirmBtn;
        private Button denyBtn;
        private Label placeLabel;
        private Label descriptionLabel;
        private Label tempCurrentLabel;
        private Button newSearchBtn;
        private Button weekViewBtn;
        private Label currentDateLbl;
        private System.Windows.Forms.Timer timeTimer;
        private Button pastWeatherBtn;
    }
}
