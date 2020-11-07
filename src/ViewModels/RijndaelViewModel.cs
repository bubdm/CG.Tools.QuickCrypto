using Syncfusion.Windows.Shared;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace CG.Tools.QuickCrypto.ViewModels
{
    /// <summary>
    /// This class represents a view-model for the rijndael tab.
    /// </summary>
    public class RijndaelViewModel : ViewModelBase
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        private string _salt;
        private string _password;
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
        /// This property contains a SALT value.
        /// </summary>
        public string Salt
        {
            get { return _salt; }
            set
            {
                _salt = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property contains a password value.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
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
                var encryptedBytes = new byte[0];

                // Get the password bytes.
                var passwordBytes = Encoding.UTF8.GetBytes(
                    Password
                    );

                // Get the salt bytes.
                var saltBytes = Encoding.UTF8.GetBytes(
                    Salt
                    );

                // Create the algorithm
                using (var alg = new RijndaelManaged())
                {
                    // Set the block and key sizes.
                    alg.KeySize = 256;
                    alg.BlockSize = 128;

                    // Derive the ACTUAL crypto key.
                    var key = new Rfc2898DeriveBytes(
                        passwordBytes,
                        saltBytes,
                        10000
                        );

                    // Generate the key and salt with proper lengths.
                    alg.Key = key.GetBytes(alg.KeySize / 8);
                    alg.IV = key.GetBytes(alg.BlockSize / 8);

                    // Create the encryptor.
                    using (var enc = alg.CreateEncryptor(
                        alg.Key,
                        alg.IV
                        ))
                    {
                        // Create a temporary stream.
                        using (var stream = new MemoryStream())
                        {
                            // Create a cryptographic stream.
                            using (var cryptoStream = new CryptoStream(
                                stream,
                                enc,
                                CryptoStreamMode.Write
                                ))
                            {
                                // Create a writer
                                using (var writer = new StreamWriter(
                                    cryptoStream
                                    ))
                                {
                                    // Write the bytes.
                                    writer.Write(
                                        PlainText
                                        );
                                }

                                // Get the bytes.
                                encryptedBytes = stream.ToArray();
                            }
                        }
                    }
                }

                // Convert the bytes back to an encoded string.
                var encryptedValue = Convert.ToBase64String(
                    encryptedBytes
                    );

                // Update the UI.
                EncryptedText = encryptedValue;
            }
            catch (Exception ex)
            {
                // Clear whatever is in the UI.
                EncryptedText = "";

                // Show the user what happened.
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
                // Convert the encrypted value to bytes.
                var encryptedBytes = Convert.FromBase64String(
                    EncryptedText
                    );

                // Get the password bytes.
                var passwordBytes = Encoding.UTF8.GetBytes(
                    Password
                    );

                // Get the salt bytes.
                var saltBytes = Encoding.UTF8.GetBytes(
                    Salt
                    );

                var plainValue = "";

                // Create the algorithm
                using (var alg = new RijndaelManaged())
                {
                    // Set the block and key sizes.
                    alg.KeySize = 256;
                    alg.BlockSize = 128;

                    // Derive the ACTUAL crypto key.
                    var key = new Rfc2898DeriveBytes(
                        passwordBytes,
                        saltBytes,
                        10000
                        );

                    // Generate the key and salt with proper lengths.
                    alg.Key = key.GetBytes(alg.KeySize / 8);
                    alg.IV = key.GetBytes(alg.BlockSize / 8);

                    // Create the decryptor.
                    using (var dec = alg.CreateDecryptor(
                        alg.Key,
                        alg.IV
                        ))
                    {
                        // Create a temporary stream.
                        using (var stream = new MemoryStream(
                            encryptedBytes
                            ))
                        {
                            // Create a crypto stream.
                            using (var cryptoStream = new CryptoStream(
                                stream,
                                dec,
                                CryptoStreamMode.Read
                                ))
                            {
                                using (var reader = new StreamReader(
                                    cryptoStream
                                    ))
                                {
                                    plainValue = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                }

                // Update the UI.
                PlainText = plainValue;
            }
            catch (Exception ex)
            {
                // Clear whatever is in the UI.
                PlainText = "";

                // Show the user what happened.
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
