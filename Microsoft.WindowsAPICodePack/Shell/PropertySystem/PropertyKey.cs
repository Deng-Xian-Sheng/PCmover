using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x02000046 RID: 70
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct PropertyKey : IEquatable<PropertyKey>
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00005208 File Offset: 0x00003408
		public Guid FormatId
		{
			get
			{
				return this.formatId;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00005220 File Offset: 0x00003420
		public int PropertyId
		{
			get
			{
				return this.propertyId;
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005238 File Offset: 0x00003438
		public PropertyKey(Guid formatId, int propertyId)
		{
			this.formatId = formatId;
			this.propertyId = propertyId;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00005249 File Offset: 0x00003449
		public PropertyKey(string formatId, int propertyId)
		{
			this.formatId = new Guid(formatId);
			this.propertyId = propertyId;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005260 File Offset: 0x00003460
		public bool Equals(PropertyKey other)
		{
			return other.Equals(this);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000528C File Offset: 0x0000348C
		public override int GetHashCode()
		{
			return this.formatId.GetHashCode() ^ this.propertyId;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000052B8 File Offset: 0x000034B8
		public override bool Equals(object obj)
		{
			bool result;
			if (obj == null)
			{
				result = false;
			}
			else if (!(obj is PropertyKey))
			{
				result = false;
			}
			else
			{
				PropertyKey propertyKey = (PropertyKey)obj;
				result = (propertyKey.formatId.Equals(this.formatId) && propertyKey.propertyId == this.propertyId);
			}
			return result;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00005318 File Offset: 0x00003518
		public static bool operator ==(PropertyKey propKey1, PropertyKey propKey2)
		{
			return propKey1.Equals(propKey2);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005334 File Offset: 0x00003534
		public static bool operator !=(PropertyKey propKey1, PropertyKey propKey2)
		{
			return !propKey1.Equals(propKey2);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005354 File Offset: 0x00003554
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, LocalizedMessages.PropertyKeyFormatString, new object[]
			{
				this.formatId.ToString("B"),
				this.propertyId
			});
		}

		// Token: 0x0400024B RID: 587
		private Guid formatId;

		// Token: 0x0400024C RID: 588
		private int propertyId;
	}
}
