using FunnyProject.PacketHandlers;

namespace FunnyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var api = new Api(new User());
            
            Task.Run(async () => await api.StartSession());
           
        }
    }
}