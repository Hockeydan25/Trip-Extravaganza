using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trip_Extravaganza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }                               //we are declaring several variable globally here to use through the program
        double price = 0;               //declaring a variable price to set the price start for calculations
        double BahaPrice = 1000;        //price for this package Bahamas
        double EuroPrice = 2000;        //price for this package Bahamas
        double TokyoPrice = 3000;       //price for this package Bahamas
        double SarfariPrice = 4000;     //price for this package Bahamas

        double DirectPrice = 1500;      //price for this package Bahamas
        double NonPrice = 2000;         //price for this package Bahamas

        double AdultPrice = 120;        //price for this package Bahamas
        double ChildPrice = 60;         //price for this package Bahamas

        List<string> Vdetails = new List<string>();  //aray list to collect data input for pricing out put to display list box1
        List<string> Vprice = new List<string>();   //aray list to collect data input for pricing out put to display list box 2

        private void btnAddCart_Click(object sender, EventArgs e) //this event IServiceProvider where we star
        {                
                //price for Adult person is added to price if selected. 
                int adults = Convert.ToInt32(cboAdult.SelectedItem);
                int children = Convert.ToInt32(cboChild.SelectedItem);
                double chPrice = children * AdultPrice;
                double adultPrice = adults * ChildPrice;
                DateTime dateStart = Convert.ToDateTime(monthCalendar1.SelectionStart);
                DateTime dateEnd = Convert.ToDateTime(monthCalendar1.SelectionEnd);
                  //price for Adult person is added to price if selected. 
            if (IsValidData())                            //method start to check data validation.
            {
                if (rdoBah.Checked)           // chceks index 0 is checked, and completes if true, this is Large. 
                {                  
                    pictureBox2.Image = Properties.Resources.DK_Hawaii_Lei; //nice picture change to selected package.
                    price = price + BahaPrice;

                    Vdetails.Add("Bahamas Package");
                    Vprice.Add("$" + Convert.ToString(BahaPrice));
                }

                else if (rdoEur.Checked)           // chceks index 0 is checked, and completes if true, this is Large. 
                {
                    pictureBox2.Image = Properties.Resources.swiss;  //nice picture change to selected package.                                      
                    price = price + EuroPrice;
                    Vdetails.Add("European Backpacking Tour");
                    Vprice.Add("$" + Convert.ToString(EuroPrice));
                }

                else if (rdoTok.Checked)           // chceks index 0 is checked, and completes if true, this is Large. 
                {
                    pictureBox2.Image = Properties.Resources.tokyo; //nice picture change to selected package.                                    
                    price = price + TokyoPrice;
                    Vdetails.Add("Tokyo Food Tour");
                    Vprice.Add("$" + Convert.ToString(TokyoPrice));
                }

                else if (rdoSar.Checked)           // chceks index 0 is checked, and completes if true, this is Large. 
                {
                    pictureBox2.Image = Properties.Resources.safari;  //nice picture change to selected package.                   
                    price = price + SarfariPrice;
                    Vdetails.Add("Safari Tour");
                    Vprice.Add("$" + Convert.ToString(SarfariPrice));
                }

                else if (rdoDir.Checked)           // chceks index 0 is checked, and completes if true, this is Large. 
                {
                    rdoNon.Checked = false;
                    price = price + DirectPrice;
                    Vdetails.Add("Direct Flight");
                    Vprice.Add("$" + Convert.ToString(DirectPrice));

                }
                else //if (rdoNon.Checked)           // chceks index 0 is checked, and completes if true, this is Large. 
                {
                    rdoDir.Checked = false;
                    price = price + NonPrice;
                    Vdetails.Add("Flight w/ layover");
                    Vprice.Add("$" + Convert.ToString(NonPrice));
                }
               
                price = price + adultPrice;
                Vprice.Add("$" + Convert.ToString(adultPrice));
                price = price + chPrice;
                Vprice.Add("$" + Convert.ToString(chPrice));

                Vdetails.Add(Convert.ToString(adults) + " adults");      //add to details array
                Vdetails.Add(Convert.ToString(children) + " children");
                Vdetails.Add("From: " + Convert.ToString(dateStart));
                Vdetails.Add("To: " + Convert.ToString(dateEnd));

                foreach (string info in Vdetails)             //loop to load details to listbox1
                {
                    lstDetails.Items.Add(info);
                }
                foreach (string price_info in Vprice) //loop to load pricing to listbox2
                {
                    lstPrice.Items.Add(price_info);
                }
                label8.Text = "Subtotal: $" + Convert.ToString(price);       //label out will show subtotalcost                       
            }
        }
        private bool IsValidData()      //data validation starting 
        {          //checking if any of the radio buttons are check if not requesting one be selected
            if (rdoBah.Checked == false & rdoEur.Checked == false & rdoTok.Checked == false & rdoSar.Checked == false)
            {
                MessageBox.Show("You must select a package.", //message box for no selection of a vacation package
                                "Entry Error");
                rdoBah.Focus();                                 //puts focus to first choice   
                return false;               
            }
            if (rdoDir.Checked == false && rdoNon.Checked == false) //checks they selected a filght type
            {
                MessageBox.Show("You must select a flight.",  
                                "Entry Error");
                rdoDir.Focus();                            //places focus to the flight group box to select one 
                return false;
            }

            else if (monthCalendar1.SelectionStart <= monthCalendar1.SelectionStart) //checks that there is a Start date selected not todays date
            {
                MessageBox.Show("Your Start date can not be todays date.", //MessageBox that tells user to select 
                                "Entry Error");
                monthCalendar1.Focus();                         //places focus to the flight group box to select an end date 
                return false;
            }
                                                        //program continues if date is selected 
                 
            else if (monthCalendar1.SelectionEnd == monthCalendar1.SelectionStart) //checks that there is a end date selected
            {
                MessageBox.Show("You must select an end date.", //MessageBox that tells user to select 
                                "Entry Error");
                monthCalendar1.Focus();                         //places focus to the flight group box to select an end date 
                return false;                                  
            }

            return true;                                    //program continues if date is selected 
        }
        private void btnClear_Click(object sender, EventArgs e)// clear button, clears vacation extravaganza
        {
            pictureBox2.Image = Properties.Resources.Vacation; // reseting the pictur to start.
            
            cboAdult.SelectedIndex = 0;                //defalut is 0 equals 1 adult.
            cboChild.SelectedIndex = 0;                //defalut is 0 equals 0 children.         

            Vprice.Clear();                         // clear button, clears vacation extravaganza.
            Vdetails.Clear();                       // clear button, clears vacation extravaganza.
            lstPrice.Items.Clear();                 // clear button, clears vacation extravaganza .   
            lstDetails.Items.Clear();

            rdoDir.Checked = false;              //more clearing out button checks for refresh.
            rdoNon.Checked = false;
            rdoBah.Checked = false;
            rdoEur.Checked = false;
            rdoSar.Checked = false;
            rdoTok.Checked = false;

            label8.Text = "Vacation Price: ";                 // clear button, clears vacation extravaganza.
            lstPrice.Text = "Subtotal: $0.00";      // clear button, clears vacation extravaganza.
            price = 0;
        }

        private void button2_Click(object sender, EventArgs e)// exit button, close vacation extravaganza.
        {
            this.Close();        
        }

        private void Form1_Load(object sender, EventArgs e)  //FormLoad seting the combo box defaluts.
        {
            cboAdult.SelectedIndex = 0; //defalut is 0 equals 1 adult.
            cboChild.SelectedIndex = 0; //defalut is 0 equals 0 children.
        }
    }
}
