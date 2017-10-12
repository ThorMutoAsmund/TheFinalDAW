using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TheFinalDAW.Audio;
using TheFinalDAW.Configuration;
using TheFinalDAW.Utils;

namespace TheFinalDAW.Gui
{
    public class TrackElement : StackPanel
    {
        public Safe<AudioTrack> AudioTrack { get; set; }

        private SolidColorBrush backgroundBrush = new SolidColorBrush(Color.FromRgb(200, 200, 200));

        public TrackElement(AudioTrack audioTrack, double height)
        {
            this.AudioTrack = audioTrack;
            this.Height = height;
            this.Orientation = Orientation.Horizontal;

            var handle = new TrackDragHandle();
            this.Children.Add(handle);

            var nameLabel = new Label()
            {
                Content = this.AudioTrack.Value.Name
            };
            this.Children.Add(nameLabel);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.ActualWidth > 0)
            {
                Rect myRect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
                drawingContext.DrawRectangle(AppConfiguration.Instance.TrackBackgroundBrush, AppConfiguration.Instance.TrackBorderPen, myRect);
                //{
                //    var text = new FormattedText(this.AudioTrack.Value.Name,
                //      CultureInfo.GetCultureInfo("en-us"),
                //      FlowDirection.LeftToRight,
                //      new Typeface("Verdana"), 12, System.Windows.Media.Brushes.Black);


                //    drawingContext.DrawText(text, new System.Windows.Point(20, 0));
                //}
            }
        }    
    }
}
