using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheFinalDAW.Audio;
using TheFinalDAW.Gui;

namespace TheFinalDAW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random r = new Random();

        private DragHandler dragHandler;

        private double trackHeight = 80;

        public MainWindow()
        {
            InitializeComponent();

            this.dragHandler = new DragHandler(this.CenterCanvas, this.trackHeight);
            CreateTrackGrid(); CreateTrackGrid(); CreateTrackGrid();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void ResizeCenterCanvasChildren(double width)
        {
            foreach (var child in this.CenterCanvas.Children)
            {
                FrameworkElement childGrid = child as FrameworkElement;
                if (childGrid != null)
                {
                    childGrid.Width = width;
                }
            }
        }

        private void CreateTrackGrid()
        {
            var trackCanvas = new TrackElement(new AudioTrack()
            {
                Name = "Track " + this.CenterCanvas.Children.Count
            }, this.trackHeight);
            trackCanvas.Width = this.CenterCanvas.ActualWidth;
            Canvas.SetLeft(trackCanvas, 0);
            Canvas.SetTop(trackCanvas, this.CenterCanvas.Children.Count * this.trackHeight);
            this.CenterCanvas.Children.Add(trackCanvas);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeCenterCanvasChildren(e.NewSize.Width);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CreateTrackGrid();
        }        
    }
}
