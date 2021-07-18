using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket
{
    class SocketDataType
    {
        public const string TYPE_USER = "user";
        public const string GLOBAL_MESSAGES = "global_messages";
        public const string NEW_GLOBAL_MESSAGE = "new_global_message";
        public const string PLAYER_STATUS = "player_status";
        public const string ONLINE_PLAYERS = "online_players";
        public const string INCOMING_GAME_REQUEST = "incoming_game_request";
        public const string OUTGOING_GAME_REQUEST = "outgoing_game_request";
        public const string NEW_PRIVATE_CHAT_MESSAGE = "new_private_chat_message";
        public const string PRIVATE_CHAT_MESSAGES = "private_chat_messages";
        public const string WAITING_FOR_PLAYER_TO_START_GAME = "waiting_for_player_to_start_game";
        public const string START_GAME = "start_game";
        public const string GAME_DATA = "game_data";
        public const string GAME_MESSAGE = "game_message";
        public const string GAME_END = "game_end";
        public const string RESUMT_GAME = "resume_game";
        public const string ME_DATA = "me";
    }
}
