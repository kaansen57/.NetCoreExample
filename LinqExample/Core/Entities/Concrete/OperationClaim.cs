﻿using Core.Abstract;

namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
