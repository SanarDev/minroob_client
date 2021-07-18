using Dooz.socket.models;
using Dooz.socket.requests;
using Dooz.utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeWindow : BaseWindow, INotifyPropertyChanged
    {
        private SocketController SocketController = SocketController.GetInstance();
        private ObservableCollection<GlobalMessage> GlobalMessages = new ObservableCollection<GlobalMessage>();
        private ObservableCollection<Player> OnlinePlayers = new ObservableCollection<Player>();
        private ObservableCollection<InComingGameRequest> InComingGameRequests = new ObservableCollection<InComingGameRequest>();
        private ObservableCollection<OutGoingGameRequest> OutGoingGameRequests = new ObservableCollection<OutGoingGameRequest>();

        public bool IsShowWaitingDialog
        {
            get => _isShowWaitingDialog;
            set
            {
                _isShowWaitingDialog = value;
                WindowPropertyChanged(nameof(IsShowWaitingDialog));
            }
        }
        private bool _isShowWaitingDialog;

        public bool IsShowResumeGameDialog
        {
            get => _isShowResumeGameDialog;
            set
            {
                _isShowResumeGameDialog = value;
                WindowPropertyChanged(nameof(IsShowResumeGameDialog));
            }
        }
        private bool _isShowResumeGameDialog;


        public bool IsActiveSnackBar {
            get => _isActive;
            set
            {
                _isActive = value;
                WindowPropertyChanged(nameof(IsActiveSnackBar));
            }
        }
        private bool _isActive;

        public string SnackbarMessage
        {
            get => _snackbarMessage;
            set
            {
                _snackbarMessage = value;
                WindowPropertyChanged(nameof(SnackbarMessage));
            }
        }
        private string _snackbarMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public void WindowPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));

        public HomeWindow() : base()
        {
            InitializeComponent();
            DataContext = this;
            SocketController.AddEvent(SocketMessage);

            GlobalChatList.ItemsSource = GlobalMessages;
            OnlinePlayerList.ItemsSource = OnlinePlayers;
            OutGoingGameRequestsList.ItemsSource = OutGoingGameRequests;
            InComingGameRequestsList.ItemsSource = InComingGameRequests;

            SocketController.Send(new GetOnlinePlayersRequest());
            SocketController.Send(new GetGameRequests());
            SocketController.Send(new GetRunningGameRequest());
            SocketController.Send(new GetMeRequest());
            SocketController.Send(new GetGlobalMessages());
        }


        private Player FindPlayerById(long PlayerId)
        {
            foreach (Player OnlinePlayer in OnlinePlayers)
            {
                if (OnlinePlayer.Id == PlayerId)
                {
                    return OnlinePlayer;
                }
            }
            return null;
        }

        public void SocketMessage(object sender, Object e)
        {
            Console.WriteLine("MainWinodw: SocketMEssage");
            if (e is Me me)
            {
                TxtFullname.Text = me.Fullname;
                TxtUsername.Text = me.Username;
                TxtNumberOfGamePlayed.Text = me.TotalGames.ToString();
                TxtWinsCount.Text = me.Wins.ToString();
            }
            else if (e is ResumeGame resumeGame)
            {

                IsShowResumeGameDialog = true;
                TxtResumeGameDialog.Text = "You have a game with " + resumeGame.PlayerName + ". Do you want to resume it?";
                BtnAcceptResumeGame.Tag = resumeGame.GameId;
                BtnCancelResumeGame.Tag = resumeGame.GameId;

            }
            else if (e is GlobalMessage globalMessage)
            {
                var MessagesSize = GlobalMessages.Count;
                GlobalMessages.Add(globalMessage);
                ScrollHelper.AutoScrollToEnd(GlobalChatList, MessagesSize);
            }
            else if (e is PlayerStatus playerStatus)
            {

                if (playerStatus.IsOnline)
                {
                    Console.WriteLine("Online Player : " + playerStatus.Player.Fullname);
                    OnlinePlayers.Remove(FindPlayerById(playerStatus.Player.Id));
                    OnlinePlayers.Add(playerStatus.Player);
                }
                else
                {
                    OnlinePlayers.Remove(FindPlayerById(playerStatus.Player.Id));
                }

            }
            else if (e is List<Player> players)
            {

                foreach (Player Player in players)
                {
                    OnlinePlayers.Add(Player);
                }
            }
            else if (e is List<InComingGameRequest> requests)
            {
                InComingGameRequests.Clear();
                foreach (InComingGameRequest InComingGameRequest in requests)
                {
                        InComingGameRequests.Add(InComingGameRequest);
                }
            }
            else if (e is List<OutGoingGameRequest> outGoingRequests)
            {
                OutGoingGameRequests.Clear();
                foreach (OutGoingGameRequest OutGoingGameRequest in outGoingRequests)
                {
                        OutGoingGameRequests.Add(OutGoingGameRequest);
                }
            }
            else if (e is WaitingForPlayerToStartGame waitingForAcceptToStart)
            {
                BtnCancelWaitingDialog.Tag = waitingForAcceptToStart.GameId;
                TxtWaitingDialog.Text = "Waiting for " + waitingForAcceptToStart.PalyerName + " to be online";
                IsShowWaitingDialog = true;
            }
            else if (e is StartGame startGame)
            {
                StopAppAfterClose = false;
                GameWindow gameWindow = new GameWindow(startGame.GameId);
                gameWindow.Show();
                this.Close();
            }
            else if (e is GlobalMessagesData globalMessagesData)
            {
                var MessagesSize = globalMessagesData.Messages.Count;
                if (globalMessagesData.MustClearHistory)
                {
                    GlobalMessages.Clear();
                    foreach (var GlobalMessage in globalMessagesData.Messages)
                    {
                        GlobalMessages.Add(GlobalMessage);
                    }
                }
                else
                {
                    globalMessagesData.Messages.Reverse();
                    foreach (var GlobalMessage in globalMessagesData.Messages)
                    {
                        GlobalMessages.Insert(0,GlobalMessage);
                    }
                    ScrollHelper.ScrollToPosition(GlobalChatList, MessagesSize);
                }
                if (globalMessagesData.MustClearHistory)
                {
                    ScrollHelper.ScrollToEnd(GlobalChatList, MessagesSize);
                    try
                    {
                        ScrollHelper.FindScrollViewer(GlobalChatList).ScrollChanged += GlobalChat_ScrollChanged;
                    }catch(Exception error)
                    {

                    }
                }
            }
        }

        private void ShowSnackbar(string Message)
        {
            SnackbarMessage = Message;
            IsActiveSnackBar = true;
            Task.Delay(5000).ContinueWith(t => Application.Current.Dispatcher.Invoke((Action)delegate
            {
                IsActiveSnackBar = false;
            }));
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Text.Equals(""))
            {
                return;
            }
            SocketController.Send(new GlobalMessageRequest { 
                Message = MessageBox.Text
            });
            MessageBox.Text = "";
        }

        private void BtnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            var BtnSendMessage = (Button) sender;
            var PlayerId = (long)BtnSendMessage.Tag;
            string PlayerName = FindPlayerById(PlayerId).Fullname;
            var PrivateChatWindow = new PrivateChatWindow(PlayerId, PlayerName);
            PrivateChatWindow.Show();
            Console.WriteLine("Open Chat Window Player : " + PlayerId);
        }
        private void BtnSendGameRequest_Click(object sender, RoutedEventArgs e)
        {
            var BtnSendMessage = (Button) sender;
            var PlayerId = (long)BtnSendMessage.Tag;
            SocketController.Send(new GameRequest
            {
                PlayerId = PlayerId
            });
            ShowSnackbar("Game Request Sent Successfully To " + FindPlayerById(PlayerId).Fullname);
        }

        private void BtnAcceptGame_Click(object sender, RoutedEventArgs e)
        {
            var BtnCancelRequest = (Button)sender;
            var GameId = (int)BtnCancelRequest.Tag;
            SocketController.Send(new AcceptGameRequest
            {
                GameId = GameId
            });
        }

        private void BtnCancelRequest_Click(object sender, RoutedEventArgs e)
        {
            var BtnCancelRequest = (Button)sender;
            var GameId = (int)BtnCancelRequest.Tag;
            SocketController.Send(new CancelGameRequest { 
                GameId = GameId
            });
        }

        private void CancelWaitingDialog_Click(object sender, RoutedEventArgs e)
        {
            IsShowWaitingDialog = false;
            SocketController.Send(new CancelWaitingForPlayerRequest { 
                GameId = (long)((Button)sender).Tag
            });
        }

        private void AcceptResumeGame_Click(object sender, RoutedEventArgs e)
        {
            StopAppAfterClose = false;
            var GameId = (long)((Button)sender).Tag;
            GameWindow gameWindow = new GameWindow(GameId);
            gameWindow.Show();
            this.Close();
        }
        private void CancelResumeGame_Click(object sender, RoutedEventArgs e)
        {
            var GameId = (long)((Button)sender).Tag;
            SocketController.Send(new AnnouncementOfLossGameRequest
            {
                GameId = GameId
            });
            IsShowResumeGameDialog = false;
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            StopAppAfterClose = false;
            FileUtility.RemoveLoginData();
            SocketController.Disconnect();
            var Window = new Signin();
            Window.Show();
            this.Close();
        }

        public override void OnClosedCalled()
        {
            ScrollHelper.FindScrollViewer(GlobalChatList).ScrollChanged -= GlobalChat_ScrollChanged;
            SocketController.RemoveEvent(SocketMessage);
        }

        private void GlobalChat_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            double d = e.VerticalOffset;
            if (Convert.ToInt32(d) == 0)
            {
                SocketController.Send(new GetGlobalMessages {
                    FromMessageId = GlobalMessages[0].Id
                });
            }
            // Here you can use the vertical-offset's value.
        }
    }
}
