using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_CRUD
{
    public partial class FormStudentInfo : Form
    {
        FormStudent form;

        public FormStudentInfo()
        {
            InitializeComponent();
            form = new FormStudent(this);
        }
        public void Display()
        {
            DbStudent.DisplayAndSearch("SELECT ID, Name, Reg, Class, Section FROM student_table", dataGridView);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.ShowDialog();
        }

        private void FormStudentInfo_Shown_1(object sender, EventArgs e)
        {
            Display(); 
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            DbStudent.DisplayAndSearch("SELECT ID, Name, Reg, Class, Section FROM student_table WHERE Name LIKE'%" + txtSearch.Text + "%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //EDIT
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.reg = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.@class = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.section = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                //DELETE
                if(MessageBox.Show("Are you sure you want to delete student record?", "Information", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information) == DialogResult.Yes);
                {
                    DbStudent.DeleteStudent(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}
