using ApiVerse.UI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiVerse.UI.Context
{
    public class ApiVerseContext : IdentityDbContext<AppUser>
    {
        public ApiVerseContext(DbContextOptions<ApiVerseContext> options) : base(options) { }

    }
}
