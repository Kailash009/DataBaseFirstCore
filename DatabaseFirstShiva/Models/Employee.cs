using System;
using System.Collections.Generic;

namespace DatabaseFirstShiva.Models;

public partial class Employee
{
    public int Eid { get; set; }

    public string? Ename { get; set; }

    public int? Eage { get; set; }

    public string? Eaddress { get; set; }

    public string? Ecity { get; set; }

    public decimal? Esalary { get; set; }
}
