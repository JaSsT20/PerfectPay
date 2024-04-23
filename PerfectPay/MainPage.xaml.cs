namespace PerfectPay
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int people = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = Convert.ToDecimal(txtBill.Text);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var totalTip = (bill * tip) / 100;

            var tipByPerson = totalTip / people;

            lblTipByPerson.Text = $"Tip by person: {tipByPerson:C}";

            var subtotal = bill / people;
            lblSubTotal.Text = $"{subtotal:C}";

            var totalByPerson = (bill + totalTip) / people;
            lblTotal.Text = $"{totalByPerson:C}";



        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;
            lblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void ButtonTip_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                var percent = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = percent;
            }
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if(people > 1)
            {
                people--;
                lblPeopleAmount.Text = people.ToString();
                CalculateTotal();
            }
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            people++;
            lblPeopleAmount.Text = people.ToString();
            CalculateTotal();
        }
    }

}
