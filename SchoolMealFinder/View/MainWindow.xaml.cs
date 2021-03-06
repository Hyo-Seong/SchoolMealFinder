﻿using MySql.Data.MySqlClient;
using SchoolMealFinder.DBConn;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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

namespace SchoolMealFinder.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string userName = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        public static string Sha512Hash(string str)
        {
            var sha512 = new SHA512CryptoServiceProvider();
            byte[] resultHash = sha512.ComputeHash(Encoding.Default.GetBytes(str));
            string transPwd = string.Empty;

            foreach (byte x in resultHash)
            {
                transPwd += $"{x:x2}";
            }

            return transPwd;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(idTb.Text == "" || pwPb.Password == "")
            {
                MessageBox.Show("아이디 또는 비밀번호를 입력하세요.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var MyRead = MysqlConn.ExecuteQuery("select name from user where id='" + idTb.Text + "' and pw='" + Sha512Hash(pwPb.Password.ToString()) + "'");

            if (MyRead.Read())
            {
                userName = MyRead["name"].ToString();
                MessageBox.Show(userName + "님 환영합니다!", "알림", MessageBoxButton.OK);
                MyRead.Close();

                ShowMealCtrl.Visibility = Visibility.Visible;
                //로그인 성공 이후 로직 구현.
                InitData();
            }
            else
            {
                MessageBox.Show("로그인에 실패하였습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
                MyRead.Close();
                return;
            }


        }

        private void InitData()
        {
            // 유저정보 받아오고, 밥정보 받아오고
            ShowMealCtrl.SetTodayMeal();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterCtrl.Visibility = Visibility.Visible;
        }
    }
}