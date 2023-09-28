using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Gallery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();
        protected  override void OnAppearing()
        {
            BindingContext = this;
            base.OnAppearing();
        }
        public GalleryPage()
        {
            InitializeComponent();
            GetPhotos();
        }
        private void GetPhotos()
        {
            var path = new DirectoryInfo("/storage/emulated/0/DCIM/Camera");

            var files = path.GetFiles("*.jpg"); 

            foreach (var file in files)
            {
                Photo photo = new Photo (file.Name, file.FullName, file.CreationTime);
                Photos.Add(photo);
            }
        }

        private void ViewPhoto(object sender, EventArgs e)
        {
            var photo = gallery.SelectedItem as Photo;
            if (photo != null)
            {
                Navigation.PushAsync(new InspectImagePage(photo));
            }
        }

        private async void RemovePhoto(object sender, EventArgs e)
        {
            var photoToRemove = gallery.SelectedItem as Photo;
            if (photoToRemove != null)
            {
                var file = new FileInfo(photoToRemove.FullName);
                var result = await DisplayAlert("Удаление", $"Удалить фото {photoToRemove.Name}?", "Да", "Нет");
                if (!result)
                {
                    return;
                }
                else
                {
                    try
                    {
                        file.Delete();
                        Photos.Remove(photoToRemove);
                        await DisplayAlert(null, $"Фото '{photoToRemove.Name}' удалено", "ОК");
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert(null, $"Произошла ошибка при удалении файла '{photoToRemove.Name}'.{Environment.NewLine}{ex.Message}", "ОК");
                    }
                }
            }
        }
    }
}