using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatanzaBikes.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace MatanzaBikes.Model
{
    public class Moto
    {
        /// <example>100</example>
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        /// <example>100</example>
        [Required]
        public int MarcaId { get; set; }
        /// <example>KLT 650</example>
        [Required]
        public string Modelo { get; set; } = null!;
        /// <example>650</example>
        [Required]
        [Range(125, 2500)]
        public string Cilindrada { get; set; } = null!;
        /// <example>Verde</example>
        [Required]
        public string Color { get; set; } = null!;
        /// <example>2023</example>
        [Required]
        [Range(2000, 2023)]
        public int Año { get; set; }
        /// <example>4 tiempos</example>
        [Required] 
        public string Motor { get; set; } = null!;
        /// <example>12</example>
        [Required]
        [Range(7, 12)]
        public string Bateria { get; set; } = null!;
        /// <example>160</example>
        [Required]
        [Range(40, 300)]
        public int Peso { get; set; }
        /// <example>118</example>
        [Required] 
        public double Rodado { get; set; }
        /// <example>Hidraulica</example>
        [Required] 
        public string Suspension { get; set; } = null!;
        /// <example>Disco</example>
        [Required] 
        public string Frenos { get; set; } = null!;
        /// <example>15</example>
        [Required]
        [Range(1, 1000)]
        public int Stock { get; set; }
        /// <example>11067000</example>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
    }
}
