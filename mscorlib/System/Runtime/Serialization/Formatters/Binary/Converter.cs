using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200079F RID: 1951
	internal sealed class Converter
	{
		// Token: 0x060054A7 RID: 21671 RVA: 0x0012C4F2 File Offset: 0x0012A6F2
		private Converter()
		{
		}

		// Token: 0x060054A8 RID: 21672 RVA: 0x0012C4FC File Offset: 0x0012A6FC
		internal static InternalPrimitiveTypeE ToCode(Type type)
		{
			InternalPrimitiveTypeE result;
			if (type != null && !type.IsPrimitive)
			{
				if (type == Converter.typeofDateTime)
				{
					result = InternalPrimitiveTypeE.DateTime;
				}
				else if (type == Converter.typeofTimeSpan)
				{
					result = InternalPrimitiveTypeE.TimeSpan;
				}
				else if (type == Converter.typeofDecimal)
				{
					result = InternalPrimitiveTypeE.Decimal;
				}
				else
				{
					result = InternalPrimitiveTypeE.Invalid;
				}
			}
			else
			{
				result = Converter.ToPrimitiveTypeEnum(Type.GetTypeCode(type));
			}
			return result;
		}

		// Token: 0x060054A9 RID: 21673 RVA: 0x0012C54C File Offset: 0x0012A74C
		internal static bool IsWriteAsByteArray(InternalPrimitiveTypeE code)
		{
			bool result = false;
			switch (code)
			{
			case InternalPrimitiveTypeE.Boolean:
			case InternalPrimitiveTypeE.Byte:
			case InternalPrimitiveTypeE.Char:
			case InternalPrimitiveTypeE.Double:
			case InternalPrimitiveTypeE.Int16:
			case InternalPrimitiveTypeE.Int32:
			case InternalPrimitiveTypeE.Int64:
			case InternalPrimitiveTypeE.SByte:
			case InternalPrimitiveTypeE.Single:
			case InternalPrimitiveTypeE.UInt16:
			case InternalPrimitiveTypeE.UInt32:
			case InternalPrimitiveTypeE.UInt64:
				result = true;
				break;
			}
			return result;
		}

		// Token: 0x060054AA RID: 21674 RVA: 0x0012C5A8 File Offset: 0x0012A7A8
		internal static int TypeLength(InternalPrimitiveTypeE code)
		{
			int result = 0;
			switch (code)
			{
			case InternalPrimitiveTypeE.Boolean:
				result = 1;
				break;
			case InternalPrimitiveTypeE.Byte:
				result = 1;
				break;
			case InternalPrimitiveTypeE.Char:
				result = 2;
				break;
			case InternalPrimitiveTypeE.Double:
				result = 8;
				break;
			case InternalPrimitiveTypeE.Int16:
				result = 2;
				break;
			case InternalPrimitiveTypeE.Int32:
				result = 4;
				break;
			case InternalPrimitiveTypeE.Int64:
				result = 8;
				break;
			case InternalPrimitiveTypeE.SByte:
				result = 1;
				break;
			case InternalPrimitiveTypeE.Single:
				result = 4;
				break;
			case InternalPrimitiveTypeE.UInt16:
				result = 2;
				break;
			case InternalPrimitiveTypeE.UInt32:
				result = 4;
				break;
			case InternalPrimitiveTypeE.UInt64:
				result = 8;
				break;
			}
			return result;
		}

		// Token: 0x060054AB RID: 21675 RVA: 0x0012C630 File Offset: 0x0012A830
		internal static InternalNameSpaceE GetNameSpaceEnum(InternalPrimitiveTypeE code, Type type, WriteObjectInfo objectInfo, out string typeName)
		{
			InternalNameSpaceE internalNameSpaceE = InternalNameSpaceE.None;
			typeName = null;
			if (code != InternalPrimitiveTypeE.Invalid)
			{
				switch (code)
				{
				case InternalPrimitiveTypeE.Boolean:
				case InternalPrimitiveTypeE.Byte:
				case InternalPrimitiveTypeE.Char:
				case InternalPrimitiveTypeE.Double:
				case InternalPrimitiveTypeE.Int16:
				case InternalPrimitiveTypeE.Int32:
				case InternalPrimitiveTypeE.Int64:
				case InternalPrimitiveTypeE.SByte:
				case InternalPrimitiveTypeE.Single:
				case InternalPrimitiveTypeE.TimeSpan:
				case InternalPrimitiveTypeE.DateTime:
				case InternalPrimitiveTypeE.UInt16:
				case InternalPrimitiveTypeE.UInt32:
				case InternalPrimitiveTypeE.UInt64:
					internalNameSpaceE = InternalNameSpaceE.XdrPrimitive;
					typeName = "System." + Converter.ToComType(code);
					break;
				case InternalPrimitiveTypeE.Decimal:
					internalNameSpaceE = InternalNameSpaceE.UrtSystem;
					typeName = "System." + Converter.ToComType(code);
					break;
				}
			}
			if (internalNameSpaceE == InternalNameSpaceE.None && type != null)
			{
				if (type == Converter.typeofString)
				{
					internalNameSpaceE = InternalNameSpaceE.XdrString;
				}
				else if (objectInfo == null)
				{
					typeName = type.FullName;
					if (type.Assembly == Converter.urtAssembly)
					{
						internalNameSpaceE = InternalNameSpaceE.UrtSystem;
					}
					else
					{
						internalNameSpaceE = InternalNameSpaceE.UrtUser;
					}
				}
				else
				{
					typeName = objectInfo.GetTypeFullName();
					if (objectInfo.GetAssemblyString().Equals(Converter.urtAssemblyString))
					{
						internalNameSpaceE = InternalNameSpaceE.UrtSystem;
					}
					else
					{
						internalNameSpaceE = InternalNameSpaceE.UrtUser;
					}
				}
			}
			return internalNameSpaceE;
		}

		// Token: 0x060054AC RID: 21676 RVA: 0x0012C711 File Offset: 0x0012A911
		internal static Type ToArrayType(InternalPrimitiveTypeE code)
		{
			if (Converter.arrayTypeA == null)
			{
				Converter.InitArrayTypeA();
			}
			return Converter.arrayTypeA[(int)code];
		}

		// Token: 0x060054AD RID: 21677 RVA: 0x0012C72C File Offset: 0x0012A92C
		private static void InitTypeA()
		{
			Type[] array = new Type[Converter.primitiveTypeEnumLength];
			array[0] = null;
			array[1] = Converter.typeofBoolean;
			array[2] = Converter.typeofByte;
			array[3] = Converter.typeofChar;
			array[5] = Converter.typeofDecimal;
			array[6] = Converter.typeofDouble;
			array[7] = Converter.typeofInt16;
			array[8] = Converter.typeofInt32;
			array[9] = Converter.typeofInt64;
			array[10] = Converter.typeofSByte;
			array[11] = Converter.typeofSingle;
			array[12] = Converter.typeofTimeSpan;
			array[13] = Converter.typeofDateTime;
			array[14] = Converter.typeofUInt16;
			array[15] = Converter.typeofUInt32;
			array[16] = Converter.typeofUInt64;
			Converter.typeA = array;
		}

		// Token: 0x060054AE RID: 21678 RVA: 0x0012C7D0 File Offset: 0x0012A9D0
		private static void InitArrayTypeA()
		{
			Type[] array = new Type[Converter.primitiveTypeEnumLength];
			array[0] = null;
			array[1] = Converter.typeofBooleanArray;
			array[2] = Converter.typeofByteArray;
			array[3] = Converter.typeofCharArray;
			array[5] = Converter.typeofDecimalArray;
			array[6] = Converter.typeofDoubleArray;
			array[7] = Converter.typeofInt16Array;
			array[8] = Converter.typeofInt32Array;
			array[9] = Converter.typeofInt64Array;
			array[10] = Converter.typeofSByteArray;
			array[11] = Converter.typeofSingleArray;
			array[12] = Converter.typeofTimeSpanArray;
			array[13] = Converter.typeofDateTimeArray;
			array[14] = Converter.typeofUInt16Array;
			array[15] = Converter.typeofUInt32Array;
			array[16] = Converter.typeofUInt64Array;
			Converter.arrayTypeA = array;
		}

		// Token: 0x060054AF RID: 21679 RVA: 0x0012C874 File Offset: 0x0012AA74
		internal static Type ToType(InternalPrimitiveTypeE code)
		{
			if (Converter.typeA == null)
			{
				Converter.InitTypeA();
			}
			return Converter.typeA[(int)code];
		}

		// Token: 0x060054B0 RID: 21680 RVA: 0x0012C890 File Offset: 0x0012AA90
		internal static Array CreatePrimitiveArray(InternalPrimitiveTypeE code, int length)
		{
			Array result = null;
			switch (code)
			{
			case InternalPrimitiveTypeE.Boolean:
				result = new bool[length];
				break;
			case InternalPrimitiveTypeE.Byte:
				result = new byte[length];
				break;
			case InternalPrimitiveTypeE.Char:
				result = new char[length];
				break;
			case InternalPrimitiveTypeE.Decimal:
				result = new decimal[length];
				break;
			case InternalPrimitiveTypeE.Double:
				result = new double[length];
				break;
			case InternalPrimitiveTypeE.Int16:
				result = new short[length];
				break;
			case InternalPrimitiveTypeE.Int32:
				result = new int[length];
				break;
			case InternalPrimitiveTypeE.Int64:
				result = new long[length];
				break;
			case InternalPrimitiveTypeE.SByte:
				result = new sbyte[length];
				break;
			case InternalPrimitiveTypeE.Single:
				result = new float[length];
				break;
			case InternalPrimitiveTypeE.TimeSpan:
				result = new TimeSpan[length];
				break;
			case InternalPrimitiveTypeE.DateTime:
				result = new DateTime[length];
				break;
			case InternalPrimitiveTypeE.UInt16:
				result = new ushort[length];
				break;
			case InternalPrimitiveTypeE.UInt32:
				result = new uint[length];
				break;
			case InternalPrimitiveTypeE.UInt64:
				result = new ulong[length];
				break;
			}
			return result;
		}

		// Token: 0x060054B1 RID: 21681 RVA: 0x0012C974 File Offset: 0x0012AB74
		internal static bool IsPrimitiveArray(Type type, out object typeInformation)
		{
			typeInformation = null;
			bool result = true;
			if (type == Converter.typeofBooleanArray)
			{
				typeInformation = InternalPrimitiveTypeE.Boolean;
			}
			else if (type == Converter.typeofByteArray)
			{
				typeInformation = InternalPrimitiveTypeE.Byte;
			}
			else if (type == Converter.typeofCharArray)
			{
				typeInformation = InternalPrimitiveTypeE.Char;
			}
			else if (type == Converter.typeofDoubleArray)
			{
				typeInformation = InternalPrimitiveTypeE.Double;
			}
			else if (type == Converter.typeofInt16Array)
			{
				typeInformation = InternalPrimitiveTypeE.Int16;
			}
			else if (type == Converter.typeofInt32Array)
			{
				typeInformation = InternalPrimitiveTypeE.Int32;
			}
			else if (type == Converter.typeofInt64Array)
			{
				typeInformation = InternalPrimitiveTypeE.Int64;
			}
			else if (type == Converter.typeofSByteArray)
			{
				typeInformation = InternalPrimitiveTypeE.SByte;
			}
			else if (type == Converter.typeofSingleArray)
			{
				typeInformation = InternalPrimitiveTypeE.Single;
			}
			else if (type == Converter.typeofUInt16Array)
			{
				typeInformation = InternalPrimitiveTypeE.UInt16;
			}
			else if (type == Converter.typeofUInt32Array)
			{
				typeInformation = InternalPrimitiveTypeE.UInt32;
			}
			else if (type == Converter.typeofUInt64Array)
			{
				typeInformation = InternalPrimitiveTypeE.UInt64;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060054B2 RID: 21682 RVA: 0x0012CA78 File Offset: 0x0012AC78
		private static void InitValueA()
		{
			string[] array = new string[Converter.primitiveTypeEnumLength];
			array[0] = null;
			array[1] = "Boolean";
			array[2] = "Byte";
			array[3] = "Char";
			array[5] = "Decimal";
			array[6] = "Double";
			array[7] = "Int16";
			array[8] = "Int32";
			array[9] = "Int64";
			array[10] = "SByte";
			array[11] = "Single";
			array[12] = "TimeSpan";
			array[13] = "DateTime";
			array[14] = "UInt16";
			array[15] = "UInt32";
			array[16] = "UInt64";
			Converter.valueA = array;
		}

		// Token: 0x060054B3 RID: 21683 RVA: 0x0012CB1C File Offset: 0x0012AD1C
		internal static string ToComType(InternalPrimitiveTypeE code)
		{
			if (Converter.valueA == null)
			{
				Converter.InitValueA();
			}
			return Converter.valueA[(int)code];
		}

		// Token: 0x060054B4 RID: 21684 RVA: 0x0012CB38 File Offset: 0x0012AD38
		private static void InitTypeCodeA()
		{
			TypeCode[] array = new TypeCode[Converter.primitiveTypeEnumLength];
			array[0] = TypeCode.Object;
			array[1] = TypeCode.Boolean;
			array[2] = TypeCode.Byte;
			array[3] = TypeCode.Char;
			array[5] = TypeCode.Decimal;
			array[6] = TypeCode.Double;
			array[7] = TypeCode.Int16;
			array[8] = TypeCode.Int32;
			array[9] = TypeCode.Int64;
			array[10] = TypeCode.SByte;
			array[11] = TypeCode.Single;
			array[12] = TypeCode.Object;
			array[13] = TypeCode.DateTime;
			array[14] = TypeCode.UInt16;
			array[15] = TypeCode.UInt32;
			array[16] = TypeCode.UInt64;
			Converter.typeCodeA = array;
		}

		// Token: 0x060054B5 RID: 21685 RVA: 0x0012CBA8 File Offset: 0x0012ADA8
		internal static TypeCode ToTypeCode(InternalPrimitiveTypeE code)
		{
			if (Converter.typeCodeA == null)
			{
				Converter.InitTypeCodeA();
			}
			return Converter.typeCodeA[(int)code];
		}

		// Token: 0x060054B6 RID: 21686 RVA: 0x0012CBC4 File Offset: 0x0012ADC4
		private static void InitCodeA()
		{
			Converter.codeA = new InternalPrimitiveTypeE[]
			{
				InternalPrimitiveTypeE.Invalid,
				InternalPrimitiveTypeE.Invalid,
				InternalPrimitiveTypeE.Invalid,
				InternalPrimitiveTypeE.Boolean,
				InternalPrimitiveTypeE.Char,
				InternalPrimitiveTypeE.SByte,
				InternalPrimitiveTypeE.Byte,
				InternalPrimitiveTypeE.Int16,
				InternalPrimitiveTypeE.UInt16,
				InternalPrimitiveTypeE.Int32,
				InternalPrimitiveTypeE.UInt32,
				InternalPrimitiveTypeE.Int64,
				InternalPrimitiveTypeE.UInt64,
				InternalPrimitiveTypeE.Single,
				InternalPrimitiveTypeE.Double,
				InternalPrimitiveTypeE.Decimal,
				InternalPrimitiveTypeE.DateTime,
				InternalPrimitiveTypeE.Invalid,
				InternalPrimitiveTypeE.Invalid
			};
		}

		// Token: 0x060054B7 RID: 21687 RVA: 0x0012CC3E File Offset: 0x0012AE3E
		internal static InternalPrimitiveTypeE ToPrimitiveTypeEnum(TypeCode typeCode)
		{
			if (Converter.codeA == null)
			{
				Converter.InitCodeA();
			}
			return Converter.codeA[(int)typeCode];
		}

		// Token: 0x060054B8 RID: 21688 RVA: 0x0012CC58 File Offset: 0x0012AE58
		internal static object FromString(string value, InternalPrimitiveTypeE code)
		{
			object result;
			if (code != InternalPrimitiveTypeE.Invalid)
			{
				result = Convert.ChangeType(value, Converter.ToTypeCode(code), CultureInfo.InvariantCulture);
			}
			else
			{
				result = value;
			}
			return result;
		}

		// Token: 0x040026AB RID: 9899
		private static int primitiveTypeEnumLength = 17;

		// Token: 0x040026AC RID: 9900
		private static volatile Type[] typeA;

		// Token: 0x040026AD RID: 9901
		private static volatile Type[] arrayTypeA;

		// Token: 0x040026AE RID: 9902
		private static volatile string[] valueA;

		// Token: 0x040026AF RID: 9903
		private static volatile TypeCode[] typeCodeA;

		// Token: 0x040026B0 RID: 9904
		private static volatile InternalPrimitiveTypeE[] codeA;

		// Token: 0x040026B1 RID: 9905
		internal static Type typeofISerializable = typeof(ISerializable);

		// Token: 0x040026B2 RID: 9906
		internal static Type typeofString = typeof(string);

		// Token: 0x040026B3 RID: 9907
		internal static Type typeofConverter = typeof(Converter);

		// Token: 0x040026B4 RID: 9908
		internal static Type typeofBoolean = typeof(bool);

		// Token: 0x040026B5 RID: 9909
		internal static Type typeofByte = typeof(byte);

		// Token: 0x040026B6 RID: 9910
		internal static Type typeofChar = typeof(char);

		// Token: 0x040026B7 RID: 9911
		internal static Type typeofDecimal = typeof(decimal);

		// Token: 0x040026B8 RID: 9912
		internal static Type typeofDouble = typeof(double);

		// Token: 0x040026B9 RID: 9913
		internal static Type typeofInt16 = typeof(short);

		// Token: 0x040026BA RID: 9914
		internal static Type typeofInt32 = typeof(int);

		// Token: 0x040026BB RID: 9915
		internal static Type typeofInt64 = typeof(long);

		// Token: 0x040026BC RID: 9916
		internal static Type typeofSByte = typeof(sbyte);

		// Token: 0x040026BD RID: 9917
		internal static Type typeofSingle = typeof(float);

		// Token: 0x040026BE RID: 9918
		internal static Type typeofTimeSpan = typeof(TimeSpan);

		// Token: 0x040026BF RID: 9919
		internal static Type typeofDateTime = typeof(DateTime);

		// Token: 0x040026C0 RID: 9920
		internal static Type typeofUInt16 = typeof(ushort);

		// Token: 0x040026C1 RID: 9921
		internal static Type typeofUInt32 = typeof(uint);

		// Token: 0x040026C2 RID: 9922
		internal static Type typeofUInt64 = typeof(ulong);

		// Token: 0x040026C3 RID: 9923
		internal static Type typeofObject = typeof(object);

		// Token: 0x040026C4 RID: 9924
		internal static Type typeofSystemVoid = typeof(void);

		// Token: 0x040026C5 RID: 9925
		internal static Assembly urtAssembly = Assembly.GetAssembly(Converter.typeofString);

		// Token: 0x040026C6 RID: 9926
		internal static string urtAssemblyString = Converter.urtAssembly.FullName;

		// Token: 0x040026C7 RID: 9927
		internal static Type typeofTypeArray = typeof(Type[]);

		// Token: 0x040026C8 RID: 9928
		internal static Type typeofObjectArray = typeof(object[]);

		// Token: 0x040026C9 RID: 9929
		internal static Type typeofStringArray = typeof(string[]);

		// Token: 0x040026CA RID: 9930
		internal static Type typeofBooleanArray = typeof(bool[]);

		// Token: 0x040026CB RID: 9931
		internal static Type typeofByteArray = typeof(byte[]);

		// Token: 0x040026CC RID: 9932
		internal static Type typeofCharArray = typeof(char[]);

		// Token: 0x040026CD RID: 9933
		internal static Type typeofDecimalArray = typeof(decimal[]);

		// Token: 0x040026CE RID: 9934
		internal static Type typeofDoubleArray = typeof(double[]);

		// Token: 0x040026CF RID: 9935
		internal static Type typeofInt16Array = typeof(short[]);

		// Token: 0x040026D0 RID: 9936
		internal static Type typeofInt32Array = typeof(int[]);

		// Token: 0x040026D1 RID: 9937
		internal static Type typeofInt64Array = typeof(long[]);

		// Token: 0x040026D2 RID: 9938
		internal static Type typeofSByteArray = typeof(sbyte[]);

		// Token: 0x040026D3 RID: 9939
		internal static Type typeofSingleArray = typeof(float[]);

		// Token: 0x040026D4 RID: 9940
		internal static Type typeofTimeSpanArray = typeof(TimeSpan[]);

		// Token: 0x040026D5 RID: 9941
		internal static Type typeofDateTimeArray = typeof(DateTime[]);

		// Token: 0x040026D6 RID: 9942
		internal static Type typeofUInt16Array = typeof(ushort[]);

		// Token: 0x040026D7 RID: 9943
		internal static Type typeofUInt32Array = typeof(uint[]);

		// Token: 0x040026D8 RID: 9944
		internal static Type typeofUInt64Array = typeof(ulong[]);

		// Token: 0x040026D9 RID: 9945
		internal static Type typeofMarshalByRefObject = typeof(MarshalByRefObject);
	}
}
