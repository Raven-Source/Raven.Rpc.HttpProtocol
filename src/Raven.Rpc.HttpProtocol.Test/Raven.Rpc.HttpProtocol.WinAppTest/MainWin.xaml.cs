using Raven.Rpc.IContractModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Raven.Rpc.HttpProtocol.WinAppTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();

            btnSubmit.Click += async (o, e) =>
            {
                try
                {
                    await BtnSubmit_Click(o, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ;
                }
            };
            cmbMethod.ItemsSource = new List<string> { "GET", "POST", "PUT", "DELETE" };
            cmbContentType.ItemsSource = new List<string> { "application/json", "application/xml", "text/plain", "text/html" };
        }

        private async Task BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            txtRes.Text = "";
            string url = txtUrl.Text.Trim();
            string contentType = null;
            string method = null;
            if (cmbMethod.Items.CurrentItem != null)
            {
                method = cmbMethod.SelectedItem.ToString();
            }
            if (cmbContentType.Items.CurrentItem != null)
            {
                contentType = cmbContentType.SelectedItem.ToString();
            }

            APIClient client = new APIClient(contentType);
            string content = null;
            if (method.ToUpper() != "GET" && method.ToUpper() != "DELETE")
            {
                content = txtContent.Text;
            }
            var result = await client.InvokeAsync<string, byte[]>(url, content, null, new System.Net.Http.HttpMethod(method));
            var resString = System.Text.Encoding.UTF8.GetString(result);
            txtRes.Text = resString;

        }
    }
}
