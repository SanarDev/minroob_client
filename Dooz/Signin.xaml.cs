using Dooz.socket.models;
using Dooz.socket.requests;
using Dooz.utils;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Dooz
{
    /// <summary>
    /// Interaction logic for Signin.xaml
    /// </summary>
    public partial class Signin : BaseWindow, INotifyPropertyChanged
    {
        private SocketController SocketController = SocketController.GetInstance();

        public event PropertyChangedEventHandler PropertyChanged;

        public void WindowPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool IsShowSnackBar
        {
            get => _isActive;
            set
            {
                _isActive = value;
                WindowPropertyChanged(nameof(IsShowSnackBar));
            }
        }
        private bool _isActive;

        public Signin()
        {
            InitializeComponent();
            DataContext = this;
            //this.Closed += (s, e) => SocketController.RemoveEvent(SocketMessage);
            SocketController.AddEvent(SocketMessage);
        }

        private void BtnSinginClick(object sender, RoutedEventArgs e)
        {
            if (EdtUsername.Text.Equals("") || EdtPassword.Text.Equals("")) {
                ShowSnackbar("Enter your username and password");
                return;
            }
            Console.WriteLine("LoginRequest getInstance");
            SocketController.Send(new LoginRequest(EdtUsername.Text, EdtPassword.Text));
        }


        private void ShowSnackbar(string Message)
        {
            SnackbarMessage.Content = Message;
            IsShowSnackBar = true;
            Task.Delay(3000).ContinueWith(t => Application.Current.Dispatcher.Invoke((Action)delegate
            {
                IsShowSnackBar = false;
            }));
        }

        public void SocketMessage(object sender, Object e)
        {
            FileUtility.Log("Signin: SocketMessage: TypeObject: "+ e.GetType());
            Console.WriteLine("Signin: SocketMessage");
            if (e is LoggedUser user)
            {
                try
                {
                    StopAppAfterClose = false;
                    FileUtility.SaveLoginData(user);
                    HomeWindow Window = new HomeWindow();
                    Window.Show();
                    this.Close();
                }
                catch (Exception error)
                {
                    FileUtility.Log("Error in OpenHome Window: "+error.Message);
                }

                FileUtility.Log("fullname: " + user.Fullname);
                Console.WriteLine("fullname: "+user.Fullname);
            } else if (e is FailAuth failAuth)
            {
                ShowSnackbar("User Not Found");
                Console.WriteLine("Fail auth");
            }
        }

        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            StopAppAfterClose = false;
            var Window = new SignUpWindow();
            Window.Show();
            this.Close();
        }

        public override void OnClosedCalled()
        {
            SocketController.RemoveEvent(SocketMessage);
        }
    }
}
