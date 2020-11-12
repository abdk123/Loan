using System.ComponentModel.DataAnnotations;

namespace LMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}