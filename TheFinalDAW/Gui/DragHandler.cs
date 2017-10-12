using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TheFinalDAW.Gui
{
    public class DragHandler
    {
        private Canvas canvas;
        private double trackHeight;
        private FrameworkElement trackBeingMoved = null;
        private Point trackBeingMovedStartPoint;
        private Point trackBeingMovedOrigin;
        private InsertionPointCanvas insertionPointCanvas = null;

        public DragHandler(Canvas canvas, double trackHeight)
        {
            this.canvas = canvas;
            this.trackHeight = trackHeight;
            this.canvas.PreviewMouseLeftButtonDown += this.Canvas_PreviewMouseLeftButtonDown;
            this.canvas.MouseMove += this.Canvas_PreviewMouseMove;
            this.canvas.PreviewMouseLeftButtonUp += this.Canvas_PreviewMouseLeftButtonUp;
        }

        private void MoveTracks(FrameworkElement source, bool up)
        {
            var sourceTop = Canvas.GetTop(source);

            foreach (UIElement trackCanvas in this.canvas.Children)
            {
                var top = Canvas.GetTop(trackCanvas);
                if (top >= sourceTop && trackCanvas != source)
                {
                    Canvas.SetTop(trackCanvas, top - (up ? this.trackHeight : -this.trackHeight));
                }

            }
        }

        private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var handle = e.Source as TrackDragHandle;
            if (handle != null)
            {
                this.trackBeingMoved = handle.Parent as TrackElement;

                if (this.trackBeingMoved != null)
                {
                    MoveTracks(this.trackBeingMoved, true);

                    this.trackBeingMovedStartPoint = e.GetPosition(null);
                    this.trackBeingMovedOrigin = new Point(Canvas.GetLeft(this.trackBeingMoved), Canvas.GetTop(this.trackBeingMoved));
                    Canvas.SetLeft(this.trackBeingMoved, 20);
                    Canvas.SetZIndex(this.trackBeingMoved, 20);

                    // Create insertion point
                    this.insertionPointCanvas = new InsertionPointCanvas();
                    this.insertionPointCanvas.Width = this.canvas.ActualWidth;
                    Canvas.SetLeft(this.insertionPointCanvas, 0);
                    Canvas.SetTop(this.insertionPointCanvas, Canvas.GetTop(this.trackBeingMoved));
                    Canvas.SetZIndex(this.insertionPointCanvas, 10);

                    this.canvas.Children.Add(this.insertionPointCanvas);
                }
            }
        }

        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.trackBeingMoved != null)
            {
                // Position dragged track
                Point mousePos = e.GetPosition(null);
                Vector diff = this.trackBeingMovedStartPoint - mousePos;
                var y = this.trackBeingMovedOrigin.Y - diff.Y;
                Canvas.SetTop(this.trackBeingMoved, y);

                // Position insertion point
                if (this.insertionPointCanvas != null)
                {
                    var index = (((int)(y + 50)) / (int)this.trackHeight);
                    if (index >= this.canvas.Children.Count - 2)
                    {
                        index = this.canvas.Children.Count - 2;
                    }
                    if (index < 0)
                    {
                        index = 0;
                    }
                    Canvas.SetTop(this.insertionPointCanvas, this.trackHeight * index);
                }
            }
        }

        private void Canvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.trackBeingMoved != null)
            {
                Canvas.SetTop(this.trackBeingMoved, Canvas.GetTop(this.insertionPointCanvas));
                Canvas.SetLeft(this.trackBeingMoved, 0);
                Canvas.SetZIndex(this.trackBeingMoved, 0);

                MoveTracks(this.trackBeingMoved, false);

                this.trackBeingMoved = null;
            }

            if (this.insertionPointCanvas != null)
            {
                this.canvas.Children.Remove(this.insertionPointCanvas);
                this.insertionPointCanvas = null;
            }
        }
    }
}
