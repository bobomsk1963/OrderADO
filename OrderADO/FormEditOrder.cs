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
    public partial class FormEditOrder : Form
    {
        int Idx=-1;
        DataRowView Drv = null;
        DataView OrderPoleView = null;

        bool Reject = true;

        cOrder EditData = null;
        ClassOpenBase Base=null;

        RefreshListView RfLV;

        // Параметры
        // idx - 
        // _base - Объект открытой базы
        // rflv -  Делегат обновляющий окно таблицы заказов

        public FormEditOrder(int idx,ClassOpenBase _base,RefreshListView rflv)
        {
            Idx=idx;
            Base =_base;
            RfLV = rflv;
            InitializeComponent();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            // Выбор Тип заказа

            FormSelectionType F = new FormSelectionType(Base, Drv, OrderPoleView);
            if (F.ShowDialog(this) == DialogResult.OK)
            {
                textBox7.DataBindings[0].ReadValue();
                textBox8.DataBindings[0].ReadValue();
            }

        }

        private void FormEditOrder_Shown(object sender, EventArgs e)
        {
            // Инициализация окна

            if (Idx < 0)
            {
                Drv = Base.classOrder.dataView.AddNew();
                new cOrder().ThisToRow(Drv.Row);
                this.Text = "Добавление";
            }
            else
            {
                Drv = Base.classOrder.dataView[Idx];
                Drv.BeginEdit();
                this.Text = "Изменение";
            }

            // Получение связных записей из таблицы полей заказа
            OrderPoleView = Drv.CreateChildView(Base.Base.dataSet.Relations["OrderParentChild"]);

            // Сортировка номер поля
            OrderPoleView.Sort = "Number ASC";

            // Помещение связных записей в таблицу
            dataGridView1.DataSource = OrderPoleView;

            //dataGridView1.RowHeadersVisible = false;
            

            //dataGridView1.Columns[0].ReadOnly = true;
            //dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridView1.Columns[0].Width = 49;

            // Скрыть колонку "Id"
            dataGridView1.Columns[0].Visible = false;

            //dataGridView1.Columns[1].ReadOnly = true;
            //dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridView1.Columns[1].Width = 49;
            //dataGridView1.Columns[1].HeaderText = "IdO";

            // Скрыть колонку "IdOrder"
            dataGridView1.Columns[1].Visible = false;

            dataGridView1.Columns[2].HeaderText = "№";
            // Запретитть редактирование
            dataGridView1.Columns[2].ReadOnly = true;
            // Запретитть возможность сортировки по полю
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].Width = 49;

            dataGridView1.Columns[3].HeaderText = "Параметр";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].Width = 120;

            dataGridView1.Columns[4].HeaderText = "Значение";
            // Разрешить редактирование
            dataGridView1.Columns[4].ReadOnly = false;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].Width = 190;


            // Создание объектов связи полей данных заказа с элементами редактирования экранной формы
            textBox4.DataBindings.Add("Text", Drv, "NDock");            
            textBox5.DataBindings.Add("Text", Drv, "Summ");
            comboBox1.DataBindings.Add("SelectedIndex", Drv, "Status");

            textBox7.DataBindings.Add("Text", Drv, "NameType");
            textBox8.DataBindings.Add("Text", Drv, "Perc");

            textBox1.DataBindings.Add("Text", Drv, "Comment");


            // Если запиь уже обработана то запрещаем редактировать Сумму и  Номер документа и выбор типа заказа
            if (comboBox1.SelectedIndex == 1)
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                button1.Enabled = false;
            }


            RfLV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!TestValidOrder())
            {
                return;
            }
            // Проверка правильности ввода

            Drv.EndEdit();
            Base.classOrder.UpdateTable();

            if (Idx < 0)
            {
                foreach (DataRowView dr in OrderPoleView)
                {
                    dr.Row.SetParentRow(Drv.Row);
                }
            } 

            Base.classOrderPole.UpdateTable();

            Reject = false;
            Close();

        }

        bool TestValidOrder()
        { 
            bool ret =true;

            if ((OrderPoleView.Count == 0) || (Drv["NameType"].ToString() == ""))
            {
                MessageBox.Show("Тип заказа не выбран!", "Внимание!");
                ret = false;
            }

            if (ret)
            {
                if (Drv["NDock"].ToString() == "")
                {
                    MessageBox.Show("Поле Номер Заказа пустое его необходимо заполнить!", "Внимание!");
                    ret = false;
                }
                else
                {
                    // Проверка на совпадения номеров Заказов  

                    for (int i = 0; i < Base.classOrder.dataTable.Rows.Count; i++)
                    {
                        DataRow row = Base.classOrder.dataTable.Rows[i];
                        if (row[0].ToString() != Drv.Row[0].ToString())
                        {
                            string s1 = row[1].ToString();
                            string s2 = Drv.Row[1].ToString();
                            if (row[1].ToString() == Drv.Row[1].ToString())
                            {
                                MessageBox.Show("Обнаружено повторение Номера Заказа!", "Внимание!");
                                ret = false;
                                break;
                            }
                        }
                    }
                }
            }

            return ret;
        }

        private void FormEditOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Reject)
            {
                Drv.EndEdit();
                Base.Base.dataSet.RejectChanges();                
            }
            RfLV();
            this.Dispose();
        }
    }

    public class PosTypeOrder
    {
        public DataRowView drv = null;
        public PosTypeOrder()
        { 
        }
    }

}
