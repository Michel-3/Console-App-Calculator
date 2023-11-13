using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
	public class PropertyAccessor
	{
		internal decimal Outcome { get; set; }
		internal bool HasSucceeded { get; set; }
		internal string ErrorMessage { get; set; }
	}
}