using Avalonia.Media;
using ImageEditor.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.ViewModels.Pages
{
    public class MenuPolygonViewModel : ViewModelBase
    {
        private string name;
        private string points;
        private int strokeNum;
        private int fillNum;
        private ObservableCollection<SolidColorBrush> colors;
        private double thicknessLine;

        public MenuPolygonViewModel()
        {
            Name = "";
            Points = "";
            StrokeNum = 0;
            FillNum = 0;
            ThicknessLine = 1;
            Colors = new ObservableCollection<SolidColorBrush>();
            var brushes = typeof(Brushes).GetProperties().Select(brush => brush.GetValue(brush));
            foreach (object? el in brushes)
            {
                Colors.Add(Converters.StringToBrush(el.ToString()));
            }
        }

        public string Points
        {
            get => points;
            set => this.RaiseAndSetIfChanged(ref points, value);
        }
        public double ThicknessLine
        {
            get => thicknessLine;
            set => this.RaiseAndSetIfChanged(ref thicknessLine, value);
        }
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public int StrokeNum
        {
            get => strokeNum;
            set => this.RaiseAndSetIfChanged(ref strokeNum, value);
        }

        public int FillNum
        {
            get => fillNum;
            set => this.RaiseAndSetIfChanged(ref fillNum, value);
        }
        public ObservableCollection<SolidColorBrush> Colors
        {
            get => colors;
            set => this.RaiseAndSetIfChanged(ref colors, value);
        }
    }
}
