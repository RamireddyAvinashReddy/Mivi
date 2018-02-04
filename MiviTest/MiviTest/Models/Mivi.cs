using System.Collections.Generic;

using Newtonsoft.Json;

namespace MiviTest.Models
{
    public partial class Result
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("included")]
        public List<Included> Included { get; set; }
    }

    public class LoginResult
    {
        public bool IsValid { get; set; }

        public Result Result { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("type")]
        public string PurpleType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public DataAttributes Attributes { get; set; }

        [JsonProperty("links")]
        public DataLinks Links { get; set; }

        [JsonProperty("relationships")]
        public DataRelationships Relationships { get; set; }
    }

    public partial class DataAttributes
    {
        [JsonProperty("payment-type")]
        public string PaymentType { get; set; }

        [JsonProperty("unbilled-charges")]
        public object UnbilledCharges { get; set; }

        [JsonProperty("next-billing-date")]
        public object NextBillingDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first-name")]
        public string FirstName { get; set; }

        [JsonProperty("last-name")]
        public string LastName { get; set; }

        [JsonProperty("date-of-birth")]
        public System.DateTime DateOfBirth { get; set; }

        [JsonProperty("contact-number")]
        public string ContactNumber { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }

        [JsonProperty("email-address-verified")]
        public bool EmailAddressVerified { get; set; }

        [JsonProperty("email-subscription-status")]
        public bool EmailSubscriptionStatus { get; set; }
    }

    public partial class DataLinks
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public partial class DataRelationships
    {
        [JsonProperty("services")]
        public Service Services { get; set; }
    }

    public partial class Service
    {
        [JsonProperty("links")]
        public ServicesLinks Links { get; set; }
    }

    public partial class ServicesLinks
    {
        [JsonProperty("related")]
        public string Related { get; set; }
    }

    public partial class Included
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public IncludedAttributes Attributes { get; set; }

        [JsonProperty("links")]
        public DataLinks Links { get; set; }

        [JsonProperty("relationships")]
        public IncludedRelationships Relationships { get; set; }
    }

    public partial class IncludedAttributes
    {
        [JsonProperty("msn")]
        public string Msn { get; set; }

        [JsonProperty("credit")]
        public long? Credit { get; set; }

        [JsonProperty("credit-expiry")]
        public System.DateTime? CreditExpiry { get; set; }

        [JsonProperty("data-usage-threshold")]
        public bool? DataUsageThreshold { get; set; }

        [JsonProperty("included-data-balance")]
        public long? IncludedDataBalance { get; set; }

        [JsonProperty("included-credit-balance")]
        public object IncludedCreditBalance { get; set; }

        [JsonProperty("included-rollover-credit-balance")]
        public object IncludedRolloverCreditBalance { get; set; }

        [JsonProperty("included-rollover-data-balance")]
        public object IncludedRolloverDataBalance { get; set; }

        [JsonProperty("included-international-talk-balance")]
        public object IncludedInternationalTalkBalance { get; set; }

        [JsonProperty("expiry-date")]
        public System.DateTime? ExpiryDate { get; set; }

        [JsonProperty("auto-renewal")]
        public bool? AutoRenewal { get; set; }

        [JsonProperty("primary-subscription")]
        public bool? PrimarySubscription { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("included-data")]
        public object IncludedData { get; set; }

        [JsonProperty("included-credit")]
        public object IncludedCredit { get; set; }

        [JsonProperty("included-international-talk")]
        public object IncludedInternationalTalk { get; set; }

        [JsonProperty("unlimited-text")]
        public bool? UnlimitedText { get; set; }

        [JsonProperty("unlimited-talk")]
        public bool? UnlimitedTalk { get; set; }

        [JsonProperty("unlimited-international-text")]
        public bool? UnlimitedInternationalText { get; set; }

        [JsonProperty("unlimited-international-talk")]
        public bool? UnlimitedInternationalTalk { get; set; }

        [JsonProperty("price")]
        public long? Price { get; set; }
    }

    public partial class IncludedRelationships
    {
        [JsonProperty("subscriptions")]
        public Subscriptions Subscriptions { get; set; }

        [JsonProperty("service")]
        public Service Service { get; set; }

        [JsonProperty("product")]
        public Downgrade Product { get; set; }

        [JsonProperty("downgrade")]
        public Downgrade Downgrade { get; set; }
    }

    public partial class Downgrade
    {
        [JsonProperty("data")]
        public Dat Data { get; set; }
    }

    public partial class Dat
    {
        [JsonProperty("type")]
        public string PurpleType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Subscriptions
    {
        [JsonProperty("links")]
        public ServicesLinks Links { get; set; }

        [JsonProperty("data")]
        public List<Dat> Data { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}