namespace Impersonator.Classes
{
    using System.Diagnostics;

    public class Module
    {
        public string Name { get; set; }

        public string Command { get; set; }

        public string Arguments { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
