using System;

namespace QuickCrypto.ViewModels
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
        }

        #endregion
    }
}
