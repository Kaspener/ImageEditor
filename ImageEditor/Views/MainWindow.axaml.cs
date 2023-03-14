using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using DynamicData;
using ImageEditor.Models;
using ImageEditor.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            string? result = await saveFileDialog.ShowAsync(this);
            if (DataContext is MainWindowViewModel dataContext)
            {
                if (result != null)
                {
                    JsonSerializer<ObservableCollection<Figures>>.Save(result, dataContext.FigureList);
                }
            }
        }
    }
}
