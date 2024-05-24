using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Validation
{
	// Token: 0x0200002F RID: 47
	[NullableContext(1)]
	[Nullable(0)]
	public static class Ensure
	{
		// Token: 0x0600042E RID: 1070 RVA: 0x00009657 File Offset: 0x00007857
		public static void NotNull([Nullable(2)] object parameter, string name)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00009663 File Offset: 0x00007863
		public static void NotEmpty(string parameter, string name)
		{
			if (string.IsNullOrWhiteSpace(parameter))
			{
				throw new ArgumentNullException(name);
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00009674 File Offset: 0x00007874
		public static void NotEmptyString(object parameter, string name)
		{
			if (string.IsNullOrWhiteSpace(parameter as string))
			{
				throw new ArgumentNullException(name);
			}
		}
	}
}
