﻿namespace CoffeeShop.Domain.Entities;

public class BonusCoffees
{
    public long Id { get; set; }
    
    public long BonusCoffeeId { get; set; }
    
    public BonusCoffees BonusCoffee { get; set; }
}