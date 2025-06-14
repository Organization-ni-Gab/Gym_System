
using System.ComponentModel.DataAnnotations;

public class WalkIn
{

    public int CustomerId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string MiddleName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string ContactNumber { get; set; }
    [Required]
    public string Gender { get; set; }

    public int PlanId { get; set; }
    public DateTime JoinDate { get; set; } 

    public DateTime ExpiryDate { get; set; }
    public int isMember { get; set; }

    public string CompleteName()
    {
        string name = FirstName + " " + MiddleName + " " + LastName;
        return name;
    }

}

