using Dooz.socket.errors;
using Dooz.socket.models;
using Dooz.socket.requests;
using Dooz.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Dooz
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUpWindow : BaseWindow, INotifyPropertyChanged
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

        public SignUpWindow()
        {
            InitializeComponent();
            DataContext = this;
            SocketController.AddEvent(SocketMessage);
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
                    FileUtility.Log("Error in OpenHome Window: " + error.Message);
                }

                FileUtility.Log("fullname: " + user.Fullname);
                Console.WriteLine("fullname: " + user.Fullname);
            }else if (e is ErrorSignUp errorSignUp)
            {
                ShowSnackbar(errorSignUp.Message);
            }
        }
        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string Username = EdtUsername.Text;
            string Fullname = EdtFullname.Text;
            string Password = EdtPassword.Text;
            string Password2 = EdtPassword2.Text;
            SocketController.Send(new CreateAccountRequest {
                Username = Username,
                Fullname = Fullname,
                Password = Password,
                Password2 = Password2,
            });
        }

        public override void OnClosedCalled()
        {
            SocketController.RemoveEvent(SocketMessage);
        }
    }
}
