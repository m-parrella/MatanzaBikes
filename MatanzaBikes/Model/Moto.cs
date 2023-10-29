using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace MatanzaBikes.Model
{
    public class Moto
    {
        /// <example>100</example>
        [Key]
        public int Id { get; set; }
        /// <example>100</example>
        public int MarcaId { get; set; }
        /// <example>KLT 650</example>
        public string Modelo { get; set; } = null!;
        /// <example>650</example>
        public string Cilindrada { get; set; } = null!;
        /// <example>Verde</example>
        public string Color { get; set; } = null!;
        /// <example>2023</example>
        public int Año { get; set; }
        /// <example>4 tiempos</example>
        public string Motor { get; set; } = null!;
        /// <example>12</example>
        public string Bateria { get; set; } = null!;
        /// <example>160</example>
        public int Peso { get; set; }
        /// <example>118</example>
        public double Rodado { get; set; }
        /// <example>Hidraulica</example>
        public string Suspension { get; set; } = null!;
        /// <example>Disco</example>
        public string Frenos { get; set; } = null!;
        /// <example></example>
        public string ImagenUrl { get; set; } = null!;
        /// <example>11067000</example>
        public double Precio { get; set; }
    }
}
