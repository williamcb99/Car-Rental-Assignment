using Car_Rental.Common.Interface;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
	public int SSN {  get; set; }
	public string FirstName {  get; set; }
	public string LastName {  get; set; }

    public Customer(int ssn, string firstName, string lastName)
    {
        SSN = ssn;
        FirstName = firstName;
        LastName = lastName;
    }
}