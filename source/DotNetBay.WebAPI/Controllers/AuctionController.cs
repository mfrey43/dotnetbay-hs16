using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetBay.Core;
using DotNetBay.Data.EF;
using DotNetBay.Data.Entity;
using DotNetBay.WebAPI.Models;

namespace DotNetBay.WebAPI.Controllers
{
    public class AuctionController : ApiController
    {
        private EFMainRepository _mainRepository = new EFMainRepository();

        [HttpGet]
        [Route("api/auctions")]
        public IEnumerable<AuctionDto> Get()
        {
            return _mainRepository.GetAuctions().ToList().Select(auction => new AuctionDto(auction));
        }

        [HttpGet]
        [Route("api/auctions/{id}")]
        public AuctionDto Get(long id)
        {
            Auction auction = _mainRepository.GetAuctions().First(a => a.Id == id);
            return new AuctionDto(auction);
        }
    }
}
