using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Cervo
{
    public partial class FrmStrumenti : Form
    {
        public FrmStrumenti()
        {
            InitializeComponent();
        }

        private void FrmStrumenti_Load(object sender, EventArgs e)
        {

        }



        private void TrovaCertificato()
        {

            try
            {
                X509Store storeX509 = new X509Store(StoreName.AddressBook, StoreLocation.CurrentUser);
                storeX509.Open(OpenFlags.MaxAllowed);
                X509Certificate2 certificato = storeX509.Certificates.Find(X509FindType.FindBySubjectName, "Emanuele", true)[0];
            }
            catch (Exception ex)
            {

                throw;
            }
        
        
        
        
        
        }




    }
}
