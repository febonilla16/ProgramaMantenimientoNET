using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProgramaMantenimiento
{
    /// <summary>
    /// Lógica de interacción para FormVista.xaml
    /// </summary>
    public partial class FormVista : Window
    {
        public List<Clientes> client;
        public FormVista()
        {
            InitializeComponent();

            client = Clientes.Extraer(); //mostrar los registros en el datagrid
            dataGrid1.ItemsSource = client;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           DataGrid dg = (DataGrid)sender;
           DataGridRow row_selected = dg.SelectedItem as DataGridRow;
           if (row_selected != null && row_selected.Item is Clientes)
           {
                Clientes cl = (Clientes)row_selected.Item;
                Console.WriteLine(cl.IdCliente);
           }
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FormUpdate form = new FormUpdate();
            form.ShowDialog();
            client = Clientes.Extraer(); //mostrar los registros en el datagrid
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = client;
        }
    }
}
