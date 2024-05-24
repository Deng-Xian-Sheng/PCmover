﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Threading;

namespace System.Globalization
{
	// Token: 0x020003D8 RID: 984
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class NumberFormatInfo : ICloneable, IFormatProvider
	{
		// Token: 0x06003205 RID: 12805 RVA: 0x000C0BCC File Offset: 0x000BEDCC
		[__DynamicallyInvokable]
		public NumberFormatInfo() : this(null)
		{
		}

		// Token: 0x06003206 RID: 12806 RVA: 0x000C0BD8 File Offset: 0x000BEDD8
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
			if (this.numberDecimalSeparator != this.numberGroupSeparator)
			{
				this.validForParseAsNumber = true;
			}
			else
			{
				this.validForParseAsNumber = false;
			}
			if (this.numberDecimalSeparator != this.numberGroupSeparator && this.numberDecimalSeparator != this.currencyGroupSeparator && this.currencyDecimalSeparator != this.numberGroupSeparator && this.currencyDecimalSeparator != this.currencyGroupSeparator)
			{
				this.validForParseAsCurrency = true;
				return;
			}
			this.validForParseAsCurrency = false;
		}

		// Token: 0x06003207 RID: 12807 RVA: 0x000C0C63 File Offset: 0x000BEE63
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx)
		{
		}

		// Token: 0x06003208 RID: 12808 RVA: 0x000C0C65 File Offset: 0x000BEE65
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
		}

		// Token: 0x06003209 RID: 12809 RVA: 0x000C0C67 File Offset: 0x000BEE67
		private static void VerifyDecimalSeparator(string decSep, string propertyName)
		{
			if (decSep == null)
			{
				throw new ArgumentNullException(propertyName, Environment.GetResourceString("ArgumentNull_String"));
			}
			if (decSep.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyDecString"));
			}
		}

		// Token: 0x0600320A RID: 12810 RVA: 0x000C0C95 File Offset: 0x000BEE95
		private static void VerifyGroupSeparator(string groupSep, string propertyName)
		{
			if (groupSep == null)
			{
				throw new ArgumentNullException(propertyName, Environment.GetResourceString("ArgumentNull_String"));
			}
		}

		// Token: 0x0600320B RID: 12811 RVA: 0x000C0CAC File Offset: 0x000BEEAC
		private static void VerifyNativeDigits(string[] nativeDig, string propertyName)
		{
			if (nativeDig == null)
			{
				throw new ArgumentNullException(propertyName, Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (nativeDig.Length != 10)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidNativeDigitCount"), propertyName);
			}
			for (int i = 0; i < nativeDig.Length; i++)
			{
				if (nativeDig[i] == null)
				{
					throw new ArgumentNullException(propertyName, Environment.GetResourceString("ArgumentNull_ArrayValue"));
				}
				if (nativeDig[i].Length != 1)
				{
					if (nativeDig[i].Length != 2)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidNativeDigitValue"), propertyName);
					}
					if (!char.IsSurrogatePair(nativeDig[i][0], nativeDig[i][1]))
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidNativeDigitValue"), propertyName);
					}
				}
				if (CharUnicodeInfo.GetDecimalDigitValue(nativeDig[i], 0) != i && CharUnicodeInfo.GetUnicodeCategory(nativeDig[i], 0) != UnicodeCategory.PrivateUse)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidNativeDigitValue"), propertyName);
				}
			}
		}

		// Token: 0x0600320C RID: 12812 RVA: 0x000C0D8A File Offset: 0x000BEF8A
		private static void VerifyDigitSubstitution(DigitShapes digitSub, string propertyName)
		{
			if (digitSub > DigitShapes.NativeNational)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDigitSubstitution"), propertyName);
			}
		}

		// Token: 0x0600320D RID: 12813 RVA: 0x000C0DA4 File Offset: 0x000BEFA4
		[SecuritySafeCritical]
		internal NumberFormatInfo(CultureData cultureData)
		{
			if (cultureData != null)
			{
				cultureData.GetNFIValues(this);
				if (cultureData.IsInvariantCulture)
				{
					this.m_isInvariant = true;
				}
			}
		}

		// Token: 0x0600320E RID: 12814 RVA: 0x000C0F29 File Offset: 0x000BF129
		private void VerifyWritable()
		{
			if (this.isReadOnly)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
			}
		}

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x0600320F RID: 12815 RVA: 0x000C0F44 File Offset: 0x000BF144
		[__DynamicallyInvokable]
		public static NumberFormatInfo InvariantInfo
		{
			[__DynamicallyInvokable]
			get
			{
				if (NumberFormatInfo.invariantInfo == null)
				{
					NumberFormatInfo.invariantInfo = NumberFormatInfo.ReadOnly(new NumberFormatInfo
					{
						m_isInvariant = true
					});
				}
				return NumberFormatInfo.invariantInfo;
			}
		}

		// Token: 0x06003210 RID: 12816 RVA: 0x000C0F7C File Offset: 0x000BF17C
		[__DynamicallyInvokable]
		public static NumberFormatInfo GetInstance(IFormatProvider formatProvider)
		{
			CultureInfo cultureInfo = formatProvider as CultureInfo;
			if (cultureInfo != null && !cultureInfo.m_isInherited)
			{
				NumberFormatInfo numberFormatInfo = cultureInfo.numInfo;
				if (numberFormatInfo != null)
				{
					return numberFormatInfo;
				}
				return cultureInfo.NumberFormat;
			}
			else
			{
				NumberFormatInfo numberFormatInfo = formatProvider as NumberFormatInfo;
				if (numberFormatInfo != null)
				{
					return numberFormatInfo;
				}
				if (formatProvider != null)
				{
					numberFormatInfo = (formatProvider.GetFormat(typeof(NumberFormatInfo)) as NumberFormatInfo);
					if (numberFormatInfo != null)
					{
						return numberFormatInfo;
					}
				}
				return NumberFormatInfo.CurrentInfo;
			}
		}

		// Token: 0x06003211 RID: 12817 RVA: 0x000C0FE0 File Offset: 0x000BF1E0
		[__DynamicallyInvokable]
		public object Clone()
		{
			NumberFormatInfo numberFormatInfo = (NumberFormatInfo)base.MemberwiseClone();
			numberFormatInfo.isReadOnly = false;
			return numberFormatInfo;
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06003212 RID: 12818 RVA: 0x000C1001 File Offset: 0x000BF201
		// (set) Token: 0x06003213 RID: 12819 RVA: 0x000C100C File Offset: 0x000BF20C
		[__DynamicallyInvokable]
		public int CurrencyDecimalDigits
		{
			[__DynamicallyInvokable]
			get
			{
				return this.currencyDecimalDigits;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 99)
				{
					throw new ArgumentOutOfRangeException("CurrencyDecimalDigits", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 99));
				}
				this.VerifyWritable();
				this.currencyDecimalDigits = value;
			}
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06003214 RID: 12820 RVA: 0x000C105B File Offset: 0x000BF25B
		// (set) Token: 0x06003215 RID: 12821 RVA: 0x000C1063 File Offset: 0x000BF263
		[__DynamicallyInvokable]
		public string CurrencyDecimalSeparator
		{
			[__DynamicallyInvokable]
			get
			{
				return this.currencyDecimalSeparator;
			}
			[__DynamicallyInvokable]
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyDecimalSeparator(value, "CurrencyDecimalSeparator");
				this.currencyDecimalSeparator = value;
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06003216 RID: 12822 RVA: 0x000C107D File Offset: 0x000BF27D
		[__DynamicallyInvokable]
		public bool IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return this.isReadOnly;
			}
		}

		// Token: 0x06003217 RID: 12823 RVA: 0x000C1088 File Offset: 0x000BF288
		internal static void CheckGroupSize(string propName, int[] groupSize)
		{
			int i = 0;
			while (i < groupSize.Length)
			{
				if (groupSize[i] < 1)
				{
					if (i == groupSize.Length - 1 && groupSize[i] == 0)
					{
						return;
					}
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidGroupSize"), propName);
				}
				else
				{
					if (groupSize[i] > 9)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidGroupSize"), propName);
					}
					i++;
				}
			}
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x06003218 RID: 12824 RVA: 0x000C10E0 File Offset: 0x000BF2E0
		// (set) Token: 0x06003219 RID: 12825 RVA: 0x000C10F4 File Offset: 0x000BF2F4
		[__DynamicallyInvokable]
		public int[] CurrencyGroupSizes
		{
			[__DynamicallyInvokable]
			get
			{
				return (int[])this.currencyGroupSizes.Clone();
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("CurrencyGroupSizes", Environment.GetResourceString("ArgumentNull_Obj"));
				}
				this.VerifyWritable();
				int[] groupSize = (int[])value.Clone();
				NumberFormatInfo.CheckGroupSize("CurrencyGroupSizes", groupSize);
				this.currencyGroupSizes = groupSize;
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x0600321A RID: 12826 RVA: 0x000C113D File Offset: 0x000BF33D
		// (set) Token: 0x0600321B RID: 12827 RVA: 0x000C1150 File Offset: 0x000BF350
		[__DynamicallyInvokable]
		public int[] NumberGroupSizes
		{
			[__DynamicallyInvokable]
			get
			{
				return (int[])this.numberGroupSizes.Clone();
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("NumberGroupSizes", Environment.GetResourceString("ArgumentNull_Obj"));
				}
				this.VerifyWritable();
				int[] groupSize = (int[])value.Clone();
				NumberFormatInfo.CheckGroupSize("NumberGroupSizes", groupSize);
				this.numberGroupSizes = groupSize;
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x0600321C RID: 12828 RVA: 0x000C1199 File Offset: 0x000BF399
		// (set) Token: 0x0600321D RID: 12829 RVA: 0x000C11AC File Offset: 0x000BF3AC
		[__DynamicallyInvokable]
		public int[] PercentGroupSizes
		{
			[__DynamicallyInvokable]
			get
			{
				return (int[])this.percentGroupSizes.Clone();
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PercentGroupSizes", Environment.GetResourceString("ArgumentNull_Obj"));
				}
				this.VerifyWritable();
				int[] groupSize = (int[])value.Clone();
				NumberFormatInfo.CheckGroupSize("PercentGroupSizes", groupSize);
				this.percentGroupSizes = groupSize;
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x0600321E RID: 12830 RVA: 0x000C11F5 File Offset: 0x000BF3F5
		// (set) Token: 0x0600321F RID: 12831 RVA: 0x000C11FD File Offset: 0x000BF3FD
		[__DynamicallyInvokable]
		public string CurrencyGroupSeparator
		{
			[__DynamicallyInvokable]
			get
			{
				return this.currencyGroupSeparator;
			}
			[__DynamicallyInvokable]
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyGroupSeparator(value, "CurrencyGroupSeparator");
				this.currencyGroupSeparator = value;
			}
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x06003220 RID: 12832 RVA: 0x000C1217 File Offset: 0x000BF417
		// (set) Token: 0x06003221 RID: 12833 RVA: 0x000C121F File Offset: 0x000BF41F
		[__DynamicallyInvokable]
		public string CurrencySymbol
		{
			[__DynamicallyInvokable]
			get
			{
				return this.currencySymbol;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("CurrencySymbol", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.currencySymbol = value;
			}
		}

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x06003222 RID: 12834 RVA: 0x000C1248 File Offset: 0x000BF448
		[__DynamicallyInvokable]
		public static NumberFormatInfo CurrentInfo
		{
			[__DynamicallyInvokable]
			get
			{
				CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
				if (!currentCulture.m_isInherited)
				{
					NumberFormatInfo numInfo = currentCulture.numInfo;
					if (numInfo != null)
					{
						return numInfo;
					}
				}
				return (NumberFormatInfo)currentCulture.GetFormat(typeof(NumberFormatInfo));
			}
		}

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x06003223 RID: 12835 RVA: 0x000C1289 File Offset: 0x000BF489
		// (set) Token: 0x06003224 RID: 12836 RVA: 0x000C1291 File Offset: 0x000BF491
		[__DynamicallyInvokable]
		public string NaNSymbol
		{
			[__DynamicallyInvokable]
			get
			{
				return this.nanSymbol;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("NaNSymbol", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.nanSymbol = value;
			}
		}

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x06003225 RID: 12837 RVA: 0x000C12B8 File Offset: 0x000BF4B8
		// (set) Token: 0x06003226 RID: 12838 RVA: 0x000C12C0 File Offset: 0x000BF4C0
		[__DynamicallyInvokable]
		public int CurrencyNegativePattern
		{
			[__DynamicallyInvokable]
			get
			{
				return this.currencyNegativePattern;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 15)
				{
					throw new ArgumentOutOfRangeException("CurrencyNegativePattern", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 15));
				}
				this.VerifyWritable();
				this.currencyNegativePattern = value;
			}
		}

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x06003227 RID: 12839 RVA: 0x000C130F File Offset: 0x000BF50F
		// (set) Token: 0x06003228 RID: 12840 RVA: 0x000C1318 File Offset: 0x000BF518
		[__DynamicallyInvokable]
		public int NumberNegativePattern
		{
			[__DynamicallyInvokable]
			get
			{
				return this.numberNegativePattern;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 4)
				{
					throw new ArgumentOutOfRangeException("NumberNegativePattern", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 4));
				}
				this.VerifyWritable();
				this.numberNegativePattern = value;
			}
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06003229 RID: 12841 RVA: 0x000C1365 File Offset: 0x000BF565
		// (set) Token: 0x0600322A RID: 12842 RVA: 0x000C1370 File Offset: 0x000BF570
		[__DynamicallyInvokable]
		public int PercentPositivePattern
		{
			[__DynamicallyInvokable]
			get
			{
				return this.percentPositivePattern;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 3)
				{
					throw new ArgumentOutOfRangeException("PercentPositivePattern", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 3));
				}
				this.VerifyWritable();
				this.percentPositivePattern = value;
			}
		}

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x0600322B RID: 12843 RVA: 0x000C13BD File Offset: 0x000BF5BD
		// (set) Token: 0x0600322C RID: 12844 RVA: 0x000C13C8 File Offset: 0x000BF5C8
		[__DynamicallyInvokable]
		public int PercentNegativePattern
		{
			[__DynamicallyInvokable]
			get
			{
				return this.percentNegativePattern;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 11)
				{
					throw new ArgumentOutOfRangeException("PercentNegativePattern", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 11));
				}
				this.VerifyWritable();
				this.percentNegativePattern = value;
			}
		}

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x0600322D RID: 12845 RVA: 0x000C1417 File Offset: 0x000BF617
		// (set) Token: 0x0600322E RID: 12846 RVA: 0x000C141F File Offset: 0x000BF61F
		[__DynamicallyInvokable]
		public string NegativeInfinitySymbol
		{
			[__DynamicallyInvokable]
			get
			{
				return this.negativeInfinitySymbol;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("NegativeInfinitySymbol", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.negativeInfinitySymbol = value;
			}
		}

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x0600322F RID: 12847 RVA: 0x000C1446 File Offset: 0x000BF646
		// (set) Token: 0x06003230 RID: 12848 RVA: 0x000C144E File Offset: 0x000BF64E
		[__DynamicallyInvokable]
		public string NegativeSign
		{
			[__DynamicallyInvokable]
			get
			{
				return this.negativeSign;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("NegativeSign", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.negativeSign = value;
			}
		}

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06003231 RID: 12849 RVA: 0x000C1475 File Offset: 0x000BF675
		// (set) Token: 0x06003232 RID: 12850 RVA: 0x000C1480 File Offset: 0x000BF680
		[__DynamicallyInvokable]
		public int NumberDecimalDigits
		{
			[__DynamicallyInvokable]
			get
			{
				return this.numberDecimalDigits;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 99)
				{
					throw new ArgumentOutOfRangeException("NumberDecimalDigits", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 99));
				}
				this.VerifyWritable();
				this.numberDecimalDigits = value;
			}
		}

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x06003233 RID: 12851 RVA: 0x000C14CF File Offset: 0x000BF6CF
		// (set) Token: 0x06003234 RID: 12852 RVA: 0x000C14D7 File Offset: 0x000BF6D7
		[__DynamicallyInvokable]
		public string NumberDecimalSeparator
		{
			[__DynamicallyInvokable]
			get
			{
				return this.numberDecimalSeparator;
			}
			[__DynamicallyInvokable]
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyDecimalSeparator(value, "NumberDecimalSeparator");
				this.numberDecimalSeparator = value;
			}
		}

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x06003235 RID: 12853 RVA: 0x000C14F1 File Offset: 0x000BF6F1
		// (set) Token: 0x06003236 RID: 12854 RVA: 0x000C14F9 File Offset: 0x000BF6F9
		[__DynamicallyInvokable]
		public string NumberGroupSeparator
		{
			[__DynamicallyInvokable]
			get
			{
				return this.numberGroupSeparator;
			}
			[__DynamicallyInvokable]
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyGroupSeparator(value, "NumberGroupSeparator");
				this.numberGroupSeparator = value;
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x06003237 RID: 12855 RVA: 0x000C1513 File Offset: 0x000BF713
		// (set) Token: 0x06003238 RID: 12856 RVA: 0x000C151C File Offset: 0x000BF71C
		[__DynamicallyInvokable]
		public int CurrencyPositivePattern
		{
			[__DynamicallyInvokable]
			get
			{
				return this.currencyPositivePattern;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 3)
				{
					throw new ArgumentOutOfRangeException("CurrencyPositivePattern", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 3));
				}
				this.VerifyWritable();
				this.currencyPositivePattern = value;
			}
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x06003239 RID: 12857 RVA: 0x000C1569 File Offset: 0x000BF769
		// (set) Token: 0x0600323A RID: 12858 RVA: 0x000C1571 File Offset: 0x000BF771
		[__DynamicallyInvokable]
		public string PositiveInfinitySymbol
		{
			[__DynamicallyInvokable]
			get
			{
				return this.positiveInfinitySymbol;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PositiveInfinitySymbol", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.positiveInfinitySymbol = value;
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x0600323B RID: 12859 RVA: 0x000C1598 File Offset: 0x000BF798
		// (set) Token: 0x0600323C RID: 12860 RVA: 0x000C15A0 File Offset: 0x000BF7A0
		[__DynamicallyInvokable]
		public string PositiveSign
		{
			[__DynamicallyInvokable]
			get
			{
				return this.positiveSign;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PositiveSign", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.positiveSign = value;
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x0600323D RID: 12861 RVA: 0x000C15C7 File Offset: 0x000BF7C7
		// (set) Token: 0x0600323E RID: 12862 RVA: 0x000C15D0 File Offset: 0x000BF7D0
		[__DynamicallyInvokable]
		public int PercentDecimalDigits
		{
			[__DynamicallyInvokable]
			get
			{
				return this.percentDecimalDigits;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0 || value > 99)
				{
					throw new ArgumentOutOfRangeException("PercentDecimalDigits", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 99));
				}
				this.VerifyWritable();
				this.percentDecimalDigits = value;
			}
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x0600323F RID: 12863 RVA: 0x000C161F File Offset: 0x000BF81F
		// (set) Token: 0x06003240 RID: 12864 RVA: 0x000C1627 File Offset: 0x000BF827
		[__DynamicallyInvokable]
		public string PercentDecimalSeparator
		{
			[__DynamicallyInvokable]
			get
			{
				return this.percentDecimalSeparator;
			}
			[__DynamicallyInvokable]
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyDecimalSeparator(value, "PercentDecimalSeparator");
				this.percentDecimalSeparator = value;
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x06003241 RID: 12865 RVA: 0x000C1641 File Offset: 0x000BF841
		// (set) Token: 0x06003242 RID: 12866 RVA: 0x000C1649 File Offset: 0x000BF849
		[__DynamicallyInvokable]
		public string PercentGroupSeparator
		{
			[__DynamicallyInvokable]
			get
			{
				return this.percentGroupSeparator;
			}
			[__DynamicallyInvokable]
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyGroupSeparator(value, "PercentGroupSeparator");
				this.percentGroupSeparator = value;
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x06003243 RID: 12867 RVA: 0x000C1663 File Offset: 0x000BF863
		// (set) Token: 0x06003244 RID: 12868 RVA: 0x000C166B File Offset: 0x000BF86B
		[__DynamicallyInvokable]
		public string PercentSymbol
		{
			[__DynamicallyInvokable]
			get
			{
				return this.percentSymbol;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PercentSymbol", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.percentSymbol = value;
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x06003245 RID: 12869 RVA: 0x000C1692 File Offset: 0x000BF892
		// (set) Token: 0x06003246 RID: 12870 RVA: 0x000C169A File Offset: 0x000BF89A
		[__DynamicallyInvokable]
		public string PerMilleSymbol
		{
			[__DynamicallyInvokable]
			get
			{
				return this.perMilleSymbol;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PerMilleSymbol", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.perMilleSymbol = value;
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06003247 RID: 12871 RVA: 0x000C16C1 File Offset: 0x000BF8C1
		// (set) Token: 0x06003248 RID: 12872 RVA: 0x000C16D3 File Offset: 0x000BF8D3
		[ComVisible(false)]
		public string[] NativeDigits
		{
			get
			{
				return (string[])this.nativeDigits.Clone();
			}
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyNativeDigits(value, "NativeDigits");
				this.nativeDigits = value;
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06003249 RID: 12873 RVA: 0x000C16ED File Offset: 0x000BF8ED
		// (set) Token: 0x0600324A RID: 12874 RVA: 0x000C16F5 File Offset: 0x000BF8F5
		[ComVisible(false)]
		public DigitShapes DigitSubstitution
		{
			get
			{
				return (DigitShapes)this.digitSubstitution;
			}
			set
			{
				this.VerifyWritable();
				NumberFormatInfo.VerifyDigitSubstitution(value, "DigitSubstitution");
				this.digitSubstitution = (int)value;
			}
		}

		// Token: 0x0600324B RID: 12875 RVA: 0x000C170F File Offset: 0x000BF90F
		[__DynamicallyInvokable]
		public object GetFormat(Type formatType)
		{
			if (!(formatType == typeof(NumberFormatInfo)))
			{
				return null;
			}
			return this;
		}

		// Token: 0x0600324C RID: 12876 RVA: 0x000C1728 File Offset: 0x000BF928
		[__DynamicallyInvokable]
		public static NumberFormatInfo ReadOnly(NumberFormatInfo nfi)
		{
			if (nfi == null)
			{
				throw new ArgumentNullException("nfi");
			}
			if (nfi.IsReadOnly)
			{
				return nfi;
			}
			NumberFormatInfo numberFormatInfo = (NumberFormatInfo)nfi.MemberwiseClone();
			numberFormatInfo.isReadOnly = true;
			return numberFormatInfo;
		}

		// Token: 0x0600324D RID: 12877 RVA: 0x000C1764 File Offset: 0x000BF964
		internal static void ValidateParseStyleInteger(NumberStyles style)
		{
			if ((style & ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier)) != NumberStyles.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidNumberStyles"), "style");
			}
			if ((style & NumberStyles.AllowHexSpecifier) != NumberStyles.None && (style & ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowHexSpecifier)) != NumberStyles.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_InvalidHexStyle"));
			}
		}

		// Token: 0x0600324E RID: 12878 RVA: 0x000C17B1 File Offset: 0x000BF9B1
		internal static void ValidateParseStyleFloatingPoint(NumberStyles style)
		{
			if ((style & ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier)) != NumberStyles.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidNumberStyles"), "style");
			}
			if ((style & NumberStyles.AllowHexSpecifier) != NumberStyles.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_HexStyleNotSupported"));
			}
		}

		// Token: 0x04001546 RID: 5446
		private static volatile NumberFormatInfo invariantInfo;

		// Token: 0x04001547 RID: 5447
		internal int[] numberGroupSizes = new int[]
		{
			3
		};

		// Token: 0x04001548 RID: 5448
		internal int[] currencyGroupSizes = new int[]
		{
			3
		};

		// Token: 0x04001549 RID: 5449
		internal int[] percentGroupSizes = new int[]
		{
			3
		};

		// Token: 0x0400154A RID: 5450
		internal string positiveSign = "+";

		// Token: 0x0400154B RID: 5451
		internal string negativeSign = "-";

		// Token: 0x0400154C RID: 5452
		internal string numberDecimalSeparator = ".";

		// Token: 0x0400154D RID: 5453
		internal string numberGroupSeparator = ",";

		// Token: 0x0400154E RID: 5454
		internal string currencyGroupSeparator = ",";

		// Token: 0x0400154F RID: 5455
		internal string currencyDecimalSeparator = ".";

		// Token: 0x04001550 RID: 5456
		internal string currencySymbol = "¤";

		// Token: 0x04001551 RID: 5457
		internal string ansiCurrencySymbol;

		// Token: 0x04001552 RID: 5458
		internal string nanSymbol = "NaN";

		// Token: 0x04001553 RID: 5459
		internal string positiveInfinitySymbol = "Infinity";

		// Token: 0x04001554 RID: 5460
		internal string negativeInfinitySymbol = "-Infinity";

		// Token: 0x04001555 RID: 5461
		internal string percentDecimalSeparator = ".";

		// Token: 0x04001556 RID: 5462
		internal string percentGroupSeparator = ",";

		// Token: 0x04001557 RID: 5463
		internal string percentSymbol = "%";

		// Token: 0x04001558 RID: 5464
		internal string perMilleSymbol = "‰";

		// Token: 0x04001559 RID: 5465
		[OptionalField(VersionAdded = 2)]
		internal string[] nativeDigits = new string[]
		{
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9"
		};

		// Token: 0x0400155A RID: 5466
		[OptionalField(VersionAdded = 1)]
		internal int m_dataItem;

		// Token: 0x0400155B RID: 5467
		internal int numberDecimalDigits = 2;

		// Token: 0x0400155C RID: 5468
		internal int currencyDecimalDigits = 2;

		// Token: 0x0400155D RID: 5469
		internal int currencyPositivePattern;

		// Token: 0x0400155E RID: 5470
		internal int currencyNegativePattern;

		// Token: 0x0400155F RID: 5471
		internal int numberNegativePattern = 1;

		// Token: 0x04001560 RID: 5472
		internal int percentPositivePattern;

		// Token: 0x04001561 RID: 5473
		internal int percentNegativePattern;

		// Token: 0x04001562 RID: 5474
		internal int percentDecimalDigits = 2;

		// Token: 0x04001563 RID: 5475
		[OptionalField(VersionAdded = 2)]
		internal int digitSubstitution = 1;

		// Token: 0x04001564 RID: 5476
		internal bool isReadOnly;

		// Token: 0x04001565 RID: 5477
		[OptionalField(VersionAdded = 1)]
		internal bool m_useUserOverride;

		// Token: 0x04001566 RID: 5478
		[OptionalField(VersionAdded = 2)]
		internal bool m_isInvariant;

		// Token: 0x04001567 RID: 5479
		[OptionalField(VersionAdded = 1)]
		internal bool validForParseAsNumber = true;

		// Token: 0x04001568 RID: 5480
		[OptionalField(VersionAdded = 1)]
		internal bool validForParseAsCurrency = true;

		// Token: 0x04001569 RID: 5481
		private const NumberStyles InvalidNumberStyles = ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier);
	}
}
