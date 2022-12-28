using System;

namespace Patriot.DomainModel.CPTLetter
{
    public class CPTLetterCreateModel
    {
        public string Client { get; set; }
        public string VisitNo { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFirstName { get; set; }
        public DateTime DOS { get; set; }
        public decimal CheckAmount { get; set; }
        public string DatesOfCPTLetter { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string DateLetterWasMailed { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public DateTime Created { get; set; }

    }
}
