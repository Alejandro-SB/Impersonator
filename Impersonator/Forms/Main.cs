namespace Impersonator
{
    using Impersonator.Classes;
    using Impersonator.Configuration;
    using Impersonator.Extensions;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public partial class Form1 : Form
    {
        private BindingList<User> Users { get; set; }

        private BindingList<Module> Modules { get; set; }

        private readonly ConfigurationHelper _helper;

        public Form1()
        {
            InitializeComponent();
            this._helper = new ConfigurationHelper();
            ReadConfiguration();
            CreateMenuItems();
            this.listUsers.DataSource = this.Users;
            this.listModules.DataSource = this.Modules;
        }

        private void ReadConfiguration()
        {
            this.Users = this._helper.GetUsers();
            this.Modules = this._helper.GetModules();
        }

        private void CreateMenuItems()
        {
            foreach(var item in this.notifyContextMenu.Items.OfType<ModuleMenuItem>().ToList())
            {
                this.notifyContextMenu.Items.Remove(item);
                item.Dispose();
            }

            foreach(var module in this.Modules)
            {
                var toolStripModule = new ModuleMenuItem(module);

                foreach (var user in this.Users)
                {
                    var toolStripUser = new UserMenuItem(user);
                    toolStripModule.DropDownItems.Add(toolStripUser);
                }

                notifyContextMenu.Items.Insert(0,toolStripModule);
            }

            notifyContextMenu.Refresh();
        }

        private void settingsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void btnAddUser_Click(object sender, System.EventArgs e)
        {
            //TODO: Add validation
            if(!string.IsNullOrEmpty(this.txtUsername.Text) && !string.IsNullOrEmpty(this.txtPassword.Text) && this.txtUsername.Text.Contains("\\"))
            {
                var domain = this.txtUsername.Text.Split('\\')[0];
                var user = this.txtUsername.Text.Split('\\')[1];
                var pwd = this.txtPassword.Text;

                this.Users.Add(new User(user, domain, pwd));
                RestoreUserControls();
                CreateMenuItems();
            }
        }

        private void listUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var index = this.listUsers.SelectedIndex;

            if (index != -1)
            {
                this.btnRemoveUser.Enabled = true;
            }
        }

        private void RestoreUserControls()
        {
            this.txtPassword.Clear();
            this.txtUsername.Clear();
            this.btnRemoveUser.Enabled = false;
            this.listUsers.SelectedIndex = -1;
        }

        private void btnRemoveUser_Click(object sender, System.EventArgs e)
        {
            this.Users.Remove((User)this.listUsers.SelectedItem);
            RestoreUserControls();
            CreateMenuItems();
        }

        private void listModules_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var index = this.listModules.SelectedIndex;

            if (index != -1)
            {
                this.btnRemoveModule.Enabled = true;
            }
        }

        private void btnRemoveModule_Click(object sender, System.EventArgs e)
        {
            if(this.listModules.SelectedIndex != -1)
            {
                this.Modules.Remove((Module)this.listModules.SelectedItem);
                RestoreModuleControls();
                CreateMenuItems();
            }
        }

        private void RestoreModuleControls()
        {
            this.txtModuleArguments.Clear();
            this.txtModuleName.Clear();
            this.txtModulePath.Clear();
            this.btnRemoveUser.Enabled = false;
            this.listModules.SelectedIndex = -1;
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            var modulePath = this.txtModulePath.Text;
            var moduleName = this.txtModuleName.Text;
            var moduleArgs = this.txtModuleArguments.Text;

            if(modulePath.IsNullOrWhitespace() || moduleName.IsNullOrWhitespace())
            {
                return;
            }

            this.Modules.Add(new Module()
            {
                Name = moduleName,
                Command = modulePath,
                Arguments = moduleArgs
            });

            RestoreModuleControls();
            CreateMenuItems();
        }

        private void btnSearchDir_Click(object sender, EventArgs e)
        {
            var dialogResult = this.ofd.ShowDialog();
            
            if(dialogResult == DialogResult.OK)
            {
                this.txtModulePath.Text = this.ofd.FileName;
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            this._helper.SaveConfiguration(this.Users, this.Modules);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}