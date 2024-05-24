using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x0200072D RID: 1837
	[ComVisible(true)]
	public class FormatterConverter : IFormatterConverter
	{
		// Token: 0x06005173 RID: 20851 RVA: 0x0011F0CE File Offset: 0x0011D2CE
		public object Convert(object value, Type type)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005174 RID: 20852 RVA: 0x0011F0EA File Offset: 0x0011D2EA
		public object Convert(object value, TypeCode typeCode)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ChangeType(value, typeCode, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005175 RID: 20853 RVA: 0x0011F106 File Offset: 0x0011D306
		public bool ToBoolean(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToBoolean(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005176 RID: 20854 RVA: 0x0011F121 File Offset: 0x0011D321
		public char ToChar(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToChar(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005177 RID: 20855 RVA: 0x0011F13C File Offset: 0x0011D33C
		[CLSCompliant(false)]
		public sbyte ToSByte(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToSByte(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005178 RID: 20856 RVA: 0x0011F157 File Offset: 0x0011D357
		public byte ToByte(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToByte(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005179 RID: 20857 RVA: 0x0011F172 File Offset: 0x0011D372
		public short ToInt16(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToInt16(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600517A RID: 20858 RVA: 0x0011F18D File Offset: 0x0011D38D
		[CLSCompliant(false)]
		public ushort ToUInt16(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToUInt16(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600517B RID: 20859 RVA: 0x0011F1A8 File Offset: 0x0011D3A8
		public int ToInt32(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToInt32(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600517C RID: 20860 RVA: 0x0011F1C3 File Offset: 0x0011D3C3
		[CLSCompliant(false)]
		public uint ToUInt32(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToUInt32(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600517D RID: 20861 RVA: 0x0011F1DE File Offset: 0x0011D3DE
		public long ToInt64(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToInt64(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600517E RID: 20862 RVA: 0x0011F1F9 File Offset: 0x0011D3F9
		[CLSCompliant(false)]
		public ulong ToUInt64(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToUInt64(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600517F RID: 20863 RVA: 0x0011F214 File Offset: 0x0011D414
		public float ToSingle(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToSingle(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005180 RID: 20864 RVA: 0x0011F22F File Offset: 0x0011D42F
		public double ToDouble(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToDouble(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005181 RID: 20865 RVA: 0x0011F24A File Offset: 0x0011D44A
		public decimal ToDecimal(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToDecimal(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005182 RID: 20866 RVA: 0x0011F265 File Offset: 0x0011D465
		public DateTime ToDateTime(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToDateTime(value, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005183 RID: 20867 RVA: 0x0011F280 File Offset: 0x0011D480
		public string ToString(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return System.Convert.ToString(value, CultureInfo.InvariantCulture);
		}
	}
}
