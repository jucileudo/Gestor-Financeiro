using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Core.CommonsObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }


        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            var objDomain = obj as Entity;
            if (ReferenceEquals(this, objDomain)) return true;
            if (ReferenceEquals(null, objDomain)) return false;

            return Id.Equals(objDomain.Id);
        }

        

        public static bool operator ==(Entity a, Entity b)
        {
            if(ReferenceEquals(a,null) && ReferenceEquals(b,null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
           return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 931) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
