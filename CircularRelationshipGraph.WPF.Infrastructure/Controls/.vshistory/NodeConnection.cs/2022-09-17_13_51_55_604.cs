using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CircularRelationshipGraph
{
    public partial class NodeConnection : Control
    {
        private void OnIsHighlightedPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            VisualStateManager.GoToState(this, IsHighlighted ? "Highlighted" : "Normal", false);
            Canvas.SetZIndex(this, IsHighlighted ? 20 : 0);
        }

        private void OnFromPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private void OnToPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private void OnViaPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateViewModel();
        }

        private NodeConnectionViewModel _viewModel = new NodeConnectionViewModel();

        public NodeConnectionViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
        }

        /// <summary>
        /// Gets the angle between the point from and to on a circle with
        /// the given center. The returned value is in the range -360 to 360.
        /// </summary>
        private static double SubtendedAngle(Point from, Point to, Point center)
        {
            double fromAngle = Math.Atan2(from.Y - center.Y, from.X - center.X);
            double toAngle = Math.Atan2(to.Y - center.Y, to.X - center.X);
            double angle = toAngle - fromAngle;
            return 180 * angle / Math.PI;
        }

        private void UpdateViewModel()
        {
            double angle = SubtendedAngle(From, To, Via);
            if (angle < 0)
                angle += 360;

            double radius = Math.Sqrt((From.Y - Via.Y) * (From.Y - Via.Y) + (From.X - Via.X) * (From.X - Via.X));
            double shortestAngle = (angle > 180) ? 360 - angle : angle;
            double func = Math.Tan(shortestAngle * (Math.PI / 2) / 180) * radius;

            _viewModel.Size = new Size(func, func);
            _viewModel.SweepDirection = Math.Abs(angle) < 180 ? SweepDirection.Counterclockwise : SweepDirection.Clockwise;
        }

        public override void OnApplyTemplate()
        {
            Panel root = this.GetTemplateChild("rootElement") as Panel;
            root.DataContext = this;
        }

        public NodeConnection()
        {
            this.DefaultStyleKey = typeof(NodeConnection);
        }
    }
}