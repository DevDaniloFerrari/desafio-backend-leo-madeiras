using System;

namespace DesafioBackendLeoMadeiras.Domain.Entities
{
    public class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
