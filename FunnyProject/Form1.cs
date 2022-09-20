using FunnyProject.GUIManagers;
using FunnyProject.Interfaces;
using FunnyProject.PacketHandlers;

namespace FunnyProject
{
    public partial class Form1 : Form
    {
        Api Api { get; set; }
        MoveInterface Move { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetDoubleBuffered(MinimapPanel);
            
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var api = new Api(new User());
            Api = api;
            Api.User.Username = UserNameBox.Text;
            Move = new(Api);
            Api.User.Password = PasswordBox.Text;
            Task.Run(async () => await Api.StartSession());
            Task.Run(async () => await Render());
           
        }

        private async Task Render()
        {
            while(true)
            {
                try
                {
                    var bit = new Bitmap(MinimapPanel.Width, MinimapPanel.Height);
                    using (Graphics g = Graphics.FromImage(bit))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        RenderManager rd = new RenderManager(g , Api ,bit.Width , bit.Height);
                        await rd.Draw();
                        var oldimage = MinimapPanel.BackgroundImage;
                        if (MinimapPanel.InvokeRequired)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                MinimapPanel.BackgroundImage = bit;
                            });
                        }
                        else
                        {
                            MinimapPanel.BackgroundImage = bit;
                        }
                        
                        await Task.Delay(50);
                        if(oldimage != null)
                        {
                            oldimage.Dispose();
                        }
                    }
                    
                    
                    
                }
                catch(Exception ex)
                {
                    await Task.Delay(50);
                    Console.WriteLine(ex);
                }
                
            }


           
        }
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        private void MinimapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (Move == null) return;
            var ConvertX = ((double)MinimapPanel.Width / 21000);
            var ConvertY = (double)MinimapPanel.Height / 13000;

            Move.FlyToCorndinates((int)((double)e.X / ConvertX), (int)((double)e.Y / ConvertY));
            Console.WriteLine((int)(e.X * ConvertX));
        }
    }
}