using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq {
    class Program {
        private static int ticks = 0;
        static void Main(string[] args) {
            var winesPlus = new LiquorStore {
                Name = "Wines Plus",
                Inventory = new List<Liquor>
            {
                new Liquor {Brand = "johnnie Walker", Price = 65, Quantity = 3},
                new Liquor {Brand = "Chivas", Price = 45, Quantity = 1},
                new Liquor {Brand = "Talisker", Price = 85, Quantity = 9},
            }
            };
            var hobos = new LiquorStore {
                Name = "Hobo Heaven",
                Inventory = new List<Liquor>
            {
                new Liquor {Brand = "GlenLivit", Price = 75, Quantity = 2},
                new Liquor {Brand = "GlenFidich", Price = 45, Quantity = 6},
                new Liquor {Brand = "Absolute", Price = 25, Quantity = 7},
            }
            };

            var stores = new List<LiquorStore> { winesPlus, hobos };

            IEnumerable<string> allLiquor = stores.SelectMany(store => store.Inventory.Select(liquor => liquor.Brand.ToUpper()));
            Console.WriteLine(string.Join(" , ", allLiquor));
            var totalCost = stores.SelectMany(store => store.Inventory).Sum(Liquor => Liquor.Price * Liquor.Quantity);
            //var totalCost = stores.Select(store => store.Inventory).SelectMany(listLiquor=>listLiquor).Sum(Liquor => Liquor.Price*Liquor.Quantity);
            Console.WriteLine("It will cost you {0} Dollars to buy all the liquor in both stores", totalCost);
            Console.ReadLine();
        }


        class LiquorStore {
            public String Name { get; set; }
            public List<Liquor> Inventory { get; set; }
        }

        class Liquor {
            public String Brand { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
