using GalaSoft.MvvmLight;
using WpfApplication1.Model;

namespace WpfApplication1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class WelcomeViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public WelcomeViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///
            WelcomeModel = new WelcomeModel() { Introduction = "Hello World" };
        }

        private WelcomeModel welcomeModel;

        public WelcomeModel WelcomeModel
        {
            get
            {
                return welcomeModel;
            }

            set
            {
                welcomeModel = value;
                RaisePropertyChanged(() => WelcomeModel);
            }
        }

    }
}