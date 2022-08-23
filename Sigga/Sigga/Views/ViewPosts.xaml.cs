using Sigga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sigga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPostsPosts : ContentPage
    {
        public ViewPostsPosts()
        {
            Title = "Posts";
            InitializeComponent();
        }
    }
}