using AssetManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetCurrentPositionController : ControllerBase
    {
        // GET: api/<AssetCurrentPositionController>
        [HttpGet]
        public IEnumerable<AssetPosition> Get()
        {
            using (var context = new AssetManagementContext())
            {


                IEnumerable<AssetPosition> assets = (from selAssets in context.Assets
                                                     join tag in context.Tags on selAssets.AssetTagMacAddress equals tag.TagMacAddress
                                                     join pos in context.PositionHistories on tag.TagMacAddress equals pos.PositionTag
                                                     where pos.PositionID == (from pos2 in context.PositionHistories
                                                                              where pos2.PositionTag == tag.TagMacAddress
                                                                              orderby pos2.PositionDate descending
                                                                              select pos2.PositionID
                                                                              ).First()

                                                     select new AssetPosition()
                                                     {
                                                         AssetId = selAssets.AssetId,
                                                         AssetName = selAssets.AssetName,
                                                         AssetDesc = selAssets.AssetDesc,
                                                         AssetInv = selAssets.AssetInventoryNumber,
                                                         PositionDate = pos.PositionDate,
                                                         PositionX = pos.PositionX,
                                                         PositionY = pos.PositionY

                                                     }).ToList();




                return assets;

            }

        }

        ////// GET: api/<AssetCurrentPositionController>
        //[HttpGet("{id}")] get single position
        //public PositionHistory Get(int id)
        //{
        //    using (var context = new AssetManagementContext())
        //    {
        //        Asset tag = context.Assets.Where(asset => asset.AssetId == id).First();

        //        //  context.PositionHistories.Where(pos => pos.PositionTag == tag.AssetTagMacAddress).OrderBy(o=>o.PositionDate).ToList();
        //        //'' PositionHistory context.PositionHistories.Where(pos => pos.PositionTag == tag.AssetTagMacAddress).OrderByDescending(o => o.PositionDate).First()



        //        return context.PositionHistories.Where(pos => pos.PositionTag == tag.AssetTagMacAddress).OrderByDescending(o => o.PositionDate).First();

        //    }

        //}
        //[HttpGet("{id}")] get all positions
        //public IEnumerable<PositionHistory> Get(int id)
        //{
        //    using (var context = new AssetManagementContext())
        //    {
        //        Asset tag = context.Assets.Where(asset => asset.AssetId == id).First();

        //        //    context.PositionHistories.Where(pos => pos.PositionTag == tag.AssetTagMacAddress).sorsortToList();



        //        return context.PositionHistories.Where(pos => pos.PositionTag == tag.AssetTagMacAddress).ToList();

        //    }

        //}

    }
}
