using System;
using System.IO;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x02000651 RID: 1617
	[Serializable]
	internal class ModuleBuilderData
	{
		// Token: 0x06004C98 RID: 19608 RVA: 0x00115987 File Offset: 0x00113B87
		[SecurityCritical]
		internal ModuleBuilderData(ModuleBuilder module, string strModuleName, string strFileName, int tkFile)
		{
			this.m_globalTypeBuilder = new TypeBuilder(module);
			this.m_module = module;
			this.m_tkFile = tkFile;
			this.InitNames(strModuleName, strFileName);
		}

		// Token: 0x06004C99 RID: 19609 RVA: 0x001159B4 File Offset: 0x00113BB4
		[SecurityCritical]
		private void InitNames(string strModuleName, string strFileName)
		{
			this.m_strModuleName = strModuleName;
			if (strFileName == null)
			{
				this.m_strFileName = strModuleName;
				return;
			}
			string extension = Path.GetExtension(strFileName);
			if (extension == null || extension == string.Empty)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NoModuleFileExtension", new object[]
				{
					strFileName
				}));
			}
			this.m_strFileName = strFileName;
		}

		// Token: 0x06004C9A RID: 19610 RVA: 0x00115A0B File Offset: 0x00113C0B
		[SecurityCritical]
		internal virtual void ModifyModuleName(string strModuleName)
		{
			this.InitNames(strModuleName, null);
		}

		// Token: 0x17000BF9 RID: 3065
		// (get) Token: 0x06004C9B RID: 19611 RVA: 0x00115A15 File Offset: 0x00113C15
		// (set) Token: 0x06004C9C RID: 19612 RVA: 0x00115A1D File Offset: 0x00113C1D
		internal int FileToken
		{
			get
			{
				return this.m_tkFile;
			}
			set
			{
				this.m_tkFile = value;
			}
		}

		// Token: 0x04001F54 RID: 8020
		internal string m_strModuleName;

		// Token: 0x04001F55 RID: 8021
		internal string m_strFileName;

		// Token: 0x04001F56 RID: 8022
		internal bool m_fGlobalBeenCreated;

		// Token: 0x04001F57 RID: 8023
		internal bool m_fHasGlobal;

		// Token: 0x04001F58 RID: 8024
		[NonSerialized]
		internal TypeBuilder m_globalTypeBuilder;

		// Token: 0x04001F59 RID: 8025
		[NonSerialized]
		internal ModuleBuilder m_module;

		// Token: 0x04001F5A RID: 8026
		private int m_tkFile;

		// Token: 0x04001F5B RID: 8027
		internal bool m_isSaved;

		// Token: 0x04001F5C RID: 8028
		[NonSerialized]
		internal ResWriterData m_embeddedRes;

		// Token: 0x04001F5D RID: 8029
		internal const string MULTI_BYTE_VALUE_CLASS = "$ArrayType$";

		// Token: 0x04001F5E RID: 8030
		internal string m_strResourceFileName;

		// Token: 0x04001F5F RID: 8031
		internal byte[] m_resourceBytes;
	}
}
