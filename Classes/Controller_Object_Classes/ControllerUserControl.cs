﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Wpf.Ui.Controls;

namespace Everything_Handhelds_Tool.Classes.Controller_Object_Classes
{
    public class ControllerUserControl : UserControl
    {
        public Object borderControl;
        public Object mainControl;
        public Object toggleSwitchControl;

      
        public virtual void ControlChangeValueHandler() { }

        public virtual void ChangeMainWindowControllerInstructionPage() { }
        public virtual void HighlightControl() 
        { 
            if (borderControl != null) 
            {
                if (borderControl is Wpf.Ui.Controls.Card)
                {
                    Card card = (Card)borderControl;
                    card.BorderBrush = System.Windows.Media.Brushes.Gray;
                }
                if (borderControl is Wpf.Ui.Controls.CardExpander)
                {
                    CardExpander card = (CardExpander)borderControl;
                    card.BorderBrush = System.Windows.Media.Brushes.Gray;
                }
            }
        }
        public virtual void SelectControl()
        {
            if (borderControl != null)
            {
                if (borderControl is Wpf.Ui.Controls.Card)
                {
                    Card card = (Card)borderControl;
                    card.BorderBrush = System.Windows.Media.Brushes.White;
                }
                if (borderControl is Wpf.Ui.Controls.CardExpander)
                {
                    CardExpander card = (CardExpander)borderControl;
                    card.BorderBrush = System.Windows.Media.Brushes.White;
                }
                ChangeMainWindowControllerInstructionPage();
            }
        }
        public virtual void UnhighlightControl() 
        {
            if (borderControl != null)
            {
                if (borderControl is Wpf.Ui.Controls.Card)
                {
                    Card card = (Card)borderControl;
                    card.BorderBrush = System.Windows.Media.Brushes.Transparent;
                }
                if (borderControl is Wpf.Ui.Controls.CardExpander)
                {
                    CardExpander card = (CardExpander)borderControl;
                    card.BorderBrush = System.Windows.Media.Brushes.Transparent;
                }
            }
        }
        public void ReturnControlToPage() 
        {
            HighlightControl();
            MainWindow wnd = (MainWindow)Application.Current.MainWindow;
            ControllerPage controllerPage = wnd.frame.Content as ControllerPage;
            controllerPage.ReturnControlToPage();
            
        }


        #region handling controller input
        public virtual void HandleControllerInput(string action)
        {
            if (mainControl != null)
            {
                if (action == "B")
                {
                    ReturnControlToPage();
                }

                if (toggleSwitchControl != null)
                {
                    ToggleSwitch tS = toggleSwitchControl as ToggleSwitch;
                    if (tS.IsChecked == true)
                    {
                        MainControlInputHandlerSwitchBoard(action);
                    }
                }
                else 
                {
                    MainControlInputHandlerSwitchBoard(action);
                }
            }
        }
        private void MainControlInputHandlerSwitchBoard(string action)
        {
            if (mainControl is Slider) { HandleSliderInput(action); }
        }
        private void HandleSliderInput(string action)
        {
            Slider slider = mainControl as Slider;
            switch (action)
            {
                case "DPadRight":
                    slider.Value = slider.Value + slider.Interval;
                    break;
                case "DPadLeft":
                    slider.Value = slider.Value - slider.Interval;
                    break;
                case "A":
                    ControlChangeValueHandler();
                    break;
                case "B":
                    ControlChangeValueHandler();
                    break;

                default: break;
            }
        }
        #endregion
    }
}
