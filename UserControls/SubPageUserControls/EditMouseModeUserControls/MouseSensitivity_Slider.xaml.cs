﻿using Handheld_Hardware_Tools.Classes;
using Handheld_Hardware_Tools.Classes.Controller_Object_Classes;
using Handheld_Hardware_Tools.Classes.MouseMode;
using Handheld_Hardware_Tools.Pages;
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
using Wpf.Ui.Controls;

namespace Handheld_Hardware_Tools.UserControls.SubPageUserControls.EditMouseModeUserControls
{
    /// <summary>
    /// Interaction logic for TDP_Slider.xaml
    /// </summary>
    public partial class MouseSensitivity_Slider : ControllerUserControl
    {

        private bool dragStarted = false;
        public MouseSensitivity_Slider(double value)
        {
            InitializeComponent();

            //set virtual border
            borderControl = border;

            //main control
            mainControl = slider;

            //set control
           ConfigureControl(value);

        }
        public override void ChangeMainWindowControllerInstructionPage()
        {
            General_Functions.ChangeControllerInstructionPage("ChangeBack");
        }

        private void ConfigureControl(double value)
        {
            slider.Value = value;

        }

     

        private void ControllerUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ControlChangeValueHandler();
        }

        private void control_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            dragStarted = false;
            ControlChangeValueHandler();
        }

        private void control_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            dragStarted = true;
        }

     
        public override void ControlChangeValueHandler()
        {

            MouseProfile mouseProfile = (MouseProfile)XML_Management.Instance.LoadXML("MouseProfile");

            if (mouseProfile != null)
            {

                mouseProfile.sensitivityMouseValue = slider.Value;
            }

            mouseProfile.SaveToXML();


            QuickAccessMenu qam = Local_Object.Instance.GetQAMWindow();

            if (qam != null)
            {
                if (qam.mouseMode != null)
                {
                    qam.mouseMode.UpdateMouseProfile();
                }
            }


        }
    }
}
