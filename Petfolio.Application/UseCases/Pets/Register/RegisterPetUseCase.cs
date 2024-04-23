using Petfolio.Communication.Reponses;
using Petfolio.Communication.Request;

namespace Petfolio.Application.UseCases.Pets.Register
{
    public class RegisterPetUseCase
    {
        public ResponseRegisterPetJson Execute(RequestRegisterPetJson request)
        {
            return new ResponseRegisterPetJson{
                Id = 7,
                Name = request.Name
            };
        }
    }
}