using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace Gallery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InspectImagePage : ContentPage
    {
        public Photo InspectedPhoto { get; set; }
        protected override void OnAppearing()
        {
            BindingContext = this;
            base.OnAppearing();
        }
        public InspectImagePage(Photo photo)
        {
            InspectedPhoto = photo;
            InitializeComponent();
        }
    }
}