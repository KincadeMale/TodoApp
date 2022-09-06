using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodoApp.Forms;

namespace TodoApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.Task frmTask = new Forms.Task();
            frmTask.ShowDialog();

            btnTodo_Click(this, new EventArgs());
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            Services.TodoService service = new Services.TodoService();
            var items = service.GetTodoList();

            foreach ( var item in items)
            {
                dataGridView1.Rows.Add(
                    item.Key,
                    item.Description,
                    item.Date
                    );
            }

            dataGridView1_CellClick(this, new DataGridViewCellEventArgs(0,0));
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                return;
            }

            Services.TodoService service = new Services.TodoService();
            Services.CommentsService commservice = new Services.CommentsService();
            commservice.DeleteTodoListComment(long.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            service.DeleteTask(long.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            btnTodo_Click(this, new EventArgs());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            btnTodo_Click(this, new EventArgs());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                return;
            }

            Comment frmComment = new Comment();
            frmComment.TodoKey = long.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frmComment.ShowDialog();

            dataGridView1_CellClick(this, new DataGridViewCellEventArgs(0, 0));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelComment.Controls.Clear();

            if(dataGridView1.Rows.Count == 0)
            {
                return;
            }

            Services.CommentsService service = new Services.CommentsService();
            var list = service.GetComments(long.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));

            foreach(var item in list)
            {
                Comments cs = new Comments();
                cs.label1.Text = item.UserName + " - " + item.CommentDate;
                cs.richTextBox1.Text = item.Comment1;
                cs.todoKey = item.TodoKey;
                cs.commentKey = item.Key;

                panelComment.Controls.Add(cs);
            }
        }
    }
}
