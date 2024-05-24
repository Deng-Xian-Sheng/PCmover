using System;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200001B RID: 27
	public struct SortColumn
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00005B5D File Offset: 0x00003D5D
		public SortColumn(PropertyKey propertyKey, SortDirection direction)
		{
			this = default(SortColumn);
			this.propertyKey = propertyKey;
			this.direction = direction;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00005B78 File Offset: 0x00003D78
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x00005B90 File Offset: 0x00003D90
		public PropertyKey PropertyKey
		{
			get
			{
				return this.propertyKey;
			}
			set
			{
				this.propertyKey = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00005B9C File Offset: 0x00003D9C
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x00005BB4 File Offset: 0x00003DB4
		public SortDirection Direction
		{
			get
			{
				return this.direction;
			}
			set
			{
				this.direction = value;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005BC0 File Offset: 0x00003DC0
		public static bool operator ==(SortColumn col1, SortColumn col2)
		{
			return col1.direction == col2.direction && col1.propertyKey == col2.propertyKey;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005BFC File Offset: 0x00003DFC
		public static bool operator !=(SortColumn col1, SortColumn col2)
		{
			return !(col1 == col2);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005C18 File Offset: 0x00003E18
		public override bool Equals(object obj)
		{
			return obj != null && obj.GetType() == typeof(SortColumn) && this == (SortColumn)obj;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00005C60 File Offset: 0x00003E60
		public override int GetHashCode()
		{
			int hashCode = this.direction.GetHashCode();
			return hashCode * 31 + this.propertyKey.GetHashCode();
		}

		// Token: 0x0400003B RID: 59
		private PropertyKey propertyKey;

		// Token: 0x0400003C RID: 60
		private SortDirection direction;
	}
}
