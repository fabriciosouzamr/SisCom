using System;

namespace Funcoes._Entity
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime UltimaAtualizacao { get; set; }
    }
}
