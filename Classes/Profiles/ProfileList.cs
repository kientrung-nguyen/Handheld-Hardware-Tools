﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handheld_Hardware_Tools.Classes.Profiles
{
    public class ProfileList : List<Profile>
    {


        public void SaveToXML()
        {
            XML_Management.Instance.SaveXML("ProfileList", this);
        }
        public Dictionary<string, Profile> ReturnProcessExeDictionary()
        {
            Dictionary<string, Profile> profileExe = new Dictionary<string, Profile>();

            List<Profile> list = this.Where(p => p.processExe != "").ToList();

            foreach (Profile profile in list)
            {
                profileExe.Add(profile.processExe, profile);
            }

            return profileExe;
        }
    }
}
