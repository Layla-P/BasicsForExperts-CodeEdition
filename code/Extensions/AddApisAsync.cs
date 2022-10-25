using BasicsForExperts.Web.Data;
using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;
using BasicsForExperts.Web.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BasicsForExperts.Web.Extensions;
public static class WebApplicationExtensions
{
    public static async Task<WebApplication> AddApisAsync(this WebApplication app)
    {
        //https://github.com/csharpfritz/InstantAPIs

        return app;
    }


}

