using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Builder
{
	internal class Mac
	{
		internal string YearProduction {  get; set; }
		internal string Processor {  get; set; }
        internal MacType Type { get; set; }
		public List<MacAccesories> Accessories { get; set; }

		public override string ToString()
		{
			return $"My new mac: {Type}-{YearProduction}, with processor: {Processor }";
		}

	}
}
