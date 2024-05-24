using System;

namespace System.Resources
{
	// Token: 0x02000397 RID: 919
	internal struct ResourceLocator
	{
		// Token: 0x06002D3E RID: 11582 RVA: 0x000ABA77 File Offset: 0x000A9C77
		internal ResourceLocator(int dataPos, object value)
		{
			this._dataPos = dataPos;
			this._value = value;
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06002D3F RID: 11583 RVA: 0x000ABA87 File Offset: 0x000A9C87
		internal int DataPosition
		{
			get
			{
				return this._dataPos;
			}
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06002D40 RID: 11584 RVA: 0x000ABA8F File Offset: 0x000A9C8F
		// (set) Token: 0x06002D41 RID: 11585 RVA: 0x000ABA97 File Offset: 0x000A9C97
		internal object Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x06002D42 RID: 11586 RVA: 0x000ABAA0 File Offset: 0x000A9CA0
		internal static bool CanCache(ResourceTypeCode value)
		{
			return value <= ResourceTypeCode.TimeSpan;
		}

		// Token: 0x04001250 RID: 4688
		internal object _value;

		// Token: 0x04001251 RID: 4689
		internal int _dataPos;
	}
}
