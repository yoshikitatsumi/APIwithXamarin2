using System.ComponentModel;
using Xamarin.Forms;
using APIwithXamarin2.ViewModels;

namespace APIwithXamarin2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}