using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000004 RID: 4
	public class LlEndpoint
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000021DF File Offset: 0x000003DF
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000021E7 File Offset: 0x000003E7
		public string BaseName { get; set; } = "LlEndpoint";

		// Token: 0x0600001D RID: 29 RVA: 0x000021F0 File Offset: 0x000003F0
		private void CreateNewUriProperties(string scheme)
		{
			LlUriProperties uriProperties = this._uriProperties;
			this._uriProperties = this.GetUriProperties(scheme);
			this._uriProperties.CopyFrom(uriProperties);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000221D File Offset: 0x0000041D
		public LlUriProperties UriProperties
		{
			get
			{
				return this._uriProperties;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002225 File Offset: 0x00000425
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002232 File Offset: 0x00000432
		public string Scheme
		{
			get
			{
				return this._uriProperties.Scheme;
			}
			set
			{
				if (this.Scheme == value)
				{
					return;
				}
				this.CreateNewUriProperties(value);
				this.MustCreateUri = true;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002251 File Offset: 0x00000451
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002259 File Offset: 0x00000459
		private bool MustCreateUri
		{
			get
			{
				return this._mustCreateUri;
			}
			set
			{
				if (this._mustCreateUri != value)
				{
					if (value)
					{
						Binding binding = this.Binding;
					}
					this._mustCreateUri = value;
				}
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002275 File Offset: 0x00000475
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000022AC File Offset: 0x000004AC
		public Uri Uri
		{
			get
			{
				if (this.MustCreateUri)
				{
					if (this._mustCreateBinding)
					{
						this._uri = null;
					}
					else
					{
						this._uri = this.CreateUri();
					}
					this.MustCreateUri = false;
				}
				return this._uri;
			}
			set
			{
				if (this._uri != value)
				{
					this._uri = value;
					this.MustCreateUri = false;
					this._mustCreateBinding = true;
					this._uriProperties = this.GetUriProperties(this._uri.Scheme);
					this._uriProperties.Uri = this._uri;
					this._ports[this._uriProperties.Scheme] = this._uriProperties.Port;
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002328 File Offset: 0x00000528
		public LlUriProperties GetUriProperties(string scheme)
		{
			BindingFactory bindingFactoryFromScheme = this.GetBindingFactoryFromScheme(scheme);
			if (bindingFactoryFromScheme != null)
			{
				return bindingFactoryFromScheme.GetUriProperties();
			}
			return new LlUriProperties(scheme);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000234D File Offset: 0x0000054D
		public LlUriProperties GetUriProperties(Uri uri)
		{
			if (uri != null)
			{
				LlUriProperties uriProperties = this.GetUriProperties(uri.Scheme);
				uriProperties.Uri = uri;
				return uriProperties;
			}
			return null;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000236D File Offset: 0x0000056D
		public EndpointAddress EndpointAddress
		{
			get
			{
				return this.CreateEndpointFromUri();
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002375 File Offset: 0x00000575
		protected bool IsValidUri
		{
			get
			{
				if (this.Uri == null)
				{
					return false;
				}
				LlUriProperties uriProperties = this._uriProperties;
				return ((uriProperties != null) ? uriProperties.BaseName : null) == this.BaseName;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000023A4 File Offset: 0x000005A4
		public bool IsValidContract
		{
			get
			{
				if (!this.IsValidUri)
				{
					return false;
				}
				string contractName = this._uriProperties.ContractName;
				ContractInfo contract = this.Contract;
				if (contractName == ((contract != null) ? contract.UriName : null))
				{
					string version = this._uriProperties.Version;
					ContractInfo contract2 = this.Contract;
					return version == ((contract2 != null) ? contract2.Version : null);
				}
				return false;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002403 File Offset: 0x00000603
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002410 File Offset: 0x00000610
		public string Host
		{
			get
			{
				return this._uriProperties.Host;
			}
			set
			{
				if (this._uriProperties.Host != value)
				{
					this._uriProperties.Host = value;
					this.MustCreateUri = true;
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002438 File Offset: 0x00000638
		public int GetPort(string scheme)
		{
			int result;
			if (this._ports.TryGetValue(scheme, out result))
			{
				return result;
			}
			return -1;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002458 File Offset: 0x00000658
		public void SetPort(string scheme, int port)
		{
			this._ports[scheme] = port;
			this.MustCreateUri = true;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000246E File Offset: 0x0000066E
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002476 File Offset: 0x00000676
		public ContractInfo Contract
		{
			get
			{
				return this._contract;
			}
			set
			{
				if (this._contract != value)
				{
					this._contract = value;
					this.MustCreateUri = true;
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000248F File Offset: 0x0000068F
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000024B4 File Offset: 0x000006B4
		public Binding Binding
		{
			get
			{
				if (this._mustCreateBinding)
				{
					this._binding = this.CreateBindingFromUri();
					this._mustCreateBinding = false;
				}
				return this._binding;
			}
			set
			{
				if (this._binding != value)
				{
					this._binding = value;
					this._mustCreateBinding = false;
					if (this._uriProperties != null)
					{
						BindingFactory bindingFactoryFromType = this.GetBindingFactoryFromType(this._binding.GetType());
						this._uriProperties.Parameters = bindingFactoryFromType.GetParameters(this._binding);
					}
					this.MustCreateUri = true;
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002510 File Offset: 0x00000710
		public IEnumerable<BindingFactory> BindingFactories
		{
			get
			{
				return this._knownBindings;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002518 File Offset: 0x00000718
		public LlEndpoint()
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000256C File Offset: 0x0000076C
		public LlEndpoint(BindingFactory bf)
		{
			this.AddBindingFactory(bf);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000025C8 File Offset: 0x000007C8
		public LlEndpoint(IEnumerable<BindingFactory> factories)
		{
			this.AddBindingFactories(factories);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002621 File Offset: 0x00000821
		public void AddBindingFactory(BindingFactory bf)
		{
			if (bf != null)
			{
				this._knownBindings.Add(bf);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002632 File Offset: 0x00000832
		public void AddBindingFactories(IEnumerable<BindingFactory> factories)
		{
			if (factories != null)
			{
				this._knownBindings.AddRange(factories);
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002644 File Offset: 0x00000844
		public BindingFactory GetBindingFactoryFromScheme(string scheme)
		{
			return (from f in this._knownBindings
			where f.Scheme == scheme
			select f).FirstOrDefault<BindingFactory>();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000267C File Offset: 0x0000087C
		public BindingFactory GetBindingFactoryFromType(Type bindingType)
		{
			return (from f in this._knownBindings
			where f.Type == bindingType
			select f).FirstOrDefault<BindingFactory>();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000026B4 File Offset: 0x000008B4
		protected virtual Binding CreateBindingFromUri()
		{
			if (!this.IsValidUri)
			{
				return null;
			}
			BindingFactory bindingFactoryFromScheme = this.GetBindingFactoryFromScheme(this.Uri.Scheme);
			if (bindingFactoryFromScheme == null)
			{
				return null;
			}
			return bindingFactoryFromScheme.CreateBinding(this._uriProperties.Parameters);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000026F4 File Offset: 0x000008F4
		protected virtual EndpointAddress CreateEndpointFromUri()
		{
			if (!this.IsValidUri)
			{
				return null;
			}
			BindingFactory bindingFactoryFromScheme = this.GetBindingFactoryFromScheme(this.Uri.Scheme);
			if (bindingFactoryFromScheme == null)
			{
				return null;
			}
			return bindingFactoryFromScheme.CreateEndpoint(this.Uri, this.Binding);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002734 File Offset: 0x00000934
		public Binding CreateBindingFromType(Type bindingType, string parameters)
		{
			BindingFactory bindingFactoryFromType = this.GetBindingFactoryFromType(bindingType);
			if (bindingFactoryFromType == null)
			{
				return null;
			}
			return bindingFactoryFromType.CreateBinding(parameters);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002758 File Offset: 0x00000958
		public Binding CreateBindingFromScheme(string scheme, string parameters)
		{
			BindingFactory bindingFactoryFromScheme = this.GetBindingFactoryFromScheme(scheme);
			if (bindingFactoryFromScheme == null)
			{
				return null;
			}
			return bindingFactoryFromScheme.CreateBinding(parameters);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000277C File Offset: 0x0000097C
		protected virtual Uri CreateUri()
		{
			if (this.Binding != null)
			{
				BindingFactory bindingFactoryFromType = this.GetBindingFactoryFromType(this.Binding.GetType());
				if (bindingFactoryFromType.Scheme != this._uriProperties.Scheme)
				{
					this.CreateNewUriProperties(bindingFactoryFromType.Scheme);
				}
				this._uriProperties.Parameters = ((bindingFactoryFromType != null) ? bindingFactoryFromType.GetParameters(this.Binding) : null);
			}
			this._uriProperties.BaseName = this.BaseName;
			this._uriProperties.ContractName = this.Contract.UriName;
			this._uriProperties.Version = this.Contract.Version;
			this._uriProperties.Port = this.GetPort(this._uriProperties.Scheme);
			return this._uriProperties.Uri;
		}

		// Token: 0x0400000B RID: 11
		public static readonly string UriSegmentDelimiter = "/";

		// Token: 0x0400000C RID: 12
		public static readonly char UriSegmentDelimiterChar = '/';

		// Token: 0x0400000D RID: 13
		public static readonly string UriSchemeServiceBus = "sb";

		// Token: 0x0400000E RID: 14
		public static readonly string UriSchemeWmi = "wmi";

		// Token: 0x0400000F RID: 15
		public static readonly string UriSchemeEma = "ema";

		// Token: 0x04000011 RID: 17
		private LlUriProperties _uriProperties = new LlUriProperties(Uri.UriSchemeNetPipe);

		// Token: 0x04000012 RID: 18
		private bool _mustCreateUri = true;

		// Token: 0x04000013 RID: 19
		private Uri _uri;

		// Token: 0x04000014 RID: 20
		private Dictionary<string, int> _ports = new Dictionary<string, int>();

		// Token: 0x04000015 RID: 21
		private ContractInfo _contract;

		// Token: 0x04000016 RID: 22
		protected bool _mustCreateBinding = true;

		// Token: 0x04000017 RID: 23
		private Binding _binding;

		// Token: 0x04000018 RID: 24
		private readonly List<BindingFactory> _knownBindings = new List<BindingFactory>();
	}
}
