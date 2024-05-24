using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Validation
{
	// Token: 0x02000031 RID: 49
	public class Validate
	{
		// Token: 0x06000433 RID: 1075 RVA: 0x000096A3 File Offset: 0x000078A3
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static void IsBetween(int value, int min, int max)
		{
			if (value < min || value > max)
			{
				throw new ArgumentException(string.Format("Value ({0}) is not between {1} and {2}.", value, min, max));
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000096CF File Offset: 0x000078CF
		[NullableContext(1)]
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static void IsValidLength(string value, int maxSize)
		{
			if (value == null)
			{
				return;
			}
			if (value.Length > maxSize)
			{
				throw new ArgumentException(string.Format("String is longer than max allowed size ({0}).", maxSize));
			}
		}
	}
}
