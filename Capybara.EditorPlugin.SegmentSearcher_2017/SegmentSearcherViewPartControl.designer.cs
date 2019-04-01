namespace Capybara.EditorPlugin.SegmentSearcher_2017
{
    partial class SegmentSearcherViewPartControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.topLevelTable = new System.Windows.Forms.TableLayoutPanel();
            this.findWhatComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.inSourceCheckBox = new System.Windows.Forms.CheckBox();
            this.inTargetCheckBox = new System.Windows.Forms.CheckBox();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.matchWholeWordCheckBox = new System.Windows.Forms.CheckBox();
            this.useRegexCheckBox = new System.Windows.Forms.CheckBox();
            this.includeTagsCheckBox = new System.Windows.Forms.CheckBox();
            this.onlyInActiveDocCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchResultsWebBrowser = new System.Windows.Forms.WebBrowser();
            this.returnButton = new System.Windows.Forms.Button();
            this.topLevelTable.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topLevelTable
            // 
            this.topLevelTable.ColumnCount = 4;
            this.topLevelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topLevelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLevelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topLevelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topLevelTable.Controls.Add(this.findWhatComboBox, 1, 0);
            this.topLevelTable.Controls.Add(this.searchButton, 2, 0);
            this.topLevelTable.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.topLevelTable.Controls.Add(this.label1, 0, 0);
            this.topLevelTable.Controls.Add(this.searchResultsWebBrowser, 0, 2);
            this.topLevelTable.Controls.Add(this.returnButton, 3, 0);
            this.topLevelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLevelTable.Location = new System.Drawing.Point(0, 0);
            this.topLevelTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topLevelTable.Name = "topLevelTable";
            this.topLevelTable.RowCount = 3;
            this.topLevelTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLevelTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLevelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLevelTable.Size = new System.Drawing.Size(871, 497);
            this.topLevelTable.TabIndex = 0;
            // 
            // findWhatComboBox
            // 
            this.findWhatComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findWhatComboBox.FormattingEnabled = true;
            this.findWhatComboBox.Location = new System.Drawing.Point(71, 4);
            this.findWhatComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.findWhatComboBox.Name = "findWhatComboBox";
            this.findWhatComboBox.Size = new System.Drawing.Size(611, 23);
            this.findWhatComboBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(688, 4);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(87, 25);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.topLevelTable.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.inSourceCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.inTargetCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.matchCaseCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.matchWholeWordCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.useRegexCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.includeTagsCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.onlyInActiveDocCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(865, 25);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // inSourceCheckBox
            // 
            this.inSourceCheckBox.AutoSize = true;
            this.inSourceCheckBox.Checked = true;
            this.inSourceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inSourceCheckBox.Location = new System.Drawing.Point(3, 3);
            this.inSourceCheckBox.Name = "inSourceCheckBox";
            this.inSourceCheckBox.Size = new System.Drawing.Size(74, 19);
            this.inSourceCheckBox.TabIndex = 0;
            this.inSourceCheckBox.Text = "In source";
            this.inSourceCheckBox.UseVisualStyleBackColor = true;
            // 
            // inTargetCheckBox
            // 
            this.inTargetCheckBox.AutoSize = true;
            this.inTargetCheckBox.Checked = true;
            this.inTargetCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inTargetCheckBox.Location = new System.Drawing.Point(83, 3);
            this.inTargetCheckBox.Name = "inTargetCheckBox";
            this.inTargetCheckBox.Size = new System.Drawing.Size(70, 19);
            this.inTargetCheckBox.TabIndex = 0;
            this.inTargetCheckBox.Text = "In target";
            this.inTargetCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Location = new System.Drawing.Point(159, 3);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(86, 19);
            this.matchCaseCheckBox.TabIndex = 0;
            this.matchCaseCheckBox.Text = "Match case";
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchWholeWordCheckBox
            // 
            this.matchWholeWordCheckBox.AutoSize = true;
            this.matchWholeWordCheckBox.Location = new System.Drawing.Point(251, 3);
            this.matchWholeWordCheckBox.Name = "matchWholeWordCheckBox";
            this.matchWholeWordCheckBox.Size = new System.Drawing.Size(125, 19);
            this.matchWholeWordCheckBox.TabIndex = 0;
            this.matchWholeWordCheckBox.Text = "Match whole word";
            this.matchWholeWordCheckBox.UseVisualStyleBackColor = true;
            // 
            // useRegexCheckBox
            // 
            this.useRegexCheckBox.AutoSize = true;
            this.useRegexCheckBox.Location = new System.Drawing.Point(382, 3);
            this.useRegexCheckBox.Name = "useRegexCheckBox";
            this.useRegexCheckBox.Size = new System.Drawing.Size(148, 19);
            this.useRegexCheckBox.TabIndex = 0;
            this.useRegexCheckBox.Text = "Use regular expressions";
            this.useRegexCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeTagsCheckBox
            // 
            this.includeTagsCheckBox.AutoSize = true;
            this.includeTagsCheckBox.Location = new System.Drawing.Point(536, 3);
            this.includeTagsCheckBox.Name = "includeTagsCheckBox";
            this.includeTagsCheckBox.Size = new System.Drawing.Size(90, 19);
            this.includeTagsCheckBox.TabIndex = 0;
            this.includeTagsCheckBox.Text = "Include tags";
            this.includeTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // onlyInActiveDocCheckBox
            // 
            this.onlyInActiveDocCheckBox.AutoSize = true;
            this.onlyInActiveDocCheckBox.Location = new System.Drawing.Point(632, 3);
            this.onlyInActiveDocCheckBox.Name = "onlyInActiveDocCheckBox";
            this.onlyInActiveDocCheckBox.Size = new System.Drawing.Size(156, 19);
            this.onlyInActiveDocCheckBox.TabIndex = 0;
            this.onlyInActiveDocCheckBox.Text = "Only in active document";
            this.onlyInActiveDocCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find what:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchResultsWebBrowser
            // 
            this.searchResultsWebBrowser.AllowWebBrowserDrop = false;
            this.topLevelTable.SetColumnSpan(this.searchResultsWebBrowser, 4);
            this.searchResultsWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResultsWebBrowser.Location = new System.Drawing.Point(3, 67);
            this.searchResultsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.searchResultsWebBrowser.Name = "searchResultsWebBrowser";
            this.searchResultsWebBrowser.ScriptErrorsSuppressed = true;
            this.searchResultsWebBrowser.Size = new System.Drawing.Size(865, 427);
            this.searchResultsWebBrowser.TabIndex = 4;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(781, 4);
            this.returnButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(87, 25);
            this.returnButton.TabIndex = 5;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // SegmentSearcherViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topLevelTable);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SegmentSearcherViewPartControl";
            this.Size = new System.Drawing.Size(871, 497);
            this.topLevelTable.ResumeLayout(false);
            this.topLevelTable.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topLevelTable;
        private System.Windows.Forms.ComboBox findWhatComboBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox matchCaseCheckBox;
        private System.Windows.Forms.CheckBox matchWholeWordCheckBox;
        private System.Windows.Forms.CheckBox useRegexCheckBox;
        private System.Windows.Forms.CheckBox includeTagsCheckBox;
        private System.Windows.Forms.CheckBox onlyInActiveDocCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser searchResultsWebBrowser;
        private System.Windows.Forms.CheckBox inSourceCheckBox;
        private System.Windows.Forms.CheckBox inTargetCheckBox;
        private System.Windows.Forms.Button returnButton;
    }
}
