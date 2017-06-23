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

using BibliotecaHotel;

namespace ReservaXeratonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReservaBase[] reservas = new ReservaBase[0];

        public MainWindow()
        {
            InitializeComponent();

            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtNumero.Text = string.Empty;
            dpReserva.SelectedDate = DateTime.Now;
            dpInicio.SelectedDate = DateTime.Now;
            dpTermino.SelectedDate = DateTime.Now;

            CargarListas();
        }

        private void CargarListas()
        {
            cboTipo.ItemsSource = Enum.GetValues(typeof(TipoReserva));
            cboTipo.SelectedIndex = 0;

            cboHabitacion.ItemsSource = Enum.GetValues(typeof(TipoHabitacion));
            cboHabitacion.SelectedIndex = 0;

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ReservaBase reserva = null;

            if ((TipoReserva)cboTipo.SelectedValue == TipoReserva.Normal)
            {
                reserva = new ReservaNormal();
            }
            else
            {
                reserva = new ReservaWeb();
            }

            reserva.Numero = int.Parse(txtNumero.Text);
            reserva.FechaReserva = (DateTime)dpReserva.SelectedDate;
            reserva.InicioReserva = (DateTime)dpInicio.SelectedDate;
            reserva.TerminoReserva = (DateTime)dpTermino.SelectedDate;

            reserva.Tipo = (TipoReserva)cboTipo.SelectedValue;
            reserva.Habitacion = (TipoHabitacion)cboHabitacion.SelectedValue;

            Array.Resize(ref reservas, reservas.Length + 1);
            reservas[reservas.Length - 1] = reserva;

            dgReservas.ItemsSource = reservas;
            dgReservas.Items.Refresh();
        }

        private void dgReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgReservas.SelectedIndex != -1)
            {

                IReserva reserva = (IReserva)reservas[dgReservas.SelectedIndex];

                chkCancelable.IsChecked = reserva.EsCancelable;
                txtValor.Text = reserva.CalcularValor().ToString();
            }
        }

    }
}
