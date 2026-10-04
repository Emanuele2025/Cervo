using System;
using System.Collections.Generic;
using System.Text;

namespace Cervo
{
    public static class Utility
    {

        #region Campi e proprietà



        public const string TitoloFinestra = "Cervo - Programma gratuito per la gestione della firma digitale";
        const string titolo = "Cervo";


        public const string Modifica = "Modifica effettuata con successo. ";

        public const string Inserimento = "Inserimento effettuato con successo. ";

        public const string Errore = "Si è verificato il seguente errore: ";



        #endregion

        #region Messaggi a video


        /// <summary>
        /// Messaggio informativo
        /// </summary>
        /// <param name="testo">testo da visualizzare</param>
        public static void MessaggioInfo(string testo)
        {
            MessageBox.Show(testo, titolo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// MEssaggio di errore
        /// </summary>
        /// <param name="testo"> testo da visualizzare</param>
        public static void MessaggioErrore(string testo)
        {
            MessageBox.Show(testo, titolo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Visualizza un messaggio per cancellare il record
        /// </summary>
        /// <returns>Restituisce SI se è stata scelta la volontà di cancellare record</returns>
        public static bool CancellaRecord()
        {
            return MessageBox.Show("Si è certi di voler eliminare il record selezionato?", titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
        /// <summary>
        /// Messaggio di scelta si e no generico
        /// </summary>
        /// <param name="testo">testo da visualizzare</param>
        /// <returns></returns>
        public static bool MessaggioSiNo(string testo)
        {
            return MessageBox.Show(testo, titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }





        #endregion



    }
}
