﻿using Handheld_Hardware_Tools.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace Handheld_Hardware_Tools.UserControls.ActionWrapPanelUserControls
{
    public partial class ActionUserControl_Toggle_OSK : ActionUserControl_DefaultHandler
    {
        public ActionUserControl_Toggle_OSK(Classes.Actions.Action newAction) : base(newAction)
        {
        }

        public override void ConfigureControls(TextBlock textBlock, TextBlock textBlock2, SymbolIcon symbolIcon, SymbolIcon symbolIconDisabled, Grid iconGrid, FontAwesome.WPF.FontAwesome faIcon)
        {
            symbolIcon.Symbol = Wpf.Ui.Common.SymbolRegular.Keyboard24;
            textBlock2.Text = Application.Current.Resources["Action_Toggle_OSK"].ToString();

            textBlock.Text = "";

            iconGrid.HorizontalAlignment = HorizontalAlignment.Center;


        }
        public override void ButtonPress(TextBlock textBlock, TextBlock textBlock2, SymbolIcon symbolIcon, SymbolIcon symbolIconDisabled) 
        {
            action.OnActivate();
           
        }


    }
}
