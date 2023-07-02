using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMQTT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMain : ContentPage
    {
        public PageMain()
        {
            InitializeComponent();
        }

        private void btnPrender1_Clicked(object sender, EventArgs e)
        {
            btnApagar1.IsEnabled = true;
            btnApagar1.IsVisible = true;
            btnPrender1.IsVisible = false;
            btnPrender1.IsEnabled = false;
        }

        private void btnApagar1_Clicked(object sender, EventArgs e)
        {
            btnPrender1.IsVisible = true;
            btnPrender1.IsEnabled = true;
            btnApagar1.IsVisible = false;
            btnApagar1.IsEnabled = false;
        }

        private void btnPrender2_Clicked(object sender, EventArgs e)
        {
            btnApagar2.IsEnabled = true;
            btnApagar2.IsVisible = true;
            btnPrender2.IsVisible = false;
            btnPrender2.IsEnabled = false;
        }

        private void btnApagar2_Clicked(object sender, EventArgs e)
        {
            btnPrender2.IsVisible = true;
            btnPrender2.IsEnabled = true;
            btnApagar2.IsVisible = false;
            btnApagar2.IsEnabled = false;
        }

        private void btnPrender3_Clicked(object sender, EventArgs e)
        {
            btnApagar3.IsEnabled = true;
            btnApagar3.IsVisible = true;
            btnPrender3.IsVisible = false;
            btnPrender3.IsEnabled = false;
        }

        private void btnApagar3_Clicked(object sender, EventArgs e)
        {
            btnPrender3.IsVisible = true;
            btnPrender3.IsEnabled = true;
            btnApagar3.IsVisible = false;
            btnApagar3.IsEnabled = false;
        }

        private void btnPrender4_Clicked(object sender, EventArgs e)
        {
            btnApagar4.IsEnabled = true;
            btnApagar4.IsVisible = true;
            btnPrender4.IsVisible = false;
            btnPrender4.IsEnabled = false;
        }

        private void btnApagar4_Clicked(object sender, EventArgs e)
        {
            btnPrender4.IsVisible = true;
            btnPrender4.IsEnabled = true;
            btnApagar4.IsVisible = false;
            btnApagar4.IsEnabled = false;
        }
    }
}