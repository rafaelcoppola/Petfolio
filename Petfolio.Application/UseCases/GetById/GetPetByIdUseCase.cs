using Petfolio.Communication.Reponses;

namespace Petfolio.Application.UseCases.GetById
{
    public class GetPetByIdUseCase
    {
        public ResponsePetJson Execute(int id)
        {
            return new ResponsePetJson
            {
                Id = id,
                Name = "Zeus",
                Birthday = new DateTime(year: 2023, month: 01, day:01),
                Type = Communication.Enums.PetType.Dog
            };
        }
    }
}