using Dooz.socket.models;
using Dooz.socket.requests;
using Dooz.utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dooz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : BaseWindow, INotifyPropertyChanged
    {
        private SocketController SocketController = SocketController.GetInstance();
        private ObservableCollection<PrivateChatMessage> Messages = new ObservableCollection<PrivateChatMessage>();
        private long GameId;
        private long ChatPlayerId = -1;

        public bool IsActiveSnackBar
        {
            get => _isActive;
            set
            {
                _isActive = value;
                WindowPropertyChanged(nameof(IsActiveSnackBar));
            }
        }
        private bool _isActive;
        
        public bool IsShowDialog
        {
            get => _isShowDialog;
            set
            {
                _isShowDialog = value;
                WindowPropertyChanged(nameof(IsShowDialog));
            }
        }
        private bool _isShowDialog;


        public event PropertyChangedEventHandler PropertyChanged;

        public void WindowPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public GameWindow(long GameId)
        {
            InitializeComponent();
            DataContext = this;
            this.GameId = GameId;
            MessageList.ItemsSource = Messages;
            SocketController.AddEvent(SocketMessage);
            GetGameData();
            ShowProgessReceiveData();
        }

        private void GetGameData()
        {
            SocketController.Send(new GetGameDataRequest
            {
                GameId = GameId
            });
        }
        private async void ShowProgessReceiveData()
        {
            IsShowDialog = true;
            TxtDialogTitle.Text = "Receive Game Data";
            TxtDialogMessage.Text = "Please wait...";
            DialogButton.Visibility = Visibility.Collapsed;
            await Task.Delay(3000);
            if (ChatPlayerId != -1)
            {
                IsShowDialog = false;
            }
            else
            {
                GetGameData();
                ShowProgessReceiveData();
            }
        }

        public void Btn_Game_KeyBoard_Click(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;
            var Data = ((String)Button.Tag).Split('_');
            var Row = Convert.ToInt32(Data[0]);
            var Col = Convert.ToInt32(Data[1]);
            SocketController.Send(new MinRoobKeyboardClickRequest
            {
                GameId = this.GameId,
                Col = Col,
                Row = Row,
            });
        }

        private void ShowSnackbar(string Message)
        {
            Snackbar.IsActive = true;
            SnackbarMessage.Content = Message;
            Task.Delay(3000).ContinueWith(t => Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Snackbar.IsActive = false;
            }));
        }

        private void InitializeNeedDataForChat(GameData gameData)
        {
            var LoggedUser = FileUtility.GetLoginData();
            if(LoggedUser.Id == gameData.Player1.Id)
            {
                this.ChatPlayerId = gameData.Player2.Id; 
            }else
                this.ChatPlayerId = gameData.Player1.Id;

            SocketController.Send(new GetPrivateChatRequest { 
                PlayerId = this.ChatPlayerId
            });
        }

        public void SocketMessage(object sender, Object e)
        {
            if (e is GameMessage gameMessage)
            {

                
                    ShowSnackbar(gameMessage.Message);
                
                Console.WriteLine("ShowSnackbarMessage: "+ gameMessage.Message);
            }
            else if (e is GameData gameData)
            {
                if (Messages.Count == 0)
                    InitializeNeedDataForChat(gameData);
               
                    var PlayerOne = gameData.Player1;
                    var PlayerTwo= gameData.Player2;

                    TxtGameTitle.Text = PlayerOne.Name + " VS "+ PlayerTwo.Name;
                    TxtTurn.Text = "Turn: "+gameData.Turn;
                    TxtPlayerOneScore.Text = PlayerOne.Name + ": " + PlayerOne.Score;
                    TxtPlayerTwoScore.Text = PlayerTwo.Name + ": " + PlayerTwo.Score;

                    button_0_0.Content = gameData.Map[0][0];
                    button_0_1.Content = gameData.Map[0][1];
                    button_0_2.Content = gameData.Map[0][2];
                    button_0_3.Content = gameData.Map[0][3];
                    button_0_4.Content = gameData.Map[0][4];
                    button_0_5.Content = gameData.Map[0][5];
                    button_0_6.Content = gameData.Map[0][6];
                    button_0_7.Content = gameData.Map[0][7];

                    button_1_0.Content = gameData.Map[1][0];
                    button_1_1.Content = gameData.Map[1][1];
                    button_1_2.Content = gameData.Map[1][2];
                    button_1_3.Content = gameData.Map[1][3];
                    button_1_4.Content = gameData.Map[1][4];
                    button_1_5.Content = gameData.Map[1][5];
                    button_1_6.Content = gameData.Map[1][6];
                    button_1_7.Content = gameData.Map[1][7];

                    button_2_0.Content = gameData.Map[2][0];
                    button_2_1.Content = gameData.Map[2][1];
                    button_2_2.Content = gameData.Map[2][2];
                    button_2_3.Content = gameData.Map[2][3];
                    button_2_4.Content = gameData.Map[2][4];
                    button_2_5.Content = gameData.Map[2][5];
                    button_2_6.Content = gameData.Map[2][6];
                    button_2_7.Content = gameData.Map[2][7];

                    button_3_0.Content = gameData.Map[3][0];
                    button_3_1.Content = gameData.Map[3][1];
                    button_3_2.Content = gameData.Map[3][2];
                    button_3_3.Content = gameData.Map[3][3];
                    button_3_4.Content = gameData.Map[3][4];
                    button_3_5.Content = gameData.Map[3][5];
                    button_3_6.Content = gameData.Map[3][6];
                    button_3_7.Content = gameData.Map[3][7];

                    button_4_0.Content = gameData.Map[4][0];
                    button_4_1.Content = gameData.Map[4][1];
                    button_4_2.Content = gameData.Map[4][2];
                    button_4_3.Content = gameData.Map[4][3];
                    button_4_4.Content = gameData.Map[4][4];
                    button_4_5.Content = gameData.Map[4][5];
                    button_4_6.Content = gameData.Map[4][6];
                    button_4_7.Content = gameData.Map[4][7];

                    button_5_0.Content = gameData.Map[5][0];
                    button_5_1.Content = gameData.Map[5][1];
                    button_5_2.Content = gameData.Map[5][2];
                    button_5_3.Content = gameData.Map[5][3];
                    button_5_4.Content = gameData.Map[5][4];
                    button_5_5.Content = gameData.Map[5][5];
                    button_5_6.Content = gameData.Map[5][6];
                    button_5_7.Content = gameData.Map[5][7];

                    button_6_0.Content = gameData.Map[6][0];
                    button_6_1.Content = gameData.Map[6][1];
                    button_6_2.Content = gameData.Map[6][2];
                    button_6_3.Content = gameData.Map[6][3];
                    button_6_4.Content = gameData.Map[6][4];
                    button_6_5.Content = gameData.Map[6][5];
                    button_6_6.Content = gameData.Map[6][6];
                    button_6_7.Content = gameData.Map[6][7];

                    button_7_0.Content = gameData.Map[7][0];
                    button_7_1.Content = gameData.Map[7][1];
                    button_7_2.Content = gameData.Map[7][2];
                    button_7_3.Content = gameData.Map[7][3];
                    button_7_4.Content = gameData.Map[7][4];
                    button_7_5.Content = gameData.Map[7][5];
                    button_7_6.Content = gameData.Map[7][6];
                    button_7_7.Content = gameData.Map[7][7];
            }
            else if (e is PrivateChat privateChat)
            {
                Console.WriteLine("PrivateChat ");
                if (privateChat.ChatWith == this.ChatPlayerId)
                {
                    if (privateChat.MustClearHistory)
                    {
                        Messages.Clear();
                        foreach (PrivateChatMessage Message in privateChat.Messages)
                        {
                            Messages.Add(Message);
                        }
                    }
                    else
                    {
                        privateChat.Messages.Reverse();
                        foreach (PrivateChatMessage Message in privateChat.Messages)
                        {
                            Messages.Insert(0, Message);
                        }
                    }
                    var MessagesSize = Messages.Count;

                    if (privateChat.MustClearHistory)
                    {
                        ScrollHelper.FindScrollViewer(MessageList).ScrollChanged += Messages_ScrollChanged;
                        ScrollHelper.ScrollToEnd(MessageList, Messages.Count);
                    }
                    else
                        ScrollHelper.ScrollToPosition(MessageList, privateChat.Messages.Count);

                }
            }
            else if (e is PrivateChatMessage privateChatMessage)
            {
                Console.WriteLine("PrivateChatMessage ");
                if (privateChatMessage.ReceiverPlayerId == this.ChatPlayerId || privateChatMessage.SenderPlayerId == this.ChatPlayerId)
                {
                    
                        var MessagesSize = Messages.Count;
                        Messages.Add(privateChatMessage);
                        ScrollHelper.AutoScrollToEnd(MessageList, MessagesSize);

                }
            }
            else if (e is GameEnd gameEnd)
            {
                Console.WriteLine("GameEnd");
                
                IsShowDialog = true;
                DialogButton.Visibility = Visibility.Visible;
                if (gameEnd.IsWinner)
                    {
                        TxtDialogTitle.Foreground = new SolidColorBrush(Colors.Green);
                        TxtDialogTitle.Text = "You Win!";
                        TxtDialogMessage.Text = gameEnd.Message;
                    }
                    else
                    {
                        TxtDialogTitle.Foreground = new SolidColorBrush(Colors.Red);
                        TxtDialogTitle.Text = "You Lose!";
                        TxtDialogMessage.Text = gameEnd.Message;
                    }

            }
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (ChatPlayerId == -1)
            {
                ShowSnackbar("Please wait for start chat");
                return;
            }
            if (EdtMessage.Text.Equals(""))
            {
                return;
            }
            SocketController.Send(new AddMessageInPrivateChatRequest { 
                PlayerId = this.ChatPlayerId,
                Message = EdtMessage.Text
            });
            EdtMessage.Text = "";
        }

        private void DialogButton_Click(object sender, RoutedEventArgs e)
        {
            StopAppAfterClose = false;
            HomeWindow MainWindow = new HomeWindow();
            MainWindow.Show();
            this.Close();
        }

        public override void OnClosedCalled()
        {
            SocketController.RemoveEvent(SocketMessage);
        }

        private void Messages_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            double d = e.VerticalOffset;
            if (Convert.ToInt32(d) == 0)
            {
                SocketController.Send(new GetPrivateChatRequest
                {
                    PlayerId = this.ChatPlayerId,
                    FromMessageId = Messages[0].Id
                });
            }
            // Here you can use the vertical-offset's value.
        }
    }
}
