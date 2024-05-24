using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace System.Security.Principal
{
	// Token: 0x02000321 RID: 801
	[ComVisible(true)]
	[Serializable]
	public class GenericIdentity : ClaimsIdentity
	{
		// Token: 0x06002887 RID: 10375 RVA: 0x00094B91 File Offset: 0x00092D91
		[SecuritySafeCritical]
		public GenericIdentity(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_name = name;
			this.m_type = "";
			this.AddNameClaim();
		}

		// Token: 0x06002888 RID: 10376 RVA: 0x00094BBF File Offset: 0x00092DBF
		[SecuritySafeCritical]
		public GenericIdentity(string name, string type)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.m_name = name;
			this.m_type = type;
			this.AddNameClaim();
		}

		// Token: 0x06002889 RID: 10377 RVA: 0x00094BF7 File Offset: 0x00092DF7
		private GenericIdentity()
		{
		}

		// Token: 0x0600288A RID: 10378 RVA: 0x00094BFF File Offset: 0x00092DFF
		protected GenericIdentity(GenericIdentity identity) : base(identity)
		{
			this.m_name = identity.m_name;
			this.m_type = identity.m_type;
		}

		// Token: 0x0600288B RID: 10379 RVA: 0x00094C20 File Offset: 0x00092E20
		public override ClaimsIdentity Clone()
		{
			return new GenericIdentity(this);
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x0600288C RID: 10380 RVA: 0x00094C28 File Offset: 0x00092E28
		public override IEnumerable<Claim> Claims
		{
			get
			{
				return base.Claims;
			}
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x0600288D RID: 10381 RVA: 0x00094C30 File Offset: 0x00092E30
		public override string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x0600288E RID: 10382 RVA: 0x00094C38 File Offset: 0x00092E38
		public override string AuthenticationType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x0600288F RID: 10383 RVA: 0x00094C40 File Offset: 0x00092E40
		public override bool IsAuthenticated
		{
			get
			{
				return !this.m_name.Equals("");
			}
		}

		// Token: 0x06002890 RID: 10384 RVA: 0x00094C58 File Offset: 0x00092E58
		[OnDeserialized]
		private void OnDeserializedMethod(StreamingContext context)
		{
			bool flag = false;
			using (IEnumerator<Claim> enumerator = base.Claims.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Claim claim = enumerator.Current;
					flag = true;
				}
			}
			if (!flag)
			{
				this.AddNameClaim();
			}
		}

		// Token: 0x06002891 RID: 10385 RVA: 0x00094CB0 File Offset: 0x00092EB0
		[SecuritySafeCritical]
		private void AddNameClaim()
		{
			if (this.m_name != null)
			{
				base.AddClaim(new Claim(base.NameClaimType, this.m_name, "http://www.w3.org/2001/XMLSchema#string", "LOCAL AUTHORITY", "LOCAL AUTHORITY", this));
			}
		}

		// Token: 0x04001003 RID: 4099
		private string m_name;

		// Token: 0x04001004 RID: 4100
		private string m_type;
	}
}
