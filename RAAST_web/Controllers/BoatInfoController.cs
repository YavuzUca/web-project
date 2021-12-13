using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Description;
using RAAST_web.Models;
using RAAST_web.App_Start;

namespace RAAST_web.Controllers
{
    public class BoatInfoController : ApiController
    {
        private string url = "https://transceiver.hr.nl/api/rock7s";

        // GET: api/BoatInfo
        // Should return Rock7It array as JSON
        // Werkt wel als je de Rock7 verandert naar string bij 26 en bij 32 ReadAsStringAsync, alleen wordt de return JSON raar en onoverzichtelijk.
        public async Task<Rock7> GetBoatInfo()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                try
                {
                    return await response.Content.ReadAsAsync<Rock7>();
                }
                catch
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}