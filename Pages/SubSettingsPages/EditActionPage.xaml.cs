﻿
using Everything_Handhelds_Tool.Classes;
using Everything_Handhelds_Tool.Classes.Actions;
using Everything_Handhelds_Tool.Classes.Actions.ActionClass;
using Everything_Handhelds_Tool.Classes.Controller_Object_Classes;
using Everything_Handhelds_Tool.Classes.Models;
using Everything_Handhelds_Tool.UserControls.ActionOverviewUserControls;
using Everything_Handhelds_Tool.UserControls.EditActionUserControls;
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
    public partial class EditActionPage : ControllerPage
    {
        public Classes.Actions.Action action;
        public EditAction_Combobox actionCombobox;
        public EditAction_ArgumentListView actionArgumentListView;
        public EditAction_EnableHotKey actionEnableHotKey;


        public bool updateControllerHotKeyDictionary = false;
        public bool updateKBHotKeyDictionary = false;
        //bool to determine if existing or new action
        private bool newAction = true;
        public EditActionPage(Classes.Actions.Action importAction = null)
        {
            //Move initilize components to sub routine and async it to make pages feel smoother
            Dispatcher.BeginInvoke(new System.Action(() => InitializeActions(importAction)));

         
        }

      

        private void InitializeActions(Classes.Actions.Action? importAction = null)
        {
            //needs to set action first, because controls generated during InitializeComponent rely on this value
            if (importAction != null)
            {
                action = importAction;
                newAction = false;
            }

            InitializeComponent();
            virtualStackPanel = stackPanel;
            AddControlsToArray();
            SetPageDefaultInstruction();
        }
        public override void SetPageDefaultInstruction()
        {
            //EDITACTION PAGE IS SPECIAL BECAUSE IT DOESNST GET THE USUAL CONTROLLER INSTRUCIONT OF SELECT BACK. TYPICALLY THIS IS HANDLED AT THE GENERIC CLASS LEVEL BUT I HAVE THE ADD SAVE BUTTON
            //AND I NEED TO MAKE A SPECIAL INSRUCTION FOR THIS ONE. SO I WILL OVERRIDE THE GENERIC PAGE CLASS RETURNCONTROLTOPAGE and i have to add the instruction at init too so thats the first thing that shows up

            General_Functions.ChangeControllerInstructionPage("SelectSaveBack");
        }

        public override void HandleControllerInput(string action)
        {
            base.HandleControllerInput(action);

            if (action == "Start" && controllerNavigatePage)
            {
                SaveActionToXML();
            }


        }

        private void AddControlsToArray()
        {
            //There is a general function that searches the stack panel and adds to the list of ControllerUserControls. It makes sure
            //visibility isn't collapsed too

            //add controls passing values as needed
            if (action != null) 
            {
                actionCombobox = new EditAction_Combobox(action.actionName);
                stackPanel.Children.Add(actionCombobox);
                actionArgumentListView = new EditAction_ArgumentListView(action);
                stackPanel.Children.Add(actionArgumentListView);

                
                stackPanel.Children.Add(new EditAction_InActionPanelToggleSwitch(action.displayInActionPanel));

                stackPanel.Children.Add(new EditAction_EnableHotKey(action.hotKey, action.hotkeyType));
            }
            else 
            {
                actionCombobox = new EditAction_Combobox();
                stackPanel.Children.Add(actionCombobox);
                actionArgumentListView = new EditAction_ArgumentListView();
                stackPanel.Children.Add(actionArgumentListView);
                stackPanel.Children.Add(new EditAction_InActionPanelToggleSwitch());

                stackPanel.Children.Add(new EditAction_EnableHotKey());
            }


            RebaseUserControlsAfterActionTypeUpdate();
        }

        public void RebaseUserControlsAfterActionTypeUpdate()
        {
            //this routine is going to update the UserControls array, so when an action doesnt need
            //a argument list, it will be collapsed, and controller input won't accidentally pick it up
            userControls = General_Functions.SearchStackPanelReturnArray(stackPanel);


        }


        private void SaveActionToEditOverviewPage()
        {
            //gets the overview page, sends to the frame on the mainwindow, passes the action to the page so it will add it and then save
            EditActionOverviewPage editActionOverviewPage = new EditActionOverviewPage(action);
            
            //get mainwindow frame
            MainWindow mainWindow = Local_Object.Instance.GetMainWindow();
            mainWindow.frame.Content = editActionOverviewPage;

            if (updateControllerHotKeyDictionary)
            {
                mainWindow.controllerInput.publicSuspendEventsForNewHotKeyList = true;
            }
            if (updateKBHotKeyDictionary)
            {
                MessageBox.Show("ADD KEYBOARD HANDLER HERE TO UPDATE KB DICTIONARY EditActionPage.xaml.cs");
            }
        }

        private void ValidateInputs()
        {

        }
        private void save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveActionToXML();
        }

        private void SaveActionToXML()
        {
            //on save we need to make sure everything is good by calling validate inputs
            //THEN save the action by sending to the overview page with action argument, and the editoverview page will handle the saving
            ValidateInputs();
            SaveActionToEditOverviewPage();
        }

        public override void PressBPageHandler()
        {
            //override base function to send you back to general settings page
            System.Windows.Controls.Page page = new EditActionOverviewPage();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.frame.Content = page;
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PressBPageHandler();
        }
    }
}
