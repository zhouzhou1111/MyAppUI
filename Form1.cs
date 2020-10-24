using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBService.Models;
using DBService.Services;

namespace MyAppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            FrmDrugAdd fda = new FrmDrugAdd();
            fda.Show();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        { 
            //点击查询按钮时，根据条件查询返回查询的数据
            ServiceDBDrug serviceDBDrug = new ServiceDBDrug();            
            string strChar = this.txtSrcChar.Text.Trim();
            this.dataGridView1.DataSource = serviceDBDrug.GetDrugs(strChar);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
