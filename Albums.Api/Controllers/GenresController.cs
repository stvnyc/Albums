﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Albums.Api.DAL;
using Albums.Data.Models;

namespace Albums.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly Context _context;

    public GenresController(Context context)
    {
        _context = context;
    }

    // GET: api/Genres
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> Getgenre()
    {
        return await _context.genre.ToListAsync();
    }

    // GET: api/Genres/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetGenre(int id)
    {
        var genre = await _context.genre.FindAsync(id);

        if (genre == null)
        {
            return NotFound();
        }

        return genre;
    }

    // PUT: api/Genres/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGenre(int id, Genre genre)
    {
        if (id != genre.GenreId)
        {
            return BadRequest();
        }

        _context.Entry(genre).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GenreExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Genres
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Genre>> PostGenre(Genre genre)
    {
        if (genre.GenreId <= 0 || !GenreExists(genre.GenreId))
        {
            _context.genre.Add(genre);
        }
        else
        {
            _context.genre.Update(genre);
        }
        await _context.SaveChangesAsync();
        return Ok(genre);
    }

    // DELETE: api/Genres/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        if (!_context.genre.Any())
        {
            return NotFound();
        }
        var genre = await _context.genre.FindAsync(id);
        if (genre == null)
        {
            return NotFound();
        }
        _context.genre.Remove(genre);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool GenreExists(int id)
    {
        return _context.genre.Any(e => e.GenreId == id);
    }
}
