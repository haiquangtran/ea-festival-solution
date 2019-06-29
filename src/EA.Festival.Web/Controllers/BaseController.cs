using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EA.Festival.ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EA.Festival.Web.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        protected AppConfig _appSettings { get; private set; }

        public BaseController(IOptions<AppConfig> appSettings)
        {
            _appSettings = appSettings.Value;
        }
    }
}
