using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class MaterialFilterQuery
    {
        [Range(1, int.MaxValue)]
        public int typeId { get; set; } = 1;

        public bool sort { get; set; } = false;
    }
}
