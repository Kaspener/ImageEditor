using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ImageEditor.Models;
using ImageEditor.ViewModels.Pages;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reactive;
using System.Xml.Linq;

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
            FigureList = new ObservableCollection<Figures>();
            Shapes = new ObservableCollection<Shape>();
            FigureListIndex = -1;
            figureViews[0] = new MenuLineViewModel(this);
            figureViews[1] = new MenuPolylineViewModel();
            figureViews[2] = new MenuPolygonViewModel();
            figureViews[3] = new MenuRectangleViewModel();
            figureViews[4] = new MenuEllipseViewModel();
            figureViews[5] = new MenuPathViewModel();
            FigureIndex = 0;
            FigureList.Add(new LineElement { Name = "Line", EndPoint = "30, 30", StartPoint = "-16, 12", StrokeColor = "Red", StrokeThickness = 12}) ;
            FigureList[0] = new LineElement { Name = "Line", EndPoint = "30, 30", StartPoint = "-16, 12", StrokeColor = "Red", StrokeThickness = 16 };
            Shapes.Add(ElementToShape(FigureList[0]));
            ClearParam = ReactiveCommand.Create(() =>  {
                FigureListIndex = -1;
                if (figureViews[figureIndex] is MenuLineViewModel newObject)
                {
                    newObject.Name = "";
                    newObject.StartPoint = "";
                    newObject.EndPoint = "";
                    newObject.StrokeNum = 0;
                    newObject.ThicknessLine = 1;
                }
                if (figureViews[figureIndex] is MenuPolylineViewModel) figureViews[figureIndex] = new MenuPolylineViewModel();
                if (figureViews[figureIndex] is MenuPolygonViewModel) figureViews[figureIndex] = new MenuPolygonViewModel();
                if (figureViews[figureIndex] is MenuRectangleViewModel) figureViews[figureIndex] = new MenuRectangleViewModel();
                if (figureViews[figureIndex] is MenuEllipseViewModel) figureViews[figureIndex] = new MenuEllipseViewModel();
                if (figureViews[figureIndex] is MenuPathViewModel) figureViews[figureIndex] = new MenuPathViewModel();
                FigureIndex = figureIndex;
            });
        }

        private Shape ElementToShape(Figures obj)
        {
            if (obj is LineElement line) return new Line
            {
                Name = line.Name,
                StartPoint = Converters.StringToPoint(line.StartPoint),
                EndPoint = Converters.StringToPoint(line.EndPoint),
                Stroke = Converters.StringToBrush(line.StrokeColor),
                StrokeThickness = line.StrokeThickness
            };
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
            set 
            {
                this.RaiseAndSetIfChanged(ref figureListIndex, value);
                if (figureListIndex != -1)
                {
                    if (FigureList[figureListIndex] is LineElement line)
                    {
                        FigureIndex = 0;
                        if (Content is MenuLineViewModel cont)
                        {
                            cont.Name = line.Name;
                            cont.StartPoint = line.StartPoint;
                            cont.EndPoint = line.EndPoint;
                            cont.SetIndexOfColor(Converters.StringToBrush(line.StrokeColor));
                            cont.ThicknessLine = line.StrokeThickness;
                        }
                    }
                }
            }
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
