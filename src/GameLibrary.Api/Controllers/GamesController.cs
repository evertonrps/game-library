﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IPlatformRepository _platformRepository;

        public GamesController(IGameRepository gameRepository, IPlatformRepository platformRepository, IMapper mapper, IUnitOfWork uow)
        {
            _gameRepository = gameRepository;
            _platformRepository = platformRepository;
            _mapper = mapper;
            _uow = uow;
        }
        // GET: api/Games
        [HttpGet]
        public Result<IEnumerable<GameViewModel>> Get()
        {
            var result = new Result<IEnumerable<GameViewModel>>();

            try
            {
                var resultado = _gameRepository.GetAll();
                var rx =resultado.Select(c => new GameViewModel { Id = c.Id, Description = c.Description, DeveloperId = c.DeveloperId, Title = c.Title} );
                result.Item = rx.ToList();  

                foreach (var item in result.Item)
                {
                    item.Platform = new List<PlatformViewModel>(_mapper.Map<List<PlatformViewModel>>(_platformRepository.GetAll().Where(c => c.GamePlatform.FirstOrDefault().GameId == item.Id).ToList()));
                }
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                return result;
            }
        }


        // GET: api/Games/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Games
        [HttpPost]
        public Result<GameViewModel> Post([FromBody] GameViewModel value)
        {
            var result = new Result<GameViewModel>();
            try
            {
                var dev = _mapper.Map<Game>(value);
                var added = _gameRepository.Add(dev);

                if (_uow.Commit().Result > 0)
                {
                    result.Item = _mapper.Map<GameViewModel>(added);
                    result.StatusCode = HttpStatusCode.Created;
                    return result;
                }
                else
                {
                    throw new Exception("Falha ao inserir");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                value.Id = 0;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Item = value;
                result.Message = ex.Message;
                return result;
            }
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
