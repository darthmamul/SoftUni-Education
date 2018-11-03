using System;
using System.Collections.Generic;
using System.Text;


public class SocietyMember : IIdentifiable
{
    private string id;

    public SocietyMember(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        private set { this.id = value; }
    }

    public bool HasInvalidEnding(string pattern)
    {
        return this.id.EndsWith(pattern);
    }
}

