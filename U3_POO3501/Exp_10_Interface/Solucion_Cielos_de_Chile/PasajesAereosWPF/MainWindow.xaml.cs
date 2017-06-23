using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BibliotecaPasajes;

namespace PasajesAereosWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PasajeAereo[] registro = new PasajeAereo[0];

        public MainWindow()
        {
            InitializeComponent();
            LimpiarControles();
        }

        /// <summary>
        /// Limpia la interfaz y carga la lista
        /// </summary>
        private void LimpiarControles()
        {
            txtNumero.Text = string.Empty;
            dpFechaHora.SelectedDate = DateTime.Now;
            txtHora.Text = string.Empty;
            chkChequeable.IsChecked = false;
            txtPresentacion.Text = string.Empty;

            cboTipo.ItemsSource = Enum.GetValues(typeof(TipoPasaje));
            cboTipo.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            PasajeAereo pasaje = null;

            /* Datos particulares */
            if ((TipoPasaje)cboTipo.SelectedValue == TipoPasaje.Nacional)
            {
                PasajeNacional nacional = new PasajeNacional();
                nacional.Rut = txtRutPasaporte.Text;

                pasaje = nacional;
            }
            else
            {
                PasajeInternacional internacional = new PasajeInternacional();
                internacional.Pasaporte = txtRutPasaporte.Text;

                pasaje = internacional;
            }

            /* Datos comunes */
            pasaje.Numero = txtNumero.Text;
            pasaje.Tipo = (TipoPasaje)cboTipo.SelectedValue;

            /* Obtiene datos para la fecha y hora del vuelo */
            DateTime fecha = (DateTime)dpFechaHora.SelectedDate;
            string[] horaMinuto = txtHora.Text.Split(':');            
            pasaje.FechaVuelo = 
                new DateTime(fecha.Year, 
                    fecha.Month, 
                    fecha.Day, 
                    int.Parse(horaMinuto[0]), 
                    int.Parse(horaMinuto[1]),0 );


            /* Redimensiona y guarda la instancia */
            Array.Resize(ref registro, registro.Length + 1);
            registro[registro.Length - 1] = pasaje;
            /* Carga el registro en la interfaz */
            dgRegistro.ItemsSource = registro;
            dgRegistro.Items.Refresh();
        }

        private void dgRegistro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgRegistro.SelectedIndex != -1)
            {
                IPasaje pasaje = (IPasaje )registro[dgRegistro.SelectedIndex];

                chkChequeable.IsChecked = pasaje.EsChequeable;
                txtPresentacion.Text = pasaje.CalcularHoraPresentacion();
            }
        }
    }
}
