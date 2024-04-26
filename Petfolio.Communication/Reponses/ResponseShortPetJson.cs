using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Reponses
{
    public class ResponseShortPetJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public PetType Type { get; set; }
    }
}