using Escuela_Sor_Maria.Data;
using Escuela_Sor_Maria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Escuela_Sor_Maria.Models.tbProvicia;

namespace Escuela_Sor_Maria.Metodos
{
    public class Metodos
    {
        private readonly ApplicationDbContext _context;

        public Metodos(ApplicationDbContext context)
        {
            _context = context;
        }




        public static string ObtenerEstado(int tipoEstado)
        {
            switch (tipoEstado)
            {
                case 1:
                    return "Activo";
                case 2:
                    return "Suspendido";
                //case 3:
                //    return "DIMEX";
                // Agrega otros casos según corresponda
                default:
                    return "Otro Tipo";
            }
        }
        public static string ObtenerNombreTipoSexo(int tipoSexo)
        {
            switch (tipoSexo)
            {
                case 1:
                    return "Masculino";
                case 2:
                    return "Femenino";
                case 3:
                    return "No Aplica";
                // Agrega otros casos según corresponda
                default:
                    return "Otro Tipo";
            }
        }
        public static string ObtenerNombreTipoCliente(int tipocliente)
        {
            switch (tipocliente)
            {
                case 1:
                    return "Normal";
                case 2:
                    return "Contado";
                case 3:
                    return "Credito";
                // Agrega otros casos según corresponda
                default:
                    return "Otro Tipo";
            }
        }
        public static string ObtenerNombrePlazo(int tipocliente)
        {
            switch (tipocliente)
            {
                case 1:
                    return "15 Días";
                case 2:
                    return "30 Días";
                case 3:
                    return "60 Días";
                // Agrega otros casos según corresponda
                default:
                    return "Otro Tipo";
            }
        }


        public static string ObtenerNombreProvincia(List<tbProvincia> provincias, string codigo)
        {
            var provincia = provincias.FirstOrDefault(pr => pr.Cod == codigo);
            return provincia != null ? provincia.Nombre : string.Empty;
        }

        public static string ObtenerNombreCanton(List<tbCanton> cantones, string codigo, string ProvinciaID)
        {
            var canton = cantones.FirstOrDefault(ca => ca.Canton == codigo && ca.ProvinciaID == ProvinciaID);
            return canton != null ? canton.Nombre : string.Empty;
        }

        public static string ObtenerNombreDistrito(List<tbDistrito> distritos, string codigo, string codigoCanton, string ProvinciaID)
        {
            var distrito = distritos.FirstOrDefault(d => d.Distrito == codigo && d.CantonID == codigoCanton && d.ProvinciaID == ProvinciaID);
            return distrito != null ? distrito.Nombre : string.Empty;
        }

        public static string ObtenerNombreBarrio(List<tbBarrios> barrios, string codigo, string codigoDistrito, string codigoCanton, string ProvinciaID)
        {
            var barrio = barrios.FirstOrDefault(b => b.Barrio == codigo && b.DistritoID == codigoDistrito && b.CantonID == codigoCanton && b.ProvinciaID == ProvinciaID);
            return barrio != null ? barrio.Nombre : string.Empty;
        }
    }
}
