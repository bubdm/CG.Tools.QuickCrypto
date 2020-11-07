using System;
using System.IO;
using System.Threading.Tasks;
using CG.Reflection;
using CG.Tools.QuickCrypto.Infrastructure;
using Syncfusion.Windows.Shared;

namespace CG.Tools.QuickCrypto.ViewModels
{
    /// <summary>
    /// This class represents a view-model for the entropy dialog.
    /// </summary>
    public class EntropyWindowViewModel : ViewModelBase
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        private DelegateCommand _okCommand;
        private DelegateCommand _cancelCommand;
        private DelegateCommand _randomCommand;
        private DelegateCommand _resetCommand;

        #endregion

        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains the application caption.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// This property contains the entropy values.
        /// </summary>
        public byte[] Entropy { get; set; }  

        /// <summary>
        /// This property contains a slice of the entropy array.
        /// </summary>
        public byte SliceA
        {
            get { return Entropy[0]; }
            set
            {
                Entropy[0] = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a slice of the entropy array.
        /// </summary>
        public byte SliceB
        {
            get { return Entropy[1]; }
            set
            {
                Entropy[1] = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a slice of the entropy array.
        /// </summary>
        public byte SliceC
        {
            get { return Entropy[2]; }
            set
            {
                Entropy[2] = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a slice of the entropy array.
        /// </summary>
        public byte SliceD
        {
            get { return Entropy[3]; }
            set
            {
                Entropy[3] = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a slice of the entropy array.
        /// </summary>
        public byte SliceE
        {
            get { return Entropy[4]; }
            set
            {
                Entropy[4] = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a slice of the entropy array.
        /// </summary>
        public byte SliceF
        {
            get { return Entropy[5]; }
            set
            {
                Entropy[5] = value;
                OnPropertyChanged();
            }
        }

        #endregion

        // *******************************************************************
        // Commands.
        // *******************************************************************

        #region Commands

        /// <summary>
        /// This property contains the OK command.
        /// </summary>
        public DelegateCommand OkCommand =>
            _okCommand ?? (_okCommand = new DelegateCommand(
                ExecuteOkCommand,
                CanExecuteOkCommand
                ));

        /// <summary>
        /// This property contains the cancel command.
        /// </summary>
        public DelegateCommand CancelCommand =>
            _cancelCommand ?? (_cancelCommand = new DelegateCommand(
                ExecuteCancelCommand,
                CanExecuteCancelCommand
                ));

        /// <summary>
        /// This property contains the random command.
        /// </summary>
        public DelegateCommand RandomCommand =>
            _randomCommand ?? (_randomCommand = new DelegateCommand(
                ExecuteRandomCommand,
                CanExecuteRandomCommand
                ));

        /// <summary>
        /// This property contains the reset command.
        /// </summary>
        public DelegateCommand ResetCommand =>
            _resetCommand ?? (_resetCommand = new DelegateCommand(
                ExecuteResetCommand,
                CanExecuteResetCommand
                ));

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="EntropyWindowViewModel"/>
        /// class.
        /// </summary>
        public EntropyWindowViewModel()
        {
            // Create the defaults
            Caption = $"QuickCrypto - [{typeof(EntropyWindowViewModel).Assembly.ReadFileVersion()}]";
            Entropy = new byte[] { 4, 8, 15, 16, 23, 42 }; // Don't tell Hugo!!
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method is called to close the dialog.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        void ExecuteOkCommand(object args)
        {
            var window = args as ICloseWindow;
            if (null != window)
            {
                window.Close(true);
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates whether it should be possible to call the <see cref="ExecuteOkCommand(object)"/>
        /// method.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        /// <returns>True if the method should be called; false otherwise.</returns>
        bool CanExecuteOkCommand(object args)
        {
            return true;
        }

        // *******************************************************************

        /// <summary>
        /// This method is called to close the dialog.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        void ExecuteCancelCommand(object args)
        {
            var window = args as ICloseWindow;
            if (null != window)
            {
                window.Close(false);
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates whether it should be possible to call the <see cref="ExecuteCancelCommand(object)"/>
        /// method.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        /// <returns>True if the method should be called; false otherwise.</returns>
        bool CanExecuteCancelCommand(object args)
        {
            return true;
        }

        // *******************************************************************

        /// <summary>
        /// This method is called to generate random entropy values.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        void ExecuteRandomCommand(object args)
        {
            var rnd = new RandomEx();
            SliceA = (byte)rnd.Next(1, 255);
            SliceB = (byte)rnd.Next(1, 255);
            SliceC = (byte)rnd.Next(1, 255);
            SliceD = (byte)rnd.Next(1, 255);
            SliceE = (byte)rnd.Next(1, 255);
            SliceF = (byte)rnd.Next(1, 255);
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates whether it should be possible to call the <see cref="ExecuteRandomCommand(object)"/>
        /// method.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        /// <returns>True if the method should be called; false otherwise.</returns>
        bool CanExecuteRandomCommand(object args)
        {
            return true;
        }

        // *******************************************************************

        /// <summary>
        /// This method is called to generate reset entropy values.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        void ExecuteResetCommand(object args)
        {
            SliceA = 4;
            SliceB = 8;
            SliceC = 15;
            SliceD = 16;
            SliceE = 23;
            SliceF = 42;
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates whether it should be possible to call the <see cref="ExecuteResetCommand(object)"/>
        /// method.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        /// <returns>True if the method should be called; false otherwise.</returns>
        bool CanExecuteResetCommand(object args)
        {
            return true;
        }

        #endregion
    }
}
