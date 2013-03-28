namespace Stashonizer.Foundation.Threading
{
    using System;

    using Stashonizer.Foundation.Threading.Interfaces;

    public class BackgroundAction : BackgroundProcess, IBackgroundAction {
        private Action<IBackgroundAction> _processAction;

        public BackgroundAction(Action<IBackgroundAction> action) {
            _processAction = action;
        }

        protected override void Execute() {
            _processAction.Invoke(this);
        }
    }
}
