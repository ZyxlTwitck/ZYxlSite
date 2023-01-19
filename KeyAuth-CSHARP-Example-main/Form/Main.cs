using System;
using System.Windows.Forms;

namespace KeyAuth
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login.KeyAuthApp.check();
            siticoneLabel1.Text = $"Current Session Validation Status: {Login.KeyAuthApp.response.success}";
            key.Text = "Username: " + Login.KeyAuthApp.user_data.username;
            expiry.Text = "Expiry: " + UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry));
            subscription.Text = "Subscription: " + Login.KeyAuthApp.user_data.subscriptions[0].subscription;
            ip.Text = "IP Address: " + Login.KeyAuthApp.user_data.ip;
            hwid.Text = "HWID: " + Login.KeyAuthApp.user_data.hwid;
            createDate.Text = "Creation date: " + UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.createdate));
            lastLogin.Text = "Last login: " + UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.lastlogin));
            subscriptionDaysLabel.Text = "Expiry in Days: "+ Login.KeyAuthApp.expirydaysleft();
            numUsers.Text = "Number of users: " + Login.KeyAuthApp.app_data.numUsers;
            numOnlineUsers.Text = "Number of online users: " + Login.KeyAuthApp.app_data.numOnlineUsers;
            numKeys.Text = "Number of licenses: " + Login.KeyAuthApp.app_data.numKeys;
            version.Text = "Current version: " + Login.KeyAuthApp.app_data.version;
            customerPanelLink.Text = "Customer panel: " + Login.KeyAuthApp.app_data.customerPanelLink;

            var onlineUsers = Login.KeyAuthApp.fetchOnline();
            onlineUsersBox.Items.Clear();
            foreach (var user in onlineUsers)
            {
                onlineUsersBox.Items.Add(user.credential);
            }
            onlineUsersBox.SelectedIndex = 0;
        }

        public static bool SubExist(string name, int len)
        {
            for (var i = 0; i < len; i++)
            {
                if (Login.KeyAuthApp.user_data.subscriptions[i].subscription == name)
                {
                    return true;
                }
            }
            return false;
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            try
            {
                dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                dtDateTime = DateTime.MaxValue;
            }
            return dtDateTime;
        }
    }
}
