namespace WeatherApplication
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            currentDateLbl = new Label();
            sunPicture = new PictureBox();
            weatherLabel = new Label();
            searchText = new TextBox();
            searchBtn = new Button();
            placeAndTimeLabel = new Label();
            tempLabel = new Label();
            dayBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            monthBox = new ComboBox();
            label3 = new Label();
            yearBox = new ComboBox();
            label4 = new Label();
            hourBox = new ComboBox();
            label5 = new Label();
            minuteBox = new ComboBox();
            lbCities = new ListBox();
            confirmBtn = new Button();
            denyBtn = new Button();
            timeTimer = new System.Windows.Forms.Timer(components);
            newSearchBtn = new Button();
            exitBtn = new Button();
            descriptionLabel = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)sunPicture).BeginInit();
            SuspendLayout();
            // 
            // currentDateLbl
            // 
            currentDateLbl.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentDateLbl.ForeColor = Color.FromArgb(210, 219, 229);
            currentDateLbl.Location = new Point(32, 36);
            currentDateLbl.Name = "currentDateLbl";
            currentDateLbl.Size = new Size(203, 108);
            currentDateLbl.TabIndex = 16;
            // 
            // sunPicture
            // 
            sunPicture.Image = (Image)resources.GetObject("sunPicture.Image");
            sunPicture.InitialImage = (Image)resources.GetObject("sunPicture.InitialImage");
            sunPicture.Location = new Point(826, 0);
            sunPicture.Name = "sunPicture";
            sunPicture.Size = new Size(342, 205);
            sunPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            sunPicture.TabIndex = 15;
            sunPicture.TabStop = false;
            // 
            // weatherLabel
            // 
            weatherLabel.Font = new Font("Verdana", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            weatherLabel.ForeColor = Color.FromArgb(210, 219, 229);
            weatherLabel.Location = new Point(777, 502);
            weatherLabel.Name = "weatherLabel";
            weatherLabel.Size = new Size(59, 140);
            weatherLabel.TabIndex = 14;
            weatherLabel.Text = ":";
            // 
            // searchText
            // 
            searchText.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchText.Location = new Point(351, 396);
            searchText.Name = "searchText";
            searchText.PlaceholderText = "Bitte geben Sie den gewünschten Ort ein.";
            searchText.Size = new Size(817, 31);
            searchText.TabIndex = 17;
            searchText.KeyDown += searchText_KeyDown;
            // 
            // searchBtn
            // 
            searchBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBtn.Location = new Point(693, 461);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(143, 23);
            searchBtn.TabIndex = 18;
            searchBtn.Text = "Suchen";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // placeAndTimeLabel
            // 
            placeAndTimeLabel.Font = new Font("Verdana", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            placeAndTimeLabel.ForeColor = Color.FromArgb(210, 219, 229);
            placeAndTimeLabel.Location = new Point(351, 502);
            placeAndTimeLabel.Name = "placeAndTimeLabel";
            placeAndTimeLabel.Size = new Size(408, 140);
            placeAndTimeLabel.TabIndex = 19;
            // 
            // tempLabel
            // 
            tempLabel.Font = new Font("Verdana", 38.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tempLabel.ForeColor = Color.FromArgb(210, 219, 229);
            tempLabel.Location = new Point(873, 442);
            tempLabel.Name = "tempLabel";
            tempLabel.Size = new Size(408, 86);
            tempLabel.TabIndex = 20;
            // 
            // dayBox
            // 
            dayBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dayBox.FormattingEnabled = true;
            dayBox.Location = new Point(351, 322);
            dayBox.Name = "dayBox";
            dayBox.Size = new Size(82, 23);
            dayBox.TabIndex = 21;
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(210, 219, 229);
            label1.Location = new Point(351, 293);
            label1.Name = "label1";
            label1.Size = new Size(54, 26);
            label1.TabIndex = 22;
            label1.Text = "Tag";
            // 
            // label2
            // 
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(210, 219, 229);
            label2.Location = new Point(453, 293);
            label2.Name = "label2";
            label2.Size = new Size(66, 26);
            label2.TabIndex = 24;
            label2.Text = "Monat";
            // 
            // monthBox
            // 
            monthBox.DropDownStyle = ComboBoxStyle.DropDownList;
            monthBox.FormattingEnabled = true;
            monthBox.Location = new Point(453, 322);
            monthBox.Name = "monthBox";
            monthBox.Size = new Size(122, 23);
            monthBox.TabIndex = 23;
            // 
            // label3
            // 
            label3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(210, 219, 229);
            label3.Location = new Point(591, 293);
            label3.Name = "label3";
            label3.Size = new Size(54, 26);
            label3.TabIndex = 26;
            label3.Text = "Jahr";
            // 
            // yearBox
            // 
            yearBox.DropDownStyle = ComboBoxStyle.DropDownList;
            yearBox.FormattingEnabled = true;
            yearBox.Location = new Point(591, 322);
            yearBox.Name = "yearBox";
            yearBox.Size = new Size(98, 23);
            yearBox.TabIndex = 25;
            // 
            // label4
            // 
            label4.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(210, 219, 229);
            label4.Location = new Point(777, 293);
            label4.Name = "label4";
            label4.Size = new Size(73, 26);
            label4.TabIndex = 28;
            label4.Text = "Stunde";
            // 
            // hourBox
            // 
            hourBox.DropDownStyle = ComboBoxStyle.DropDownList;
            hourBox.FormattingEnabled = true;
            hourBox.Location = new Point(777, 322);
            hourBox.Name = "hourBox";
            hourBox.Size = new Size(82, 23);
            hourBox.TabIndex = 27;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(210, 219, 229);
            label5.Location = new Point(873, 293);
            label5.Name = "label5";
            label5.Size = new Size(69, 26);
            label5.TabIndex = 30;
            label5.Text = "Minute";
            // 
            // minuteBox
            // 
            minuteBox.DropDownStyle = ComboBoxStyle.DropDownList;
            minuteBox.FormattingEnabled = true;
            minuteBox.Location = new Point(873, 322);
            minuteBox.Name = "minuteBox";
            minuteBox.Size = new Size(82, 23);
            minuteBox.TabIndex = 29;
            // 
            // lbCities
            // 
            lbCities.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCities.FormattingEnabled = true;
            lbCities.ItemHeight = 25;
            lbCities.Location = new Point(478, 333);
            lbCities.Name = "lbCities";
            lbCities.Size = new Size(613, 154);
            lbCities.TabIndex = 33;
            // 
            // confirmBtn
            // 
            confirmBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmBtn.Location = new Point(595, 531);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(75, 23);
            confirmBtn.TabIndex = 34;
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
            denyBtn.TabIndex = 35;
            denyBtn.Text = "Abbrechen";
            denyBtn.UseVisualStyleBackColor = true;
            denyBtn.Click += denyBtn_Click;
            // 
            // timeTimer
            // 
            timeTimer.Tick += timeTimer_Tick;
            // 
            // newSearchBtn
            // 
            newSearchBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newSearchBtn.Location = new Point(1316, 654);
            newSearchBtn.Name = "newSearchBtn";
            newSearchBtn.Size = new Size(92, 23);
            newSearchBtn.TabIndex = 37;
            newSearchBtn.Text = "Anderer Ort";
            newSearchBtn.UseVisualStyleBackColor = true;
            newSearchBtn.Click += newSearchBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(1425, 654);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(84, 23);
            exitBtn.TabIndex = 36;
            exitBtn.Text = "Beenden";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Font = new Font("Verdana", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionLabel.ForeColor = Color.FromArgb(210, 219, 229);
            descriptionLabel.Location = new Point(888, 531);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(408, 149);
            descriptionLabel.TabIndex = 38;
            // 
            // label6
            // 
            label6.Font = new Font("Verdana", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(210, 219, 229);
            label6.Location = new Point(351, 36);
            label6.Name = "label6";
            label6.Size = new Size(408, 140);
            label6.TabIndex = 39;
            label6.Text = "Wetter";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 71, 124);
            ClientSize = new Size(1521, 689);
            Controls.Add(label6);
            Controls.Add(descriptionLabel);
            Controls.Add(newSearchBtn);
            Controls.Add(exitBtn);
            Controls.Add(denyBtn);
            Controls.Add(confirmBtn);
            Controls.Add(lbCities);
            Controls.Add(label5);
            Controls.Add(minuteBox);
            Controls.Add(label4);
            Controls.Add(hourBox);
            Controls.Add(label3);
            Controls.Add(yearBox);
            Controls.Add(label2);
            Controls.Add(monthBox);
            Controls.Add(label1);
            Controls.Add(dayBox);
            Controls.Add(tempLabel);
            Controls.Add(placeAndTimeLabel);
            Controls.Add(searchBtn);
            Controls.Add(searchText);
            Controls.Add(currentDateLbl);
            Controls.Add(sunPicture);
            Controls.Add(weatherLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)sunPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label currentDateLbl;
        private PictureBox sunPicture;
        private Label weatherLabel;
        private TextBox searchText;
        private Button searchBtn;
        private Label placeAndTimeLabel;
        private Label tempLabel;
        private ComboBox dayBox;
        private Label label1;
        private Label label2;
        private ComboBox monthBox;
        private Label label3;
        private ComboBox yearBox;
        private Label label4;
        private ComboBox hourBox;
        private Label label5;
        private ComboBox minuteBox;
        private ListBox lbCities;
        private Button confirmBtn;
        private Button denyBtn;
        private System.Windows.Forms.Timer timeTimer;
        private Button newSearchBtn;
        private Button exitBtn;
        private Label descriptionLabel;
        private Label label6;
    }
}