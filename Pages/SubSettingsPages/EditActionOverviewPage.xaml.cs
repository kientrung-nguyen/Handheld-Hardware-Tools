﻿
using Everything_Handhelds_Tool.Classes;
using Everything_Handhelds_Tool.Classes.Actions;
using Everything_Handhelds_Tool.Classes.Actions.ActionClass;
using Everything_Handhelds_Tool.Classes.Controller_Object_Classes;
using Everything_Handhelds_Tool.Classes.Models;
using Everything_Handhelds_Tool.UserControls.ActionOverviewUserControls;
using Everything_Handhelds_Tool.UserControls.HomePageUserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Everything_Handhelds_Tool.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class EditActionOverviewPage : ControllerPage
    {

        public EditActionOverviewPage(Classes.Actions.Action? action = null)
        {
            //Move initilize components to sub routine and async it to make pages feel smoother
            Dispatcher.BeginInvoke(new System.Action(() => InitializeActions(action)));

         
        }

      

        private void InitializeActions(Classes.Actions.Action? action = null)
        {
            InitializeComponent();
            virtualStackPanel = stackPanel;
            AddControlsToArray(action);

          
        }

        private void ReBaseIDsInActionList()
        {
            int index = 0;
            foreach (object child in stackPanel.Children)
            {
                if (child is ActionOverview_UserControl)
                {
                    ActionOverview_UserControl actionOverview_UserControl = (ActionOverview_UserControl)child;
                    actionOverview_UserControl.action.ID= index;
                    index++;
                }
            }

        }


       
        private void AddControlsToArray(Classes.Actions.Action? saveAction = null)
        {
            ActionList actions = (ActionList)XML_Management.Instance.LoadXML("ActionList");

            if (saveAction != null)
            {
                if (saveAction.ID == -1)
                {
                    //new action is -1, so if its -1 count it as new and make the new index = count - 1
                    saveAction.ID = actions.Count - 1;
                    actions.Add(saveAction);
                }
                else
                {
                    actions[saveAction.ID] = saveAction;
                }
                actions.SaveToXML();
            }


            foreach (Classes.Actions.Action action in actions)
            {
                UserControl userControl = new ActionOverview_UserControl(action);
                stackPanel.Children.Add(userControl);
                userControls.Add((ControllerUserControl)userControl);
            }

           

        }

        private void SaveActionList()
        {
            //grabs all the actions from each control and then saves them to the XML
            ActionList actions = new ActionList();

            foreach (object child in stackPanel.Children)
            {
                if (child != null)
                {
                    ActionOverview_UserControl editAction_UserControl = (ActionOverview_UserControl)child;
                    actions.Add(editAction_UserControl.action);
                }
            }

            actions.SaveToXML();

        }

        public void HandleUserControlInputs(UserControl userControl, string action)
        {
            int ucIndex = stackPanel.Children.IndexOf(userControl);
            if (ucIndex >= 0)
            {
                switch(action)
                {
                    case "Delete":
                        stackPanel.Children.Remove(userControl);
                        userControls.Remove((ControllerUserControl)userControl);
                        highlightedUserControl = -1;
                        ReturnControlToPage();
                        break;

                    case "MoveUp":
                        if (ucIndex > 0)
                        {
                            if (ucIndex == highlightedUserControl)
                            {
                                highlightedUserControl = ucIndex - 1;
                            }

                            stackPanel.Children.Remove(userControl);
                            stackPanel.Children.Insert(ucIndex-1,userControl);

                            userControls.Remove((ControllerUserControl)userControl);
                            userControls.Insert(ucIndex-1, (ControllerUserControl)userControl);

                            
                        }

                        break;
                    case "Edit":
                        ActionOverview_UserControl actionOverview_UserControl = (ActionOverview_UserControl)userControl;
                        System.Windows.Controls.Page page = new EditActionPage(actionOverview_UserControl.action);

                        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow.frame.Content = page;

                        break;
                    case "MoveDown":
                        if (ucIndex < userControls.Count-1)
                        {
                            if (ucIndex == highlightedUserControl)
                            {
                                highlightedUserControl = ucIndex + 1;
                            }

                            stackPanel.Children.Remove(userControl);
                            stackPanel.Children.Insert(ucIndex + 1, userControl);

                            userControls.Remove((ControllerUserControl)userControl);
                            userControls.Insert(ucIndex + 1, (ControllerUserControl)userControl);


                        }

                        break;

                }


            }
        }

        private void newAction_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Controls.Page page = new EditActionPage();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.frame.Content = page;
        }

        private void ControllerPage_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveActionList();
        }
    }
}
