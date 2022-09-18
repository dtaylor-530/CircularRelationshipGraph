using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CircularRelationshipGraph
{
    public class ViewModel : INotifyPropertyChanged
    {
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