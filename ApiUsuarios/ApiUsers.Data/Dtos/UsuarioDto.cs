using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsers.Data.Dtos
{
    public class UsuarioDto
    {
        public int? Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
