using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000732 RID: 1842
	[CLSCompliant(false)]
	[ComVisible(true)]
	public interface IFormatterConverter
	{
		// Token: 0x060051A9 RID: 20905
		object Convert(object value, Type type);

		// Token: 0x060051AA RID: 20906
		object Convert(object value, TypeCode typeCode);

		// Token: 0x060051AB RID: 20907
		bool ToBoolean(object value);

		// Token: 0x060051AC RID: 20908
		char ToChar(object value);

		// Token: 0x060051AD RID: 20909
		sbyte ToSByte(object value);

		// Token: 0x060051AE RID: 20910
		byte ToByte(object value);

		// Token: 0x060051AF RID: 20911
		short ToInt16(object value);

		// Token: 0x060051B0 RID: 20912
		ushort ToUInt16(object value);

		// Token: 0x060051B1 RID: 20913
		int ToInt32(object value);

		// Token: 0x060051B2 RID: 20914
		uint ToUInt32(object value);

		// Token: 0x060051B3 RID: 20915
		long ToInt64(object value);

		// Token: 0x060051B4 RID: 20916
		ulong ToUInt64(object value);

		// Token: 0x060051B5 RID: 20917
		float ToSingle(object value);

		// Token: 0x060051B6 RID: 20918
		double ToDouble(object value);

		// Token: 0x060051B7 RID: 20919
		decimal ToDecimal(object value);

		// Token: 0x060051B8 RID: 20920
		DateTime ToDateTime(object value);

		// Token: 0x060051B9 RID: 20921
		string ToString(object value);
	}
}
