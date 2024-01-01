using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGrupal
{
    internal class Pokemon
    {
        // Propiedades
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<string> Tipos { get; set; }
        public List<string> Habilidades { get; set; }
        public string ImgEvolucion { get; set; }
        public string DescrEvolucion { get; set; }
        public string Img { get; set; }
        public string ImgEstadisticas { get; set; }
        public string DescrEstadisticas { get; set; }

        // Constructor
        public Pokemon(string nombre, string descripcion, List<string> tipos, List<string> habilidades, string imgEvolucion, string descrEvolucion, string img, string imgEstadisticas, string descrEstadisticas)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Tipos = tipos;
            Habilidades = habilidades;
            ImgEvolucion = imgEvolucion;
            DescrEvolucion = descrEvolucion;
            Img = img;
            ImgEstadisticas = imgEstadisticas;
            DescrEstadisticas=descrEstadisticas;
        }
    }
}
