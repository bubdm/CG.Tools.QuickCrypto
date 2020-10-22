using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QuickCrypto.Infrastructure
{
    /// <summary>
    /// This class converts a byte array to a string.
    /// </summary>
    [ValueConversion(typeof(byte[]), typeof(string))]
    public class ByteArrayConverter : IValueConverter
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method converts a byte array to a string.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An optional parameter for the conversion. </param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>A string containing the converted byte array.</returns>
        public object Convert(
            object value, 
            Type targetType, 
            object parameter,
            System.Globalization.CultureInfo culture
            )
        {
            byte[] bytes = (byte[])value;
            StringBuilder sb = new StringBuilder(100);
            for (int x = 0; x < bytes.Length; x++)
            {
                sb.Append(bytes[x].ToString()).Append(" ");
            }
            return sb.ToString();
        }

        // *******************************************************************

        /// <summary>
        /// This method converts a string to a byte array.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An optional parameter for the conversion. </param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>A byte array containing the converted string.</returns>
        public object ConvertBack(
            object value, 
            Type targetType,
            object parameter, 
            System.Globalization.CultureInfo culture
            )
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
