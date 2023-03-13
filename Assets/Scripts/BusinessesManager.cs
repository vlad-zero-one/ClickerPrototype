using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BusinessesManager
    {
        private double balance;

        private List<Business> businesses = new();

        public double Balance => balance;

        public List<Business> Businesses => businesses;

        public void AddBusiness(Business business)
        {
            businesses.Add(business);
        }

        public void AddMoney(double amount)
        {
            balance += amount;
        }

        public void SetMoney(double amount)
        {
            balance = amount;
        }

        public bool LevelUp(Business business)
        {
            if (balance >= business.LevelUpPrice)
            {
                SetMoney(balance - business.LevelUpPrice);
                business.LevelUp();

                return true;
            }

            return false;
        }

        public bool BuyUpgrade(Business business, BusinessUpgrade businessUpgrade)
        {
            var price = businessUpgrade.Price;
            if (balance >= price)
            {
                SetMoney(balance - price);
                businessUpgrade.Buy();

                return true;
            }

            return false;
        }
    }
}
