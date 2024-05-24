using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C3 RID: 1987
	[ComVisible(true)]
	public class WellKnownServiceTypeEntry : TypeEntry
	{
		// Token: 0x06005603 RID: 22019 RVA: 0x001312DC File Offset: 0x0012F4DC
		public WellKnownServiceTypeEntry(string typeName, string assemblyName, string objectUri, WellKnownObjectMode mode)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			if (objectUri == null)
			{
				throw new ArgumentNullException("objectUri");
			}
			base.TypeName = typeName;
			base.AssemblyName = assemblyName;
			this._objectUri = objectUri;
			this._mode = mode;
		}

		// Token: 0x06005604 RID: 22020 RVA: 0x00131338 File Offset: 0x0012F538
		public WellKnownServiceTypeEntry(Type type, string objectUri, WellKnownObjectMode mode)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (objectUri == null)
			{
				throw new ArgumentNullException("objectUri");
			}
			if (!(type is RuntimeType))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			base.TypeName = type.FullName;
			base.AssemblyName = type.Module.Assembly.FullName;
			this._objectUri = objectUri;
			this._mode = mode;
		}

		// Token: 0x17000E33 RID: 3635
		// (get) Token: 0x06005605 RID: 22021 RVA: 0x001313B5 File Offset: 0x0012F5B5
		public string ObjectUri
		{
			get
			{
				return this._objectUri;
			}
		}

		// Token: 0x17000E34 RID: 3636
		// (get) Token: 0x06005606 RID: 22022 RVA: 0x001313BD File Offset: 0x0012F5BD
		public WellKnownObjectMode Mode
		{
			get
			{
				return this._mode;
			}
		}

		// Token: 0x17000E35 RID: 3637
		// (get) Token: 0x06005607 RID: 22023 RVA: 0x001313C8 File Offset: 0x0012F5C8
		public Type ObjectType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
				return RuntimeTypeHandle.GetTypeByName(base.TypeName + ", " + base.AssemblyName, ref stackCrawlMark);
			}
		}

		// Token: 0x17000E36 RID: 3638
		// (get) Token: 0x06005608 RID: 22024 RVA: 0x001313F4 File Offset: 0x0012F5F4
		// (set) Token: 0x06005609 RID: 22025 RVA: 0x001313FC File Offset: 0x0012F5FC
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

		// Token: 0x0600560A RID: 22026 RVA: 0x00131408 File Offset: 0x0012F608
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"type='",
				base.TypeName,
				", ",
				base.AssemblyName,
				"'; objectUri=",
				this._objectUri,
				"; mode=",
				this._mode.ToString()
			});
		}

		// Token: 0x0400277E RID: 10110
		private string _objectUri;

		// Token: 0x0400277F RID: 10111
		private WellKnownObjectMode _mode;

		// Token: 0x04002780 RID: 10112
		private IContextAttribute[] _contextAttributes;
	}
}
