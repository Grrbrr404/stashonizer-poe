using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace Stashonizer.Application.ViewModels {
    public class LoginViewModel : Screen {

        private ILoginView _view;

        public ILoginView View { get { return _view; } }

        [ImportingConstructor]
        public LoginViewModel() {
            ViewAttached += OnViewAttached;    
        }

        private void OnViewAttached(object sender, ViewAttachedEventArgs viewAttachedEventArgs) {
            if (viewAttachedEventArgs.View is ILoginView) {
                _view = (ILoginView)viewAttachedEventArgs.View;
            }
        }

        public void ExecuteLogin() {
            TryClose(true);
        }

    }
}
