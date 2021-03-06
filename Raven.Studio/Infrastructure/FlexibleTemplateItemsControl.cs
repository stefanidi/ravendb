﻿using System.Windows;
using System.Windows.Controls;

namespace Raven.Studio.Infrastructure
{
    public class FlexibleTemplateItemsControl : ItemsControl
    {
        public static readonly DependencyProperty FirstItemTemplateProperty =
            DependencyProperty.Register("FirstItemTemplate", typeof (DataTemplate), typeof (FlexibleTemplateItemsControl), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate FirstItemTemplate
        {
            get { return (DataTemplate) GetValue(FirstItemTemplateProperty); }
            set { SetValue(FirstItemTemplateProperty, value); }
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            var itemIndex = ItemContainerGenerator.IndexFromContainer(element);
            if (itemIndex == 0 && FirstItemTemplate != null)
            {
                (element as ContentPresenter).ContentTemplate = FirstItemTemplate;
            } 
        }
    }
}