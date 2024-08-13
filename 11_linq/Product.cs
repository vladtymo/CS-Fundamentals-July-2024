namespace _09_linq
{
    class Product
    {
        public string Model { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product(string m, string c, decimal p)
        {
            this.Model = m;
            Category = c;
            Price = p;
        }

        public override string ToString()
        {
            return $"{Category}: {Model} - {Price}$";
        }
    }
}