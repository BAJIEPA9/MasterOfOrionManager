﻿using System;
using System.Collections.Generic;
using OrionManager.Common.DataModels;

namespace OrionManager.Common.Interfaces
{
    public interface IGameConfigurationService
    {
        IEnumerable<GameConfigurationDataModel> Load();
        void Delete(Guid id);
        void Save(GameConfigurationDataModel dataModel);
    }
}