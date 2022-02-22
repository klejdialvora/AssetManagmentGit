using AssetManagment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsInGroupsController : ControllerBase
    {
        // GET: api/<AssetsInGroupsController>
        [HttpGet]
        public IEnumerable<AssetsInGroups> Get()
        {

            using (var context = new AssetManagementContext())
            {

                IEnumerable<AssetsInGroups> assets = (from groups in context.Groups
                                                      join groupsAssets in context.AssetGroups on groups.GroupId equals groupsAssets.GroupId

                                                      select new AssetsInGroups()
                                                      {
                                                          GroupId = groups.GroupId,
                                                          GroupName = groups.GroupName,
                                                          assets = (from asset in context.Assets
                                                                    join groupsAssets2 in context.AssetGroups on asset.AssetId equals groupsAssets2.AssetId
                                                                    where groupsAssets2.GroupId == groups.GroupId
                                                                    select new Asset()
                                                                    {
                                                                        AssetId = asset.AssetId,
                                                                        AssetDesc = asset.AssetDesc,
                                                                    })
                                                                    .ToList()



                                                      }).ToList();

                return assets;
            }

        }
    }
}
