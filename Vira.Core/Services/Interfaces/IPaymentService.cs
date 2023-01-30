using Berlance.Core.DTOs.Cart;
using Berlance.Core.DTOs.Payment;
using Berlance.DataLayer.Entities.payment;

namespace Berlance.Core.Services.Interfaces;

public interface IPaymentService
{
    ResultDto<RequestPayDto.ResultRequestPayDto> Execute(int amount, int userId);
    ResultDto<RequestPayDto.ResultRequestPayDto> GetRequstPay(Guid guid);

}