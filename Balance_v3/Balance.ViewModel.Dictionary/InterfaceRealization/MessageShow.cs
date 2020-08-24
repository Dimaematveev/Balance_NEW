
using Balance.BL.Interfaces;
using System;
using System.Windows;

namespace Balance.ViewModel.Dictionary.InterfaceRealization
{
    public class MessageShow : IMessage
    {
        public override void ShowMessage(string message, string header, TypeMessage typeMessage)
        {
            if (header == null)
            {
                if (typeMessage == TypeMessage.None)
                {
                    header = "";
                }
                else
                {
                    header = Enum.GetName(typeof(TypeMessage), typeMessage);
                }
            }

            MessageBoxButton messageBoxButton = MessageBoxButton.OK;
            MessageBoxImage messageBoxImage = MessageBoxImage.None;
            switch (typeMessage)
            {
                case TypeMessage.None:
                    messageBoxImage = MessageBoxImage.None;
                    break;
                case TypeMessage.Warning:
                    messageBoxImage = MessageBoxImage.Warning;
                    break;
                case TypeMessage.Information:
                    messageBoxImage = MessageBoxImage.Information;
                    break;
                case TypeMessage.Error:
                    messageBoxImage = MessageBoxImage.Error;
                    break;
                case TypeMessage.Question:
                    messageBoxButton = MessageBoxButton.YesNo;
                    messageBoxImage = MessageBoxImage.Question;
                    break;
                default:
                    break;
            }
            var resultMessage = MessageBox.Show(message, header, messageBoxButton, messageBoxImage, MessageBoxResult.OK);
            Result = !(resultMessage.Equals(MessageBoxResult.No));
        }
    }
}
