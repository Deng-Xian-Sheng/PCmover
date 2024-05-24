using System;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace System.Runtime.Hosting
{
	// Token: 0x02000A56 RID: 2646
	[ComVisible(true)]
	[Serializable]
	public sealed class ActivationArguments : EvidenceBase
	{
		// Token: 0x060066C2 RID: 26306 RVA: 0x00159F47 File Offset: 0x00158147
		private ActivationArguments()
		{
		}

		// Token: 0x1700118D RID: 4493
		// (get) Token: 0x060066C3 RID: 26307 RVA: 0x00159F4F File Offset: 0x0015814F
		internal bool UseFusionActivationContext
		{
			get
			{
				return this.m_useFusionActivationContext;
			}
		}

		// Token: 0x1700118E RID: 4494
		// (get) Token: 0x060066C4 RID: 26308 RVA: 0x00159F57 File Offset: 0x00158157
		// (set) Token: 0x060066C5 RID: 26309 RVA: 0x00159F5F File Offset: 0x0015815F
		internal bool ActivateInstance
		{
			get
			{
				return this.m_activateInstance;
			}
			set
			{
				this.m_activateInstance = value;
			}
		}

		// Token: 0x1700118F RID: 4495
		// (get) Token: 0x060066C6 RID: 26310 RVA: 0x00159F68 File Offset: 0x00158168
		internal string ApplicationFullName
		{
			get
			{
				return this.m_appFullName;
			}
		}

		// Token: 0x17001190 RID: 4496
		// (get) Token: 0x060066C7 RID: 26311 RVA: 0x00159F70 File Offset: 0x00158170
		internal string[] ApplicationManifestPaths
		{
			get
			{
				return this.m_appManifestPaths;
			}
		}

		// Token: 0x060066C8 RID: 26312 RVA: 0x00159F78 File Offset: 0x00158178
		public ActivationArguments(ApplicationIdentity applicationIdentity) : this(applicationIdentity, null)
		{
		}

		// Token: 0x060066C9 RID: 26313 RVA: 0x00159F82 File Offset: 0x00158182
		public ActivationArguments(ApplicationIdentity applicationIdentity, string[] activationData)
		{
			if (applicationIdentity == null)
			{
				throw new ArgumentNullException("applicationIdentity");
			}
			this.m_appFullName = applicationIdentity.FullName;
			this.m_activationData = activationData;
		}

		// Token: 0x060066CA RID: 26314 RVA: 0x00159FAB File Offset: 0x001581AB
		public ActivationArguments(ActivationContext activationData) : this(activationData, null)
		{
		}

		// Token: 0x060066CB RID: 26315 RVA: 0x00159FB8 File Offset: 0x001581B8
		public ActivationArguments(ActivationContext activationContext, string[] activationData)
		{
			if (activationContext == null)
			{
				throw new ArgumentNullException("activationContext");
			}
			this.m_appFullName = activationContext.Identity.FullName;
			this.m_appManifestPaths = activationContext.ManifestPaths;
			this.m_activationData = activationData;
			this.m_useFusionActivationContext = true;
		}

		// Token: 0x060066CC RID: 26316 RVA: 0x0015A004 File Offset: 0x00158204
		internal ActivationArguments(string appFullName, string[] appManifestPaths, string[] activationData)
		{
			if (appFullName == null)
			{
				throw new ArgumentNullException("appFullName");
			}
			this.m_appFullName = appFullName;
			this.m_appManifestPaths = appManifestPaths;
			this.m_activationData = activationData;
			this.m_useFusionActivationContext = true;
		}

		// Token: 0x17001191 RID: 4497
		// (get) Token: 0x060066CD RID: 26317 RVA: 0x0015A036 File Offset: 0x00158236
		public ApplicationIdentity ApplicationIdentity
		{
			get
			{
				return new ApplicationIdentity(this.m_appFullName);
			}
		}

		// Token: 0x17001192 RID: 4498
		// (get) Token: 0x060066CE RID: 26318 RVA: 0x0015A043 File Offset: 0x00158243
		public ActivationContext ActivationContext
		{
			get
			{
				if (!this.UseFusionActivationContext)
				{
					return null;
				}
				if (this.m_appManifestPaths == null)
				{
					return new ActivationContext(new ApplicationIdentity(this.m_appFullName));
				}
				return new ActivationContext(new ApplicationIdentity(this.m_appFullName), this.m_appManifestPaths);
			}
		}

		// Token: 0x17001193 RID: 4499
		// (get) Token: 0x060066CF RID: 26319 RVA: 0x0015A07E File Offset: 0x0015827E
		public string[] ActivationData
		{
			get
			{
				return this.m_activationData;
			}
		}

		// Token: 0x060066D0 RID: 26320 RVA: 0x0015A088 File Offset: 0x00158288
		public override EvidenceBase Clone()
		{
			ActivationArguments activationArguments = new ActivationArguments();
			activationArguments.m_useFusionActivationContext = this.m_useFusionActivationContext;
			activationArguments.m_activateInstance = this.m_activateInstance;
			activationArguments.m_appFullName = this.m_appFullName;
			if (this.m_appManifestPaths != null)
			{
				activationArguments.m_appManifestPaths = new string[this.m_appManifestPaths.Length];
				Array.Copy(this.m_appManifestPaths, activationArguments.m_appManifestPaths, activationArguments.m_appManifestPaths.Length);
			}
			if (this.m_activationData != null)
			{
				activationArguments.m_activationData = new string[this.m_activationData.Length];
				Array.Copy(this.m_activationData, activationArguments.m_activationData, activationArguments.m_activationData.Length);
			}
			activationArguments.m_activateInstance = this.m_activateInstance;
			activationArguments.m_appFullName = this.m_appFullName;
			activationArguments.m_useFusionActivationContext = this.m_useFusionActivationContext;
			return activationArguments;
		}

		// Token: 0x04002E10 RID: 11792
		private bool m_useFusionActivationContext;

		// Token: 0x04002E11 RID: 11793
		private bool m_activateInstance;

		// Token: 0x04002E12 RID: 11794
		private string m_appFullName;

		// Token: 0x04002E13 RID: 11795
		private string[] m_appManifestPaths;

		// Token: 0x04002E14 RID: 11796
		private string[] m_activationData;
	}
}
