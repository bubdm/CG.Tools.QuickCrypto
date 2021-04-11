using CG.DataProtection;
using Microsoft.AspNetCore.DataProtection;
using CG.Tools.QuickCrypto.Views;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace CG.Tools.QuickCrypto.ViewModels
{
    /// <summary>
    /// This class represents a view-model for the data protection tab.
    /// </summary>
    public class DataProtectionViewModel : ViewModelBase
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

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
        /// This constructor creates a new instance of the <see cref="DataProtectionViewModel"/>
        /// class.
        /// </summary>
        public DataProtectionViewModel()
        {

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
                // Update the UI.
                EncryptedText = DataProtector.Instance().Protect(
                    PlainText
                    );
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
                // Update the UI.
                PlainText = DataProtector.Instance().Unprotect(
                    EncryptedText
                    );
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
