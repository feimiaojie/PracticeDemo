using GalaSoft.MvvmLight;

namespace WpfApplication1.Model
{
    public class UserInfoModel : ObservableObject
    {
        private string userName;

        public string UserName { get => userName; set { userName = value; RaisePropertyChanged(() => UserName); } }

        private long phone;

        public long Phone { get => phone; set { phone = value; RaisePropertyChanged(() => Phone); } }

        private int gender;

        public int Gender { get => gender; set { gender = value; RaisePropertyChanged(() => Gender); } }
        
        private string address;

        public string Address { get => address; set { address = value; RaisePropertyChanged(() => Address); } }
    }
}
