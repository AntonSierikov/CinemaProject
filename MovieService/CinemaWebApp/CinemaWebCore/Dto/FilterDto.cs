using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class FilterDto<T>
    {
        public T Entity { get; set; }

        public bool IsAvailable { get; set; }

        public FilterDto(T entity, bool isAvailable)
        {
            Entity = entity;
            IsAvailable = isAvailable;
        }
    }
}
