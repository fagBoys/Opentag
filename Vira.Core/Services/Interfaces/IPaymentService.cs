using Vira.Core.DTOs.Cart;
using Vira.Core.DTOs.Payment;
using Vira.DataLayer.Entities.payment;

namespace Vira.Core.Services.Interfaces;

public interface IPaymentService
{
    ResultDto<RequestPayDto.ResultRequestPayDto> Execute(int amount, int userId);
    ResultDto<RequestPayDto.ResultRequestPayDto> GetRequstPay(Guid guid);

}