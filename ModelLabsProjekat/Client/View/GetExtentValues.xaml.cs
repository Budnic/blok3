﻿using Client.ViewModel;
using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for GetExtentValues.xaml
    /// </summary>
    public partial class GetExtentValues : UserControl
    {
        public GetExtentValues()
        {
            InitializeComponent();
            DataContext = new GetExtentValuesViewModel();
        }
        private void comboBoxDMSType_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<DMSType> enums = Enum.GetValues(typeof(DMSType)).Cast<DMSType>().ToList();
            enums.Remove(DMSType.MASK_TYPE);
            comboBoxDMSType.ItemsSource = enums;
        }
    }
}
