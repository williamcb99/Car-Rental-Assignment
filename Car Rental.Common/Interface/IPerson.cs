namespace Car_Rental.Common.Interface;

public interface IPerson
{
    public int Id { get; set; }
    public int SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
