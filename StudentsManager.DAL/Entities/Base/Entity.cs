﻿namespace DAL.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public Entity()
        {
            Id = 0;
        }
    }
}