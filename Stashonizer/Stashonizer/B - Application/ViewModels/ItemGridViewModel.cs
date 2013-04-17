using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Stashonizer.Application.ViewModels {
    public class ItemGridViewModel : Screen {

        public PoeItem Item { get; set; }

        [ImportingConstructor]
        public ItemGridViewModel(PoeItem item) {
            DisplayName = "Stash View";
            this.Item = item;
        }
    }
}
