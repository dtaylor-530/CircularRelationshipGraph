using CircularRelationshipGraph.Data;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CircularRelationshipGraph
{
    public partial class NodeSegment : Control, INotifyPropertyChanged
    {
        private partial void OnIsHighlightedPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            VisualStateManager.GoToState(this, IsHighlighted ? "Highlighted" : "Normal", false);
            Canvas.SetZIndex(this, IsHighlighted ? 100 : 99);

            if (IsHighlighted && ParentGraph != null)
            {
                ParentGraph.HighlightedNode = this.DataContext as INode;
            }
        }

        private partial void OnCenterPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private partial void OnInnerRadiusPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private partial void OnOuterRadiusPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private partial void OnStartAnglePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private partial void OnSweepAnglePropertyChanged(DependencyPropertyChangedEventArgs e)
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
            ConnectorPoint = Util.RadialToCartesian(MidPointAngle, InnerRadius, Center);

            // compute the path control points
            ViewModel.S1 = Util.RadialToCartesian(startAngle, OuterRadius, Center);
            ViewModel.S2 = Util.RadialToCartesian(endAngle, OuterRadius, Center);
            ViewModel.S3 = Util.RadialToCartesian(endAngle, InnerRadius, Center);
            ViewModel.S4 = Util.RadialToCartesian(startAngle, InnerRadius, Center);

            // create sizes from radius values
            ViewModel.InnerSize = new Size(InnerRadius, InnerRadius);
            ViewModel.OuterSize = new Size(OuterRadius, OuterRadius);

            ViewModel.LabelLocation = Util.RadialToCartesian(MidPointAngle, LabelRadius, Center);

            ViewModel.IsLargeArc = SweepAngle > 180;
        }

        public NodeSegment()
        {
            this.DefaultStyleKey = typeof(NodeSegment);
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