using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000969 RID: 2409
	[Guid("CCBD682C-73A5-4568-B8B0-C7007E11ABA2")]
	[ComVisible(true)]
	public interface IRegistrationServices
	{
		// Token: 0x06006227 RID: 25127
		[SecurityCritical]
		bool RegisterAssembly(Assembly assembly, AssemblyRegistrationFlags flags);

		// Token: 0x06006228 RID: 25128
		[SecurityCritical]
		bool UnregisterAssembly(Assembly assembly);

		// Token: 0x06006229 RID: 25129
		[SecurityCritical]
		Type[] GetRegistrableTypesInAssembly(Assembly assembly);

		// Token: 0x0600622A RID: 25130
		[SecurityCritical]
		string GetProgIdForType(Type type);

		// Token: 0x0600622B RID: 25131
		[SecurityCritical]
		void RegisterTypeForComClients(Type type, ref Guid g);

		// Token: 0x0600622C RID: 25132
		Guid GetManagedCategoryGuid();

		// Token: 0x0600622D RID: 25133
		[SecurityCritical]
		bool TypeRequiresRegistration(Type type);

		// Token: 0x0600622E RID: 25134
		bool TypeRepresentsComType(Type type);
	}
}
