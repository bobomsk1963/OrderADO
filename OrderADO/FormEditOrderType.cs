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
    public partial class FormEditOrderType : Form
    {
        int Idx = -1;
        ClassOpenBase Base;

        DataRowView Drv = null;
        DataView TypeOrderPoleView = null;

        bool Reject = true;

        RefreshListView RfLV;

        public FormEditOrderType(int idx, ClassOpenBase _base, RefreshListView rflv)
        {
            Base = _base;
            Idx = idx;
            RfLV = rflv;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cTypeOrderPole ctop = new cTypeOrderPole();
            FormEditPoleName F = new FormEditPoleName(ctop,"Добавить");
            if (F.ShowDialog(this)==DialogResult.OK)
            {
              DataRowView drvchild= TypeOrderPoleView.AddNew();
              ctop.ThisToRow(drvchild.Row);
              drvchild.EndEdit();

              ReNumberChild();

              listView1.VirtualListSize = TypeOrderPoleView.Count;
              listView1.Refresh();
            }

        }

        bool TestValidOrderType()
        {
            bool ret = true;

            // Проверка данных на возможность добавления
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Поле Наименование пустое его необходимо заполнить!", "Внимание!");
                ret = false;
            }

            // Проверка наличия повторений в наименованиях полей
            if (ret)
            {
                if (TypeOrderPoleView.Count == 0)
                {
                    MessageBox.Show("Должно быть хотябы одно наименование поля!", "Внимание!");
                    ret = false;
                }

                if (ret)
                {
                    for (int i = 0; i < TypeOrderPoleView.Count; i++)
                    {
                        if (TypeOrderPoleView[i].Row["NamePole"].ToString() == "")
                        {
                           MessageBox.Show("Все имена полей не должны быть пустыми!", "Внимание!");
                            ret = false;
                            break;
                        }

                        for (int j = i + 1; j < TypeOrderPoleView.Count; j++)
                        {
                            if (TypeOrderPoleView[i].Row["NamePole"].ToString() == TypeOrderPoleView[j].Row["NamePole"].ToString())
                            {
                                MessageBox.Show("Имена полей не должны совпадать!", "Внимание!");
                                ret = false;
                                break;
                            }
                        }
                        if (!ret) { break; }
                    }
                }

                if (ret)
                {                        
                        // Проверка на совпадения в именах таблицы Типов Заказов 

                    for (int i = 0; i < Base.classTypeOrder.dataTable.Rows.Count; i++)
                    {
                        DataRow row = Base.classTypeOrder.dataTable.Rows[i];
                        if (row[0].ToString() != Drv.Row[0].ToString())
                        {
                            string s1 = row[1].ToString();
                            string s2 = Drv.Row[1].ToString();
                            if (row[1].ToString() == Drv.Row[1].ToString())
                            {
                                MessageBox.Show("Обнаружено повторение имени Типа Заказа!", "Внимание!");
                                ret = false;
                                break;
                            }
                        }
                    }
                }

            }
            return ret;
        }

        private void FormEditOrderType_Shown(object sender, EventArgs e)
        {
            if (Idx < 0)
            {
                Drv = Base.classTypeOrder.dataView.AddNew();
                new cTypeOrder().ThisToRow(Drv.Row);
                this.Text = "Добавление";
            }
            else
            {
                Drv = Base.classTypeOrder.dataView[Idx];
                Drv.BeginEdit();
                this.Text = "Изменение";
            }

            TypeOrderPoleView = Drv.CreateChildView(Base.Base.dataSet.Relations["TypeOrderParentChild"]);

            TypeOrderPoleView.Sort = "Number" + " ASC";

            textBox1.DataBindings.Add("Text", Drv, "Name");
            textBox2.DataBindings.Add("Text", Drv, "Perc");
            textBox3.DataBindings.Add("Text", Drv, "Comment");


            listView1.VirtualListSize = TypeOrderPoleView.Count;
            listView1.VirtualMode = true;
            listView1.Refresh();
            RfLV();
        }

        void ReNumberChild()
        {
            for (int i = 0; i < TypeOrderPoleView.Count; i++)
            {
                TypeOrderPoleView[i].Row.BeginEdit();
                TypeOrderPoleView[i].Row["Number"] = i+1;
                TypeOrderPoleView[i].Row.EndEdit();
            }
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            // Событие вывода в виртуальную таблицу Заказов            
            int c = ((ListView)sender).VirtualListSize;
            if (((c > 0) && (e.ItemIndex < c)) && (e.ItemIndex > -1))
            {
                cTypeOrderPole cO = new cTypeOrderPole(TypeOrderPoleView[e.ItemIndex].Row);
                e.Item = new ListViewItem(new string[] { 
                                    cO.Id.ToString(),
                                    //cO.IdTypeOrder.ToString(),
                                    cO.Number.ToString(),
                                    cO.NamePole
                                    });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!TestValidOrderType()) { return; }

            Drv.EndEdit();
            Base.classTypeOrder.UpdateTable();
            
            if (Idx<0)
            {
                foreach (DataRowView dr in TypeOrderPoleView)
                {
                    dr.Row.SetParentRow(Drv.Row);
                }
            } 
            
            Base.classTypeOrderPole.UpdateTable(); 
           
            Reject = false;
            Close();

        }

        private void FormEditOrderType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Reject)
            {
                Drv.EndEdit();
                Base.classTypeOrderPole.dataTable.RejectChanges();
                Base.classTypeOrder.dataTable.RejectChanges();                
            }

            RfLV();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int n=listView1.SelectedIndices[0];
                DataRowView drvchild = TypeOrderPoleView[n]; ;
                cTypeOrderPole ctop = new cTypeOrderPole(drvchild.Row);

                FormEditPoleName F = new FormEditPoleName(ctop,"Изменить");
                if (F.ShowDialog(this) == DialogResult.OK)
                {                    
                    drvchild.BeginEdit();
                    ctop.ThisToRow(drvchild.Row);
                    drvchild.EndEdit();

                    listView1.VirtualListSize = TypeOrderPoleView.Count;
                    listView1.Refresh();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int n = listView1.SelectedIndices[0];

                TypeOrderPoleView[n].Delete();

                ReNumberChild();

                listView1.VirtualListSize = TypeOrderPoleView.Count;
                listView1.Refresh();
            }
        }

    }
}
