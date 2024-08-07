﻿using Handheld_Hardware_Tools.Classes;
using Handheld_Hardware_Tools.Classes.Controller_Object_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
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

namespace Handheld_Hardware_Tools.UserControls.ActionWrapPanelUserControls
{

    public partial class Action_UserControl : ControllerUserControl
    {
        public ActionUserControl_DefaultHandler actionHandler = null;
      
        public Action_UserControl(Handheld_Hardware_Tools.Classes.Actions.Action newAction)
        {
            InitializeComponent();

            //set virtual border
            borderControl = border;

            //main control
            mainControl = button;

            SelectActionHandler(newAction);

            //Configure text and symbol to match the action
            ConfigureTextAndSymbol();
        
        }
        private void SelectActionHandler(Classes.Actions.Action action)
        {
            switch (action.actionName)
            {
                case "Cycle_TDP":
                    actionHandler = new ActionUserControl_Cycle_TDP(action);
                    break;
                case "Cycle_EPP":
                    actionHandler = new ActionUserControl_Cycle_EPP (action);
                    break;
                case "Cycle_Volume":
                    actionHandler = new ActionUserControl_Cycle_Volume(action);
                    break;
                case "Change_TDP":
                    actionHandler = new ActionUserControl_Change_TDP(action);
                    break;
                case "Toggle_WifiAP":
                    actionHandler = new ActionUserControl_Toggle_WifiAP(action);
                    break;
                case "Toggle_Desktop":
                    actionHandler = new ActionUserControl_Toggle_Desktop(action);
                    break;
                case "Toggle_QAM":
                    actionHandler = new ActionUserControl_Toggle_QAM(action);
                    break;
                case "Toggle_Wifi":
                    actionHandler = new ActionUserControl_Toggle_Wifi(action);
                    break;
                case "Toggle_BT":
                    actionHandler = new ActionUserControl_Toggle_BT(action);
                    break;
                case "Toggle_IntegerScaling":
                    actionHandler = new ActionUserControl_Toggle_IntegerScaling(action);
                    break;
                case "Toggle_MicrophoneMute":
                    actionHandler = new ActionUserControl_Toggle_MicrophoneMute(action);
                    break;
                case "Toggle_VolumeMute":
                    actionHandler = new ActionUserControl_Toggle_VolumeMute(action);
                    break;
                case "Toggle_WinOSK":
                    actionHandler = new ActionUserControl_Toggle_WinOSK(action);
                    break;
                case "Toggle_OSK":
                    actionHandler = new ActionUserControl_Toggle_OSK(action);
                    break;
                case "Toggle_WindowManager":
                    actionHandler = new ActionUserControl_Toggle_WindowManager(action);
                    break;
                case "Toggle_QuickActionWheel":
                    actionHandler = new ActionUserControl_Toggle_QuickActionWheel(action);
                    break;
                case "Toggle_MouseMode":
                    actionHandler = new ActionUserControl_Toggle_MouseMode(action);
                    break;
                case "Open_SteamBP":
                    actionHandler = new ActionUserControl_Open_SteamBP(action);
                    break;
                case "Toggle_Guide":
                    actionHandler = new ActionUserControl_Toggle_Guide(action);
                    break;
                case "Toggle_FreeSync":
                    actionHandler = new ActionUserControl_Toggle_FreeSync(action);
                    break;
                case "Toggle_Controller":
                    actionHandler = new ActionUserControl_Toggle_Controller(action);
                    break;
                default:
                    MessageBox.Show("NO HANDLER FOR THIS ACTION, ADD IT YOU DUMMY. Action_UserControl.xaml.cs " + action.actionName);
                    break;
            }
            
        }

        public override void ChangeMainWindowControllerInstructionPage()
        {
            General_Functions.ChangeControllerInstructionPage("SelectBack");
        }

        private void ConfigureTextAndSymbol()
        {
            actionHandler.ConfigureControls(textBlock, textBlock2, symbolIcon, symbolIconDisabled, iconGrid, faIcon);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            actionHandler.ButtonPress(textBlock,textBlock2,symbolIcon,symbolIconDisabled);

        }
    }
}
