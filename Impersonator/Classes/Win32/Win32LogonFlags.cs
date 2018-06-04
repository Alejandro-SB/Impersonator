namespace Impersonator.Classes
{
    using System;

    [Flags]
    public enum LogonFlags
    {
        None = 0,
        LOGON_WITH_PROFILE = 1,
        LOGON_NETCREDENTIALS_ONLY = 2
    }
}
