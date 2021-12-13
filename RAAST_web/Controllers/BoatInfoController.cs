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
        public async Task<string> GetBoatInfo()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                try
                {
                    var jsonlist = await response.Content.ReadAsStringAsync();
                    return jsonlist;
                }
                catch
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}