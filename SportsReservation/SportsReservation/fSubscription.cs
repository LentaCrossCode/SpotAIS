using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsReservation
{
    public partial class fSubscription : MetroFramework.Forms.MetroForm
    {
        String operation;
        Double firstnum;
        Double secondnum;
        Double answer;
        

        Double swimming;
        Double dance;
        Double fitness;
        Double yoga;
        Double training;

        Double EURO = 0.01603;
        Double British_frank = 0.01360;
        Double Grivna_Ukrainia = 0.46347;
        Double zlatie_Polen = 0.0676;
        Double schwetz_frank = 0.01755;

        public fSubscription()
        {
            InitializeComponent();
        }

        private void reservation_SystemBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.reservation_SystemBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.orderDataSet);

        }

        private void fMain_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "orderDataSet.Reservation_System". При необходимости она может быть перемещена или удалена.
            this.reservation_SystemTableAdapter.Fill(this.orderDataSet.Reservation_System);
            mcbCurrency.Text = "Выберите валюту";
            mcbCurrency.Items.Add("Евро");
            mcbCurrency.Items.Add("Британский франк");
            mcbCurrency.Items.Add("Украинская гривна");
            mcbCurrency.Items.Add("Польские златые");
            mcbCurrency.Items.Add("Швецкий франк");

            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/MM/yyyy");
            order_TimeTextBox.Text = iDate.ToString("HH:mm:ss");

            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";
            qty4TextBox.Text = "0";
            qty5TextBox.Text = "0";

            unit_Price1TextBox.Text = "0" ;
            unit_Price2TextBox.Text = "0" ;
            unit_Price3TextBox.Text = "0" ;
            unit_Price4TextBox.Text = "0" ;
            unit_Price5TextBox.Text = "0" ;

            

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (lblDisplay.Text == "0")
                lblDisplay.Text = num.Text;
            else
                lblDisplay.Text = lblDisplay.Text + num.Text;

        }

        private void Calc_Operators_Click(object sender, EventArgs e)
        {
            Button ops = (Button)sender;
            firstnum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = " ";
            operation = ops.Text;
            lblShowCalc.Text = System.Convert.ToString(firstnum) + " " + operation;

        }

        private void mbtnEquals_Click(object sender, EventArgs e)
        {
            lblShowCalc.Text = "";
            secondnum = Double.Parse(lblDisplay.Text);
            switch (operation)
            {
                case "+":
                    answer = (firstnum + secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                case "-":
                    answer = (firstnum - secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                case "*":
                    answer = (firstnum * secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                case "/":
                    answer = (firstnum / secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                default:
                    break;
            }
        }

        private void mbtnBackspace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
        }

        private void mmbtDot_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (num.Text == ",")
            {
                if (!lblDisplay.Text.Contains(","))
                    lblDisplay.Text = lblDisplay.Text + num.Text;
            }
        }

        private void mbtnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            lblShowCalc.Text = "";
            lblDisplay.Text = "0";
        }
        private void CurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbtnCurrency.Visible = false;
        }

        private void mbtnCurrency_Click(object sender, EventArgs e)
        {
            mbtnCurrency.Visible = false;
        }


        private void StandartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbtnCurrency.Visible = true;
        }

        private void metroButtonCloseConverter_Click(object sender, EventArgs e)
        {
            mbtnCurrency.Visible = true;
        }

        private void metroButtonReset_Click(object sender, EventArgs e)
        {
            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";
            qty4TextBox.Text = "0";
            qty5TextBox.Text = "0";


            unit_Price1TextBox.Text = "0";
            unit_Price2TextBox.Text = "0";
            unit_Price3TextBox.Text = "0";
            unit_Price4TextBox.Text = "0";
            unit_Price5TextBox.Text = "0";


            sub_Total1TextBox.Text = "";
            sub_Total2TextBox.Text = "";
            sub_Total3TextBox.Text = "";
            sub_Total4TextBox.Text = "";
            sub_Total5TextBox.Text = "";

            net_Sub_TotalTextBox.Text = "";
            

            customer_NameTextBox.Text = "";
            customer_PhoneTextBox.Text = "";
            order_Ref_IdTextBox.Text = "";

        }

        private void metroButtonAddToBasket_Click(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/MM/yyyy");
            order_TimeTextBox.Text = iDate.ToString("HH:mm:ss");
            tabControl1.SelectedTab = tabPageReicept;
            txtReicept.AppendText("\t\t\t" + "Спортивный абонемент" + Environment.NewLine);
            txtReicept.AppendText("\t\t\t" + "============================================" + Environment.NewLine);
            txtReicept.AppendText("\t\t\t " + Environment.NewLine);
            txtReicept.AppendText(" Имя клиента:" + "\t" + customer_NameTextBox.Text + "\t" + "Номер телефона:" + customer_PhoneTextBox.Text + "\t" + "\n Номер брони:" + "\t" + order_Ref_IdTextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + " Вид спорта: " + "\t" + "Занятий: " + "\t" + "Цена: " + "\t" + "Стоимость: " + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + " Плавание " + "\t\t" + qty1TextBox.Text + "\t" + unit_Price1TextBox.Text + "\t" + sub_Total1TextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + " Танцы    " + "\t\t" + qty2TextBox.Text + "\t" + unit_Price2TextBox.Text + "\t" + sub_Total2TextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + " Фитнес   " + "\t\t" + qty3TextBox.Text + "\t" + unit_Price3TextBox.Text + "\t" + sub_Total3TextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + " Йога     " + "\t\t" + qty4TextBox.Text + "\t" + unit_Price4TextBox.Text + "\t" + sub_Total4TextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + " Спортзал " + "\t\t" + qty5TextBox.Text + "\t" + unit_Price5TextBox.Text + "\t" + sub_Total5TextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + "\t\t\t" + "Стоимость:" + "\t" + net_Sub_TotalTextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + "\t\t\t" + "Дата бронированияь:" + "\t" + order_DateTextBox.Text + Environment.NewLine);
            txtReicept.AppendText(Environment.NewLine + "\t\t\t" + "Время бронирования:" + "\t" + order_TimeTextBox.Text + Environment.NewLine);
            txtReicept.AppendText("\t\t\t" + "============================================" + Environment.NewLine);
            txtReicept.AppendText("\t\t\t" + "Спортивный абонемент" + Environment.NewLine);

        }
        private void metroButtonCalculate_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageCalculate;
        }

        private void metroButtonReservation_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPagedataBase;
        }

        private void metroButtonReicept_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageReicept;
        }

        private void metroButtonSave_Click(object sender, EventArgs e)
        {


            tabControl1.SelectedTab = tabPagedataBase;
            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/MM/yyyy");
            order_TimeTextBox.Text = iDate.ToString("HH:mm:ss");
            this.Validate();
            this.reservation_SystemBindingSource.EndEdit();


        }

        private void metroButtonTotal_Click(object sender, EventArgs e)
        {
            Double nswimming;
            Double ndance;
            Double nfitness;
            Double nyoga;
            Double ntraining;
            Double unitprice1;
            Double unitprice2;
            Double unitprice3;
            Double unitprice4;
            Double unitprice5;


            nswimming = Double.Parse(qty1TextBox.Text);
            ndance = Double.Parse(qty2TextBox.Text);
            nfitness = Double.Parse(qty3TextBox.Text);
            nyoga = Double.Parse(qty4TextBox.Text);
            ntraining = Double.Parse(qty5TextBox.Text);

            unitprice1 = Double.Parse(unit_Price1TextBox.Text);
            unitprice2 = Double.Parse(unit_Price2TextBox.Text);
            unitprice3 = Double.Parse(unit_Price3TextBox.Text);
            unitprice4 = Double.Parse(unit_Price4TextBox.Text);
            unitprice5 = Double.Parse(unit_Price5TextBox.Text);

            swimming = nswimming * unitprice1;
            dance = ndance * unitprice2;
            fitness = nfitness * unitprice3;
            yoga = nyoga * unitprice4;
            training = ntraining * unitprice5;

            sub_Total1TextBox.Text = System.Convert.ToString(swimming);
            sub_Total2TextBox.Text = System.Convert.ToString(dance);
            sub_Total3TextBox.Text = System.Convert.ToString(fitness);
            sub_Total4TextBox.Text = System.Convert.ToString(yoga);
            sub_Total5TextBox.Text = System.Convert.ToString(training);

            net_Sub_TotalTextBox.Text = System.Convert.ToString(swimming + dance + fitness + yoga + training);
            

            unit_Price1TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price1TextBox.Text));
            unit_Price2TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price2TextBox.Text));
            unit_Price3TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price3TextBox.Text));
            unit_Price4TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price4TextBox.Text));
            unit_Price5TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price5TextBox.Text));

            sub_Total1TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total1TextBox.Text));
            sub_Total2TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total2TextBox.Text));
            sub_Total3TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total3TextBox.Text));
            sub_Total4TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total4TextBox.Text));
            sub_Total5TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total5TextBox.Text));

            net_Sub_TotalTextBox.Text = String.Format("{0:c}", Double.Parse(net_Sub_TotalTextBox.Text));
           

        }

        private void metroButtonConvert_Click(object sender, EventArgs e)
        {            
            Double Russian_rubl = Double.Parse(metroTextBoxCurrency.Text);

            if (mcbCurrency.Text == ("Евро"))
            {
                labelConvert.Text = System.Convert.ToString((Russian_rubl * EURO));

            }
            if (mcbCurrency.Text == ("Британский франк"))
            {
                labelConvert.Text = System.Convert.ToString((Russian_rubl * British_frank));

            }
            if (mcbCurrency.Text == ("Украинская гривна"))
            {
                labelConvert.Text = System.Convert.ToString((Russian_rubl * Grivna_Ukrainia));

            }
            if (mcbCurrency.Text == ("Польские златые"))
            {
                labelConvert.Text = System.Convert.ToString((Russian_rubl * zlatie_Polen));

            }
            if (mcbCurrency.Text == ("Швецкий франк"))
            {
                labelConvert.Text = System.Convert.ToString((Russian_rubl * schwetz_frank));

            }
            
        }

        private void mbtnAddNew_Click(object sender, EventArgs e)
        {
            this.reservation_SystemBindingSource.AddNew();
        }

        private void mbtnSet_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.reservation_SystemBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.orderDataSet);
        }

        private void mbtnRemove_Click(object sender, EventArgs e)
        {
            this.reservation_SystemBindingSource.RemoveCurrent();
        }

        private void mbtnNext_Click(object sender, EventArgs e)
        {
            reservation_SystemBindingSource.MoveNext();
        }

        private void mbtnPrevious_Click(object sender, EventArgs e)
        {
            reservation_SystemBindingSource.MovePrevious();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа АИС спорткомплекс. \nАвтор: Воронина Е.В. ", "О программе ");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPagedataBase;
        }
    }
}                                 
               
     