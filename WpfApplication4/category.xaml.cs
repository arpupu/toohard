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

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for category.xaml
    /// </summary>
    public partial class category : UserControl
    {
        public category()
        {
            InitializeComponent();
        }



        public int setPriceValue
        {
            // 避免輸入非數字的值
            get
            {

                try
                {
                    return int.Parse(categoryPrice.Text);
                }

                catch
                {
                    if (categoryPrice.Text != "")
                    {
                        MessageBox.Show("只能輸入數字");
                    }
                    return 0;
                }
            }
            set
            {
                categoryPrice.Text = value.ToString();
            }
        }

        // 使用者點選日期時
        private void categoryDate_GotFocus(object sender, RoutedEventArgs e)
        {
            // 清空預設日期
            categoryDate.Text = "";
        }

        // 使用者點選價格時
        private void categoryPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            // 清空預設價格
            categoryPrice.Text = "";
        }

        // 使用者點選項目名稱時
        private void categoryName_GotFocus(object sender, RoutedEventArgs e)
        {
            // 清空預設名稱
            categoryName.Text = "";
        }

        // 使用者沒有點選項目名稱時
        private void categoryName_LostFocus(object sender, RoutedEventArgs e)
        {
            // 如果使用者前一次沒有輸入資料
            if (categoryName.Text == "")
            {
                // 設定回預設內容
                categoryName.Text = "請輸入項目名稱";
            }

        }
        // 使用者沒有點選價格欄位時
        private void categoryPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            // 如果使用者前一次沒有輸入資料
            if (categoryPrice.Text == "")
            {
                // 設定回預設內容
                categoryPrice.Text = "0";
            }
        }
        // 使用者沒有點選日期欄位時
        private void categoryDate_LostFocus(object sender, RoutedEventArgs e)
        {
            // 如果使用者前一次沒有輸入資料
            if (categoryDate.Text == "")
            {
                // 設定為當前日期
                categoryDate.Text = DateTime.Now.ToString("M / dd");
            }
        }

        private void categoryDate_Loaded(object sender, RoutedEventArgs e)
        {
            // 預設日期為當日
            categoryDate.Text = DateTime.Now.ToString("M / dd");
        }
    }
}
