using Microsoft.EntityFrameworkCore;
using PersonasAPI.Data;
using PersonasAPI.Entities;

namespace PersonasAPI.Repositories
{
    public class PersonasRepository: ICrudRepository<Persona, long>
    {
        private readonly ApplicationDbContext context;

        public PersonasRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Persona persona)
        {
            context.Remove(persona);
            this.Save();
        }

        public IEnumerable<Persona> GetAll()
        {
            return context.Personas.Include(p => p.Autos).Include(p => p.Titulos).ToList();
        }

        public Persona? GetById(long document)
        {
            return context.Personas.Include(p => p.Autos).Include(p => p.Titulos).FirstOrDefault(x => x.Documento == document);
        }

        public void Add(Persona persona)
        {
            context.Personas.Add(persona);
            this.Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Persona persona)
        {
            context.Update(persona);
            this.Save();
        }
    }
}
