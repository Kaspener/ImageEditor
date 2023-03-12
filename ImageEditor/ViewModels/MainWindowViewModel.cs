using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ImageEditor.Models;
using ImageEditor.ViewModels.Pages;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text.Json;

namespace ImageEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int figureIndex;
        private int figureListIndex;
        private object[] figureViews;
        private object content;
        private ObservableCollection<Figures> figureList;
        private ObservableCollection<Shape> shapes;

        public MainWindowViewModel()
        {
            figureViews = new object[6];
            figureViews[0] = new MenuLineViewModel();
            figureViews[1] = new MenuPolylineViewModel();
            figureViews[2] = new MenuPolygonViewModel();
            figureViews[3] = new MenuRectangleViewModel();
            figureViews[4] = new MenuEllipseViewModel();
            figureViews[5] = new MenuPathViewModel();
            FigureIndex = 0;
            FigureList = new ObservableCollection<Figures>();
            Shapes = new ObservableCollection<Shape>();
            Shapes.Add(new Line { StartPoint = new Avalonia.Point(30, 30), EndPoint = new Avalonia.Point(50, 50), Stroke = new SolidColorBrush(Colors.Red), StrokeThickness = 1 });
            Shapes.Add(new Ellipse {Width = 50, Height = 60, Fill = new SolidColorBrush(Colors.Red), Margin = new Avalonia.Thickness(50, 0, 0, 0) });
            FigureList.Add(new LineElement { Name = "srt", EndPoint = "30, 30", StartPoint = "30, 30", StrokeNum = 1, StrokeThickness = 1}) ;
            ElementToShape(FigureList[0]);
            FigureListIndex = -1;
            ClearParam = ReactiveCommand.Create(() =>  {
                FigureListIndex = -1;
                if (figureViews[figureIndex] is MenuLineViewModel) figureViews[figureIndex] = new MenuLineViewModel();
                if (figureViews[figureIndex] is MenuPolylineViewModel) figureViews[figureIndex] = new MenuPolylineViewModel();
                if (figureViews[figureIndex] is MenuPolygonViewModel) figureViews[figureIndex] = new MenuPolygonViewModel();
                if (figureViews[figureIndex] is MenuRectangleViewModel) figureViews[figureIndex] = new MenuRectangleViewModel();
                if (figureViews[figureIndex] is MenuEllipseViewModel) figureViews[figureIndex] = new MenuEllipseViewModel();
                if (figureViews[figureIndex] is MenuPathViewModel) figureViews[figureIndex] = new MenuPathViewModel();
                FigureIndex = figureIndex;
            });
        }

        public Shape ElementToShape(Figures obj)
        {
            if (obj is LineElement) return new Line {Name = obj.Name };
            return null;
        }

        public object Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public int FigureIndex
        {
            get => figureIndex;
            set {
                this.RaiseAndSetIfChanged(ref figureIndex, value);
                Content = figureViews[figureIndex];
            }
        }
        public int FigureListIndex
        {
            get => figureListIndex;
            set => this.RaiseAndSetIfChanged(ref figureListIndex, value);
        }

        public ObservableCollection<Figures> FigureList
        {
            get => figureList;
            set => this.RaiseAndSetIfChanged(ref figureList, value);
        }

        public ObservableCollection<Shape> Shapes
        {
            get => shapes;
            set => this.RaiseAndSetIfChanged(ref shapes, value);
        }

        public ReactiveCommand<Unit, Unit> ClearParam { get; }
    }
}
