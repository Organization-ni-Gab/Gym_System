
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Protocols.Configuration;

public class Signup
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Gender { get; set; }
    public int? PlanID { get; set; }
    public DateTime? JoinDate { get; set; } 
    public DateTime? ExpiryDate { get; set; }
    public bool? isMember { get; set; }

}

