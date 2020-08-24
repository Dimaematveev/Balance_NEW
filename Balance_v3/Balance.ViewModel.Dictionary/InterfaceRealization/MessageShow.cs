
using Balance.BL.Interfaces;
using System.Windows;

namespace Balance.ViewModel.Dictionary.InterfaceRealization
{
    public class MessageShow : IMessage
    {
        public override void ShowMessage(string message, TypeMessage typeMessage)
        {
            string header = "";
            MessageBoxButton messageBoxButton = MessageBoxButton.OK;
            MessageBoxImage messageBoxImage = MessageBoxImage.None;
            switch (typeMessage)
            {
                case TypeMessage.None:
                    header = "";
                    messageBoxButton = MessageBoxButton.OK;
                    messageBoxImage = MessageBoxImage.None;
                    break;
                case TypeMessage.Warning:
                    header = "Warning";
                    messageBoxButton = MessageBoxButton.OK;
                    messageBoxImage = MessageBoxImage.Warning;
                    break;
                case TypeMessage.Information:
                    header = "Information";
                    messageBoxButton = MessageBoxButton.OK;
                    messageBoxImage = MessageBoxImage.Information;
                    break;
                case TypeMessage.Error:
                    header = "Error";
                    messageBoxButton = MessageBoxButton.OK;
                    messageBoxImage = MessageBoxImage.Error;
                    break;
                case TypeMessage.Question:
                    header = "Question";
                    messageBoxButton = MessageBoxButton.YesNo;
                    messageBoxImage = MessageBoxImage.Error;
                    break;
                default:
                    break;
            }
            Result = MessageBox.Show(message, header, messageBoxButton, messageBoxImage, MessageBoxResult.OK) != MessageBoxResult.No;
        }
    }
}
