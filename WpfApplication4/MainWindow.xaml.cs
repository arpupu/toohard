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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // 開始程式
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string[] lines = { };
            // 有檔案就進行讀取
            try
            {
                lines = System.IO.File.ReadAllLines(@"D:\accountingApp\data.txt");
            }
            // 如果沒檔案就進行新增
            catch
            {
                List<string> standard = new List<string>();
                System.IO.File.WriteAllLines(@"D:\accountingApp\data.txt", standard);
            }

            // 讀取每一行
            foreach (string line in lines)
            {
                // 用 | 來隔開每一行
                string[] parts = line.Split('|');

                // 建立 category
                category categorys = new category();

                // 讀取category的資料
                categorys.categoryDate.Text = parts[0];
                categorys.categoryName.Text = parts[1];
                categorys.categoryPrice.Text = parts[2];

                // 放到清單裡面
                categoryList.Children.Add(categorys);
            }
        }
        // 按下+鍵的時候
        private void addBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生項目
            category categorys = new category();

            //放到清單裡面
            categoryList.Children.Add(categorys);
        }

        // 關閉程式的時候
        private void windowClosed(object sender, EventArgs e)
        {
            List<string> Texts = new List<string>();

            foreach (category categorys in categoryList.Children)
            {

                string data = "";

                // 每一種資料以"|"分隔然後再加入Texts字串
                data += categorys.categoryDate.Text + "|" + categorys.categoryName.Text + "|" + categorys.categoryPrice.Text;

                // 存入Texts的陣列
                Texts.Add(data);
            }
            //儲存到D:\
            System.IO.File.WriteAllLines(@"D:\accountingApp\data.txt", Texts);
        }

        // 使用者切換欄位的時候 自動計算總和
        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            int totalprice = 0;


            foreach (category categorys in categoryList.Children)
            {
                totalprice += categorys.setPriceValue;
            }

            //顯示價格
            total.Text = totalprice.ToString();

        }
    }
}
