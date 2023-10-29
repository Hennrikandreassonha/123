using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPP.Domain.DbObjects
{
    public interface DbEntity
    {
        public Guid Id { get; set; }
    }
}