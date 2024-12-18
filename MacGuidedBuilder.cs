using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Builder
{
	internal class MacGuidedBuilder
	{
		public List<MacAccesories> _accessories = new List<MacAccesories>();

		//constructor should be private for static implementation
		private MacGuidedBuilder() { }
		public static MacGuidedBuilderStep1 Create() => new MacGuidedBuilderStep1();
		internal class MacGuidedBuilderStep1
		{
			public MacGuidedBuilderStep2 WithType(MacType type)
			{
				return new MacGuidedBuilderStep2(type);
			}
		}
		internal class MacGuidedBuilderStep2
		{
			private MacType type;
			public MacGuidedBuilderStep2(MacType type)
			{
				this.type = type;
			}
			public MacGuidedBuilderStep3 WithProcessor(string processor)
			{
 				return new MacGuidedBuilderStep3(this.type, processor);
			}
		}
		internal class MacGuidedBuilderStep3 
		{
			private string processor;
			private MacType type;
			private string _yyearProduction;
			public MacGuidedBuilderStep3(MacType type, string processor)
			{
				this.type = type;
				this.processor = processor;
			}
			public MacGuidedBuilderStep3 OfYearProdction(string yearProduction)
			{
				_yyearProduction = yearProduction;
				return this;
			}
			public Mac Build()
			{
				return new Mac
				{
					Processor = processor,
					Type = type,
					YearProduction = _yyearProduction
				};
			}

		}
		public MacGuidedBuilder WithAccesories(MacAccesories accessories)
		{
			_accessories.Add(accessories);
			return this;
		}
	}
}
