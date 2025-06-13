using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionPeliculas
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Año { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
    }

    public class PeliculaService
    {
        private readonly ApplicationDbContext _context;

        public PeliculaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPelicula(string titulo, string genero, int año)
        {
            var pelicula = new Pelicula { Titulo = titulo, Genero = genero, Año = año };
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
        }

        public void ListPeliculas()
        {
            var peliculas = _context.Peliculas.ToList();
            foreach (var pelicula in peliculas)
            {
                Console.WriteLine($"ID: {pelicula.Id}, Título: {pelicula.Titulo}, Género: {pelicula.Genero}, Año: {pelicula.Año}");
            }
        }

        public void DeletePelicula(int id)
        {
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Pelicula no encontrada.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("Data Source=peliculas.db");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                var service = new PeliculaService(context);

                while (true)
                {
                    Console.WriteLine("1. Agregar Película");
                    Console.WriteLine("2. Listar Películas");
                    Console.WriteLine("3. Eliminar Película");
                    Console.WriteLine("4. Salir");
                    Console.Write("Selecciona una opción: ");

                    var opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Título de la película: ");
                            var titulo = Console.ReadLine();
                            Console.Write("Género de la película: ");
                            var genero = Console.ReadLine();
                            Console.Write("Año de estreno: ");
                            if (int.TryParse(Console.ReadLine(), out int año))
                            {
                                service.AddPelicula(titulo, genero, año);
                            }
                            else
                            {
                                Console.WriteLine("Año inválido.");
                            }
                            break;
                        case "2":
                            service.ListPeliculas();
                            break;
                        case "3":
                            Console.Write("ID de la película a eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                service.DeletePelicula(id);
                            }
                            else
                            {
                                Console.WriteLine("ID inválido.");
                            }
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }
        }
    }
}
