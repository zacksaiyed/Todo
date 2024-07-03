using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Response
{
    public class OrderResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Order> Results { get; set; }
    }

    public class Order
    {
        public string Number { get; set; }
        public string Short_Id { get; set; }
        public string ExternalIdSeller { get; set; }
        public string ExternalIdBuyer { get; set; }
        public string ExtAcctId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string User { get; set; }
        public int? Buyer { get; set; }
        public int Seller { get; set; }
        public Customer Customer { get; set; }
        public string CustomerGroupId { get; set; }
        public string Brand { get; set; }
        public List<int> BrandIds { get; set; }
        public string Status { get; set; }
        public bool Manual { get; set; }
        public double Discount { get; set; }
        public string DiscountType { get; set; }
        public double TaxAmount { get; set; }
        public string TaxType { get; set; }
        public string FinalTax { get; set; }
        public Charge ShippingCharge { get; set; }
        public Charge Total { get; set; }
        public string PaymentTerm { get; set; }
        public List<string> PaymentMethods { get; set; }
        public object PaymentDueDate { get; set; }
        public bool Paid { get; set; }
        public string PaidDate { get; set; }
        public string ShipDate { get; set; }
        public string ShippingDetails { get; set; }
        public string Notes { get; set; }
        public string InternalNotes { get; set; }
        public string DeliveryPreferences { get; set; }
        public List<SalesRep> SalesReps { get; set; }
        public string Classification { get; set; }
        public double PaymentBalance { get; set; }
        public List<string> AvailableTransitions { get; set; }
        public DateTime Modified { get; set; }
        public bool HasSpecialRequests { get; set; }
        public int? DeliveryProvider { get; set; }
        public List<object> OrderTaxes { get; set; }
        public string DeliveryInfo { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public bool IsCombination { get; set; }
        public bool LlfPaymentMethod { get; set; }
        public double Credits { get; set; }
        public List<int> Warehouses { get; set; }
        public int FacilityId { get; set; }
        public object SplitFrom { get; set; }
        public List<PaymentOption> AvailablePaymentOptions { get; set; }
        public PaymentOption SelectedPaymentOption { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDate { get; set; }
        public string ApprovedBy { get; set; }
        public string DraftInventoryReservationDate { get; set; }
        public string OrderNumber { get; set; }
        public string OrderSellerNumber { get; set; }
        public string OrderBuyerNumber { get; set; }
        public string OrderShortNumber { get; set; }
        public string Distributor { get; set; }
        public Dictionary<string, string> ExternalIds { get; set; }
        public CorporateAddress CorporateAddress { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public List<object> OrderAdjustments { get; set; }
        public object PaymentsInvoiceStatus { get; set; }
        public List<object> TransactionFees { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Display_Name { get; set; }
        public object ExtAcctId { get; set; }
        public bool Delinquent { get; set; }
    }

    public class Charge
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
    }

    public class SalesRep
    {
        public int Id { get; set; }
        public string User { get; set; }
    }

    public class CreatedBy
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class PaymentOption
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentProgram { get; set; }
        public string PaymentStrategy { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
    }


}
