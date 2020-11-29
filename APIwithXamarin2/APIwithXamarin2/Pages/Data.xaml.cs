using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIwithXamarin2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Data : ContentPage
    {

        public int recovered { get; set; }
        public int deaths { get; set; }
        public int confirmed { get; set; }
        public DateTime lastChecked { get; set; }
        public DateTime lastReported { get; set; }
        public string location { get; set; }
        public Data()
        {
            InitializeComponent();
        }
    }
}