
using System;

namespace VolvoLab.Caminhoes.MVC.Models
{
    public class CaminhaoViewModel
    {
        public Guid Id { get; set; }

        public string NumSerie { get; set; }

        public string Modelo { get; set; }

        public int AnoFab { get; set; }

        public int AnoMod { get; set; }
    }
}
