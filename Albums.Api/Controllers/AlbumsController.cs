using System;
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
public class AlbumsController : ControllerBase
{
    private readonly Context _context;

    public AlbumsController(Context context)
    {
        _context = context;
    }

    // GET: api/Albums
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Album>>> Getalbum()
    {
        return await _context.album.ToListAsync();
    }

    // GET: api/Albums/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Album>> GetAlbum(int id)
    {
        var album = await _context.album.FindAsync(id);

        if (album == null)
        {
            return NotFound();
        }

        return album;
    }

    // PUT: api/Albums/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAlbum(int id, Album album)
    {
        if (id != album.AlbumId)
        {
            return BadRequest();
        }

        _context.Entry(album).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlbumExists(id))
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

    // POST: api/Albums
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Album>> PostAlbum(Album album)
    {
        if (album.AlbumId <= 0 || !AlbumExists(album.AlbumId))
        {
            _context.album.Add(album);
        }
        else
        {
            _context.album.Update(album);
        }
        await _context.SaveChangesAsync();
        return Ok(album);
    }

    // DELETE: api/Albums/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        if (!_context.album.Any())
        {
            return NotFound();
        }
        var album = await _context.album.FindAsync(id);
        if (album == null)
        {
            return NotFound();
        }
        _context.album.Remove(album);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool AlbumExists(int id)
    {
        return _context.album.Any(e => e.AlbumId == id);
    }
}
