using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class UserInitialize
    {
        public const short ID = 7511;

        public int FactionID { get; set; }
        public string ShipType { get; set; }
        public bool var_2798 { get; set; }
        public int var_1169 { get; set; }
        public int Level { get; set; }
        public int var_366 { get; set; }
        public bool Cloaked { get ; set; }
        public int Speed { get; set; }
        public double Uridium { get; set; }
        public int MapId { get; set; }
        public int Shield { get; set; }
        public int name_10 { get; set; }
        public double Credits { get; set; }
        public int var_90 { get; set; }
        public string Username { get ; set ;}
        public int X { get; set; }
        public double Experience { get; set; }
        public bool premium  { get; set; }
        public string name_7 { get; set; }
        public int var_1149 { get; set; }
        public int name_11 { get ; set; }
        public int MaxHp { get ; set; }
        public int name_2 { get ; set; }
        public int var_359  { get ; set; }
        public double Honnor { get ; set; }
        public int name_5 { get ; set; }
        public int name_42 { get ; set; }
        public float jackpot { get ; set; }
        public int Hp { get ; set; }
        public int Y { get; set; }



        public UserInitialize(EndianBinaryReader param1)
        {
            FactionID = param1.ReadInt32();
            FactionID = (int)((uint)FactionID >> 12 | (uint)FactionID << 20);
            ShipType = param1.ReadString();
            var_2798 = param1.ReadBoolean();
            param1.ReadInt16(); //Not needed ?
            var_1169 = param1.ReadInt32();
            var_1169 = (int)((uint)var_1169 << 16 | (uint)var_1169 >> 16);
            Level = param1.ReadInt32();
            Level = (int)((uint)Level >> 9 | (uint)Level << 23);
            var_366 = param1.ReadInt32();
            var_366 = (int)((uint)var_366 << 14 | (uint)var_366 >> 18);
            Cloaked = param1.ReadBoolean();
            Speed = param1.ReadInt32();
            Speed = (int)((uint)Speed << 10 | (uint)Speed >> 22);
            Uridium = param1.ReadDouble();
            MapId = param1.ReadInt32();
            MapId = (int)((uint)MapId << 9 | (uint)MapId >> 23);
            Shield = param1.ReadInt32();
            Shield = (int)((uint)Shield << 10 | (uint)Shield >> 22);
            name_10 = param1.ReadInt32();
            name_10 = (int)((uint)name_10 >> 8 | (uint)name_10 << 24);
            Credits = param1.ReadDouble();
            var_90 = param1.ReadInt32();
            Username = param1.ReadString();
            X = param1.ReadInt32();
            X = (int)((uint)X << 5 | (uint)X >> 27);
            Experience = param1.ReadDouble();
            premium = param1.ReadBoolean();
            name_7 = param1.ReadString();
            var_1149 = param1.ReadInt32();
            var_1149 = (int)((uint)var_1149 << 10 | (uint)var_1149 >> 22);
            name_11 =  param1.ReadInt32();
            name_11 = (int)((uint)name_11 >> 6 | (uint)name_11 << 26);
            MaxHp = param1.ReadInt32();
            MaxHp = (int)((uint)MaxHp << 5 | (uint)MaxHp >> 27);
            name_2 = param1.ReadInt32();
            name_2 = (int)((uint)name_2 >> 1 | (uint)name_2 << 31);
            var_359 = param1.ReadInt32();
            var_359 = (int)((uint)var_359 << 1 | (uint)var_359 >> 31);
            Honnor = param1.ReadDouble();
            name_5 = param1.ReadInt32();
            name_5 = (int)((uint)name_5 << 8 | (uint)name_5 >> 24);
            name_42 = param1.ReadInt32();
            name_42 = (int)((uint)name_42 >> 3 | (uint)name_42 << 29);
            jackpot = param1.ReadSingle();
            Hp = param1.ReadInt32();
            Hp = (int)((uint)Hp >> 3 | (uint)Hp << 29);
            
            var _loc3_ = param1.ReadInt32();
            for (int i = 0; i < _loc3_; i++)
            {
                param1.ReadInt16();
                var name2 = param1.ReadInt32();
                name2 = (int)((uint)name2 >> 11 | (uint)name2 << 21);
                var count = param1.ReadInt32();
                count = (int)((uint)count << 15 | (uint)count >> 17);
                var UkStr = param1.ReadString();
                var activated = param1.ReadBoolean();
                var attribute = param1.ReadInt32();
                attribute = (int)((uint)attribute << 3 | (uint)attribute >> 29);
                param1.ReadInt16();
                param1.ReadUInt16();
        
            
            }
            Y = param1.ReadInt32();
            Y = (int)((uint)Y >> 1 | (uint)Y << 31);
           



        }
    }
}
