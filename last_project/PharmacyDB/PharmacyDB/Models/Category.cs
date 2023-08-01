﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyDB.Models
{
    public partial class Category
    {
        public Category()
        {
            Drugs = new HashSet<Drug>();
        }
        [JsonIgnore]

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        [NotMapped]
        public IFormFile ImageFile;

        [JsonIgnore]
        public virtual ICollection<Drug> Drugs { get; set; }
    }
}
