using FunnyProject.Forms;
using FunnyProject.GUIManagers;
using FunnyProject.Interfaces;
using FunnyProject.Logic;
using FunnyProject.Logic.Interface;
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
            ServerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ServerComboBox.SelectedIndex = 0;



        }

      
       
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
          
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

   

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (Api == null) return;
            BoxLogic box = new BoxLogic(Api);
            FollowModule follow = new FollowModule(Api);
            NpcKillerModule npc = new(Api);
            npc.Running = true;
            box.Running = true;
            Task.Run(async() => await box.StartMethod());
            
        }

        private void LoginPage_Resize(object sender, EventArgs e)
        {
            UsernameBox.Location = new Point(LoginPage.Width / 2 - UsernameBox.Width / 2, LoginPage.Height / 2 - UsernameBox.Height / 2);
            PasswordBox.Location = new Point(LoginPage.Width / 2 - PasswordBox.Width / 2, LoginPage.Height / 2 - PasswordBox.Height / 2 + 30);
            LoginBtn.Location = new Point(LoginPage.Width / 2 - LoginBtn.Width / 2, LoginPage.Height / 2 - LoginBtn.Height / 2 + 90);
            ServerComboBox.Location = new Point(LoginPage.Width / 2 - ServerComboBox.Width / 2, LoginPage.Height / 2 - ServerComboBox.Height / 2 + 60);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            TabPage page = new TabPage();
            UserWindow window = new UserWindow(new Api(new User(UsernameBox.Text , PasswordBox.Text , ServerComboBox.SelectedItem.ToString())));
            page.Text = UsernameBox.Text;
            window.Dock = DockStyle.Fill;
            window.FormBorderStyle = FormBorderStyle.None;
            window.TopLevel = false;
            page.Controls.Add(window);
            window.Show();
            MainTabPage.TabPages.Add(page);
            Refresh();
        }
    }
}