using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200080A RID: 2058
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class ContextProperty
	{
		// Token: 0x17000EB6 RID: 3766
		// (get) Token: 0x060058B6 RID: 22710 RVA: 0x00138D45 File Offset: 0x00136F45
		public virtual string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000EB7 RID: 3767
		// (get) Token: 0x060058B7 RID: 22711 RVA: 0x00138D4D File Offset: 0x00136F4D
		public virtual object Property
		{
			get
			{
				return this._property;
			}
		}

		// Token: 0x060058B8 RID: 22712 RVA: 0x00138D55 File Offset: 0x00136F55
		internal ContextProperty(string name, object prop)
		{
			this._name = name;
			this._property = prop;
		}

		// Token: 0x0400286B RID: 10347
		internal string _name;

		// Token: 0x0400286C RID: 10348
		internal object _property;
	}
}
