using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using RestSharp;

namespace GestionUtilisateur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollyTestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            //var retryPolicy = Policy
            //    .Handle<Exception>()
            //    .RetryAsync(5, onRetry: (exception, retryCount) =>
            //    {
            //        Console.WriteLine("Error : " + exception.Message + "... Retry Count :" + retryCount);
            //    });

            //await retryPolicy.ExecuteAsync(ApiConnection);




            //var amountToPase = TimeSpan.FromSeconds(15);

            //var retryWaitPolicy = Policy
            //    .Handle<Exception>()
            //    .WaitAndRetryAsync(5, i => amountToPase, onRetry: (exception , retryCount) =>
            //    {
            //        Console.WriteLine("Error : " + exception.Message + "... Retry Count :" + retryCount);
            //    });

            //await retryWaitPolicy.ExecuteAsync(ApiConnection);



            var retryPolicy = Policy
                .Handle<Exception>()
                .RetryAsync(5, onRetry: (exception, retryCount) =>
                {
                    Console.WriteLine("Error : " + exception.Message + "... Retry Count :" + retryCount);
                });


            var circuitPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));

            var finalPolicy = retryPolicy.WrapAsync(circuitPolicy);

            await finalPolicy.ExecuteAsync(async () =>
            {
                Console.WriteLine("Executing");
                await ApiConnectionAsync();
            });




            //await ApiConnection();
            return Ok();
        }

        private async Task ApiConnectionAsync()
        {
            var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";

            var client = new RestClient();

            var request = new RestRequest(url, Method.Get);
            request.AddHeader("accept", "application/json");
            request.AddHeader("X-RapidAPI-Key", "898eec3a69mshdd2173f426c65c5p1764b7jsnbe7d904ef645");
            request.AddHeader("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content);
            }

            else
            {
                Console.WriteLine(response.ErrorMessage);
                throw new Exception("le service est n'accesible pas ");
            }


        }
    }
}
