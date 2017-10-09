using Nop.Core;
using Nop.Services.Helpers;
using Nop.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Admin.Controllers
{
    public class ServerController : BaseAdminController
    {
        #region Fields
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;
        #endregion

        #region Ctor

        public ServerController(IWorkContext workContext,
            IPermissionService permissionService)
        {
            this._workContext = workContext;
            this._permissionService = permissionService;
        }

        #endregion

        // GET: Server/ServerStatistics/5
        public ActionResult ServerStatistics(string ip)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel))
                return Content("");

            //a vendor doesn't have access to this report
            if (_workContext.CurrentVendor != null)
                return Content("");

            return PartialView();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LoadServerStatistics(string ip)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel))
                return Content("");

            //a vendor doesn't have access to this report
            if (_workContext.CurrentVendor != null)
                return Content("");

            var result = new List<object>();

            result.Add(new
            {
                value = ""
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
