using System.Collections.Generic;

namespace VolvoLab.Caminhoes.MVC.Models
{
    public class PageViewModel<T>
    {
        public IEnumerable<T> List { get; set; }

        public T Obj { get; set; }

    }
}
