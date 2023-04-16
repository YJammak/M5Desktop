using System;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;

namespace M5App
{
    public class MainWindow : PresentationWindow
    {
        private sealed class Cross : Shape
        {
            /// <summary>
            /// The default constructor.
            /// </summary>
            public Cross() { }

            /// <summary>
            /// To manual draw, override the OnRender method and draw using 
            /// standard drawing type functions.
            /// </summary>
            /// <param name="dc"></param>
            public override void OnRender(DrawingContext dc)
            {
                // Draw a line from top, left to bottom, right
                dc.DrawLine(base.Stroke, 0, 0, Width, Height);

                // Draw a line from top, right to bottom, left
                dc.DrawLine(base.Stroke, Width, 0, 0, Height);
            }
        }

        public MainWindow(App app) : base(app)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var panel = new StackPanel(Orientation.Vertical);
            this.Child = panel;
            panel.Visibility = Visibility.Visible;

            // This is an array of different shapes to be drawn.
            var shapes = new Shape[] { new Ellipse(0, 0),
                new Line(),         // A square.
                new Polygon(new[] { 0, 0,    50, 0,    50, 50,    0, 50 }),
                new Rectangle(),

                new Cross()  // A custom shape.
            };

            // Set up the needed member values for each shape.
            for (var x = 0; x < shapes.Length; x++)
            {
                var s = shapes[x];
                s.Fill = new SolidColorBrush(ColorUtility.ColorFromRGB(0, 255, 0));
                s.Stroke = new Pen(Color.Black, 2);
                s.Visibility = Visibility.Visible;
                s.HorizontalAlignment = HorizontalAlignment.Center;
                s.VerticalAlignment = VerticalAlignment.Center;
                s.Height = Height - 1;
                s.Width = Width - 1;

                if (panel.Orientation == Orientation.Horizontal)
                    s.Width /= shapes.Length;
                else
                    s.Height /= shapes.Length;

                panel.Children.Add(s);
            }
        }
    }
}
