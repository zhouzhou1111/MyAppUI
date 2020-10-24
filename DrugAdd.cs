using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBService;
using DBService.Models;
using DBService.Services;
using QWPlatform.SystemLibrary.Utils;

namespace MyAppUI
{
    public partial class FrmDrugAdd : Form
    {

        //初始化对象药品、service、库存、库存明细、剂型、厂家、库房
        Drug drug = new Drug();
        ServiceDBDrug serviceDBDrug = new ServiceDBDrug();
        Inventory inventory = new Inventory();
        InventorySchedule inventorySchedule = new InventorySchedule();
        Storehouse storehouse = new Storehouse();
        Manufacture manufacture = new Manufacture();
        Dosageform dosageform = new Dosageform();
        ServiceDBInventory serviceDBInventory = new ServiceDBInventory();
        
        public FrmDrugAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            #region 验证输入信息
            //1.验证输入信息--是否为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBox.Show("药品名称不为空");
                return;
            }
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                MessageBox.Show("药品简码不为空");
                return;
            }
            //if (string.IsNullOrEmpty(this.txtAmount.Text.Trim()))
            //{
            //    MessageBox.Show("药品数量不为空");
            //    return;
            //}
            if (string.IsNullOrEmpty(this.txtOperator.Text.Trim()))
            {
                MessageBox.Show("操作人不为空");
                return;
            }
            if (string.IsNullOrEmpty(this.comDosage.Text.Trim()))
            {
                MessageBox.Show("药品剂型不为空");
                return;
            }
            if (string.IsNullOrEmpty(this.comManufacture.Text.Trim()))
            {
                MessageBox.Show("药品厂家不为空");
                return;
            }
            if (string.IsNullOrEmpty(this.comStorhouse.Text.Trim()))
            {
                MessageBox.Show("药品库房不为空");
                return;
            }
            #endregion


          //  #region 验证输入的数量            
          ////  var a = this.txtAmount.Text.Trim();
          //  if (!Strings.IsNumber(a)) {
          //      MessageBox.Show("数量请填写数字");
          //      return;
          //  }
          //  else
          //  { 
          //      if (Convert.ToInt32(a) < 0)
          //      {
          //          MessageBox.Show("数量不能小于0");
          //          return;
          //      }
          //  }
          //  #endregion

            //2.为对象赋值
            drug.name = this.txtName.Text.Trim();
            drug.code = this.txtCode.Text.Trim();
            drug.englishName = this.txtEngname.Text.Trim();
           // inventory.amount = Convert.ToInt32(a);
           //  drug.amount = inventory.amount;
            dosageform.id = Convert.ToInt32(this.comDosage.SelectedIndex+1);
            manufacture.id = Convert.ToInt32(this.comManufacture.SelectedIndex + 1);
            storehouse.id = Convert.ToInt32(this.comStorhouse.SelectedIndex + 1);
            inventorySchedule.oprPerson = this.txtOperator.Text.Trim();
            drug.dosageform = dosageform;
            drug.manufacture = manufacture;
            drug.storehouse = storehouse;
            drug.inventory = inventory;
            drug.inventorySchedule = inventorySchedule;
          
            

 
            //保存,插入药品、药品库存和明细
            bool rs = serviceDBDrug.DrugADD(drug);
            if (serviceDBDrug.DrugADD(drug))
            {
                MessageBox.Show("药品添加成功");
            }
            //bool rs1 = serviceDBInventory.InHouse(drug,inventory,inventorySchedule,storehouse);

            

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //获取简码
             this.txtCode.Text = Strings.GetSpellFirstCode(this.txtName.Text.Trim()); 
        }

        private void FrmDrugAdd_Load(object sender, EventArgs e)
        { 
            //为获取数据库的字典表后，赋值给combox

            this.comDosage.DataSource = serviceDBDrug.GetDosageFormList();
            comDosage.DisplayMember = "name";
            comDosage.ValueMember = "name";


           this.comManufacture.DataSource = serviceDBDrug.GetManufactureList();
            comManufacture.DisplayMember = "name";
            comManufacture.ValueMember = "name";

            this.comStorhouse.DataSource = serviceDBDrug.GetStorehouseList();
            comStorhouse.DisplayMember = "name";
            comStorhouse.ValueMember = "name";
        }
    }
}
