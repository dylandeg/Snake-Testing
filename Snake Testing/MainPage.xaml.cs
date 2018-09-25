using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Snake_Testing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            
            this.InitializeComponent();
            
            
            
            gameBoard.Children.Add(myRect);

            DispatcherTimerSetup();
            
            

            
            
        }

        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;
        int timesTicked = 1;
        int timesToTick = 10;
     
        SolidColorBrush appleColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
        SolidColorBrush snakeColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
        Rectangle myRect = new Rectangle();

        public void DispatcherTimerSetup()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //IsEnabled defaults to false

            Grid.SetRow(myRect, 0);
            Grid.SetColumn(myRect, 0);
            myRect.Fill = appleColor;

            startTime = DateTimeOffset.Now;
            lastTime = startTime;
            
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
            
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - lastTime;
            lastTime = time;
            //Time since last tick should be very very close to Interval
            Grid.SetRow(myRect, timesTicked);
            Grid.SetColumn(myRect, timesTicked);
            myRect.Fill = appleColor;
            int burger = timesTicked % 2;
            switch (burger)
            {
                case 0:
                    myRect.Fill = appleColor;
                    break;
                default:
                    myRect.Fill = snakeColor;
                    break;

            }

            timesTicked++;
            if (timesTicked > timesToTick)
            {
                stopTime = time;
                
                dispatcherTimer.Stop();
                //IsEnabled should now be false after calling stop
                
                span = stopTime - startTime;
                
            }
        }

    }
}
