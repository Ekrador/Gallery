using Gallery.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityPage : ContentPage
    {
        private string _password;
        private Entry[] entryFields;
        private int currentFieldIndex;
        public SecurityPage()
        {
            InitializeComponent();
            InitializeFields();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(100);
            entryFields[0].Focus();
            _password = Preferences.Get("password", string.Empty);
            InfoTextHandler();
        }

        private void InfoTextHandler()
        {
            if (string.IsNullOrEmpty(_password))
            {
                info.Text = "Установите четырехзначный пароль";
            }
            else
            {
                info.Text = "Введите пароль";
            }
        }

        private void InitializeFields()
        {
            entryFields = new Entry[] { entry1, entry2, entry3, entry4 };
            currentFieldIndex = 0;

            foreach (var entry in entryFields)
            {
                entry.TextChanged += Entry_TextChanged;
                entry.Focused += Entry_Focused;
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                if (currentFieldIndex < entryFields.Length - 1)
                {
                    entryFields[currentFieldIndex + 1].Focus();
                }
            }
            else if (!string.IsNullOrEmpty(e.OldTextValue) && currentFieldIndex > 0)
            {
                entryFields[currentFieldIndex - 1].Focus();
            }
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            for (int i = 0; i < entryFields.Length; i++)
            {
                if (entryFields[i] == sender)
                {
                    currentFieldIndex = i;
                    break;
                }
            }
        }
        private async void Entry_Completed(object sender, EventArgs e)
        {
            string enteredPassword = entry1.Text + entry2.Text + entry3.Text + entry4.Text;
            if (!string.IsNullOrEmpty(_password))
            {
                if(string.Equals(enteredPassword, _password)) 
                {
                    await Navigation.PushAsync(new GalleryPage());
                }
                else
                {
                    info.TextColor = Color.Red;
                    info.Text = "Введен неверный пароль!";
                    Utility.Shake(info);
                    foreach (var entry in entryFields)
                    {
                        entry.Text = "";
                    }
                    entry1.Focus();
                }
            }
            else
            {
                Preferences.Set("password", enteredPassword);
                await Navigation.PushAsync(new GalleryPage());
            }
        }       
    }
}