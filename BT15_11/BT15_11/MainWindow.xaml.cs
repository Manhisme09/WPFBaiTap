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

namespace BT15_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<NhanVien> nv = new List<NhanVien>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Convert.ToInt32(tb_songay.Text) <= 0)
                {
                    MessageBox.Show(" Số ngày làm việc là số nguyên >0");
                }
                else
                {
                    string mess = "";
                    string strngoaingu = "";
                    int soNgay = Convert.ToInt32(tb_songay.Text);
                    List<string> nn = new List<string>();
                    mess = tb_tennv.Text.Trim() + "-" + cb_phong.Text + "-";
                    foreach (CheckBox item in stck_ngoaingu.Children)
                    {
                        if (item.IsChecked == true)
                        {
                            nn.Add(item.Content.ToString());
                        }
                    }
                    //int i = 0;
                    //foreach (var item in nn)
                    //{
                    //    if (i == 0)
                    //    {
                    //        mess = mess + item.ToString();
                    //        i++;
                    //    }
                    //    else
                    //    {
                    //        mess = mess+ "," + item.ToString();
                    //    }
                    //}
                    if (nn.Count != 0)
                    {
                        mess = mess + $"{ nn.Aggregate((a, b) => a + "," + b)}" + "-";
                        strngoaingu =  nn.Aggregate((a, b) => a + "," + b);
                    }
                    int year = dateP_ngaysinh.DisplayDate.Year;
                    if (2021 - year < 18)
                    {
                        MessageBox.Show("Tuổi của nhân viên tuyển dụng phải >=18");
                    }
                    else
                    {
                        DateTime dateOfBirth = new DateTime();
                        dateOfBirth = dateP_ngaysinh.SelectedDate.Value;
                        mess = mess + dateOfBirth.ToString("dd/MM/yyyy");
                        



                        int luong = (Convert.ToInt32(tb_songay.Text) <= 20) ? (Convert.ToInt32(tb_songay.Text) * 100000) : (2000000 + (Convert.ToInt32(tb_songay.Text) - 20) * 200000);

                        mess = mess + "-" + Convert.ToString(luong).ToString();
                        nv.Add(new NhanVien(tb_tennv.Text, cb_phong.Text, strngoaingu, dateOfBirth , soNgay,luong));
                        list_tt.Items.Add(mess);
                        
                    }
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải nhập tất cả các trường dữ liệu");
            }

        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tb_tennv.Text = "";
            tb_songay.Text = "";
            cb_phong.SelectedIndex = -1;
            dateP_ngaysinh.Text = DateTime.Now.ToString();
            foreach (CheckBox item in stck_ngoaingu.Children)
            {
                item.IsChecked = false;
            }
            tb_tennv.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 myWindow = new Window3();
            int length = nv.Count() - 1;
            myWindow.tb_tennv2.Text = nv[length].hoten;
            myWindow.cb_phong2.Text = nv[length].phongban;

            string[] language = nv[length].ngoaingu.Split(",");
            foreach (var item in language)
            {
                if (item == "Anh") myWindow.ckb_anh.IsChecked = true;
                if (item == "Pháp") myWindow.ckb_phap.IsChecked = true;
                if (item == "Trung") myWindow.ckb_trung.IsChecked = true;
            }
            myWindow.dateP_ngaysinh2.SelectedDate = nv[length].ngaysinh;
            myWindow.tb_songay2.Text = nv[length].songay.ToString();
            myWindow.tb_tienluong.Text = nv[length].luong.ToString();

            myWindow.Show();
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


