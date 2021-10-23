using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEB_953504_Kozlovski.Data;
using WEB_953504_Kozlovski.Entities;

[assembly: HostingStartup(typeof(WEB_953504_Kozlovski.Areas.Identity.IdentityHostingStartup))]
namespace WEB_953504_Kozlovski.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}