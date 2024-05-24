using System;
using System.IO;
using System.Runtime.Hosting;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000712 RID: 1810
	[SecuritySafeCritical]
	[SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
	internal static class CmsUtils
	{
		// Token: 0x0600510D RID: 20749 RVA: 0x0011DDF0 File Offset: 0x0011BFF0
		internal static void GetEntryPoint(ActivationContext activationContext, out string fileName, out string parameters)
		{
			parameters = null;
			fileName = null;
			ICMS applicationComponentManifest = activationContext.ApplicationComponentManifest;
			if (applicationComponentManifest == null || applicationComponentManifest.EntryPointSection == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NoMain"));
			}
			IEnumUnknown enumUnknown = (IEnumUnknown)applicationComponentManifest.EntryPointSection._NewEnum;
			uint num = 0U;
			object[] array = new object[1];
			if (enumUnknown.Next(1U, array, ref num) == 0 && num == 1U)
			{
				IEntryPointEntry entryPointEntry = (IEntryPointEntry)array[0];
				EntryPointEntry allData = entryPointEntry.AllData;
				if (allData.CommandLine_File != null && allData.CommandLine_File.Length > 0)
				{
					fileName = allData.CommandLine_File;
				}
				else
				{
					object obj = null;
					if (allData.Identity != null)
					{
						((ISectionWithReferenceIdentityKey)applicationComponentManifest.AssemblyReferenceSection).Lookup(allData.Identity, out obj);
						IAssemblyReferenceEntry assemblyReferenceEntry = (IAssemblyReferenceEntry)obj;
						fileName = assemblyReferenceEntry.DependentAssembly.Codebase;
					}
				}
				parameters = allData.CommandLine_Parameters;
			}
		}

		// Token: 0x0600510E RID: 20750 RVA: 0x0011DED0 File Offset: 0x0011C0D0
		internal static IAssemblyReferenceEntry[] GetDependentAssemblies(ActivationContext activationContext)
		{
			IAssemblyReferenceEntry[] array = null;
			ICMS applicationComponentManifest = activationContext.ApplicationComponentManifest;
			if (applicationComponentManifest == null)
			{
				return null;
			}
			ISection assemblyReferenceSection = applicationComponentManifest.AssemblyReferenceSection;
			uint num = (assemblyReferenceSection != null) ? assemblyReferenceSection.Count : 0U;
			if (num > 0U)
			{
				uint num2 = 0U;
				array = new IAssemblyReferenceEntry[num];
				IEnumUnknown enumUnknown = (IEnumUnknown)assemblyReferenceSection._NewEnum;
				IEnumUnknown enumUnknown2 = enumUnknown;
				uint celt = num;
				object[] rgelt = array;
				int num3 = enumUnknown2.Next(celt, rgelt, ref num2);
				if (num2 != num || num3 < 0)
				{
					return null;
				}
			}
			return array;
		}

		// Token: 0x0600510F RID: 20751 RVA: 0x0011DF38 File Offset: 0x0011C138
		internal static string GetEntryPointFullPath(ActivationArguments activationArguments)
		{
			return CmsUtils.GetEntryPointFullPath(activationArguments.ActivationContext);
		}

		// Token: 0x06005110 RID: 20752 RVA: 0x0011DF48 File Offset: 0x0011C148
		internal static string GetEntryPointFullPath(ActivationContext activationContext)
		{
			string text;
			string text2;
			CmsUtils.GetEntryPoint(activationContext, out text, out text2);
			if (!string.IsNullOrEmpty(text))
			{
				string text3 = activationContext.ApplicationDirectory;
				if (text3 == null || text3.Length == 0)
				{
					text3 = Directory.UnsafeGetCurrentDirectory();
				}
				text = Path.Combine(text3, text);
			}
			return text;
		}

		// Token: 0x06005111 RID: 20753 RVA: 0x0011DF88 File Offset: 0x0011C188
		internal static bool CompareIdentities(ActivationContext activationContext1, ActivationContext activationContext2)
		{
			if (activationContext1 == null || activationContext2 == null)
			{
				return activationContext1 == activationContext2;
			}
			return IsolationInterop.AppIdAuthority.AreDefinitionsEqual(0U, activationContext1.Identity.Identity, activationContext2.Identity.Identity);
		}

		// Token: 0x06005112 RID: 20754 RVA: 0x0011DFB8 File Offset: 0x0011C1B8
		internal static bool CompareIdentities(ApplicationIdentity applicationIdentity1, ApplicationIdentity applicationIdentity2, ApplicationVersionMatch versionMatch)
		{
			if (applicationIdentity1 == null || applicationIdentity2 == null)
			{
				return applicationIdentity1 == applicationIdentity2;
			}
			uint flags;
			if (versionMatch != ApplicationVersionMatch.MatchExactVersion)
			{
				if (versionMatch != ApplicationVersionMatch.MatchAllVersions)
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
					{
						(int)versionMatch
					}), "versionMatch");
				}
				flags = 1U;
			}
			else
			{
				flags = 0U;
			}
			return IsolationInterop.AppIdAuthority.AreDefinitionsEqual(flags, applicationIdentity1.Identity, applicationIdentity2.Identity);
		}

		// Token: 0x06005113 RID: 20755 RVA: 0x0011E01C File Offset: 0x0011C21C
		internal static string GetFriendlyName(ActivationContext activationContext)
		{
			ICMS deploymentComponentManifest = activationContext.DeploymentComponentManifest;
			IMetadataSectionEntry metadataSectionEntry = (IMetadataSectionEntry)deploymentComponentManifest.MetadataSectionEntry;
			IDescriptionMetadataEntry descriptionData = metadataSectionEntry.DescriptionData;
			string result = string.Empty;
			if (descriptionData != null)
			{
				DescriptionMetadataEntry allData = descriptionData.AllData;
				result = ((allData.Publisher != null) ? string.Format("{0} {1}", allData.Publisher, allData.Product) : allData.Product);
			}
			return result;
		}

		// Token: 0x06005114 RID: 20756 RVA: 0x0011E080 File Offset: 0x0011C280
		internal static void CreateActivationContext(string fullName, string[] manifestPaths, bool useFusionActivationContext, out ApplicationIdentity applicationIdentity, out ActivationContext activationContext)
		{
			applicationIdentity = new ApplicationIdentity(fullName);
			activationContext = null;
			if (useFusionActivationContext)
			{
				if (manifestPaths != null)
				{
					activationContext = new ActivationContext(applicationIdentity, manifestPaths);
					return;
				}
				activationContext = new ActivationContext(applicationIdentity);
			}
		}

		// Token: 0x06005115 RID: 20757 RVA: 0x0011E0AA File Offset: 0x0011C2AA
		internal static Evidence MergeApplicationEvidence(Evidence evidence, ApplicationIdentity applicationIdentity, ActivationContext activationContext, string[] activationData)
		{
			return CmsUtils.MergeApplicationEvidence(evidence, applicationIdentity, activationContext, activationData, null);
		}

		// Token: 0x06005116 RID: 20758 RVA: 0x0011E0B8 File Offset: 0x0011C2B8
		internal static Evidence MergeApplicationEvidence(Evidence evidence, ApplicationIdentity applicationIdentity, ActivationContext activationContext, string[] activationData, ApplicationTrust applicationTrust)
		{
			Evidence evidence2 = new Evidence();
			ActivationArguments evidence3 = (activationContext == null) ? new ActivationArguments(applicationIdentity, activationData) : new ActivationArguments(activationContext, activationData);
			evidence2 = new Evidence();
			evidence2.AddHostEvidence<ActivationArguments>(evidence3);
			if (applicationTrust != null)
			{
				evidence2.AddHostEvidence<ApplicationTrust>(applicationTrust);
			}
			if (activationContext != null)
			{
				Evidence applicationEvidence = new ApplicationSecurityInfo(activationContext).ApplicationEvidence;
				if (applicationEvidence != null)
				{
					evidence2.MergeWithNoDuplicates(applicationEvidence);
				}
			}
			if (evidence != null)
			{
				evidence2.MergeWithNoDuplicates(evidence);
			}
			return evidence2;
		}
	}
}
