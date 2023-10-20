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

namespace OOOSportTovars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>-
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Начальные настройкм
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Classes.Helper.DB = new Model.SportTovarsEntities();
        }
        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// обработка логина и пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string log = Login.Text;
            string pas = PasswordTex.Text;
            string pasP = PasswordPas.Password;
            StringBuilder sb = new StringBuilder();
            // Проверка пустоты
            if (log == "")
            {
                sb.Append("Вы не ввели логин\n");
            }
            if (pas == "" && pasP == "")
            {
                sb.Append("Вы не ввели пароль\n");
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(Convert.ToString(sb)); return;
            }
            // Проверка правильности данных
            Classes.Helper.Users = Classes.Helper.DB.User.ToList();
            Model.User user;
            if (pasP == "")
            {
                user = Classes.Helper.Users.Where(u => u.Login == log && u.Password == pas).FirstOrDefault();
            }
            else
            {
                user = Classes.Helper.Users.Where(u => u.Login == log && u.Password == pasP).FirstOrDefault();
            }
            if (user != null)
            {
                string userFio = user.Familia + " " + user.Name + " " + user.Otchestvo;
                string userRol = user.Role.NaimenovanieRoli;
                MessageBox.Show(userFio + '\n' + userRol);
            }
            else { MessageBox.Show("Неверный логин или пароль"); }
        }

        private void VisiblePass_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTex.Visibility = Visibility.Visible;
            PasswordPas.Visibility = Visibility.Collapsed;
            PasswordPas.Password = "";
        }

        private void VisiblePass_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordPas.Visibility = Visibility.Visible;
            PasswordTex.Visibility = Visibility.Collapsed;
            PasswordTex.Text = "";
        }
    }
}
