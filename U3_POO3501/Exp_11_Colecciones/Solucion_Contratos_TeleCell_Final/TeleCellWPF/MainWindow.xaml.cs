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

/* Add's */
using BibliotecaTeleCell;

namespace TeleCellWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ContratoBase[] registro = new ContratoBase[0];
        private ContratoCollection registro = new ContratoCollection();

        public MainWindow()
        {
            InitializeComponent();

            LimpiarControles();
        }

        /// <summary>
        /// Limpia los controles de la interfaz de usuario y carga las listas
        /// </summary>
        private void LimpiarControles()
        {
            txtNumero.Text = string.Empty;
            dpFechaContrato.SelectedDate = DateTime.Now;
            txtNombre.Text = string.Empty;
            chkEquipo.IsChecked = false;
            txtMinuto.Text = string.Empty;
            txtMB.Text = string.Empty;
            txtSMS.Text = string.Empty;
            txtValorMinuto.Text = string.Empty;
            txtValorMB.Text = string.Empty;
            txtValorSMS.Text = string.Empty;

            CargaContratos();

        }

        /// <summary>
        /// Carga los Tipos de Contrato y Planes asociados
        /// </summary>
        private void CargaContratos()
        {
            cboContrato.ItemsSource = Enum.GetValues(typeof(TipoContrato));
            cboContrato.SelectedIndex = 0;

            CargaPlanes();
        }

        /// <summary>
        /// Carga los planes en base al contrato seleccionado
        /// </summary>
        private void CargaPlanes()
        {
            Array planes = null;
            TipoContrato contrato = (TipoContrato)cboContrato.SelectedValue;

            switch (contrato)
            {
                case TipoContrato.Postpago:
                    planes = Enum.GetValues(typeof(ContratoPostpago));
                    break;
                case TipoContrato.Prepago:
                    planes = Enum.GetValues(typeof(ContratoPrepago));
                    break;
            }

            cboPlan.ItemsSource = planes;
            cboPlan.SelectedIndex = 0;
        }

        private void cboContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboContrato.SelectedIndex != -1)
            {
                CargaPlanes();

                MostrarInformacion();
            }
        }

        private void cboPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPlan.SelectedIndex != -1)
            {
                MostrarInformacion();
            }
        }

        /// <summary>
        /// Muestra información en base a los datos del Contrato y Plan
        /// </summary>
        private void MostrarInformacion()
        {
            TipoContrato tipo = (TipoContrato)cboContrato.SelectedValue;
            if (tipo == TipoContrato.Postpago)
            {
                PostPago post = new PostPago();
                post.Contrato = (ContratoPostpago)cboPlan.SelectedValue;

                txtMinuto.Text = post.Minutos.ToString();
                txtMB.Text = post.MBInternet.ToString();
                txtSMS.Text = post.SMS.ToString();

                txtValorMinuto.Text = post.MinutoAdicional.ToString();
                txtValorMB.Text = post.MBAdicional.ToString();
                txtValorSMS.Text = post.SMSAdicional.ToString();

                txtPrecioContrato.Text = post.PrecioContrato().ToString();
            }
            else
            {
                PrePago pre = new PrePago();
                pre.Contrato = (ContratoPrepago)cboPlan.SelectedValue;

                txtMinuto.Text = "0";
                txtMB.Text = "0";
                txtSMS.Text = "0";

                txtValorMinuto.Text = pre.ValorMinuto.ToString();
                txtValorMB.Text = pre.ValorMB.ToString();
                txtValorSMS.Text = pre.ValorSMS.ToString();

                txtPrecioContrato.Text = pre.PrecioContrato().ToString();
            }

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ContratoBase contrato = new ContratoBase();

            try
            {
                PoblarContrato(ref contrato);

                /* Agrega y muestra registro */
                //Array.Resize(ref registro, registro.Length + 1);
                //registro[registro.Length - 1] = contrato;
                registro.Add(contrato);

                MostrarRegistros();
                LimpiarControles();

                MessageBox.Show("Contrato registrado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /// <summary>
        /// Muestra los registros de contrato
        /// </summary>
        private void MostrarRegistros()
        {
            dgRegistro.ItemsSource = registro;
            dgRegistro.Items.Refresh();
        }

        /// <summary>
        /// Carga las propiedades de la instancia con los datos de los controles.
        /// </summary>
        /// <param name="contrato"></param>
        private void PoblarContrato(ref ContratoBase contrato)
        {
            /* Asigna Plan */
            switch ((TipoContrato)cboContrato.SelectedValue)
            {
                case TipoContrato.Postpago:
                    PostPago post = new PostPago();
                    post.Contrato = (ContratoPostpago)cboPlan.SelectedValue;
                    contrato = post;
                    break;
                case TipoContrato.Prepago:
                    PrePago pre = new PrePago();
                    pre.Contrato = (ContratoPrepago)cboPlan.SelectedValue;
                    contrato = pre;
                    break;
            }

            contrato.Numero = int.Parse(txtNumero.Text);
            contrato.FechaContrato = (DateTime)dpFechaContrato.SelectedDate;
            contrato.NombreTitular = txtNombre.Text;
            contrato.EquipoPropio = (bool)chkEquipo.IsChecked;
            contrato.Tipo = (TipoContrato)cboContrato.SelectedValue;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgRegistro.SelectedIndex != -1)
            {
                try
                {
                    ContratoBase contrato = registro[dgRegistro.SelectedIndex];
                    PoblarContrato(ref contrato);
                    registro[dgRegistro.SelectedIndex] = contrato;

                    MostrarRegistros();
                    LimpiarControles();

                    MessageBox.Show("Contrato actualizado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (ArgumentException ae)
                {
                    MessageBox.Show(ae.Message, "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe haber un registro seleccionado");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgRegistro.SelectedIndex != -1)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Eliminar el registro seleccionado?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (respuesta == MessageBoxResult.Yes)
                {
                    ///* Hace una copia del registro original */
                    //ContratoBase[] copia = (ContratoBase[])registro.Clone();

                    ///* Redimensiona el registro */
                    //Array.Resize(ref registro, registro.Length - 1); //Opcional registro = new Persona[registro.Length - 1]


                    ///* Traspasa los elementos exceptuando la posición a eliminar */
                    //int posicion = dgRegistro.SelectedIndex;
                    //for (int i = 0; i < copia.Length; i++)
                    //{
                    //    if (i < posicion)
                    //    {
                    //        registro[i] = copia[i];
                    //    }
                    //    else if (i > posicion)
                    //    {
                    //        registro[i - 1] = copia[i];
                    //    }
                    //}

                    registro.RemoveAt(dgRegistro.SelectedIndex);

                    MostrarRegistros();

                    dgRegistro.ItemsSource = null; /* Limpiar detalle */

                    MessageBox.Show("Contrato eliminado");
                }
            }
            else
            {
                MessageBox.Show("No hay un registro seleccionado para modificar", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void dgRegistro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* Verifica que hay un elemento seleccionado*/
            if (dgRegistro.SelectedIndex != -1)
            {
                /* solicita cargar los datos de esta posición */
                CargarDatos(dgRegistro.SelectedIndex);
            }

        }

        /// <summary>
        /// Carga los datos en los controles de la interfaz
        /// </summary>
        /// <param name="indice"></param>
        private void CargarDatos(int indice)
        {
            LimpiarControles();

            /* Carga los datos en la interfaz */
            ContratoBase contrato = registro[indice];

            txtNumero.Text = contrato.Numero.ToString();
            dpFechaContrato.SelectedDate = contrato.FechaContrato;
            txtNombre.Text = contrato.NombreTitular;
            chkEquipo.IsChecked = contrato.EquipoPropio;
            cboContrato.SelectedValue = contrato.Tipo;

            CargaPlanes(); /* Asegura la sincronización Contrato <-> Plan */

            if (contrato is PostPago)
            {
                PostPago post = (PostPago)contrato;
                cboPlan.SelectedValue= post.Contrato;
            }
            else
            {
                PrePago pre = (PrePago)contrato;
                cboPlan.SelectedValue = pre.Contrato;
            }
        }

        private void btnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            /* instancia y asigna el registro */
            Estadisticas form = new Estadisticas();
            form.Registro = registro;

            /* Muestra el formulario */
            form.ShowDialog();
        }

        

    }
}
