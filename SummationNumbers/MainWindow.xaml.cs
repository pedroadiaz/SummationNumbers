using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SummationNumbers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int max = 1000;
            /**
             * I could iterate from 1 to 1000 and just pick out the values I need, however,
             * that would be 1000 iterations, whereas this is far fewer. Finally, since they
             * want the sum of three or five and I am doing both independently of each other,
             * I would be counting the ones that are divisible by both 3 and 5 twice. 
             **/
            int sumThrees = SumValues(3, max);
            int sumFives = SumValues(5, max);
            int sumFifteen = SumValues(15, max);

            /**
             * Fortunately though, there is a much easier way to calculate a sum of series.
             * According to Gauss, the sum of a series is given by n * (n+1)/2. 
             * Therefore, we can calculate the exact same thing as above without iterating.
             **/

            int gaussianThrees = CalculateGuassian(3, max);
            int gaussianFivess = CalculateGuassian(5, max-1); //I passed in 999 because we want values less than the max and 5 divides evenly
            int gaussianFifteens = CalculateGuassian(15, max);

            Result.Text = string.Format("The final value using the iterating method is: {0}\r\nThe final result for the Gaussian way is {1}", sumThrees + sumFives - sumFifteen, gaussianThrees + gaussianFivess - gaussianFifteens);
        }

        private int SumValues(int incrementor, int max)
        {
            List<int> list = new List<int>();

            for (int i = incrementor; i < max; i += incrementor)
            {
                list.Add(i);
            }

            return list.Sum();
        }

        private int CalculateGuassian(int incrementor, int max)
        {
            int limit = max / incrementor;
            int result = incrementor * (limit * (limit + 1) / 2);
            return result;
        }
    }
}
