using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCentium.CodeExample.UI
{
    public partial class ViewerForm : Form
    {
        private const int offset = 85;
        internal Image CurrentImage { set { pb_image.Image = value; Width = value.Width + offset;Height = value.Height + offset; } }
        internal string Title { set { this.Text = value; } }
        public ViewerForm()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
