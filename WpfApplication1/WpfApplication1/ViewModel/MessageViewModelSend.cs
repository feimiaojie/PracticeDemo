using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    public class MessageViewModelSend : ViewModelBase
    {
        private string msg;

        public string Msg
        {
            get { return msg; }
            set
            {
                msg = value;
                RaisePropertyChanged(() => Msg);
            }
        }

        public RelayCommand SendCommand
        {
            get; set;
        }

        public MessageViewModelSend()
        {
            SendCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<string>(Msg, "Message1");
            });

        }
    }
}
