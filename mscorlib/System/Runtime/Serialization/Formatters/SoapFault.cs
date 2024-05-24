using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata;
using System.Security;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x02000765 RID: 1893
	[SoapType(Embedded = true)]
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapFault : ISerializable
	{
		// Token: 0x0600531C RID: 21276 RVA: 0x00123C80 File Offset: 0x00121E80
		public SoapFault()
		{
		}

		// Token: 0x0600531D RID: 21277 RVA: 0x00123C88 File Offset: 0x00121E88
		public SoapFault(string faultCode, string faultString, string faultActor, ServerFault serverFault)
		{
			this.faultCode = faultCode;
			this.faultString = faultString;
			this.faultActor = faultActor;
			this.detail = serverFault;
		}

		// Token: 0x0600531E RID: 21278 RVA: 0x00123CB0 File Offset: 0x00121EB0
		internal SoapFault(SerializationInfo info, StreamingContext context)
		{
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string name = enumerator.Name;
				object value = enumerator.Value;
				if (string.Compare(name, "faultCode", true, CultureInfo.InvariantCulture) == 0)
				{
					int num = ((string)value).IndexOf(':');
					if (num > -1)
					{
						this.faultCode = ((string)value).Substring(num + 1);
					}
					else
					{
						this.faultCode = (string)value;
					}
				}
				else if (string.Compare(name, "faultString", true, CultureInfo.InvariantCulture) == 0)
				{
					this.faultString = (string)value;
				}
				else if (string.Compare(name, "faultActor", true, CultureInfo.InvariantCulture) == 0)
				{
					this.faultActor = (string)value;
				}
				else if (string.Compare(name, "detail", true, CultureInfo.InvariantCulture) == 0)
				{
					this.detail = value;
				}
			}
		}

		// Token: 0x0600531F RID: 21279 RVA: 0x00123D90 File Offset: 0x00121F90
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("faultcode", "SOAP-ENV:" + this.faultCode);
			info.AddValue("faultstring", this.faultString);
			if (this.faultActor != null)
			{
				info.AddValue("faultactor", this.faultActor);
			}
			info.AddValue("detail", this.detail, typeof(object));
		}

		// Token: 0x17000DC6 RID: 3526
		// (get) Token: 0x06005320 RID: 21280 RVA: 0x00123DFD File Offset: 0x00121FFD
		// (set) Token: 0x06005321 RID: 21281 RVA: 0x00123E05 File Offset: 0x00122005
		public string FaultCode
		{
			get
			{
				return this.faultCode;
			}
			set
			{
				this.faultCode = value;
			}
		}

		// Token: 0x17000DC7 RID: 3527
		// (get) Token: 0x06005322 RID: 21282 RVA: 0x00123E0E File Offset: 0x0012200E
		// (set) Token: 0x06005323 RID: 21283 RVA: 0x00123E16 File Offset: 0x00122016
		public string FaultString
		{
			get
			{
				return this.faultString;
			}
			set
			{
				this.faultString = value;
			}
		}

		// Token: 0x17000DC8 RID: 3528
		// (get) Token: 0x06005324 RID: 21284 RVA: 0x00123E1F File Offset: 0x0012201F
		// (set) Token: 0x06005325 RID: 21285 RVA: 0x00123E27 File Offset: 0x00122027
		public string FaultActor
		{
			get
			{
				return this.faultActor;
			}
			set
			{
				this.faultActor = value;
			}
		}

		// Token: 0x17000DC9 RID: 3529
		// (get) Token: 0x06005326 RID: 21286 RVA: 0x00123E30 File Offset: 0x00122030
		// (set) Token: 0x06005327 RID: 21287 RVA: 0x00123E38 File Offset: 0x00122038
		public object Detail
		{
			get
			{
				return this.detail;
			}
			set
			{
				this.detail = value;
			}
		}

		// Token: 0x040024D5 RID: 9429
		private string faultCode;

		// Token: 0x040024D6 RID: 9430
		private string faultString;

		// Token: 0x040024D7 RID: 9431
		private string faultActor;

		// Token: 0x040024D8 RID: 9432
		[SoapField(Embedded = true)]
		private object detail;
	}
}
