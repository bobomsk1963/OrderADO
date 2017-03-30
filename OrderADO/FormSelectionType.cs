using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderADO
{
    public partial class FormSelectionType : Form
    {
        ClassOpenBase Base = null;
        BindingSource masterBindingSource = new BindingSource();
        BindingSource detailsBindingSource = new BindingSource();

        DataRowView Drv = null;
        DataView OrderPoleView = null;

        public FormSelectionType(ClassOpenBase _base,DataRowView r,DataView d)
        {
            Base = _base;
            Drv = r;
            OrderPoleView = d;
            InitializeComponent();
        }

        private void FormSelectionType_Shown(object sender, EventArgs e)
        {
            // Инициализация связанных таблиц

            masterBindingSource.DataSource = Base.classTypeOrder.dataView;

            detailsBindingSource.DataSource = masterBindingSource;
            detailsBindingSource.DataMember = "TypeOrderParentChild";
            detailsBindingSource.Sort = "Number";

            dataGridView1.DataSource = masterBindingSource;
            dataGridView2.DataSource = detailsBindingSource;


            // Определение колонок таблиц
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Имя типа заказа";
            dataGridView1.Columns[1].Width = 180;            

            dataGridView1.Columns[2].HeaderText = "Проценты";
            dataGridView1.Columns[2].Width = 70;

            dataGridView1.Columns[3].HeaderText = "Коментарий";
            dataGridView1.Columns[3].Width = 180;            



            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;

            dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[2].HeaderText = "№";
            dataGridView2.Columns[2].Width = 50;

            dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[3].HeaderText = "Параметр";
            dataGridView2.Columns[3].Width = 200;

            //dataGridView2.Rows[0].Cells[0].Selected = false;
            //dataGridView2.ClearSelection();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;            
            
            // Очистить все дочерние элементы если есть
            if (OrderPoleView.Count > 0)
            {
                foreach (DataRowView dr in OrderPoleView)
                {
                    dr.Delete();
                }
            }

            // Скопировать дочерние элементы из типа заказа
            
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {                
                DataRowView dr = OrderPoleView.AddNew();
                dr["Number"] = dataGridView2.Rows[i].Cells["Number"].Value;
                dr["NamePole"] = dataGridView2.Rows[i].Cells["NamePole"].Value;
                dr["Text"] = "";
                dr.EndEdit();
            }

            Drv["NameType"] = drv["Name"];
            Drv["Perc"] = drv["Perc"];

            if (sender is DataGridView)
            {
                // Если выбор происходит по двойному щелчку по DataGrid то закрываем форму 
                // Выбор по кнопке закрывает форму автоматически
                this.Close();
            }

        }

        private void FormSelectionType_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Удаление формы по её закрытии
            this.Dispose();
        }
    }
}
