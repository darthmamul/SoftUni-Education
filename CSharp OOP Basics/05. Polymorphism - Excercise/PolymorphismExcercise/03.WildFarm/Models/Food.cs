using System;
using System.Collections.Generic;
using System.Text;


abstract class Food
{
    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity { get; set; }
}

