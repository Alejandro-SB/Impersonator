namespace Impersonator.Classes
{
    public class User
    {
        internal string Name { get; set; }
        internal string Domain { get; set; }
        internal string Password { get; set; }

        public User(string username, string domain, string password)
        {
            this.Name = username;
            this.Domain = domain;
            this.Password = password;
        }

        public override string ToString()
        {
            return this.Domain + "\\" + this.Name;
        }
    }
}
