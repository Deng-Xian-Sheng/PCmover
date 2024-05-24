using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity
{
	// Token: 0x0200000A RID: 10
	public static class WithName
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00002E96 File Offset: 0x00001096
		[SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Validation done by Guard class")]
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Validated with Guard class")]
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Need to match signature Func<Type, string>")]
		public static string TypeName(Type type)
		{
			Guard.ArgumentNotNull(type, "type");
			return type.Name;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002EA9 File Offset: 0x000010A9
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static string Default(Type type)
		{
			return null;
		}
	}
}
