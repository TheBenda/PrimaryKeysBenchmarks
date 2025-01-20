using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PKS.IdentityApi.Domain.Entities;

namespace PKS.IdentityApi.Infrastructure.Data;

public class IdentityUserDbContext(DbContextOptions<IdentityUserDbContext> options) : IdentityDbContext<User>(options);