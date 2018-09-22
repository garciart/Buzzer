using Plugin.SimpleAudioPlayer;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace Buzzer {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e) {
            ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStreamFromFile("buzzer.mp3"));
            player.Play();
        }

        private Stream GetStreamFromFile(string filename) {
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Buzzer.Resources." + filename);
            return stream;
        }
    }
}
