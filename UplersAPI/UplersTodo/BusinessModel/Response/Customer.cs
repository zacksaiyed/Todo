using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Response
{
    public class PaymentMethod
    {
        public int? Id { get; set; }
        public string Method { get; set; }
    }

    public class PaymentTerm
    {
        public int? Id { get; set; }
        public string Term { get; set; }
        public int? Days { get; set; }
        public string Code { get; set; }
    }

    public class AvailablePaymentOption
    {
        public int? Id { get; set; }
        public bool IsDefault { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public object PaymentProgram { get; set; }
        public object PaymentStrategy { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
    }

    public class CorporateAddress
    {
        public string Address { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }

    public class DeliveryAddress
    {
        public string Address { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }

    public class Result
    {
        public int? Id { get; set; }
        public string State { get; set; }
        public List<int?> Managers { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Modified { get; set; }
        public DateTime NextContactDate { get; set; }
        public string Tier { get; set; }
        public string Nickname { get; set; }
        public string ExternalId { get; set; }
        public string ExtAcctId { get; set; }
        public string LicenseNumber { get; set; }
        public string OldLicenseNumber { get; set; }
        public bool LicenseInactive { get; set; }
        public string BusinessIdentifier { get; set; }
        public string Ein { get; set; }
        public string Directions { get; set; }
        public string DeliveryPreferences { get; set; }
        public string Currency { get; set; }
        public string ShippingCharge { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Dba { get; set; }
        public string BusinessLicenseName { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string OldAddress { get; set; }
        public string UnitNumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Phone { get; set; }
        public object PhoneExtension { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string LeaflinkLastViews { get; set; }
        public bool LeaflinkSource { get; set; }
        public string Reason { get; set; }
        public bool Archived { get; set; }
        public bool Delinquent { get; set; }
        public string DiscountPercent { get; set; }
        public int? Owner { get; set; }
        public int? Partner { get; set; }
        public string PriceSchedule { get; set; }
        public string ServiceZone { get; set; }
        public int? LicenseType { get; set; }
        public string PaymentTerm { get; set; }
        public List<string> PaymentMethods { get; set; }
        public string Status { get; set; }
        public string ReasonProduct { get; set; }
        public Dictionary<string, object> ExternalIds { get; set; }
        public CorporateAddress CorporateAddress { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public List<AvailablePaymentOption> AvailablePaymentOptions { get; set; }
    }

    public class Root
    {
        public int? Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public List<Result> Results { get; set; }
    }
}
