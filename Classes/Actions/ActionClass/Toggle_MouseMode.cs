﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Handheld_Hardware_Tools.Classes.Actions.ActionClass
{
    public class Toggle_MouseMode : Action
    {
        public Toggle_MouseMode()
        {
            actionName = "Toggle_MouseMode";
            //arguments = new List<string>();
        }
        public override void OnActivate(string quickActionWheelParameter = "")
        {
            //calls main window toggle window
            Application.Current.Dispatcher.Invoke(() =>
            {
                QuickAccessMenu mainWindow = (QuickAccessMenu)Application.Current.MainWindow;
                mainWindow.ToggleMouseMode();

            });
        }
    }
}
