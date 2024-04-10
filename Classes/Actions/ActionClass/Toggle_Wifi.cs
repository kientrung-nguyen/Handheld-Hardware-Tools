﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Handheld_Hardware_Tools.Classes.Actions.ActionClass
{
    public class Toggle_Wifi : Action
    {
        public Toggle_Wifi()
        {
            actionName = "Toggle_Wifi";
            //arguments = new List<string>();
        }
        public override void OnActivate(string quickActionWheelParameter = "")
        {
            Wifi_BT_Management.Instance.ToggleWifi();
        }
    }
}
