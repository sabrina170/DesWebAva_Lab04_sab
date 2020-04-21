using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e) {
            BPedido bPedido = null;

            try
            {
                bPedido = new BPedido();
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(Convert.ToDateTime(txtFechaInicio.Text),
                    Convert.ToDateTime(txtFechaFin.Text));
            }
            catch (Exception) {

                MessageBox.Show("Comunicate conn el administardor");
            }
            finally
            {
                bPedido = null;
            }
        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BDetallePedido bdPedido = null;

            bdPedido = new BDetallePedido();

            int idPedido;
            var item = dgvPedido.SelectedItem as DataRowView;
            if (null == item) return;
            idPedido = Convert.ToInt32(item.Row["IdPedido"]);
            dgvDetallePedido.ItemsSource = bdPedido.GetDetallePedidosPorId(idPedido);
            txtTotal.Text = Convert.ToString(bdPedido.GetDetalleTotalPorId(idPedido));
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
