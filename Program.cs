namespace Creational_Builder
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*
			 * CREATIONAL
			 * SIMPLIFY THE OBJECT CONSTRUCTION PROCESS
			 */
			Console.WriteLine("I'm creating the Mac without builder");
			Mac m1 = new Mac()
			{
				Processor = "M4",
				Type = MacType.MacBookAir,
				YearProduction = "End-2024",
				Accessories = new List<MacAccesories> {
					new MacAccesories { Name = "Mouse", Price = 99.75M },
					new MacAccesories { Name = "Keyboard", Price = 19.18M }
				}
			};
			Console.WriteLine(m1.ToString());
			Console.WriteLine("I'm creating the Mac with public fluent builder");
			Mac m2 = new MacBuilder()
						 .WithProcessor("M4")
						 .WithType(MacType.MacBookAir)
						 .OfYearProdction("End-2024")
						 .WithAccesories(new MacAccesories { Name = "Mouse", Price = 99.75M })
						 .WithAccesories(new MacAccesories { Name = "Keyboard", Price = 19.18M })
						 .Build();
			Console.WriteLine(m2.ToString());
			Console.WriteLine("I'm creating the Mac with private static fluent builder");
			Mac m3 = MacBuilder.Empty()
						 .WithProcessor("M4")
						 .WithType(MacType.MacBookAir)
						 .OfYearProdction("End-2024")
						 .WithAccesories(new MacAccesories { Name = "Mouse", Price = 99.75M })
						 .WithAccesories(new MacAccesories { Name = "Keyboard", Price = 19.18M })
						 .Build();
			Console.WriteLine(m3.ToString());
			Console.WriteLine("I'm creating the Mac with private static default fluent builder");
			Mac m4 = MacBuilder.Default()
							   .Build();
			Console.WriteLine(m4.ToString());
			Console.WriteLine("I'm creating the Mac with private static default (with change) fluent builder");
			Mac m5 = MacBuilder.Default()
							   .WithType(MacType.MacMini) //you can modify default configuration
							   .Build();
			Console.WriteLine(m5.ToString());
			Console.WriteLine("I'm creating the Mac with public fluent builder, nested with another builder");
			Mac m6 = new MacBuilder()
						 .WithProcessor("M4")
						 .WithType(MacType.MacBookAir)
						 .OfYearProdction("End-2024")
						 .WithAccesories(AccessoriesBuilder.Create()
										 .WithName("Keyboard")
										 .WithPrice(19.18M)
										 .Build())
						 .WithAccesories(AccessoriesBuilder.Create()
										 .WithName("Mouse")
										 .WithPrice(99.75M)
										 .Build())
						 .Build();
			Console.WriteLine(m6.ToString());
			Console.WriteLine("I'm creating the Mac with public fluent builder, nested with another builder WITH DELEGATE");
			Console.WriteLine("Not use the static method Create to instantiate the AccessoriesBuilder");
			Mac m7 = new MacBuilder()
						 .WithProcessor("M4")
						 .WithType(MacType.MacBookAir)
						 .OfYearProdction("End-2024")
						 .WithAccesories_DELEGATE(x => x
										 .WithName("Joestick")
										 .WithPrice(39.54M)
										 )
						 .WithAccesories(AccessoriesBuilder.Create()
										 .WithName("Mouse")
										 .WithPrice(99.75M)
										 .Build())
						 .Build();
			Console.WriteLine(m7.ToString());
			Console.WriteLine("I'm creating the Mac with public fluent GUIDED builder");
			Mac m8 = MacGuidedBuilder
					 .Create()
					 .WithType(MacType.MacPro)
					 .WithProcessor("M5")
					 .OfYearProdction("MID-2024")
					 .Build();
			m8.Accessories = new List<MacAccesories>();
			Console.WriteLine(m8.ToString());
		}
	}

}
