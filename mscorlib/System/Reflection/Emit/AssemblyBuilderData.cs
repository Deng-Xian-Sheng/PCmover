using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x0200062A RID: 1578
	internal class AssemblyBuilderData
	{
		// Token: 0x06004977 RID: 18807 RVA: 0x00109E54 File Offset: 0x00108054
		[SecurityCritical]
		internal AssemblyBuilderData(InternalAssemblyBuilder assembly, string strAssemblyName, AssemblyBuilderAccess access, string dir)
		{
			this.m_assembly = assembly;
			this.m_strAssemblyName = strAssemblyName;
			this.m_access = access;
			this.m_moduleBuilderList = new List<ModuleBuilder>();
			this.m_resWriterList = new List<ResWriterData>();
			if (dir == null && access != AssemblyBuilderAccess.Run)
			{
				this.m_strDir = Environment.CurrentDirectory;
			}
			else
			{
				this.m_strDir = dir;
			}
			this.m_peFileKind = PEFileKinds.Dll;
		}

		// Token: 0x06004978 RID: 18808 RVA: 0x00109EB6 File Offset: 0x001080B6
		internal void AddModule(ModuleBuilder dynModule)
		{
			this.m_moduleBuilderList.Add(dynModule);
		}

		// Token: 0x06004979 RID: 18809 RVA: 0x00109EC4 File Offset: 0x001080C4
		internal void AddResWriter(ResWriterData resData)
		{
			this.m_resWriterList.Add(resData);
		}

		// Token: 0x0600497A RID: 18810 RVA: 0x00109ED4 File Offset: 0x001080D4
		internal void AddCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (this.m_CABuilders == null)
			{
				this.m_CABuilders = new CustomAttributeBuilder[16];
			}
			if (this.m_iCABuilder == this.m_CABuilders.Length)
			{
				CustomAttributeBuilder[] array = new CustomAttributeBuilder[this.m_iCABuilder * 2];
				Array.Copy(this.m_CABuilders, array, this.m_iCABuilder);
				this.m_CABuilders = array;
			}
			this.m_CABuilders[this.m_iCABuilder] = customBuilder;
			this.m_iCABuilder++;
		}

		// Token: 0x0600497B RID: 18811 RVA: 0x00109F4C File Offset: 0x0010814C
		internal void AddCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			if (this.m_CABytes == null)
			{
				this.m_CABytes = new byte[16][];
				this.m_CACons = new ConstructorInfo[16];
			}
			if (this.m_iCAs == this.m_CABytes.Length)
			{
				byte[][] array = new byte[this.m_iCAs * 2][];
				ConstructorInfo[] array2 = new ConstructorInfo[this.m_iCAs * 2];
				for (int i = 0; i < this.m_iCAs; i++)
				{
					array[i] = this.m_CABytes[i];
					array2[i] = this.m_CACons[i];
				}
				this.m_CABytes = array;
				this.m_CACons = array2;
			}
			byte[] array3 = new byte[binaryAttribute.Length];
			Array.Copy(binaryAttribute, array3, binaryAttribute.Length);
			this.m_CABytes[this.m_iCAs] = array3;
			this.m_CACons[this.m_iCAs] = con;
			this.m_iCAs++;
		}

		// Token: 0x0600497C RID: 18812 RVA: 0x0010A01C File Offset: 0x0010821C
		[SecurityCritical]
		internal void FillUnmanagedVersionInfo()
		{
			CultureInfo locale = this.m_assembly.GetLocale();
			if (locale != null)
			{
				this.m_nativeVersion.m_lcid = locale.LCID;
			}
			for (int i = 0; i < this.m_iCABuilder; i++)
			{
				Type declaringType = this.m_CABuilders[i].m_con.DeclaringType;
				if (this.m_CABuilders[i].m_constructorArgs.Length != 0 && this.m_CABuilders[i].m_constructorArgs[0] != null)
				{
					if (declaringType.Equals(typeof(AssemblyCopyrightAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						if (!this.m_OverrideUnmanagedVersionInfo)
						{
							this.m_nativeVersion.m_strCopyright = this.m_CABuilders[i].m_constructorArgs[0].ToString();
						}
					}
					else if (declaringType.Equals(typeof(AssemblyTrademarkAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						if (!this.m_OverrideUnmanagedVersionInfo)
						{
							this.m_nativeVersion.m_strTrademark = this.m_CABuilders[i].m_constructorArgs[0].ToString();
						}
					}
					else if (declaringType.Equals(typeof(AssemblyProductAttribute)))
					{
						if (!this.m_OverrideUnmanagedVersionInfo)
						{
							this.m_nativeVersion.m_strProduct = this.m_CABuilders[i].m_constructorArgs[0].ToString();
						}
					}
					else if (declaringType.Equals(typeof(AssemblyCompanyAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						if (!this.m_OverrideUnmanagedVersionInfo)
						{
							this.m_nativeVersion.m_strCompany = this.m_CABuilders[i].m_constructorArgs[0].ToString();
						}
					}
					else if (declaringType.Equals(typeof(AssemblyDescriptionAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						this.m_nativeVersion.m_strDescription = this.m_CABuilders[i].m_constructorArgs[0].ToString();
					}
					else if (declaringType.Equals(typeof(AssemblyTitleAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						this.m_nativeVersion.m_strTitle = this.m_CABuilders[i].m_constructorArgs[0].ToString();
					}
					else if (declaringType.Equals(typeof(AssemblyInformationalVersionAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						if (!this.m_OverrideUnmanagedVersionInfo)
						{
							this.m_nativeVersion.m_strProductVersion = this.m_CABuilders[i].m_constructorArgs[0].ToString();
						}
					}
					else if (declaringType.Equals(typeof(AssemblyCultureAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						CultureInfo cultureInfo = new CultureInfo(this.m_CABuilders[i].m_constructorArgs[0].ToString());
						this.m_nativeVersion.m_lcid = cultureInfo.LCID;
					}
					else if (declaringType.Equals(typeof(AssemblyFileVersionAttribute)))
					{
						if (this.m_CABuilders[i].m_constructorArgs.Length != 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", new object[]
							{
								this.m_CABuilders[i].m_con.ReflectedType.Name
							}));
						}
						if (!this.m_OverrideUnmanagedVersionInfo)
						{
							this.m_nativeVersion.m_strFileVersion = this.m_CABuilders[i].m_constructorArgs[0].ToString();
						}
					}
				}
			}
		}

		// Token: 0x0600497D RID: 18813 RVA: 0x0010A4D4 File Offset: 0x001086D4
		internal void CheckResNameConflict(string strNewResName)
		{
			int count = this.m_resWriterList.Count;
			for (int i = 0; i < count; i++)
			{
				ResWriterData resWriterData = this.m_resWriterList[i];
				if (resWriterData.m_strName.Equals(strNewResName))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_DuplicateResourceName"));
				}
			}
		}

		// Token: 0x0600497E RID: 18814 RVA: 0x0010A524 File Offset: 0x00108724
		internal void CheckNameConflict(string strNewModuleName)
		{
			int count = this.m_moduleBuilderList.Count;
			for (int i = 0; i < count; i++)
			{
				ModuleBuilder moduleBuilder = this.m_moduleBuilderList[i];
				if (moduleBuilder.m_moduleData.m_strModuleName.Equals(strNewModuleName))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_DuplicateModuleName"));
				}
			}
		}

		// Token: 0x0600497F RID: 18815 RVA: 0x0010A57C File Offset: 0x0010877C
		internal void CheckTypeNameConflict(string strTypeName, TypeBuilder enclosingType)
		{
			for (int i = 0; i < this.m_moduleBuilderList.Count; i++)
			{
				ModuleBuilder moduleBuilder = this.m_moduleBuilderList[i];
				moduleBuilder.CheckTypeNameConflict(strTypeName, enclosingType);
			}
		}

		// Token: 0x06004980 RID: 18816 RVA: 0x0010A5B4 File Offset: 0x001087B4
		internal void CheckFileNameConflict(string strFileName)
		{
			int count = this.m_moduleBuilderList.Count;
			for (int i = 0; i < count; i++)
			{
				ModuleBuilder moduleBuilder = this.m_moduleBuilderList[i];
				if (moduleBuilder.m_moduleData.m_strFileName != null && string.Compare(moduleBuilder.m_moduleData.m_strFileName, strFileName, StringComparison.OrdinalIgnoreCase) == 0)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_DuplicatedFileName"));
				}
			}
			count = this.m_resWriterList.Count;
			for (int i = 0; i < count; i++)
			{
				ResWriterData resWriterData = this.m_resWriterList[i];
				if (resWriterData.m_strFileName != null && string.Compare(resWriterData.m_strFileName, strFileName, StringComparison.OrdinalIgnoreCase) == 0)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_DuplicatedFileName"));
				}
			}
		}

		// Token: 0x06004981 RID: 18817 RVA: 0x0010A664 File Offset: 0x00108864
		internal ModuleBuilder FindModuleWithFileName(string strFileName)
		{
			int count = this.m_moduleBuilderList.Count;
			for (int i = 0; i < count; i++)
			{
				ModuleBuilder moduleBuilder = this.m_moduleBuilderList[i];
				if (moduleBuilder.m_moduleData.m_strFileName != null && string.Compare(moduleBuilder.m_moduleData.m_strFileName, strFileName, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return moduleBuilder;
				}
			}
			return null;
		}

		// Token: 0x06004982 RID: 18818 RVA: 0x0010A6BC File Offset: 0x001088BC
		internal ModuleBuilder FindModuleWithName(string strName)
		{
			int count = this.m_moduleBuilderList.Count;
			for (int i = 0; i < count; i++)
			{
				ModuleBuilder moduleBuilder = this.m_moduleBuilderList[i];
				if (moduleBuilder.m_moduleData.m_strModuleName != null && string.Compare(moduleBuilder.m_moduleData.m_strModuleName, strName, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return moduleBuilder;
				}
			}
			return null;
		}

		// Token: 0x06004983 RID: 18819 RVA: 0x0010A712 File Offset: 0x00108912
		internal void AddPublicComType(Type type)
		{
			if (this.m_isSaved)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotAlterAssembly"));
			}
			this.EnsurePublicComTypeCapacity();
			this.m_publicComTypeList[this.m_iPublicComTypeCount] = type;
			this.m_iPublicComTypeCount++;
		}

		// Token: 0x06004984 RID: 18820 RVA: 0x0010A74E File Offset: 0x0010894E
		internal void AddPermissionRequests(PermissionSet required, PermissionSet optional, PermissionSet refused)
		{
			if (this.m_isSaved)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotAlterAssembly"));
			}
			this.m_RequiredPset = required;
			this.m_OptionalPset = optional;
			this.m_RefusedPset = refused;
		}

		// Token: 0x06004985 RID: 18821 RVA: 0x0010A780 File Offset: 0x00108980
		private void EnsurePublicComTypeCapacity()
		{
			if (this.m_publicComTypeList == null)
			{
				this.m_publicComTypeList = new Type[16];
			}
			if (this.m_iPublicComTypeCount == this.m_publicComTypeList.Length)
			{
				Type[] array = new Type[this.m_iPublicComTypeCount * 2];
				Array.Copy(this.m_publicComTypeList, array, this.m_iPublicComTypeCount);
				this.m_publicComTypeList = array;
			}
		}

		// Token: 0x04001E49 RID: 7753
		internal List<ModuleBuilder> m_moduleBuilderList;

		// Token: 0x04001E4A RID: 7754
		internal List<ResWriterData> m_resWriterList;

		// Token: 0x04001E4B RID: 7755
		internal string m_strAssemblyName;

		// Token: 0x04001E4C RID: 7756
		internal AssemblyBuilderAccess m_access;

		// Token: 0x04001E4D RID: 7757
		private InternalAssemblyBuilder m_assembly;

		// Token: 0x04001E4E RID: 7758
		internal Type[] m_publicComTypeList;

		// Token: 0x04001E4F RID: 7759
		internal int m_iPublicComTypeCount;

		// Token: 0x04001E50 RID: 7760
		internal bool m_isSaved;

		// Token: 0x04001E51 RID: 7761
		internal const int m_iInitialSize = 16;

		// Token: 0x04001E52 RID: 7762
		internal string m_strDir;

		// Token: 0x04001E53 RID: 7763
		internal const int m_tkAssembly = 536870913;

		// Token: 0x04001E54 RID: 7764
		internal PermissionSet m_RequiredPset;

		// Token: 0x04001E55 RID: 7765
		internal PermissionSet m_OptionalPset;

		// Token: 0x04001E56 RID: 7766
		internal PermissionSet m_RefusedPset;

		// Token: 0x04001E57 RID: 7767
		internal CustomAttributeBuilder[] m_CABuilders;

		// Token: 0x04001E58 RID: 7768
		internal int m_iCABuilder;

		// Token: 0x04001E59 RID: 7769
		internal byte[][] m_CABytes;

		// Token: 0x04001E5A RID: 7770
		internal ConstructorInfo[] m_CACons;

		// Token: 0x04001E5B RID: 7771
		internal int m_iCAs;

		// Token: 0x04001E5C RID: 7772
		internal PEFileKinds m_peFileKind;

		// Token: 0x04001E5D RID: 7773
		internal MethodInfo m_entryPointMethod;

		// Token: 0x04001E5E RID: 7774
		internal Assembly m_ISymWrapperAssembly;

		// Token: 0x04001E5F RID: 7775
		internal ModuleBuilder m_entryPointModule;

		// Token: 0x04001E60 RID: 7776
		internal string m_strResourceFileName;

		// Token: 0x04001E61 RID: 7777
		internal byte[] m_resourceBytes;

		// Token: 0x04001E62 RID: 7778
		internal NativeVersionInfo m_nativeVersion;

		// Token: 0x04001E63 RID: 7779
		internal bool m_hasUnmanagedVersionInfo;

		// Token: 0x04001E64 RID: 7780
		internal bool m_OverrideUnmanagedVersionInfo;
	}
}
