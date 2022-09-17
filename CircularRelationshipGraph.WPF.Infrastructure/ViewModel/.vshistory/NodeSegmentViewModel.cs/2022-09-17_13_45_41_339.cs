using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CircularRelationshipGraph
{
    public partial class NodeSegmentViewModel : INotifyPropertyChanged
    {
        private static readonly Point EMPTY_POINT = new Point();

        private static readonly Size EMPTY_SIZE = new Size();

        /// <summary>
        /// Field which backs the S1 property
        /// </summary>
        private Point _s1 = EMPTY_POINT;

        /// <summary>
        /// Gets / sets the S1 value
        /// </summary>
        public Point S1
        {
            get { return _s1; }
            set
            {
                if (_s1 == value)
                    return;

                _s1 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Field which backs the S2 property
        /// </summary>
        private Point _s2 = EMPTY_POINT;

        /// <summary>
        /// Gets / sets the S2 value
        /// </summary>
        public Point S2
        {
            get { return _s2; }
            set
            {
                if (_s2 == value)
                    return;

                _s2 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Field which backs the S3 property
        /// </summary>
        private Point _s3 = EMPTY_POINT;

        public static readonly string S3Property = "S3";

        /// <summary>
        /// Gets / sets the S3 value
        /// </summary>
        public Point S3
        {
            get { return _s3; }
            set
            {
                if (_s3 == value)
                    return;

                _s3 = value;
                OnPropertyChanged(S3Property);
            }
        }

        /// <summary>
        /// Field which backs the S4 property
        /// </summary>
        private Point _s4 = EMPTY_POINT;

        /// <summary>
        /// Gets / sets the S4 value
        /// </summary>
        public Point S4
        {
            get { return _s4; }
            set
            {
                if (_s4 == value)
                    return;

                _s4 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Field which backs the LabelLocation property
        /// </summary>
        private Point _labelLocation = EMPTY_POINT;

        public static readonly string LabelLocationProperty = "LabelLocation";

        /// <summary>
        /// Gets / sets the LabelLocation value
        /// </summary>
        public Point LabelLocation
        {
            get { return _labelLocation; }
            set
            {
                if (_labelLocation == value)
                    return;

                _labelLocation = value;
                OnPropertyChanged(LabelLocationProperty);
            }
        }

        /// <summary>
        /// Field which backs the InnerSize property
        /// </summary>
        private Size _innerSize = EMPTY_SIZE;

        public static readonly string InnerSizeProperty = "InnerSize";

        /// <summary>
        /// Gets / sets the InnerSize value
        /// </summary>
        public Size InnerSize
        {
            get { return _innerSize; }
            set
            {
                if (_innerSize == value)
                    return;

                _innerSize = value;
                OnPropertyChanged(InnerSizeProperty);
            }
        }

        /// <summary>
        /// Field which backs the OuterSize property
        /// </summary>
        private Size _outerSize = EMPTY_SIZE;

        /// <summary>
        /// Gets / sets the OuterSize value
        /// </summary>
        public Size OuterSize
        {
            get { return _outerSize; }
            set
            {
                if (_outerSize == value)
                    return;

                _outerSize = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Field which backs the IsLargeArc property
        /// </summary>
        private bool _isLargeArc = false;

        /// <summary>
        /// Gets / sets the IsLargeArc value
        /// </summary>
        public bool IsLargeArc
        {
            get { return _isLargeArc; }
            set
            {
                if (_isLargeArc == value)
                    return;

                _isLargeArc = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises a PropertyChanged event
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string? property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion INotifyPropertyChanged Members
    }
}