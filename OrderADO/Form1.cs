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

    public delegate void RefreshListView();

    public partial class Form1 : Form
    {
        ClassOpenBase Base;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Добавление Закказа
            FormEditOrder F = new FormEditOrder(-1, Base, refreshListView);
            F.ShowDialog(this);

        }

        void refreshListView()
        {
            listView1.VirtualListSize = Base.classOrder.dataView.Count;
            listView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Открытие окна типов заказа

            PosTypeOrder pos = new PosTypeOrder();
            FormOrderType F = new FormOrderType(Base,pos);
            F.ShowDialog(this);
            F.Dispose();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Открыти базы данных
            Base = new ClassOpenBase();


            // Установка иконок сортировки в заголовки колонок
            listView1.Columns[1].ImageIndex = 1;
            for (int i = 2; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].ImageIndex = 0;
            }


            // Инициализация виртуальной таблицы
            listView1.VirtualListSize = Base.classOrder.dataView.Count;
            listView1.VirtualMode = true;
            listView1.Refresh();
            
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            // Событие вывода в виртуальную таблицу Заказов            
            int c = ((ListView)sender).VirtualListSize;
            if (((c > 0) && (e.ItemIndex < c)) && (e.ItemIndex > -1))
            {
                cOrder cO = new cOrder(Base.classOrder.dataView[e.ItemIndex].Row);
                e.Item = new ListViewItem(new string[] { (e.ItemIndex + 1).ToString(), 
                                    cO.Id.ToString(),
                                    cO.NDock,
                                    cO.Summ.ToString(),
                                    cO.StatusStr,
                                    cO.NameTypeOrder,
                                    cO.Percent.ToString(),
                                    cO.Comment
                                    });                              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Изменение Закказа

            if (listView1.SelectedIndices.Count > 0)
            {

                int n = listView1.SelectedIndices[0];

                FormEditOrder F = new FormEditOrder(n, Base, refreshListView);
                F.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Удаление заказа

            if (listView1.SelectedIndices.Count > 0)
            {
                int n = listView1.SelectedIndices[0];

                if (Base.classOrder.delRow(n, false))
                {
                    Base.classOrderPole.UpdateTable();
                    Base.classOrder.UpdateTable();

                    refreshListView();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                // Нажатие кнопки Обработать Заказ
                int n = listView1.SelectedIndices[0];

                DataRow row = Base.classOrder.dataView[n].Row;
                if (Int32.Parse(row[3].ToString()) == 0)
                {
                    Decimal summ = 0;
                    try
                    {
                        summ = Decimal.Parse(row[2].ToString());
                    }
                    catch { }
                    Decimal proc = 0;
                    try
                    {
                        proc = Decimal.Parse(row[5].ToString());
                    }
                    catch { }
                    summ = (summ / 100) * (100 + proc);

                    row.BeginEdit();
                    row[2] = summ;
                    row[3] = 1;
                    row.EndEdit();

                    Base.classOrder.UpdateTable();

                    listView1.Refresh();

                }
                else
                {
                    MessageBox.Show(this,"Заказ уже обработан!", "Внимание!");
                }

            }
            else
            {
                MessageBox.Show(this, "Выберите заказ для обработки!", "Внимание!");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                // Нажатие кнопки Отменить Обработку Заказа
                int n = listView1.SelectedIndices[0];

                DataRow row = Base.classOrder.dataView[n].Row;
                if (Int32.Parse(row[3].ToString()) == 1)
                {
                    Decimal summ = 0;
                    try
                    {
                        summ = Decimal.Parse(row[2].ToString());
                    }
                    catch { }
                    Decimal proc = 0;
                    try
                    {
                        proc = Decimal.Parse(row[5].ToString());
                    }
                    catch { }

                    summ = (summ / (100 + proc)) * 100;

                    row.BeginEdit();
                    row[2] = summ;
                    row[3] = 0;
                    row.EndEdit();

                    Base.classOrder.UpdateTable();
                    listView1.Refresh();
                }
                else
                {
                    MessageBox.Show(this, "В заказе нет статуса \"Обработано\"!", "Внимание!");
                }

            }
            else
            {
                MessageBox.Show(this, "Выберите заказ для снятия статуса \"Обработано\"!", "Внимание!");
            }

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Обработка щелчков по заголовкам колонок для соответствующей пересортировки таблицы

            if (e.Column > 0)
            {

                if (((ListView)sender).Columns[e.Column].ImageIndex < 1)
                {
                    for (int i = 0; i < ((ListView)sender).Columns.Count; i++)
                    {
                        if (((ListView)sender).Columns[i].ImageIndex > 0)
                        {
                            ((ListView)sender).Columns[i].ImageIndex = 0;
                            break;
                        }
                    }
                    ((ListView)sender).Columns[e.Column].ImageIndex = 1;
                }
                else
                {
                    int i = ((ListView)sender).Columns[e.Column].ImageIndex;
                    ((ListView)sender).Columns[e.Column].ImageIndex = (i % 2) + 1;
                }

                Base.classOrder.sortOrientation = (SortOrientation)(((ListView)sender).Columns[e.Column].ImageIndex);
                Base.classOrder.SortIndex = e.Column - 1;


                refreshListView();
            }
        }
    }
    
}
