﻿using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System.Collections.Generic;

namespace GameLibrary.Domain.Entities.Games
{
    public class PlatformType : Entity<PlatformType>
    {
        public PlatformType()
        {
        }

        public PlatformType(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public virtual ICollection<Platform> Platforms { get; set; }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateDescription();
            ValidationResult = Validate(this);
        }

        private void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage(Messages.GameTitleInvalid)
                .Length(2, 150).WithMessage(Messages.GameTitleInvalid);
        }
    }
}