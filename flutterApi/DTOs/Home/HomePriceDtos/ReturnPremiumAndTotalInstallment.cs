﻿namespace flutterApi.DTOs.Home.HomePriceDtos
{
    public class ReturnPremiumAndTotalInstallment
    {
        public string? Message { get; set; }=string.Empty;
       public PremiumAndTotalInstallmentForHome? premiumAndTotal {  get; set; }

    }
}
