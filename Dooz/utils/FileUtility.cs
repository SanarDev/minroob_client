using Dooz.socket.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.utils
{
    class FileUtility
    {
        public static void SaveLoginData(LoggedUser user)
        {
            try
            {
                File.WriteAllText("loginData.gmSession", JsonConvert.SerializeObject(user));
            }
            catch (Exception e)
            {
                Log("error in SaveLoginData: "+e.Message);
            }
        }

        public static void Log(string message)
        {
            //File.AppendAllText("log.txt", message+"\n");
        }
        public static void RemoveLoginData()
        {
            File.Delete("loginData.gmSession");
        }
        public static LoggedUser GetLoginData()
        {
            if (!File.Exists("loginData.gmSession"))
            {
                return null;
            }
            try
            {
                var data = File.ReadAllText("loginData.gmSession");
                return JsonConvert.DeserializeObject<LoggedUser>(data);
            }catch(Exception e)
            {
                return null;
            }
        }

    }
}
