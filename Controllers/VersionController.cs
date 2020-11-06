﻿  
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using LAB1.Models;

namespace LAB1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
       
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var versionInfo = new Version
            {
                Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
                ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
            };

            return Ok(versionInfo);
        }
    }
}