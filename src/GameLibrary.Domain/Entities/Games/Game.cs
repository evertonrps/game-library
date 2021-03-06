﻿using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;

namespace GameLibrary.Domain.Entities.Games
{
    public class Game : Entity<Game>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int DeveloperId { get; private set; }

        public Game()
        {
        }

        private Game(string title, string _description, int _DeveloperId)
        {
            Title = title;
            Description = _description;
            DeveloperId = _DeveloperId;
        }

        public static Game Factory(string title, string description, int developerId)
        {
            var game = new Game(title, description, developerId);
            game.ValidateNow(new GameValidator(), game);
            return game;
        }

        //EF
        public virtual Developer Developer { get; set; }

        //public virtual ICollection<Platform> Platform { get; set; }

        public virtual ICollection<GamePlatform> GamePlatform { get; set; }
    }
}