using System;
using System.Collections.Generic;
using System.Text;


public class Robot : SocietyMember
{
    private string model;

    public Robot(string id, string model)
        : base(id)
    {
        this.Model = model;
    }

    public string Model
    {
        get => this.model;
        private set { this.model = value; }
    }

}

