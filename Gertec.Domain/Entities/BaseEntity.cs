using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Gertec.Domain.Entities
{
    public abstract class EntityBase<T> where T : class
    {
        [Key]
        [Column("id")]
        [JsonPropertyName("id")]       
        public int Id { get; set; }

        [JsonPropertyName("notifications")]
        public IList<string> Notifications { get; protected set; }

        [JsonPropertyName("notificationBlockers")]
        public IList<string> NotificationBlockers { get; protected set; }

        public bool HasNotificationBlockers { get { return NotificationBlockers.Any(); } }

        protected EntityBase()
        {
        }

        protected EntityBase(int id)
        {
            Id = id;
        }

        public abstract void ValidateCreate(IEnumerable<T> list);

        public abstract void ValidateDelete(IEnumerable<T> list);

        public override string ToString()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            string value = string.Empty;

            foreach (PropertyInfo property in properties)
            {
                value += $"{property.Name}: {property.GetValue(this, null)} {Environment.NewLine} | ";
            }

            return value;
        }
    }
}
