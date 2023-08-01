using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PharmacyDB.Models
{
    public partial class Drug
    {
        public Drug()
        {
            DrugActiveIngredients = new HashSet<DrugActiveIngredient>();
            DrugForms = new HashSet<DrugForm>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string ArabicName { get; set; } = null!;
        public string EnglishName { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string SideEffects { get; set; } = null!;
        [JsonIgnore]
        public virtual Brand Brand { get; set; } = null!;

        [JsonIgnore]
        public virtual Category Category { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<DrugActiveIngredient> DrugActiveIngredients { get; set; }
        [JsonIgnore]
        public virtual ICollection<DrugForm> DrugForms { get; set; }
    }
}
