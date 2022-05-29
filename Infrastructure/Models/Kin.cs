namespace justice_technical_assestment.Infrastructure.Models
{
    public class Kin
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public string? AddressLineThree { get; set; }
        public string? AddressLineFour { get; set; }
        public string? PostalCode { get; set; }
        public Relationship Relation { get; set; }
    }

    public class KinRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public string? AddressLineThree { get; set; }
        public string? AddressLineFour { get; set; }
        public string? PostalCode { get; set; }
        public Relationship Relation { get; set; }
    }

    public enum Relationship
    {
        Daughter,
        Son,
        Mother,
        Father,
        Husband,
        Wife,
        Other
    }
}