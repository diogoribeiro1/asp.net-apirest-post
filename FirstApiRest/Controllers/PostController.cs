using FirstApiRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{

    private readonly MySQLContext _context;

    public PostController(MySQLContext context)
    {
        _context = context;
    }

    [HttpGet("listAllPosts")]
    public async Task<ActionResult> ListPosts()
    {
        List<Post> list = await _context.Posts.ToListAsync();
        return Ok(list);
    }

    [HttpGet("findPostById")]
    public async Task<ActionResult> GetPost([FromQuery] int postId)
    {
        Post item = await _context.Posts.FindAsync(postId);
        if (item == null)
        {
            return NoContent();
        }
        return Ok(item);
    }

    [HttpPost("createPost")]
    public async Task<ActionResult> NewPost([FromBody] Post post)
    {
        post.Data = DateTime.Now;
        var ret = await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        ret.State = EntityState.Detached;
        return Ok(ret.Entity);
    }

    [HttpPut("updatePost")]
    public async Task<ActionResult> UpdatePost([FromBody] Post post)
    {
        _context.Entry(post).State = EntityState.Modified;
        return Ok(await _context.SaveChangesAsync());
    }

    [HttpDelete("deletePost")]
    public async Task<ActionResult> DeletePost([FromBody] int id)
    {
        var item = await _context.Posts.FindAsync(id);
        if (item == null)
        {
            return BadRequest();
        }
        _context.Posts.Remove(item);
        await _context.SaveChangesAsync();
        return Ok(true);
    }
}
   