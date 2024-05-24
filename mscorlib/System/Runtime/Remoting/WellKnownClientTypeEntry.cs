using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C2 RID: 1986
	[ComVisible(true)]
	public class WellKnownClientTypeEntry : TypeEntry
	{
		// Token: 0x060055FC RID: 22012 RVA: 0x0013115C File Offset: 0x0012F35C
		public WellKnownClientTypeEntry(string typeName, string assemblyName, string objectUrl)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			if (objectUrl == null)
			{
				throw new ArgumentNullException("objectUrl");
			}
			base.TypeName = typeName;
			base.AssemblyName = assemblyName;
			this._objectUrl = objectUrl;
		}

		// Token: 0x060055FD RID: 22013 RVA: 0x001311B0 File Offset: 0x0012F3B0
		public WellKnownClientTypeEntry(Type type, string objectUrl)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (objectUrl == null)
			{
				throw new ArgumentNullException("objectUrl");
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			base.TypeName = type.FullName;
			base.AssemblyName = runtimeType.GetRuntimeAssembly().GetSimpleName();
			this._objectUrl = objectUrl;
		}

		// Token: 0x17000E30 RID: 3632
		// (get) Token: 0x060055FE RID: 22014 RVA: 0x00131229 File Offset: 0x0012F429
		public string ObjectUrl
		{
			get
			{
				return this._objectUrl;
			}
		}

		// Token: 0x17000E31 RID: 3633
		// (get) Token: 0x060055FF RID: 22015 RVA: 0x00131234 File Offset: 0x0012F434
		public Type ObjectType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
				return RuntimeTypeHandle.GetTypeByName(base.TypeName + ", " + base.AssemblyName, ref stackCrawlMark);
			}
		}

		// Token: 0x17000E32 RID: 3634
		// (get) Token: 0x06005600 RID: 22016 RVA: 0x00131260 File Offset: 0x0012F460
		// (set) Token: 0x06005601 RID: 22017 RVA: 0x00131268 File Offset: 0x0012F468
		public string ApplicationUrl
		{
			get
			{
				return this._appUrl;
			}
			set
			{
				this._appUrl = value;
			}
		}

		// Token: 0x06005602 RID: 22018 RVA: 0x00131274 File Offset: 0x0012F474
		public override string ToString()
		{
			string text = string.Concat(new string[]
			{
				"type='",
				base.TypeName,
				", ",
				base.AssemblyName,
				"'; url=",
				this._objectUrl
			});
			if (this._appUrl != null)
			{
				text = text + "; appUrl=" + this._appUrl;
			}
			return text;
		}

		// Token: 0x0400277C RID: 10108
		private string _objectUrl;

		// Token: 0x0400277D RID: 10109
		private string _appUrl;
	}
}
