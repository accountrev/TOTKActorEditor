using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ImGuiNET;
using NAudio.Wave;
using Newtonsoft.Json;
using ClickableTransparentOverlay;


namespace TOTKActorEditorCS
{
    public class Program : Overlay
    {
        public static Dictionary<ActorNames, Dictionary<int, KeyValuePair<int,bool>>> addresses = new Dictionary<ActorNames, Dictionary<int, KeyValuePair<int, bool>>>()
        {
            {ActorNames.SWORD, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0xc3b94, false)}, {1, new KeyValuePair<int, bool>(0xc3bd4, false)}, {2, new KeyValuePair<int, bool>(0xc3c14, false)}, {3, new KeyValuePair<int, bool>(0xc3c54, false)}, {4, new KeyValuePair<int, bool>(0xc3c94, false)}, {5, new KeyValuePair<int, bool>(0xc3cd4, false)}, {6, new KeyValuePair<int, bool>(0xc3d14, false)}, {7, new KeyValuePair<int, bool>(0xc3d54, false)}, {8, new KeyValuePair<int, bool>(0xc3d94, false)}, {9, new KeyValuePair<int, bool>(0xc3dd4, false)}, {10, new KeyValuePair<int, bool>(0xc3e14, false)}, {11, new KeyValuePair<int, bool>(0xc3e54, false)}, {12, new KeyValuePair<int, bool>(0xc3e94, false)}, {13, new KeyValuePair<int, bool>(0xc3ed4, false)}, {14, new KeyValuePair<int, bool>(0xc3f14, false)}, {15, new KeyValuePair<int, bool>(0xc3f54, false)}, {16, new KeyValuePair<int, bool>(0xc3f94, false)}, {17, new KeyValuePair<int, bool>(0xc3fd4, false)}, {18, new KeyValuePair<int, bool>(0xc4014, false)}, {19, new KeyValuePair<int, bool>(0xc4054, false)}}},
            {ActorNames.SWORD_FUSE, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0xa6610, false)}, {1, new KeyValuePair<int, bool>(0xa6650, false)}, {2, new KeyValuePair<int, bool>(0xa6690, false)}, {3, new KeyValuePair<int, bool>(0xa66d0, false)}, {4, new KeyValuePair<int, bool>(0xa6710, false)}, {5, new KeyValuePair<int, bool>(0xa6750, false)}, {6, new KeyValuePair<int, bool>(0xa6790, false)}, {7, new KeyValuePair<int, bool>(0xa67d0, false)}, {8, new KeyValuePair<int, bool>(0xa6810, false)}, {9, new KeyValuePair<int, bool>(0xa6850, false)}, {10, new KeyValuePair<int, bool>(0xa6890, false)}, {11, new KeyValuePair<int, bool>(0xa68d0, false)}, {12, new KeyValuePair<int, bool>(0xa6910, false)}, {13, new KeyValuePair<int, bool>(0xa6950, false)}, {14, new KeyValuePair<int, bool>(0xa6990, false)}, {15, new KeyValuePair<int, bool>(0xa69d0, false)}, {16, new KeyValuePair<int, bool>(0xa6a10, false)}, {17, new KeyValuePair<int, bool>(0xa6a50, false)}, {18, new KeyValuePair<int, bool>(0xa6a90, false)}, {19, new KeyValuePair<int, bool>(0xa6ad0, false)}}},
            {ActorNames.SHIELD, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0x7612c, false)}, {1, new KeyValuePair<int, bool>(0x7616c, false)}, {2, new KeyValuePair<int, bool>(0x761ac, false)}, {3, new KeyValuePair<int, bool>(0x761ec, false)}, {4, new KeyValuePair<int, bool>(0x7622c, false)}, {5, new KeyValuePair<int, bool>(0x7626c, false)}, {6, new KeyValuePair<int, bool>(0x762ac, false)}, {7, new KeyValuePair<int, bool>(0x762ec, false)}, {8, new KeyValuePair<int, bool>(0x7632c, false)}, {9, new KeyValuePair<int, bool>(0x7636c, false)}, {10, new KeyValuePair<int, bool>(0x763ac, false)}, {11, new KeyValuePair<int, bool>(0x763ec, false)}, {12, new KeyValuePair<int, bool>(0x7642c, false)}, {13, new KeyValuePair<int, bool>(0x7646c, false)}, {14, new KeyValuePair<int, bool>(0x764ac, false)}, {15, new KeyValuePair<int, bool>(0x764ec, false)}, {16, new KeyValuePair<int, bool>(0x7652c, false)}, {17, new KeyValuePair<int, bool>(0x7656c, false)}, {18, new KeyValuePair<int, bool>(0x765ac, false)}, {19, new KeyValuePair<int, bool>(0x765ec, false)}}},
            {ActorNames.SHIELD_FUSE, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0xaa0b8, false)}, {1, new KeyValuePair<int, bool>(0xaa0f8, false)}, {2, new KeyValuePair<int, bool>(0xaa138, false)}, {3, new KeyValuePair<int, bool>(0xaa178, false)}, {4, new KeyValuePair<int, bool>(0xaa1b8, false)}, {5, new KeyValuePair<int, bool>(0xaa1f8, false)}, {6, new KeyValuePair<int, bool>(0xaa238, false)}, {7, new KeyValuePair<int, bool>(0xaa278, false)}, {8, new KeyValuePair<int, bool>(0xaa2b8, false)}, {9, new KeyValuePair<int, bool>(0xaa2f8, false)}, {10, new KeyValuePair<int, bool>(0xaa338, false)}, {11, new KeyValuePair<int, bool>(0xaa378, false)}, {12, new KeyValuePair<int, bool>(0xaa3b8, false)}, {13, new KeyValuePair<int, bool>(0xaa3f8, false)}, {14, new KeyValuePair<int, bool>(0xaa438, false)}, {15, new KeyValuePair<int, bool>(0xaa478, false)}, {16, new KeyValuePair<int, bool>(0xaa4b8, false)}, {17, new KeyValuePair<int, bool>(0xaa4f8, false)}, {18, new KeyValuePair<int, bool>(0xaa538, false)}, {19, new KeyValuePair<int, bool>(0xaa578, false)}}},
            {ActorNames.BOW, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0x7b520, false)}, {1, new KeyValuePair<int, bool>(0x7b560, false)}, {2, new KeyValuePair<int, bool>(0x7b5a0, false)}, {3, new KeyValuePair<int, bool>(0x7b5e0, false)}, {4, new KeyValuePair<int, bool>(0x7b620, false)}, {5, new KeyValuePair<int, bool>(0x7b660, false)}, {6, new KeyValuePair<int, bool>(0x7b6a0, false)}, {7, new KeyValuePair<int, bool>(0x7b6e0, false)}, {8, new KeyValuePair<int, bool>(0x7b720, false)}, {9, new KeyValuePair<int, bool>(0x7b760, false)}, {10, new KeyValuePair<int, bool>(0x7b7a0, false)}, {11, new KeyValuePair<int, bool>(0x7b7e0, false)}, {12, new KeyValuePair<int, bool>(0x7b820, false)}, {13, new KeyValuePair<int, bool>(0x7b860, false)}}},
            {ActorNames.ARMOR, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0x61bf8, false)}, {1, new KeyValuePair<int, bool>(0x61c38, false)}, {2, new KeyValuePair<int, bool>(0x61c78, false)}, {3, new KeyValuePair<int, bool>(0x61cb8, false)}, {4, new KeyValuePair<int, bool>(0x61cf8, false)}, {5, new KeyValuePair<int, bool>(0x61d38, false)}, {6, new KeyValuePair<int, bool>(0x61d78, false)}, {7, new KeyValuePair<int, bool>(0x61db8, false)}, {8, new KeyValuePair<int, bool>(0x61df8, false)}, {9, new KeyValuePair<int, bool>(0x61e38, false)}, {10, new KeyValuePair<int, bool>(0x61e78, false)}, {11, new KeyValuePair<int, bool>(0x61eb8, false)}, {12, new KeyValuePair<int, bool>(0x61ef8, false)}, {13, new KeyValuePair<int, bool>(0x61f38, false)}, {14, new KeyValuePair<int, bool>(0x61f78, false)}, {15, new KeyValuePair<int, bool>(0x61fb8, false)}, {16, new KeyValuePair<int, bool>(0x61ff8, false)}, {17, new KeyValuePair<int, bool>(0x62038, false)}, {18, new KeyValuePair<int, bool>(0x62078, false)}, {19, new KeyValuePair<int, bool>(0x620b8, false)}, {20, new KeyValuePair<int, bool>(0x620f8, false)}, {21, new KeyValuePair<int, bool>(0x62138, false)}, {22, new KeyValuePair<int, bool>(0x62178, false)}, {23, new KeyValuePair<int, bool>(0x621b8, false)}, {24, new KeyValuePair<int, bool>(0x621f8, false)}, {25, new KeyValuePair<int, bool>(0x62238, false)}, {26, new KeyValuePair<int, bool>(0x62278, false)}, {27, new KeyValuePair<int, bool>(0x622b8, false)}, {28, new KeyValuePair<int, bool>(0x622f8, false)}, {29, new KeyValuePair<int, bool>(0x62338, false)}, {30, new KeyValuePair<int, bool>(0x62378, false)}, {31, new KeyValuePair<int, bool>(0x623b8, false)}, {32, new KeyValuePair<int, bool>(0x623f8, false)}, {33, new KeyValuePair<int, bool>(0x62438, false)}, {34, new KeyValuePair<int, bool>(0x62478, false)}, {35, new KeyValuePair<int, bool>(0x624b8, false)}, {36, new KeyValuePair<int, bool>(0x624f8, false)}, {37, new KeyValuePair<int, bool>(0x62538, false)}, {38, new KeyValuePair<int, bool>(0x62578, false)}, {39, new KeyValuePair<int, bool>(0x625b8, false)}, {40, new KeyValuePair<int, bool>(0x625f8, false)}, {41, new KeyValuePair<int, bool>(0x62638, false)}, {42, new KeyValuePair<int, bool>(0x62678, false)}, {43, new KeyValuePair<int, bool>(0x626b8, false)}, {44, new KeyValuePair<int, bool>(0x626f8, false)}, {45, new KeyValuePair<int, bool>(0x62738, false)}, {46, new KeyValuePair<int, bool>(0x62778, false)}, {47, new KeyValuePair<int, bool>(0x627b8, false)}, {48, new KeyValuePair<int, bool>(0x627f8, false)}, {49, new KeyValuePair<int, bool>(0x62838, false)}, {50, new KeyValuePair<int, bool>(0x62878, false)}, {51, new KeyValuePair<int, bool>(0x628b8, false)}, {52, new KeyValuePair<int, bool>(0x628f8, false)}, {53, new KeyValuePair<int, bool>(0x62938, false)}, {54, new KeyValuePair<int, bool>(0x62978, false)}, {55, new KeyValuePair<int, bool>(0x629b8, false)}, {56, new KeyValuePair<int, bool>(0x629f8, false)}, {57, new KeyValuePair<int, bool>(0x62a38, false)}, {58, new KeyValuePair<int, bool>(0x62a78, false)}, {59, new KeyValuePair<int, bool>(0x62ab8, false)}, {60, new KeyValuePair<int, bool>(0x62af8, false)}, {61, new KeyValuePair<int, bool>(0x62b38, false)}, {62, new KeyValuePair<int, bool>(0x62b78, false)}, {63, new KeyValuePair<int, bool>(0x62bb8, false)}, {64, new KeyValuePair<int, bool>(0x62bf8, false)}, {65, new KeyValuePair<int, bool>(0x62c38, false)}, {66, new KeyValuePair<int, bool>(0x62c78, false)}, {67, new KeyValuePair<int, bool>(0x62cb8, false)}, {68, new KeyValuePair<int, bool>(0x62cf8, false)}, {69, new KeyValuePair<int, bool>(0x62d38, false)}, {70, new KeyValuePair<int, bool>(0x62d78, false)}, {71, new KeyValuePair<int, bool>(0x62db8, false)}, {72, new KeyValuePair<int, bool>(0x62df8, false)}, {73, new KeyValuePair<int, bool>(0x62e38, false)}, {74, new KeyValuePair<int, bool>(0x62e78, false)}, {75, new KeyValuePair<int, bool>(0x62eb8, false)}, {76, new KeyValuePair<int, bool>(0x62ef8, false)}, {77, new KeyValuePair<int, bool>(0x62f38, false)}, {78, new KeyValuePair<int, bool>(0x62f78, false)}, {79, new KeyValuePair<int, bool>(0x62fb8, false)}, {80, new KeyValuePair<int, bool>(0x62ff8, false)}, {81, new KeyValuePair<int, bool>(0x63038, false)}, {82, new KeyValuePair<int, bool>(0x63078, false)}, {83, new KeyValuePair<int, bool>(0x630b8, false)}, {84, new KeyValuePair<int, bool>(0x630f8, false)}, {85, new KeyValuePair<int, bool>(0x63138, false)}, {86, new KeyValuePair<int, bool>(0x63178, false)}, {87, new KeyValuePair<int, bool>(0x631b8, false)}, {88, new KeyValuePair<int, bool>(0x631f8, false)}, {89, new KeyValuePair<int, bool>(0x63238, false)}, {90, new KeyValuePair<int, bool>(0x63278, false)}, {91, new KeyValuePair<int, bool>(0x632b8, false)}, {92, new KeyValuePair<int, bool>(0x632f8, false)}, {93, new KeyValuePair<int, bool>(0x63338, false)}, {94, new KeyValuePair<int, bool>(0x63378, false)}, {95, new KeyValuePair<int, bool>(0x633b8, false)}, {96, new KeyValuePair<int, bool>(0x633f8, false)}, {97, new KeyValuePair<int, bool>(0x63438, false)}, {98, new KeyValuePair<int, bool>(0x63478, false)}, {99, new KeyValuePair<int, bool>(0x634b8, false)}, {100, new KeyValuePair<int, bool>(0x634f8, false)}, {101, new KeyValuePair<int, bool>(0x63538, false)}, {102, new KeyValuePair<int, bool>(0x63578, false)}, {103, new KeyValuePair<int, bool>(0x635b8, false)}, {104, new KeyValuePair<int, bool>(0x635f8, false)}, {105, new KeyValuePair<int, bool>(0x63638, false)}, {106, new KeyValuePair<int, bool>(0x63678, false)}, {107, new KeyValuePair<int, bool>(0x636b8, false)}, {108, new KeyValuePair<int, bool>(0x636f8, false)}, {109, new KeyValuePair<int, bool>(0x63738, false)}, {110, new KeyValuePair<int, bool>(0x63778, false)}, {111, new KeyValuePair<int, bool>(0x637b8, false)}, {112, new KeyValuePair<int, bool>(0x637f8, false)}, {113, new KeyValuePair<int, bool>(0x63838, false)}, {114, new KeyValuePair<int, bool>(0x63878, false)}, {115, new KeyValuePair<int, bool>(0x638b8, false)}, {116, new KeyValuePair<int, bool>(0x638f8, false)}, {117, new KeyValuePair<int, bool>(0x63938, false)}, {118, new KeyValuePair<int, bool>(0x63978, false)}, {119, new KeyValuePair<int, bool>(0x639b8, false)}, {120, new KeyValuePair<int, bool>(0x639f8, false)}, {121, new KeyValuePair<int, bool>(0x63a38, false)}, {122, new KeyValuePair<int, bool>(0x63a78, false)}, {123, new KeyValuePair<int, bool>(0x63ab8, false)}, {124, new KeyValuePair<int, bool>(0x63af8, false)}, {125, new KeyValuePair<int, bool>(0x63b38, false)}, {126, new KeyValuePair<int, bool>(0x63b78, false)}, {127, new KeyValuePair<int, bool>(0x63bb8, false)}, {128, new KeyValuePair<int, bool>(0x63bf8, false)}, {129, new KeyValuePair<int, bool>(0x63c38, false)}, {130, new KeyValuePair<int, bool>(0x63c78, false)}, {131, new KeyValuePair<int, bool>(0x63cb8, false)}, {132, new KeyValuePair<int, bool>(0x63cf8, false)}, {133, new KeyValuePair<int, bool>(0x63d38, false)}, {134, new KeyValuePair<int, bool>(0x63d78, false)}, {135, new KeyValuePair<int, bool>(0x63db8, false)}, {136, new KeyValuePair<int, bool>(0x63df8, false)}, {137, new KeyValuePair<int, bool>(0x63e38, false)}, {138, new KeyValuePair<int, bool>(0x63e78, false)}, {139, new KeyValuePair<int, bool>(0x63eb8, false)}, {140, new KeyValuePair<int, bool>(0x63ef8, false)}, {141, new KeyValuePair<int, bool>(0x63f38, false)}, {142, new KeyValuePair<int, bool>(0x63f78, false)}, {143, new KeyValuePair<int, bool>(0x63fb8, false)}, {144, new KeyValuePair<int, bool>(0x63ff8, false)}, {145, new KeyValuePair<int, bool>(0x64038, false)}, {146, new KeyValuePair<int, bool>(0x64078, false)}, {147, new KeyValuePair<int, bool>(0x640b8, false)}, {148, new KeyValuePair<int, bool>(0x640f8, false)}, {149, new KeyValuePair<int, bool>(0x64138, false)}}},
            {ActorNames.AUTOBUILD, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0xde208, false)}, {1, new KeyValuePair<int, bool>(0xdfc2c, false)}, {2, new KeyValuePair<int, bool>(0xe1650, false)}, {3, new KeyValuePair<int, bool>(0xe3074, false)}, {4, new KeyValuePair<int, bool>(0xe4a98, false)}, {5, new KeyValuePair<int, bool>(0xe64bc, false)}, {6, new KeyValuePair<int, bool>(0xe7ee0, false)}, {7, new KeyValuePair<int, bool>(0xe9904, false)}, {8, new KeyValuePair<int, bool>(0xeb328, false)}, {9, new KeyValuePair<int, bool>(0xecd4c, false)}, {10, new KeyValuePair<int, bool>(0xee770, false)}, {11, new KeyValuePair<int, bool>(0xf0194, false)}, {12, new KeyValuePair<int, bool>(0xf1bb8, false)}, {13, new KeyValuePair<int, bool>(0xf35dc, false)}, {14, new KeyValuePair<int, bool>(0xf5000, false)}, {15, new KeyValuePair<int, bool>(0xf6a24, false)}, {16, new KeyValuePair<int, bool>(0xf8448, false)}, {17, new KeyValuePair<int, bool>(0xf9e6c, false)}, {18, new KeyValuePair<int, bool>(0xfb890, false)}, {19, new KeyValuePair<int, bool>(0xfd2b4, false)}, {20, new KeyValuePair<int, bool>(0xfecd8, false)}, {21, new KeyValuePair<int, bool>(0x1006fc, false)}, {22, new KeyValuePair<int, bool>(0x102120, false)}, {23, new KeyValuePair<int, bool>(0x103b44, false)}, {24, new KeyValuePair<int, bool>(0x105568, false)}, {25, new KeyValuePair<int, bool>(0x106f8c, false)}, {26, new KeyValuePair<int, bool>(0x1089b0, false)}, {27, new KeyValuePair<int, bool>(0x10a3d4, false)}, {28, new KeyValuePair<int, bool>(0x10bdf8, false)}, {29, new KeyValuePair<int, bool>(0x10d81c, false)}}},
            {ActorNames.MONSTER, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0x10f26c, false)}, {1, new KeyValuePair<int, bool>(0x10f2d8, false)}, {2, new KeyValuePair<int, bool>(0x10f344, false)}, {3, new KeyValuePair<int, bool>(0x10f3b0, false)}, {4, new KeyValuePair<int, bool>(0x10f41c, false)}, {5, new KeyValuePair<int, bool>(0x10f488, false)}, {6, new KeyValuePair<int, bool>(0x10f4f4, false)}, {7, new KeyValuePair<int, bool>(0x10f560, false)}, {8, new KeyValuePair<int, bool>(0x10f5cc, false)}, {9, new KeyValuePair<int, bool>(0x10f638, false)}}},
            {ActorNames.HORSE, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0x8a128, false)}, {1, new KeyValuePair<int, bool>(0x8a168, false)}, {2, new KeyValuePair<int, bool>(0x8a1a8, false)}, {3, new KeyValuePair<int, bool>(0x8a1e8, false)}, {4, new KeyValuePair<int, bool>(0x8a228, false)}, {5, new KeyValuePair<int, bool>(0x8a268, false)}, {6, new KeyValuePair<int, bool>(0x8a2a8, false)}, {7, new KeyValuePair<int, bool>(0x8a2e8, false)}}},
            {ActorNames.MATERIAL, new Dictionary<int, KeyValuePair<int,bool>>(){{0, new KeyValuePair<int, bool>(0xafc30, false)}, {1, new KeyValuePair<int, bool>(0xafc70, false)}, {2, new KeyValuePair<int, bool>(0xafcb0, false)}, {3, new KeyValuePair<int, bool>(0xafcf0, false)}, {4, new KeyValuePair<int, bool>(0xafd30, false)}, {5, new KeyValuePair<int, bool>(0xafd70, false)}, {6, new KeyValuePair<int, bool>(0xafdb0, false)}, {7, new KeyValuePair<int, bool>(0xafdf0, false)}, {8, new KeyValuePair<int, bool>(0xafe30, false)}, {9, new KeyValuePair<int, bool>(0xafe70, false)}, {10, new KeyValuePair<int, bool>(0xafeb0, false)}, {11, new KeyValuePair<int, bool>(0xafef0, false)}, {12, new KeyValuePair<int, bool>(0xaff30, false)}, {13, new KeyValuePair<int, bool>(0xaff70, false)}, {14, new KeyValuePair<int, bool>(0xaffb0, false)}, {15, new KeyValuePair<int, bool>(0xafff0, false)}, {16, new KeyValuePair<int, bool>(0xb0030, false)}, {17, new KeyValuePair<int, bool>(0xb0070, false)}, {18, new KeyValuePair<int, bool>(0xb00b0, false)}, {19, new KeyValuePair<int, bool>(0xb00f0, false)}, {20, new KeyValuePair<int, bool>(0xb0130, false)}, {21, new KeyValuePair<int, bool>(0xb0170, false)}, {22, new KeyValuePair<int, bool>(0xb01b0, false)}, {23, new KeyValuePair<int, bool>(0xb01f0, false)}, {24, new KeyValuePair<int, bool>(0xb0230, false)}, {25, new KeyValuePair<int, bool>(0xb0270, false)}, {26, new KeyValuePair<int, bool>(0xb02b0, false)}, {27, new KeyValuePair<int, bool>(0xb02f0, false)}, {28, new KeyValuePair<int, bool>(0xb0330, false)}, {29, new KeyValuePair<int, bool>(0xb0370, false)}, {30, new KeyValuePair<int, bool>(0xb03b0, false)}, {31, new KeyValuePair<int, bool>(0xb03f0, false)}, {32, new KeyValuePair<int, bool>(0xb0430, false)}, {33, new KeyValuePair<int, bool>(0xb0470, false)}, {34, new KeyValuePair<int, bool>(0xb04b0, false)}, {35, new KeyValuePair<int, bool>(0xb04f0, false)}, {36, new KeyValuePair<int, bool>(0xb0530, false)}, {37, new KeyValuePair<int, bool>(0xb0570, false)}, {38, new KeyValuePair<int, bool>(0xb05b0, false)}, {39, new KeyValuePair<int, bool>(0xb05f0, false)}, {40, new KeyValuePair<int, bool>(0xb0630, false)}, {41, new KeyValuePair<int, bool>(0xb0670, false)}, {42, new KeyValuePair<int, bool>(0xb06b0, false)}, {43, new KeyValuePair<int, bool>(0xb06f0, false)}, {44, new KeyValuePair<int, bool>(0xb0730, false)}, {45, new KeyValuePair<int, bool>(0xb0770, false)}, {46, new KeyValuePair<int, bool>(0xb07b0, false)}, {47, new KeyValuePair<int, bool>(0xb07f0, false)}, {48, new KeyValuePair<int, bool>(0xb0830, false)}, {49, new KeyValuePair<int, bool>(0xb0870, false)}, {50, new KeyValuePair<int, bool>(0xb08b0, false)}, {51, new KeyValuePair<int, bool>(0xb08f0, false)}, {52, new KeyValuePair<int, bool>(0xb0930, false)}, {53, new KeyValuePair<int, bool>(0xb0970, false)}, {54, new KeyValuePair<int, bool>(0xb09b0, false)}, {55, new KeyValuePair<int, bool>(0xb09f0, false)}, {56, new KeyValuePair<int, bool>(0xb0a30, false)}, {57, new KeyValuePair<int, bool>(0xb0a70, false)}, {58, new KeyValuePair<int, bool>(0xb0ab0, false)}, {59, new KeyValuePair<int, bool>(0xb0af0, false)}, {60, new KeyValuePair<int, bool>(0xb0b30, false)}, {61, new KeyValuePair<int, bool>(0xb0b70, false)}, {62, new KeyValuePair<int, bool>(0xb0bb0, false)}, {63, new KeyValuePair<int, bool>(0xb0bf0, false)}, {64, new KeyValuePair<int, bool>(0xb0c30, false)}, {65, new KeyValuePair<int, bool>(0xb0c70, false)}, {66, new KeyValuePair<int, bool>(0xb0cb0, false)}, {67, new KeyValuePair<int, bool>(0xb0cf0, false)}, {68, new KeyValuePair<int, bool>(0xb0d30, false)}, {69, new KeyValuePair<int, bool>(0xb0d70, false)}, {70, new KeyValuePair<int, bool>(0xb0db0, false)}, {71, new KeyValuePair<int, bool>(0xb0df0, false)}, {72, new KeyValuePair<int, bool>(0xb0e30, false)}, {73, new KeyValuePair<int, bool>(0xb0e70, false)}, {74, new KeyValuePair<int, bool>(0xb0eb0, false)}, {75, new KeyValuePair<int, bool>(0xb0ef0, false)}, {76, new KeyValuePair<int, bool>(0xb0f30, false)}, {77, new KeyValuePair<int, bool>(0xb0f70, false)}, {78, new KeyValuePair<int, bool>(0xb0fb0, false)}, {79, new KeyValuePair<int, bool>(0xb0ff0, false)}, {80, new KeyValuePair<int, bool>(0xb1030, false)}, {81, new KeyValuePair<int, bool>(0xb1070, false)}, {82, new KeyValuePair<int, bool>(0xb10b0, false)}, {83, new KeyValuePair<int, bool>(0xb10f0, false)}, {84, new KeyValuePair<int, bool>(0xb1130, false)}, {85, new KeyValuePair<int, bool>(0xb1170, false)}, {86, new KeyValuePair<int, bool>(0xb11b0, false)}, {87, new KeyValuePair<int, bool>(0xb11f0, false)}, {88, new KeyValuePair<int, bool>(0xb1230, false)}, {89, new KeyValuePair<int, bool>(0xb1270, false)}, {90, new KeyValuePair<int, bool>(0xb12b0, false)}, {91, new KeyValuePair<int, bool>(0xb12f0, false)}, {92, new KeyValuePair<int, bool>(0xb1330, false)}, {93, new KeyValuePair<int, bool>(0xb1370, false)}, {94, new KeyValuePair<int, bool>(0xb13b0, false)}, {95, new KeyValuePair<int, bool>(0xb13f0, false)}, {96, new KeyValuePair<int, bool>(0xb1430, false)}, {97, new KeyValuePair<int, bool>(0xb1470, false)}, {98, new KeyValuePair<int, bool>(0xb14b0, false)}, {99, new KeyValuePair<int, bool>(0xb14f0, false)}, {100, new KeyValuePair<int, bool>(0xb1530, false)}, {101, new KeyValuePair<int, bool>(0xb1570, false)}, {102, new KeyValuePair<int, bool>(0xb15b0, false)}, {103, new KeyValuePair<int, bool>(0xb15f0, false)}, {104, new KeyValuePair<int, bool>(0xb1630, false)}, {105, new KeyValuePair<int, bool>(0xb1670, false)}, {106, new KeyValuePair<int, bool>(0xb16b0, false)}, {107, new KeyValuePair<int, bool>(0xb16f0, false)}, {108, new KeyValuePair<int, bool>(0xb1730, false)}, {109, new KeyValuePair<int, bool>(0xb1770, false)}, {110, new KeyValuePair<int, bool>(0xb17b0, false)}, {111, new KeyValuePair<int, bool>(0xb17f0, false)}, {112, new KeyValuePair<int, bool>(0xb1830, false)}, {113, new KeyValuePair<int, bool>(0xb1870, false)}, {114, new KeyValuePair<int, bool>(0xb18b0, false)}, {115, new KeyValuePair<int, bool>(0xb18f0, false)}, {116, new KeyValuePair<int, bool>(0xb1930, false)}, {117, new KeyValuePair<int, bool>(0xb1970, false)}, {118, new KeyValuePair<int, bool>(0xb19b0, false)}, {119, new KeyValuePair<int, bool>(0xb19f0, false)}, {120, new KeyValuePair<int, bool>(0xb1a30, false)}, {121, new KeyValuePair<int, bool>(0xb1a70, false)}, {122, new KeyValuePair<int, bool>(0xb1ab0, false)}, {123, new KeyValuePair<int, bool>(0xb1af0, false)}, {124, new KeyValuePair<int, bool>(0xb1b30, false)}, {125, new KeyValuePair<int, bool>(0xb1b70, false)}, {126, new KeyValuePair<int, bool>(0xb1bb0, false)}, {127, new KeyValuePair<int, bool>(0xb1bf0, false)}, {128, new KeyValuePair<int, bool>(0xb1c30, false)}, {129, new KeyValuePair<int, bool>(0xb1c70, false)}, {130, new KeyValuePair<int, bool>(0xb1cb0, false)}, {131, new KeyValuePair<int, bool>(0xb1cf0, false)}, {132, new KeyValuePair<int, bool>(0xb1d30, false)}, {133, new KeyValuePair<int, bool>(0xb1d70, false)}, {134, new KeyValuePair<int, bool>(0xb1db0, false)}, {135, new KeyValuePair<int, bool>(0xb1df0, false)}, {136, new KeyValuePair<int, bool>(0xb1e30, false)}, {137, new KeyValuePair<int, bool>(0xb1e70, false)}, {138, new KeyValuePair<int, bool>(0xb1eb0, false)}, {139, new KeyValuePair<int, bool>(0xb1ef0, false)}, {140, new KeyValuePair<int, bool>(0xb1f30, false)}, {141, new KeyValuePair<int, bool>(0xb1f70, false)}, {142, new KeyValuePair<int, bool>(0xb1fb0, false)}, {143, new KeyValuePair<int, bool>(0xb1ff0, false)}, {144, new KeyValuePair<int, bool>(0xb2030, false)}, {145, new KeyValuePair<int, bool>(0xb2070, false)}, {146, new KeyValuePair<int, bool>(0xb20b0, false)}, {147, new KeyValuePair<int, bool>(0xb20f0, false)}, {148, new KeyValuePair<int, bool>(0xb2130, false)}, {149, new KeyValuePair<int, bool>(0xb2170, false)}, {150, new KeyValuePair<int, bool>(0xb21b0, false)}, {151, new KeyValuePair<int, bool>(0xb21f0, false)}, {152, new KeyValuePair<int, bool>(0xb2230, false)}, {153, new KeyValuePair<int, bool>(0xb2270, false)}, {154, new KeyValuePair<int, bool>(0xb22b0, false)}, {155, new KeyValuePair<int, bool>(0xb22f0, false)}, {156, new KeyValuePair<int, bool>(0xb2330, false)}, {157, new KeyValuePair<int, bool>(0xb2370, false)}, {158, new KeyValuePair<int, bool>(0xb23b0, false)}, {159, new KeyValuePair<int, bool>(0xb23f0, false)}, {160, new KeyValuePair<int, bool>(0xb2430, false)}, {161, new KeyValuePair<int, bool>(0xb2470, false)}, {162, new KeyValuePair<int, bool>(0xb24b0, false)}, {163, new KeyValuePair<int, bool>(0xb24f0, false)}, {164, new KeyValuePair<int, bool>(0xb2530, false)}, {165, new KeyValuePair<int, bool>(0xb2570, false)}, {166, new KeyValuePair<int, bool>(0xb25b0, false)}, {167, new KeyValuePair<int, bool>(0xb25f0, false)}, {168, new KeyValuePair<int, bool>(0xb2630, false)}, {169, new KeyValuePair<int, bool>(0xb2670, false)}, {170, new KeyValuePair<int, bool>(0xb26b0, false)}, {171, new KeyValuePair<int, bool>(0xb26f0, false)}, {172, new KeyValuePair<int, bool>(0xb2730, false)}, {173, new KeyValuePair<int, bool>(0xb2770, false)}, {174, new KeyValuePair<int, bool>(0xb27b0, false)}, {175, new KeyValuePair<int, bool>(0xb27f0, false)}, {176, new KeyValuePair<int, bool>(0xb2830, false)}, {177, new KeyValuePair<int, bool>(0xb2870, false)}, {178, new KeyValuePair<int, bool>(0xb28b0, false)}, {179, new KeyValuePair<int, bool>(0xb28f0, false)}, {180, new KeyValuePair<int, bool>(0xb2930, false)}, {181, new KeyValuePair<int, bool>(0xb2970, false)}, {182, new KeyValuePair<int, bool>(0xb29b0, false)}, {183, new KeyValuePair<int, bool>(0xb29f0, false)}, {184, new KeyValuePair<int, bool>(0xb2a30, false)}, {185, new KeyValuePair<int, bool>(0xb2a70, false)}, {186, new KeyValuePair<int, bool>(0xb2ab0, false)}, {187, new KeyValuePair<int, bool>(0xb2af0, false)}, {188, new KeyValuePair<int, bool>(0xb2b30, false)}, {189, new KeyValuePair<int, bool>(0xb2b70, false)}, {190, new KeyValuePair<int, bool>(0xb2bb0, false)}, {191, new KeyValuePair<int, bool>(0xb2bf0, false)}, {192, new KeyValuePair<int, bool>(0xb2c30, false)}, {193, new KeyValuePair<int, bool>(0xb2c70, false)}, {194, new KeyValuePair<int, bool>(0xb2cb0, false)}, {195, new KeyValuePair<int, bool>(0xb2cf0, false)}, {196, new KeyValuePair<int, bool>(0xb2d30, false)}, {197, new KeyValuePair<int, bool>(0xb2d70, false)}, {198, new KeyValuePair<int, bool>(0xb2db0, false)}, {199, new KeyValuePair<int, bool>(0xb2df0, false)}, {200, new KeyValuePair<int, bool>(0xb2e30, false)}, {201, new KeyValuePair<int, bool>(0xb2e70, false)}, {202, new KeyValuePair<int, bool>(0xb2eb0, false)}, {203, new KeyValuePair<int, bool>(0xb2ef0, false)}, {204, new KeyValuePair<int, bool>(0xb2f30, false)}, {205, new KeyValuePair<int, bool>(0xb2f70, false)}, {206, new KeyValuePair<int, bool>(0xb2fb0, false)}, {207, new KeyValuePair<int, bool>(0xb2ff0, false)}, {208, new KeyValuePair<int, bool>(0xb3030, false)}, {209, new KeyValuePair<int, bool>(0xb3070, false)}, {210, new KeyValuePair<int, bool>(0xb30b0, false)}, {211, new KeyValuePair<int, bool>(0xb30f0, false)}, {212, new KeyValuePair<int, bool>(0xb3130, false)}, {213, new KeyValuePair<int, bool>(0xb3170, false)}, {214, new KeyValuePair<int, bool>(0xb31b0, false)}, {215, new KeyValuePair<int, bool>(0xb31f0, false)}, {216, new KeyValuePair<int, bool>(0xb3230, false)}, {217, new KeyValuePair<int, bool>(0xb3270, false)}, {218, new KeyValuePair<int, bool>(0xb32b0, false)}, {219, new KeyValuePair<int, bool>(0xb32f0, false)}, {220, new KeyValuePair<int, bool>(0xb3330, false)}, {221, new KeyValuePair<int, bool>(0xb3370, false)}, {222, new KeyValuePair<int, bool>(0xb33b0, false)}, {223, new KeyValuePair<int, bool>(0xb33f0, false)}, {224, new KeyValuePair<int, bool>(0xb3430, false)}, {225, new KeyValuePair<int, bool>(0xb3470, false)}, {226, new KeyValuePair<int, bool>(0xb34b0, false)}, {227, new KeyValuePair<int, bool>(0xb34f0, false)}, {228, new KeyValuePair<int, bool>(0xb3530, false)}, {229, new KeyValuePair<int, bool>(0xb3570, false)}, {230, new KeyValuePair<int, bool>(0xb35b0, false)}, {231, new KeyValuePair<int, bool>(0xb35f0, false)}, {232, new KeyValuePair<int, bool>(0xb3630, false)}, {233, new KeyValuePair<int, bool>(0xb3670, false)}, {234, new KeyValuePair<int, bool>(0xb36b0, false)}, {235, new KeyValuePair<int, bool>(0xb36f0, false)}, {236, new KeyValuePair<int, bool>(0xb3730, false)}, {237, new KeyValuePair<int, bool>(0xb3770, false)}, {238, new KeyValuePair<int, bool>(0xb37b0, false)}, {239, new KeyValuePair<int, bool>(0xb37f0, false)}, {240, new KeyValuePair<int, bool>(0xb3830, false)}, {241, new KeyValuePair<int, bool>(0xb3870, false)}, {242, new KeyValuePair<int, bool>(0xb38b0, false)}, {243, new KeyValuePair<int, bool>(0xb38f0, false)}, {244, new KeyValuePair<int, bool>(0xb3930, false)}, {245, new KeyValuePair<int, bool>(0xb3970, false)}, {246, new KeyValuePair<int, bool>(0xb39b0, false)}, {247, new KeyValuePair<int, bool>(0xb39f0, false)}, {248, new KeyValuePair<int, bool>(0xb3a30, false)}, {249, new KeyValuePair<int, bool>(0xb3a70, false)}, {250, new KeyValuePair<int, bool>(0xb3ab0, false)}}}

        };

        public enum ConsoleOutputType
        {
            DEFAULT,
            INFO,
            SUCCESS,
            WARNING,
            ERROR
        }

        public enum ActorNames
        {
            SWORD,
            SWORD_FUSE,
            SHIELD,
            SHIELD_FUSE,
            BOW,
            ARMOR,
            AUTOBUILD,
            MONSTER,
            HORSE,
            MATERIAL
        }

        public enum SaveAction
        {
            EDITING,
            DELETING,
            MASSDELETE
        }

        public enum SoundEffects
        {
            OPEN,
            CLICK,
            CLOSE,
            WRITE,
            DECLINE
        }

        public static List<string> actorList = new List<string>();
        public static Dictionary<int, string> actorDesc = new Dictionary<int, string>();
        public static int actorSelectionSelected = 0;

        public static string saveFolder = string.Empty;
        public static List<string> slotFolders = new List<string>();
        public static int saveSlotSelected = 0;
        public static bool saveFolderScanned = false;
        public static Regex reSaveSlot = new Regex(@"^slot_\d{2}$");

        public static bool reselectEnabled = false;
        public static bool massDelEnabled = false;
        public static bool optEnabled = false;
        public static bool consoleShow = true;

        public static ActorNames reselectCurrentTab = ActorNames.SWORD;

        public static bool optDisableSound = false;
        public static bool optClearAfter = false;
        public static int optSelectionSep = 10;
        public static bool disableFont = false;
        public static int fontSize = 16;

        [STAThread]
        public static void Main(string[] args)
        {   
            Console.Title = "TOTK Actor Editor Console";

            ConsolePrint($"TOTK Actor Editor by @accountrev.\n");
            ConsolePrint("Please select a Tears of the Kingdom save folder.");
            ConsolePrint("If you use the Yuzu emulator, right click on TOTK > Open Save Data Location > copy the folder path URL.");
            ConsolePrint("If you use the Ryujinx emulator, right click on TOTK > Open User Save Directoy > copy the folder path URL.");
            ConsolePrint("If you use a modded Switch, use Checkpoint to backup your save and select the backed up save folder.");

            do
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                var fbdResult = fbd.ShowDialog();
                if (fbdResult == DialogResult.OK)
                {
                    saveFolder = fbd.SelectedPath;
                }
                else if (fbdResult == DialogResult.Cancel || fbdResult == DialogResult.None) System.Environment.Exit(0);


                if (Directory.Exists(saveFolder))
                {
                    foreach (string directory in Directory.GetDirectories(saveFolder))
                    {
                        var dirInfo = new DirectoryInfo(directory);

                        if (reSaveSlot.IsMatch(dirInfo.Name))
                        {
                            slotFolders.Add(dirInfo.Name);
                        }
                    }

                    ConsolePrint("Folder selected has been verified.", ConsoleOutputType.INFO);
                }
                else
                {
                    ConsolePrint("Something went wrong trying to access the folder. Please try again or do another save folder.", ConsoleOutputType.ERROR);
                }


                if (slotFolders.Count == 0)
                    ConsolePrint("No save slots have been detected in this folder. Please try another save folder.", ConsoleOutputType.ERROR);
                else
                    saveFolderScanned = true;
                    saveSlotSelected = slotFolders.Count-1;

                    ConsolePrint("Folder now in use.", ConsoleOutputType.INFO);
                

            } while (!saveFolderScanned);
            

            ConsolePrint("Loading the actor list...", ConsoleOutputType.INFO);
            

            using (StreamReader reader = new StreamReader(@"data\actors.txt"))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    actorList.Add(line);
                }
                
            }
            
            ConsolePrint("Actor list loaded.", ConsoleOutputType.SUCCESS);
            ConsolePrint("Loading actor descriptions...", ConsoleOutputType.INFO);

            using (StreamReader reader = new StreamReader(@"data\actor_info.json"))
            {
                string json = reader.ReadToEnd();
                var actorDescTemp = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                actorDesc = actorDescTemp.ToDictionary(
                    pair => int.Parse(pair.Key),
                    pair => pair.Value
                );
            }

            ConsolePrint("Actor descriptions loaded.", ConsoleOutputType.SUCCESS);
            ConsolePrint("Loading editor...", ConsoleOutputType.INFO);

            Program program = new Program();
            program.ReplaceFont(@"data\Calamity-Regular.otf", fontSize, FontGlyphRangeType.English);
            SoundEffect(SoundEffects.OPEN);

            program.Start().Wait();
        }

        static void ConsolePrint(dynamic data, ConsoleOutputType type = ConsoleOutputType.DEFAULT)
        {
            string prefix = string.Empty;

            switch (type)
            {
                case ConsoleOutputType.DEFAULT:
                    Console.ForegroundColor = ConsoleColor.White;
                    prefix = "[*] ";
                    break;
                case ConsoleOutputType.INFO:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    prefix = "[?] ";
                    break;
                case ConsoleOutputType.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    prefix = "[!] ";
                    break;
                case ConsoleOutputType.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    prefix = "[X] ";
                    break;
                case ConsoleOutputType.SUCCESS:
                    Console.ForegroundColor = ConsoleColor.Green;
                    prefix = "[✓] ";
                    break;
            }

            Console.WriteLine(prefix + data);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void SetImGuiStyle()
        {
            var style = ImGui.GetStyle();
            
            style.Alpha = 1.0f;
            style.DisabledAlpha = 0.6000000238418579f;
            style.WindowPadding = new Vector2(8.0f, 8.0f);
            style.WindowRounding = 10.0f;
            style.WindowBorderSize = 1.0f;
            style.WindowMinSize = new Vector2(32.0f, 32.0f);
            style.WindowTitleAlign = new Vector2(0.5f, 0.5f);
            style.WindowMenuButtonPosition = ImGuiDir.Left;
            style.ChildRounding = 7.0f;
            style.ChildBorderSize = 1.0f;
            style.PopupRounding = 6.0f;
            style.PopupBorderSize = 1.0f;
            style.FramePadding = new Vector2(4.0f, 3.0f);
            style.FrameRounding = 6.5f;
            style.FrameBorderSize = 0.0f;
            style.ItemSpacing = new Vector2(8.0f, 4.0f);
            style.ItemInnerSpacing = new Vector2(4.0f, 4.0f);
            style.CellPadding = new Vector2(4.0f, 2.0f);
            style.IndentSpacing = 21.0f;
            style.ColumnsMinSpacing = 6.0f;
            style.ScrollbarSize = 14.0f;
            style.ScrollbarRounding = 10.0f;
            style.GrabMinSize = 10.0f;
            style.GrabRounding = 0.0f;
            style.TabRounding = 4.0f;
            style.TabBorderSize = 0.0f;
            style.TabMinWidthForCloseButton = 0.0f;
            style.ColorButtonPosition = ImGuiDir.Right;
            style.ButtonTextAlign = new Vector2(0.5f, 0.5f);
            style.SelectableTextAlign = new Vector2(0.0f, 0.0f);
            
            style.Colors[(int)ImGuiCol.Text] = new Vector4(0.7653115391731262f, 0.8624956011772156f, 0.9484978318214417f, 1.0f);
            style.Colors[(int)ImGuiCol.TextDisabled] = new Vector4(0.4980392158031464f, 0.4980392158031464f, 0.4980392158031464f, 1.0f);
            style.Colors[(int)ImGuiCol.WindowBg] = new Vector4(0.05882352963089943f, 0.05882352963089943f, 0.05882352963089943f, 0.9399999976158142f);
            style.Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            style.Colors[(int)ImGuiCol.PopupBg] = new Vector4(0.0784313753247261f, 0.0784313753247261f, 0.0784313753247261f, 0.9399999976158142f);
            style.Colors[(int)ImGuiCol.Border] = new Vector4(0.4236401617527008f, 0.6503168940544128f, 0.9055793881416321f, 1.0f);
            style.Colors[(int)ImGuiCol.BorderShadow] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999899930335232e-07f, 0.0f);
            style.Colors[(int)ImGuiCol.FrameBg] = new Vector4(0.1568627506494522f, 0.2862745225429535f, 0.47843137383461f, 0.5400000214576721f);
            style.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.4000000059604645f);
            style.Colors[(int)ImGuiCol.FrameBgActive] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.6700000166893005f);
            style.Colors[(int)ImGuiCol.TitleBg] = new Vector4(0.0f, 0.1987892836332321f, 0.4206008315086365f, 1.0f);
	        style.Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(0.0f, 0.2901960909366608f, 0.6196078658103943f, 1.0f);
            style.Colors[(int)ImGuiCol.TitleBgCollapsed] = new Vector4(0.0f, 0.1254029273986816f, 0.3175965547561646f, 0.5099999904632568f);
            style.Colors[(int)ImGuiCol.MenuBarBg] = new Vector4(0.1372549086809158f, 0.1372549086809158f, 0.1372549086809158f, 1.0f);
            style.Colors[(int)ImGuiCol.ScrollbarBg] = new Vector4(0.01960784383118153f, 0.01960784383118153f, 0.01960784383118153f, 0.5299999713897705f);
            style.Colors[(int)ImGuiCol.ScrollbarGrab] = new Vector4(0.3098039329051971f, 0.3098039329051971f, 0.3098039329051971f, 1.0f);
            style.Colors[(int)ImGuiCol.ScrollbarGrabHovered] = new Vector4(0.407843142747879f, 0.407843142747879f, 0.407843142747879f, 1.0f);
            style.Colors[(int)ImGuiCol.ScrollbarGrabActive] = new Vector4(0.5098039507865906f, 0.5098039507865906f, 0.5098039507865906f, 1.0f);
            style.Colors[(int)ImGuiCol.CheckMark] = new Vector4(0.2599999904632568f, 0.5899999737739563f, 0.9800000190734863f, 1.0f);
            style.Colors[(int)ImGuiCol.SliderGrab] = new Vector4(0.239999994635582f, 0.5199999809265137f, 0.8799999952316284f, 1.0f);
            style.Colors[(int)ImGuiCol.SliderGrabActive] = new Vector4(0.2599999904632568f, 0.5899999737739563f, 0.9800000190734863f, 1.0f);
            style.Colors[(int)ImGuiCol.Button] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.4000000059604645f);
            style.Colors[(int)ImGuiCol.ButtonHovered] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 1.0f);
            style.Colors[(int)ImGuiCol.ButtonActive] = new Vector4(0.05882352963089943f, 0.529411792755127f, 0.9764705896377563f, 1.0f);
            style.Colors[(int)ImGuiCol.Header] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.3100000023841858f);
            style.Colors[(int)ImGuiCol.HeaderHovered] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.800000011920929f);
            style.Colors[(int)ImGuiCol.HeaderActive] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 1.0f);
            style.Colors[(int)ImGuiCol.Separator] = new Vector4(0.4274509847164154f, 0.4274509847164154f, 0.4980392158031464f, 0.5f);
            style.Colors[(int)ImGuiCol.SeparatorHovered] = new Vector4(0.09803921729326248f, 0.4000000059604645f, 0.7490196228027344f, 0.7799999713897705f);
            style.Colors[(int)ImGuiCol.SeparatorActive] = new Vector4(0.09803921729326248f, 0.4000000059604645f, 0.7490196228027344f, 1.0f);
            style.Colors[(int)ImGuiCol.ResizeGrip] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.2000000029802322f);
            style.Colors[(int)ImGuiCol.ResizeGripHovered] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.6700000166893005f);
            style.Colors[(int)ImGuiCol.ResizeGripActive] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.949999988079071f);
            style.Colors[(int)ImGuiCol.Tab] = new Vector4(0.1764705926179886f, 0.3490196168422699f, 0.5764706134796143f, 0.8619999885559082f);
            style.Colors[(int)ImGuiCol.TabHovered] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.800000011920929f);
            style.Colors[(int)ImGuiCol.TabActive] = new Vector4(0.196078434586525f, 0.407843142747879f, 0.6784313917160034f, 1.0f);
            style.Colors[(int)ImGuiCol.TabUnfocused] = new Vector4(0.06666667014360428f, 0.1019607856869698f, 0.1450980454683304f, 0.9724000096321106f);
            style.Colors[(int)ImGuiCol.TabUnfocusedActive] = new Vector4(0.1333333402872086f, 0.2588235437870026f, 0.4235294163227081f, 1.0f);
            style.Colors[(int)ImGuiCol.PlotLines] = new Vector4(0.6078431606292725f, 0.6078431606292725f, 0.6078431606292725f, 1.0f);
            style.Colors[(int)ImGuiCol.PlotLinesHovered] = new Vector4(1.0f, 0.4274509847164154f, 0.3490196168422699f, 1.0f);
            style.Colors[(int)ImGuiCol.PlotHistogram] = new Vector4(0.8980392217636108f, 0.6980392336845398f, 0.0f, 1.0f);
            style.Colors[(int)ImGuiCol.PlotHistogramHovered] = new Vector4(1.0f, 0.6000000238418579f, 0.0f, 1.0f);
            style.Colors[(int)ImGuiCol.TableHeaderBg] = new Vector4(0.1882352977991104f, 0.1882352977991104f, 0.2000000029802322f, 1.0f);
            style.Colors[(int)ImGuiCol.TableBorderStrong] = new Vector4(0.3098039329051971f, 0.3098039329051971f, 0.3490196168422699f, 1.0f);
            style.Colors[(int)ImGuiCol.TableBorderLight] = new Vector4(0.2274509817361832f, 0.2274509817361832f, 0.2470588237047195f, 1.0f);
            style.Colors[(int)ImGuiCol.TableRowBg] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999899930335232e-07f, 0.0f);
            style.Colors[(int)ImGuiCol.TableRowBgAlt] = new Vector4(1.0f, 1.0f, 1.0f, 0.05999999865889549f);
            style.Colors[(int)ImGuiCol.TextSelectedBg] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 0.3499999940395355f);
            style.Colors[(int)ImGuiCol.DragDropTarget] = new Vector4(1.0f, 1.0f, 0.0f, 0.8999999761581421f);
            style.Colors[(int)ImGuiCol.NavHighlight] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 1.0f);
            style.Colors[(int)ImGuiCol.NavWindowingHighlight] = new Vector4(1.0f, 0.9999899864196777f, 0.9999899864196777f, 0.699999988079071f);
            style.Colors[(int)ImGuiCol.NavWindowingDimBg] = new Vector4(0.9141631126403809f, 0.9141539335250854f, 0.9141539335250854f, 0.2000000029802322f);
            style.Colors[(int)ImGuiCol.ModalWindowDimBg] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999899930335232e-07f, 0.5364806652069092f);
        }

        
        static void SlotsRender()
        {
            var separatorCounter = 0;

            // TODO: Change for loop to foreach loop, this code was for an older structure of addresses dictionary
            for (int i = 0; i < addresses[reselectCurrentTab].Count; i++)
            {
                bool slot = addresses[reselectCurrentTab][i].Value;

                if (reselectCurrentTab != ActorNames.MATERIAL && reselectCurrentTab != ActorNames.ARMOR)
                {
                    ImGui.Checkbox($"{i+1:00}", ref slot);
                }
                else ImGui.Checkbox($"{i+1:000}", ref slot);

                if (ImGui.IsItemHovered()) ImGui.SetTooltip($"Slot {i+1}");

                if (separatorCounter != optSelectionSep - 1)
                {
                    ImGui.SameLine();
                    separatorCounter++;
                }
                else
                {
                    separatorCounter = 0;
                }

                addresses[reselectCurrentTab][i] = new KeyValuePair<int, bool>(addresses[reselectCurrentTab][i].Key, slot);
            }
        }

        static void ToggleConsoleWindow()
        {
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();

            [DllImport("user32.dll")]
            static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);

            const int SW_HIDE = 0;
            const int SW_SHOW = 5;

            IntPtr handle = GetConsoleWindow();
            if (consoleShow)
            {
                ShowWindow(handle, SW_HIDE);
                ConsolePrint("Hiding the console...", ConsoleOutputType.INFO);
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
                ConsolePrint("Showing the console...", ConsoleOutputType.INFO);
            }

            consoleShow = !consoleShow;
                
        }

        static Task SoundEffect(SoundEffects soundEffect)
        {
            
            if (!optDisableSound)
            {
                var outputDevice = new WaveOutEvent();
                
                switch (soundEffect)
                {
                    case SoundEffects.OPEN:
                        var openWav = new AudioFileReader(@"audio\open.wav");
                        outputDevice.Init(openWav);
                        break;
                    case SoundEffects.CLICK:
                        var clickWav = new AudioFileReader(@"audio\click.wav");
                        outputDevice.Init(clickWav);
                        break;
                    case SoundEffects.WRITE:
                        var writeWav = new AudioFileReader(@"audio\write.wav");
                        outputDevice.Init(writeWav);
                        break;
                        
                }

                outputDevice.Play();
            }

            return Task.CompletedTask;     
        }


        // Currently unused
        static void EditAddress(ActorNames actorCategory, int slot, int newAddress)
        {
            addresses[actorCategory][slot] = new KeyValuePair<int, bool>(newAddress, addresses[actorCategory][slot].Value);
        }
        
        static void EditSave(SaveAction action, ActorNames actorToMassDelete = ActorNames.SWORD)
        {
            using (var fs = new FileStream(saveFolder + "\\" + slotFolders[saveSlotSelected] + @"\progress.sav", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                switch (action)
                {
                    case SaveAction.EDITING:
                        foreach (var actorCat in addresses)
                        {
                            foreach (var address in actorCat.Value)
                            {
                                if (address.Value.Value)
                                {
                                    ConsolePrint($"Writing values to slot {address.Value}...", ConsoleOutputType.INFO);
                                    fs.Seek(address.Value.Key, SeekOrigin.Begin);

                                    var actorString = Encoding.UTF8.GetBytes(actorList[actorSelectionSelected]);
                                    fs.Write(actorString, 0, actorString.Length);
                                    fs.WriteByte(0);
                                }
                            }
                        }
                        break;
                    case SaveAction.DELETING:
                        foreach (var actorCat in addresses)
                        {
                            foreach (var address in actorCat.Value)
                            {
                                if (address.Value.Value)
                                {
                                    ConsolePrint($"Deleting values from slot {address.Value}...", ConsoleOutputType.INFO);
                                    fs.Seek(address.Value.Key, SeekOrigin.Begin);
                                    fs.WriteByte(0);
                                }
                            }
                        }
                        break;
                    case SaveAction.MASSDELETE:
                        ConsolePrint("Mass-deleting slots...", ConsoleOutputType.INFO);
                        foreach (var address in addresses[actorToMassDelete])
                        {
                            fs.Seek(address.Value.Key, SeekOrigin.Begin);
                            fs.WriteByte(0);
                        }
                        break;
                }

                fs.Close();
            }

            if (optClearAfter)
            {
                foreach (var actorCat in addresses)
                {
                    foreach (var address in actorCat.Value)
                    {
                        addresses[actorCat.Key][address.Key] = new KeyValuePair<int, bool>(address.Value.Key, false);
                    }
                }
            }
        }

        protected override void Render()
        {
            SetImGuiStyle();

            if (ImGui.Begin("Tears of the Kingdom Actor Editor"))
            {

                ImGui.BeginChild("Selected Actor", new Vector2(0, ImGui.GetWindowSize().Y / 4));
                ImGui.TextWrapped($"Currently selected: {actorList[actorSelectionSelected]}");
                ImGui.Separator();
                if (!actorDesc.ContainsKey(actorSelectionSelected)) ImGui.TextWrapped($"No description available.");
                else ImGui.TextWrapped($"{actorDesc[actorSelectionSelected]}");
                ImGui.EndChild();
                ImGui.TextWrapped($"Position: {actorSelectionSelected}");
                ImGui.BeginGroup();
                ImGui.Separator();
                ImGui.TextWrapped("What would you like to do?");

                if (ImGui.Button("Write to Slots"))
                {
                    EditSave(SaveAction.EDITING);
                    SoundEffect(SoundEffects.WRITE);   
                }

                ImGui.SameLine();
                
                if (ImGui.Button("Delete Slots"))
                {
                    EditSave(SaveAction.DELETING);
                    SoundEffect(SoundEffects.WRITE);
                }

                ImGui.SameLine();

                if (ImGui.Button("Reselect Slots"))
                {
                    reselectEnabled = !reselectEnabled;
                    SoundEffect(SoundEffects.CLICK);
                }

                ImGui.SameLine();

                if (ImGui.Button("Mass Delete"))
                {
                    massDelEnabled = !massDelEnabled;
                    SoundEffect(SoundEffects.CLICK);
                }

                ImGui.SameLine();

                if (ImGui.Button("Options"))
                {
                    optEnabled = !optEnabled;
                    SoundEffect(SoundEffects.CLICK);
                }

                ImGui.SameLine();

                if (ImGui.Button("Toggle Console"))
                {
                    ToggleConsoleWindow();
                    SoundEffect(SoundEffects.CLICK);
                }

                ImGui.Separator();
                ImGui.TextWrapped("Select an actor:");
                
                ImGui.BeginChild("Actor List", new Vector2(0, -ImGui.GetFrameHeightWithSpacing()), true);
                
                for (int i = 0; i < actorList.Count; i++)
                {
                    if (ImGui.Selectable(actorList[i], actorSelectionSelected == i))
                        actorSelectionSelected = i;
                }
                ImGui.EndChild();

                ImGui.TextWrapped("Save Slot");
                ImGui.SameLine();
                if (ImGui.BeginCombo(string.Empty, slotFolders[saveSlotSelected]))
                {
                    for (int i = 0; i < slotFolders.Count; i++)
                    {
                        if (ImGui.Selectable(slotFolders[i], saveSlotSelected == i))
                            saveSlotSelected = i;
                    }
                }

                ImGui.EndGroup();
            }

            if (reselectEnabled)
                if (ImGui.Begin("Slot Selection", ref reselectEnabled))
                {
                    if (ImGui.BeginTabBar("##Tabs"))
                    {
                        if (ImGui.BeginTabItem("Weapons"))
                        {
                            reselectCurrentTab = ActorNames.SWORD;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }
                        
                        if (ImGui.BeginTabItem("Weapon Fuses"))
                        {
                            reselectCurrentTab = ActorNames.SWORD_FUSE;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }
                        
                        if (ImGui.BeginTabItem("Shields"))
                        {
                            reselectCurrentTab = ActorNames.SHIELD;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }
                        
                        if (ImGui.BeginTabItem("Shield Fuses"))
                        {
                            reselectCurrentTab = ActorNames.SHIELD_FUSE;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }
                        
                        if (ImGui.BeginTabItem("Bows"))
                        {
                            reselectCurrentTab = ActorNames.BOW;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }

                        if (ImGui.BeginTabItem("Armor"))
                        {
                            reselectCurrentTab = ActorNames.ARMOR;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }
                        
                        if (ImGui.BeginTabItem("Autobuild"))
                        {
                            reselectCurrentTab = ActorNames.AUTOBUILD;
                            ImGui.TextWrapped("UNDER CONSTRUCTION!");
                            //SlotsRender();
                            ImGui.EndTabItem();
                        }

                        if (ImGui.BeginTabItem("Monster Statues"))
                        {
                            reselectCurrentTab = ActorNames.MONSTER;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }

                        if (ImGui.BeginTabItem("Horses"))
                        {
                            reselectCurrentTab = ActorNames.HORSE;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }
                        
                        if (ImGui.BeginTabItem("Materials"))
                        {
                            reselectCurrentTab = ActorNames.MATERIAL;
                            SlotsRender();
                            ImGui.EndTabItem();
                        }
                        
                        
                    }
                }

            if (massDelEnabled)
                if (ImGui.Begin("Mass Delete", ref massDelEnabled))
                {
                    ImGui.Text("Please select what actor to mass delete from the save file.");
                    ImGui.Text("This will WIPE ALL SLOTS that you select. You have been warned.");
                    ImGui.Separator();

                    if (ImGui.Button("Weapons"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.SWORD);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Weapon Fuses"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.SWORD_FUSE);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Shields"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.SHIELD);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Shield Fuses"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.SHIELD_FUSE);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Bows"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.BOW);
                    }

                    if (ImGui.Button("Armor"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.ARMOR);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("!Autobuild!"))
                    {
                        ConsolePrint("Under construction!", ConsoleOutputType.WARNING);
                        //EditSave(SaveAction.MASSDELETE, ActorNames.AUTOBUILD);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Monster Statues"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.MONSTER);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Horses"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.HORSE);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Materials"))
                    {
                        EditSave(SaveAction.MASSDELETE, ActorNames.MATERIAL);
                    }


                }

            
            if (optEnabled)
                if (ImGui.Begin("Options", ref optEnabled))
                {
                    ImGui.Checkbox("Disable Sounds", ref optDisableSound);
                    if (ImGui.IsItemHovered()) ImGui.SetTooltip("Enables the sounds that are played when using the menu.");
                    ImGui.Checkbox("Clear Checkboxes After Write", ref optClearAfter);
                    if (ImGui.IsItemHovered()) ImGui.SetTooltip("Clears the slot checkboxes that you selected from the Slot Selection menu after a write.");
                    ImGui.InputInt("Slot Selection Row Amount", ref optSelectionSep);
                    if (ImGui.IsItemHovered()) ImGui.SetTooltip("How many slots before it makes a new row.");
                    ImGui.InputInt("Font Size", ref fontSize);
                    if (ImGui.IsItemHovered()) ImGui.SetTooltip("The size of the current font.");
                    if (ImGui.Button("Toggle Font"))
                    {
                        if (!disableFont)
                        {
                            ConsolePrint("Switching to ProggyClean.ttf font", ConsoleOutputType.INFO);
                            ReplaceFont("ProggyClean.ttf", fontSize, FontGlyphRangeType.English);
                        }
                        else
                        {
                            ConsolePrint("Switching to Calamity-Regular.otf font", ConsoleOutputType.INFO);
                            ReplaceFont("Calamity-Regular.otf", fontSize, FontGlyphRangeType.English);
                        }

                        disableFont = !disableFont;
                    }
                    if (ImGui.IsItemHovered()) ImGui.SetTooltip("Toggles the font between Calamity-Regular and the default ImGui font.");
                }
        }
    }
}