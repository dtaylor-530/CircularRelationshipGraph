using System.Windows;

namespace CircularRelationshipGraph.WPF.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new MainPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            content.Content = new StackOverflow();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            content.Content = new WorldDebt();
        }
    }
}