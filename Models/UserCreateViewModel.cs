namespace AdminPage.Models
{
    public class UserCreateViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<RoleDto> Roles { get; set; }
        public int RoleId { get; set; }
    }
}
