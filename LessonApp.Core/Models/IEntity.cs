using System;

namespace LessonApp.Core.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
