﻿using System;
using System.Collections.Generic;
using System.Text;


public class Pokemon
{
    //Pokemon have a name, an element and health
    public string Name { get; set; }
    public string Element { get; set; }
    public int Health { get; set; }

    public Pokemon(string name, string element, int health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }
}
