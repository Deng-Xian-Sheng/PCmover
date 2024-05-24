using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000002 RID: 2
	public class LlServiceHost : ServiceHost
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static H CreateHost<H>(Func<H> hostNew, bool optionalTcp = false) where H : LlServiceHost
		{
			try
			{
				H h = hostNew();
				bool flag = h.Initialize();
				if (!flag)
				{
					h.Ts.TraceInformation("Could not create ServiceHost.");
					if (optionalTcp && h.AllowTcpBindings && (h.CreateSecureTcpBindings || h.CreateOpenTcpBindings))
					{
						h.Ts.TraceInformation("Trying again without TCP");
						h.Abort();
						h = hostNew();
						h.AllowTcpBindings = false;
						flag = h.Initialize();
					}
				}
				if (flag)
				{
					h.Ts.TraceInformation("ServiceHost created");
					return h;
				}
				h.Ts.TraceInformation("Could not create ServiceHost");
				h.Abort();
			}
			catch (Exception)
			{
			}
			return default(H);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002150 File Offset: 0x00000350
		public LlTraceSource Ts { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002158 File Offset: 0x00000358
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002160 File Offset: 0x00000360
		public bool CreatePipeBindings { get; set; } = true;

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002169 File Offset: 0x00000369
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002171 File Offset: 0x00000371
		public string CreatePipeBindingsSetting { get; set; } = "createPipeBindings";

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000217A File Offset: 0x0000037A
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002182 File Offset: 0x00000382
		public bool AllowTcpBindings { get; set; } = true;

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000218B File Offset: 0x0000038B
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00002193 File Offset: 0x00000393
		public bool CreateSecureTcpBindings { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000219C File Offset: 0x0000039C
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000021A4 File Offset: 0x000003A4
		public string CreateSecureTcpBindingsSetting { get; set; } = "createSecureTcpBindings";

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021AD File Offset: 0x000003AD
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000021B5 File Offset: 0x000003B5
		public bool CreateOpenTcpBindings { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021BE File Offset: 0x000003BE
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000021C6 File Offset: 0x000003C6
		public string CreateOpenTcpBindingsSetting { get; set; } = "createOpenTcpBindings";

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000021CF File Offset: 0x000003CF
		public List<LlEndpoint> Endpoints { get; } = new List<LlEndpoint>();

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000021D7 File Offset: 0x000003D7
		public List<Type> BindingTypes { get; } = new List<Type>();

		// Token: 0x06000013 RID: 19 RVA: 0x000021E0 File Offset: 0x000003E0
		public LlServiceHost(object singletonInstance, LlTraceSource ts) : base(singletonInstance, Array.Empty<Uri>())
		{
			this.Ts = ts;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002245 File Offset: 0x00000445
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000224D File Offset: 0x0000044D
		public Exception InitializationException { get; private set; }

		// Token: 0x06000016 RID: 22 RVA: 0x00002258 File Offset: 0x00000458
		public virtual bool Initialize()
		{
			bool result;
			try
			{
				this.Ts.TraceCaller("LlServiceHost", "Initialize");
				this.ReadSettings();
				this.AddEndpoints();
				this.PrepareToOpen();
				this.Ts.TraceInformation("Opening ServiceHost");
				base.Open();
				this.Ts.TraceCaller("Initialized", "Initialize");
				result = true;
			}
			catch (Exception ex)
			{
				this.InitializationException = ex;
				this.Ts.TraceException(ex, "Initialize");
				result = false;
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022EC File Offset: 0x000004EC
		protected virtual void ReadSettings()
		{
			if (this.CreatePipeBindings)
			{
				this.CreatePipeBindings = ConfigHelper.GetBoolSetting(this.CreatePipeBindingsSetting, true);
			}
			if (this.AllowTcpBindings)
			{
				this.CreateOpenTcpBindings = ConfigHelper.GetBoolSetting(this.CreateOpenTcpBindingsSetting, this.CreateOpenTcpBindings);
				this.CreateSecureTcpBindings = ConfigHelper.GetBoolSetting(this.CreateSecureTcpBindingsSetting, this.CreateSecureTcpBindings);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002349 File Offset: 0x00000549
		public virtual void ConfigureEndpoint(ServiceEndpoint endpoint)
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000234C File Offset: 0x0000054C
		private ServiceEndpoint AddEndpoint(LlEndpoint llEndpoint)
		{
			ServiceEndpoint serviceEndpoint = base.AddServiceEndpoint(llEndpoint.Contract.Type, llEndpoint.Binding, llEndpoint.Uri);
			this.ConfigureEndpoint(serviceEndpoint);
			this.Ts.TraceInformation(string.Format("Added endpoint {0}", llEndpoint.Uri));
			return serviceEndpoint;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000239C File Offset: 0x0000059C
		private void AddAllEndpoints(Type bindingType, string bindingParameters)
		{
			foreach (LlEndpoint llEndpoint in this.Endpoints)
			{
				BindingFactory bindingFactoryFromType = llEndpoint.GetBindingFactoryFromType(bindingType);
				if (bindingFactoryFromType != null)
				{
					llEndpoint.Host = bindingFactoryFromType.LocalHostName;
					llEndpoint.Binding = bindingFactoryFromType.CreateBinding(bindingParameters);
					this.AddEndpoint(llEndpoint);
				}
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002414 File Offset: 0x00000614
		protected virtual void AddEndpoints()
		{
			if (this.CreatePipeBindings)
			{
				this.AddAllEndpoints(typeof(NetNamedPipeBinding), null);
			}
			if (this.AllowTcpBindings)
			{
				if (this.CreateOpenTcpBindings)
				{
					this.AddAllEndpoints(typeof(NetTcpBinding), null);
				}
				if (this.CreateSecureTcpBindings)
				{
					this.AddAllEndpoints(typeof(NetTcpBinding), "transport/windows");
				}
			}
			foreach (Type bindingType in this.BindingTypes)
			{
				this.AddAllEndpoints(bindingType, null);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000024C0 File Offset: 0x000006C0
		protected virtual void PrepareToOpen()
		{
		}
	}
}
