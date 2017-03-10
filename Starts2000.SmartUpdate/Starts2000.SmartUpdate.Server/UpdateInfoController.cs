using System;
using System.Collections.Generic;
using System.Web.Http;
using Starts2000.SmartUpdate.Server.Dal;
using Starts2000.SmartUpdate.Server.Models;

namespace Starts2000.SmartUpdate.Server
{
    public class UpdateInfoController : ApiController
    {
        readonly UpdateInfoDal _updateInfoDal = new UpdateInfoDal();

        [HttpGet]
        [Route("updateinfo/{clientType:int}/{lastUpdateTime?}")]
        public UpdateInfo Get(int clientType, DateTime? lastUpdateTime)
        {
            if (!lastUpdateTime.HasValue)
            {
                lastUpdateTime = DateTime.MinValue;
            }

            var info = _updateInfoDal.Get(clientType, lastUpdateTime);
            if (info == null)
            {
                info = new UpdateInfo
                {
                    HasNewVersion = false
                };
            }
            else
            {
                info.HasNewVersion = true;
                info.LastUpdateTime = DateTime.Now;
            }

            return info;
        }

        [HttpGet]
        [Route("managerxx/updateinfo/list")]
        public IEnumerable<UpdateInfo> GetList()
        {
            return _updateInfoDal.GetList();
        }

        [HttpPost]
        [Route("managerxx/updateinfo/add")]
        public bool Add(UpdateInfo info)
        {
            return _updateInfoDal.Add(info);
        }

        [HttpGet]
        [Route("mamangerxx/updateinfo/delete/{id:int}")]
        public bool DeleteById(int id)
        {
            return _updateInfoDal.Delete(id);
        }
    }
}