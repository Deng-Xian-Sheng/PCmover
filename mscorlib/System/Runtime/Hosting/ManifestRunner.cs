using System;
using System.Deployment.Internal.Isolation.Manifest;
using System.IO;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Hosting
{
	// Token: 0x02000A54 RID: 2644
	internal sealed class ManifestRunner
	{
		// Token: 0x060066B8 RID: 26296 RVA: 0x00159BF4 File Offset: 0x00157DF4
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, Unrestricted = true)]
		internal ManifestRunner(AppDomain domain, ActivationContext activationContext)
		{
			this.m_domain = domain;
			string text;
			string text2;
			CmsUtils.GetEntryPoint(activationContext, out text, out text2);
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NoMain"));
			}
			if (string.IsNullOrEmpty(text2))
			{
				this.m_args = new string[0];
			}
			else
			{
				this.m_args = text2.Split(new char[]
				{
					' '
				});
			}
			this.m_apt = ApartmentState.Unknown;
			string applicationDirectory = activationContext.ApplicationDirectory;
			this.m_path = Path.Combine(applicationDirectory, text);
		}

		// Token: 0x1700118C RID: 4492
		// (get) Token: 0x060066B9 RID: 26297 RVA: 0x00159C78 File Offset: 0x00157E78
		internal RuntimeAssembly EntryAssembly
		{
			[SecurityCritical]
			[FileIOPermission(SecurityAction.Assert, Unrestricted = true)]
			[SecurityPermission(SecurityAction.Assert, Unrestricted = true)]
			get
			{
				if (this.m_assembly == null)
				{
					this.m_assembly = (RuntimeAssembly)Assembly.LoadFrom(this.m_path);
				}
				return this.m_assembly;
			}
		}

		// Token: 0x060066BA RID: 26298 RVA: 0x00159CA4 File Offset: 0x00157EA4
		[SecurityCritical]
		private void NewThreadRunner()
		{
			this.m_runResult = this.Run(false);
		}

		// Token: 0x060066BB RID: 26299 RVA: 0x00159CB4 File Offset: 0x00157EB4
		[SecurityCritical]
		private int RunInNewThread()
		{
			Thread thread = new Thread(new ThreadStart(this.NewThreadRunner));
			thread.SetApartmentState(this.m_apt);
			thread.Start();
			thread.Join();
			return this.m_runResult;
		}

		// Token: 0x060066BC RID: 26300 RVA: 0x00159CF4 File Offset: 0x00157EF4
		[SecurityCritical]
		private int Run(bool checkAptModel)
		{
			if (checkAptModel && this.m_apt != ApartmentState.Unknown)
			{
				if (Thread.CurrentThread.GetApartmentState() != ApartmentState.Unknown && Thread.CurrentThread.GetApartmentState() != this.m_apt)
				{
					return this.RunInNewThread();
				}
				Thread.CurrentThread.SetApartmentState(this.m_apt);
			}
			return this.m_domain.nExecuteAssembly(this.EntryAssembly, this.m_args);
		}

		// Token: 0x060066BD RID: 26301 RVA: 0x00159D5C File Offset: 0x00157F5C
		[SecurityCritical]
		internal int ExecuteAsAssembly()
		{
			object[] customAttributes = this.EntryAssembly.EntryPoint.GetCustomAttributes(typeof(STAThreadAttribute), false);
			if (customAttributes.Length != 0)
			{
				this.m_apt = ApartmentState.STA;
			}
			customAttributes = this.EntryAssembly.EntryPoint.GetCustomAttributes(typeof(MTAThreadAttribute), false);
			if (customAttributes.Length != 0)
			{
				if (this.m_apt == ApartmentState.Unknown)
				{
					this.m_apt = ApartmentState.MTA;
				}
				else
				{
					this.m_apt = ApartmentState.Unknown;
				}
			}
			return this.Run(true);
		}

		// Token: 0x04002E0A RID: 11786
		private AppDomain m_domain;

		// Token: 0x04002E0B RID: 11787
		private string m_path;

		// Token: 0x04002E0C RID: 11788
		private string[] m_args;

		// Token: 0x04002E0D RID: 11789
		private ApartmentState m_apt;

		// Token: 0x04002E0E RID: 11790
		private RuntimeAssembly m_assembly;

		// Token: 0x04002E0F RID: 11791
		private int m_runResult;
	}
}
