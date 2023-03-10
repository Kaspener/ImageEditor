using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using ImageEditor.ViewModels;

namespace ImageEditor.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButtonClick(object? sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel window)
            {
                // оставшаяся логика
            }
        }

    }
}
