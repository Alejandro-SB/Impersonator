namespace Impersonator.Classes
{
    public class User
    {
        internal string Name { get; set; }
        internal string Domain { get; set; }
        internal string Password { get; set; }
        internal bool AuthenticateNetwork { get; set; }

        public User(string username, string domain, string password, bool authenticate)
        {
            this.Name = username;
            this.Domain = domain;
            this.Password = password;
            this.AuthenticateNetwork = authenticate;
        }

        public override string ToString()
        {
            return this.Domain + "\\" + this.Name + (this.AuthenticateNetwork ? " (/netonly)" : string.Empty);
        }
    }
}
