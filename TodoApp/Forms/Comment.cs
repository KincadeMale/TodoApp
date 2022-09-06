using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoApp.Forms
{
    public partial class Comment : Form
    {
        public Comment()
        {
            InitializeComponent();
        }

        public long CommentKey;
        public long TodoKey;

        private void Comment_Load(object sender, EventArgs e)
        {
            if(CommentKey > 0)
            {
                Services.CommentsService service = new Services.CommentsService();
                richTextBox1.Text = service.GetComment(CommentKey);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services.CommentsService service = new Services.CommentsService();

            if (CommentKey == 0)
            {
                service.CreateComment(TodoKey, richTextBox1.Text);
            }
            else
            {
                service.UpdateComment(CommentKey, richTextBox1.Text);
            }

            this.Close();
        }
    }
}
