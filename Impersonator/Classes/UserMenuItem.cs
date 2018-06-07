namespace Impersonator.Classes
{
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

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
            startupInfo.cb = Marshal.SizeOf(startupInfo);

            Win32Helper.CreateProcessWithLogonW(user.Name, user.Domain, user.Password, (int)LogonFlags.LOGON_NETCREDENTIALS_ONLY, null, module.Command, 0, IntPtr.Zero, null, ref startupInfo, out var pi);
        }
    }
}
