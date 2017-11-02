using System;
namespace Panor.Models.Numbers
{
    public class NumberPreview
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public Uri Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
