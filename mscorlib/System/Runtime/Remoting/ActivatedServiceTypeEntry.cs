using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C1 RID: 1985
	[ComVisible(true)]
	public class ActivatedServiceTypeEntry : TypeEntry
	{
		// Token: 0x060055F6 RID: 22006 RVA: 0x00131051 File Offset: 0x0012F251
		public ActivatedServiceTypeEntry(string typeName, string assemblyName)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			base.TypeName = typeName;
			base.AssemblyName = assemblyName;
		}

		// Token: 0x060055F7 RID: 22007 RVA: 0x00131084 File Offset: 0x0012F284
		public ActivatedServiceTypeEntry(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"));
			}
			base.TypeName = type.FullName;
			base.AssemblyName = runtimeType.GetRuntimeAssembly().GetSimpleName();
		}

		// Token: 0x17000E2E RID: 3630
		// (get) Token: 0x060055F8 RID: 22008 RVA: 0x001310E8 File Offset: 0x0012F2E8
		public Type ObjectType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
				return RuntimeTypeHandle.GetTypeByName(base.TypeName + ", " + base.AssemblyName, ref stackCrawlMark);
			}
		}

		// Token: 0x17000E2F RID: 3631
		// (get) Token: 0x060055F9 RID: 22009 RVA: 0x00131114 File Offset: 0x0012F314
		// (set) Token: 0x060055FA RID: 22010 RVA: 0x0013111C File Offset: 0x0012F31C
		public IContextAttribute[] ContextAttributes
		{
			get
			{
				return this._contextAttributes;
			}
			set
			{
				this._contextAttributes = value;
			}
		}

		// Token: 0x060055FB RID: 22011 RVA: 0x00131125 File Offset: 0x0012F325
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"type='",
				base.TypeName,
				", ",
				base.AssemblyName,
				"'"
			});
		}

		// Token: 0x0400277B RID: 10107
		private IContextAttribute[] _contextAttributes;
	}
}
