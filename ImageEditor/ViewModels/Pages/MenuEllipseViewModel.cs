﻿using Avalonia.Media;
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
    public class MenuEllipseViewModel : ViewModelBase
    {
        private string name;
        private string startPoint;
        private string width;
        private string height;
        private int strokeNum;
        private int fillNum;
        private ObservableCollection<SolidColorBrush> colors;
        private double thicknessLine;

        public MenuEllipseViewModel()
        {
            Name = "";
            StartPoint = "";
            Width = "";
            Height = "";
            FillNum = 0;
            StrokeNum = 0;
            ThicknessLine = 1;
            Colors = new ObservableCollection<SolidColorBrush>();
            var brushes = typeof(Brushes).GetProperties().Select(brush => brush.GetValue(brush));
            foreach (object? el in brushes)
            {
                Colors.Add(Converters.StringToBrush(el.ToString()));
            }
        }

        public void SetIndexOfColor(SolidColorBrush color)
        {
            for (int i = 0; i < Colors.Count; i++)
            {
                if (Colors[i].Color == color.Color) { StrokeNum = i; break; }
            }
        }
        public void SetIndexOfColorFill(SolidColorBrush color)
        {
            for (int i = 0; i < Colors.Count; i++)
            {
                if (Colors[i].Color == color.Color) { FillNum = i; break; }
            }
        }

        public string StartPoint
        {
            get => startPoint;
            set => this.RaiseAndSetIfChanged(ref startPoint, value);
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
        public string Width
        {
            get => width;
            set => this.RaiseAndSetIfChanged(ref width, value);
        }
        public string Height
        {
            get => height;
            set => this.RaiseAndSetIfChanged(ref height, value);
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