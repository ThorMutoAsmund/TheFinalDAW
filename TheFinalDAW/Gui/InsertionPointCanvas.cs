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
    public class InsertionPointCanvas : Canvas
    {
        

        public InsertionPointCanvas()
        {
            this.Height = 4;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.ActualWidth > 0)
            {
                Rect myRect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
                drawingContext.DrawRectangle(AppConfiguration.Instance.InsertionPointBackgroundBrush, AppConfiguration.Instance.InsertionPointPen, myRect);
            }
        }    
    }
}
