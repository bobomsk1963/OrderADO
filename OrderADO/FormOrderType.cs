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
    public partial class FormOrderType : Form
    {
        ClassOpenBase Base = null;
        bool Edit=true;

        PosTypeOrder Pos = null;

        public FormOrderType(ClassOpenBase _base, PosTypeOrder pos, bool edit = true)
        {
            Base = _base;
            Edit = edit;
            Pos = pos;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEditOrderType F = new FormEditOrderType(-1, Base, refreshListView);
            F.ShowDialog(this);
        }

        void refreshListView()
        {
            listView1.VirtualListSize = Base.classTypeOrder.dataView.Count;
            listView1.Refresh();
        }

        private void FormOrderType_Shown(object sender, EventArgs e)
        {

            if (Edit)
            {
                panel1.Visible = false;
                panel2.Dock = DockStyle.Fill;

            }

            listView1.VirtualListSize = Base.classTypeOrder.dataView.Count;
            listView1.VirtualMode = true;
            listView1.Refresh();
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            // Событие вывода в виртуальную таблицу Заказов            
            int c = ((ListView)sender).VirtualListSize;
            if (((c > 0) && (e.ItemIndex < c)) && (e.ItemIndex > -1))
            {
                cTypeOrder cO = new cTypeOrder(Base.classTypeOrder.dataView[e.ItemIndex].Row);
                e.Item = new ListViewItem(new string[] { (e.ItemIndex + 1).ToString(), 
                                    cO.Id.ToString(),
                                    cO.Name,
                                    cO.Percent.ToString(),
                                    cO.Comment
                                    });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int n = listView1.SelectedIndices[0];
                FormEditOrderType F = new FormEditOrderType(n, Base, refreshListView);
                F.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int n = listView1.SelectedIndices[0];

                if (Base.classTypeOrder.delRow(n, false))
                {
                    Base.classTypeOrderPole.UpdateTable();
                    Base.classTypeOrder.UpdateTable();

                    listView1.VirtualListSize = Base.classTypeOrder.dataView.Count;
                    listView1.Refresh();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int n = listView1.SelectedIndices[0];
                Pos.drv = Base.classTypeOrder.dataView[n];
            }
        }

    }
}
