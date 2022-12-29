using System;

namespace Patriot.DomainModel.CPTLetter
{
    public class MasterLetterCreateModel
    {
        public string Client { get; set; }
        public string Entity { get; set; }
        public string LetterType { get; set; }
        public string VisitNo { get; set; }
        public string InsuranceName { get; set; }
        public string InsuranceID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOS { get; set; }
        public decimal CheckAmount { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public DateTime ImportDate { get; set; }
        public int LetterGeneratedIndex { get; set; }
        public string LoggedUser { get; set; }
    }
}
