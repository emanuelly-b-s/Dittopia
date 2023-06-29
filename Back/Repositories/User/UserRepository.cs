using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using Back.Repositories;
using SecurityService;

namespace Back.Repositories.User;

public class UserRepository : IUserRepository<UserBaddit>
{
    private BadditContext ctx;

    public UserRepository(BadditContext ctx) => this.ctx = ctx;

    public async Task<bool> ExistingEmail(string userNickName)
        => await ctx.UserBaddits
                    .AnyAsync(u => u.NickUser == userNickName);

    public async Task<bool> ExistingNickName(string userEmail)
    => await ctx.UserBaddits
                .AnyAsync(u => u.Email == userEmail);

    public async Task Add(UserBaddit obj)
    {
        await ctx.UserBaddits.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public void Delete(UserBaddit obj)
    {
        ctx.UserBaddits.Remove(obj);
        ctx.SaveChangesAsync();
    }

    public async Task<List<UserBaddit>> Filter(Expression<Func<UserBaddit, bool>> condition)
    {
        return await ctx.UserBaddits
            .Where(condition)
            .ToListAsync();
    }

    public void Update(UserBaddit obj)
    {
        ctx.UserBaddits.Update(obj);
        ctx.SaveChangesAsync();
    }

}

