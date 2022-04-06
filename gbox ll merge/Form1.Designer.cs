namespace gbox_ll_merge
{
    partial class mapon_fw_merge
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
            this.tb_bootloader_location = new System.Windows.Forms.TextBox();
            this.tb_firmware_location = new System.Windows.Forms.TextBox();
            this.b_set_bootloader_location = new System.Windows.Forms.Button();
            this.b_set_firmware_location = new System.Windows.Forms.Button();
            this.b_output_location = new System.Windows.Forms.Button();
            this.tb_output_location = new System.Windows.Forms.TextBox();
            this.b_merge = new System.Windows.Forms.Button();
            this.status_bar = new System.Windows.Forms.StatusStrip();
            this.tssbl_error = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_bar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_bootloader_location
            // 
            this.tb_bootloader_location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_bootloader_location.Location = new System.Drawing.Point(12, 12);
            this.tb_bootloader_location.Name = "tb_bootloader_location";
            this.tb_bootloader_location.Size = new System.Drawing.Size(472, 20);
            this.tb_bootloader_location.TabIndex = 0;
            // 
            // tb_firmware_location
            // 
            this.tb_firmware_location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_firmware_location.Location = new System.Drawing.Point(12, 38);
            this.tb_firmware_location.Name = "tb_firmware_location";
            this.tb_firmware_location.Size = new System.Drawing.Size(472, 20);
            this.tb_firmware_location.TabIndex = 1;
            // 
            // b_set_bootloader_location
            // 
            this.b_set_bootloader_location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_set_bootloader_location.Location = new System.Drawing.Point(490, 12);
            this.b_set_bootloader_location.Name = "b_set_bootloader_location";
            this.b_set_bootloader_location.Size = new System.Drawing.Size(116, 20);
            this.b_set_bootloader_location.TabIndex = 2;
            this.b_set_bootloader_location.Text = "bootloader location";
            this.b_set_bootloader_location.UseVisualStyleBackColor = true;
            this.b_set_bootloader_location.Click += new System.EventHandler(this.b_set_bootloader_location_Click);
            // 
            // b_set_firmware_location
            // 
            this.b_set_firmware_location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_set_firmware_location.Location = new System.Drawing.Point(490, 38);
            this.b_set_firmware_location.Name = "b_set_firmware_location";
            this.b_set_firmware_location.Size = new System.Drawing.Size(116, 20);
            this.b_set_firmware_location.TabIndex = 3;
            this.b_set_firmware_location.Text = "firmware location";
            this.b_set_firmware_location.UseVisualStyleBackColor = true;
            this.b_set_firmware_location.Click += new System.EventHandler(this.b_set_firmware_location_Click);
            // 
            // b_output_location
            // 
            this.b_output_location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_output_location.Location = new System.Drawing.Point(490, 64);
            this.b_output_location.Name = "b_output_location";
            this.b_output_location.Size = new System.Drawing.Size(116, 20);
            this.b_output_location.TabIndex = 5;
            this.b_output_location.Text = "output location";
            this.b_output_location.UseVisualStyleBackColor = true;
            this.b_output_location.Click += new System.EventHandler(this.b_output_location_Click);
            // 
            // tb_output_location
            // 
            this.tb_output_location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_output_location.Location = new System.Drawing.Point(12, 64);
            this.tb_output_location.Name = "tb_output_location";
            this.tb_output_location.Size = new System.Drawing.Size(472, 20);
            this.tb_output_location.TabIndex = 4;
            // 
            // b_merge
            // 
            this.b_merge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_merge.Location = new System.Drawing.Point(12, 90);
            this.b_merge.Name = "b_merge";
            this.b_merge.Size = new System.Drawing.Size(594, 23);
            this.b_merge.TabIndex = 6;
            this.b_merge.Text = "Create File";
            this.b_merge.UseVisualStyleBackColor = true;
            this.b_merge.Click += new System.EventHandler(this.b_merge_Click);
            // 
            // status_bar
            // 
            this.status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbl_error});
            this.status_bar.Location = new System.Drawing.Point(0, 119);
            this.status_bar.Name = "status_bar";
            this.status_bar.Size = new System.Drawing.Size(619, 22);
            this.status_bar.TabIndex = 7;
            this.status_bar.Text = "status_bar";
            // 
            // tssbl_error
            // 
            this.tssbl_error.Name = "tssbl_error";
            this.tssbl_error.Size = new System.Drawing.Size(45, 17);
            this.tssbl_error.Text = "Mapon";
            // 
            // mapon_fw_merge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 141);
            this.Controls.Add(this.status_bar);
            this.Controls.Add(this.b_merge);
            this.Controls.Add(this.b_output_location);
            this.Controls.Add(this.tb_output_location);
            this.Controls.Add(this.b_set_firmware_location);
            this.Controls.Add(this.b_set_bootloader_location);
            this.Controls.Add(this.tb_firmware_location);
            this.Controls.Add(this.tb_bootloader_location);
            this.MaximumSize = new System.Drawing.Size(1024, 180);
            this.MinimumSize = new System.Drawing.Size(250, 164);
            this.Name = "mapon_fw_merge";
            this.Text = "Mapon";
            this.Load += new System.EventHandler(this.mapon_fw_merge_Load);
            this.status_bar.ResumeLayout(false);
            this.status_bar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_bootloader_location;
        private System.Windows.Forms.TextBox tb_firmware_location;
        private System.Windows.Forms.Button b_set_bootloader_location;
        private System.Windows.Forms.Button b_set_firmware_location;
        private System.Windows.Forms.Button b_output_location;
        private System.Windows.Forms.TextBox tb_output_location;
        private System.Windows.Forms.Button b_merge;
        private System.Windows.Forms.StatusStrip status_bar;
        private System.Windows.Forms.ToolStripStatusLabel tssbl_error;
    }
}

