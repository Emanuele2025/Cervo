namespace Cervo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: gestione dei file da leggere
            //TODO: mettere un menu
            //TODO: file di utility
            //TODO: file informativa
            this.Text = Utility.TitoloFinestra;
        }

        private void MniEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MniStrumenti_Click(object sender, EventArgs e)
        {
            FrmStrumenti strumenti = new FrmStrumenti();
            strumenti.ShowDialog();
        }
    }
}
