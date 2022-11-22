namespace Backend.Models;

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string Student { get; set; }
    public string LoanDate { get; set; }
    public string ReturnDate { get; set; }
}