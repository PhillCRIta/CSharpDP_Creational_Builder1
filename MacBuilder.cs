using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Builder
{
	internal class MacBuilder
	{
		private string _yearProduction;
		private string _processor;
		private MacType _type;
		private List<MacAccesories> _accessories = new List<MacAccesories>();

		//constructor should be private for static implementation
        public MacBuilder()
        {
            
        }

		public static MacBuilder Empty() => new MacBuilder();
		public static MacBuilder Default() => new MacBuilder()
						 .WithType(MacType.DEFAULT)
						 .WithAccesories(new MacAccesories { Name = "Mouse", Price = 99.75M })
						 .WithAccesories(new MacAccesories { Name = "Keyboard", Price = 19.18M });
		//you can create more static method, for each static method you can also implement checking function for correct object creation

		public MacBuilder OfYearProdction(string yearProduction)
		{
			_yearProduction = yearProduction;
			return this;
		}
		public MacBuilder WithProcessor(string processor)
		{
			_processor =processor;
			return this;
		}
		public MacBuilder WithType(MacType type)
		{
			_type = type;
			return this;
		}
		public MacBuilder WithAccesories(MacAccesories accessories)
		{
			_accessories.Add(accessories);
			return this;
		}
		/*	Action notify = () =>
			{
				Console.WriteLine("Actions are great.");
			};

			Action<int> doMath = (x) =>
			{
				Console.WriteLine($"The square of {x} is {x * x}");
			};

			Action<int, decimal> calculateDiscount = (x, y) =>
			{
				Console.WriteLine($"The discount is {x * y}");
			};
		*/
		public MacBuilder WithAccesories_DELEGATE(Action<AccessoriesBuilder> options)
		{
			AccessoriesBuilder accessory = AccessoriesBuilder.Create();
			//options IS A CALL TO THE LAMBDA/ANONYMOUS FUNCTION WHEN I CALL THIS FUNCTION (.WithAccesories_DELEGATE(X)) -- X is AccessoriesBuilder
			//FIRST I CREATE A BUILDER OBJECT
			//AFTER THAT I SET THE PROPERTY CALLING THE ANONYMOUS FUNCTION LIKE A DELEGATE FUNCTION
			options(accessory);
			_accessories.Add(accessory.Build());
			return this;
		}

		public Mac Build() {
			return new Mac
			{
				Processor = _processor,
				Type = _type,
				YearProduction = _yearProduction,
				Accessories = _accessories
			};
		}


	}
}
