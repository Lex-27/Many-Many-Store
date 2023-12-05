using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Point_of_Sale
{
    public partial class UserForm : Form
    {
        public static decimal total;
        public static decimal payment = 0.00m;
        public static decimal sukli = 0.00m;
        public static ArrayList listData = new ArrayList();
        

        //product quantity
        private static int prdt_One = 1;
        private static int prdt_Two = 1;
        private static int prdt_Three = 1;
        private static int prdt_Four = 1;
        private static int prdt_Five = 1;
        private static int prdt_Six = 1;
        private static int prdt_Seven = 1;
        private static int prdt_Eight = 1;
        private static int prdt_Nine = 1;
        private static int prdt_Ten = 1;
        private static int prdt_Eleven = 1;
        private static int prdt_Twelve = 1;
        private static int prdt_Thirteen = 1;
        private static int prdt_Fourteen = 1;
        private static int prdt_Fifthteen = 1;
        private static int prdt_Sixteen = 1;
        private static int prdt_Seventeen = 1;
        private static int prdt_Eighteen = 1;

        //products Prices
        const decimal priceCB = 33.00m;     //cornbeef
        const decimal pricePC = 16.00m;     //pancit canton
        const decimal priceFT = 27.00m;     //fresca tuna
        const decimal priceSS = 19.50m;     //soy sauce
        const decimal pricePS = 12.00m;     //pepsi small
        const decimal pricePB = 40.00m;     //pepsi big
        const decimal priceRS = 12.00m;     //royal small
        const decimal priceRB = 40.00m;     //royal big
        const decimal priceMDs = 18.00m;     //mountain dew
        const decimal price_Piatos = 16.00m;     //piatos
        const decimal price_Nova = 16.00m;     //Nova
        const decimal price_Chips = 8.00m;     //Mr. Chips
        const decimal price_SG = 29.00m;     //Safeguard
        const decimal price_CG = 65.00m;     //Colgate
        const decimal price_HnH = 8.00m;     //Head & Shoulders
        const decimal price_Surf = 7.00m;     //Surf
        const decimal price_Blanca = 11.00m;     //KOPIKO Blanca
        const decimal price_Orig = 16.00m;     //NESCAFE Original


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public UserForm()
        {
            InitializeComponent();
            
            //creates a rounded corner
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            
            //remove mouse over change color
            logoutBtn.FlatAppearance.MouseOverBackColor = logoutBtn.BackColor;
            logoutBtn.BackColorChanged += (s, e) => {
                logoutBtn.FlatAppearance.MouseOverBackColor = logoutBtn.BackColor;
            };
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                var loginform = new LoginForm();
                loginform.ShowDialog();
                this.Close();
            }
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        //clocks timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }


        //the following methods are the checkbox checker
        private void pancitCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Lucky Me Pancit Canton \t₱ {pricePC}   {prdt_One}x";
            string rcptString = $"LMPancitCanton \t\t   x{prdt_One}\t\t      {pricePC}";
            

            if (pancitCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_One, pricePC);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_One, pricePC);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
                
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void cornBfCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Youngstown Corned Beef \t₱ {priceCB}   {prdt_Two}x";
            string rcptString = $"YgTCornedbeef  \t\t   x{prdt_Two}\t\t      {priceCB}";

            if (cornbefCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Two, priceCB);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Two, priceCB);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
                
            }
            string txt = total.ToString();
            if(total > 0)
                totalAmt.Text = txt;
        }
        private void frescaCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Fresca Tuna Caldereta \t₱ {priceFT}   {prdt_Three}x";
            string rcptString = $"FrescaTuna     \t\t   x{prdt_Three}\t\t      {priceFT}";

            if (frescaCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Three, priceFT);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Three, priceFT);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void soySauceCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"SilverSwan SoySauce \t₱ {priceSS}   {prdt_Four}x";
            string rcptString = $"SiverSwanSoy   \t\t   x{prdt_Four}\t\t      {priceSS}";

            if (soySauceCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Four, priceSS);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Four, priceSS);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void pepsiSmlCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Pepsi 12oz \t\t₱ {pricePS}   {prdt_Five}x";
            string rcptString = $"Pepsi 12oz     \t\t   x{prdt_Five}\t\t      {pricePS}";

            if (pepsiSmlCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Five, pricePS);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Five, pricePS);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void pepsiBigCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Pepsi 1 Liter \t\t₱ {pricePB}   {prdt_Six}x";
            string rcptString = $"Pepsi 1 Liter  \t\t   x{prdt_Six}\t\t      {pricePB}";

            if (pepsiBigCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Six, pricePB);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Six, pricePB);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void royalBigCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Royal 1 Liter \t\t₱ {priceRB}   {prdt_Seven}x";
            string rcptString = $"Royal 1 Liter  \t\t   x{prdt_Seven}\t\t      {priceRB}";

            if (royalBigCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Seven, priceRB);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Seven, priceRB);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void royalSmlCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Royal 12oz \t\t₱ {priceRS}   {prdt_Eight}x";
            string rcptString = $"Royal 12oz     \t\t   x{prdt_Eight}\t\t      {priceRS}";

            if (royalSmlCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Eight, priceRS);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Eight, priceRS);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void mountainDewCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"MountainDew 12oz \t\t₱ {priceMDs}   {prdt_Nine}x";
            string rcptString = $"MountainDew 12oz     \t   x{prdt_Nine}\t\t      {priceMDs}";

            if (mountainDewCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Nine, priceMDs);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Nine, priceMDs);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void piatosCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Piatos  \t\t\t₱ {price_Piatos}   {prdt_Ten}x";
            string rcptString = $"Piatos     \t\t   x{prdt_Ten}\t\t      {price_Piatos}";

            if (piatosCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Ten, price_Piatos);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Ten, price_Piatos);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void novaCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Nova  \t\t\t₱ {price_Nova}   {prdt_Eleven}x";
            string rcptString = $"Nova     \t\t   x{prdt_Eleven}\t\t      {price_Nova}";

            if (novaCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Eleven, price_Nova);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Eleven, price_Nova);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void chipsCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Mr. Chips  \t\t₱ {price_Chips}     {prdt_Twelve}x";
            string rcptString = $"Mr. Chips     \t\t   x{prdt_Twelve}\t\t      {price_Chips}";

            if (chipsCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Twelve, price_Chips);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Twelve, price_Chips);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void safeGCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Safeguard  \t\t₱ {price_SG}   {prdt_Thirteen}x";
            string rcptString = $"Safeguard     \t\t   x{prdt_Thirteen}\t\t      {price_SG}";

            if (safeGCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Thirteen, price_SG);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Thirteen, price_SG);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void colgateCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Colgate  \t\t\t₱ {price_CG}   {prdt_Fourteen}x";
            string rcptString = $"Colgate     \t\t   x{prdt_Fourteen}\t\t      {price_CG}";

            if (colgateCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Fourteen, price_CG);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Fourteen, price_CG);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void HnHCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Head & Shoulders  \t\t₱ {price_HnH}     {prdt_Fifthteen}x";
            string rcptString = $"Head & Shoulders     \t   x{prdt_Fifthteen}\t\t      {price_HnH}";

            if (HnHCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Fifthteen, price_HnH);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Fifthteen, price_HnH);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void surfCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"Surf  \t\t\t₱ {price_Surf}     {prdt_Sixteen}x";
            string rcptString = $"Surf     \t\t   x{prdt_Sixteen}\t\t      {price_Surf}";

            if (surfCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Sixteen, price_Surf);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Sixteen, price_Surf);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void blancaCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"KOPIKO Blanca  \t\t₱ {price_Blanca}   {prdt_Seventeen}x";
            string rcptString = $"KOPIKO Blanca     \t   x{prdt_Seventeen}\t\t      {price_Blanca}";

            if (blancaCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Seventeen, price_Blanca);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Seventeen, price_Blanca);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }
        private void origCKAdd_CheckedChanged(object sender, EventArgs e)
        {
            string cbxString = $"NESCAFE Original  \t\t₱ {price_Orig}   {prdt_Eighteen}x";
            string rcptString = $"NESCAFE Original     \t   x{prdt_Eighteen}\t\t      {price_Orig}";

            if (origCKAdd.Checked)
            {
                listCart.Items.Add(cbxString);
                looper_AddQuant(prdt_Eighteen, price_Orig);
                savePrdt_to_Array(rcptString);
            }
            else
            {
                listCart.Items.Remove(cbxString);
                looper_MinusQuant(prdt_Eighteen, price_Orig);
                removePrdt_from_Array(rcptString);
                totalAmt.Text = "";
            }
            string txt = total.ToString();
            if (total > 0)
                totalAmt.Text = txt;
        }



        //this method clears the listbox or the cart
        private void clrBtn_Click(object sender, EventArgs e)
        {
            listCart.Items.Clear();
            pancitCKAdd.Checked = false;
            cornbefCKAdd.Checked = false;
            frescaCKAdd.Checked = false;
            soySauceCKAdd.Checked = false;
            pepsiSmlCKAdd.Checked = false;
            pepsiBigCKAdd.Checked = false;
            royalBigCKAdd.Checked = false;
            royalSmlCKAdd.Checked = false;
            mountainDewCKAdd.Checked = false;
            piatosCKAdd.Checked = false;
            novaCKAdd.Checked = false;
            chipsCKAdd.Checked = false;
            safeGCKAdd.Checked = false;
            colgateCKAdd.Checked = false;
            HnHCKAdd.Checked = false;
            surfCKAdd.Checked = false;
            blancaCKAdd.Checked = false;
            origCKAdd.Checked = false;

            totalAmt.Text = "";
            payInput.Text = "";
            change.Text = "";
            sukli = 0.00m;
            total = 0.00m;

            
        }




        //decreases the quantity of a product
        private void minusQuanty_Click(object sender, EventArgs e)
        {
            if (!pancitCKAdd.Checked)
            {
                if (prdt_One >= 2)
                    prdt_One--;

                quanttyPrduc1.Text = prdt_One.ToString();
            }
        }
        private void minusQuanty2_Click(object sender, EventArgs e)
        {
            if (!cornbefCKAdd.Checked)
            {
                if (prdt_Two >= 2)
                    prdt_Two--;

                quanttyPrduc2.Text = prdt_Two.ToString();
            }
        }
        private void minusQuanty3_Click(object sender, EventArgs e)
        {
            if (!frescaCKAdd.Checked)
            {
                if (prdt_Three >= 2)
                    prdt_Three--;

                quanttyPrduc3.Text = prdt_Three.ToString();
            }
        }
        private void minusQuanty4_Click(object sender, EventArgs e)
        {
            if (!soySauceCKAdd.Checked)
            {
                if (prdt_Four >= 2)
                    prdt_Four--;

                quanttyPrduc4.Text = prdt_Four.ToString();
            }
        }
        private void minusQuanty5_Click(object sender, EventArgs e)
        {
            if (!pepsiSmlCKAdd.Checked)
            {
                if (prdt_Five >= 2)
                    prdt_Five--;

                quanttyPrduc5.Text = prdt_Five.ToString();
            }
        }
        private void minusQuanty6_Click(object sender, EventArgs e)
        {
            if (!pepsiBigCKAdd.Checked)
            {
                if (prdt_Six >= 2)
                    prdt_Six--;

                quanttyPrduc6.Text = prdt_Six.ToString();
            }
        }
        private void minusQuanty7_Click(object sender, EventArgs e)
        {
            if (!royalBigCKAdd.Checked)
            {
                if (prdt_Seven >= 2)
                    prdt_Seven--;

                quanttyPrduc7.Text = prdt_Seven.ToString();
            }
        }
        private void minusQuanty8_Click(object sender, EventArgs e)
        {
            if (!royalSmlCKAdd.Checked)
            {
                if (prdt_Eight >= 2)
                    prdt_Eight--;

                quanttyPrduc8.Text = prdt_Eight.ToString();
            }
        }
        private void minusQuanty9_Click(object sender, EventArgs e)
        {
            if (!mountainDewCKAdd.Checked)
            {
                if (prdt_Nine >= 2)
                    prdt_Nine--;

                quanttyPrduc9.Text = prdt_Nine.ToString();
            }
        }
        private void minusQuanty10_Click(object sender, EventArgs e)
        {
            if (!piatosCKAdd.Checked)
            {
                if (prdt_Ten >= 2)
                    prdt_Ten--;

                quanttyPrduc10.Text = prdt_Ten.ToString();
            }
        }
        private void minusQuanty11_Click(object sender, EventArgs e)
        {
            if (!novaCKAdd.Checked)
            {
                if (prdt_Eleven >= 2)
                    prdt_Eleven--;

                quanttyPrduc11.Text = prdt_Eleven.ToString();
            }
        }
        private void minusQuanty12_Click(object sender, EventArgs e)
        {
            if (!chipsCKAdd.Checked)
            {
                if (prdt_Twelve >= 2)
                    prdt_Twelve--;

                quanttyPrduc12.Text = prdt_Twelve.ToString();
            }
        }
        private void minusQuanty13_Click(object sender, EventArgs e)
        {
            if (!safeGCKAdd.Checked)
            {
                if (prdt_Thirteen >= 2)
                    prdt_Thirteen--;

                quanttyPrduc13.Text = prdt_Thirteen.ToString();
            }
        }
        private void minusQuanty14_Click(object sender, EventArgs e)
        {
            if (!colgateCKAdd.Checked)
            {
                if (prdt_Fourteen >= 2)
                    prdt_Fourteen--;

                quanttyPrduc14.Text = prdt_Fourteen.ToString();
            }
        }
        private void minusQuanty15_Click(object sender, EventArgs e)
        {
            if (!HnHCKAdd.Checked)
            {
                if (prdt_Fifthteen >= 2)
                    prdt_Fifthteen--;

                quanttyPrduc15.Text = prdt_Fifthteen.ToString();
            }
        }
        private void minusQuanty16_Click(object sender, EventArgs e)
        {
            if (!surfCKAdd.Checked)
            {
                if (prdt_Sixteen >= 2)
                    prdt_Sixteen--;

                quanttyPrduc16.Text = prdt_Sixteen.ToString();
            }
        }
        private void minusQuanty17_Click(object sender, EventArgs e)
        {
            if (!blancaCKAdd.Checked)
            {
                if (prdt_Seventeen >= 2)
                    prdt_Seventeen--;

                quanttyPrduc17.Text = prdt_Seventeen.ToString();
            }
        }
        private void minusQuanty18_Click(object sender, EventArgs e)
        {
            if (!origCKAdd.Checked)
            {
                if (prdt_Eighteen >= 2)
                    prdt_Eighteen--;

                quanttyPrduc18.Text = prdt_Eighteen.ToString();
            }
        }

        //increases the quantity of a product
        private void addQuanty_Click(object sender, EventArgs e)
        {
            if (!pancitCKAdd.Checked)
            {
                prdt_One++;
                quanttyPrduc1.Text = prdt_One.ToString();
            }
        }
        private void addQuanty2_Click(object sender, EventArgs e)
        {
            if (!cornbefCKAdd.Checked)
            {
                prdt_Two++;
                quanttyPrduc2.Text = prdt_Two.ToString();
            }
        }
        private void addQuanty3_Click(object sender, EventArgs e)
        {
            if (!frescaCKAdd.Checked)
            {
                prdt_Three++;
                quanttyPrduc3.Text = prdt_Three.ToString();
            }
        }
        private void addQuanty4_Click(object sender, EventArgs e)
        {
            if (!soySauceCKAdd.Checked)
            {
                prdt_Four++;
                quanttyPrduc4.Text = prdt_Four.ToString();
            }
        }
        private void addQuanty5_Click(object sender, EventArgs e)
        {
            if (!pepsiSmlCKAdd.Checked)
            {
                prdt_Five++;
                quanttyPrduc5.Text = prdt_Five.ToString();
            }
        }
        private void addQuanty6_Click(object sender, EventArgs e)
        {
            if (!pepsiBigCKAdd.Checked)
            {
                prdt_Six++;
                quanttyPrduc6.Text = prdt_Six.ToString();
            }
        }
        private void addQuanty7_Click(object sender, EventArgs e)
        {
            if (!royalBigCKAdd.Checked)
            {
                prdt_Seven++;
                quanttyPrduc7.Text = prdt_Seven.ToString();
            }
        }
        private void addQuanty8_Click(object sender, EventArgs e)
        {
            if (!royalSmlCKAdd.Checked)
            {
                prdt_Eight++;
                quanttyPrduc8.Text = prdt_Eight.ToString();
            }
        }
        private void addQuanty9_Click(object sender, EventArgs e)
        {
            if (!mountainDewCKAdd.Checked)
            {
                prdt_Nine++;
                quanttyPrduc9.Text = prdt_Nine.ToString();
            }
        }
        private void addQuanty10_Click(object sender, EventArgs e)
        {
            if (!piatosCKAdd.Checked)
            {
                prdt_Ten++;
                quanttyPrduc10.Text = prdt_Ten.ToString();
            }
        }
        private void addQuanty11_Click(object sender, EventArgs e)
        {
            if (!novaCKAdd.Checked)
            {
                prdt_Eleven++;
                quanttyPrduc11.Text = prdt_Eleven.ToString();
            }
        }
        private void addQuanty12_Click(object sender, EventArgs e)
        {
            if (!chipsCKAdd.Checked)
            {
                prdt_Twelve++;
                quanttyPrduc12.Text = prdt_Twelve.ToString();
            }
        }
        private void addQuanty13_Click(object sender, EventArgs e)
        {
            if (!safeGCKAdd.Checked)
            {
                prdt_Thirteen++;
                quanttyPrduc13.Text = prdt_Thirteen.ToString();
            }
        }
        private void addQuanty14_Click(object sender, EventArgs e)
        {
            if (!colgateCKAdd.Checked)
            {
                prdt_Fourteen++;
                quanttyPrduc14.Text = prdt_Fourteen.ToString();
            }
        }
        private void addQuanty15_Click(object sender, EventArgs e)
        {
            if (!HnHCKAdd.Checked)
            {
                prdt_Fifthteen++;
                quanttyPrduc15.Text = prdt_Fifthteen.ToString();
            }
        }
        private void addQuanty16_Click(object sender, EventArgs e)
        {
            if (!surfCKAdd.Checked)
            {
                prdt_Sixteen++;
                quanttyPrduc16.Text = prdt_Sixteen.ToString();
            }
        }
        private void addQuanty17_Click(object sender, EventArgs e)
        {
            if (!blancaCKAdd.Checked)
            {
                prdt_Seventeen++;
                quanttyPrduc17.Text = prdt_Seventeen.ToString();
            }
        }
        private void addQuanty18_Click(object sender, EventArgs e)
        {
            if (!origCKAdd.Checked)
            {
                prdt_Eighteen++;
                quanttyPrduc18.Text = prdt_Eighteen.ToString();
            }
        }



        //checks the payment of the buyer if
        //its enough or not
        //also calculates the changes if the payment is larger than the total price to pay
        private void payInput_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (payInput.Text != null && total != 0)
                {
                    sukli = Convert.ToDecimal(payInput.Text) - total;
                    payment = Convert.ToDecimal(payInput.Text);
                    
                }
                else 
                {
                    change.Text = "";
                }

                if (sukli <= 0)
                {
                    change.Text = "0.00";
                }
                else if (sukli >= 1)
                {
                    string s = sukli.ToString();
                    change.Text = s;
                }

                if(payInput.Text == null || payInput.Text == "")
                {
                    change.Text = "";
                }
            } catch { }

        }



        //this button checks if cart is empty or not
        // also checks if you inputed enough payment or not
        private void buyBtn_Click(object sender, EventArgs e)
        {
            if (payment >= total && total != 0)
            {
                ReceiptForm receiptForm = new ReceiptForm();
                receiptForm.SetListData(listData);

                sukli = 0.00m;

                receiptForm.Show();
            }
            else if (total != 0)
            {
                MessageBox.Show("Payment Not Enough!", " ⚠️ Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Your'e cart is Empty!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        //own Methods
        private void looper_AddQuant(int quantt, decimal price) 
        {
            int num = quantt;
            for (int i = 0; i < num; num--) 
            {
                total += price;
                
            }
            
        }
        private void looper_MinusQuant(int quantt, decimal price)
        {
            int num = quantt;
            for (int i = 0; i < num; num--)
            {
                total -= price;
                
            }
        }

        private void savePrdt_to_Array(string txt) 
        {
            listData.Add(txt);
        }
        private void removePrdt_from_Array(string txt) 
        {
            listData.Remove(txt);
        }

        
    }
}
