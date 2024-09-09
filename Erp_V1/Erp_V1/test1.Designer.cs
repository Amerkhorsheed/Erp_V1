namespace Erp_V1
{
    partial class test1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPreferences;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblPreferences;
        private System.Windows.Forms.Label lblRecommendations;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPreferences = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblPreferences = new System.Windows.Forms.Label();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(120, 20);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 22);
            this.txtCustomerName.TabIndex = 0;
            // 
            // txtPreferences
            // 
            this.txtPreferences.Location = new System.Drawing.Point(120, 60);
            this.txtPreferences.Name = "txtPreferences";
            this.txtPreferences.Size = new System.Drawing.Size(200, 22);
            this.txtPreferences.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(120, 100);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 30);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate Recommendations";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 16;
            this.lstRecommendations.Location = new System.Drawing.Point(120, 150);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(400, 180);
            this.lstRecommendations.TabIndex = 3;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 23);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(94, 16);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // lblPreferences
            // 
            this.lblPreferences.AutoSize = true;
            this.lblPreferences.Location = new System.Drawing.Point(20, 63);
            this.lblPreferences.Name = "lblPreferences";
            this.lblPreferences.Size = new System.Drawing.Size(77, 16);
            this.lblPreferences.TabIndex = 5;
            this.lblPreferences.Text = "Preferences:";
            // 
            // lblRecommendations
            // 
            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Location = new System.Drawing.Point(20, 150);
            this.lblRecommendations.Name = "lblRecommendations";
            this.lblRecommendations.Size = new System.Drawing.Size(100, 16);
            this.lblRecommendations.TabIndex = 6;
            this.lblRecommendations.Text = "Recommendations:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblRecommendations);
            this.Controls.Add(this.lblPreferences);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtPreferences);
            this.Controls.Add(this.txtCustomerName);
            this.Name = "Form1";
            this.Text = "Product Recommendation System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}