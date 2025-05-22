using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IOT_Server_Endpoint_Grab.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IOT_Server_Endpoint_Grab.Controllers
{
    [Route("/grab")]
    [Tags("Grab Integration")]
    public class EndpointGrabController : Controller
    {

        [HttpGet("merchant/menu")]
        public ActionResult<string> GetMenuEndpoint([FromQuery] GetMenuRequest request)
        {
            Console.WriteLine("_____grab_get_menu: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Helper.LogRequest("merchant_menu", request);
            return Ok();
        }

        [HttpPost("/get_token_client")]
        public ActionResult<OauthResponse> GetToken([FromBody] OAuthRequest request)
        {
            Console.WriteLine($"_____grab_request_auth: " + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss"));
            Helper.LogRequest("get_token_client", request);
            OauthResponse OAuth2Client = new OauthResponse
            {
                expires_in = 60000,
                token_type = "Bearer",
                access_token = "testing"
            };

            return Ok(OAuth2Client);
        }

        [HttpPost("order")]
        public ActionResult<string> PostSubmitOrder([FromBody] object request)
        {
            Console.WriteLine($"_____grab_submit: " + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss"));
            Helper.LogRequest("order", request);
            return Ok();
        }


        [HttpPut("order/state")]
        public ActionResult<string> PutPushOrderState([FromBody] object request)
        {
            Console.WriteLine($"_____grab_submit: " + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss"));
            Helper.LogRequest("order_state", request);
            return Ok();
        }

        [HttpPost("")]
        public ActionResult<string> MenuSyncHook([FromBody] object request)
        {
            Console.WriteLine($"_____grab_menu_sync_hook: " + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss"));
            Helper.LogRequest("webhook", request);
            return Ok();
        }

        [HttpPost("push_grab_menu")]
        public ActionResult<string> PoshPushOrder([FromBody] object request)
        {
            Console.WriteLine($"_____grab_submit: " + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss"));
            Helper.LogRequest("push_grab_menu", request);
            return Ok();
        }

        [HttpPost("push_integration_status")]
        public ActionResult<string> PoshIntergrationStatus([FromBody] object request)
        {
            Console.WriteLine($"_____grab_submit: " + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss"));
            Helper.LogRequest("push_integration_status", request);
            return Ok();
        }


        public class GetMenuRequest
        {
            [Required]
            [StringLength(32)]
            public  string merchantID { get; set; } = default!;

            [Required]
            [StringLength(32)]
            public string partnerMerchantID { get; set; }
        }

        public class OauthResponse
        {
            public string? access_token { get; set; }
            public int? expires_in { get; set; }
            public string? token_type { get; set; }
        }

        public class OAuthRequest
        {
            [Required]
            public string client_id { get; set; }
            [Required]
            public string client_secret { get; set; }
            [Required]
            public string grant_type { get; set; }
            [Required]
            public string scope { get; set; }
        }

    }

    
}

