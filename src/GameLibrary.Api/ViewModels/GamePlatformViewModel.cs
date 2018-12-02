﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Api.ViewModels
{
    public class GamePlatformViewModel
    {
        public int GameId { get; set; }

        public int PlatformId { get; set; }

        public PlatformViewModel Platform { get; set; }
    }
}
