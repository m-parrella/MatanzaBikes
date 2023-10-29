using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MatanzaBikes.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace MatanzaBikes.Model
{
    public class Marca
    {
        /// <example>100</example>
        [Key]
        public int Id { get; set; }
        /// <example>Kawasaki</example>
        public string Nombre { get; set; } = null!;

    }
}