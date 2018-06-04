namespace Impersonator.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    public static class Win32Helper
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean CreateProcessWithLogonW(String lpszUsername,String lpszDomain,String lpszPassword,Int32 dwLogonFlags,String applicationName,String commandLine,
                                                            Int32 creationFlags,IntPtr environment,String currentDirectory,ref StartupInfo sui,out ProcessInformation processInfo);
    }
}
