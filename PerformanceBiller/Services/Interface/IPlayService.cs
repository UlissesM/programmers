﻿namespace PerformanceBiller.Services.Interface
{
    public interface IPlayService
    {
        int calculateTotalAmount(int audience);

        int calculateVolumeCredits(int audience);
    }
}
