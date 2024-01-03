﻿using Everything_Handhelds_Tool.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace Everything_Handhelds_Tool.UserControls.ActionWrapPanelUserControls
{
    public partial class ActionUserControl_Toggle_MicrophoneMute : ActionUserControl_DefaultHandler
    {
        public ActionUserControl_Toggle_MicrophoneMute(Classes.Actions.Action newAction) : base(newAction)
        {
        }

        public override void ConfigureControls(TextBlock textBlock, TextBlock textBlock2, SymbolIcon symbolIcon, SymbolIcon symbolIconDisabled)
        {
            symbolIcon.Symbol = Wpf.Ui.Common.SymbolRegular.Mic24;
            textBlock2.Text = Application.Current.Resources["Action_Toggle_MicrophoneMute"].ToString();



            MainWindow mW = Local_Object.Instance.GetMainWindow();

            if (Volume_Management.Instance.ReadAndReturnMicrophoneMute() == true)
            {
                symbolIconDisabled.Visibility = Visibility.Visible;
                textBlock.Text = Application.Current.Resources["ActionUserControl_Disabled"].ToString();
            }
            else
            {
                symbolIconDisabled.Visibility = Visibility.Hidden;
                textBlock.Text = Application.Current.Resources["ActionUserControl_Enabled"].ToString();
            }

        }
        public override void ButtonPress(TextBlock textBlock, TextBlock textBlock2, SymbolIcon symbolIcon, SymbolIcon symbolIconDisabled) 
        {
            action.OnActivate();
            if (symbolIconDisabled.Visibility == Visibility.Visible)
            {
                symbolIconDisabled.Visibility = Visibility.Hidden;
                textBlock.Text = Application.Current.Resources["ActionUserControl_Enabled"].ToString();
            }
            else
            {
                symbolIconDisabled.Visibility = Visibility.Visible;
                textBlock.Text = Application.Current.Resources["ActionUserControl_Disabled"].ToString();
            }
        }


    }
}