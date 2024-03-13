using Microsoft.EntityFrameworkCore.ChangeTracking;
using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {

        private readonly ApplicationDbContext _db;


        public CategoriaRepositorio( ApplicationDbContext db) : base(db )
        {
            _db = db;
        }

        public void Actualizar(Categoria categoria)
        {
            var categorioBD = _db.Categorias.FirstOrDefault(b => b.Id == categoria.Id);

            if(categorioBD != null) 
            {
				categorioBD.Nombre = categoria.Nombre;
				categorioBD.Descripcion = categoria.Descripcion;
				categorioBD.Estado = categoria.Estado;
                _db.SaveChanges();
            }
        }
    }
}
