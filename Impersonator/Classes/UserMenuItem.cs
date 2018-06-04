namespace Impersonator.Classes
{
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Windows.Forms;

    class UserMenuItem : ToolStripMenuItem
    {
        private readonly User _user;

        internal User GetUser()
        {
            return _user;
        }

        internal UserMenuItem(User user) : base(user.Name)
        {
            this._user = user;
            this.Click += ExecuteCommandWithUser;
        }

        internal void ExecuteCommandWithUser(object sender, EventArgs args)
        {
            var userItem = (UserMenuItem)sender;
            var moduleItem = (ModuleMenuItem)userItem.OwnerItem;

            var user = userItem.GetUser();
            var module = moduleItem.GetModule();

            StartupInfo startupInfo = new StartupInfo();

            Win32Helper.CreateProcessWithLogonW(user.Name, user.Domain, user.Password, (int)LogonFlags.LOGON_NETCREDENTIALS_ONLY, module.Name, module.Command, 0, IntPtr.Zero, Path.GetFullPath(module.Command), ref startupInfo, out _);
        }
    }
}
