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
        private ContratoCollection contratos = new ContratoCollection();

        #region Datos de Ejemplo
        private string[] nombres = {  "SOFIA"       ,"VALENTINA"   ,"ISIDORA"     ,"ANTONIA"    ,"EMILIA"
                                     ,"CATALINA"    ,"FERNANDA"    ,"CONSTANZA"   ,"JAVIERA"    ,"MARIA"       
                                     ,"FRANCISCA"   ,"AGUSTINA"    ,"AMANDA"      ,"CAMILA"     ,"MONSERRAT"  
                                     ,"BENJAMIN"    ,"VICENTE"     ,"MARTIN"      ,"MATIAS"     ,"JOAQUIN"    
                                     ,"AGUSTIN"     ,"CRISTOBAL"   ,"MAXIMILIANO" ,"SEBASTIAN"  ,"TOMAS"       
                                     ,"DIEGO"       ,"JOSE"        ,"NICOLAS"     ,"FELIPE"     ,"ALONSO"};

        private string[] apellidos = {  "SOTO"      , "CONTRERAS"   , "SILVA"   , "SEPÚLVEDA"   , "MARTÍNEZ"
                                       ,"MORALES"   , "RODRÍGUEZ"   , "LÓPEZ"   , "FUENTES"     , "ARAYA"
                                       ,"TORRES"    , "HERNÁNDEZ"   , "FLORES"  , "ESPINOZA"    , "VALENZUELA"
                                       ,"CASTILLO"  , "RAMÍREZ"     , "REYES"   , "GUTIÉRREZ"   , "CASTRO"
                                       ,"VARGAS"    , "ÁLVAREZ"     , "VÁSQUEZ" , "FERNÁNDEZ"   , "TAPIA"
                                       ,"SÁNCHEZ"   , "GÓMEZ"       , "HERRERA" , "CARRASCO"    , "CORTÉS"
                                       ,"NÚÑEZ"     , "JARA"        , "VERGARA" , "RIVERA"      , "FIGUEROA"
                                       ,"RIQUELME"  , "GARCÍA"      , "BRAVO"   , "MIRANDA"     , "VERA"
                                       ,"MOLINA"    , "VEGA"        , "CAMPOS"  , "OLIVARES"    , "ZÚÑIGA"
                                       ,"ORELLANA"  , "GALLARDO"    , "ALARCÓN" , "ORTIZ"       , "GARRIDO"
                                       ,"SALAZAR"   , "HENRÍQUEZ"   , "AGUILERA", "SAAVEDRA"    , "PIZARRO"
                                       ,"GUZMÁN"    ,"NAVARRO"      , "ARAVENA" , "PARRA"       , "ROMERO"
                                       ,"CÁCERES"   , "GODOY"       , "PEÑA"    , "LEIVA"       , "ESCOBAR" }; 
        #endregion
        
        public MainWindow()
        {
            InitializeComponent();

            CargaContratos();
        }

        /// <summary>
        /// Carga Contratos d ejemplo para la estadistica
        /// </summary>
        private void CargaContratos()
        {
            Random rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                ContratoBase contrato = null;
                TipoContrato tipo = (TipoContrato)(rnd.Next(0, 50) % 2);

                /* Asigna Plan */
                switch (tipo)
                {
                    case TipoContrato.Postpago:
                        PostPago post = new PostPago();
                        post.Contrato = (ContratoPostpago)rnd.Next(0, 2);
                        contrato = post;
                        break;
                    case TipoContrato.Prepago:
                        PrePago pre = new PrePago();
                        pre.Contrato = (ContratoPrepago)rnd.Next(0, 1);
                        contrato = pre;
                        break;
                }
                contrato.Tipo = tipo;

                contrato.Numero = (rnd.Next(6,9) * 10000000) + (rnd.Next(0,10000000));

                contrato.FechaContrato = DateTime.Now.AddDays(rnd.Next(1, 15) * (-1));
                contrato.NombreTitular = string.Format("{0} {1}", nombres[rnd.Next(0,29)] , apellidos[rnd.Next(0,64)]);
                contrato.EquipoPropio = (rnd.Next(0,50)%2 == 0);

                contratos.Add(contrato);

            }

            dgRegistro.ItemsSource = contratos;

        }

    }
}
