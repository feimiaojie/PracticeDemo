using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    public class MessageViewModelReceive: ViewModelBase
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

        public MessageViewModelReceive()
        {
            Messenger.Default.Register<string>(this, "Message1", (msg) =>
            {
                Msg = msg;
            });
        }
    }
}
