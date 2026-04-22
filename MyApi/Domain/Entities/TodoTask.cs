using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Domain.Entities
{
    [Table("task")]
    public record TodoTask
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Column("id")]
            public int Id { get; set; }

            [Column("title")]
            [MaxLength(100)]
            public string Title { get; set; }

            [Column("description")]
            [MaxLength(500)]
            public string Description { get; set; }

            [Column("duedate")]
            public DateTime DueDate { get; set; }

        //please do not forget that you still have to change this in the database using migrations!!!!!!!!!!!!!!!!!
            [Column("status")]
            public bool Status { get; set; }

            [Column("priority")]
            public int Priority { get; set; }
        
    }
}
