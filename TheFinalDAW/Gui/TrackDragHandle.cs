using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TheFinalDAW.Configuration;

namespace TheFinalDAW.Gui
{
    public class TrackDragHandle : Canvas
    {
        public TrackDragHandle()
        {
            this.Width = 15;
            this.Height = 80;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.ActualWidth > 0)
            {
                Rect myRect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
                drawingContext.DrawRectangle(AppConfiguration.Instance.TrackDragHandleBackgroundBrush, null, myRect);
            }
        }
    }
}
