using System.Windows;
using Stashonizer.Application.ViewModels;

namespace Stashonizer.Presentation.Views {
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window, ILoginView {
        public LoginView() {
            InitializeComponent();
        }

        public string UserPassword {
            get { return txtbxPassword.Password; }
            set { txtbxPassword.Password = value; }
        }

        public string UserAccount {
            get { return txtbxUserAccount.Text; }
            set { txtbxUserAccount.Text = value; }
        }
    }
}
