﻿using System.Collections.Generic;

namespace GameLibrary.Api.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PlatformTypeId { get; set; }
        public int DeveloperId { get; set; }
       // public List<PlatformViewModel> Platform { get; set; }

        public List<GamePlatformViewModel> GamePlatform { get; set; }
    }
}