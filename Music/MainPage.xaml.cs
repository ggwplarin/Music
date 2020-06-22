using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Music
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
         MediaPlayer mediaPlayer;
         Uri u = new Uri(@"C:/Users/user/source/repos/Music/Music/Assets/m.mp3");
        public MainPage()
        {
            this.InitializeComponent();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Volume = 0.1;

           

            
            
        }

        private async void start_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("m.mp3");

            mediaPlayer.AutoPlay = false;
            mediaPlayer.Source = MediaSource.CreateFromStorageFile(file);
            mediaPlayer.Play();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            
        }
    }
}
