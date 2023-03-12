using System.ComponentModel.DataAnnotations;
using TestApp.Data;

namespace TestApp.Pages
{
    partial class Index
    {
        public string DisplayMessage { set; get; } = "INSERT COIN";
        public string? ChangeMessage { set; get; } = null;
        public string? ExactChangeMessage { set; get; } = null;
        public List<float> Coins { get; set; } = new List<float>();
        public float Total { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public bool ExactChange { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Coins = new List<float>() { 0.01f, 0.02f, 0.05f, 0.10f, 0.20f, 0.50f, 1.00f, 2.00f };

            Products.Add(new Product("Cola", 1.00f, 3));
            Products.Add(new Product("Crisp", 0.5f, 0));
            Products.Add(new Product("Chocolate", 0.65f, 8));
        }

        protected object AddTotal(float amount)
        {
            Total += amount;
            DisplayMessage = $"{Total} Available";
            return Total;
        }

        protected void SelectProduct(Product product) 
        {
            if (product.Price > Total)
                DisplayMessage = $"You do not have enough money {product.Name} costs £{product.Price}";
            else if (ExactChange && Total != product.Price)
                DisplayMessage = "EXACT CHANGE NEEDED";
            else if (product.Stock == 0)
                DisplayMessage = $"{product.Name} IS UNAVAIALBLE";
            else
                {           
                var change = Total - product.Price;

                if (change > 0) {
                    DisplayChange(change);
                }
            }
        }

        protected void DisplayChange(float change)
        {
            DisplayMessage = "THANK YOU";

            Thread.Sleep(2000);
            ChangeMessage = $"Your change is £{change}";
            ReturnToDefault();
        }

        protected void SetExactChange()
        {
            ExactChange = !ExactChange;
            if (ExactChange)
                ExactChangeMessage = "EXACT CHANGE NEEDED";
        }

        protected void ReturnToDefault()
        {
            Thread.Sleep(2000);
            Total = 0;
            DisplayMessage = "INSERT COIN";
        }
    }
}
