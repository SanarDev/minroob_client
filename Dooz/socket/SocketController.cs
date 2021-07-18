using Dooz.socket;
using Dooz.socket.errors;
using Dooz.socket.models;
using Dooz.socket.requests;
using Dooz.utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Dooz
{
    class SocketController
    {
        private bool IsSokcetConnected;
        private static SocketController mSocketController;
        private event EventHandler<Object> MessageReceivedEvents;
        public event EventHandler<LoggedUser> LoginSuccessEvents;
        public event EventHandler<LoggedUser> LoginErrorEvents;

        private TcpClient client;
        private NetworkStream stream;

        public static SocketController GetInstance()
        {
            if (mSocketController == null)
            {
                mSocketController = new SocketController();
            }
            return mSocketController;
        }

        public void AddEvent(EventHandler<Object> evt)
        {
            MessageReceivedEvents += evt;
        }

        public void RemoveEvent(EventHandler<Object> evt)
        {
            MessageReceivedEvents -= evt;
        }

        public void Disconnect()
        {
            if (client != null && stream != null)
            {
                stream.Close();
                client.Close();
            }
        }

        public void Start()
        {
            new Thread(Connect).Start();
        }

        private void ParseData(string data)
        {
            Console.WriteLine(data);
            try
            {
                var SocketMessage = JsonConvert.DeserializeObject<SocketMessage>(data);
                if (SocketMessage.Status == "ok")
                {
                    switch (SocketMessage.Type)
                    {
                        case SocketDataType.TYPE_USER:
                            {
                                var Me = JsonConvert.DeserializeObject<LoggedUser>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, Me);
                                break;
                            }
                        case SocketDataType.NEW_GLOBAL_MESSAGE:
                            {
                                var GlobalMessage = JsonConvert.DeserializeObject<GlobalMessage>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, GlobalMessage);
                                break;
                            }
                        case SocketDataType.PLAYER_STATUS:
                            {
                                var PlayerStatus = JsonConvert.DeserializeObject<PlayerStatus>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, PlayerStatus);
                                break;
                            }
                        case SocketDataType.ONLINE_PLAYERS:
                            {
                                var OnlinePlayers = JsonConvert.DeserializeObject<List<Player>>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, OnlinePlayers);
                                break;
                            }
                        case SocketDataType.INCOMING_GAME_REQUEST:
                            {
                                var InComingRequests = JsonConvert.DeserializeObject<List<InComingGameRequest>>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, InComingRequests);
                                break;
                            }
                        case SocketDataType.OUTGOING_GAME_REQUEST:
                            {
                                var OutGoingGameRequests = JsonConvert.DeserializeObject<List<OutGoingGameRequest>>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, OutGoingGameRequests);
                                break;
                            }
                        case SocketDataType.PRIVATE_CHAT_MESSAGES:
                            {
                                var PrivateChat = JsonConvert.DeserializeObject<PrivateChat>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, PrivateChat);
                                break;
                            }
                        case SocketDataType.NEW_PRIVATE_CHAT_MESSAGE:
                            {
                                var Message = JsonConvert.DeserializeObject<PrivateChatMessage>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, Message);
                                break;
                            }
                        case SocketDataType.WAITING_FOR_PLAYER_TO_START_GAME:
                            {
                                var WaitingForAcceptToStart = JsonConvert.DeserializeObject<WaitingForPlayerToStartGame>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this,WaitingForAcceptToStart);
                                Console.WriteLine("line 106");
                                break;
                            }
                        case SocketDataType.START_GAME:
                            {
                                var StartGame = JsonConvert.DeserializeObject<StartGame>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, StartGame);
                                break;
                            }
                        case SocketDataType.GAME_DATA:
                            {
                                var GameData = JsonConvert.DeserializeObject<GameData>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, GameData);
                                break;
                            }
                        case SocketDataType.GAME_MESSAGE:
                            {
                                var GameMessage = JsonConvert.DeserializeObject<GameMessage>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, GameMessage);
                                break;
                            }
                        case SocketDataType.GAME_END:
                            {
                                var GameEnd = JsonConvert.DeserializeObject<GameEnd>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, GameEnd);
                                break;
                            }
                        case SocketDataType.RESUMT_GAME:
                            {
                                var ResumeGame = JsonConvert.DeserializeObject<ResumeGame>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, ResumeGame);
                                break;
                            }
                        case SocketDataType.ME_DATA:
                            {
                                var Me = JsonConvert.DeserializeObject<Me>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, Me);
                                break;
                            }
                        case SocketDataType.GLOBAL_MESSAGES:
                            {
                                var GlobalMessages = JsonConvert.DeserializeObject<GlobalMessagesData>(SocketMessage.Data);
                                MessageReceivedEvents.Invoke(this, GlobalMessages);
                                break;
                            }
                    }
                }
                else
                {
                    switch (SocketMessage.Code)
                    {
                        case SocketErrorType.REQUIRE_AUTH:
                            {
                                var LoggedUser = FileUtility.GetLoginData();
                                if (LoggedUser != null)
                                {
                                    Send(new LoginWithTokenRequest(LoggedUser.Token));
                                }
                                break;
                            }
                        case SocketErrorType.FAIL_AUTH:
                            {
                                FileUtility.RemoveLoginData();
                                MessageReceivedEvents.Invoke(this, new FailAuth());
                                break;
                            }
                        case SocketErrorType.ERROR_SIGN_UP:
                            {
                                MessageReceivedEvents.Invoke(this, new ErrorSignUp { 
                                    Message = SocketMessage.Message
                                });
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                FileUtility.Log("Socket parse message Error : " + e.Message);
                Console.WriteLine(e.Message);
            }
        }

        public void Send(Object obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                json = json + "\r\n";
                //Console.WriteLine(json);
                var data = System.Text.Encoding.UTF8.GetBytes(json);
                stream.Write(data, 0, data.Length);
                stream.Flush();
                Console.WriteLine("Stream send: "+ json);
                FileUtility.Log("Stream send: " + json);
            }
            catch (Exception e)
            {
                FileUtility.Log("Error line 194: SendAsync: " + e.Message);
                Console.WriteLine("Error in send: "+e.Message);
                Disconnect();
                Start();
            }
        }
        

        public async Task SendAsync(Object obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                //Console.WriteLine(json);
                json = json + "\r\n";
                var data = System.Text.Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();
            }
            catch (Exception e)
            {
                FileUtility.Log("Error line 194: SendAsync: " + e.Message);
                Console.WriteLine("Error line 194: SendAsync: "+e.Message);
            }
        }


        private async void Connect()
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 8000;
                String message = "";
                client = new TcpClient("anroapp.com", port);

                //// Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[1024*10];

                // String to store the response ASCII representation.
                string responseData = String.Empty;

                
                while (client.Connected)
                {
                    try
                    {
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                        var SplitedData = responseData.Split(new String[] { "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            foreach (String item in SplitedData) { 
                                this.ParseData(item);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        FileUtility.Log("Socket exeption : " + e.Message);
                        Disconnect();
                    }
                    FileUtility.Log("Received: "+ responseData);
                    Console.WriteLine("Received: {0}", responseData);
                }

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            FileUtility.Log("Stream Closed");
            Console.WriteLine("Stream Closed");
        }
    }
}
