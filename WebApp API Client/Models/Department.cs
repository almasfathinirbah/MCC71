using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApp.Base;

namespace WebApp.Models
{
    public class Department : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Division")]
        public int DivisionId { get; set; }
        [JsonIgnore] // membuat property Division tidak di serialize menjadi JSON object
        public Division? Division { get; set; }

        public Department()
        {

        }

        public Department(int id, string name, int divisionId)
        {
            Id = id;
            Name = name;
            DivisionId = divisionId;
        }
    }
}
