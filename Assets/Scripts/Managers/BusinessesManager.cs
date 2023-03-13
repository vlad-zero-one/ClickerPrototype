using Game.Save;
using System.Collections.Generic;

namespace Game
{
    public class BusinessesManager
    {
        private double balance;

        private Dictionary<string, Business> businesses = new();

        public double Balance => balance;

        public Dictionary<string, Business> Businesses => businesses;

        public void AddBusiness(Business business)
        {
            businesses.Add(business.Id, business);
        }

        public bool LoadBusiness(SaveDataBusiness saveData)
        {
            if (businesses.TryGetValue(saveData.Id, out var business))
            {
                business.FromLoad(saveData);

                return true;
            }

            return false;
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
            if (business.Level > 0 && balance >= price)
            {
                SetMoney(balance - price);
                businessUpgrade.Buy();

                return true;
            }

            return false;
        }
    }
}
