using Api.Resources;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService musicService;
        private readonly IMapper mapper;

        public MusicController(IMusicService musicService, IMapper mapper)
        {
            this.musicService = musicService;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicResource>>> GetAllMusics()
        {
            IEnumerable<Music> musics = await this.musicService.GetAllWithArtist();
            IEnumerable<MusicResource> musicResources = this.mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);
            return Ok(musicResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicResource>> GetMusicById(int id)
        {
            Music music = await this.musicService.GetMusicById(id);
            MusicResource musicResource = this.mapper.Map<Music, MusicResource>(music);
            return Ok(musicResource);
        }
    }
}
