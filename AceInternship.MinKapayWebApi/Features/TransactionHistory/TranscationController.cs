using AceInternship.MinKapayWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AceInternship.MinKapayWebApi.Features.TransactionHistory
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscationController : ControllerBase
    {

        public IActionResult CheckCustomerCode(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                return BadRequest("Invalid Customer Code");
            }



            return Ok();
        }

        public TransactionHistoryResponseModel TransactionHistory(string customerCode)
        {
            TransactionHistoryResponseModel model = new TransactionHistoryResponseModel();
            
            return 0;
        }

        public class TransactionHistoryResponseModel
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public List<CustomerTranscationHistoryModel> Data { get; set; }
        }
    }
}
