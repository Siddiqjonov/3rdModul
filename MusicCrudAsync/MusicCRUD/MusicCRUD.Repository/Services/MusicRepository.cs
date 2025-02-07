﻿using Microsoft.EntityFrameworkCore;
using MusicCRUD.DataAccess;
using MusicCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.Repository.Services;

public class MusicRepository : IMusicRepository
{
    private readonly MainContext _mainContext;

    public MusicRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<Guid> AddAsync(Music music)
    {
        await _mainContext.Music.AddAsync(music);
        await _mainContext.SaveChangesAsync(); // return int intager of raws that has been changed in the database
        return music.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
        var music = await GetByIdAsync(id);
        _mainContext.Music.Remove(music);
        _mainContext.SaveChanges();
    }

    public async Task<List<Music>> GetAllAsync()
    {
        var allMusic = await _mainContext.Music.ToListAsync();
        return allMusic;
    }

    public async Task<Music> GetByIdAsync(Guid id)
    {
        var music = await _mainContext.Music.FirstOrDefaultAsync(mus => mus.Id == id); // ?? throw new NullReferenceException();
        if (music == null)
            throw new NullReferenceException();
        return music;
    }

    public async Task UpdateAsync(Music music)
    {
        var musicFromDb = await GetByIdAsync(music.Id);
        _mainContext.Music.Update(musicFromDb);
        _mainContext.SaveChanges();
    }
}
