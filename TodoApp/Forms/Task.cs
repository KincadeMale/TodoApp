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
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services.TodoService service = new Services.TodoService();
            service.CreateTask(richTextBox1.Text, dateTimePicker1.Value.Date);
            this.Close();
        }
    }
}
