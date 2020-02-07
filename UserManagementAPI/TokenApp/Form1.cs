using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Configuration;
using System.Windows.Forms;

namespace TokenApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = string.Empty;
                GetToken();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void GetToken()
        {

            string aadInstance = "https://login.windows.net/{0}";
            string ResourceId = ConfigurationManager.AppSettings["ResourceId"];
            string tenantId = ConfigurationManager.AppSettings["TenantId"];
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string replyAddress = ConfigurationManager.AppSettings["ReplyAddressConfigured"];
            AuthenticationContext authenticationContext =
              new AuthenticationContext(string.Format(aadInstance, tenantId));

            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(ResourceId, clientId, new Uri(replyAddress), new PlatformParameters(PromptBehavior.Always));

            textBox1.Text = authenticationResult.AccessToken;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
            textBox1.SelectAll();
            Clipboard.Clear();
            if (textBox1.Text.Trim() != string.Empty)
            {
                Clipboard.SetText(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            textBox1.Text = string.Empty;
        }
    }
}
