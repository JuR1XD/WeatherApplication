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
            searchText.Location = new Point(356, 354);
            searchText.Name = "searchText";
            searchText.PlaceholderText = "Bitte geben sie Ihre Stadt ein";
            searchText.Size = new Size(817, 23);
            searchText.TabIndex = 2;
            // 
            // searchBtn
            // 
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
            lbCities.FormattingEnabled = true;
            lbCities.ItemHeight = 15;
            lbCities.Location = new Point(595, 333);
            lbCities.Name = "lbCities";
            lbCities.Size = new Size(368, 169);
            lbCities.TabIndex = 5;
            // 
            // confirmBtn
            // 
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
            denyBtn.Location = new Point(888, 531);
            denyBtn.Name = "denyBtn";
            denyBtn.Size = new Size(75, 23);
            denyBtn.TabIndex = 7;
            denyBtn.Text = "Abbrechen";
            denyBtn.UseVisualStyleBackColor = true;
            denyBtn.Click += denyBtn_Click;
            // 
            // placeLabel
            // 
            placeLabel.Font = new Font("Verdana", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            placeLabel.ForeColor = Color.FromArgb(210, 219, 229);
            placeLabel.Location = new Point(34, 237);
            placeLabel.Name = "placeLabel";
            placeLabel.Size = new Size(835, 371);
            placeLabel.TabIndex = 8;
            placeLabel.TextAlign = ContentAlignment.MiddleLeft;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 71, 124);
            ClientSize = new Size(1521, 689);
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
    }
}
