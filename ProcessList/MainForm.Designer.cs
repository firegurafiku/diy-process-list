namespace ProcessList
{
    partial class MainForm
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
            ProcessList.ProcessLister processLister1 = new ProcessList.ProcessLister();
            this.uxSortKeyComboBox = new System.Windows.Forms.ComboBox();
            this.uiDescriptionLabel = new System.Windows.Forms.Label();
            this.uxExitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.processListControl1 = new ProcessList.ProcessListControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxSortKeyComboBox
            // 
            this.uxSortKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxSortKeyComboBox.FormattingEnabled = true;
            this.uxSortKeyComboBox.Location = new System.Drawing.Point(269, 16);
            this.uxSortKeyComboBox.Name = "uxSortKeyComboBox";
            this.uxSortKeyComboBox.Size = new System.Drawing.Size(165, 21);
            this.uxSortKeyComboBox.TabIndex = 2;
            // 
            // uiDescriptionLabel
            // 
            this.uiDescriptionLabel.AutoSize = true;
            this.uiDescriptionLabel.BackColor = System.Drawing.SystemColors.Highlight;
            this.uiDescriptionLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.uiDescriptionLabel.Location = new System.Drawing.Point(3, 0);
            this.uiDescriptionLabel.Name = "uiDescriptionLabel";
            this.uiDescriptionLabel.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.SetRowSpan(this.uiDescriptionLabel, 3);
            this.uiDescriptionLabel.Size = new System.Drawing.Size(246, 49);
            this.uiDescriptionLabel.TabIndex = 2;
            this.uiDescriptionLabel.Text = "Below is the list of all processes we were able to obtain access to; there may be" +
    " other projects running on the system.\r\n";
            // 
            // uxExitButton
            // 
            this.uxExitButton.Location = new System.Drawing.Point(3, 507);
            this.uxExitButton.Name = "uxExitButton";
            this.uxExitButton.Size = new System.Drawing.Size(75, 23);
            this.uxExitButton.TabIndex = 5;
            this.uxExitButton.Text = "E&xit";
            this.uxExitButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.uiDescriptionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.processListControl1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uxSortKeyComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uxExitButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 533);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order &by property";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(269, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "&Descending";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // processListControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.processListControl1, 2);
            this.processListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processListControl1.Location = new System.Drawing.Point(3, 71);
            this.processListControl1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.processListControl1.Name = "processListControl1";
            this.processListControl1.ProcessLister = processLister1;
            this.processListControl1.ProcessSortDescending = false;
            this.processListControl1.ProcessSortKey = null;
            this.processListControl1.Size = new System.Drawing.Size(431, 430);
            this.processListControl1.TabIndex = 4;
            this.processListControl1.Text = "processListControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 541);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ProcessListControl processListControl1;
        private System.Windows.Forms.ComboBox uxSortKeyComboBox;
        private System.Windows.Forms.Label uiDescriptionLabel;
        private System.Windows.Forms.Button uxExitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}

