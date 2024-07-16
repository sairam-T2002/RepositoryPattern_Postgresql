using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Usr_Nam { get; set; }
        public string Pwd { get; set; }
        public string E_Mail { get; set; }
    }
}
