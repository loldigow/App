using Dominio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sigga.ViewModels
{
    [QueryProperty("post", "post")]
    public class ViewModelPost : ViewModelBase
    {
        private PostModel _post = new PostModel();
        public String post
        {
            set
            {
                var postDescodificado = Uri.UnescapeDataString(value);
                var post = JsonConvert.DeserializeObject<PostModel>(postDescodificado);
                if (post != null)
                {
                    _post = post;
                    OnPropertyChanged(nameof(Post));
                }
                else
                {
                    throw new Exception("Não foi possivel abrir os detalhes deste post.");
                }
            }
        }
        public PostModel Post { 
            get { return _post; } 
        }


        public ViewModelPost()
        {

        }
    }
}
