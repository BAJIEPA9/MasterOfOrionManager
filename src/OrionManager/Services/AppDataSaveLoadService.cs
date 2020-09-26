﻿using OrionManager.DataModels;
using OrionManager.Interfaces;
using Unity;

namespace OrionManager.Services
{
    internal class AppDataSaveLoadService : ISaveLoadService<AppDataModel>
    {
        public AppDataSaveLoadService(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public AppDataModel Load() =>
            //todo: actual implement
            new AppDataModel(false);

        public void Save(AppDataModel dataModel)
        {
            //todo: actual implement
        }
    }
}