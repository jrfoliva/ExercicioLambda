using System.Globalization;
namespace ExercicioLambda.Entities
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return "Product: "+ Name + ", Price: $ "+Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
