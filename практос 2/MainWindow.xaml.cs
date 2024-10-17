using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_14;
using LibMas;

namespace prac2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,]? array;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// метод который выводит информацию о задании
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ввести n целых чисел. Найти сумму чисел < 8. Результат вывести на экран.", "Задание", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// метод для вывода информации о разработчике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Андрианов Алексей Вариант 14.", "Задание", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// метод закрытия программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        bool flagCellEditEnding = false;
        bool flagDoneCellEditEnding = false;
        /// <summary>
        /// метод для изменения массива вручную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            flagCellEditEnding = true;
            int indexRow = e.Row.GetIndex();
            int indexColumn = e.Column.DisplayIndex;
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out int newValue))
            {
                flagDoneCellEditEnding = true;
                array[indexRow, indexColumn] = newValue;

            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// метод для загрузки сохраненого массива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            array = ArrayEditor.Open();
            DataGrid.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
        }
        /// <summary>
        /// метод для сохранения массива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ArrayEditor.Save(array);
        }
        /// <summary>
        /// метод для генерации массива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbKol.Text, out int number) && number > 0)
            {
                array = ArrayEditor.Generate(1, number);
                DataGrid.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
            }
            else MessageBox.Show("Введите правильное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// метод для очистки программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = null;
            tbKol.Clear();
            tbRez.Clear();
        }
        /// <summary>
        /// метод для расчета суммы чисел меньше 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (array != null && flagCellEditEnding == flagDoneCellEditEnding && DataGrid.ItemsSource != null)
            {
                tbRez.Text = ClassSumUnder8.SumUnder8(array).ToString();
            }
            else MessageBox.Show("Введите правильное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

      
    }
}

