
using Xamarin.Forms;

namespace colorpicker
{
    public class ColPicker : ContentPage
    {
        public ColPicker()
        {
            CreateUI();
        }

        string ConvertToHex(double red, double green, double blue, double opacity)
        {
            return string.Format("#{0:X}{1:X}{2:X}{3:X}", (int)opacity, (int)red, (int)green, (int)blue);
        }

        void CreateUI()
        {
            double red = 255 * .5, green = 255 * .5, blue = 255 * .5, opacity = 255;
            double realRed = .5, realGreen = .5, realBlue = .5, realOpacity = 1;

            var redSlider = new Slider
            {
                WidthRequest = App.ScreenSize.Width * .6,
                Value = realRed
            };
            var blueSlider = new Slider
            {
                WidthRequest = App.ScreenSize.Width * .6,
                Value = realGreen
            };
            var greenSlider = new Slider
            {
                WidthRequest = App.ScreenSize.Width * .6,
                Value = realBlue
            };
            var opacitySlider = new Slider
            {
                WidthRequest = App.ScreenSize.Width * .6,
                Value = realOpacity
            };

            var lblRed = new Label
            {
                Text = red.ToString("##.##"),
                WidthRequest = App.ScreenSize.Width * .2,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var lblGreen = new Label
            {
                Text = green.ToString("##.##"),
                WidthRequest = App.ScreenSize.Width * .2,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var lblBlue = new Label
            {
                Text = blue.ToString("##.##"),
                WidthRequest = App.ScreenSize.Width * .2,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var lblOpacity = new Label
            {
                Text = opacity.ToString("##.##"),
                WidthRequest = App.ScreenSize.Width * .2,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var lblHex = new Label
            {
                WidthRequest = App.ScreenSize.Width * .5,
                Text = ConvertToHex(red, green, blue, opacity)
            };

            var colorBox = new BoxView
            {
                WidthRequest = App.ScreenSize.Width * .3,
                HeightRequest = App.ScreenSize.Height * .2,
                Color = Color.FromRgba(realRed, realGreen, realBlue, realOpacity),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            redSlider.ValueChanged += (object sender, ValueChangedEventArgs e) =>
            {
                realRed = e.NewValue;
                red = e.NewValue * 255;
                lblRed.Text = red.ToString("##.##");
                lblHex.Text = ConvertToHex(red, green, blue, opacity);
                Device.BeginInvokeOnMainThread(() => colorBox.Color = Color.FromRgba(realRed, realGreen, realBlue, realOpacity));
            };

            greenSlider.ValueChanged += (object sender, ValueChangedEventArgs e) =>
            {
                realGreen = e.NewValue;
                green = e.NewValue * 255;
                lblGreen.Text = green.ToString("##.##");
                lblHex.Text = ConvertToHex(red, green, blue, opacity);
                Device.BeginInvokeOnMainThread(() => colorBox.Color = Color.FromRgba(realRed, realGreen, realBlue, realOpacity));
            };

            blueSlider.ValueChanged += (object sender, ValueChangedEventArgs e) =>
            {
                realBlue = e.NewValue;
                blue = e.NewValue * 255;
                lblBlue.Text = blue.ToString("##.##");
                lblHex.Text = ConvertToHex(red, green, blue, opacity);
                Device.BeginInvokeOnMainThread(() => colorBox.Color = Color.FromRgba(realRed, realGreen, realBlue, realOpacity));
            };

            opacitySlider.ValueChanged += (object sender, ValueChangedEventArgs e) =>
            {
                realOpacity = e.NewValue;
                opacity = e.NewValue * 255;
                lblOpacity.Text = opacity.ToString("##.##");
                lblHex.Text = ConvertToHex(red, green, blue, opacity);
                Device.BeginInvokeOnMainThread(() => colorBox.Color = Color.FromRgba(realRed, realGreen, realBlue, realOpacity));
            };

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(12),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = "Color Picker",
                                FontSize = 22,
                                HorizontalTextAlignment = TextAlignment.Center,
                                TextColor = Color.Fuchsia
                            }
                        }
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children =
                        {
                            new Label
                            {
                                Text = "Red"
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Children = {redSlider, lblRed}
                            }
                        }
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children =
                        {
                            new Label
                            {
                                Text = "Green"
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Children = {greenSlider, lblGreen}
                            }
                        }
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children =
                        {
                            new Label
                            {
                                Text = "Blue"
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Children = {blueSlider, lblBlue}
                            }
                        }
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children =
                        {
                            new Label
                            {
                                Text = "Opacity"
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Children = {opacitySlider, lblOpacity}
                            }
                        }
                    },
                    colorBox,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label
                            {
                                Text= "HEX :"
                            },
                            lblHex
                        }
                    }
                }
            };
        }
    }
}

