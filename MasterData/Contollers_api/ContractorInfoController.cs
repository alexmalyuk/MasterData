using Common;
using MasterData.Models;
using MD.Data.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace MasterData.Contollers_api
{
    public class ContractorInfoController : ApiController
    {
        private MdContext db = new MdContext();

        [HttpGet]
        [Route("api/ContractorInfo/{NodeAlias}")]
        public JsonResult<List<ContractorInfo>> Get(string NodeAlias)
        {
            throw new NotImplementedException();

            //return Json(new List<ContractorInfo>());
        }

        [HttpGet]
        [Route("api/ContractorInfo/{NodeAlias}/{NativeId}")]
        public ContractorInfo Get(string NodeAlias, string NativeId)
        {
            ContractorInfo contractorInfo = ContractorInfo.GetByNativeId(NativeId, NodeAlias);
            return contractorInfo;
        }

        [HttpPost]
        [Route("api/ContractorInfo/{NodeAlias}")]
        public bool Post(string NodeAlias, [FromBody]ContractorInfo contractorInfo)
        {
            try
            {
                contractorInfo.NodeAlias = NodeAlias;
                contractorInfo.Save();
            }
            catch (Exception ex)
            {
                Log.For(this).Error("[HttpPost][Route(\"api/ContractorInfo/{NodeAlias}\")]", ex);
            }

            return true;
        }
    }
}
