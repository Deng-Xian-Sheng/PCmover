using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008B0 RID: 2224
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DecimalConstantAttribute : Attribute
	{
		// Token: 0x06005D9A RID: 23962 RVA: 0x00149488 File Offset: 0x00147688
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public DecimalConstantAttribute(byte scale, byte sign, uint hi, uint mid, uint low)
		{
			this.dec = new decimal((int)low, (int)mid, (int)hi, sign > 0, scale);
		}

		// Token: 0x06005D9B RID: 23963 RVA: 0x001494A5 File Offset: 0x001476A5
		[__DynamicallyInvokable]
		public DecimalConstantAttribute(byte scale, byte sign, int hi, int mid, int low)
		{
			this.dec = new decimal(low, mid, hi, sign > 0, scale);
		}

		// Token: 0x17001012 RID: 4114
		// (get) Token: 0x06005D9C RID: 23964 RVA: 0x001494C2 File Offset: 0x001476C2
		[__DynamicallyInvokable]
		public decimal Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this.dec;
			}
		}

		// Token: 0x06005D9D RID: 23965 RVA: 0x001494CC File Offset: 0x001476CC
		internal static decimal GetRawDecimalConstant(CustomAttributeData attr)
		{
			foreach (CustomAttributeNamedArgument customAttributeNamedArgument in attr.NamedArguments)
			{
				if (customAttributeNamedArgument.MemberInfo.Name.Equals("Value"))
				{
					return (decimal)customAttributeNamedArgument.TypedValue.Value;
				}
			}
			ParameterInfo[] parameters = attr.Constructor.GetParameters();
			IList<CustomAttributeTypedArgument> constructorArguments = attr.ConstructorArguments;
			if (parameters[2].ParameterType == typeof(uint))
			{
				int lo = (int)((uint)constructorArguments[4].Value);
				int mid = (int)((uint)constructorArguments[3].Value);
				int hi = (int)((uint)constructorArguments[2].Value);
				byte b = (byte)constructorArguments[1].Value;
				byte scale = (byte)constructorArguments[0].Value;
				return new decimal(lo, mid, hi, b > 0, scale);
			}
			int lo2 = (int)constructorArguments[4].Value;
			int mid2 = (int)constructorArguments[3].Value;
			int hi2 = (int)constructorArguments[2].Value;
			byte b2 = (byte)constructorArguments[1].Value;
			byte scale2 = (byte)constructorArguments[0].Value;
			return new decimal(lo2, mid2, hi2, b2 > 0, scale2);
		}

		// Token: 0x04002A0B RID: 10763
		private decimal dec;
	}
}
