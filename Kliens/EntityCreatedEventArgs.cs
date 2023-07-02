using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliens
{
    public class EntityCreatedEventArgs : EventArgs
    {
        public MealDTO CreatedEntity { get; set; }

        public EntityCreatedEventArgs(MealDTO entity)
        {
            this.CreatedEntity = entity;
        }
    }
}
