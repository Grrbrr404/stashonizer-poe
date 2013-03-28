namespace Stashonizer.Foundation.Threading
{
    using System;
    using System.Threading;

    public enum BackgroundProcessState
    {
        /// <summary>
        /// Background process is initialized
        /// </summary>
        Initialized,

        /// <summary>
        /// Background process is running
        /// </summary>
        Running,

        /// <summary>
        /// Background process has finished
        /// </summary>
        Finished
    }

    /// <summary>
    /// This class contains a background <seealso cref="Thread"/> and an abstract method <seealso cref="Execute"/> which will be
    /// called inside the thread. Only additional functionality is the possibility to start/stop the thread and safe disposing.
    /// </summary>
    public abstract class BackgroundProcess : IDisposable
    {
        #region private members
        /// <summary>
        /// Synchronizing object (used in lock statements)
        /// </summary>
        private readonly object _syncObj = new object();

        /// <summary>
        /// Background thread executing 
        /// </summary>
        private Thread _backgroundThread;

        /// <summary>
        /// Flag, if thread should be terminated
        /// </summary>
        private bool _terminated;

        /// <summary>
        /// State of background process
        /// </summary>
        private BackgroundProcessState _state;
        #endregion

        /// <summary>
        /// Finalizes an instance of the <see cref="BackgroundProcess"/> class. 
        /// </summary>
        ~BackgroundProcess()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets a value indicating whether thread has to be terminated
        /// </summary>
        public bool IsTerminated
        {
            get
            {
                lock (_syncObj)
                    return _terminated;
            }

            private set
            {
                lock (_syncObj)
                    _terminated = value;
            }
        }

        /// <summary>
        /// Gets state of background process
        /// </summary>
        public BackgroundProcessState State
        {
            get
            {
                lock (_syncObj)
                    return _state;
            }

            private set
            {
                lock (_syncObj)
                    _state = value;
            }
        }

        #region public methods
        /// <summary>
        /// Führt anwendungsspezifische Aufgaben durch, die mit der Freigabe, der Zurückgabe oder dem Zurücksetzen von nicht verwalteten Ressourcen zusammenhängen.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Set <seealso cref="IsTerminated"/> flag to indicate thread to abort
        /// </summary>
        public void Terminate()
        {
            IsTerminated = true;
        }

        /// <summary>
        /// Initialized and executes background thread
        /// </summary>
        public void Start()
        {
            if (_backgroundThread != null) return;

            _backgroundThread = new Thread(InternalExecute) { IsBackground = true };
            _backgroundThread.Start();
        }

        /// <summary>
        /// Terminates running background thread
        /// </summary>
        public void Stop()
        {
            if (_backgroundThread == null) return;

            try
            {
                Terminate();
                while (State != BackgroundProcessState.Finished)
                    Thread.Sleep(10);
            }
            catch (ThreadStateException)
            {

            }
            finally
            {
                _backgroundThread = null;
            }
        }

        /// <summary>
        /// Checks if caller is executed in context of messagequeue(thread)
        /// </summary>
        /// <returns>True, if caller is in context of messagequeue(thread)</returns>
        public bool IsCurrentContext()
        {
            return Thread.CurrentThread == _backgroundThread;
        }
        #endregion

        #region protected methods (abstract)
        /// <summary>
        /// Method called once by background <seealso cref="Thread"/>
        /// </summary>
        protected abstract void Execute();
        #endregion

        /// <summary>
        /// Disposes thread (if not already disposed)
        /// </summary>
        /// <param name="disposing">True, if called from <seealso cref="Dispose"/></param>
        protected virtual void Dispose(bool disposing)
        {
            Stop();
        }

        #region private methods
        /// <summary>
        /// Internal callback method used by thread (used for pre- and post-processing)
        /// </summary>
        private void InternalExecute()
        {
            State = BackgroundProcessState.Running;
            try
            {
                Execute();
            }
            finally
            {
                State = BackgroundProcessState.Finished;
                _backgroundThread = null;
            }
        }
        #endregion
    }
}