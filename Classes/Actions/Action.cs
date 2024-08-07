﻿using Handheld_Hardware_Tools.Classes.Actions.ActionClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace Handheld_Hardware_Tools.Classes.Actions
{
    //List of items in this class

    //Action model which has all the action details


    //Action model is for general use, there will be a display model below for the action panel page
    [XmlInclude(typeof(Change_TDP))]
    [XmlInclude(typeof(Toggle_WifiAP))]
    [XmlInclude(typeof(Cycle_TDP))]
    [XmlInclude(typeof(Cycle_Volume))]
    [XmlInclude(typeof(Toggle_IntegerScaling))]
    [XmlInclude(typeof(Toggle_MicrophoneMute))]
    [XmlInclude(typeof(Toggle_VolumeMute))]
    [XmlInclude(typeof(Toggle_Controller))]
    [XmlInclude(typeof(Toggle_Wifi))]
    [XmlInclude(typeof(Toggle_QAM))]
    [XmlInclude(typeof(Toggle_BT))]
    [XmlInclude(typeof(Toggle_WinOSK))]
    [XmlInclude(typeof(Toggle_OSK))]
    [XmlInclude(typeof(Toggle_WindowManager))]
    [XmlInclude(typeof(Toggle_QuickActionWheel))]
    [XmlInclude(typeof(Toggle_Desktop))]
    [XmlInclude(typeof(Toggle_MouseMode))]
    [XmlInclude(typeof(Toggle_Guide))]
    [XmlInclude(typeof(Open_SteamBP))]
    [XmlInclude(typeof(Cycle_EPP))]
    [XmlInclude(typeof(Toggle_FreeSync))]
    public class Action
    {
        //action name is programming specific, display name will be generated at runtime based on language selected

        
        public int ID = -1;
        public string actionName;
        public bool displayInActionPanel;
        public bool displayInRadialMenu;
        public bool displayNotification;
        public string hotkeyType = "";
        public string hotKey = "";
        public List<string> parameters;

        //This routine is going to be the onclick event. string quickActionWheelParameter is for the quick action wheel menu only, its meant to integrate actions with quick action wheel menu easily
        //only a few will use this though
        public virtual void OnActivate(string quickActionWheelParameter = "") { }

        public void DisplayNotification(string title, string message)
        {
            if (displayNotification == true)
            {
                Notification_Management.Instance.TaskbarNotification(title + ": " + message);
            }
        }

        public virtual bool UsableOnDevice() { return true; }
       
    }




    public class DefaultActionItemDictionary: Dictionary<string, string>
    {
        //This is default action item list that is used during creating a new action item
        public DefaultActionItemDictionary()   
        {
            this.Add("Change_TDP", Application.Current.Resources["Action_Change_TDP"].ToString());
            this.Add("Cycle_TDP", Application.Current.Resources["Action_Cycle_TDP"].ToString());
            this.Add("Cycle_EPP", Application.Current.Resources["Action_Cycle_EPP"].ToString());
            this.Add("Cycle_Volume", Application.Current.Resources["Action_Cycle_Volume"].ToString());
            this.Add("Toggle_Wifi", Application.Current.Resources["Action_Toggle_Wifi"].ToString());
            this.Add("Toggle_WifiAP", Application.Current.Resources["Action_Toggle_WifiAP"].ToString());
            this.Add("Toggle_IntegerScaling", Application.Current.Resources["Action_Toggle_IntegerScaling"].ToString());
            this.Add("Toggle_MicrophoneMute", Application.Current.Resources["Action_Toggle_MicrophoneMute"].ToString());
            this.Add("Toggle_VolumeMute", Application.Current.Resources["Action_Toggle_VolumeMute"].ToString());
            this.Add("Toggle_BT", Application.Current.Resources["Action_Toggle_BT"].ToString());
            this.Add("Toggle_Controller", Application.Current.Resources["Action_Toggle_Controller"].ToString());
            this.Add("Toggle_WinOSK", Application.Current.Resources["Action_Toggle_WinOSK"].ToString());
            this.Add("Toggle_OSK", Application.Current.Resources["Action_Toggle_OSK"].ToString());
            this.Add("Toggle_Desktop", Application.Current.Resources["Action_Toggle_Desktop"].ToString());
            this.Add("Toggle_WindowManager", Application.Current.Resources["Action_Toggle_WindowManager"].ToString());
            this.Add("Toggle_QuickActionWheel", Application.Current.Resources["Action_Toggle_QuickActionWheel"].ToString());
            this.Add("Toggle_QAM", Application.Current.Resources["Action_Toggle_QAM"].ToString());
            this.Add("Toggle_MouseMode", Application.Current.Resources["Action_Toggle_MouseMode"].ToString());
            this.Add("Toggle_Guide", Application.Current.Resources["Action_Toggle_Guide"].ToString());
            this.Add("Toggle_FreeSync", Application.Current.Resources["Action_Toggle_FreeSync"].ToString());
            this.Add("Open_SteamBP", Application.Current.Resources["Action_Open_SteamBP"].ToString());


            //new DefaultActionItem() { actionName = "Auto_TDP", displayName = "" };


            //new DefaultActionItem() { actionName = "Open_Steam_Big_Picture", displayName = "" };
            //new DefaultActionItem() { actionName = "Open_Playnite", displayName = "" };
            //new DefaultActionItem() { actionName = "Change_Brightness", displayName = "" };
            //new DefaultActionItem() { actionName = "Cycle_Brightness", displayName = "" };
            //new DefaultActionItem() { actionName = "Change_Volume", displayName = "" };
            //new DefaultActionItem() { actionName = "Cycle_Volume", displayName = "" };
            //new DefaultActionItem() { actionName = "Show_Desktop", displayName = "" };
            //new DefaultActionItem() { actionName = "Toggle_AMD_RSR", displayName = "" };
            //new DefaultActionItem() { actionName = "Cycle_Resolution_Mode", displayName = "" };
            //new DefaultActionItem() { actionName = "Cycle_Refresh_Mode", displayName = "" };

        }
    }

   
  

}
