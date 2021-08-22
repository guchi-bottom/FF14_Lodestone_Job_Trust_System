
namespace FF14_Lodestone_Job_Trust_System
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
            this.Acquisition = new System.Windows.Forms.Button();
            this.html_status = new System.Windows.Forms.Label();
            this.Tank = new System.Windows.Forms.Panel();
            this.Healer = new System.Windows.Forms.Panel();
            this.Melee = new System.Windows.Forms.Panel();
            this.Physical = new System.Windows.Forms.Panel();
            this.Magical = new System.Windows.Forms.Panel();
            this.Crafter = new System.Windows.Forms.Panel();
            this.Gatherer = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.L_Tank = new System.Windows.Forms.Label();
            this.L_Healer = new System.Windows.Forms.Label();
            this.L_Melee = new System.Windows.Forms.Label();
            this.L_Physical = new System.Windows.Forms.Label();
            this.L_Magical = new System.Windows.Forms.Label();
            this.L_Crafter = new System.Windows.Forms.Label();
            this.L_Gatherer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Acquisition
            // 
            this.Acquisition.Location = new System.Drawing.Point(12, 567);
            this.Acquisition.Name = "Acquisition";
            this.Acquisition.Size = new System.Drawing.Size(75, 23);
            this.Acquisition.TabIndex = 0;
            this.Acquisition.Text = "Get";
            this.Acquisition.UseVisualStyleBackColor = true;
            this.Acquisition.Click += new System.EventHandler(this.button1_Click);
            // 
            // html_status
            // 
            this.html_status.AutoSize = true;
            this.html_status.Location = new System.Drawing.Point(93, 571);
            this.html_status.Name = "html_status";
            this.html_status.Size = new System.Drawing.Size(67, 15);
            this.html_status.TabIndex = 1;
            this.html_status.Text = "html_status";
            this.html_status.Visible = false;
            // 
            // Tank
            // 
            this.Tank.Location = new System.Drawing.Point(12, 27);
            this.Tank.Name = "Tank";
            this.Tank.Size = new System.Drawing.Size(200, 530);
            this.Tank.TabIndex = 1;
            // 
            // Healer
            // 
            this.Healer.Location = new System.Drawing.Point(218, 27);
            this.Healer.Name = "Healer";
            this.Healer.Size = new System.Drawing.Size(200, 530);
            this.Healer.TabIndex = 2;
            // 
            // Melee
            // 
            this.Melee.Location = new System.Drawing.Point(424, 27);
            this.Melee.Name = "Melee";
            this.Melee.Size = new System.Drawing.Size(200, 530);
            this.Melee.TabIndex = 2;
            // 
            // Physical
            // 
            this.Physical.Location = new System.Drawing.Point(630, 27);
            this.Physical.Name = "Physical";
            this.Physical.Size = new System.Drawing.Size(200, 530);
            this.Physical.TabIndex = 2;
            // 
            // Magical
            // 
            this.Magical.Location = new System.Drawing.Point(836, 27);
            this.Magical.Name = "Magical";
            this.Magical.Size = new System.Drawing.Size(200, 530);
            this.Magical.TabIndex = 2;
            // 
            // Crafter
            // 
            this.Crafter.Location = new System.Drawing.Point(1042, 27);
            this.Crafter.Name = "Crafter";
            this.Crafter.Size = new System.Drawing.Size(200, 530);
            this.Crafter.TabIndex = 2;
            // 
            // Gatherer
            // 
            this.Gatherer.Location = new System.Drawing.Point(1248, 27);
            this.Gatherer.Name = "Gatherer";
            this.Gatherer.Size = new System.Drawing.Size(200, 530);
            this.Gatherer.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(300, 567);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(530, 23);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 571);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lodestone キャラクターID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1377, 567);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // L_Tank
            // 
            this.L_Tank.AutoSize = true;
            this.L_Tank.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Tank.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.L_Tank.Location = new System.Drawing.Point(12, 9);
            this.L_Tank.Name = "L_Tank";
            this.L_Tank.Size = new System.Drawing.Size(38, 15);
            this.L_Tank.TabIndex = 6;
            this.L_Tank.Text = "TANK";
            // 
            // L_Healer
            // 
            this.L_Healer.AutoSize = true;
            this.L_Healer.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Healer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.L_Healer.Location = new System.Drawing.Point(218, 9);
            this.L_Healer.Name = "L_Healer";
            this.L_Healer.Size = new System.Drawing.Size(49, 15);
            this.L_Healer.TabIndex = 7;
            this.L_Healer.Text = "HEALER";
            // 
            // L_Melee
            // 
            this.L_Melee.AutoSize = true;
            this.L_Melee.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Melee.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.L_Melee.Location = new System.Drawing.Point(424, 9);
            this.L_Melee.Name = "L_Melee";
            this.L_Melee.Size = new System.Drawing.Size(65, 15);
            this.L_Melee.TabIndex = 8;
            this.L_Melee.Text = "Melee DPS";
            // 
            // L_Physical
            // 
            this.L_Physical.AutoSize = true;
            this.L_Physical.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Physical.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.L_Physical.Location = new System.Drawing.Point(630, 9);
            this.L_Physical.Name = "L_Physical";
            this.L_Physical.Size = new System.Drawing.Size(119, 15);
            this.L_Physical.TabIndex = 9;
            this.L_Physical.Text = "Physical Ranged DPS";
            // 
            // L_Magical
            // 
            this.L_Magical.AutoSize = true;
            this.L_Magical.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Magical.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.L_Magical.Location = new System.Drawing.Point(836, 9);
            this.L_Magical.Name = "L_Magical";
            this.L_Magical.Size = new System.Drawing.Size(118, 15);
            this.L_Magical.TabIndex = 10;
            this.L_Magical.Text = "Magical Ranged DPS";
            // 
            // L_Crafter
            // 
            this.L_Crafter.AutoSize = true;
            this.L_Crafter.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Crafter.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.L_Crafter.Location = new System.Drawing.Point(1042, 9);
            this.L_Crafter.Name = "L_Crafter";
            this.L_Crafter.Size = new System.Drawing.Size(42, 15);
            this.L_Crafter.TabIndex = 11;
            this.L_Crafter.Text = "Crafter";
            // 
            // L_Gatherer
            // 
            this.L_Gatherer.AutoSize = true;
            this.L_Gatherer.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Gatherer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.L_Gatherer.Location = new System.Drawing.Point(1248, 9);
            this.L_Gatherer.Name = "L_Gatherer";
            this.L_Gatherer.Size = new System.Drawing.Size(52, 15);
            this.L_Gatherer.TabIndex = 12;
            this.L_Gatherer.Text = "Gatherer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 602);
            this.Controls.Add(this.L_Gatherer);
            this.Controls.Add(this.L_Crafter);
            this.Controls.Add(this.L_Magical);
            this.Controls.Add(this.L_Physical);
            this.Controls.Add(this.L_Melee);
            this.Controls.Add(this.L_Healer);
            this.Controls.Add(this.L_Tank);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Gatherer);
            this.Controls.Add(this.Crafter);
            this.Controls.Add(this.Magical);
            this.Controls.Add(this.Physical);
            this.Controls.Add(this.Melee);
            this.Controls.Add(this.Healer);
            this.Controls.Add(this.Tank);
            this.Controls.Add(this.html_status);
            this.Controls.Add(this.Acquisition);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Acquisition;
        private System.Windows.Forms.Label html_catch;
        private System.Windows.Forms.Label html_status;
        private System.Windows.Forms.Panel Tank;
        private System.Windows.Forms.Panel Healer;
        private System.Windows.Forms.Panel Melee;
        private System.Windows.Forms.Panel Physical;
        private System.Windows.Forms.Panel Magical;
        private System.Windows.Forms.Panel Crafter;
        private System.Windows.Forms.Panel Gatherer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label L_Tank;
        private System.Windows.Forms.Label L_Healer;
        private System.Windows.Forms.Label L_Melee;
        private System.Windows.Forms.Label L_Physical;
        private System.Windows.Forms.Label L_Magical;
        private System.Windows.Forms.Label L_Crafter;
        private System.Windows.Forms.Label L_Gatherer;
    }
}

