using MayTheFourth.Application.Common.ClassBase;

namespace MayTheFourth.Application.Features.People
{
    public class GetPeopleResponse
    {
        public string Name { get; set; } = null!;
        public string Height { get; set; } = null!;
        public string Mass { get; set; } = null!;
        public string Haircolor { get; set; } = null!;
        public string Skincolor { get; set; } = null!;
        public string Eyecolor { get; set; } = null!;
        public string Birthyear { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public List<ItemDescription>? Movies { get; set; }
    }
}
