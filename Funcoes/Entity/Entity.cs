using System;
using System.Collections.Generic;
using System.Text;

namespace Funcoes.Classes
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
