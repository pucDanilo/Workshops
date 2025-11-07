using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Language
    {
        [Key]
        public int Id { get; set; }

        public string LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int TenantId { get; set; }
    }
}