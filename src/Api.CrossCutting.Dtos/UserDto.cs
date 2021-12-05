using System;

namespace Api.CrossCutting.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateRegister { get; set; }
        public string EmailAddress { get; set; }
        public bool Verified { get; set; }
    }
}
