﻿using Everything_Handhelds_Tool.Classes;
using Everything_Handhelds_Tool.Classes.Actions;
using Everything_Handhelds_Tool.Classes.Controller_Object_Classes;
using Everything_Handhelds_Tool.Pages;
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

namespace Everything_Handhelds_Tool.UserControls.EditActionUserControls
{
    /// <summary>
    /// Interaction logic for TDP_Slider.xaml
    /// </summary>
    public partial class PowerPlan_Combobox : ControllerUserControl
    {
        int originalSelectedIndex = -1;
        Dictionary<string, Guid> powerPlanLookup = PowerplanHelper.GetPowerSchemes();
        public PowerPlan_Combobox()
        {
            InitializeComponent();

            //set virtual border
            borderControl = border;

            //main control
            mainControl = comboBox;


            //set control
           ConfigureControl();

        }
        public override void ChangeMainWindowControllerInstructionPage()
        {
            General_Functions.ChangeControllerInstructionPage("ChangeBack");
        }

        private Dictionary<string,string> powerPlanLookup2 = new Dictionary<string, string>()
        {
            { Application.Current.Resources["Usercontrol_PowerPlanHighPerformance"].ToString(), "High_Performance" },
            { Application.Current.Resources["Usercontrol_PowerPlanBalanced"].ToString(), "Balanced" },
            { Application.Current.Resources["Usercontrol_PowerPlanPowerSaver"].ToString(), "Power_Saver" },
            { Application.Current.Resources["Usercontrol_PowerPlanOptimizedPowerSaver"].ToString(), "Optimized_Power_Saver" }
        };
        
        private void ConfigureControl()
        {
            comboBox.ItemsSource = powerPlanLookup;

            string getActiveScheme = PowerplanHelper.GetActivePowerSchemeName();

            foreach (KeyValuePair<string,Guid> pair in comboBox.ItemsSource)
            {
                if (pair.Key == getActiveScheme)
                {
                    comboBox.SelectedItem = pair;
                    originalSelectedIndex = comboBox.SelectedIndex;
                }
            }

        }




        public override void ReturnControlToPage()
        {
            //NEED TO DO EXTRA, if combobox ORIGINAL selected index != new,  we go back to the old value. It only changes when you press A
            if (comboBox.SelectedIndex != originalSelectedIndex)
            {
                comboBox.SelectedIndex = originalSelectedIndex;
            }

            //still run normal code for return to page
            base.ReturnControlToPage();
        }


        public override void ControlChangeValueHandler()
        {
            //set originalselectedindex to the NEW selected index to prevent accidental change when returning control to page (where it will reset to original if indexes dont match)
            HandleDropDownChanged();
        }

        private void HandleDropDownChanged()
        {
            if (comboBox.SelectedIndex != originalSelectedIndex && comboBox.SelectedIndex > -1)
            {
                originalSelectedIndex = comboBox.SelectedIndex;

                KeyValuePair<string, Guid> selectedItem = (KeyValuePair<string, Guid>)comboBox.SelectedItem;
       
                if (selectedItem.Value != null)
                {

                }

               
            }
        }

        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            HandleDropDownChanged();
        }
    }


}
