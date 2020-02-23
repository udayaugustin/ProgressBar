using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ProgressBar
{
    public class ProgressBar : ContentView
    {
        private Grid grid;
        private Frame frame;

        public static readonly BindableProperty BarListProperty =
            BindableProperty.Create(nameof(BarList), typeof(ObservableCollection<BarSegment>), typeof(ProgressBar), new ObservableCollection<BarSegment>());

        public ObservableCollection<BarSegment> BarList
        {
            get
            {
                return (ObservableCollection<BarSegment>)GetValue(BarListProperty);
            }
            set
            {
                SetValue(BarListProperty, value);
            }
        }

        public static readonly BindableProperty ProgressBarWidthProperty =
            BindableProperty.Create(nameof(ProgressBarWidth), typeof(double), typeof(ProgressBar), 100.0);

        public double ProgressBarWidth
        {
            get
            {
                return (double)GetValue(ProgressBarWidthProperty);
            }
            set
            {
                SetValue(ProgressBarWidthProperty, value);
            }
        }

        public static readonly BindableProperty ProgressBarHeightProperty =
            BindableProperty.Create(nameof(ProgressBarHeight), typeof(int), typeof(ProgressBar), 10);

        public int ProgressBarHeight
        {
            get
            {
                return Convert.ToInt32(GetValue(ProgressBarHeightProperty));
            }
            set
            {
                SetValue(ProgressBarHeightProperty, value);
            }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(ProgressBar), 5);

        public int CornerRadius
        {
            get
            {
                return Convert.ToInt32(GetValue(CornerRadiusProperty));
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        public ProgressBar()
        {
            
            BindingContext = this;

            grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{  Height = new GridLength(ProgressBarHeight, GridUnitType.Absolute)}
                },
                ColumnSpacing = 0,
                WidthRequest = ProgressBarWidth,
                HorizontalOptions = LayoutOptions.Start
            };

            frame = new Frame
            {
                Padding = 0,
                IsClippedToBounds = true,
                CornerRadius = CornerRadius,
                WidthRequest = ProgressBarWidth,
                HeightRequest = ProgressBarHeight,
                HasShadow = false,
                HorizontalOptions = LayoutOptions.Start,
                BorderColor = Color.Transparent
            };

            frame.Content = grid;

            Content = frame;

            BarList.CollectionChanged += StatusList_CollectionChanged;
        }

        private void StatusList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var index = e.NewStartingIndex;
            var item = BarList[index];

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = item.BarWidth });
            var boxView = new BoxView
            {
                BackgroundColor = item.BarColor,
            };

            grid.Children.Add(boxView, index, 0);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ProgressBarWidthProperty.PropertyName)
            {
                grid.WidthRequest = ProgressBarWidth;
                frame.WidthRequest = ProgressBarWidth;

            }
            else if (propertyName == ProgressBarHeightProperty.PropertyName)
            {
                frame.HeightRequest = ProgressBarHeight;
                grid.HeightRequest = ProgressBarHeight;
                grid.RowDefinitions.FirstOrDefault().Height = ProgressBarHeight;
            }
        }
    }


    public class BarSegment : ContentView
    {
        public static readonly BindableProperty BarWidthProperty =
            BindableProperty.Create(nameof(BarWidth), typeof(GridLength), typeof(BarSegment), new GridLength(20, GridUnitType.Star));

        public GridLength BarWidth
        {
            get
            {
                return (GridLength)GetValue(BarWidthProperty);
            }
            set
            {
                SetValue(BarWidthProperty, value);
            }
        }

        public static readonly BindableProperty BarColorProperty =
            BindableProperty.Create(nameof(BarColor), typeof(Color), typeof(BarSegment), Color.Red);

        public Color BarColor
        {
            get
            {
                return (Color)GetValue(BarColorProperty);
            }
            set
            {
                SetValue(BarColorProperty, value);
            }
        }
    }
}

