using System;
using System.Reflection;

namespace System.Runtime.InteropServices.TCEAdapterGen
{
	// Token: 0x020009C2 RID: 2498
	internal class EventItfInfo
	{
		// Token: 0x060063AC RID: 25516 RVA: 0x0015441B File Offset: 0x0015261B
		public EventItfInfo(string strEventItfName, string strSrcItfName, string strEventProviderName, RuntimeAssembly asmImport, RuntimeAssembly asmSrcItf)
		{
			this.m_strEventItfName = strEventItfName;
			this.m_strSrcItfName = strSrcItfName;
			this.m_strEventProviderName = strEventProviderName;
			this.m_asmImport = asmImport;
			this.m_asmSrcItf = asmSrcItf;
		}

		// Token: 0x060063AD RID: 25517 RVA: 0x00154448 File Offset: 0x00152648
		public Type GetEventItfType()
		{
			Type type = this.m_asmImport.GetType(this.m_strEventItfName, true, false);
			if (type != null && !type.IsVisible)
			{
				type = null;
			}
			return type;
		}

		// Token: 0x060063AE RID: 25518 RVA: 0x00154480 File Offset: 0x00152680
		public Type GetSrcItfType()
		{
			Type type = this.m_asmSrcItf.GetType(this.m_strSrcItfName, true, false);
			if (type != null && !type.IsVisible)
			{
				type = null;
			}
			return type;
		}

		// Token: 0x060063AF RID: 25519 RVA: 0x001544B5 File Offset: 0x001526B5
		public string GetEventProviderName()
		{
			return this.m_strEventProviderName;
		}

		// Token: 0x04002CC9 RID: 11465
		private string m_strEventItfName;

		// Token: 0x04002CCA RID: 11466
		private string m_strSrcItfName;

		// Token: 0x04002CCB RID: 11467
		private string m_strEventProviderName;

		// Token: 0x04002CCC RID: 11468
		private RuntimeAssembly m_asmImport;

		// Token: 0x04002CCD RID: 11469
		private RuntimeAssembly m_asmSrcItf;
	}
}
