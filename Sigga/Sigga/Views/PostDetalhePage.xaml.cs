﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sigga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetalhePage : ContentPage
    {
        public PostDetalhePage()
        {

            Title = "Detalhes Post";
            InitializeComponent();
        }
    }
}