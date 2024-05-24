using System;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B0 RID: 2480
	[SecurityCritical]
	[StructLayout(LayoutKind.Explicit)]
	internal struct Variant
	{
		// Token: 0x0600632F RID: 25391 RVA: 0x00152260 File Offset: 0x00150460
		internal static bool IsPrimitiveType(VarEnum varEnum)
		{
			switch (varEnum)
			{
			case VarEnum.VT_I2:
			case VarEnum.VT_I4:
			case VarEnum.VT_R4:
			case VarEnum.VT_R8:
			case VarEnum.VT_DATE:
			case VarEnum.VT_BSTR:
			case VarEnum.VT_BOOL:
			case VarEnum.VT_DECIMAL:
			case VarEnum.VT_I1:
			case VarEnum.VT_UI1:
			case VarEnum.VT_UI2:
			case VarEnum.VT_UI4:
			case VarEnum.VT_I8:
			case VarEnum.VT_UI8:
			case VarEnum.VT_INT:
			case VarEnum.VT_UINT:
				return true;
			}
			return false;
		}

		// Token: 0x06006330 RID: 25392 RVA: 0x001522D4 File Offset: 0x001504D4
		public unsafe void CopyFromIndirect(object value)
		{
			VarEnum varEnum = this.VariantType & (VarEnum)(-16385);
			if (value == null)
			{
				if (varEnum == VarEnum.VT_DISPATCH || varEnum == VarEnum.VT_UNKNOWN || varEnum == VarEnum.VT_BSTR)
				{
					*(IntPtr*)((void*)this._typeUnion._unionTypes._byref) = IntPtr.Zero;
				}
				return;
			}
			if (!AppContextSwitches.DoNotMarshalOutByrefSafeArrayOnInvoke && (varEnum & VarEnum.VT_ARRAY) != VarEnum.VT_EMPTY)
			{
				Variant variant;
				Marshal.GetNativeVariantForObject(value, (IntPtr)((void*)(&variant)));
				*(IntPtr*)((void*)this._typeUnion._unionTypes._byref) = variant._typeUnion._unionTypes._byref;
				return;
			}
			switch (varEnum)
			{
			case VarEnum.VT_I2:
				*(short*)((void*)this._typeUnion._unionTypes._byref) = (short)value;
				return;
			case VarEnum.VT_I4:
			case VarEnum.VT_INT:
				*(int*)((void*)this._typeUnion._unionTypes._byref) = (int)value;
				return;
			case VarEnum.VT_R4:
				*(float*)((void*)this._typeUnion._unionTypes._byref) = (float)value;
				return;
			case VarEnum.VT_R8:
				*(double*)((void*)this._typeUnion._unionTypes._byref) = (double)value;
				return;
			case VarEnum.VT_CY:
				*(long*)((void*)this._typeUnion._unionTypes._byref) = decimal.ToOACurrency((decimal)value);
				return;
			case VarEnum.VT_DATE:
				*(double*)((void*)this._typeUnion._unionTypes._byref) = ((DateTime)value).ToOADate();
				return;
			case VarEnum.VT_BSTR:
				*(IntPtr*)((void*)this._typeUnion._unionTypes._byref) = Marshal.StringToBSTR((string)value);
				return;
			case VarEnum.VT_DISPATCH:
				*(IntPtr*)((void*)this._typeUnion._unionTypes._byref) = Marshal.GetIDispatchForObject(value);
				return;
			case VarEnum.VT_ERROR:
				*(int*)((void*)this._typeUnion._unionTypes._byref) = ((ErrorWrapper)value).ErrorCode;
				return;
			case VarEnum.VT_BOOL:
				*(short*)((void*)this._typeUnion._unionTypes._byref) = (((bool)value) ? -1 : 0);
				return;
			case VarEnum.VT_VARIANT:
				Marshal.GetNativeVariantForObject(value, this._typeUnion._unionTypes._byref);
				return;
			case VarEnum.VT_UNKNOWN:
				*(IntPtr*)((void*)this._typeUnion._unionTypes._byref) = Marshal.GetIUnknownForObject(value);
				return;
			case VarEnum.VT_DECIMAL:
				*(decimal*)((void*)this._typeUnion._unionTypes._byref) = (decimal)value;
				return;
			case VarEnum.VT_I1:
				*(byte*)((void*)this._typeUnion._unionTypes._byref) = (byte)((sbyte)value);
				return;
			case VarEnum.VT_UI1:
				*(byte*)((void*)this._typeUnion._unionTypes._byref) = (byte)value;
				return;
			case VarEnum.VT_UI2:
				*(short*)((void*)this._typeUnion._unionTypes._byref) = (short)((ushort)value);
				return;
			case VarEnum.VT_UI4:
			case VarEnum.VT_UINT:
				*(int*)((void*)this._typeUnion._unionTypes._byref) = (int)((uint)value);
				return;
			case VarEnum.VT_I8:
				*(long*)((void*)this._typeUnion._unionTypes._byref) = (long)value;
				return;
			case VarEnum.VT_UI8:
				*(long*)((void*)this._typeUnion._unionTypes._byref) = (long)((ulong)value);
				return;
			}
			throw new ArgumentException("invalid argument type");
		}

		// Token: 0x06006331 RID: 25393 RVA: 0x00152614 File Offset: 0x00150814
		public unsafe object ToObject()
		{
			if (this.IsEmpty)
			{
				return null;
			}
			switch (this.VariantType)
			{
			case VarEnum.VT_NULL:
				return DBNull.Value;
			case VarEnum.VT_I2:
				return this.AsI2;
			case VarEnum.VT_I4:
				return this.AsI4;
			case VarEnum.VT_R4:
				return this.AsR4;
			case VarEnum.VT_R8:
				return this.AsR8;
			case VarEnum.VT_CY:
				return this.AsCy;
			case VarEnum.VT_DATE:
				return this.AsDate;
			case VarEnum.VT_BSTR:
				return this.AsBstr;
			case VarEnum.VT_DISPATCH:
				return this.AsDispatch;
			case VarEnum.VT_ERROR:
				return this.AsError;
			case VarEnum.VT_BOOL:
				return this.AsBool;
			case VarEnum.VT_UNKNOWN:
				return this.AsUnknown;
			case VarEnum.VT_DECIMAL:
				return this.AsDecimal;
			case VarEnum.VT_I1:
				return this.AsI1;
			case VarEnum.VT_UI1:
				return this.AsUi1;
			case VarEnum.VT_UI2:
				return this.AsUi2;
			case VarEnum.VT_UI4:
				return this.AsUi4;
			case VarEnum.VT_I8:
				return this.AsI8;
			case VarEnum.VT_UI8:
				return this.AsUi8;
			case VarEnum.VT_INT:
				return this.AsInt;
			case VarEnum.VT_UINT:
				return this.AsUint;
			}
			object objectForNativeVariant;
			try
			{
				try
				{
					fixed (Variant* ptr = &this)
					{
						void* value = (void*)ptr;
						objectForNativeVariant = Marshal.GetObjectForNativeVariant((IntPtr)value);
					}
				}
				finally
				{
					Variant* ptr = null;
				}
			}
			catch (Exception inner)
			{
				throw new NotImplementedException("Variant.ToObject cannot handle" + this.VariantType.ToString(), inner);
			}
			return objectForNativeVariant;
		}

		// Token: 0x06006332 RID: 25394 RVA: 0x001527E0 File Offset: 0x001509E0
		public unsafe void Clear()
		{
			VarEnum variantType = this.VariantType;
			if ((variantType & VarEnum.VT_BYREF) != VarEnum.VT_EMPTY)
			{
				this.VariantType = VarEnum.VT_EMPTY;
				return;
			}
			if ((variantType & VarEnum.VT_ARRAY) != VarEnum.VT_EMPTY || variantType == VarEnum.VT_BSTR || variantType == VarEnum.VT_UNKNOWN || variantType == VarEnum.VT_DISPATCH || variantType == VarEnum.VT_VARIANT || variantType == VarEnum.VT_RECORD || variantType == VarEnum.VT_VARIANT)
			{
				fixed (Variant* ptr = &this)
				{
					void* value = (void*)ptr;
					NativeMethods.VariantClear((IntPtr)value);
				}
				return;
			}
			this.VariantType = VarEnum.VT_EMPTY;
		}

		// Token: 0x17001121 RID: 4385
		// (get) Token: 0x06006333 RID: 25395 RVA: 0x00152846 File Offset: 0x00150A46
		// (set) Token: 0x06006334 RID: 25396 RVA: 0x00152853 File Offset: 0x00150A53
		public VarEnum VariantType
		{
			get
			{
				return (VarEnum)this._typeUnion._vt;
			}
			set
			{
				this._typeUnion._vt = (ushort)value;
			}
		}

		// Token: 0x17001122 RID: 4386
		// (get) Token: 0x06006335 RID: 25397 RVA: 0x00152862 File Offset: 0x00150A62
		internal bool IsEmpty
		{
			get
			{
				return this._typeUnion._vt == 0;
			}
		}

		// Token: 0x17001123 RID: 4387
		// (get) Token: 0x06006336 RID: 25398 RVA: 0x00152872 File Offset: 0x00150A72
		internal bool IsByRef
		{
			get
			{
				return (this._typeUnion._vt & 16384) > 0;
			}
		}

		// Token: 0x06006337 RID: 25399 RVA: 0x00152888 File Offset: 0x00150A88
		public void SetAsNULL()
		{
			this.VariantType = VarEnum.VT_NULL;
		}

		// Token: 0x17001124 RID: 4388
		// (get) Token: 0x06006338 RID: 25400 RVA: 0x00152891 File Offset: 0x00150A91
		// (set) Token: 0x06006339 RID: 25401 RVA: 0x001528A3 File Offset: 0x00150AA3
		public sbyte AsI1
		{
			get
			{
				return this._typeUnion._unionTypes._i1;
			}
			set
			{
				this.VariantType = VarEnum.VT_I1;
				this._typeUnion._unionTypes._i1 = value;
			}
		}

		// Token: 0x17001125 RID: 4389
		// (get) Token: 0x0600633A RID: 25402 RVA: 0x001528BE File Offset: 0x00150ABE
		// (set) Token: 0x0600633B RID: 25403 RVA: 0x001528D0 File Offset: 0x00150AD0
		public short AsI2
		{
			get
			{
				return this._typeUnion._unionTypes._i2;
			}
			set
			{
				this.VariantType = VarEnum.VT_I2;
				this._typeUnion._unionTypes._i2 = value;
			}
		}

		// Token: 0x17001126 RID: 4390
		// (get) Token: 0x0600633C RID: 25404 RVA: 0x001528EA File Offset: 0x00150AEA
		// (set) Token: 0x0600633D RID: 25405 RVA: 0x001528FC File Offset: 0x00150AFC
		public int AsI4
		{
			get
			{
				return this._typeUnion._unionTypes._i4;
			}
			set
			{
				this.VariantType = VarEnum.VT_I4;
				this._typeUnion._unionTypes._i4 = value;
			}
		}

		// Token: 0x17001127 RID: 4391
		// (get) Token: 0x0600633E RID: 25406 RVA: 0x00152916 File Offset: 0x00150B16
		// (set) Token: 0x0600633F RID: 25407 RVA: 0x00152928 File Offset: 0x00150B28
		public long AsI8
		{
			get
			{
				return this._typeUnion._unionTypes._i8;
			}
			set
			{
				this.VariantType = VarEnum.VT_I8;
				this._typeUnion._unionTypes._i8 = value;
			}
		}

		// Token: 0x17001128 RID: 4392
		// (get) Token: 0x06006340 RID: 25408 RVA: 0x00152943 File Offset: 0x00150B43
		// (set) Token: 0x06006341 RID: 25409 RVA: 0x00152955 File Offset: 0x00150B55
		public byte AsUi1
		{
			get
			{
				return this._typeUnion._unionTypes._ui1;
			}
			set
			{
				this.VariantType = VarEnum.VT_UI1;
				this._typeUnion._unionTypes._ui1 = value;
			}
		}

		// Token: 0x17001129 RID: 4393
		// (get) Token: 0x06006342 RID: 25410 RVA: 0x00152970 File Offset: 0x00150B70
		// (set) Token: 0x06006343 RID: 25411 RVA: 0x00152982 File Offset: 0x00150B82
		public ushort AsUi2
		{
			get
			{
				return this._typeUnion._unionTypes._ui2;
			}
			set
			{
				this.VariantType = VarEnum.VT_UI2;
				this._typeUnion._unionTypes._ui2 = value;
			}
		}

		// Token: 0x1700112A RID: 4394
		// (get) Token: 0x06006344 RID: 25412 RVA: 0x0015299D File Offset: 0x00150B9D
		// (set) Token: 0x06006345 RID: 25413 RVA: 0x001529AF File Offset: 0x00150BAF
		public uint AsUi4
		{
			get
			{
				return this._typeUnion._unionTypes._ui4;
			}
			set
			{
				this.VariantType = VarEnum.VT_UI4;
				this._typeUnion._unionTypes._ui4 = value;
			}
		}

		// Token: 0x1700112B RID: 4395
		// (get) Token: 0x06006346 RID: 25414 RVA: 0x001529CA File Offset: 0x00150BCA
		// (set) Token: 0x06006347 RID: 25415 RVA: 0x001529DC File Offset: 0x00150BDC
		public ulong AsUi8
		{
			get
			{
				return this._typeUnion._unionTypes._ui8;
			}
			set
			{
				this.VariantType = VarEnum.VT_UI8;
				this._typeUnion._unionTypes._ui8 = value;
			}
		}

		// Token: 0x1700112C RID: 4396
		// (get) Token: 0x06006348 RID: 25416 RVA: 0x001529F7 File Offset: 0x00150BF7
		// (set) Token: 0x06006349 RID: 25417 RVA: 0x00152A09 File Offset: 0x00150C09
		public int AsInt
		{
			get
			{
				return this._typeUnion._unionTypes._int;
			}
			set
			{
				this.VariantType = VarEnum.VT_INT;
				this._typeUnion._unionTypes._int = value;
			}
		}

		// Token: 0x1700112D RID: 4397
		// (get) Token: 0x0600634A RID: 25418 RVA: 0x00152A24 File Offset: 0x00150C24
		// (set) Token: 0x0600634B RID: 25419 RVA: 0x00152A36 File Offset: 0x00150C36
		public uint AsUint
		{
			get
			{
				return this._typeUnion._unionTypes._uint;
			}
			set
			{
				this.VariantType = VarEnum.VT_UINT;
				this._typeUnion._unionTypes._uint = value;
			}
		}

		// Token: 0x1700112E RID: 4398
		// (get) Token: 0x0600634C RID: 25420 RVA: 0x00152A51 File Offset: 0x00150C51
		// (set) Token: 0x0600634D RID: 25421 RVA: 0x00152A66 File Offset: 0x00150C66
		public bool AsBool
		{
			get
			{
				return this._typeUnion._unionTypes._bool != 0;
			}
			set
			{
				this.VariantType = VarEnum.VT_BOOL;
				this._typeUnion._unionTypes._bool = (value ? -1 : 0);
			}
		}

		// Token: 0x1700112F RID: 4399
		// (get) Token: 0x0600634E RID: 25422 RVA: 0x00152A87 File Offset: 0x00150C87
		// (set) Token: 0x0600634F RID: 25423 RVA: 0x00152A99 File Offset: 0x00150C99
		public int AsError
		{
			get
			{
				return this._typeUnion._unionTypes._error;
			}
			set
			{
				this.VariantType = VarEnum.VT_ERROR;
				this._typeUnion._unionTypes._error = value;
			}
		}

		// Token: 0x17001130 RID: 4400
		// (get) Token: 0x06006350 RID: 25424 RVA: 0x00152AB4 File Offset: 0x00150CB4
		// (set) Token: 0x06006351 RID: 25425 RVA: 0x00152AC6 File Offset: 0x00150CC6
		public float AsR4
		{
			get
			{
				return this._typeUnion._unionTypes._r4;
			}
			set
			{
				this.VariantType = VarEnum.VT_R4;
				this._typeUnion._unionTypes._r4 = value;
			}
		}

		// Token: 0x17001131 RID: 4401
		// (get) Token: 0x06006352 RID: 25426 RVA: 0x00152AE0 File Offset: 0x00150CE0
		// (set) Token: 0x06006353 RID: 25427 RVA: 0x00152AF2 File Offset: 0x00150CF2
		public double AsR8
		{
			get
			{
				return this._typeUnion._unionTypes._r8;
			}
			set
			{
				this.VariantType = VarEnum.VT_R8;
				this._typeUnion._unionTypes._r8 = value;
			}
		}

		// Token: 0x17001132 RID: 4402
		// (get) Token: 0x06006354 RID: 25428 RVA: 0x00152B0C File Offset: 0x00150D0C
		// (set) Token: 0x06006355 RID: 25429 RVA: 0x00152B33 File Offset: 0x00150D33
		public decimal AsDecimal
		{
			get
			{
				Variant variant = this;
				variant._typeUnion._vt = 0;
				return variant._decimal;
			}
			set
			{
				this.VariantType = VarEnum.VT_DECIMAL;
				this._decimal = value;
				this._typeUnion._vt = 14;
			}
		}

		// Token: 0x17001133 RID: 4403
		// (get) Token: 0x06006356 RID: 25430 RVA: 0x00152B51 File Offset: 0x00150D51
		// (set) Token: 0x06006357 RID: 25431 RVA: 0x00152B68 File Offset: 0x00150D68
		public decimal AsCy
		{
			get
			{
				return decimal.FromOACurrency(this._typeUnion._unionTypes._cy);
			}
			set
			{
				this.VariantType = VarEnum.VT_CY;
				this._typeUnion._unionTypes._cy = decimal.ToOACurrency(value);
			}
		}

		// Token: 0x17001134 RID: 4404
		// (get) Token: 0x06006358 RID: 25432 RVA: 0x00152B87 File Offset: 0x00150D87
		// (set) Token: 0x06006359 RID: 25433 RVA: 0x00152B9E File Offset: 0x00150D9E
		public DateTime AsDate
		{
			get
			{
				return DateTime.FromOADate(this._typeUnion._unionTypes._date);
			}
			set
			{
				this.VariantType = VarEnum.VT_DATE;
				this._typeUnion._unionTypes._date = value.ToOADate();
			}
		}

		// Token: 0x17001135 RID: 4405
		// (get) Token: 0x0600635A RID: 25434 RVA: 0x00152BBE File Offset: 0x00150DBE
		// (set) Token: 0x0600635B RID: 25435 RVA: 0x00152BD5 File Offset: 0x00150DD5
		public string AsBstr
		{
			get
			{
				return Marshal.PtrToStringBSTR(this._typeUnion._unionTypes._bstr);
			}
			set
			{
				this.VariantType = VarEnum.VT_BSTR;
				this._typeUnion._unionTypes._bstr = Marshal.StringToBSTR(value);
			}
		}

		// Token: 0x17001136 RID: 4406
		// (get) Token: 0x0600635C RID: 25436 RVA: 0x00152BF4 File Offset: 0x00150DF4
		// (set) Token: 0x0600635D RID: 25437 RVA: 0x00152C29 File Offset: 0x00150E29
		public object AsUnknown
		{
			get
			{
				if (this._typeUnion._unionTypes._unknown == IntPtr.Zero)
				{
					return null;
				}
				return Marshal.GetObjectForIUnknown(this._typeUnion._unionTypes._unknown);
			}
			set
			{
				this.VariantType = VarEnum.VT_UNKNOWN;
				if (value == null)
				{
					this._typeUnion._unionTypes._unknown = IntPtr.Zero;
					return;
				}
				this._typeUnion._unionTypes._unknown = Marshal.GetIUnknownForObject(value);
			}
		}

		// Token: 0x17001137 RID: 4407
		// (get) Token: 0x0600635E RID: 25438 RVA: 0x00152C62 File Offset: 0x00150E62
		// (set) Token: 0x0600635F RID: 25439 RVA: 0x00152C97 File Offset: 0x00150E97
		public object AsDispatch
		{
			get
			{
				if (this._typeUnion._unionTypes._dispatch == IntPtr.Zero)
				{
					return null;
				}
				return Marshal.GetObjectForIUnknown(this._typeUnion._unionTypes._dispatch);
			}
			set
			{
				this.VariantType = VarEnum.VT_DISPATCH;
				if (value == null)
				{
					this._typeUnion._unionTypes._dispatch = IntPtr.Zero;
					return;
				}
				this._typeUnion._unionTypes._dispatch = Marshal.GetIDispatchForObject(value);
			}
		}

		// Token: 0x17001138 RID: 4408
		// (get) Token: 0x06006360 RID: 25440 RVA: 0x00152CD0 File Offset: 0x00150ED0
		internal IntPtr AsByRefVariant
		{
			get
			{
				return this._typeUnion._unionTypes._pvarVal;
			}
		}

		// Token: 0x04002CBC RID: 11452
		[FieldOffset(0)]
		private Variant.TypeUnion _typeUnion;

		// Token: 0x04002CBD RID: 11453
		[FieldOffset(0)]
		private decimal _decimal;

		// Token: 0x02000C9C RID: 3228
		private struct TypeUnion
		{
			// Token: 0x0400385A RID: 14426
			internal ushort _vt;

			// Token: 0x0400385B RID: 14427
			internal ushort _wReserved1;

			// Token: 0x0400385C RID: 14428
			internal ushort _wReserved2;

			// Token: 0x0400385D RID: 14429
			internal ushort _wReserved3;

			// Token: 0x0400385E RID: 14430
			internal Variant.UnionTypes _unionTypes;
		}

		// Token: 0x02000C9D RID: 3229
		private struct Record
		{
			// Token: 0x0400385F RID: 14431
			private IntPtr _record;

			// Token: 0x04003860 RID: 14432
			private IntPtr _recordInfo;
		}

		// Token: 0x02000C9E RID: 3230
		[StructLayout(LayoutKind.Explicit)]
		private struct UnionTypes
		{
			// Token: 0x04003861 RID: 14433
			[FieldOffset(0)]
			internal sbyte _i1;

			// Token: 0x04003862 RID: 14434
			[FieldOffset(0)]
			internal short _i2;

			// Token: 0x04003863 RID: 14435
			[FieldOffset(0)]
			internal int _i4;

			// Token: 0x04003864 RID: 14436
			[FieldOffset(0)]
			internal long _i8;

			// Token: 0x04003865 RID: 14437
			[FieldOffset(0)]
			internal byte _ui1;

			// Token: 0x04003866 RID: 14438
			[FieldOffset(0)]
			internal ushort _ui2;

			// Token: 0x04003867 RID: 14439
			[FieldOffset(0)]
			internal uint _ui4;

			// Token: 0x04003868 RID: 14440
			[FieldOffset(0)]
			internal ulong _ui8;

			// Token: 0x04003869 RID: 14441
			[FieldOffset(0)]
			internal int _int;

			// Token: 0x0400386A RID: 14442
			[FieldOffset(0)]
			internal uint _uint;

			// Token: 0x0400386B RID: 14443
			[FieldOffset(0)]
			internal short _bool;

			// Token: 0x0400386C RID: 14444
			[FieldOffset(0)]
			internal int _error;

			// Token: 0x0400386D RID: 14445
			[FieldOffset(0)]
			internal float _r4;

			// Token: 0x0400386E RID: 14446
			[FieldOffset(0)]
			internal double _r8;

			// Token: 0x0400386F RID: 14447
			[FieldOffset(0)]
			internal long _cy;

			// Token: 0x04003870 RID: 14448
			[FieldOffset(0)]
			internal double _date;

			// Token: 0x04003871 RID: 14449
			[FieldOffset(0)]
			internal IntPtr _bstr;

			// Token: 0x04003872 RID: 14450
			[FieldOffset(0)]
			internal IntPtr _unknown;

			// Token: 0x04003873 RID: 14451
			[FieldOffset(0)]
			internal IntPtr _dispatch;

			// Token: 0x04003874 RID: 14452
			[FieldOffset(0)]
			internal IntPtr _pvarVal;

			// Token: 0x04003875 RID: 14453
			[FieldOffset(0)]
			internal IntPtr _byref;

			// Token: 0x04003876 RID: 14454
			[FieldOffset(0)]
			internal Variant.Record _record;
		}
	}
}
