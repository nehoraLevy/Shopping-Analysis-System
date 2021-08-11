﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace WPFDemo
{
    public partial class WPFDemoWindow : Window
    {
        public WPFDemoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }


        #region Carousel

        private void CarouselSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ExampleCarouselControl.RotationSpeed = e.NewValue;
        }

        private void LookdownOffsetSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ExampleCarouselControl.LookDownOffset = e.NewValue;
            ExampleCarouselControl.SetElementPositions();
        }

        private void CarouselFadeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ExampleCarouselControl.Fade = e.NewValue;
            ExampleCarouselControl.SetElementPositions();
        }

        private void CarouselScaleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ExampleCarouselControl.Scale = e.NewValue;
            ExampleCarouselControl.SetElementPositions();
        }

        private void VerticalOrientationRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ExampleCarouselControl.Width = 0;
            ExampleCarouselControl.Height = 600;
            ExampleCarouselControl.ReInitialize();
        }

        private void HorizontalOrientationRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ExampleCarouselControl.Width = 600;
            ExampleCarouselControl.Height = 0;
            ExampleCarouselControl.ReInitialize();
        }

        private void ExampleCarouselControl_OnElementSelected(object sender)
        {
            SphereControl selected = ExampleCarouselControl.CurrentlySelected as SphereControl;
            if (CurrentlySelectedEllipse != null)
                CurrentlySelectedEllipse.Fill = selected.SphereFill;
            if ((CurrentlySelectedNameTextBlock != null) && (CurrentlySelectedNameShadowTextBlock != null))
            {
                CurrentlySelectedNameTextBlock.Foreground = selected.SphereFill;
                CurrentlySelectedNameTextBlock.Text = selected.Name;
                CurrentlySelectedNameShadowTextBlock.Text = selected.Name;
            }
        }

        #endregion
        


       }
}
