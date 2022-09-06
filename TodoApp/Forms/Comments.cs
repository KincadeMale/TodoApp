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
    public partial class Comments : UserControl
    {
        public Comments()
        {
            InitializeComponent();
        }

        public long commentKey;
        public long todoKey;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.Comment comment = new Comment();
            comment.CommentKey = commentKey;
            comment.TodoKey = todoKey;
            comment.ShowDialog();
            richTextBox1.Text = comment.richTextBox1.Text;
        }

        private void Comments_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Services.CommentsService comment = new Services.CommentsService();
            comment.DeleteComment(commentKey);
            this.Dispose();
        }
    }
}
