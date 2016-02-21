using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooApp.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_AnimalName")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_AnimalOrigin")]
        public string Origin { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }

    public class Food
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_FoodName")]
        public string Name { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }

        //some code 
        //multiple animal food entity
        //hold multiple food
    }

    public class AnimalFood
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        [Required]
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Food Food { get; set; }
        [Required]
        public int Quantity { get; set; }
        //some code
    }
}
