using Lawliet.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Lawliet.Models {
    public class User : IDataModel {
        public string Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string? AboutMe { get; set; }
        public string? Status { get; set; }
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
        Teacher = 0,
        Student = 1
    }
}