namespace LabCSH
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
            this.pbField = new System.Windows.Forms.PictureBox();
            this.START = new System.Windows.Forms.Button();
            this.fieldX = new System.Windows.Forms.TextBox();
            this.fieldY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.playersVL = new System.Windows.Forms.ListView();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.gbPlayers = new System.Windows.Forms.GroupBox();
            this.actualPlayer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.rbSmart = new System.Windows.Forms.RadioButton();
            this.rbMachine = new System.Windows.Forms.RadioButton();
            this.addPlayer = new System.Windows.Forms.Button();
            this.charBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbField = new System.Windows.Forms.GroupBox();
            this.gbBot = new System.Windows.Forms.GroupBox();
            this.makeMove = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sleepTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).BeginInit();
            this.gbPlayers.SuspendLayout();
            this.gbAdd.SuspendLayout();
            this.gbField.SuspendLayout();
            this.gbBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbField
            // 
            resources.ApplyResources(this.pbField, "pbField");
            this.pbField.Name = "pbField";
            this.pbField.TabStop = false;
            this.pbField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // START
            // 
            resources.ApplyResources(this.START, "START");
            this.START.Name = "START";
            this.START.UseVisualStyleBackColor = true;
            this.START.Click += new System.EventHandler(this.START_Click);
            // 
            // fieldX
            // 
            resources.ApplyResources(this.fieldX, "fieldX");
            this.fieldX.Name = "fieldX";
            this.fieldX.TextChanged += new System.EventHandler(this.fieldX_TextChanged);
            this.fieldX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // fieldY
            // 
            resources.ApplyResources(this.fieldY, "fieldY");
            this.fieldY.Name = "fieldY";
            this.fieldY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // playersVL
            // 
            this.playersVL.HideSelection = false;
            resources.ApplyResources(this.playersVL, "playersVL");
            this.playersVL.Name = "playersVL";
            this.playersVL.UseCompatibleStateImageBehavior = false;
            this.playersVL.View = System.Windows.Forms.View.List;
            // 
            // nameBox
            // 
            resources.ApplyResources(this.nameBox, "nameBox");
            this.nameBox.Name = "nameBox";
            // 
            // gbPlayers
            // 
            this.gbPlayers.Controls.Add(this.actualPlayer);
            this.gbPlayers.Controls.Add(this.label6);
            this.gbPlayers.Controls.Add(this.playersVL);
            resources.ApplyResources(this.gbPlayers, "gbPlayers");
            this.gbPlayers.Name = "gbPlayers";
            this.gbPlayers.TabStop = false;
            // 
            // actualPlayer
            // 
            resources.ApplyResources(this.actualPlayer, "actualPlayer");
            this.actualPlayer.Name = "actualPlayer";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // gbAdd
            // 
            this.gbAdd.Controls.Add(this.delete);
            this.gbAdd.Controls.Add(this.rbSmart);
            this.gbAdd.Controls.Add(this.rbMachine);
            this.gbAdd.Controls.Add(this.addPlayer);
            this.gbAdd.Controls.Add(this.charBox);
            this.gbAdd.Controls.Add(this.label3);
            this.gbAdd.Controls.Add(this.label2);
            this.gbAdd.Controls.Add(this.nameBox);
            resources.ApplyResources(this.gbAdd, "gbAdd");
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.TabStop = false;
            // 
            // rbSmart
            // 
            resources.ApplyResources(this.rbSmart, "rbSmart");
            this.rbSmart.Name = "rbSmart";
            this.rbSmart.TabStop = true;
            this.rbSmart.UseVisualStyleBackColor = true;
            // 
            // rbMachine
            // 
            resources.ApplyResources(this.rbMachine, "rbMachine");
            this.rbMachine.Name = "rbMachine";
            this.rbMachine.TabStop = true;
            this.rbMachine.UseVisualStyleBackColor = true;
            // 
            // addPlayer
            // 
            resources.ApplyResources(this.addPlayer, "addPlayer");
            this.addPlayer.Name = "addPlayer";
            this.addPlayer.UseVisualStyleBackColor = true;
            this.addPlayer.Click += new System.EventHandler(this.addPlayer_Click);
            // 
            // charBox
            // 
            resources.ApplyResources(this.charBox, "charBox");
            this.charBox.Name = "charBox";
            this.charBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.charBox_KeyPress);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // gbField
            // 
            this.gbField.Controls.Add(this.fieldX);
            this.gbField.Controls.Add(this.fieldY);
            this.gbField.Controls.Add(this.label1);
            resources.ApplyResources(this.gbField, "gbField");
            this.gbField.Name = "gbField";
            this.gbField.TabStop = false;
            // 
            // gbBot
            // 
            this.gbBot.Controls.Add(this.makeMove);
            this.gbBot.Controls.Add(this.label5);
            this.gbBot.Controls.Add(this.sleepTime);
            this.gbBot.Controls.Add(this.label4);
            resources.ApplyResources(this.gbBot, "gbBot");
            this.gbBot.Name = "gbBot";
            this.gbBot.TabStop = false;
            // 
            // makeMove
            // 
            resources.ApplyResources(this.makeMove, "makeMove");
            this.makeMove.Name = "makeMove";
            this.makeMove.UseVisualStyleBackColor = true;
            this.makeMove.Click += new System.EventHandler(this.makeMove_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // sleepTime
            // 
            resources.ApplyResources(this.sleepTime, "sleepTime");
            this.sleepTime.Name = "sleepTime";
            this.sleepTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Name = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBot);
            this.Controls.Add(this.gbField);
            this.Controls.Add(this.gbAdd);
            this.Controls.Add(this.gbPlayers);
            this.Controls.Add(this.START);
            this.Controls.Add(this.pbField);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).EndInit();
            this.gbPlayers.ResumeLayout(false);
            this.gbPlayers.PerformLayout();
            this.gbAdd.ResumeLayout(false);
            this.gbAdd.PerformLayout();
            this.gbField.ResumeLayout(false);
            this.gbField.PerformLayout();
            this.gbBot.ResumeLayout(false);
            this.gbBot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbField;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.TextBox fieldX;
        private System.Windows.Forms.TextBox fieldY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView playersVL;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.GroupBox gbPlayers;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.RadioButton rbSmart;
        private System.Windows.Forms.RadioButton rbMachine;
        private System.Windows.Forms.Button addPlayer;
        private System.Windows.Forms.TextBox charBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbField;
        private System.Windows.Forms.GroupBox gbBot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sleepTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button makeMove;
        private System.Windows.Forms.Label actualPlayer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button delete;
    }
}

