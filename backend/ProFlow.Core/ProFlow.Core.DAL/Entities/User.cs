using ProFlow.Core.DAL.Entities.Base;
using ProFlow.Core.DAL.Entities.HelperEntities;

namespace ProFlow.Core.DAL.Entities
{
    public class User : SqlServerEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OAuthToken { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public ICollection<UserWorkspacePermission> WorkspacePermissions { get; set; } = new List<UserWorkspacePermission>();

        public User(string userName, string firstName, string lastName, string oAuthToken, string imagePath, string email) 
        { 
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            OAuthToken = oAuthToken;
            ImagePath = imagePath;
            Email = email;
        }
    }
}
