using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Order
{
    public partial class frmPizzaOrder : Form
    {
        private float Price = 0;
        public frmPizzaOrder()
        {
            InitializeComponent();
        }

        void UpdateSize(string NewValue,bool isChecked)
        {
            if(isChecked)
                lbSize.Text = NewValue;
        }
        void UpdateCrustType(string NewValue, bool isChecked)
        {
            if (isChecked)
                lbCrustType.Text = NewValue;
        }
        void UpdateWhereToEat(string NewValue, bool isChecked)
        {
            if (isChecked)
                lbWhereToEat.Text = NewValue;
        }
        void UpdateTotalPrice(float NewPrice, bool isChecked)
        {
            if(isChecked)
                Price += NewPrice;
            else
                Price -= NewPrice;

            lbPrice.Text = "$" + Price.ToString();
        }
        void ResetToppings()
        {
            foreach (CheckBox checkBox in gbToppings.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
        }
        private void frmPizzaOrder_Load(object sender, EventArgs e)
        {
            foreach(RadioButton rdSize in gbSize.Controls.OfType<RadioButton>())
            {
                if(rdSize.Checked)
                {
                    UpdateTotalPrice(Convert.ToSingle(rdSize.Tag), rdSize.Checked);
                    UpdateSize(rdSize.Text, rdSize.Checked);
                    break;
                }
            }

            foreach (RadioButton rdCrustType in gbCrustType.Controls.OfType<RadioButton>())
            {
                if (rdCrustType.Checked)
                {
                    UpdateTotalPrice(Convert.ToSingle(rdCrustType.Tag), rdCrustType.Checked);
                    UpdateCrustType(rdCrustType.Text, rdCrustType.Checked);
                    break;
                }
            }

            foreach (RadioButton rdWhereToEate in gbWhereToEat.Controls.OfType<RadioButton>())
            {
                if (rdWhereToEate.Checked)
                {
                    UpdateTotalPrice(Convert.ToSingle(rdWhereToEate.Tag), rdWhereToEate.Checked);
                    UpdateWhereToEat(rdWhereToEate.Text, rdWhereToEate.Checked);
                    break;
                }
            }
        }

        private void ChooseSize(object sender, EventArgs e)
        {
            RadioButton rdSize = (RadioButton)sender;

            UpdateSize(rdSize.Text, rdSize.Checked);
            UpdateTotalPrice(Convert.ToSingle(rdSize.Tag), rdSize.Checked);            
        }

        private void UpdateToppings()
        {
            List<string> checkedCheckboxesText = new List<string>();
            foreach(CheckBox checkBox in gbToppings.Controls.OfType<CheckBox>())
            {
                if (checkBox.Checked)
                    checkedCheckboxesText.Add(checkBox.Text);
            }

            if (checkedCheckboxesText.Count == 0)
                lbToppings.Text = "No Toppings";

            else
                lbToppings.Text = string.Join(",", checkedCheckboxesText);
        }
        private void ChooseToppings(object sender, EventArgs e)
        {
            CheckBox chkTopping = (CheckBox)sender;

            UpdateToppings();
            UpdateTotalPrice(Convert.ToSingle(chkTopping.Tag), chkTopping.Checked);            
        }

        private void ChooseCrustType(object sender, EventArgs e)
        {
            RadioButton rdCrustType = (RadioButton)sender;

            UpdateCrustType(rdCrustType.Text, rdCrustType.Checked);
            UpdateTotalPrice(Convert.ToSingle(rdCrustType.Tag), rdCrustType.Checked);
        }

        private void ChooseWhereToEat(object sender, EventArgs e)
        {
            RadioButton rdWhereToEat = (RadioButton)sender;

            UpdateWhereToEat(rdWhereToEat.Text, rdWhereToEat.Checked);
            
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Place Succuessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gbOrder.Enabled = false;
                btnOrderPizza.Enabled = false;
            }
        }
        

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            gbOrder.Enabled = true;
            btnOrderPizza.Enabled = true;
            rdMedium.Checked = true;
            rdThinCrust.Checked = true;
            rdEatIn.Checked = true;
            lbSize.Text = "Medium";
            lbCrustType.Text = "Thin Crust";
            lbWhereToEat.Text = "Eat In";
            lbToppings.Text = "No Toppings";
            ResetToppings();
        }
    }
}
