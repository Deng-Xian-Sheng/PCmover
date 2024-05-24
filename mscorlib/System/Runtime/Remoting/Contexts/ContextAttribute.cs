using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200080E RID: 2062
	[SecurityCritical]
	[AttributeUsage(AttributeTargets.Class)]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	[Serializable]
	public class ContextAttribute : Attribute, IContextAttribute, IContextProperty
	{
		// Token: 0x060058C3 RID: 22723 RVA: 0x00138D6B File Offset: 0x00136F6B
		public ContextAttribute(string name)
		{
			this.AttributeName = name;
		}

		// Token: 0x17000EB9 RID: 3769
		// (get) Token: 0x060058C4 RID: 22724 RVA: 0x00138D7A File Offset: 0x00136F7A
		public virtual string Name
		{
			[SecurityCritical]
			get
			{
				return this.AttributeName;
			}
		}

		// Token: 0x060058C5 RID: 22725 RVA: 0x00138D82 File Offset: 0x00136F82
		[SecurityCritical]
		public virtual bool IsNewContextOK(Context newCtx)
		{
			return true;
		}

		// Token: 0x060058C6 RID: 22726 RVA: 0x00138D85 File Offset: 0x00136F85
		[SecurityCritical]
		public virtual void Freeze(Context newContext)
		{
		}

		// Token: 0x060058C7 RID: 22727 RVA: 0x00138D88 File Offset: 0x00136F88
		[SecuritySafeCritical]
		public override bool Equals(object o)
		{
			IContextProperty contextProperty = o as IContextProperty;
			return contextProperty != null && this.AttributeName.Equals(contextProperty.Name);
		}

		// Token: 0x060058C8 RID: 22728 RVA: 0x00138DB2 File Offset: 0x00136FB2
		[SecuritySafeCritical]
		public override int GetHashCode()
		{
			return this.AttributeName.GetHashCode();
		}

		// Token: 0x060058C9 RID: 22729 RVA: 0x00138DC0 File Offset: 0x00136FC0
		[SecurityCritical]
		public virtual bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
		{
			if (ctx == null)
			{
				throw new ArgumentNullException("ctx");
			}
			if (ctorMsg == null)
			{
				throw new ArgumentNullException("ctorMsg");
			}
			if (!ctorMsg.ActivationType.IsContextful)
			{
				return true;
			}
			object property = ctx.GetProperty(this.AttributeName);
			return property != null && this.Equals(property);
		}

		// Token: 0x060058CA RID: 22730 RVA: 0x00138E14 File Offset: 0x00137014
		[SecurityCritical]
		public virtual void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
			if (ctorMsg == null)
			{
				throw new ArgumentNullException("ctorMsg");
			}
			ctorMsg.ContextProperties.Add(this);
		}

		// Token: 0x0400286D RID: 10349
		protected string AttributeName;
	}
}
