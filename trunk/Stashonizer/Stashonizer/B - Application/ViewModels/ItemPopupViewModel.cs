using System.Windows.Controls;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Stashonizer.Application.ViewModels {
    public class ItemPopupViewModel : Screen {
        private UserControl _view;
        private string _headerLeftSource;
        private string _headerRightSource;
        private string _headerSource;
        private string _topText;

        public string HeaderLeftSource {
            get {
                return _headerLeftSource;
            }
            set {
                _headerLeftSource = value;
                NotifyOfPropertyChange(() => HeaderLeftSource);
            }
        }

        public PoeItem Item { get; set; }

        public string HeaderRightSource {
            get { return _headerRightSource; }
            set {
                _headerRightSource = value;
                NotifyOfPropertyChange(() => HeaderRightSource);
            }
        }

        public string HeaderSource {
            get { return _headerSource; }
            set {
                _headerSource = value;
                NotifyOfPropertyChange(() => HeaderSource);
            }
        }

        public string TopText {
            get {
                return _topText;
            }
            set {
                _topText = value;
                NotifyOfPropertyChange(() => TopText);
            }
        }

        [ImportingConstructor]
        public ItemPopupViewModel() {

        }

        protected override void OnInitialize() {
            base.OnInitialize();
            Render();
        }

        internal double GetHeight() {
            return _view.ActualHeight * -1;
        }

        protected override void OnViewAttached(object view, object context) {
            _view = view as UserControl;
            base.OnViewAttached(view, context);
        }


        public void Render() {
            SetHeader(Item.rarity);
            TopText = "Stack Size: 12/20";
        }

        private void SetHeader(ItemRarity itemRarity) {
            string path = "/Stashonizer;component/A - Presentation/Images/header_{0}.png";
            HeaderLeftSource = string.Format(path, itemRarity.ToString().ToLower() + "_left");
            HeaderRightSource = string.Format(path, itemRarity.ToString().ToLower() + "_right");
            HeaderSource = string.Format(path, itemRarity.ToString().ToLower());
        }
    }
}
