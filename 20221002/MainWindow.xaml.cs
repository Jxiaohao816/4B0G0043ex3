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

namespace _20221002
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> foods = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();
            AddNewFood(foods);
        }
        private void AddNewFood(Dictionary<string, int> myfood)
        {
            myfood.Add("大麥克漢堡(套餐)", 150);
            myfood.Add("大麥克漢堡(單點)", 90);
            myfood.Add("麥香雞漢堡(套餐)", 140);
            myfood.Add("麥香雞漢堡(單點)", 80);
            myfood.Add("雙層牛肉堡(套餐)", 160);
            myfood.Add("雙層牛肉堡(單點)", 100);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB1.Text = "";
            var targetTextBox = new[] { BM1, BM2, MG1, MG2, DB1, DB2 };
            bool success = true;
            var count = new[] { 1,1,1,1,1,1 };
            int money = 0;
            for (int i = 0; i <= 5; i++)
            {
                success = success && (int.TryParse(targetTextBox[i].Text, out count[i]) || targetTextBox[i].Text=="");
               
            }
            if (!success) MessageBox.Show("請輸入整數", "輸入錯誤");
            else if (count[0] < 0&& count[1] < 0&&count[2] < 0&&count[3] < 0 && count[4] < 0 && count[5] < 0 ) MessageBox.Show("請輸入正整數", "輸入錯誤");
            else
            {
                for (int i = 0; i <= 5; i++) {
                    StackPanel targetStackPanel = targetTextBox[i].Parent as StackPanel;
                    Label targetLabel = targetStackPanel.Children[0] as Label;
                    string foodItem = targetLabel.Content.ToString();
                    if (count[i] != 0) { 
                        TB1.Text = TB1.Text + $"{foodItem}X{count[i]}，每份{foods[foodItem]}元，總共{foods[foodItem] * count[i]}元\n";
                        TB1.Text = TB1.Text + "-------------\n";
                    }
                    money += count[i] * foods[foodItem];
                }
                TB1.Text = TB1.Text + $"售價：{money}元\n紅利：{money / 100}點\n";
                if (money > 1000)
                    money = money /100*85;
                else if (money > 500)
                    money = money /100* 90;
                TB1.Text = TB1.Text + $"打折後小計：{money}元\n";

            }
        }
    }
}

