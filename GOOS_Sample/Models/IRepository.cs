﻿using GOOS_Sample.Models.dataModels;

namespace GOOS_Sample.Models
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}