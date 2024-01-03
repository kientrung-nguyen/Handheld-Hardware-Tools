﻿using Everything_Handhelds_Tool.Classes;
using Everything_Handhelds_Tool.Classes.Controller_Object_Classes;
using Everything_Handhelds_Tool.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Everything_Handhelds_Tool.UserControls.SettingsPageUserControls
{
    /// <summary>
    /// Interaction logic for TDP_Slider.xaml
    /// </summary>
    public partial class EditHomepageSettings_Button : ControllerUserControl
    {

      
        public EditHomepageSettings_Button()
        {
            InitializeComponent();

            //set virtual border
            borderControl = border;

            //main control
            mainControl = button;

        
        }
        public override void ChangeMainWindowControllerInstructionPage()
        {
            General_Functions.ChangeControllerInstructionPage("SelectBack");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //navigate to the specific settings page
      

            Page page = new EditHomeOverviewPage();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.frame.Content = page;


        }
    }
}