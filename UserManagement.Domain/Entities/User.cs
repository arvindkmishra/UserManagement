namespace UserManagement.Domain.Entities
{
    public class User
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        public User(string name, string email)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            IsActive = true;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
