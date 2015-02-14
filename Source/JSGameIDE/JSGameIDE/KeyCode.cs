/*
    <JSGameIDE - An open-source IDE+Library to Javascript Game Development>
    Copyright (C) 2015  Patrick Pissurno

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, version 3, except for commercial usage,
    which is strictly FORBIDDEN.
   
    COMMERCIAL USAGE IS STRICTLY FORBIDDEN!
    
    If you're going to distribute a version of this program you need to
    keep this commentary in all the classes of it, and also you  should
    mantain it open source and under the same  terms  of  the  original
    version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See  the
    GNU General Public License for more details.

    You should have received a copy of  the  GNU  General Public  License
    along with this program.  If  not, see <http://www.gnu.org/licenses/>.
  
    For further  details see: http://patrickpissurno.github.io/JSGameIDE/
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSGameIDE
{
    public static class KeyCode
    {
        //A dictionary containing all the available KeyCodes
        public static Dictionary<string, int> keyCodes = new Dictionary<string, int>()
        {
            {"vk_backspace",8},
            {"vk_tab",9},
            {"vk_enter",13},
            {"vk_shift",16},
            {"vk_ctrl",17},
            {"vk_caps",20},
            {"vk_escape",27},
            {"vk_space",32},
            {"vk_left",37},
            {"vk_up",38},
            {"vk_right",39},
            {"vk_down",40},
            {"vk_delete",46},
            {"vk_0",48},
            {"vk_1",49},
            {"vk_2",50},
            {"vk_3",51},
            {"vk_4",52},
            {"vk_5",53},
            {"vk_6",54},
            {"vk_7",55},
            {"vk_8",56},
            {"vk_9",57},
            {"vk_a",65},
            {"vk_b",66},
            {"vk_c",67},
            {"vk_d",68},
            {"vk_e",69},
            {"vk_f",70},
            {"vk_g",71},
            {"vk_h",72},
            {"vk_i",73},
            {"vk_j",74},
            {"vk_k",75},
            {"vk_l",76},
            {"vk_m",77},
            {"vk_n",78},
            {"vk_o",79},
            {"vk_p",80},
            {"vk_q",81},
            {"vk_r",82},
            {"vk_s",83},
            {"vk_t",84},
            {"vk_u",85},
            {"vk_v",86},
            {"vk_w",87},
            {"vk_x",88},
            {"vk_y",89},
            {"vk_z",90},
            {"vk_numpad0",96},
            {"vk_numpad1",97},
            {"vk_numpad2",98},
            {"vk_numpad3",99},
            {"vk_numpad4",100},
            {"vk_numpad5",101},
            {"vk_numpad6",102},
            {"vk_numpad7",103},
            {"vk_numpad8",104},
            {"vk_numpad9",105}
        };
    }
}
