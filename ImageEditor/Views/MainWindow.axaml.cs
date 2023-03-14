using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DynamicData;
using ImageEditor.Models;
using ImageEditor.ViewModels;
using SharpDX.WIC;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;

namespace ImageEditor.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void OpenFileDialogMenuXmlClick(object sender, RoutedEventArgs routedEventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<string> formates = new List<string>
            {
                "xml"
            };
            openFileDialog.Filters.Add(new FileDialogFilter { Extensions = formates });
            openFileDialog.AllowMultiple = false;
            string[]? result = await openFileDialog.ShowAsync(this);
            if (DataContext is MainWindowViewModel dataContext)
            {
                if (result != null)
                {
                    dataContext.FigureList = Serializer<ObservableCollection<Figures>>.Load(result[0]);
                }
            }

        }
        private async void OpenFileDialogMenuJsonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<string> formates = new List<string>
            {
                "json"
            };
            openFileDialog.Filters.Add(new FileDialogFilter { Extensions = formates, Name = "Json files" });
            openFileDialog.AllowMultiple = false;
            string[]? result = await openFileDialog.ShowAsync(this);
            if (DataContext is MainWindowViewModel dataContext)
            {
                if (result != null)
                {
                    dataContext.FigureList = JsonSerializer<ObservableCollection<Figures>>.Load(result[0]);
                }
            }

        }
        private async void SaveFileDialogMenuXmlClick(object sender, RoutedEventArgs routedEventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            List<string> formates = new List<string>
            {
                "xml"
            };
            saveFileDialog.Filters.Add(new FileDialogFilter { Extensions = formates, Name = "Xml files" });
            string? result = await saveFileDialog.ShowAsync(this);
            if (DataContext is MainWindowViewModel dataContext)
            {
                if (result != null)
                {
                    Serializer<ObservableCollection<Figures>>.Save(result, dataContext.FigureList);
                }
            }
        }
        private async void SaveFileDialogMenuJsonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            List<string> formates = new List<string>
            {
                "json"
            };
            saveFileDialog.Filters.Add(new FileDialogFilter { Extensions = formates, Name = "Json files" });
            string? result = await saveFileDialog.ShowAsync(this);
            if (DataContext is MainWindowViewModel dataContext)
            {
                if (result != null)
                {
                    JsonSerializer<ObservableCollection<Figures>>.Save(result, dataContext.FigureList);
                }
            }
        }

        private async void SaveFileDialogMenuPngClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var pixelSize = new PixelSize((int)canvas.Width, (int)canvas.Height);
            var size = new Size(canvas.Width, canvas.Height);
            using (RenderTargetBitmap bitmap = new RenderTargetBitmap(pixelSize, new Avalonia.Vector(96, 96)))
            {
                canvas.Measure(size);
                canvas.Arrange(new Rect(size));
                bitmap.Render(canvas);
                bitmap.Save("Image.png");
            }
        }
    }
}
