﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfNotifications.Core;

namespace WpfNotifications.Display
{
    public class NotificationAnimator : INotificationAnimator
    {
        private readonly NotificationDisplayPart _displayPart;
        private readonly TimeSpan _showAnimationTime;
        private readonly TimeSpan _hideAnimationTime;

        public NotificationAnimator(NotificationDisplayPart displayPart, TimeSpan showAnimationTime, TimeSpan hideAnimationTime)
        {
            _displayPart = displayPart;
            _showAnimationTime = showAnimationTime;
            _hideAnimationTime = hideAnimationTime;
        }

        public void Setup()
        {
            ScaleTransform scale = new ScaleTransform(1, 0);
            _displayPart.RenderTransform = scale;
        }

        public void PlayShowAnimation()
        {
            var scale = (ScaleTransform)_displayPart.RenderTransform;
            scale.CenterY = _displayPart.Height / 2;
            scale.CenterX = _displayPart.ActualWidth / 2;

            Storyboard storyboard = new Storyboard();

            DoubleAnimation growYAnimation = new DoubleAnimation
            {
                Duration = _showAnimationTime,
                From = 0,
                To = 1
            };
            storyboard.Children.Add(growYAnimation);

            DoubleAnimation growXAnimation = new DoubleAnimation
            {
                Duration = _showAnimationTime,
                From = 0,
                To = 1
            };
            storyboard.Children.Add(growXAnimation);

            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                Duration = _showAnimationTime,
                From = 0,
                To = 1
            };
            storyboard.Children.Add(fadeInAnimation);

            Storyboard.SetTargetProperty(growYAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(growYAnimation, _displayPart);

            Storyboard.SetTargetProperty(growXAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTarget(growXAnimation, _displayPart);

            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity"));
            Storyboard.SetTarget(fadeInAnimation, _displayPart);

            storyboard.Begin();
        }

        public void PlayHideAnimation()
        {
            var scale = (ScaleTransform)_displayPart.RenderTransform;
            scale.CenterY = _displayPart.Height / 2;
            scale.CenterX = _displayPart.ActualWidth / 2;

            Storyboard storyboard = new Storyboard();

            DoubleAnimation shrinkYAnimation = new DoubleAnimation
            {
                Duration = _hideAnimationTime,
                From = 1,
                To = 0
            };

            storyboard.Children.Add(shrinkYAnimation);

            DoubleAnimation shrinkXAnimation = new DoubleAnimation
            {
                Duration = _hideAnimationTime,
                From = 1,
                To = 0
            };

            storyboard.Children.Add(shrinkXAnimation);

            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                Duration = _hideAnimationTime,
                From = 1,
                To = 0
            };

            storyboard.Children.Add(fadeInAnimation);

            Storyboard.SetTargetProperty(shrinkYAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(shrinkYAnimation, _displayPart);
            Storyboard.SetTargetProperty(shrinkXAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTarget(shrinkXAnimation, _displayPart);

            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity"));
            Storyboard.SetTarget(fadeInAnimation, _displayPart);

            storyboard.Begin();
        }
    }
}