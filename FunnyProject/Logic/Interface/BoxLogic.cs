using FunnyProject.Commands.Write;
using Action = FunnyProject.Commands.Write.Action;

namespace FunnyProject.Logic.Interface
{
    public class BoxLogic : LogicInterface
    {
        public bool Running { get; set; }
        public BoxLogic(Api api) : base(api)
        {

        }
        public async Task StartMethod()
        {
            await Task.Delay(1000);
            Api.User.PacketManager?.Send(new Action("equipment_extra_cpu_cl04k-xl"));
            while (Running)
            {
                try
                {

                    if (Api.User.Position.Moving == false)
                    {
                        Random r = new Random();
                        FlyToCorndinates(r.Next(0, 21000), r.Next(0, 13000));
                    }
                    await Task.Delay(50);
                    while (Api.User.Boxes._Boxes.Count != 0)
                    {

                        Api.User.SelectedBox = ClosestBox();
                        if (Api.User.SelectedBox == null) continue;





                        FlyToCorndinates(Api.User.SelectedBox.X, Api.User.SelectedBox.Y);
                        if (Api.User.SelectedBox == null) continue;
                        while (CalculateDistance(Api.User.SelectedBox.X, Api.User.SelectedBox.Y) > 200)
                        {

                            await Task.Delay(200);
                            FlyToCorndinates(Api.User.SelectedBox.X, Api.User.SelectedBox.Y);

                        }
                        Api.User.PacketManager.Send(new CollectBox(Api.User.SelectedBox.Hash, Api.User.Position.X, Api.User.Position.Y, Api.User.SelectedBox.X, Api.User.SelectedBox.Y));
                        
                        
                        Api.User.Boxes.Remove(Api.User.SelectedBox?.Hash);
                        Api.User.SelectedBox = null;
                        

                        //while (Api.User.SelectedBox != null && i < 10)
                        //{
                        //    await Task.Delay(50);
                        //    i++;
                        //}

                        Api.User.Boxes.Remove(Api.User.SelectedBox?.Hash);
                        
                    }

                }
                catch (Exception e)
                {
                    
                }

            }
        }
    }



}
