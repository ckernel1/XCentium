﻿

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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TopWords)).BeginInit();
            this.bb_request.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_grouping
            // 
            this.cb_grouping.AutoSize = true;
            this.cb_grouping.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cb_grouping.Location = new System.Drawing.Point(3, 73);
            this.cb_grouping.Name = "cb_grouping";
            this.cb_grouping.Size = new System.Drawing.Size(194, 17);
            this.cb_grouping.TabIndex = 0;
            this.cb_grouping.Text = "Use Stem Word Grouping";
            this.cb_grouping.UseVisualStyleBackColor = true;
            // 
            // txt_URL
            // 
            this.txt_URL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_URL.Location = new System.Drawing.Point(3, 16);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.Size = new System.Drawing.Size(516, 20);
            this.txt_URL.TabIndex = 1;
            this.txt_URL.Text = "http://google.com";
            // 
            // btn_Go
            // 
            this.btn_Go.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Go.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Go.Location = new System.Drawing.Point(3, 103);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(516, 23);
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
            this.dgv_TopWords.Size = new System.Drawing.Size(722, 563);
            this.dgv_TopWords.TabIndex = 3;
            // 
            // lv_images
            // 
            this.lv_images.Dock = System.Windows.Forms.DockStyle.Right;
            this.lv_images.LargeImageList = this.imagesFromCurrentSite;
            this.lv_images.Location = new System.Drawing.Point(722, 0);
            this.lv_images.Name = "lv_images";
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
            this.bb_request.Location = new System.Drawing.Point(0, 563);
            this.bb_request.Name = "bb_request";
            this.bb_request.Size = new System.Drawing.Size(722, 129);
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
            this.cb_ignoreCommonwords.Location = new System.Drawing.Point(3, 90);
            this.cb_ignoreCommonwords.Name = "cb_ignoreCommonwords";
            this.cb_ignoreCommonwords.Size = new System.Drawing.Size(194, 17);
            this.cb_ignoreCommonwords.TabIndex = 3;
            this.cb_ignoreCommonwords.Text = "Ignore Common Words";
            this.cb_ignoreCommonwords.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_grouping);
            this.groupBox1.Controls.Add(this.cb_ignoreCommonwords);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(519, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_Go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 692);
            this.Controls.Add(this.dgv_TopWords);
            this.Controls.Add(this.bb_request);
            this.Controls.Add(this.lv_images);
            this.Name = "Form1";
            this.Text = "XCentium Web Scrapper";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TopWords)).EndInit();
            this.bb_request.ResumeLayout(false);
            this.bb_request.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}
