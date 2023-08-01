using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PharmacyDB.Models
{
    public partial class ActiveIngredient
    {
        public ActiveIngredient()
        {
            DrugActiveIngredients = new HashSet<DrugActiveIngredient>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<DrugActiveIngredient> DrugActiveIngredients { get; set; }
    }
}
