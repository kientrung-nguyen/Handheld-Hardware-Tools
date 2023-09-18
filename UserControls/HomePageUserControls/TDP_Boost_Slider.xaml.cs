﻿using Everything_Handhelds_Tool.Classes;
using Everything_Handhelds_Tool.Classes.Controller_Object_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Everything_Handhelds_Tool.UserControls.HomePageUserControls
{
    /// <summary>
    /// Interaction logic for TDP_Slider.xaml
    /// </summary>
    public partial class TDP_Boost_Slider : ControllerUserControl
    {
        public TDP_Boost_Slider()
        {
            InitializeComponent();
            //set virtual border
            borderControl = border;

            //set control
            ConfigureControl();
        }
        private void ConfigureControl()
        {
            Settings settings = Load_Settings.Instance.LoadSettings();

            control.Maximum = settings.maxTDP;
            control.Minimum = settings.minTDP;

            control.Value = TDP_Management.Instance.ReadAndReturnBoostTDP();
        }

        private void control_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {

        }

        private void control_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {

        }
    }
}
