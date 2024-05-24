using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x02000047 RID: 71
	[StructLayout(LayoutKind.Explicit)]
	public sealed class PropVariant : IDisposable
	{
		// Token: 0x06000145 RID: 325 RVA: 0x000055C4 File Offset: 0x000037C4
		private static Dictionary<Type, Action<PropVariant, Array, uint>> GenerateVectorActions()
		{
			Dictionary<Type, Action<PropVariant, Array, uint>> dictionary = new Dictionary<Type, Action<PropVariant, Array, uint>>();
			dictionary.Add(typeof(short), delegate(PropVariant pv, Array array, uint i)
			{
				short num;
				PropVariantNativeMethods.PropVariantGetInt16Elem(pv, i, out num);
				array.SetValue(num, (long)((ulong)i));
			});
			dictionary.Add(typeof(ushort), delegate(PropVariant pv, Array array, uint i)
			{
				ushort num;
				PropVariantNativeMethods.PropVariantGetUInt16Elem(pv, i, out num);
				array.SetValue(num, (long)((ulong)i));
			});
			dictionary.Add(typeof(int), delegate(PropVariant pv, Array array, uint i)
			{
				int num;
				PropVariantNativeMethods.PropVariantGetInt32Elem(pv, i, out num);
				array.SetValue(num, (long)((ulong)i));
			});
			dictionary.Add(typeof(uint), delegate(PropVariant pv, Array array, uint i)
			{
				uint num;
				PropVariantNativeMethods.PropVariantGetUInt32Elem(pv, i, out num);
				array.SetValue(num, (long)((ulong)i));
			});
			dictionary.Add(typeof(long), delegate(PropVariant pv, Array array, uint i)
			{
				long num;
				PropVariantNativeMethods.PropVariantGetInt64Elem(pv, i, out num);
				array.SetValue(num, (long)((ulong)i));
			});
			dictionary.Add(typeof(ulong), delegate(PropVariant pv, Array array, uint i)
			{
				ulong num;
				PropVariantNativeMethods.PropVariantGetUInt64Elem(pv, i, out num);
				array.SetValue(num, (long)((ulong)i));
			});
			dictionary.Add(typeof(DateTime), delegate(PropVariant pv, Array array, uint i)
			{
				System.Runtime.InteropServices.ComTypes.FILETIME filetime;
				PropVariantNativeMethods.PropVariantGetFileTimeElem(pv, i, out filetime);
				long fileTimeAsLong = PropVariant.GetFileTimeAsLong(ref filetime);
				array.SetValue(DateTime.FromFileTime(fileTimeAsLong), (long)((ulong)i));
			});
			dictionary.Add(typeof(bool), delegate(PropVariant pv, Array array, uint i)
			{
				bool flag;
				PropVariantNativeMethods.PropVariantGetBooleanElem(pv, i, out flag);
				array.SetValue(flag, (long)((ulong)i));
			});
			dictionary.Add(typeof(double), delegate(PropVariant pv, Array array, uint i)
			{
				double num;
				PropVariantNativeMethods.PropVariantGetDoubleElem(pv, i, out num);
				array.SetValue(num, (long)((ulong)i));
			});
			dictionary.Add(typeof(float), delegate(PropVariant pv, Array array, uint i)
			{
				float[] array2 = new float[1];
				Marshal.Copy(pv._ptr2, array2, (int)i, 1);
				array.SetValue(array2[0], (int)i);
			});
			dictionary.Add(typeof(decimal), delegate(PropVariant pv, Array array, uint i)
			{
				int[] array2 = new int[4];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = Marshal.ReadInt32(pv._ptr2, (int)(i * 16U + (uint)(j * 4)));
				}
				array.SetValue(new decimal(array2), (long)((ulong)i));
			});
			dictionary.Add(typeof(string), delegate(PropVariant pv, Array array, uint i)
			{
				string empty = string.Empty;
				PropVariantNativeMethods.PropVariantGetStringElem(pv, i, ref empty);
				array.SetValue(empty, (long)((ulong)i));
			});
			return dictionary;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00005820 File Offset: 0x00003A20
		public static PropVariant FromObject(object value)
		{
			PropVariant result;
			if (value == null)
			{
				result = new PropVariant();
			}
			else
			{
				Func<object, PropVariant> dynamicConstructor = PropVariant.GetDynamicConstructor(value.GetType());
				result = dynamicConstructor(value);
			}
			return result;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000585C File Offset: 0x00003A5C
		private static Func<object, PropVariant> GetDynamicConstructor(Type type)
		{
			Func<object, PropVariant> result;
			lock (PropVariant._padlock)
			{
				Func<object, PropVariant> func;
				if (!PropVariant._cache.TryGetValue(type, out func))
				{
					ConstructorInfo constructor = typeof(PropVariant).GetConstructor(new Type[]
					{
						type
					});
					if (constructor == null)
					{
						throw new ArgumentException(LocalizedMessages.PropVariantTypeNotSupported);
					}
					ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "arg");
					NewExpression body = Expression.New(constructor, new Expression[]
					{
						Expression.Convert(parameterExpression, type)
					});
					func = Expression.Lambda<Func<object, PropVariant>>(body, new ParameterExpression[]
					{
						parameterExpression
					}).Compile();
					PropVariant._cache.Add(type, func);
				}
				result = func;
			}
			return result;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005948 File Offset: 0x00003B48
		public PropVariant()
		{
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005954 File Offset: 0x00003B54
		public PropVariant(string value)
		{
			if (value == null)
			{
				throw new ArgumentException(LocalizedMessages.PropVariantNullString, "value");
			}
			this._valueType = 31;
			this._ptr = Marshal.StringToCoTaskMemUni(value);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000599C File Offset: 0x00003B9C
		public PropVariant(string[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromStringVector(value, (uint)value.Length, this);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000059D4 File Offset: 0x00003BD4
		public PropVariant(bool[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromBooleanVector(value, (uint)value.Length, this);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00005A0C File Offset: 0x00003C0C
		public PropVariant(short[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromInt16Vector(value, (uint)value.Length, this);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005A44 File Offset: 0x00003C44
		public PropVariant(ushort[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromUInt16Vector(value, (uint)value.Length, this);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00005A7C File Offset: 0x00003C7C
		public PropVariant(int[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromInt32Vector(value, (uint)value.Length, this);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00005AB4 File Offset: 0x00003CB4
		public PropVariant(uint[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromUInt32Vector(value, (uint)value.Length, this);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005AEC File Offset: 0x00003CEC
		public PropVariant(long[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromInt64Vector(value, (uint)value.Length, this);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00005B24 File Offset: 0x00003D24
		public PropVariant(ulong[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromUInt64Vector(value, (uint)value.Length, this);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00005B5C File Offset: 0x00003D5C
		public PropVariant(double[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropVariantNativeMethods.InitPropVariantFromDoubleVector(value, (uint)value.Length, this);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00005B94 File Offset: 0x00003D94
		public PropVariant(DateTime[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			System.Runtime.InteropServices.ComTypes.FILETIME[] array = new System.Runtime.InteropServices.ComTypes.FILETIME[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				array[i] = PropVariant.DateTimeToFileTime(value[i]);
			}
			PropVariantNativeMethods.InitPropVariantFromFileTimeVector(array, (uint)array.Length, this);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005C06 File Offset: 0x00003E06
		public PropVariant(bool value)
		{
			this._valueType = 11;
			this._int32 = (value ? -1 : 0);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005C28 File Offset: 0x00003E28
		public PropVariant(DateTime value)
		{
			this._valueType = 64;
			System.Runtime.InteropServices.ComTypes.FILETIME filetime = PropVariant.DateTimeToFileTime(value);
			PropVariantNativeMethods.InitPropVariantFromFileTime(ref filetime, this);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005C56 File Offset: 0x00003E56
		public PropVariant(byte value)
		{
			this._valueType = 17;
			this._byte = value;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00005C70 File Offset: 0x00003E70
		public PropVariant(sbyte value)
		{
			this._valueType = 16;
			this._sbyte = value;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00005C8A File Offset: 0x00003E8A
		public PropVariant(short value)
		{
			this._valueType = 2;
			this._short = value;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00005CA3 File Offset: 0x00003EA3
		public PropVariant(ushort value)
		{
			this._valueType = 18;
			this._ushort = value;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00005CBD File Offset: 0x00003EBD
		public PropVariant(int value)
		{
			this._valueType = 3;
			this._int32 = value;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005CD6 File Offset: 0x00003ED6
		public PropVariant(uint value)
		{
			this._valueType = 19;
			this._uint32 = value;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005CF0 File Offset: 0x00003EF0
		public PropVariant(decimal value)
		{
			this._decimal = value;
			this._valueType = 14;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005D0C File Offset: 0x00003F0C
		public PropVariant(decimal[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this._valueType = 4110;
			this._int32 = value.Length;
			this._ptr2 = Marshal.AllocCoTaskMem(value.Length * 16);
			for (int i = 0; i < value.Length; i++)
			{
				int[] bits = decimal.GetBits(value[i]);
				Marshal.Copy(bits, 0, this._ptr2, bits.Length);
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00005D95 File Offset: 0x00003F95
		public PropVariant(float value)
		{
			this._valueType = 4;
			this._float = value;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00005DB0 File Offset: 0x00003FB0
		public PropVariant(float[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this._valueType = 4100;
			this._int32 = value.Length;
			this._ptr2 = Marshal.AllocCoTaskMem(value.Length * 4);
			Marshal.Copy(value, 0, this._ptr2, value.Length);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005E12 File Offset: 0x00004012
		public PropVariant(long value)
		{
			this._long = value;
			this._valueType = 20;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005E2C File Offset: 0x0000402C
		public PropVariant(ulong value)
		{
			this._valueType = 21;
			this._ulong = value;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005E46 File Offset: 0x00004046
		public PropVariant(double value)
		{
			this._valueType = 5;
			this._double = value;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00005E5F File Offset: 0x0000405F
		internal void SetIUnknown(object value)
		{
			this._valueType = 13;
			this._ptr = Marshal.GetIUnknownForObject(value);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00005E78 File Offset: 0x00004078
		internal void SetSafeArray(Array array)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr intPtr = PropVariantNativeMethods.SafeArrayCreateVector(13, 0, (uint)array.Length);
			IntPtr ptr = PropVariantNativeMethods.SafeArrayAccessData(intPtr);
			try
			{
				for (int i = 0; i < array.Length; i++)
				{
					object value = array.GetValue(i);
					IntPtr val = (value != null) ? Marshal.GetIUnknownForObject(value) : IntPtr.Zero;
					Marshal.WriteIntPtr(ptr, i * IntPtr.Size, val);
				}
			}
			finally
			{
				PropVariantNativeMethods.SafeArrayUnaccessData(intPtr);
			}
			this._valueType = 8205;
			this._ptr = intPtr;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00005F2C File Offset: 0x0000412C
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00005F44 File Offset: 0x00004144
		public VarEnum VarType
		{
			get
			{
				return (VarEnum)this._valueType;
			}
			set
			{
				this._valueType = (ushort)value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00005F50 File Offset: 0x00004150
		public bool IsNullOrEmpty
		{
			get
			{
				return this._valueType == 0 || this._valueType == 1;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00005F78 File Offset: 0x00004178
		public object Value
		{
			get
			{
				VarEnum valueType = (VarEnum)this._valueType;
				if (valueType <= (VarEnum)4101)
				{
					switch (valueType)
					{
					case VarEnum.VT_I2:
						return this._short;
					case VarEnum.VT_I4:
					case VarEnum.VT_INT:
						return this._int32;
					case VarEnum.VT_R4:
						return this._float;
					case VarEnum.VT_R8:
						return this._double;
					case VarEnum.VT_CY:
						return this._decimal;
					case VarEnum.VT_DATE:
						return DateTime.FromOADate(this._double);
					case VarEnum.VT_BSTR:
						return Marshal.PtrToStringBSTR(this._ptr);
					case VarEnum.VT_DISPATCH:
						return Marshal.GetObjectForIUnknown(this._ptr);
					case VarEnum.VT_ERROR:
						return this._long;
					case VarEnum.VT_BOOL:
						return this._int32 == -1;
					case VarEnum.VT_VARIANT:
					case (VarEnum)15:
					case VarEnum.VT_VOID:
					case VarEnum.VT_HRESULT:
					case VarEnum.VT_PTR:
					case VarEnum.VT_SAFEARRAY:
					case VarEnum.VT_CARRAY:
					case VarEnum.VT_USERDEFINED:
						break;
					case VarEnum.VT_UNKNOWN:
						return Marshal.GetObjectForIUnknown(this._ptr);
					case VarEnum.VT_DECIMAL:
						return this._decimal;
					case VarEnum.VT_I1:
						return this._sbyte;
					case VarEnum.VT_UI1:
						return this._byte;
					case VarEnum.VT_UI2:
						return this._ushort;
					case VarEnum.VT_UI4:
					case VarEnum.VT_UINT:
						return this._uint32;
					case VarEnum.VT_I8:
						return this._long;
					case VarEnum.VT_UI8:
						return this._ulong;
					case VarEnum.VT_LPSTR:
						return Marshal.PtrToStringAnsi(this._ptr);
					case VarEnum.VT_LPWSTR:
						return Marshal.PtrToStringUni(this._ptr);
					default:
						switch (valueType)
						{
						case VarEnum.VT_FILETIME:
							return DateTime.FromFileTime(this._long);
						case VarEnum.VT_BLOB:
							return this.GetBlobData();
						default:
							switch (valueType)
							{
							case (VarEnum)4098:
								return this.GetVector<short>();
							case (VarEnum)4099:
								return this.GetVector<int>();
							case (VarEnum)4100:
								return this.GetVector<float>();
							case (VarEnum)4101:
								return this.GetVector<double>();
							}
							break;
						}
						break;
					}
				}
				else if (valueType <= (VarEnum)4127)
				{
					switch (valueType)
					{
					case (VarEnum)4107:
						return this.GetVector<bool>();
					case (VarEnum)4108:
					case (VarEnum)4109:
					case (VarEnum)4111:
					case (VarEnum)4112:
					case (VarEnum)4113:
						break;
					case (VarEnum)4110:
						return this.GetVector<decimal>();
					case (VarEnum)4114:
						return this.GetVector<ushort>();
					case (VarEnum)4115:
						return this.GetVector<uint>();
					case (VarEnum)4116:
						return this.GetVector<long>();
					case (VarEnum)4117:
						return this.GetVector<ulong>();
					default:
						if (valueType == (VarEnum)4127)
						{
							return this.GetVector<string>();
						}
						break;
					}
				}
				else
				{
					if (valueType == (VarEnum)4160)
					{
						return this.GetVector<DateTime>();
					}
					if (valueType == (VarEnum)8205)
					{
						return PropVariant.CrackSingleDimSafeArray(this._ptr);
					}
				}
				return null;
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000062B0 File Offset: 0x000044B0
		private static long GetFileTimeAsLong(ref System.Runtime.InteropServices.ComTypes.FILETIME val)
		{
			return ((long)val.dwHighDateTime << 32) + (long)val.dwLowDateTime;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000062D4 File Offset: 0x000044D4
		private static System.Runtime.InteropServices.ComTypes.FILETIME DateTimeToFileTime(DateTime value)
		{
			long num = value.ToFileTime();
			return new System.Runtime.InteropServices.ComTypes.FILETIME
			{
				dwLowDateTime = (int)(num & (long)((ulong)-1)),
				dwHighDateTime = (int)(num >> 32)
			};
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006310 File Offset: 0x00004510
		private object GetBlobData()
		{
			byte[] array = new byte[this._int32];
			IntPtr ptr = this._ptr2;
			Marshal.Copy(ptr, array, 0, this._int32);
			return array;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006348 File Offset: 0x00004548
		private Array GetVector<T>()
		{
			int num = PropVariantNativeMethods.PropVariantGetElementCount(this);
			Array result;
			if (num <= 0)
			{
				result = null;
			}
			else
			{
				lock (PropVariant._padlock)
				{
					if (PropVariant._vectorActions == null)
					{
						PropVariant._vectorActions = PropVariant.GenerateVectorActions();
					}
				}
				Action<PropVariant, Array, uint> action;
				if (!PropVariant._vectorActions.TryGetValue(typeof(T), out action))
				{
					throw new InvalidCastException(LocalizedMessages.PropVariantUnsupportedType);
				}
				Array array = new T[num];
				uint num2 = 0U;
				while ((ulong)num2 < (ulong)((long)num))
				{
					action(this, array, num2);
					num2 += 1U;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006410 File Offset: 0x00004610
		private static Array CrackSingleDimSafeArray(IntPtr psa)
		{
			uint num = PropVariantNativeMethods.SafeArrayGetDim(psa);
			if (num != 1U)
			{
				throw new ArgumentException(LocalizedMessages.PropVariantMultiDimArray, "psa");
			}
			int num2 = PropVariantNativeMethods.SafeArrayGetLBound(psa, 1U);
			int num3 = PropVariantNativeMethods.SafeArrayGetUBound(psa, 1U);
			int num4 = num3 - num2 + 1;
			object[] array = new object[num4];
			for (int i = num2; i <= num3; i++)
			{
				array[i] = PropVariantNativeMethods.SafeArrayGetElement(psa, ref i);
			}
			return array;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000648D File Offset: 0x0000468D
		public void Dispose()
		{
			PropVariantNativeMethods.PropVariantClear(this);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000064A0 File Offset: 0x000046A0
		~PropVariant()
		{
			this.Dispose();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000064D4 File Offset: 0x000046D4
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}: {1}", new object[]
			{
				this.Value,
				this.VarType.ToString()
			});
		}

		// Token: 0x0400024D RID: 589
		private static Dictionary<Type, Action<PropVariant, Array, uint>> _vectorActions = null;

		// Token: 0x0400024E RID: 590
		private static Dictionary<Type, Func<object, PropVariant>> _cache = new Dictionary<Type, Func<object, PropVariant>>();

		// Token: 0x0400024F RID: 591
		private static object _padlock = new object();

		// Token: 0x04000250 RID: 592
		[FieldOffset(0)]
		private decimal _decimal;

		// Token: 0x04000251 RID: 593
		[FieldOffset(0)]
		private ushort _valueType;

		// Token: 0x04000252 RID: 594
		[FieldOffset(12)]
		private IntPtr _ptr2;

		// Token: 0x04000253 RID: 595
		[FieldOffset(8)]
		private IntPtr _ptr;

		// Token: 0x04000254 RID: 596
		[FieldOffset(8)]
		private int _int32;

		// Token: 0x04000255 RID: 597
		[FieldOffset(8)]
		private uint _uint32;

		// Token: 0x04000256 RID: 598
		[FieldOffset(8)]
		private byte _byte;

		// Token: 0x04000257 RID: 599
		[FieldOffset(8)]
		private sbyte _sbyte;

		// Token: 0x04000258 RID: 600
		[FieldOffset(8)]
		private short _short;

		// Token: 0x04000259 RID: 601
		[FieldOffset(8)]
		private ushort _ushort;

		// Token: 0x0400025A RID: 602
		[FieldOffset(8)]
		private long _long;

		// Token: 0x0400025B RID: 603
		[FieldOffset(8)]
		private ulong _ulong;

		// Token: 0x0400025C RID: 604
		[FieldOffset(8)]
		private double _double;

		// Token: 0x0400025D RID: 605
		[FieldOffset(8)]
		private float _float;
	}
}
