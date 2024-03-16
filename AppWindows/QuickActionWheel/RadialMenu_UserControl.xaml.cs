﻿using Everything_Handhelds_Tool.Classes;
using RadialMenu.Controls;
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

namespace Everything_Handhelds_Tool.AppWindows.QuickActionWheel
{
    /// <summary>
    /// Interaction logic for RadialMenu_UserControl.xaml
    /// </summary>
    public partial class RadialMenu_UserControl : UserControl
    {
        public QuickActionWheelItem quickActionWheelItem_Handler;
        public List<RadialMenuItem> subRadialMenuItems = null;
        public Classes.Actions.Action action;
        public RadialMenuCentralItem radialMenuCentralItem =  null;

        public string displayActionName = "";
        public RadialMenu_UserControl(Classes.Actions.Action importAction)
        {
            InitializeComponent();
            action = importAction;
            quickActionWheelItem_Handler = QuickActionWheelItemConverter.ActionToQuickActionWheelItemConverter(importAction);

            if (quickActionWheelItem_Handler != null)
            {
                quickActionWheelItem_Handler.SetUpIconsAndTextblock(icon, fontIcon, textblock, out subRadialMenuItems, radialMenuCentralItem, action, out displayActionName);

            }
        }

        public void ClickEvent()
        {
            if (quickActionWheelItem_Handler != null)
            {
                if (subRadialMenuItems != null)
                {
                    //do sub menu stuff
                }
                else
                {
                    quickActionWheelItem_Handler.OnClickEvent();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
    }
}