﻿namespace FeederDotNet.Services
{
    public interface IPredictionServices
    {
        
        Task TrainAsync();
        
        Task PredictDataSetTest();

    }
}
