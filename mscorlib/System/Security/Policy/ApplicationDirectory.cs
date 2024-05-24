using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x02000340 RID: 832
	[ComVisible(true)]
	[Serializable]
	public sealed class ApplicationDirectory : EvidenceBase
	{
		// Token: 0x06002967 RID: 10599 RVA: 0x00098F58 File Offset: 0x00097158
		public ApplicationDirectory(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_appDirectory = new URLString(name);
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x00098F7A File Offset: 0x0009717A
		private ApplicationDirectory(URLString appDirectory)
		{
			this.m_appDirectory = appDirectory;
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06002969 RID: 10601 RVA: 0x00098F89 File Offset: 0x00097189
		public string Directory
		{
			get
			{
				return this.m_appDirectory.ToString();
			}
		}

		// Token: 0x0600296A RID: 10602 RVA: 0x00098F98 File Offset: 0x00097198
		public override bool Equals(object o)
		{
			ApplicationDirectory applicationDirectory = o as ApplicationDirectory;
			return applicationDirectory != null && this.m_appDirectory.Equals(applicationDirectory.m_appDirectory);
		}

		// Token: 0x0600296B RID: 10603 RVA: 0x00098FC2 File Offset: 0x000971C2
		public override int GetHashCode()
		{
			return this.m_appDirectory.GetHashCode();
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x00098FCF File Offset: 0x000971CF
		public override EvidenceBase Clone()
		{
			return new ApplicationDirectory(this.m_appDirectory);
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x00098FDC File Offset: 0x000971DC
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x00098FE4 File Offset: 0x000971E4
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.ApplicationDirectory");
			securityElement.AddAttribute("version", "1");
			if (this.m_appDirectory != null)
			{
				securityElement.AddChild(new SecurityElement("Directory", this.m_appDirectory.ToString()));
			}
			return securityElement;
		}

		// Token: 0x0600296F RID: 10607 RVA: 0x00099030 File Offset: 0x00097230
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x04001102 RID: 4354
		private URLString m_appDirectory;
	}
}
