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
        protected IMapper _mapper { get; private set; }
        protected AppConfig _appSettings { get; private set; }

        public BaseController(IMapper mapper, IOptions<AppConfig> appSettings)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
    }
}
