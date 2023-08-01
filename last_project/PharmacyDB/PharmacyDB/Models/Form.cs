using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PharmacyDB.Models
{
    public partial class Form
    {
        public Form()
        {
            DrugForms = new HashSet<DrugForm>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<DrugForm> DrugForms { get; set; }
    }
}
