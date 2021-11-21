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

namespace on1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NhanVien> nv = new List<NhanVien>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tB_songay.Text) <= 0)
                {
                    MessageBox.Show(" Số ngày làm việc là số nguyên >0");
                }
                else
                {

                    if (2021 - datepk_ngaysinh.DisplayDate.Year <= 18)
                    {
                        MessageBox.Show("Tuổi của nhân viên tuyển dụng phải >=18");
                    }
                    else
                    {
                        string mess = "";
                        List<string> nn = new List<string>();
                        int soNgay = Convert.ToInt32(tB_songay.Text);
                        string strngoaingu = "";
                        mess = mess + tB_tennhanvien.Text.Trim() + "-" + cB_phongban.Text.Trim() + "-";

                        foreach (CheckBox item in ckb_language.Children)
                        {
                            if (item.IsChecked == true)
                            {
                                nn.Add(item.Content.ToString());
                            }
                        }

                        if (nn.Count != 0)
                        {
                            mess = mess + $"{ nn.Aggregate((a, b) => a + "," + b)}" + "-";
                            strngoaingu = nn.Aggregate((a, b) => a + "," + b);
                        }

                        DateTime dateofb = new DateTime();
                        dateofb = datepk_ngaysinh.SelectedDate.Value;
                        mess = mess + dateofb.ToString("dd/MM/yyyy");

                        int luong = (Convert.ToInt32(tB_songay.Text) <= 20) ? (Convert.ToInt32(tB_songay.Text) * 100000) : (2000000 + (Convert.ToInt32(tB_songay.Text) - 20) * 200000);

                        mess = mess + "-" + Convert.ToString(luong).ToString();
                        nv.Add(new NhanVien(tB_tennhanvien.Text, cB_phongban.Text, strngoaingu, dateofb, soNgay, luong));
                        list_ds.Items.Add(mess);
                    }
                    

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Bạn phải nhập tất cả các trường dữ liệu (trừ check box)");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 wd = new Window2();
            int length = nv.Count() - 1;
            wd.tB_tennhanvien.Text = nv[length].hoten;
            wd.cB_phongban.Text = nv[length].phongban;
            string[] language = nv[length].ngoaingu.Split(",");
            foreach (var item in language)
            {
                if (item == "Anh") wd.ckB_anh.IsChecked = true;
                if (item == "Pháp") wd.ckB_phap.IsChecked = true;
                if (item == "Trung") wd.ckB_trung.IsChecked = true;
            }
            wd.datepk_ngaysinh.SelectedDate = nv[length].ngaysinh;
            wd.tB_songay.Text = nv[length].songay.ToString();
            wd.tB_luong.Text = nv[length].luong.ToString();
            wd.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tB_tennhanvien.Text = "";
            tB_songay.Text = "";
            cB_phongban.SelectedIndex = -1;
            datepk_ngaysinh.Text = DateTime.Now.ToString();
            foreach (CheckBox item in ckb_language.Children)
            {
                item.IsChecked = false;
            }
            tB_tennhanvien.Focus();
        }
    }

    public class NhanVien
    {
        public string hoten { get; set; }
        public string phongban { get; set; }
        public string ngoaingu { get; set; }
        public DateTime ngaysinh { get; set; }
        public int songay { get; set; }
        public int luong { get; set; }
        public NhanVien()
        {

        }

        public NhanVien(string hoten,string phongban,string ngoaingu,DateTime ns,int songay,int luong)
        {
            this.hoten = hoten;
            this.phongban = phongban;
            this.ngoaingu = ngoaingu;
            this.ngaysinh = ns;
            this.songay = songay;
            this.luong = luong;
        }

    }
    
}

