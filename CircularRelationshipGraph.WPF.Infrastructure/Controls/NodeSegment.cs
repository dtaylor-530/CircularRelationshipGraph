using CircularRelationshipGraph.Data;
using CircularRelationshipGraph.WPF.Infrastructure.Common;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CircularRelationshipGraph
{
    public partial class NodeSegment : Control, INotifyPropertyChanged
    {
        static NodeSegment()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NodeSegment), new FrameworkPropertyMetadata(typeof(NodeSegment)));
        }

        private void OnIsHighlightedPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            VisualStateManager.GoToState(this, IsHighlighted ? "Highlighted" : "Normal", false);
            Canvas.SetZIndex(this, IsHighlighted ? 100 : 99);

            if (IsHighlighted && ParentGraph != null)
            {
                ParentGraph.HighlightedNode = this.DataContext as INode;
            }
        }

        private void OnCenterPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private void OnInnerRadiusPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private void OnOuterRadiusPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private void OnStartAnglePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private void OnSweepAnglePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private NodeSegmentViewModel _viewmodel = new NodeSegmentViewModel();

        public RelationshipGraph ParentGraph { get; set; }

        public NodeSegmentViewModel ViewModel
        {
            get
            {
                return _viewmodel;
            }
        }

        private void UpdateViewModel()
        {
            double startAngle = StartAngle;
            double endAngle = StartAngle + SweepAngle;

            // compute the properties that the segment exposes to support other UI elements
            MidPointAngle = startAngle + (SweepAngle / 2);
            ConnectorPoint = WPFUtil.RadialToCartesian(MidPointAngle, InnerRadius, Center);

            // compute the path control points
            ViewModel.S1 = WPFUtil.RadialToCartesian(startAngle, OuterRadius, Center);
            ViewModel.S2 = WPFUtil.RadialToCartesian(endAngle, OuterRadius, Center);
            ViewModel.S3 = WPFUtil.RadialToCartesian(endAngle, InnerRadius, Center);
            ViewModel.S4 = WPFUtil.RadialToCartesian(startAngle, InnerRadius, Center);

            // create sizes from radius values
            ViewModel.InnerSize = new Size(InnerRadius, InnerRadius);
            ViewModel.OuterSize = new Size(OuterRadius, OuterRadius);

            ViewModel.LabelLocation = WPFUtil.RadialToCartesian(MidPointAngle, LabelRadius, Center);

            ViewModel.IsLargeArc = SweepAngle > 180;
        }

        public override void OnApplyTemplate()
        {
            Panel root = this.GetTemplateChild("rootElement") as Panel;
            UIElement shape = this.GetTemplateChild("segmentShape") as UIElement;

            shape.MouseEnter += (s, e) => IsHighlighted = true;
            shape.MouseLeave += (s, e) => IsHighlighted = false;
        }
    }
}