using Car_Rental.Common.Interface;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; set; }
	public int SSN {  get; set; }
	public string FirstName {  get; set; }
	public string LastName {  get; set; }

    public Customer(int id, int ssn, string firstName, string lastName)
    {
        Id = id;
        SSN = ssn;
        FirstName = firstName;
        LastName = lastName;
    }
}