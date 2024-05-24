using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Practices.Unity
{
	// Token: 0x02000006 RID: 6
	public abstract class RegistrationConvention
	{
		// Token: 0x06000021 RID: 33
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
		public abstract IEnumerable<Type> GetTypes();

		// Token: 0x06000022 RID: 34
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "API is easier to use with nested generics")]
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
		public abstract Func<Type, IEnumerable<Type>> GetFromTypes();

		// Token: 0x06000023 RID: 35
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
		public abstract Func<Type, string> GetName();

		// Token: 0x06000024 RID: 36
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
		public abstract Func<Type, LifetimeManager> GetLifetimeManager();

		// Token: 0x06000025 RID: 37
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "API is easier to use with nested generics")]
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
		public abstract Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers();
	}
}
