using DynamicData;
using ImageEditor.Models;
using ImageEditor.ViewModels.Pages;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;

namespace ImageEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int figureIndex;
        private object[] figureViews;
        private object content;
        private ObservableCollection<Figures> figureList;

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
            FigureList.Add(new Line { Name = "Line", StartPoint = "30, 40", EndPoint = "30, 115", ColorLine="Black", ThicknessLine=2});
            ClearParam = ReactiveCommand.Create(() =>  {
                if (figureViews[figureIndex] is MenuLineViewModel) figureViews[figureIndex] = new MenuLineViewModel();
                if (figureViews[figureIndex] is MenuPolylineViewModel) figureViews[figureIndex] = new MenuPolylineViewModel();
                if (figureViews[figureIndex] is MenuPolygonViewModel) figureViews[figureIndex] = new MenuPolygonViewModel();
                if (figureViews[figureIndex] is MenuRectangleViewModel) figureViews[figureIndex] = new MenuRectangleViewModel();
                if (figureViews[figureIndex] is MenuEllipseViewModel) figureViews[figureIndex] = new MenuEllipseViewModel();
                if (figureViews[figureIndex] is MenuPathViewModel) figureViews[figureIndex] = new MenuPathViewModel();
                FigureIndex = figureIndex;
            });
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

        public ObservableCollection<Figures> FigureList
        {
            get => figureList;
            set => this.RaiseAndSetIfChanged(ref figureList, value);
        }

        public ReactiveCommand<Unit, Unit> ClearParam { get; }
    }
}
