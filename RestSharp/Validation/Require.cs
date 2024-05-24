using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Validation
{
	// Token: 0x02000030 RID: 48
	public class Require
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x0000968A File Offset: 0x0000788A
		[NullableContext(1)]
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static void Argument(string argumentName, object argumentValue)
		{
			if (argumentValue == null)
			{
				throw new ArgumentException("Argument cannot be null.", argumentName);
			}
		}
	}
}
