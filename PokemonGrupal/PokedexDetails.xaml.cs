using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238
namespace PokemonGrupal
{
    public sealed partial class PokedexDetails : Page
    {
        private List<Pokemon> listadoPokemon;
        private string pokemonNombre;

        public PokedexDetails()
        {
            InitializeComponent();
            listadoPokemon = CargarContenidoPokemonXML();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Obtener el parámetro pasado en la navegación
            if (e.Parameter != null && e.Parameter is Dictionary<string, object> parameters)
            {
                if (parameters.TryGetValue("pokemonNombre", out object pokemonNombre))
                {
                    // Cargar los datos del Pokémon con el nombre especificado
                    this.pokemonNombre = pokemonNombre as string;
                    ImprimirDatosPokemon();
                }
            }
        }
        private List<Pokemon> CargarContenidoPokemonXML()
        {
            List<Pokemon> listado = new List<Pokemon>();
            string rutaArchivo = "ms-appx:///Datos/Pokemon.xml";
            try
            {
                StorageFile file = Task.Run(async () => await StorageFile.GetFileFromApplicationUriAsync(new Uri(rutaArchivo))).Result;
                string contenido = Task.Run(async () => await FileIO.ReadTextAsync(file)).Result;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(contenido);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    string nombre = node.SelectSingleNode("Nombre").InnerText;
                    string descripcion = node.SelectSingleNode("Descripcion").InnerText;
                    List<string> tipos = new List<string>();
                    foreach (XmlNode tipoNode in node.SelectNodes("Tipos/Tipo"))
                    {
                        tipos.Add(tipoNode.InnerText);
                    }
                    List<string> habilidades = new List<string>();
                    foreach (XmlNode habilidadNode in node.SelectNodes("Habilidades/Habilidad"))
                    {
                        habilidades.Add(habilidadNode.InnerText);
                    }
                    string imgEvolucion = node.SelectSingleNode("ImgEvolucion").InnerText;
                    string descrEvolucion = node.SelectSingleNode("DescrEvolucion").InnerText;
                    string img = node.SelectSingleNode("Img").InnerText;
                    string imgEstadisticas = node.SelectSingleNode("ImgEstadisticas").InnerText;
                    string descrEstadisticas = node.SelectSingleNode("DescrEstadisticas").InnerText;
                    Pokemon nuevoPokemon = new Pokemon(nombre, descripcion, tipos, habilidades, imgEvolucion, descrEvolucion, img, imgEstadisticas, descrEstadisticas);
                    listado.Add(nuevoPokemon);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al cargar el archivo XML: " + ex.Message);
            }
            return listado;
        }




        private void ImprimirDatosPokemon()
        {
            // Buscar el Pokémon en la lista
            var pokemonSeleccionado = listadoPokemon.FirstOrDefault(p => p.Nombre == pokemonNombre);

            if (pokemonSeleccionado != null)
            {
                // Imprimir los datos del Pokémon
                nombrePokemon.Text = pokemonSeleccionado.Nombre;
                tbDescripcion.Text = pokemonSeleccionado.Descripcion;
                tbTipos.Text = string.Join(", ", pokemonSeleccionado.Tipos);
                tbHabilidades.Text = string.Join(", ", pokemonSeleccionado.Habilidades);

                string rutaImagenPokemon = string.Format("ms-appx:///Img/{0}", pokemonSeleccionado.Img);
                BitmapImage imagen = new BitmapImage(new Uri(rutaImagenPokemon));
                imgPokemon.Source = imagen;

                string rutaImagenEvolucion = string.Format("ms-appx:///Img/{0}", pokemonSeleccionado.ImgEvolucion);
                BitmapImage imagenEvolucion = new BitmapImage(new Uri(rutaImagenEvolucion));
                imgEvolucion.Source = imagenEvolucion;

                string rutaImagenEstadisticas = string.Format("ms-appx:///Img/{0}", pokemonSeleccionado.ImgEstadisticas);
                BitmapImage imagenEstadisticas = new BitmapImage(new Uri(rutaImagenEstadisticas));
                imgEstadisticasPokemon.Source = imagenEstadisticas;

                tbDescripcionEvolucion.Text = pokemonSeleccionado.DescrEvolucion;

                tbDescripcionEstadisticas.Text = pokemonSeleccionado.DescrEstadisticas;


            }
        }





    }

}
