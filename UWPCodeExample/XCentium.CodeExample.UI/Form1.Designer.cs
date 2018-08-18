

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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.btn_Go = new System.Windows.Forms.Button();
            this.dgv_TopWords = new System.Windows.Forms.DataGridView();
            this.lv_images = new System.Windows.Forms.ListView();
            this.imagesFromCurrentSite = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TopWords)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(269, 461);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txt_URL
            // 
            this.txt_URL.Location = new System.Drawing.Point(23, 380);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.Size = new System.Drawing.Size(198, 20);
            this.txt_URL.TabIndex = 1;
            this.txt_URL.Text = "http://google.com";
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(288, 380);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(75, 23);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // dgv_TopWords
            // 
            this.dgv_TopWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TopWords.Location = new System.Drawing.Point(23, 25);
            this.dgv_TopWords.Name = "dgv_TopWords";
            this.dgv_TopWords.Size = new System.Drawing.Size(365, 285);
            this.dgv_TopWords.TabIndex = 3;
            // 
            // lv_images
            // 
            this.lv_images.Dock = System.Windows.Forms.DockStyle.Right;
            this.lv_images.LargeImageList = this.imagesFromCurrentSite;
            this.lv_images.Location = new System.Drawing.Point(565, 0);
            this.lv_images.Name = "lv_images";
            this.lv_images.Size = new System.Drawing.Size(612, 671);
            this.lv_images.SmallImageList = this.imagesFromCurrentSite;
            this.lv_images.TabIndex = 4;
            this.lv_images.UseCompatibleStateImageBehavior = false;
            this.lv_images.SelectedIndexChanged += new System.EventHandler(this.lv_images_SelectedIndexChanged);
            // 
            // imagesFromCurrentSite
            // 
            this.imagesFromCurrentSite.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imagesFromCurrentSite.ImageSize = new System.Drawing.Size(16, 16);
            this.imagesFromCurrentSite.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 671);
            this.Controls.Add(this.lv_images);
            this.Controls.Add(this.dgv_TopWords);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.txt_URL);
            this.Controls.Add(this.checkBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TopWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_URL;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.DataGridView dgv_TopWords;
        private ListView lv_images;
        private ImageList imagesFromCurrentSite;
    }
}

