using System;
using CG.Reflection;

namespace CG.Tools.QuickCrypto.ViewModels
{
    /// <summary>
    /// This class represents a view-model for the main window.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a view-model for the data privacy tab.
        /// </summary>
        public DataPrivacyViewModel DataPrivacy { get; }

        /// <summary>
        /// This property contains a view-model for the rijndael tab.
        /// </summary>
        public RijndaelViewModel Rijndael { get; }

        /// <summary>
        /// This property contains the application caption.
        /// </summary>
        public string Caption { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="MainWindowViewModel"/>
        /// class.
        /// </summary>
        public MainWindowViewModel()
        {
            // Create the default view-models.
            DataPrivacy = new DataPrivacyViewModel();
            Rijndael = new RijndaelViewModel();
            Caption = $"QuickCrypto - [{typeof(MainWindowViewModel).Assembly.ReadFileVersion()}]";
        }

        #endregion
    }
}
