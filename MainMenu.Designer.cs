
namespace FinalProject
{
    partial class MainMenu
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
            this.playersTable = new System.Windows.Forms.DataGridView();
            this.createButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // playersTable
            // 
            this.playersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersTable.Location = new System.Drawing.Point(15, 19);
            this.playersTable.Name = "playersTable";
            this.playersTable.Size = new System.Drawing.Size(545, 345);
            this.playersTable.TabIndex = 0;
            this.playersTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.playersTable_CellClick);
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.Khaki;
            this.createButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(640, 44);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(135, 32);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Create!";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            this.createButton.MouseEnter += new System.EventHandler(this.allButtons_MouseEnter);
            this.createButton.MouseLeave += new System.EventHandler(this.allButtons_MouseLeave);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Khaki;
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(640, 126);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(135, 31);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit!";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            this.editButton.MouseEnter += new System.EventHandler(this.allButtons_MouseEnter);
            this.editButton.MouseLeave += new System.EventHandler(this.allButtons_MouseLeave);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Khaki;
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(640, 197);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(135, 31);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete!";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            this.deleteButton.MouseEnter += new System.EventHandler(this.allButtons_MouseEnter);
            this.deleteButton.MouseLeave += new System.EventHandler(this.allButtons_MouseLeave);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Khaki;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(640, 271);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(135, 27);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close!";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.allButtons_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.allButtons_MouseLeave);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(815, 463);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.playersTable);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playersTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView playersTable;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
    }
}

