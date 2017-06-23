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
using Biblioteca;


namespace RegistroPersonasWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Registro dinámico de Personas */
        Persona[] registro = new Persona[0];

        public MainWindow()
        {
            InitializeComponent();

            LimpiarControles();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                /* Crea instancia de la nueva Persona */
                Persona persona = new Persona();
                PoblarInstancia(persona);

                /* Redimensiona el registro y guarda la nueva instancia */
                Array.Resize(ref registro, registro.Length + 1);
                registro[registro.Length - 1] = persona;

                MessageBox.Show("Persona registrada");
                MostrarRegistro();
                LimpiarControles();
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Validación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            if (dgRegistro.SelectedIndex != -1)   
            {
                try
                {
                    /* Recupera y actualiza la instancia de la persona */
                    Persona persona = registro[dgRegistro.SelectedIndex];
                    PoblarInstancia(persona);
                    registro[dgRegistro.SelectedIndex] = persona;

                    MessageBox.Show("Persona modificada");
                    MostrarRegistro();
                }
                catch (ArgumentException ae)
                {
                    MessageBox.Show(ae.Message, "Validación", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
            else
            {
                MessageBox.Show("No hay un registro seleccionado para modificar", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (dgRegistro.SelectedIndex != -1)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Eliminar el regsitro seleccionado?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (respuesta == MessageBoxResult.Yes)
                {
                    /* Hace una copia del registro original */
                    Persona[] copia = (Persona[])registro.Clone();

                    /* Redimensiona el registro */
                    Array.Resize(ref registro, registro.Length - 1); //Opcional registro = new Persona[registro.Length - 1]


                    /* Traspasa los elementos exceptuando la posición a eliminar */
                    int posicion = dgRegistro.SelectedIndex;
                    for (int i = 0; i < copia.Length; i++)
                    {
                        if (i < posicion)
                        {
                            registro[i] = copia[i];
                        }
                        else if (i > posicion)
                        {
                            registro[i - 1] = copia[i];
                        }
                    }

                    MessageBox.Show("Persona eliminada");
                    MostrarRegistro();
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
        /// Carga la información desde la interfaz a una instancia de Persona
        /// </summary>
        /// <param name="persona"></param>
        private void PoblarInstancia(Persona persona)
        {
            persona.Nombres = txtNombres.Text;
            persona.Apellidos = txtApellidos.Text;
            persona.Sexo = (SexoPersona)cboSexo.SelectedValue;
        }

        /// <summary>
        /// Carga los registros de personas en la interfaz
        /// </summary>
        private void MostrarRegistro()
        {
            /* Muestra en el DataGrid */
            dgRegistro.ItemsSource = registro;
            dgRegistro.Items.Refresh();
        }

        /// <summary>
        /// Limpia los controles de interfaz
        /// </summary>
        private void LimpiarControles()
        {
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            CargarListas();
        }

        /// <summary>
        /// Carga listas desde las enumeraciones
        /// </summary>
        private void CargarListas()
        {
            cboSexo.ItemsSource = Enum.GetValues(typeof(SexoPersona));
            cboSexo.SelectedIndex = 0;

        }

        /// <summary>
        /// Carga los datos en los controles de la interfaz
        /// </summary>
        /// <param name="indice"></param>
        private void CargarDatos(int indice)
        {
            LimpiarControles();

            /* Carga los datos en la interfaz */
            Persona persona = registro[indice];

            txtNombres.Text = persona.Nombres;
            txtApellidos.Text = persona.Apellidos;
            cboSexo.SelectedValue = persona.Sexo;
        }

    }
}
