namespace Impersonator.Classes
{
    using System.Windows.Forms;

    class UserMenuItem : ToolStripMenuItem
    {
        private readonly User _user;

        internal UserMenuItem(User user) : base(user.Name)
        {
            this._user = user;
        }
    }
}
