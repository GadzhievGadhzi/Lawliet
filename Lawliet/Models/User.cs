using Lawliet.Interfaces;

namespace Lawliet.Models {
    public class User : IDataModel {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PictureUrl { get; set; }

        public User() { }
        public User(string id, string? name, string? email, string? pictureUrl) {
            Id = id;
            Name = name;
            Email = email;
            PictureUrl = pictureUrl;
        }
    }
}