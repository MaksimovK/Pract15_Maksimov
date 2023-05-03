using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pract15;

namespace WF_Pract15
{
    public partial class Form1 : Form
    {
        private StudentGroup studentGroup = new StudentGroup();
        private SortedList<string, StudentGroup> data = new SortedList<string, StudentGroup>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int key = CheckKey(NumberStudent);
                studentGroup.FirstName = FirstName.Text;
                studentGroup.MiddleName = MiddleName.Text;
                studentGroup.LastName = LastName.Text;
                studentGroup.DataOfBirth = DataOfBirth.Value.Date;
                studentGroup.NumberPhone = NumberPhone.Text;
                new StudentGroup(key, studentGroup.FirstName, studentGroup.MiddleName, studentGroup.LastName,
                    studentGroup.DataOfBirth, studentGroup.NumberPhone);
                dataGridView1.Rows.Add(key, studentGroup.FirstName, studentGroup.MiddleName, studentGroup.LastName,
                    studentGroup.DataOfBirth, studentGroup.NumberPhone);
                data.Add(key.ToString(), studentGroup);
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Номер в списке", "Номер в списке");
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("Дата рождения", "Дата рождения");
            dataGridView1.Columns.Add("Номер телефона", "Номер телефона");
        }

        private int CheckKey(TextBox tb)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Номер в списке"].Value != null &&
                        row.Cells["Номер в списке"].Value.ToString() == tb.Text)
                    {
                        tb.Text = "0";
                    }
                }
            }
            catch (Exception)
            {
                tb.Text = "0";
            }

            return int.Parse(tb.Text);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string key = selectedRow.Cells[0].Value.ToString();
                data.Remove(key);
                dataGridView1.Rows.RemoveAt(selectedRow.Index);
            }
        }

        private void CountStudent_Click(object sender, EventArgs e)
        {
            int countStudent;
            countStudent = dataGridView1.Rows.Count;

            MessageBox.Show($"Кол-во студентов в группе {countStudent - 1}", "Информация", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearch.Text;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString().Equals(searchValue))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}