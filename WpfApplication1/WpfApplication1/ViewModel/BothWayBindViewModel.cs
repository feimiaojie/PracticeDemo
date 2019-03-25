using GalaSoft.MvvmLight;
using WpfApplication1.Model;

namespace WpfApplication1.ViewModel
{
    public class BothWayBindViewModel : ViewModelBase
    {
        private UserInfoModel userInfo;

        public UserInfoModel UserInfo { get => userInfo; set { userInfo = value; RaisePropertyChanged(() => UserInfo); } }

        public BothWayBindViewModel()
        {
            UserInfo = new UserInfoModel();
        }


    }
}
