using System;
using System.IO;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000628 RID: 1576
	internal sealed class InternalAssemblyBuilder : RuntimeAssembly
	{
		// Token: 0x060048FF RID: 18687 RVA: 0x00107D7F File Offset: 0x00105F7F
		private InternalAssemblyBuilder()
		{
		}

		// Token: 0x06004900 RID: 18688 RVA: 0x00107D87 File Offset: 0x00105F87
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is InternalAssemblyBuilder)
			{
				return this == obj;
			}
			return obj.Equals(this);
		}

		// Token: 0x06004901 RID: 18689 RVA: 0x00107DA2 File Offset: 0x00105FA2
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06004902 RID: 18690 RVA: 0x00107DAA File Offset: 0x00105FAA
		public override string[] GetManifestResourceNames()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
		}

		// Token: 0x06004903 RID: 18691 RVA: 0x00107DBB File Offset: 0x00105FBB
		public override FileStream GetFile(string name)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
		}

		// Token: 0x06004904 RID: 18692 RVA: 0x00107DCC File Offset: 0x00105FCC
		public override FileStream[] GetFiles(bool getResourceModules)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
		}

		// Token: 0x06004905 RID: 18693 RVA: 0x00107DDD File Offset: 0x00105FDD
		public override Stream GetManifestResourceStream(Type type, string name)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
		}

		// Token: 0x06004906 RID: 18694 RVA: 0x00107DEE File Offset: 0x00105FEE
		public override Stream GetManifestResourceStream(string name)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
		}

		// Token: 0x06004907 RID: 18695 RVA: 0x00107DFF File Offset: 0x00105FFF
		public override ManifestResourceInfo GetManifestResourceInfo(string resourceName)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
		}

		// Token: 0x17000B6B RID: 2923
		// (get) Token: 0x06004908 RID: 18696 RVA: 0x00107E10 File Offset: 0x00106010
		public override string Location
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
			}
		}

		// Token: 0x17000B6C RID: 2924
		// (get) Token: 0x06004909 RID: 18697 RVA: 0x00107E21 File Offset: 0x00106021
		public override string CodeBase
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
			}
		}

		// Token: 0x0600490A RID: 18698 RVA: 0x00107E32 File Offset: 0x00106032
		public override Type[] GetExportedTypes()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicAssembly"));
		}

		// Token: 0x17000B6D RID: 2925
		// (get) Token: 0x0600490B RID: 18699 RVA: 0x00107E43 File Offset: 0x00106043
		public override string ImageRuntimeVersion
		{
			get
			{
				return RuntimeEnvironment.GetSystemVersion();
			}
		}
	}
}
