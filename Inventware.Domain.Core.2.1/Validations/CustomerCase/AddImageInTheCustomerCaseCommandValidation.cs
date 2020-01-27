using Inventware.Domain.Core2.Commands.CustomerCase;


namespace Inventware.Domain.Core2.Validations.CustomerCase
{
    public class AddImageInTheCustomerCaseCommandValidation : CustomerCaseValidation<AddImageInTheCustomerCaseCommand>
    {
        public AddImageInTheCustomerCaseCommandValidation()
        {
            ValidateId();
            
            // ValidateXXXX(); Deve ser implementada uma validação que verifica se a Imagem já não foi inserida na lista.
        }
    }
}
