﻿using Handheld_Hardware_Tools.Classes.Profiles.ProfileActions.ProfileActionClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.ApplicationModel.Store;

namespace Handheld_Hardware_Tools.Classes.Actions.ActionClass
{
    public class Cycle_TDP : Action
    {
        public Cycle_TDP()
        {
            actionName = "Cycle_TDP";
            parameters = new List<string>();
        }
        public override void OnActivate(string quickActionWheelParameter="")
        {
            if (parameters.Count > 0)
            {
                int intTDP = TDP_Management.Instance.ReadAndReturnSustainedTDP();
                
                if (quickActionWheelParameter == "")
                {
                    string strTDP = intTDP.ToString();

                    int index = parameters.IndexOf(strTDP);
                    //if the index is -1 that means it doesnt exist, start at the first tdp in the list
                    //if the index+1 = count that means we are at the end of the list and we need to go back to 0
                    if (index == -1 || index + 1 == parameters.Count)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = index + 1;
                    }

                    int.TryParse(parameters[index], out intTDP);

                    TDP_Management.Instance.ChangeSustainedBoostTDP(intTDP, intTDP);

                    
                }
                else
                {//this is for quick action wheel only
                    quickActionWheelParameter = quickActionWheelParameter.Replace(" W", "");

                    if (int.TryParse(quickActionWheelParameter, out intTDP))
                    {
                        TDP_Management.Instance.ChangeSustainedBoostTDP(intTDP, intTDP);
                    }
                }

                if (displayNotification)
                {
                    //displaynotification
                    DisplayNotification(Application.Current.Resources["Action_" + actionName].ToString(), (intTDP).ToString() + " W");
                }
                

            }
        }
    }
}
