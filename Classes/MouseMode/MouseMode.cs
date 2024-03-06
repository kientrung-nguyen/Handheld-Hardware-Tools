﻿using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Everything_Handhelds_Tool.Classes.MouseMode
{
    public class MouseMode
    {
        MouseProfile mouseProfile = new MouseProfile();
        InputSimulator inputSimulator = Local_Object.Instance.GetMainWindowInputSimulator();
        public MouseMode()
        {
            SubscribeControllerEvents();
        }
        public void SubscribeControllerEvents()
        {
            ControllerInput controllerInput = Local_Object.Instance.GetMainWindowControllerInput();
            if (controllerInput != null )
            {
                controllerInput.joystickEvent.controllerJoystickEvent += JoystickEvent_controllerJoystickEvent;
                controllerInput.buttonPressEvent.controllerInputEvent += ButtonPressEvent_controllerInputEvent;
            }
        }

        private void ButtonPressEvent_controllerInputEvent(object? sender, controllerInputEventArgs e)
        {
            //this clip of code checks if any of the windows are visible, the ! makes it so its only true when none of the windows are visislbe
            //this is what i want for mousemode, only work when the user enables it AND no windows are open, otherwise controller input takes over
            if (!System.Windows.Application.Current.Windows.Cast<System.Windows.Window>().Any(x => x.Visibility == Visibility.Visible))
            {
                if (mouseProfile.mouseActionList.ContainsKey(e.Action))
                {
                    Classes.MouseMode.Actions.MouseAction mouseAction = mouseProfile.mouseActionList[e.Action];
                    if (mouseAction != null)
                    {
                        mouseAction.ClickEvent();
                    }
                }

               
            }

           
        }

        private void JoystickEvent_controllerJoystickEvent(object? sender, controllerJoystickEventArgs e)
        {
            //handle mouse movement and scroll from joysticks

            //this clip of code checks if any of the windows are visible, the ! makes it so its only true when none of the windows are visislbe
            //this is what i want for mousemode, only work when the user enables it AND no windows are open, otherwise controller input takes over
            if (!System.Windows.Application.Current.Windows.Cast<System.Windows.Window>().Any(x => x.Visibility == Visibility.Visible))
            {
                HandleMouseMovement(e);
                

            }
        }
        private void HandleMouseMovement(controllerJoystickEventArgs e)
        {
            int xValue = 0;
            int yValue = 0;
            if (mouseProfile.rightScroll)
            {
                xValue = ApplyCurveAndSensitivityFactor(NormalizeJoystickInput(e.lx, mouseProfile.deadZone), mouseProfile.xValues, mouseProfile.yValues, mouseProfile.sensitivityValue);
                yValue = ApplyCurveAndSensitivityFactor(NormalizeJoystickInput(e.ly, mouseProfile.deadZone), mouseProfile.xValues, mouseProfile.yValues, mouseProfile.sensitivityValue);
                
            }
            else
            {
                xValue = ApplyCurveAndSensitivityFactor(NormalizeJoystickInput(e.rx, mouseProfile.deadZone), mouseProfile.xValues, mouseProfile.yValues, mouseProfile.sensitivityValue);
                yValue = ApplyCurveAndSensitivityFactor(NormalizeJoystickInput(e.ry, mouseProfile.deadZone), mouseProfile.xValues, mouseProfile.yValues, mouseProfile.sensitivityValue);

            }

            //apply negative to yvalue because controller Y axis is reversed from typical coordinate plane
            inputSimulator.Mouse.MoveMouseBy((int)xValue, (int)-yValue);
        }

        private double NormalizeJoystickInput(double value, double deadZone)
        {
            //handles the normalizing, so taking the -32768 to 32767 range and making it -100 to 100  (percentage without the 100 division yet
            double normalizeDeadZone = (deadZone * 32768) / 100;

            if (Math.Abs(value) > normalizeDeadZone)
            {
                return Math.Round(value / 32768, 3) * 100;
            }
            else { return 0; }
         
        }

        private int ApplyCurveAndSensitivityFactor(double value, double[] xValueArray, double[]yValueArray, double sensitivityFactor)
        {
            int firstIndex = 0;
            int secondIndex = 1;
            //I want to take a linear approximation between x and y values so the mouse repsonse isnt jittery when moving along the curve. This
            //basically turns the 10 data points from step functions to a curve made of 10 straight lines
            for (int i = 0; i < xValueArray.Length; i++)
            {
                if (Math.Abs(value) <= xValueArray[i])
                {
                    secondIndex = i;
                    break;
                }
            }
            //if second index never makes it to 1, then our window is 0 to 1 index so lets account for that here
            if (secondIndex == 0)
            {
                secondIndex = 1;
            }
            else
            {
                firstIndex = secondIndex - 1;
            }

            //DONT FORGET DIVIDE 100 BECAUSE I NEVER CONVERTED TO PERCENTAGE
            double result = (sensitivityFactor/100) * LinearInterpolation(xValueArray[firstIndex] / 100, yValueArray[firstIndex] / 100, xValueArray[secondIndex] / 100, yValueArray[secondIndex] / 100, value);

            return (int)Math.Round(result ,0);



        }

        private double LinearInterpolation(double x1, double y1, double x2, double y2, double x)
        {
           
            // Calculate the slope (m) of the line
            double m = (y2 - y1) / (x2 - x1);


            // Calculate the y value using linear interpolation
            double y = y1 + m * (x - x1);

            return y;
        }

        public void UnsubscribeControllerEvents() 
        {
            ControllerInput controllerInput = Local_Object.Instance.GetMainWindowControllerInput();
            if (controllerInput != null)
            {
                controllerInput.joystickEvent.controllerJoystickEvent -= JoystickEvent_controllerJoystickEvent;
                controllerInput.buttonPressEvent.controllerInputEvent -= ButtonPressEvent_controllerInputEvent;
            }

        }

        private bool _updateMouseProfile { get; set; } = false;

        public bool UpdateMouseProfile
        {
            get
            {
                return _updateMouseProfile;
            }
            set
            {
                _updateMouseProfile = value;
            }
        }

    }
}
