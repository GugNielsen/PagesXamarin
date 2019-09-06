//using System.Linq;
//using System.Collections.Generic;
//using Xamarin.Forms;
//using dnamethod.DTOs;

//namespace dnamethod.ControlsXamarin
//{
//    public class ListOption : ContentView
//    {
//        public static readonly BindableProperty OptionsProperty =
//            BindableProperty.Create(
//                nameof(ResponseOptionDto),
//                typeof(IList<ResponseOptionDto>),
//                typeof(ListOption),
//                null,
//                propertyChanged: OnPropertyChanged
//            );

//        public IList<ResponseOptionDto> Options
//        {
//            get => (IList<ResponseOptionDto>)GetValue(OptionsProperty);
//            set => SetValue(OptionsProperty, value);
//        }

//        private static ListOption _instance;
//        private static StackLayout _stackLayout;

//        public ListOption()
//        {
//            _instance = this;
//            _stackLayout = new StackLayout();
//        }

//        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
//        {
//            if (!(newValue is IList<ResponseOptionDto> options)) return;

//            _stackLayout.Children.Clear();

//            foreach (var option in options)
//            {
//                var grid = new Grid()
//                {
//                    ColumnDefinitions =
//                    {
//                        new ColumnDefinition() { Width = new GridLength(70, GridUnitType.Absolute) },
//                        new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) }
//                    },
//                    Margin = new Thickness(10)
//                };

//                var tap = new TapGestureRecognizer();
//                tap.Tapped += (sender, e) =>
//                {
//                    UnselectAllOptions();
//                    SelectOption(sender as Grid);
//                };
//                grid.GestureRecognizers.Add(tap);

//                var image = new Image()
//                {
//                    Source = "option.png",
//                    HeightRequest = 24
//                };

//                var label = new Label()
//                {
//                    Text = option.Description,
//                    TextColor = Color.White,
//                    VerticalOptions = LayoutOptions.CenterAndExpand
//                };

//                grid.Children.Add(image, 0, 0);
//                grid.Children.Add(label, 1, 0);

//                _stackLayout.Children.Add(grid);
//            }

//            _instance.Content = _stackLayout;
//        }

//        private static void UnselectAllOptions()
//        {
//            var grids = (IList<Grid>)_stackLayout.Children;
//            if (grids == null)
//                return;

//            foreach (var grid in grids)
//            {
//                if (!(grid.Children.FirstOrDefault() is Image image)) continue;

//                image.Source = "option.png";
//            }
//        }

//        private static void SelectOption(Grid grid)
//        {
//            if (!(grid?.Children.FirstOrDefault() is Image selectedImage)) return;

//            selectedImage.Source = "option-selected.png";
//        }
//    }
//}