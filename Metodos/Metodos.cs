using Escuela_Sor_Maria.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Escuela_Sor_Maria.Metodos
{
    public class Metodos
    {
        private readonly ApplicationDbContext _context;

        public Metodos(ApplicationDbContext context)
        {
            _context = context;
        }
        
    }
}
