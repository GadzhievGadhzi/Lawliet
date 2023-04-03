using Lawliet.Interfaces;

namespace Lawliet.Models {
    public class User : IDataModel {
        public string Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PictureUrl { get; set; }
        public List<LessonTopic> Topics { get; set; }

        public User() {
            Topics = new List<LessonTopic>();
        }
    }

    public enum Gender {
        Man,
        Woman
    }

    public enum Status {
        Teacher,
        Student
    }
}