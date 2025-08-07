namespace Archaeology_CardGame
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxCenter = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayer1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayer2 = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonDrawCard = new System.Windows.Forms.Button();
            this.labelLeftover = new System.Windows.Forms.Label();
            this.buttonTrade = new System.Windows.Forms.Button();
            this.buttonExplore = new System.Windows.Forms.Button();
            this.buttonSell = new System.Windows.Forms.Button();
            this.pictureBoxMarketPlace = new System.Windows.Forms.PictureBox();
            this.labelGameStatus = new System.Windows.Forms.Label();
            this.endTurnButton = new System.Windows.Forms.Button();
            this.labelPlayer2Gold = new System.Windows.Forms.Label();
            this.labelPlayer1Gold = new System.Windows.Forms.Label();
            this.labelPlayerTurn = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarketPlace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCenter
            // 
            this.pictureBoxCenter.BackColor = System.Drawing.Color.SaddleBrown;
            this.pictureBoxCenter.Location = new System.Drawing.Point(10, 185);
            this.pictureBoxCenter.Name = "pictureBoxCenter";
            this.pictureBoxCenter.Size = new System.Drawing.Size(1221, 382);
            this.pictureBoxCenter.TabIndex = 0;
            this.pictureBoxCenter.TabStop = false;
            // 
            // pictureBoxPlayer1
            // 
            this.pictureBoxPlayer1.BackColor = System.Drawing.Color.Peru;
            this.pictureBoxPlayer1.Location = new System.Drawing.Point(10, 587);
            this.pictureBoxPlayer1.Name = "pictureBoxPlayer1";
            this.pictureBoxPlayer1.Size = new System.Drawing.Size(784, 150);
            this.pictureBoxPlayer1.TabIndex = 1;
            this.pictureBoxPlayer1.TabStop = false;
            this.pictureBoxPlayer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPlayer1_MouseClick);
            // 
            // pictureBoxPlayer2
            // 
            this.pictureBoxPlayer2.BackColor = System.Drawing.Color.Peru;
            this.pictureBoxPlayer2.Location = new System.Drawing.Point(457, 12);
            this.pictureBoxPlayer2.Name = "pictureBoxPlayer2";
            this.pictureBoxPlayer2.Size = new System.Drawing.Size(774, 146);
            this.pictureBoxPlayer2.TabIndex = 2;
            this.pictureBoxPlayer2.TabStop = false;
            this.pictureBoxPlayer2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPlayer2_MouseClick);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStart.Location = new System.Drawing.Point(1102, 497);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(114, 47);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "PLAY";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDrawCard
            // 
            this.buttonDrawCard.BackColor = System.Drawing.Color.Transparent;
            this.buttonDrawCard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDrawCard.BackgroundImage")));
            this.buttonDrawCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDrawCard.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDrawCard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDrawCard.Location = new System.Drawing.Point(850, 283);
            this.buttonDrawCard.Name = "buttonDrawCard";
            this.buttonDrawCard.Size = new System.Drawing.Size(98, 146);
            this.buttonDrawCard.TabIndex = 4;
            this.buttonDrawCard.Text = "Dig";
            this.buttonDrawCard.UseVisualStyleBackColor = false;
            this.buttonDrawCard.Click += new System.EventHandler(this.buttonDrawCard_Click);
            // 
            // labelLeftover
            // 
            this.labelLeftover.AutoSize = true;
            this.labelLeftover.BackColor = System.Drawing.Color.Gainsboro;
            this.labelLeftover.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeftover.Location = new System.Drawing.Point(847, 432);
            this.labelLeftover.Name = "labelLeftover";
            this.labelLeftover.Size = new System.Drawing.Size(66, 15);
            this.labelLeftover.TabIndex = 5;
            this.labelLeftover.Text = "Cards Left:";
            this.labelLeftover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTrade
            // 
            this.buttonTrade.BackColor = System.Drawing.Color.DarkCyan;
            this.buttonTrade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTrade.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTrade.Location = new System.Drawing.Point(966, 283);
            this.buttonTrade.Name = "buttonTrade";
            this.buttonTrade.Size = new System.Drawing.Size(114, 28);
            this.buttonTrade.TabIndex = 6;
            this.buttonTrade.Text = "Trade";
            this.buttonTrade.UseVisualStyleBackColor = false;
            this.buttonTrade.Click += new System.EventHandler(this.buttonTrade_Click);
            // 
            // buttonExplore
            // 
            this.buttonExplore.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonExplore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExplore.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExplore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonExplore.Location = new System.Drawing.Point(966, 317);
            this.buttonExplore.Name = "buttonExplore";
            this.buttonExplore.Size = new System.Drawing.Size(114, 28);
            this.buttonExplore.TabIndex = 7;
            this.buttonExplore.Text = "Explore";
            this.buttonExplore.UseVisualStyleBackColor = false;
            this.buttonExplore.Click += new System.EventHandler(this.buttonExplore_Click);
            // 
            // buttonSell
            // 
            this.buttonSell.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSell.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSell.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSell.Location = new System.Drawing.Point(966, 351);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(114, 28);
            this.buttonSell.TabIndex = 8;
            this.buttonSell.Text = "Sell";
            this.buttonSell.UseVisualStyleBackColor = false;
            this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click);
            // 
            // pictureBoxMarketPlace
            // 
            this.pictureBoxMarketPlace.BackColor = System.Drawing.Color.Chocolate;
            this.pictureBoxMarketPlace.Location = new System.Drawing.Point(19, 291);
            this.pictureBoxMarketPlace.Name = "pictureBoxMarketPlace";
            this.pictureBoxMarketPlace.Size = new System.Drawing.Size(775, 146);
            this.pictureBoxMarketPlace.TabIndex = 9;
            this.pictureBoxMarketPlace.TabStop = false;
            this.pictureBoxMarketPlace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMarketPlace_MouseClick);
            // 
            // labelGameStatus
            // 
            this.labelGameStatus.AutoSize = true;
            this.labelGameStatus.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameStatus.Location = new System.Drawing.Point(45, 518);
            this.labelGameStatus.Name = "labelGameStatus";
            this.labelGameStatus.Size = new System.Drawing.Size(125, 26);
            this.labelGameStatus.TabIndex = 13;
            this.labelGameStatus.Text = "Game Status";
            this.labelGameStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endTurnButton
            // 
            this.endTurnButton.BackColor = System.Drawing.Color.Gold;
            this.endTurnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.endTurnButton.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTurnButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.endTurnButton.Location = new System.Drawing.Point(1102, 283);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Size = new System.Drawing.Size(114, 62);
            this.endTurnButton.TabIndex = 14;
            this.endTurnButton.Text = "End Turn";
            this.endTurnButton.UseVisualStyleBackColor = false;
            this.endTurnButton.Click += new System.EventHandler(this.endTurnButton_Click);
            // 
            // labelPlayer2Gold
            // 
            this.labelPlayer2Gold.AutoSize = true;
            this.labelPlayer2Gold.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2Gold.Location = new System.Drawing.Point(25, 25);
            this.labelPlayer2Gold.Name = "labelPlayer2Gold";
            this.labelPlayer2Gold.Size = new System.Drawing.Size(152, 29);
            this.labelPlayer2Gold.TabIndex = 16;
            this.labelPlayer2Gold.Text = "Player 2 Gold:";
            // 
            // labelPlayer1Gold
            // 
            this.labelPlayer1Gold.AutoSize = true;
            this.labelPlayer1Gold.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1Gold.Location = new System.Drawing.Point(961, 697);
            this.labelPlayer1Gold.Name = "labelPlayer1Gold";
            this.labelPlayer1Gold.Size = new System.Drawing.Size(153, 29);
            this.labelPlayer1Gold.TabIndex = 17;
            this.labelPlayer1Gold.Text = "Player 1 Gold: ";
            // 
            // labelPlayerTurn
            // 
            this.labelPlayerTurn.AutoSize = true;
            this.labelPlayerTurn.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerTurn.Location = new System.Drawing.Point(1064, 216);
            this.labelPlayerTurn.Name = "labelPlayerTurn";
            this.labelPlayerTurn.Size = new System.Drawing.Size(124, 23);
            this.labelPlayerTurn.TabIndex = 18;
            this.labelPlayerTurn.Text = "Player 1\'s Turn";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonConfirm.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonConfirm.Location = new System.Drawing.Point(966, 388);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(116, 59);
            this.buttonConfirm.TabIndex = 19;
            this.buttonConfirm.Text = "Confirm Action";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(1243, 748);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelPlayerTurn);
            this.Controls.Add(this.labelPlayer1Gold);
            this.Controls.Add(this.labelPlayer2Gold);
            this.Controls.Add(this.endTurnButton);
            this.Controls.Add(this.labelGameStatus);
            this.Controls.Add(this.pictureBoxMarketPlace);
            this.Controls.Add(this.buttonSell);
            this.Controls.Add(this.buttonExplore);
            this.Controls.Add(this.buttonTrade);
            this.Controls.Add(this.labelLeftover);
            this.Controls.Add(this.buttonDrawCard);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBoxPlayer2);
            this.Controls.Add(this.pictureBoxPlayer1);
            this.Controls.Add(this.pictureBoxCenter);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarketPlace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labelPlayerTurn;
        private System.Windows.Forms.Label labelPlayer1Gold;
        private System.Windows.Forms.Label labelPlayer2Gold;
        private System.Windows.Forms.Button endTurnButton;
        private System.Windows.Forms.Label labelGameStatus;
        private System.Windows.Forms.PictureBox pictureBoxMarketPlace;
        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.Button buttonExplore;
        private System.Windows.Forms.Button buttonTrade;
        private System.Windows.Forms.Label labelLeftover;
        private System.Windows.Forms.Button buttonDrawCard;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBoxPlayer2;
        private System.Windows.Forms.PictureBox pictureBoxPlayer1;
        private System.Windows.Forms.PictureBox pictureBoxCenter;
    }
}

