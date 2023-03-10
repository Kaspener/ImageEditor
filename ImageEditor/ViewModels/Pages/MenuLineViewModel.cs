using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.ViewModels.Pages
{
    public class MenuLineViewModel : ViewModelBase
    {
        private string name;
        private string startPoint;
        private string endPoint;
        private int colorNum;
        private int thicknessLine;

        public MenuLineViewModel()
        {
            Name = "";
            StartPoint = "";
            EndPoint = "";
            ColorNum = 0;
            ThicknessLine = 1;
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

        public int ColorNum
        {
            get => colorNum;
            set => this.RaiseAndSetIfChanged(ref colorNum, value);
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
    }
}
