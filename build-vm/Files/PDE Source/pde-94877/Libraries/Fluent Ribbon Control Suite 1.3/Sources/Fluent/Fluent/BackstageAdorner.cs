﻿#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Fluent
{
    /// <summary>
    /// Represents adorner for Backstage
    /// </summary>
    internal class BackstageAdorner :Adorner
    {
        #region Fields

        // Backstage
        readonly UIElement backstage;
        // Adorner offset from top of window
        readonly double topOffset;
        // Collection of visual children
        readonly VisualCollection visualChildren;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="adornedElement">Adorned element</param>
        /// <param name="backstage">Backstage</param>
        /// <param name="topOffset">Adorner offset from top of window</param>
        public BackstageAdorner(FrameworkElement adornedElement, UIElement backstage, double topOffset) : base(adornedElement)
        {
            this.backstage = backstage;
            this.topOffset = topOffset;
            visualChildren = new VisualCollection(this);
            visualChildren.Add(backstage);

            // TODO: fix it! (below ugly workaround) in measureoverride we cannot get RenderSize, we must use DesiredSize
            // Syncronize with visual size
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += CompositionTargetRendering;
        }

        void OnUnloaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= CompositionTargetRendering;
        }

        void CompositionTargetRendering(object sender, System.EventArgs e)
        {
            if (RenderSize != AdornedElement.RenderSize) InvalidateMeasure();
        }

        #endregion

        #region Layout & Visual Children

        /// <summary>
        /// Positions child elements and determines
        /// a size for the control
        /// </summary>
        /// <param name="finalSize">The final area within the parent 
        /// that this element should use to arrange 
        /// itself and its children</param>
        /// <returns>The actual size used</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            backstage.Arrange(new Rect(0, topOffset, finalSize.Width, finalSize.Height - topOffset));            
            return finalSize;
        }

        /// <summary>
        /// Measures KeyTips
        /// </summary>
        /// <param name="constraint">The available size that this element can give to child elements.</param>
        /// <returns>The size that the groups container determines it needs during 
        /// layout, based on its calculations of child element sizes.
        /// </returns>
        protected override Size MeasureOverride(Size constraint)
        {
            // TODO: fix it! (below ugly workaround) in measureoverride we cannot get RenderSize, we must use DesiredSize
            backstage.Measure(new Size(AdornedElement.RenderSize.Width,AdornedElement.RenderSize.Height - this.topOffset));
            return AdornedElement.RenderSize;
        }

        /// <summary>
        /// Gets visual children count
        /// </summary>
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }

        /// <summary>
        /// Returns a child at the specified index from a collection of child elements
        /// </summary>
        /// <param name="index">The zero-based index of the requested child element in the collection</param>
        /// <returns>The requested child element</returns>
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }

        #endregion
    }
}
