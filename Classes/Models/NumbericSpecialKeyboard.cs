﻿using Handheld_Hardware_Tools.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handheld_Hardware_Tools.Classes.Models
{
    public class NumericSpecialKeyboard : Keyboard
    {
        
        public NumericSpecialKeyboard() 
        {
            leftKeyboard = leftKeyboardLowerAlpha;
            rightKeyboard = rightKeyboardLowerAlpha;
        }

        private Dictionary<int, VirtualKeyCodeDisplayCharacter> leftKeyboardLowerAlpha = new Dictionary<int, VirtualKeyCodeDisplayCharacter>()
        {
            {0, new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_G, DisplayCharacter="g"}}, 
            {1,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_T, DisplayCharacter="t"}},
            {2,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_3, DisplayCharacter="3"}},
            {3,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_2, DisplayCharacter="2"}},
            {4,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_1, DisplayCharacter="1"}},
            {5,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_Q, DisplayCharacter="q"}},
            {6,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_A, DisplayCharacter="a"}},
            {7,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_Z, DisplayCharacter="z"}},
            {8,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_7, DisplayCharacter="7"}},
            {9,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_8, DisplayCharacter="8"}},
            {10,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_9, DisplayCharacter="9"}},
            {11,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_B, DisplayCharacter="b"}},
            {12,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_5, DisplayCharacter="5"}},
            {13,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_4, DisplayCharacter="4"}},
            {14,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_6, DisplayCharacter="6"}},
        
        };
        private Dictionary<int, VirtualKeyCodeDisplayCharacter> rightKeyboardLowerAlpha = new Dictionary<int, VirtualKeyCodeDisplayCharacter>()
        {
            {0, new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_G, DisplayCharacter=";"}},
            {1,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_P, DisplayCharacter="p"}},
            {2,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_O, DisplayCharacter="o"}},
            {3,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_I, DisplayCharacter="i"}},
            {4,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_U, DisplayCharacter="u"}},
            {5,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_Y, DisplayCharacter="y"}},
            {6,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_H, DisplayCharacter="h"}},
            {7,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_N, DisplayCharacter="n"}},
            {8,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_M, DisplayCharacter="m"}},
            {9,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.OEM_COMMA, DisplayCharacter=","}},
            {10,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.OEM_PERIOD, DisplayCharacter="."}},
            {11,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.SPACE, DisplayCharacter="?"}},
            {12,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_K, DisplayCharacter="k"}},
            {13,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_J, DisplayCharacter="j"}},
            {14,new VirtualKeyCodeDisplayCharacter{vkc = WindowsInput.Native.VirtualKeyCode.VK_L, DisplayCharacter="l"}},

        };
      

    }
}
