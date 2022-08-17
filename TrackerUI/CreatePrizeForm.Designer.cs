namespace TrackerUI
{
    partial class CreatePrizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePrizeForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.placeNumberLabel = new System.Windows.Forms.Label();
            this.placeNumberValue = new System.Windows.Forms.TextBox();
            this.placeNameValue = new System.Windows.Forms.TextBox();
            this.placeNameLabel = new System.Windows.Forms.Label();
            this.prizeAmountValue = new System.Windows.Forms.TextBox();
            this.prizeAmountLabel = new System.Windows.Forms.Label();
            this.prizePercentageValue = new System.Windows.Forms.TextBox();
            this.prizePercentageLabel = new System.Windows.Forms.Label();
            this.orLabel = new System.Windows.Forms.Label();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.headerLabel.Location = new System.Drawing.Point(24, 33);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(267, 62);
            this.headerLabel.TabIndex = 12;
            this.headerLabel.Text = "Create Prize";
            // 
            // placeNumberLabel
            // 
            this.placeNumberLabel.AutoSize = true;
            this.placeNumberLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.placeNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.placeNumberLabel.Location = new System.Drawing.Point(24, 120);
            this.placeNumberLabel.Name = "placeNumberLabel";
            this.placeNumberLabel.Size = new System.Drawing.Size(223, 45);
            this.placeNumberLabel.TabIndex = 13;
            this.placeNumberLabel.Text = "Place Number";
            // 
            // placeNumberValue
            // 
            this.placeNumberValue.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.placeNumberValue.Location = new System.Drawing.Point(294, 123);
            this.placeNumberValue.Name = "placeNumberValue";
            this.placeNumberValue.Size = new System.Drawing.Size(211, 43);
            this.placeNumberValue.TabIndex = 14;
            // 
            // placeNameValue
            // 
            this.placeNameValue.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.placeNameValue.Location = new System.Drawing.Point(294, 188);
            this.placeNameValue.Name = "placeNameValue";
            this.placeNameValue.Size = new System.Drawing.Size(211, 43);
            this.placeNameValue.TabIndex = 16;
            // 
            // placeNameLabel
            // 
            this.placeNameLabel.AutoSize = true;
            this.placeNameLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.placeNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.placeNameLabel.Location = new System.Drawing.Point(24, 185);
            this.placeNameLabel.Name = "placeNameLabel";
            this.placeNameLabel.Size = new System.Drawing.Size(191, 45);
            this.placeNameLabel.TabIndex = 15;
            this.placeNameLabel.Text = "Place Name";
            // 
            // prizeAmountValue
            // 
            this.prizeAmountValue.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizeAmountValue.Location = new System.Drawing.Point(294, 253);
            this.prizeAmountValue.Name = "prizeAmountValue";
            this.prizeAmountValue.Size = new System.Drawing.Size(211, 43);
            this.prizeAmountValue.TabIndex = 18;
            this.prizeAmountValue.Text = "0";
            this.prizeAmountValue.TextChanged += new System.EventHandler(this.prizeAmountValue_TextChanged);
            // 
            // prizeAmountLabel
            // 
            this.prizeAmountLabel.AutoSize = true;
            this.prizeAmountLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizeAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.prizeAmountLabel.Location = new System.Drawing.Point(24, 250);
            this.prizeAmountLabel.Name = "prizeAmountLabel";
            this.prizeAmountLabel.Size = new System.Drawing.Size(215, 45);
            this.prizeAmountLabel.TabIndex = 17;
            this.prizeAmountLabel.Text = "Prize Amount";
            // 
            // prizePercentageValue
            // 
            this.prizePercentageValue.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizePercentageValue.Location = new System.Drawing.Point(294, 382);
            this.prizePercentageValue.Name = "prizePercentageValue";
            this.prizePercentageValue.Size = new System.Drawing.Size(211, 43);
            this.prizePercentageValue.TabIndex = 20;
            this.prizePercentageValue.Text = "0";
            // 
            // prizePercentageLabel
            // 
            this.prizePercentageLabel.AutoSize = true;
            this.prizePercentageLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizePercentageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.prizePercentageLabel.Location = new System.Drawing.Point(24, 382);
            this.prizePercentageLabel.Name = "prizePercentageLabel";
            this.prizePercentageLabel.Size = new System.Drawing.Size(264, 45);
            this.prizePercentageLabel.TabIndex = 19;
            this.prizePercentageLabel.Text = "Place Percentage";
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.orLabel.Location = new System.Drawing.Point(240, 317);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(76, 45);
            this.orLabel.TabIndex = 21;
            this.orLabel.Text = "-or-";
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPrizeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createPrizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.createPrizeButton.Location = new System.Drawing.Point(161, 467);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(262, 74);
            this.createPrizeButton.TabIndex = 26;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = true;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(576, 583);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.prizePercentageValue);
            this.Controls.Add(this.prizePercentageLabel);
            this.Controls.Add(this.prizeAmountValue);
            this.Controls.Add(this.prizeAmountLabel);
            this.Controls.Add(this.placeNameValue);
            this.Controls.Add(this.placeNameLabel);
            this.Controls.Add(this.placeNumberValue);
            this.Controls.Add(this.placeNumberLabel);
            this.Controls.Add(this.headerLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatePrizeForm";
            this.Text = "Create Prize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private Label placeNumberLabel;
        private TextBox placeNumberValue;
        private TextBox placeNameValue;
        private Label placeNameLabel;
        private TextBox prizeAmountValue;
        private Label prizeAmountLabel;
        private TextBox prizePercentageValue;
        private Label prizePercentageLabel;
        private Label orLabel;
        private Button createPrizeButton;
    }
}