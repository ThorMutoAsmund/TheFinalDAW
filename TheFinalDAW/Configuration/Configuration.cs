using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TheFinalDAW.Configuration
{
    public class AppConfiguration
    {
        public Pen TrackBorderPen = new Pen(new SolidColorBrush(Color.FromRgb(100, 100, 100)), 1);
        public SolidColorBrush TrackBackgroundBrush = new SolidColorBrush(Color.FromRgb(200, 200, 200));
        public SolidColorBrush TrackDragHandleBackgroundBrush = new SolidColorBrush(Color.FromRgb(50, 50, 50));
        public Pen InsertionPointPen = new Pen(new SolidColorBrush(Color.FromRgb(150, 0, 0)), 1);
        public SolidColorBrush InsertionPointBackgroundBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));

        public static AppConfiguration Instance = new AppConfiguration();

        private AppConfiguration()
        {

        }
    }
}
