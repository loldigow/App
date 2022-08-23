using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sigga
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : Shell
    {
        public Menu()
        {
            InitializeComponent();
            Routing.RegisterRoute("Usuario/Detalhes", typeof(Views.UsuarioPage));
            Routing.RegisterRoute("Usuario/Detalhes/Sobre", typeof(Views.SobreUsuarioPage));
            Routing.RegisterRoute("Post/Detalhes", typeof(Views.PostDetalhePage));
        }
    }
}