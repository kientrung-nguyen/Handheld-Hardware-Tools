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
    public partial class ActionUserControl_Toggle_IntegerScaling : ActionUserControl_DefaultHandler
    {
        public ActionUserControl_Toggle_IntegerScaling(Classes.Actions.Action newAction) : base(newAction)
        {
        }

        public override void ConfigureControls(TextBlock textBlock, TextBlock textBlock2, SymbolIcon symbolIcon, SymbolIcon symbolIconDisabled)
        {
            symbolIcon.Symbol = Wpf.Ui.Common.SymbolRegular.Blur20;
            textBlock2.Text = Application.Current.Resources["Action_Toggle_IntegerScaling"].ToString();



            if (!ADLX_Management.HasIntegerScalingSupport())
            {
                System.Windows.MessageBox.Show("ActionUserControl_Toggle_IntegerScaling.cs   NEED TO FIGURE OUT HOW TO HANDLE INTERGER SCALING FOR THIS ACTION PANEL");
            }


            if (ADLX_Management.HasIntegerScalingSupport())
            {
                if (ADLX_Management.IsIntegerScalingEnabled())
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
            else
            {
                

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
