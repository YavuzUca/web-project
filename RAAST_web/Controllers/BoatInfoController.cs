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
using System.Net.Http.Json;
using System.Web.Http.Results;
using System.Web.Http.Description;
using RAAST_web.Models;
using RAAST_web.App_Start;
using System.Text.Json;

namespace RAAST_web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BoatInfoController : ApiController
    {
        private string url = "https://transceiver.hr.nl/api/rock7s";
        private Data db = new Data();


        // GET: api/BoatInfo
        // Should return Rock7It array as JSON
        public async void GetBoatInfo()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(request))
            {
                try
                {
                    Rock7 data = JsonSerializer.Deserialize<Rock7>(await response.Content.ReadAsStringAsync());
                    foreach (Rock7It item in data.Rock7Item)
                    {
                        if (db.Boat_Info.Any(m => m.idName == item.IdString)) return;

                        Boat_Info record = new Boat_Info
                        {
                            idName = item.IdString,
                            longitude = item.SourceLon,
                            latitude = item.SourcaLat,
                            temperature = item.Temp1,
                            wind_Direction = item.WindDirection,
                            boat_Speed = item.Speed,
                            Date_Time = item.DateReceived,
                        };

                        db.Boat_Info.Add(record);
                    }
                    db.SaveChanges();
                }
                catch
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


    }
}