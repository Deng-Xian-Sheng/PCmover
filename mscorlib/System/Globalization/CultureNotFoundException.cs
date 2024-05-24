using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Globalization
{
	// Token: 0x020003A9 RID: 937
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class CultureNotFoundException : ArgumentException, ISerializable
	{
		// Token: 0x06002EA0 RID: 11936 RVA: 0x000B2330 File Offset: 0x000B0530
		[__DynamicallyInvokable]
		public CultureNotFoundException() : base(CultureNotFoundException.DefaultMessage)
		{
		}

		// Token: 0x06002EA1 RID: 11937 RVA: 0x000B233D File Offset: 0x000B053D
		[__DynamicallyInvokable]
		public CultureNotFoundException(string message) : base(message)
		{
		}

		// Token: 0x06002EA2 RID: 11938 RVA: 0x000B2346 File Offset: 0x000B0546
		[__DynamicallyInvokable]
		public CultureNotFoundException(string paramName, string message) : base(message, paramName)
		{
		}

		// Token: 0x06002EA3 RID: 11939 RVA: 0x000B2350 File Offset: 0x000B0550
		[__DynamicallyInvokable]
		public CultureNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06002EA4 RID: 11940 RVA: 0x000B235A File Offset: 0x000B055A
		public CultureNotFoundException(string paramName, int invalidCultureId, string message) : base(message, paramName)
		{
			this.m_invalidCultureId = new int?(invalidCultureId);
		}

		// Token: 0x06002EA5 RID: 11941 RVA: 0x000B2370 File Offset: 0x000B0570
		public CultureNotFoundException(string message, int invalidCultureId, Exception innerException) : base(message, innerException)
		{
			this.m_invalidCultureId = new int?(invalidCultureId);
		}

		// Token: 0x06002EA6 RID: 11942 RVA: 0x000B2386 File Offset: 0x000B0586
		[__DynamicallyInvokable]
		public CultureNotFoundException(string paramName, string invalidCultureName, string message) : base(message, paramName)
		{
			this.m_invalidCultureName = invalidCultureName;
		}

		// Token: 0x06002EA7 RID: 11943 RVA: 0x000B2397 File Offset: 0x000B0597
		[__DynamicallyInvokable]
		public CultureNotFoundException(string message, string invalidCultureName, Exception innerException) : base(message, innerException)
		{
			this.m_invalidCultureName = invalidCultureName;
		}

		// Token: 0x06002EA8 RID: 11944 RVA: 0x000B23A8 File Offset: 0x000B05A8
		protected CultureNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.m_invalidCultureId = (int?)info.GetValue("InvalidCultureId", typeof(int?));
			this.m_invalidCultureName = (string)info.GetValue("InvalidCultureName", typeof(string));
		}

		// Token: 0x06002EA9 RID: 11945 RVA: 0x000B2400 File Offset: 0x000B0600
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			int? num = null;
			num = this.m_invalidCultureId;
			info.AddValue("InvalidCultureId", num, typeof(int?));
			info.AddValue("InvalidCultureName", this.m_invalidCultureName, typeof(string));
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06002EAA RID: 11946 RVA: 0x000B2468 File Offset: 0x000B0668
		public virtual int? InvalidCultureId
		{
			get
			{
				return this.m_invalidCultureId;
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x06002EAB RID: 11947 RVA: 0x000B2470 File Offset: 0x000B0670
		[__DynamicallyInvokable]
		public virtual string InvalidCultureName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_invalidCultureName;
			}
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x06002EAC RID: 11948 RVA: 0x000B2478 File Offset: 0x000B0678
		private static string DefaultMessage
		{
			get
			{
				return Environment.GetResourceString("Argument_CultureNotSupported");
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06002EAD RID: 11949 RVA: 0x000B2484 File Offset: 0x000B0684
		private string FormatedInvalidCultureId
		{
			get
			{
				if (this.InvalidCultureId != null)
				{
					return string.Format(CultureInfo.InvariantCulture, "{0} (0x{0:x4})", this.InvalidCultureId.Value);
				}
				return this.InvalidCultureName;
			}
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06002EAE RID: 11950 RVA: 0x000B24CC File Offset: 0x000B06CC
		[__DynamicallyInvokable]
		public override string Message
		{
			[__DynamicallyInvokable]
			get
			{
				string message = base.Message;
				if (this.m_invalidCultureId == null && this.m_invalidCultureName == null)
				{
					return message;
				}
				string resourceString = Environment.GetResourceString("Argument_CultureInvalidIdentifier", new object[]
				{
					this.FormatedInvalidCultureId
				});
				if (message == null)
				{
					return resourceString;
				}
				return message + Environment.NewLine + resourceString;
			}
		}

		// Token: 0x0400134F RID: 4943
		private string m_invalidCultureName;

		// Token: 0x04001350 RID: 4944
		private int? m_invalidCultureId;
	}
}
