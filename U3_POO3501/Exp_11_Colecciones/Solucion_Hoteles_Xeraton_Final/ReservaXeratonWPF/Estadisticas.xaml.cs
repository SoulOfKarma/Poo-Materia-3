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

using BibliotecaHotel;

namespace ReservaXeratonWPF
{
    /// <summary>
    /// Interaction logic for Estadisticas.xaml
    /// </summary>
    public partial class Estadisticas : Window
    {
        public ReservaCollection Reservas { get; set; }

        public Estadisticas()
        {
            InitializeComponent();
        }

        private void btnCantidad_Click(object sender, RoutedEventArgs e)
        {
            int normal = Reservas.ContarPorTipoReserva(TipoReserva.Normal);
            int web = Reservas.ContarPorTipoReserva(TipoReserva.Web);

            txtCantidadNormal.Text = normal.ToString();
            txtCantidadWeb.Text = web.ToString();
        }

        private void btnFechas_Click(object sender, RoutedEventArgs e)
        {
            DateTime menor =  Reservas.MenorFechaReserva();
            DateTime mayor = Reservas.MayorFechaReserva();

            txtMenor.Text = menor.ToString("dd-MM-yyyy");
            txtMayor.Text = mayor.ToString("dd-MM-yyyy");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboTipoHabitacion.ItemsSource = Enum.GetValues(typeof(TipoHabitacion));
            cboTipoHabitacion.SelectedIndex = 0;

            cboTipoReserva.ItemsSource = Enum.GetValues(typeof(TipoReserva));
            cboTipoReserva.SelectedIndex = 0;
        }

        private void btnNumeros_Click(object sender, RoutedEventArgs e)
        {
            if (cboTipoHabitacion.SelectedIndex != -1)
            {
                lstNumeros.ItemsSource = 
                    Reservas.NumerosReservaPorTipoHabitacion((TipoHabitacion)cboTipoHabitacion.SelectedValue);
            }
        }

        private void btnPrecio_Click(object sender, RoutedEventArgs e)
        {
            if (cboTipoReserva.SelectedIndex != -1)
            {
                txtPrecio.Text =
                    Reservas.PromedioPrecioPorTipoReserva((TipoReserva)cboTipoReserva.SelectedValue).ToString();
            }
        }

    }
}
