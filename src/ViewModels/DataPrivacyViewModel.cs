using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace QuickCrypto.ViewModels
{
    /// <summary>
    /// This class represents a view-model for the data privacy tab.
    /// </summary>
    public class DataPrivacyViewModel : ViewModelBase
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        private byte[] _entropy = new byte[] { 12, 48, 8, 20 };
        private IEnumerable<string> _scopes;
        private string _selectedScope;
        private string _plainText;
        private string _encryptedText;

        private DelegateCommand _encryptCommand;
        private DelegateCommand _decryptCommand;

        #endregion

        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains entropy bytes.
        /// </summary>
        public byte[] Entropy
        {
            get { return _entropy; }
            set
            {
                _entropy = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a list of data protection scopes.
        /// </summary>
        public IEnumerable<string> Scopes
        {
            get { return _scopes; }
            set
            {
                _scopes = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a selected data protection scope.
        /// </summary>
        public string SelectedScope
        {
            get { return _selectedScope; }
            set
            {
                _selectedScope = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains plain text to be encrypted.
        /// </summary>
        public string PlainText 
        { 
            get { return _plainText; }
            set
            {
                _plainText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains encrypted text to be decrypted.
        /// </summary>
        public string EncryptedText
        { 
            get { return _encryptedText; } 
            set
            {
                _encryptedText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        // *******************************************************************
        // Commands.
        // *******************************************************************

        #region Commands
        
        /// <summary>
        /// This property contains the encryption command.
        /// </summary>
        public DelegateCommand EncryptCommand =>
            _encryptCommand ?? (_encryptCommand = new DelegateCommand(
                ExecuteEncryptCommand,
                CanExecuteEncryptCommand
                ));


        /// <summary>
        /// This property contains the decryption command.
        /// </summary>
        public DelegateCommand DecryptCommand =>
            _decryptCommand ?? (_decryptCommand = new DelegateCommand(
                ExecuteDecryptCommand,
                CanExecuteDecryptCommand
                ));

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="DataPrivacyViewModel"/>
        /// class.
        /// </summary>
        public DataPrivacyViewModel()
        {
            // Setup default property values.
            Scopes = Enum.GetNames(typeof(DataProtectionScope));
            SelectedScope = Enum.GetName(typeof(DataProtectionScope), DataProtectionScope.CurrentUser);
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method is called to perform an encryption operation.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        void ExecuteEncryptCommand(object args)
        {
            try
            {
                // Get the scope.
                var scope = (DataProtectionScope)Enum.Parse(
                    typeof(DataProtectionScope),
                    SelectedScope,
                    true
                    );

                // Convert the unencrypted value to bytes.
                var unprotectedBytes = Encoding.UTF8.GetBytes(
                    PlainText
                    );

                // Protect the bytes.
                var protectedBytes = ProtectedData.Protect(
                   unprotectedBytes,
                   Entropy,
                   scope
                   );

                // Convert the bytes back to a string.
                var protectedPropertyValue = Convert.ToBase64String(
                    protectedBytes
                    );

                // Update the UI.
                EncryptedText = protectedPropertyValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates whether it should be possible to call the <see cref="ExecuteEncryptCommand(object)"/>
        /// method.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        /// <returns>True if the method should be called; false otherwise.</returns>
        bool CanExecuteEncryptCommand(object args)
        {
            return true;
        }

        // *******************************************************************

        /// <summary>
        /// This method is called to perform an decryption operation.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        void ExecuteDecryptCommand(object args)
        {
            try
            {
                // Get the scope.
                var scope = (DataProtectionScope)Enum.Parse(
                    typeof(DataProtectionScope),
                    SelectedScope,
                    true
                    );

                // Convert the encrypted value to bytes.
                var encryptedBytes = Convert.FromBase64String(
                    EncryptedText
                    );

                // Unprotect the bytes.
                var unprotectedBytes = ProtectedData.Unprotect(
                    encryptedBytes,
                    Entropy,
                    scope
                    );

                // Convert the bytes back to a (non-encoded) string.
                var unprotectedPropertyValue = Encoding.UTF8.GetString(
                    unprotectedBytes
                    );

                // Update the UI.
                PlainText = unprotectedPropertyValue;
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates whether it should be possible to call the <see cref="ExecuteDecryptCommand(object)"/>
        /// method.
        /// </summary>
        /// <param name="args">The arguments for the operation.</param>
        /// <returns>True if the method should be called; false otherwise.</returns>
        bool CanExecuteDecryptCommand(object args)
        {
            return true;
        }

        #endregion
    }
}
