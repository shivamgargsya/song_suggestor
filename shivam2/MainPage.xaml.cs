using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Search;
using System.Net.Http;
using System.Xml.Linq;
using System.Threading;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace shivam2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        Playback playback = new Playback();
        private DispatcherTimer timer;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {



         try {  var folder = KnownFolders.MusicLibrary;

                var query = folder.CreateFileQuery();

                var files = await query.GetFilesAsync();




                playback.totalsongs = (int)(files).Count;
                StorageFile file;

                try
                {

                    for (int i = 0; i <= (files).Count; i++)
                    {

                        file = files[i];
                        if (file.FileType == ".mp3")
                        {
                            song item = new song();

                            var datas = await file.Properties.GetMusicPropertiesAsync();
                            item.artist = datas.Artist;
                            item.album = datas.Album;
                            item.genre = "abc";

                            //datas.TrackNumber =(uint) 0;
                            item.count = (int)datas.TrackNumber;
                            item.Name = datas.Title;

                            //status.Text = files.Count.ToString();
                            //status.Text = file.Path;
                            item.path = file.Path;
                            playback.totalsongs = (files).Count;
                            playback.playlist.Add(item);


                        }

                    }
                   


                }





                catch (Exception exp)
                {
                    //loadstatus.Text = "Nothing to play please put some songs in music library";
                    //loadstatus.Text = exp.Message;
                    /*playbutton.IsEnabled = false;
                    timelineslider.IsEnabled = false;
                    loadsongs.IsEnabled = false;*/
                }
                grid.ItemsSource = playback.playlist;
                playback.currentindex = 0;
                playbutton.IsEnabled = true;
                timelineslider.IsEnabled = true;
                loadsongs.IsEnabled = true;

                changetheelement(0);
                player.Play();


                grid.SelectedIndex = 0;
        }
            
                catch (Exception exp)
                {
                    loadstatus.Text = "Nothing to play please put some songs in music library";
                    //loadstatus.Text = exp.Message;
                    playbutton.IsEnabled = false;
                    timelineslider.IsEnabled = false;
                    loadsongs.IsEnabled = false;
                }
            
           
   
    
            
           

        }
        
        
        
       
        
        
        private   int setsliderfrequency()
        {
            int frequency=1;
            return frequency;
        }

        private void Setuptimer()
        {
            try
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds((double)setsliderfrequency());
                starttimer();
            }
            catch (Exception e)
            { }
        }
        private void stoptimer()
        {

            try
            {
                timer.Stop();
                timer.Tick -= timer_Tick;
            }
            catch (Exception e)
            { }
        }
        private void starttimer()
        {
            try
            {
                timer.Tick += timer_Tick;
                timer.Start();
            }
            catch (Exception e)
            { }
        }
        private void timer_Tick(Object sender, Object e)
        {
            timelineslider.Value = player.Position.TotalSeconds;
            int min=0;
            int sec=0;
            min=((int)player.Position.TotalSeconds)/60;
            sec=((int)player.Position.TotalSeconds)%60;
            timestatus.Text ="0"+ min.ToString() + ":" + sec.ToString(); 
        }

        
        
        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void changetheelement(int newindex)
    {
        try
        {
            playback.currentindex = newindex;
            int index = playback.currentindex;
            List<song> list = playback.playlist;
            Uri uri = new Uri(list[index].path);
            player.Source = uri;
            StorageFile file = await StorageFile.GetFileFromPathAsync(list[index].path);
            var stream = await file.OpenReadAsync();
            if (list[index].path != null)
            {
                player.SetSource(stream, list[index].path);
                player.Play();
            }
            var datas = await file.Properties.GetMusicPropertiesAsync();
            datas.TrackNumber++;
            grid.SelectedIndex = newindex;
            playbutton.Content = "Pause";
        }
        catch (Exception e)
        { }
    }

        private   void Media_Ended(object sender, RoutedEventArgs e)
        {
            try
            {
                player.Stop();
                playback.currentindex++;
                stoptimer();
                changetheelement(playback.currentindex);
            }
            catch (Exception exp)
            { }
           }

       
        private  void Media_Failed(object sender, ExceptionRoutedEventArgs e)
        {
            player.Stop();
           
             changetheelement(playback.currentindex);
             stoptimer();
        }

        private  void Media_Opened(object sender, RoutedEventArgs e)
        {
            try
            {
                timelineslider.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
                timelineslider.Value = 0;
                Setuptimer();
                playback.playlist[playback.currentindex].count++;
            }
            catch (Exception exp)
            { }
           }

     

        private void volume_changed(object sender, RangeBaseValueChangedEventArgs e)
        {
            player.Volume = volumeslider.Value;
        }

        private void new_value(object sender, RangeBaseValueChangedEventArgs e)
        {

            player.Position = TimeSpan.FromSeconds((double)timelineslider.Value);
        }

        private void play_clicked(object sender, RoutedEventArgs e)
        {
            if (String.Compare((String)playbutton.Content,"Pause")==0)
            {
                playbutton.Content = "Play";
                player.Pause();
                stoptimer();
            }
            else
            {
                playbutton.Content = "Pause";
                player.Play();
                starttimer();
            }
            
        }

        private void item_selected(object sender, TappedRoutedEventArgs e)
        {
            int index = grid.SelectedIndex;

            playback.currentindex = index;
            if (playback.currentindex < 0)
            {
                playback.currentindex = 0;
            }

            changetheelement(index);
             
        }

        private  async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            loadsongs.IsEnabled = false;
            StorageFile file = await StorageFile.GetFileFromPathAsync(playback.playlist[playback.currentindex].path);
            var item = await file.Properties.GetMusicPropertiesAsync();
            (item.TrackNumber)++;

            HttpClient httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("ie", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
            try
            {
                httpclient.MaxResponseContentBufferSize = 256000;
                String resourceadd = "http://ws.audioscrobbler.com/2.0/?method=artist.gettoptracks&artist=" + item.Artist + "&api_key=053ca583d5f4dae64dbf6a7e61a82997";

                message.Text = "connecting.....";
                HttpResponseMessage response = await httpclient.GetAsync(resourceadd);
                response.EnsureSuccessStatusCode();
                message.Text = response.ReasonPhrase + Environment.NewLine;
                
                String responsestring = await response.Content.ReadAsStringAsync();
                //StorageFolder storagefolder=KnownFolders.DocumentsLibrary;
                //StorageFile fp = await storagefolder.CreateFileAsync("sample.txt");
                //await FileIO.WriteTextAsync(fp, responsestring);

                XElement doc = XElement.Parse(responsestring);
                //message.Text = "XDocument created..";

                IEnumerable<XElement> datas = doc.Descendants("track");


                ObservableCollection<song> data = new ObservableCollection<song>();
                List<song> streamdata = new List<song>();
                foreach (var element in datas)
                {


                    song item2 = new song();
                    item2.Name = (String)element.Element("name").Value;
                    try { item2.uri = (String)element.Element("url").Value; }
                    catch (Exception et)
                        {
                        }
                   // message.Text = item2.uri;
                    streamdata.Add(item2);
                    data.Add(item2);
                    


                }
               

                grid2.ItemsSource = data;
                loadsongs.IsEnabled = true;
                



            }
            catch (Exception exp)
            {
                message.Text = exp.Message;
                loadsongs.IsEnabled = true;
            }


        }

       
           

    }
}
