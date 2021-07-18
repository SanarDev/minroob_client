using Dooz.socket.models;
using Dooz.socket.requests;
using Dooz.utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PrivateChatWindow.xaml
    /// </summary>
    public partial class PrivateChatWindow : BaseWindow
    {
        private SocketController SocketController = SocketController.GetInstance();
        private ObservableCollection<PrivateChatMessage> Messages = new ObservableCollection<PrivateChatMessage>();
        
        public long PlayerId { get; private set; }
        public string PlayerName { get; private set; }

        public PrivateChatWindow(long PlayerId, string PlayerName)
        {
            InitializeComponent();
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;

            SocketController.AddEvent(SocketMessage);
            SocketController.Send(new GetPrivateChatRequest
            {
                PlayerId = this.PlayerId
            });
            ToolbarTitle.Text = "Private Chat - "+PlayerName;
            MessageList.ItemsSource = Messages;
            StopAppAfterClose = false;
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Text.Equals(""))
            {
                return;
            }
            SocketController.Send(new AddMessageInPrivateChatRequest
            {
                PlayerId = this.PlayerId,
                Message = MessageBox.Text,
            });
            MessageBox.Text = "";
        }

        public void SocketMessage(object sender, Object e)
        {
            if (e is PrivateChat privateChat)
            {
                if (privateChat.ChatWith == this.PlayerId)
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
                            Messages.Insert(0,Message);
                        }
                    }
                    var MessagesSize = Messages.Count;

                    if (privateChat.MustClearHistory)
                    {
                        ScrollHelper.FindScrollViewer(MessageList).ScrollChanged += Messages_ScrollChanged;
                        ScrollHelper.ScrollToEnd(MessageList,Messages.Count);
                    }
                    else
                        ScrollHelper.ScrollToPosition(MessageList, privateChat.Messages.Count);

                }
            }else if (e is PrivateChatMessage privateChatMessage)
            {
                Console.WriteLine("PrivateChatMessage ");
                if (privateChatMessage.ReceiverPlayerId == this.PlayerId || privateChatMessage.SenderPlayerId == this.PlayerId)
                {
                    var MessagesSize = Messages.Count;
                    Messages.Add(privateChatMessage);
                    ScrollHelper.AutoScrollToEnd(MessageList, MessagesSize);
                }
            }
        }
        public override void OnClosedCalled()
        {
            ScrollHelper.FindScrollViewer(MessageList).ScrollChanged -= Messages_ScrollChanged;
            SocketController.RemoveEvent(SocketMessage);
        }

        private void Messages_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            double d = e.VerticalOffset;
            if (Convert.ToInt32(d) == 0)
            {
                SocketController.Send(new GetPrivateChatRequest
                {
                    PlayerId = this.PlayerId,
                    FromMessageId = Messages[0].Id
                });
            }
            // Here you can use the vertical-offset's value.
        }
    }
}
