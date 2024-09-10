using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using Newtonsoft.Json;

namespace MyWebAPI.Controllers
{
    [Route("apiPetAdoption")]
    [ApiController]
    public class PetAdoptionController : ControllerBase
    {
        private readonly ThirdPartDataBuilder _dataBuilder;

        public PetAdoptionController(ThirdPartDataBuilder dataBuilder)
        {
            _dataBuilder = dataBuilder;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<PetAdoption>> GetAll()
        {
            string url = "https://data.moa.gov.tw/Service/OpenData/TransService.aspx?UnitId=QcbUEzN6E6DL&IsTransData=1";

            var data = await _dataBuilder.GetDataFromAPI(url);

            var collection = JsonConvert.DeserializeObject<IEnumerable<PetAdoption>>(data);//反序列化

            return collection; 

        }

        [HttpGet("Get")]
        public async Task<IEnumerable<PetAdoption>> Get(int? top, int? skip, string? filter)
        {
            string url = "https://data.moa.gov.tw/Service/OpenData/TransService.aspx?UnitId=QcbUEzN6E6DL&IsTransData=1&$top="+top * 20+"&$skip="+skip * 20+"&$filter="+filter;

            var data = await _dataBuilder.GetDataFromAPI(url);

            var collection = JsonConvert.DeserializeObject<IEnumerable<PetAdoption>>(data);//反序列化

            return collection;

        }

        [HttpGet("GetID")]
        public async Task<IEnumerable<PetAdoption>> GetID(string id)
        {
            string url = "https://data.moa.gov.tw/Service/OpenData/TransService.aspx?UnitId=QcbUEzN6E6DL&IsTransData=1&$filter=animal_id+like+" + id;

            var data = await _dataBuilder.GetDataFromAPI(url);

            var collection = JsonConvert.DeserializeObject<IEnumerable<PetAdoption>>(data);//反序列化

            return collection;

        }
    }
}
