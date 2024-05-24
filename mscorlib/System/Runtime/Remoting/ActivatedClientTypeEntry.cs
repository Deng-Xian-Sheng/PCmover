using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C0 RID: 1984
	[ComVisible(true)]
	public class ActivatedClientTypeEntry : TypeEntry
	{
		// Token: 0x060055EF RID: 21999 RVA: 0x00130EFC File Offset: 0x0012F0FC
		public ActivatedClientTypeEntry(string typeName, string assemblyName, string appUrl)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			if (appUrl == null)
			{
				throw new ArgumentNullException("appUrl");
			}
			base.TypeName = typeName;
			base.AssemblyName = assemblyName;
			this._appUrl = appUrl;
		}

		// Token: 0x060055F0 RID: 22000 RVA: 0x00130F50 File Offset: 0x0012F150
		public ActivatedClientTypeEntry(Type type, string appUrl)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (appUrl == null)
			{
				throw new ArgumentNullException("appUrl");
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"));
			}
			base.TypeName = type.FullName;
			base.AssemblyName = runtimeType.GetRuntimeAssembly().GetSimpleName();
			this._appUrl = appUrl;
		}

		// Token: 0x17000E2B RID: 3627
		// (get) Token: 0x060055F1 RID: 22001 RVA: 0x00130FC9 File Offset: 0x0012F1C9
		public string ApplicationUrl
		{
			get
			{
				return this._appUrl;
			}
		}

		// Token: 0x17000E2C RID: 3628
		// (get) Token: 0x060055F2 RID: 22002 RVA: 0x00130FD4 File Offset: 0x0012F1D4
		public Type ObjectType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
				return RuntimeTypeHandle.GetTypeByName(base.TypeName + ", " + base.AssemblyName, ref stackCrawlMark);
			}
		}

		// Token: 0x17000E2D RID: 3629
		// (get) Token: 0x060055F3 RID: 22003 RVA: 0x00131000 File Offset: 0x0012F200
		// (set) Token: 0x060055F4 RID: 22004 RVA: 0x00131008 File Offset: 0x0012F208
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

		// Token: 0x060055F5 RID: 22005 RVA: 0x00131011 File Offset: 0x0012F211
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"type='",
				base.TypeName,
				", ",
				base.AssemblyName,
				"'; appUrl=",
				this._appUrl
			});
		}

		// Token: 0x04002779 RID: 10105
		private string _appUrl;

		// Token: 0x0400277A RID: 10106
		private IContextAttribute[] _contextAttributes;
	}
}
