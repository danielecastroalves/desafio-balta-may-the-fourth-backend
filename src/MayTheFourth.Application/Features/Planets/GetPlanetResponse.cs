using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayTheFourth.Application.Common.ClassBase;

namespace MayTheFourth.Application.Features.Planets
{
    public class GetPlanetResponse
    {
        public string Name { get; set; } = null!;
        public string Rotation_Period { get; set; } = null!;
        public string Orbital_Period { get; set; } = null!;
        public string Diameter { get; set; } = null!;
        public string Climate { get; set; } = null!;
        public string Gravity { get; set; } = null!;
        public string Terrain { get; set; } = null!;
        public string Surface_Water { get; set; } = null!;
        public string Population { get; set; } = null!;
        public List<string> Residents { get; set; } = null!;
        public List<ItemDescription>? Movies { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; } = null!;
    }
}
