using System;
using System.Collections.Generic;
using System.Text;


public interface ICar
{
    string Model { get; }
    string Driver { get; }

    string UseBrakes();
    string UseGasPedal();
}

