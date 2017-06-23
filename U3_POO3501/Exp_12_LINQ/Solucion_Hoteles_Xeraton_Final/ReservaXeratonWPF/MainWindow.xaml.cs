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
        ReservaCollection reservas = new ReservaCollection();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            Estadisticas form = new Estadisticas();
            form.Reservas = reservas;

            form.ShowDialog();
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            reservas = new ReservaCollection();
            CargarReservas();

            MessageBox.Show("Reservas cargadas");
        }

        private void CargarReservas()
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                ReservaBase reserva = new ReservaBase();
                TipoReserva tipo = (TipoReserva) ( rnd.Next(0, 50) % 2 );

                if (tipo == TipoReserva.Normal)
                {
                    reserva = new ReservaNormal();
                }
                else
                {
                    reserva = new ReservaWeb();
                }
                reserva.Tipo = tipo;

                reserva.Numero = 100 + i;
                reserva.FechaReserva = DateTime.Now.AddDays( rnd.Next(1,15) * (-1) );
                reserva.InicioReserva = reserva.FechaReserva.AddDays(rnd.Next(3, 20));
                reserva.TerminoReserva = reserva.InicioReserva.AddDays(rnd.Next(5, 30));

                reserva.Habitacion = (TipoHabitacion)rnd.Next(0,3);

                reservas.Add(reserva);
            }

            /* Carga reservas en el grid */
            dgReservas.ItemsSource = reservas;
            dgReservas.Items.Refresh();
        }
    }
}
