using System;

namespace DesafioBackendLeoMadeiras.Domain.Entities
{
    public class Entidade
    {
        public Entidade(Guid id, Guid criadoEm)
        {
            Id = id;
            CriadoEm = criadoEm;
        }

        public Guid Id { get; set; }
        public Guid CriadoEm { get; set; }
    }
}
