using Connected;
using System.Security.Principal;

namespace BalanceMain
{
    public class AdminPanelBL
    {
        public string ResultConnect { get;private set; }

        /// <summary>
        /// Открывает соединение с SQL, и если удалось выводит true
        /// </summary>
        /// <returns>Если соединение открылось вывод true, иначе false</returns>
        public bool OpenConnected()
        {
            ConnectBL.ConnectOpen();
            ResultConnect = ConnectBL._resultConnection;
            return ConnectBL._IsOpen;
        }

        /// <summary>
        /// Просто закрывает соединение
        /// </summary>
        public void CloseConnected()
        {
            ConnectBL.ConnectClose();
        }
    }
}
