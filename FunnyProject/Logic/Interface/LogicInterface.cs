using FunnyProject.Commands.Write;
using FunnyProject.UserCollections.Objects;
using FunnyProject.UserCollections.Resources;
using Krypton_Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = FunnyProject.Commands.Write.Action;

namespace FunnyProject.Logic.Interface
{
    public class LogicInterface
    {
        protected Api Api { get; set; }

        public LogicInterface(Api api)
        {
            Api = api;
        }
        #region closes and calculation
        protected double CalculateDistance(int x, int y)
        {
            return CalculateDistance(Api.User.Position.X, Api.User.Position.Y, x, y);
        }
        protected double CalculateDistance(Point point)
        {
            return CalculateDistance(point.X, point.Y);
        }
        public double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        public Box? ClosestBox()
        {
            Box? nearestBox;
            nearestBox = Api.User.Boxes._Boxes.ToList().MinBy(box => CalculateDistance(new Point(box.X, box.Y)));
            if (nearestBox != null)
            {
                if(nearestBox.Type.Contains("BONUS_BOX"))
                {
                    return nearestBox;
                }
            }
            return null;
        }
        #endregion

        protected void SendPacket(Command com)
        {
            Api.User.PacketManager?.Send(com);
        }
        public bool NpcAround()
        {
            return Api.User.Players.Npcs.Count != 0;
        }
        protected Player? ClosestNpc()
        {
            Player? npc = null;
           npc = Api.User.Players.Npcs.ToList().OrderBy(npc => CalculateDistance(new Point(npc.X, npc.Y))).FirstOrDefault();

            if (npc != null)
            {
                return npc;
              
            }
            


            return null;
        }
        protected PointF CircleAround(float radius, float AngleInDegrees, PointF origin)
        {
            float x = (float)(radius * Math.Cos(AngleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(AngleInDegrees * Math.PI / 180f)) + origin.Y;
            return new PointF(x, y);
        }



        float angle = 0f; // angle of my own ship

        private float CalculateAngle(float x1, float x2, float y1, float y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            return (float)((float)Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI);
        }
        public void AssignAngle()
        {
            if (Api.User.Target == null) return;
            angle = CalculateAngle(Api.User.Target.X, Api.User.Position.X, Api.User.Target.Y, Api.User.Position.Y);
            if (angle < 0)
            {
                angle *= -1;
            }

            Console.WriteLine("angle:" + angle);
        }
        public void AttackNpc(Player npc)
        {
            SendPacket(new AttackCommand(npc.ID, Api.User.Target.X, Api.User.Target.Y));
        }

        public void Circle(Player npc)
        {
            if (npc == null) return;
            var pos = CircleAround(450, angle, new PointF(npc.X, npc.Y));
            if (angle < 360)
            {
                angle += 12f;
            }
            else
            {
                angle = 0;
            }

            FlyToCorndinates((int)pos.X, (int)pos.Y);

        }
        public void Circle(int x, int y)
        {
            var pos = CircleAround(5000, angle, new PointF(x, y));
            if (angle < 360)
            {
                angle += 6.5f;
            }
            else
            {
                angle = 0;
            }
            FlyToCorndinates((int)pos.X, (int)pos.Y);
        }
        protected void SellectAmmo()
        {
            SendPacket(new Action("ammunition_laser_ucb-100"));
        }
        private void FlyWithAnimation(int x, int y)
        {
            Api.User.Position.TargetX = x;
            Api.User.Position.TargetY = y;

            Api.User.PacketManager?.Send(new Move(Api.User.Position.X, Api.User.Position.Y, Api.User.Position.TargetX, Api.User.Position.TargetY));
            Api.User.Position.Moving = true;


            double distance = Math.Sqrt(Math.Pow((Api.User.Position.TargetX - Api.User.Position.X), 2) + Math.Pow((Api.User.Position.TargetY - Api.User.Position.Y), 2));
            double duration = (distance / Api.User.Position.Speed);
            float durationMs = (float)duration * 1000;

            Api.Tweener.TargetCancel(Api.User.Position);
            Api.Tweener.Tween(Api.User.Position, new { X = Api.User.Position.TargetX, Y = Api.User.Position.TargetY }, durationMs)
                .OnComplete(new System.Action(() => Api.User.Position.Moving = false));
            

        }
        public void FlyToCorndinates(int x, int y)
        {
            FlyWithAnimation(x, y);
        }

    }
}
