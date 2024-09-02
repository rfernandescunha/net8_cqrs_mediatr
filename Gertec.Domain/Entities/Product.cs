using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gertec.Domain.Entities
{
    [Table("product")]
    public class Product : EntityBase<Product>
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category_name")]
        [Required]
        [StringLength(80)]
        public string CategoryName { get; set; }

        [Column("img_url")]
        [Required]
        [StringLength(300)]
        public string ImgUrl { get; set; }

        [Column("amount")]
        [Required]
        public int Amount { get; set; }

        public Product()
        {
        }

        public Product(int productId) : base(productId)
        {
        }

        public Product(string name)
        {
            Name = name.Trim();
        }

        public Product(int productId, string name) : base(productId)
        {
            Name = name.Trim();
        }

        public override void ValidateCreate(IEnumerable<Product> list)
        {
            Notifications = new List<string>();
            NotificationBlockers = new List<string>();

            if (list == null || !list.Any())
            {
                return;
            }

            if (list.Any(x => x.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                NotificationBlockers.Add($"ProductName [{Name}] already exists!");
            }
        }

        public override void ValidateDelete(IEnumerable<Product> list)
        {
            Notifications = new List<string>();
            NotificationBlockers = new List<string>();

            if (list == null)
            {
                NotificationBlockers.Add($"ProductId [{Id}] not found!");
            }

            if (!list.Any(x => x.Id == Id))
            {
                NotificationBlockers.Add($"ProductId [{Id}] not found!");
            }
        }
    }
}
