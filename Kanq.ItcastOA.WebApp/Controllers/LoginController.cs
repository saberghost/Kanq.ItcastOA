using Kanq.ItcastOA.Common;
using Kanq.ItcastOA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IUserInfoService userInfoService { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string UName, string UPwd, string vcode)
        {
            string validateCode = Session["validateCode"]?.ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误");
            }
            Session["validateCode"] = null;
            if (!validateCode.Equals(vcode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误");
            }
            var userInfo = userInfoService.LoadEntities(u => u.UName == UName && u.UPwd == UPwd).FirstOrDefault();
            if (userInfo == null)
            {
                return Content("no:用户名或密码错误");
            }
            Session["userInfo"] = userInfo;
            return Content("ok:验证通过");
        }

        public ActionResult ShowValidateCode()
        {
            ValidateCode code = new ValidateCode();
            string validateCode = code.CreateValidateCode(4);
            Session["validateCode"] = validateCode;
            return File(code.CreateValidateGraphic(validateCode), "image/jpeg");
        }
    }
}