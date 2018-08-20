

using System;
using System.Drawing;
using System.Windows.Forms;

namespace XCentium.CodeExample.UI
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
            this.components = new System.ComponentModel.Container();
            this.cb_grouping = new System.Windows.Forms.CheckBox();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.btn_Go = new System.Windows.Forms.Button();
            this.dgv_TopWords = new System.Windows.Forms.DataGridView();
            this.lv_images = new System.Windows.Forms.ListView();
            this.imagesFromCurrentSite = new System.Windows.Forms.ImageList(this.components);
            this.bb_request = new System.Windows.Forms.GroupBox();
            this.cb_ignoreCommonwords = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ll_wordCount = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TopWords)).BeginInit();
            this.bb_request.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_grouping
            // 
            this.cb_grouping.AutoSize = true;
            this.cb_grouping.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cb_grouping.Location = new System.Drawing.Point(3, 15);
            this.cb_grouping.Name = "cb_grouping";
            this.cb_grouping.Size = new System.Drawing.Size(152, 17);
            this.cb_grouping.TabIndex = 0;
            this.cb_grouping.Text = "Use Stem Word Grouping";
            this.cb_grouping.UseVisualStyleBackColor = true;
            // 
            // txt_URL
            // 
            this.txt_URL.BackColor = System.Drawing.Color.YellowGreen;
            this.txt_URL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_URL.Location = new System.Drawing.Point(3, 16);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.Size = new System.Drawing.Size(558, 20);
            this.txt_URL.TabIndex = 1;
            this.txt_URL.Text = "http://google.com";
            // 
            // btn_Go
            // 
            this.btn_Go.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Go.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Go.Location = new System.Drawing.Point(3, 45);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(558, 23);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // dgv_TopWords
            // 
            this.dgv_TopWords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TopWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TopWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_TopWords.Location = new System.Drawing.Point(0, 0);
            this.dgv_TopWords.Name = "dgv_TopWords";
            this.dgv_TopWords.Size = new System.Drawing.Size(722, 568);
            this.dgv_TopWords.TabIndex = 3;
            // 
            // lv_images
            // 
            this.lv_images.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_images.Dock = System.Windows.Forms.DockStyle.Right;
            this.lv_images.LargeImageList = this.imagesFromCurrentSite;
            this.lv_images.Location = new System.Drawing.Point(722, 0);
            this.lv_images.Name = "lv_images";
            this.lv_images.ShowItemToolTips = true;
            this.lv_images.Size = new System.Drawing.Size(612, 692);
            this.lv_images.SmallImageList = this.imagesFromCurrentSite;
            this.lv_images.TabIndex = 4;
            this.lv_images.UseCompatibleStateImageBehavior = false;
            this.lv_images.SelectedIndexChanged += new System.EventHandler(this.lv_images_SelectedIndexChanged);
            // 
            // imagesFromCurrentSite
            // 
            this.imagesFromCurrentSite.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagesFromCurrentSite.ImageSize = new System.Drawing.Size(64, 64);
            this.imagesFromCurrentSite.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bb_request
            // 
            this.bb_request.Controls.Add(this.txt_URL);
            this.bb_request.Controls.Add(this.btn_Go);
            this.bb_request.Controls.Add(this.groupBox1);
            this.bb_request.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bb_request.Location = new System.Drawing.Point(0, 621);
            this.bb_request.Name = "bb_request";
            this.bb_request.Size = new System.Drawing.Size(722, 71);
            this.bb_request.TabIndex = 5;
            this.bb_request.TabStop = false;
            this.bb_request.Text = "Request";
            // 
            // cb_ignoreCommonwords
            // 
            this.cb_ignoreCommonwords.AutoSize = true;
            this.cb_ignoreCommonwords.Checked = true;
            this.cb_ignoreCommonwords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ignoreCommonwords.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cb_ignoreCommonwords.Location = new System.Drawing.Point(3, 32);
            this.cb_ignoreCommonwords.Name = "cb_ignoreCommonwords";
            this.cb_ignoreCommonwords.Size = new System.Drawing.Size(152, 17);
            this.cb_ignoreCommonwords.TabIndex = 3;
            this.cb_ignoreCommonwords.Text = "Ignore Common Words";
            this.cb_ignoreCommonwords.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_grouping);
            this.groupBox1.Controls.Add(this.cb_ignoreCommonwords);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(561, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ll_wordCount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 568);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 53);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web Page Info";
            // 
            // ll_wordCount
            // 
            this.ll_wordCount.AutoSize = true;
            this.ll_wordCount.Location = new System.Drawing.Point(99, 20);
            this.ll_wordCount.Name = "ll_wordCount";
            this.ll_wordCount.Size = new System.Drawing.Size(48, 13);
            this.ll_wordCount.TabIndex = 0;
            this.ll_wordCount.TabStop = true;
            this.ll_wordCount.Text = "<Empty>";
            this.toolTip1.SetToolTip(this.ll_wordCount, "Click to toggle between full word list and top word list.");
            this.ll_wordCount.Click += new System.EventHandler(this.ll_wordCount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total word count:";
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "";
            this.toolTip1.ToolTipTitle = "Toggle";
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_Go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 692);
            this.Controls.Add(this.dgv_TopWords);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bb_request);
            this.Controls.Add(this.lv_images);
            this.Name = "Form1";
            this.Text = "XCentium WebSite Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TopWords)).EndInit();
            this.bb_request.ResumeLayout(false);
            this.bb_request.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_grouping;
        private System.Windows.Forms.TextBox txt_URL;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.DataGridView dgv_TopWords;
        private ListView lv_images;
        private ImageList imagesFromCurrentSite;
        private GroupBox bb_request;
        private GroupBox groupBox1;
        private CheckBox cb_ignoreCommonwords;
        private GroupBox groupBox2;
        private Label label1;
        private LinkLabel ll_wordCount;
        private ToolTip toolTip1;
    }
}

