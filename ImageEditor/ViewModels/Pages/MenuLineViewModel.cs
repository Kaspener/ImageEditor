using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageEditor.Models;
using Avalonia.Controls.Shapes;

namespace ImageEditor.ViewModels.Pages
{
    public class MenuLineViewModel : ViewModelBase
    {
        private string name;
        private string startPoint;
        private string endPoint;
        private int itemNum;
        private ObservableCollection<Rectangle> colors;
        private int thicknessLine;

        public MenuLineViewModel()
        {
            Name = "";
            StartPoint = "";
            EndPoint = "";
            itemNum = 0;
            ThicknessLine = 1;
            Colors = new ObservableCollection<Rectangle>();
            var brushes = typeof(Brushes).GetProperties().Select(brush => brush.GetValue(brush));
            foreach(object? el in brushes)
            {
                Colors.Add(new Rectangle { Fill = Converters.StringToBrush(el.ToString()) });
            }
        }

        public string StartPoint
        {
            get => startPoint;
            set => this.RaiseAndSetIfChanged(ref startPoint, value);
        }

        public string EndPoint
        {
            get => endPoint;
            set => this.RaiseAndSetIfChanged(ref endPoint, value);
        }
        public int ThicknessLine
        {
            get => thicknessLine;
            set => this.RaiseAndSetIfChanged(ref thicknessLine, value);
        }
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public int ItemNum
        {
            get => itemNum;
            set => this.RaiseAndSetIfChanged(ref itemNum, value);
        }

        public ObservableCollection<Rectangle> Colors
        {
            get => colors;
            set => this.RaiseAndSetIfChanged(ref colors, value);
        }
    }
}
