﻿using ALL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using URLshortner.Models;

namespace URLshortner.Repositories;

public class UserRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<User> GetUserById(int? ID)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.ID == ID);
    }

    public async Task<User> GetUserByUsername(string? Username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == Username);
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateUser(int? ID, User? user)
    {
        var curUser = await GetUserById(ID);
        
        curUser.Username = user.Username;
        curUser.Password = user.Password;
        await _context.SaveChangesAsync();
    }
}