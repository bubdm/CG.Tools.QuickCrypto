using CG.Tools.QuickCrypto.Infrastructure;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CG.Tools.QuickCrypto.Views
{
    /// <summary>
    /// Interaction logic for EntropyWindow.xaml
    /// </summary>
    public partial class EntropyWindow : Window, ICloseWindow
    {
        /// <summary>
        /// This constrctor creates a new instance of the <see cref="EntropyWindow"/>
        /// class.
        /// </summary>
        public EntropyWindow()
        {
            InitializeComponent();
        }

        /// <inheritdoc />
        public void Close(bool? result)
        {
            DialogResult = result;
            base.Close();
        }
    }
}
