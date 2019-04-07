using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coursework.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
    }
}