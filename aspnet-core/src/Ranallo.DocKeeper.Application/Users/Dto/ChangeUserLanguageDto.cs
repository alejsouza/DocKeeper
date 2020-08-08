using System.ComponentModel.DataAnnotations;

namespace Ranallo.DocKeeper.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}