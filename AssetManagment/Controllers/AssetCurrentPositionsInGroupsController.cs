using AssetManagment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetCurrentPositionsInGroupsController : ControllerBase
    {
       

        // GET api/<AssetCurrentPositionsInGroupsController>/5
        [HttpGet("{id}")]
        public IEnumerable<AssetPosition> Get(int id)
        {
            using (var context = new AssetManagementContext())
            {


                IEnumerable<AssetPosition> assets = (from selAssets in context.Assets
                                                     join tag in context.Tags on selAssets.AssetTagMacAddress equals tag.TagMacAddress
                                                     join pos in context.PositionHistories on tag.TagMacAddress equals pos.PositionTag
                                                     join gro in context.AssetGroups on selAssets.AssetId equals gro.AssetId

                                                     where pos.PositionID == (from pos2 in context.PositionHistories
                                                                              where pos2.PositionTag == tag.TagMacAddress
                                                                              orderby pos2.PositionDate descending
                                                                              select pos2.PositionID
                                                                              ).First()

                                                     where gro.GroupId == id
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


       
    }
}
