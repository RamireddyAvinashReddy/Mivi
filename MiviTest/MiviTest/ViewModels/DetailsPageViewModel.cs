using MiviTest.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiviTest.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        private readonly Result details;

        private string dataBalance;

        public string DataBalance
        {
            get { return dataBalance; }

            set { SetProperty(ref dataBalance, value); }
        }

        private string expiryDate;

        public string ExpiryDate
        {
            get { return expiryDate; }

            set { SetProperty(ref expiryDate, value); }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }

            set { SetProperty(ref productName, value); }
        }

        private string productPrice;

        public string ProductPrice
        {
            get { return productPrice; }

            set { SetProperty(ref productPrice, value); }
        }

        public DetailsPageViewModel(Result details)
        {
            this.details = details;

            DataBalance = "Data balance :" + GetSubscription().IncludedDataBalance.ToString();

            ExpiryDate = "Expiry date :" + GetSubscription().ExpiryDate?.ToString("dd /MM/yyyy");

            ProductName = "Name " + GetProduct().Name;
            ProductPrice = "Price  " + GetProduct().Price.ToString();
        }

        private IncludedAttributes GetSubscription()
        {
            return details.Included.Single(i => i.Type == "subscriptions").Attributes;
        }

        private IncludedAttributes GetProduct()
        {
            return details.Included.Single(i => i.Type == "products").Attributes;
        }
    }
}