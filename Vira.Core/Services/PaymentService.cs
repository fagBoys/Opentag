using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.DTOs.Cart;
using Berlance.Core.DTOs.Payment;
using Berlance.Core.Services.Interfaces;
using Berlance.DataLayer.Context;
using Berlance.DataLayer.Entities.payment;

namespace Berlance.Core.Services
{
    public class PaymentService:IPaymentService
    {
        private BerLanceContext _context;

        public PaymentService(BerLanceContext context)
        {
            _context = context;
        }
        public ResultDto<RequestPayDto.ResultRequestPayDto> Execute(int amount, int userId)
        {
            var user = _context.Users.Find(userId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = amount+22000,
                RequestId = Guid.NewGuid(),
                IsPay = false,
                User = user,
                PayDate = DateTime.Now,
            };
            _context.RequestPays.Add(requestPay);
            _context.SaveChanges();
            return new ResultDto<RequestPayDto.ResultRequestPayDto>()
            {
                Data = new RequestPayDto.ResultRequestPayDto()
                {
                    Guid = requestPay.RequestId,
                    Amount = requestPay.Amount,
                },
                IsSuccess = true,
            }; 
        }

        public ResultDto<RequestPayDto.ResultRequestPayDto> GetRequstPay(Guid guid)
        {
            var requestPay = _context.RequestPays.FirstOrDefault(p => p.RequestId == guid);
            if (requestPay != null)
            {
                return new ResultDto<RequestPayDto.ResultRequestPayDto>()
                {
                    Data = new RequestPayDto.ResultRequestPayDto()
                    {
                        Amount = requestPay.Amount,
                        Guid = requestPay.RequestId,
                    }
                };
            }
            else
            {
                throw new Exception("درخواست نامعتبر است");
            }
        }
    }
}
