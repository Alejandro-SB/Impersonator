namespace Impersonator.Classes
{
    using System.Windows.Forms;

    class ModuleMenuItem : ToolStripMenuItem
    {
        private readonly Module _module;

        internal Module GetModule()
        {
            return _module;
        }

        internal ModuleMenuItem(Module module) : base(module.Name)
        {
            this._module = module;
        }
    }
}
