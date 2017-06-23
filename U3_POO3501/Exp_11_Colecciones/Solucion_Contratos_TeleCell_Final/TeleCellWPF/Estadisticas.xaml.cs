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
using System.Windows.Shapes;

using BibliotecaTeleCell;

namespace TeleCellWPF
{
    /// <summary>
    /// Interaction logic for Estadisticas.xaml
    /// </summary>
    public partial class Estadisticas : Window
    {
        public ContratoCollection Registro { get; set; }

        public Estadisticas()
        {
            InitializeComponent();

            CargaContratos();
        }

        private void CargaContratos()
        {
            cboContrato.ItemsSource = Enum.GetValues(typeof(TipoContrato));
            cboContrato.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MostrarPorTipo();
        }

        private void MostrarPorTipo()
        {
            txtPrepago.Text = Registro.ContarPorTipoContrato(TipoContrato.Prepago).ToString();
            txtPostpago.Text = Registro.ContarPorTipoContrato(TipoContrato.Postpago).ToString();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ContratoBase contrato = Registro.BuscarPorNumero(int.Parse(txtNumero.Text));

            if( contrato != null)
            {
                txtNumero.Text = contrato.Numero.ToString();
                dpFechaContrato.SelectedDate = contrato.FechaContrato;
                txtNombre.Text = contrato.NombreTitular;
                chkEquipo.IsChecked = contrato.EquipoPropio;
                cboContrato.SelectedValue = contrato.Tipo;
            }
            else
            {
                MessageBox.Show("Número no encontrado");
            }
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            txtSuma.Text = Registro.SumarPrecioPostpago().ToString();
            txtPromedio.Text = Registro.PromedioPrecioPostpago().ToString();
        }

    }
}
