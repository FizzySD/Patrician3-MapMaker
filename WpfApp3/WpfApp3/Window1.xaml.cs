using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3;

namespace Main
{
    /// <summary>
    /// Logica di interazione per Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bool canDraw = true;
        List<PathEllipse> pathEllipseList = new List<PathEllipse>();
        private Double zoomMax = 5;
        private Double zoomMin = 1;
        private Double zoomSpeed = 0.001;
        private Double zoom = 1;
        String _ImageSource;
        private Point startPoint;
        ImageExtractor ImgHandler;

        public Window1(string Source)
        {
            _ImageSource = Source;
            InitializeComponent();
            LoadImage(Source);
            ImgHandler = new ImageExtractor();
        }
        private void _Drag(object sender, RoutedEventArgs e)
        {
            //TO IMPLEMENT
            //DragMove();
        }
        private void LoadImage(string src)
        {
            var uri = new Uri(src);
            var bitmap = new BitmapImage(uri);
            image1.Source = bitmap;
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (canDraw)// && Mouse.GetPosition(preview).X > 15 && Mouse.GetPosition(preview).Y > 15 && Mouse.GetPosition(preview).Y < 455)
            {
                if (pathEllipseList.Count >= 1)
                {
                    PathEllipse elipse = new PathEllipse(2, 2, Brushes.Red, Mouse.GetPosition(preview).X, Mouse.GetPosition(preview).Y);
                    PathEllipse firstEllipse = pathEllipseList[0];

                    double tolerance = 2f; // Puoi regolare questa tolleranza in base alle tue esigenze

                    bool coordinatesMatch =
                        Math.Abs(elipse.Coordinates.X - firstEllipse.Coordinates.X) < tolerance &&
                        Math.Abs(elipse.Coordinates.Y - firstEllipse.Coordinates.Y) < tolerance;

                    if (!coordinatesMatch)
                    {
                        preview.Children.Add(elipse.GetEllipse());
                        pathEllipseList.Add(elipse);
                    }
                    else
                    {
                        preview.Children.Add(elipse.GetEllipse());
                        pathEllipseList.Add(elipse);
                        canDraw = false;
                        FillArea();
                    }
                }
                else
                {
                    PathEllipse elipse = new PathEllipse(2, 2, Brushes.Orange, Mouse.GetPosition(preview).X, Mouse.GetPosition(preview).Y);
                    preview.Children.Add(elipse.GetEllipse());
                    pathEllipseList.Add(elipse);                  
                }
            }
        }
        private void SaveCanvas(object sender, RoutedEventArgs e)
        {
            drawingCanvas.Children.Remove(image1);
            SaveCanvasToFile(this, drawingCanvas, 64 , "output.bmp");
            drawingCanvas.Children.Add(image1);
            Panel.SetZIndex(image1, 0);
            ImgHandler.ConvertImage();
        }

        private void FillArea()
        {
            if (pathEllipseList.Count >= 2) // Verifica che ci siano almeno due punti
            {
                // Crea un oggetto Polygon
                Polygon polygon = new Polygon
                {
                    Fill = Brushes.Cyan, // Colore di riempimento
                    Opacity = 1 // Opacità (modificabile a tuo piacimento)
                };

                // Aggiungi i punti del percorso al Polygon
                foreach (PathEllipse pathEllipse in pathEllipseList)
                {
                    Point point = pathEllipse.Coordinates;
                    polygon.Points.Add(point);
                }

                // Chiudi il percorso aggiungendo il primo punto
                polygon.Points.Add(pathEllipseList[0].Coordinates);
                Panel.SetZIndex(polygon, 1);
                // Aggiungi il Polygon alla canvas
                drawingCanvas.Children.Add(polygon);
                pathEllipseList.Clear();
                preview.Children.Clear();
                canDraw = true;
            }
        }

        public static void SaveCanvasToFile(Window window, Canvas canvas, int dpi, string filename)
        {
            var rtb = new RenderTargetBitmap(
                (int)640, //width
                (int)472, //height
                96, //dpi x
                96, //dpi y
                PixelFormats.Pbgra32 // pixelformat
                );
            DrawingVisual visual = new DrawingVisual();
            rtb.Render(canvas);

            SaveRTBAsPNGBMP(rtb, filename);
        }

        private static void SaveRTBAsPNGBMP(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));

            using (var stm = System.IO.File.Create(filename))
            {
                enc.Save(stm);
            }
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            zoom += zoomSpeed * e.Delta; // Ajust zooming speed (e.Delta = Mouse spin value )
            if (zoom < zoomMin) { zoom = zoomMin; } // Limit Min Scale
            if (zoom > zoomMax) { zoom = zoomMax; } // Limit Max Scale

            if (zoom < zoomMax)
            {

                Point mousePos = e.GetPosition(drawingCanvas);
                if (e.Delta > 0) 
                {
                    if (zoom > 1)
                    {
                        drawingCanvas.RenderTransform = new ScaleTransform(zoom, zoom, mousePos.X, mousePos.Y); // transform Canvas size from mouse position
                    }
                    else
                    {
                        drawingCanvas.RenderTransform = new ScaleTransform(zoom, zoom); // transform Canvas size
                    }
                }
                else 
                {
                    if (zoom > 1)
                    {
                        drawingCanvas.RenderTransform = new ScaleTransform(zoom, zoom, mousePos.X, mousePos.Y); // transform Canvas size from mouse position
                    }
                    else
                    {
                        drawingCanvas.RenderTransform = new ScaleTransform(zoom, zoom); // transform Canvas size
                    }
                }
            }
        }
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //isDrawing = false;
        }
    }
}

