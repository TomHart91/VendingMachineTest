namespace TestApp.Data
{
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, float price, int stock) 
        {
            Name= name;
            Price= price;
            Stock= stock;
        }
    }
}
