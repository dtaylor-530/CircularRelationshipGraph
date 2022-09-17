using CircularRelationshipGraph.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;

namespace CircularRelationshipGraph
{
    public partial class RelationshipGraph
    {
        #region fields

        private Panel _graphContainer;

        private Dictionary<INode, NodeSegment> _segmentForNode = new Dictionary<INode, NodeSegment>();

        #endregion fields

        #region DP change handlers

        private partial void OnDataPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnInnerRadiusPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnConnectorFillInterpolatorPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnConnectorThicknessPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnLabelRadiusPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnNodeConnectorStylePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnNodeSegmentStylePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnOuterRadiusPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnSegmentFillInterpolatorPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Render();
        }

        private partial void OnSortOrderProviderPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            var sortedData = SortOrderProvider.Sort(Data);
            AnimateToOrder(sortedData);
        }

        #endregion DP change handlers

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public INodeList Data
        {
            get { return (INodeList)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        /// <summary>
        /// Defines the Data dependnecy property.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(INodeList), typeof(RelationshipGraph),
                new PropertyMetadata(null, new PropertyChangedCallback(OnDataPropertyChanged)));

        /// <summary>
        /// Invoked when the Data property changes
        /// </summary>
        private partial void OnDataPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnDataPropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public Interpolator SegmentFillInterpolator
        {
            get { return (Interpolator)GetValue(SegmentFillInterpolatorProperty); }
            set { SetValue(SegmentFillInterpolatorProperty, value); }
        }

        /// <summary>
        /// Defines the SegmentFillInterpolator dependnecy property.
        /// </summary>
        public static readonly DependencyProperty SegmentFillInterpolatorProperty =
            DependencyProperty.Register("SegmentFillInterpolator", typeof(Interpolator), typeof(RelationshipGraph),
                new PropertyMetadata(null, new PropertyChangedCallback(OnSegmentFillInterpolatorPropertyChanged)));

        /// <summary>
        /// Invoked when the SegmentFillInterpolator property changes
        /// </summary>
        private partial void OnSegmentFillInterpolatorPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnSegmentFillInterpolatorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnSegmentFillInterpolatorPropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public Interpolator ConnectorFillInterpolator
        {
            get { return (Interpolator)GetValue(ConnectorFillInterpolatorProperty); }
            set { SetValue(ConnectorFillInterpolatorProperty, value); }
        }

        /// <summary>
        /// Defines the ConnectorFillInterpolator dependnecy property.
        /// </summary>
        public static readonly DependencyProperty ConnectorFillInterpolatorProperty =
            DependencyProperty.Register("ConnectorFillInterpolator", typeof(Interpolator), typeof(RelationshipGraph),
                new PropertyMetadata(null, new PropertyChangedCallback(OnConnectorFillInterpolatorPropertyChanged)));

        /// <summary>
        /// Invoked when the ConnectorFillInterpolator property changes
        /// </summary>
        private partial void OnConnectorFillInterpolatorPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnConnectorFillInterpolatorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnConnectorFillInterpolatorPropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public Style NodeSegmentStyle
        {
            get { return (Style)GetValue(NodeSegmentStyleProperty); }
            set { SetValue(NodeSegmentStyleProperty, value); }
        }

        /// <summary>
        /// Defines the NodeSegmentStyle dependnecy property.
        /// </summary>
        public static readonly DependencyProperty NodeSegmentStyleProperty =
            DependencyProperty.Register("NodeSegmentStyle", typeof(Style), typeof(RelationshipGraph),
                new PropertyMetadata(null, new PropertyChangedCallback(OnNodeSegmentStylePropertyChanged)));

        /// <summary>
        /// Invoked when the NodeSegmentStyle property changes
        /// </summary>
        private partial void OnNodeSegmentStylePropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnNodeSegmentStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnNodeSegmentStylePropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public Style NodeConnectorStyle
        {
            get { return (Style)GetValue(NodeConnectorStyleProperty); }
            set { SetValue(NodeConnectorStyleProperty, value); }
        }

        /// <summary>
        /// Defines the NodeConnectorStyle dependnecy property.
        /// </summary>
        public static readonly DependencyProperty NodeConnectorStyleProperty =
            DependencyProperty.Register("NodeConnectorStyle", typeof(Style), typeof(RelationshipGraph),
                new PropertyMetadata(null, new PropertyChangedCallback(OnNodeConnectorStylePropertyChanged)));

        /// <summary>
        /// Invoked when the NodeConnectorStyle property changes
        /// </summary>
        private partial void OnNodeConnectorStylePropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnNodeConnectorStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnNodeConnectorStylePropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public DoubleRange ConnectorThickness
        {
            get { return (DoubleRange)GetValue(ConnectorThicknessProperty); }
            set { SetValue(ConnectorThicknessProperty, value); }
        }

        /// <summary>
        /// Defines the ConnectorThickness dependnecy property.
        /// </summary>
        public static readonly DependencyProperty ConnectorThicknessProperty =
            DependencyProperty.Register("ConnectorThickness", typeof(DoubleRange), typeof(RelationshipGraph),
                new PropertyMetadata(null, new PropertyChangedCallback(OnConnectorThicknessPropertyChanged)));

        /// <summary>
        /// Invoked when the ConnectorThickness property changes
        /// </summary>
        private partial void OnConnectorThicknessPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnConnectorThicknessPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnConnectorThicknessPropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public double InnerRadius
        {
            get { return (double)GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        /// <summary>
        /// Defines the InnerRadius dependnecy property.
        /// </summary>
        public static readonly DependencyProperty InnerRadiusProperty =
            DependencyProperty.Register("InnerRadius", typeof(double), typeof(RelationshipGraph),
                new PropertyMetadata(0.7, new PropertyChangedCallback(OnInnerRadiusPropertyChanged)));

        /// <summary>
        /// Invoked when the InnerRadius property changes
        /// </summary>
        private partial void OnInnerRadiusPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnInnerRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnInnerRadiusPropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public double OuterRadius
        {
            get { return (double)GetValue(OuterRadiusProperty); }
            set { SetValue(OuterRadiusProperty, value); }
        }

        /// <summary>
        /// Defines the OuterRadius dependnecy property.
        /// </summary>
        public static readonly DependencyProperty OuterRadiusProperty =
            DependencyProperty.Register("OuterRadius", typeof(double), typeof(RelationshipGraph),
                new PropertyMetadata(0.8, new PropertyChangedCallback(OnOuterRadiusPropertyChanged)));

        /// <summary>
        /// Invoked when the OuterRadius property changes
        /// </summary>
        private partial void OnOuterRadiusPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnOuterRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnOuterRadiusPropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public double LabelRadius
        {
            get { return (double)GetValue(LabelRadiusProperty); }
            set { SetValue(LabelRadiusProperty, value); }
        }

        /// <summary>
        /// Defines the LabelRadius dependnecy property.
        /// </summary>
        public static readonly DependencyProperty LabelRadiusProperty =
            DependencyProperty.Register("LabelRadius", typeof(double), typeof(RelationshipGraph),
                new PropertyMetadata(0.9, new PropertyChangedCallback(OnLabelRadiusPropertyChanged)));

        /// <summary>
        /// Invoked when the LabelRadius property changes
        /// </summary>
        private partial void OnLabelRadiusPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnLabelRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnLabelRadiusPropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public INode HighlightedNode
        {
            get { return (INode)GetValue(HighlightedNodeProperty); }
            set { SetValue(HighlightedNodeProperty, value); }
        }

        /// <summary>
        /// Defines the HighlightedNode dependnecy property.
        /// </summary>
        public static readonly DependencyProperty HighlightedNodeProperty =
            DependencyProperty.Register("HighlightedNode", typeof(INode), typeof(RelationshipGraph),
                new PropertyMetadata(null, new PropertyChangedCallback(OnHighlightedNodePropertyChanged)));

        /// <summary>
        /// Invoked when the HighlightedNode property changes
        /// </summary>
        private partial void OnHighlightedNodePropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnHighlightedNodePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnHighlightedNodePropertyChanged(e);
        }

        /// <summary>
        /// Gets / sets the property value This is a dependency property
        /// </summary>
        public ISortOrderProvider SortOrderProvider
        {
            get { return (ISortOrderProvider)GetValue(SortOrderProviderProperty); }
            set { SetValue(SortOrderProviderProperty, value); }
        }

        /// <summary>
        /// Defines the SortOrderProvider dependnecy property.
        /// </summary>
        public static readonly DependencyProperty SortOrderProviderProperty =
            DependencyProperty.Register("SortOrderProvider", typeof(ISortOrderProvider), typeof(RelationshipGraph),
                new PropertyMetadata(new NaturalSortOrderProvider(), new PropertyChangedCallback(OnSortOrderProviderPropertyChanged)));

        /// <summary>
        /// Invoked when the SortOrderProvider property changes
        /// </summary>
        private partial void OnSortOrderProviderPropertyChanged(DependencyPropertyChangedEventArgs e);

        private static void OnSortOrderProviderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RelationshipGraph control = d as RelationshipGraph;
            control.OnSortOrderProviderPropertyChanged(e);
        }
    }
}