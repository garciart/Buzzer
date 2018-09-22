# Buzzer!
<h2>A fun way to annoy your friends using Adrian Stevens' awesome Simple Audio Player!</h2>
<h3>Introduction:</h3>
Buzzer is a neat little application I wrote to annoy people who say stupid things and to get back into mobile application development using Xamarin. If you looked at the README.md for the Test Mate repositories, you'll know that my first mobile app was a port of Test Mate to my XV6700 Pocket PC using Visual C++ .NET back in 2006. I eventually ported Test Mate to the BlackBerry OS (Java), Apple's iOS (C++), Palm's webOS (HTML/JavaScript), and my Android devices (which I still use to this day). However, more and more of my friends began to ask me to write web sites, so, for almost a decade, I ended up focused on creating data-driven web applications.
The good news is that I kept up my C# skills, since I used ASP.NET rather than PHP or JavaScript to develop web applications. Therefore, I was excited when I heard about Xamarin, but unfortunately, due to life, school, and work, I was not able to follow up until now. But enough background; here's the code (and I take no responsibility for what happens when you start annoying people with it!)
<h3>Steps:</h3>
Open Visual Studio (we're using VS 2017) and click on New -&gt; Project:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-01.jpg" /></p>
Expand the Visual C# node in the pane on the left and select Cross-Platform. Select Mobile App (Xamarin.Forms) from the pane on the right, name the application "Buzzer", and click OK:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-02.jpg" /></p>
Select the Blank template. Ensuring all platforms are selected and the Code Sharing Strategy is set to .NET Standard, click OK:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-03.jpg" /></p>
Once Visual Studio is finished setting up the project, open the NuGet Package Manager Console by clicking on Tools -&gt; NuGet Package Manager -&gt; Package Manager Console:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-04.jpg" /></p>
Type in "Install-Package Xam.Plugin.SimpleAudioPlayer" at the prompt and hit enter:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-05.jpg" /></p>
Once the package is installed, open the MainPage.xaml file (if it is not open already), and replace the code within the StackLayout to the following:
<pre>&lt;Label Text="Welcome to Buzzer!"
  HorizontalOptions="Center"
  VerticalOptions="CenterAndExpand" /&gt;
&lt;Button Text="Press Me!"
  HorizontalOptions="Center"
  VerticalOptions="CenterAndExpand"
  TextColor="White"
  BackgroundColor="Red" /&gt;
</pre>
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-06.jpg" /></p>
In the Solution Explorer, Right click on the Buzzer.Android project and select Set as StartUp Project:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-07.jpg" /></p>
Save all and click on Debug -&gt; Start Debugging (or press F5). It will take some time for the emulator to render the phone, but when it is complete, you should see the following:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-08.jpg" /></p>
If you press the button, nothing happens. Click on Debug -&gt; Stop Debugging (or press Shift F5) in Visual Studio. Add Clicked="Button_Clicked" to the Button control in MainPage.xaml:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-09.jpg" /></p>
Expand the MainPage.xaml node in the Solution Explorer and click on MainPage.xaml.cs to open the file (if it is not already open). Change the code to the following:
<pre>
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
</pre>
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-10.jpg" /></p>
Download the <a href="http://rgprogramming.com/wp-content/uploads/buzzer.mp3">buzzer.mp3</a> file. Right click on the Buzzer project in the Solution Explorer and click on Properties:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-11.jpg" /></p>
Select Resources in the left-hand pane. You will see the following message:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-12.jpg" /></p>
Click on the message. On the following screen, click on the down arrow next to Add Resource at the top, and select Add Existing File...:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-13.jpg" /></p>
Go to the folder where you downloaded <a href="http://rgprogramming.com/wp-content/uploads/buzzer.mp3">buzzer.mp3</a> and select the file:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-14.jpg" /></p>
The <a href="http://rgprogramming.com/wp-content/uploads/buzzer.mp3">buzzer.mp3</a> file will be added to the Buzzer project under a folder named Resources:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-15.jpg" /></p>
However, the application cannot use the file yet. Right-click on the <a href="http://rgprogramming.com/wp-content/uploads/buzzer.mp3">buzzer.mp3</a> file and select Properties:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-16.jpg" /></p>
Change the Build Action from <b>None</b> to <b>Embedded resource</b>:
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-17.jpg" /></p>
Once again, save all and click on Debug -&gt; Start Debugging (or press F5). Once the emulator starts, click the button and you should hear the buzz!
<p style="text-align: center;"><img src="http://rgprogramming.com/wp-content/uploads/buzzer-tutorial-18.jpg" /></p>
<h3>Conclusion:</h3>
There you have it: a simple application to annoy your friends. Make sure you also check out Simple Audio Player and Adrian Stevens' other Xamarin plugins at <a href="https://github.com/adrianstevens/Xamarin-Plugins" target="_blank" rel="noopener">https://github.com/adrianstevens/Xamarin-Plugins</a>. Have fun, and once again, I take no responsibility for what happens when you start annoying people with it!
<h3>References:</h3>
<p>Microsoft. (n.d.). Xamarin.Forms. Retrieved September 22, 2018, from <a href="https://docs.microsoft.com/en-us/xamarin/xamarin-forms/" target="_blank" rel="noopener">https://docs.microsoft.com/en-us/xamarin/xamarin-forms/</a></p>
<p>Stevens, A. (2018, September 1). adrianstevens/Xamarin-Plugins. Retrieved from <a href="https://github.com/adrianstevens/Xamarin-Plugins" target="_blank" rel="noopener">https://github.com/adrianstevens/Xamarin-Plugins</a></p>