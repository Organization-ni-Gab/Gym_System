
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
    public DateTime? JoinDate { get; set; } 
    public int? isMember { get; set;}

    public List<int>? checkBoxId { get; set; }

}

