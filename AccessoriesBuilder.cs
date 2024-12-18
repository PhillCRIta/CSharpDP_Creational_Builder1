using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Builder
{
	internal class AccessoriesBuilder
	{
		string _name;
		decimal _price;

		private AccessoriesBuilder() { }

		public static AccessoriesBuilder Create() => new AccessoriesBuilder();

		public AccessoriesBuilder WithName(string name)
		{
			_name = name;
			return this;
		}
		public AccessoriesBuilder WithPrice(decimal price)
		{
			_price = price;
			return this;
		}

		public MacAccesories Build()
		{
			return new MacAccesories
			{
				Name = _name,
				Price = _price
			};
		}
	}
}
