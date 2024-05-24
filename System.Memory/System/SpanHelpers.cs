﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	// Token: 0x02000013 RID: 19
	internal static class SpanHelpers
	{
		// Token: 0x0600010D RID: 269 RVA: 0x00005E4D File Offset: 0x0000404D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int BinarySearch<T, TComparable>(this ReadOnlySpan<T> span, TComparable comparable) where TComparable : IComparable<T>
		{
			if (comparable == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.comparable);
			}
			return SpanHelpers.BinarySearch<T, TComparable>(MemoryMarshal.GetReference<T>(span), span.Length, comparable);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005E70 File Offset: 0x00004070
		public unsafe static int BinarySearch<T, TComparable>(ref T spanStart, int length, TComparable comparable) where TComparable : IComparable<T>
		{
			int i = 0;
			int num = length - 1;
			while (i <= num)
			{
				int num2 = (int)((uint)(num + i) >> 1);
				int num3 = comparable.CompareTo(*Unsafe.Add<T>(ref spanStart, num2));
				if (num3 == 0)
				{
					return num2;
				}
				if (num3 > 0)
				{
					i = num2 + 1;
				}
				else
				{
					num = num2 - 1;
				}
			}
			return ~i;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005EC0 File Offset: 0x000040C0
		public static int IndexOf(ref byte searchSpace, int searchSpaceLength, ref byte value, int valueLength)
		{
			if (valueLength == 0)
			{
				return 0;
			}
			byte value2 = value;
			ref byte second = ref Unsafe.Add<byte>(ref value, 1);
			int num = valueLength - 1;
			int num2 = 0;
			for (;;)
			{
				int num3 = searchSpaceLength - num2 - num;
				if (num3 <= 0)
				{
					return -1;
				}
				int num4 = SpanHelpers.IndexOf(Unsafe.Add<byte>(ref searchSpace, num2), value2, num3);
				if (num4 == -1)
				{
					return -1;
				}
				num2 += num4;
				if (SpanHelpers.SequenceEqual<byte>(Unsafe.Add<byte>(ref searchSpace, num2 + 1), ref second, num))
				{
					break;
				}
				num2++;
			}
			return num2;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005F28 File Offset: 0x00004128
		public unsafe static int IndexOfAny(ref byte searchSpace, int searchSpaceLength, ref byte value, int valueLength)
		{
			if (valueLength == 0)
			{
				return 0;
			}
			int num = -1;
			for (int i = 0; i < valueLength; i++)
			{
				int num2 = SpanHelpers.IndexOf(ref searchSpace, *Unsafe.Add<byte>(ref value, i), searchSpaceLength);
				if (num2 < num)
				{
					num = num2;
					searchSpaceLength = num2;
					if (num == 0)
					{
						break;
					}
				}
			}
			return num;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005F68 File Offset: 0x00004168
		public unsafe static int LastIndexOfAny(ref byte searchSpace, int searchSpaceLength, ref byte value, int valueLength)
		{
			if (valueLength == 0)
			{
				return 0;
			}
			int num = -1;
			for (int i = 0; i < valueLength; i++)
			{
				int num2 = SpanHelpers.LastIndexOf(ref searchSpace, *Unsafe.Add<byte>(ref value, i), searchSpaceLength);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005FA0 File Offset: 0x000041A0
		public unsafe static int IndexOf(ref byte searchSpace, byte value, int length)
		{
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)length;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count * 2)
			{
				int num = Unsafe.AsPointer<byte>(ref searchSpace) & Vector<byte>.Count - 1;
				intPtr2 = (IntPtr)(Vector<byte>.Count - num & Vector<byte>.Count - 1);
			}
			Vector<byte> vector2;
			for (;;)
			{
				if ((void*)intPtr2 < 8)
				{
					if ((void*)intPtr2 >= 4)
					{
						intPtr2 -= 4;
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr))
						{
							goto IL_242;
						}
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1))
						{
							goto IL_24A;
						}
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2))
						{
							goto IL_258;
						}
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3))
						{
							goto IL_266;
						}
						intPtr += 4;
					}
					while ((void*)intPtr2 != null)
					{
						intPtr2 -= 1;
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr))
						{
							goto IL_242;
						}
						intPtr += 1;
					}
					if (!Vector.IsHardwareAccelerated || (void*)intPtr >= length)
					{
						return -1;
					}
					intPtr2 = (IntPtr)(length - (void*)intPtr & ~(Vector<byte>.Count - 1));
					Vector<byte> vector = SpanHelpers.GetVector(value);
					while ((void*)intPtr2 != (void*)intPtr)
					{
						vector2 = Vector.Equals<byte>(vector, Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr)));
						if (!Vector<byte>.Zero.Equals(vector2))
						{
							goto IL_204;
						}
						intPtr += Vector<byte>.Count;
					}
					if ((void*)intPtr >= length)
					{
						return -1;
					}
					intPtr2 = (IntPtr)(length - (void*)intPtr);
				}
				else
				{
					intPtr2 -= 8;
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr))
					{
						goto IL_242;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1))
					{
						goto IL_24A;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2))
					{
						goto IL_258;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3))
					{
						goto IL_266;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 4))
					{
						goto IL_274;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 5))
					{
						goto IL_282;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 6))
					{
						goto IL_290;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 7))
					{
						goto IL_29E;
					}
					intPtr += 8;
				}
			}
			IL_204:
			return (void*)intPtr + SpanHelpers.LocateFirstFoundByte(vector2);
			IL_242:
			return (void*)intPtr;
			IL_24A:
			return (void*)(intPtr + 1);
			IL_258:
			return (void*)(intPtr + 2);
			IL_266:
			return (void*)(intPtr + 3);
			IL_274:
			return (void*)(intPtr + 4);
			IL_282:
			return (void*)(intPtr + 5);
			IL_290:
			return (void*)(intPtr + 6);
			IL_29E:
			return (void*)(intPtr + 7);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00006258 File Offset: 0x00004458
		public static int LastIndexOf(ref byte searchSpace, int searchSpaceLength, ref byte value, int valueLength)
		{
			if (valueLength == 0)
			{
				return 0;
			}
			byte value2 = value;
			ref byte second = ref Unsafe.Add<byte>(ref value, 1);
			int num = valueLength - 1;
			int num2 = 0;
			int num4;
			for (;;)
			{
				int num3 = searchSpaceLength - num2 - num;
				if (num3 <= 0)
				{
					return -1;
				}
				num4 = SpanHelpers.LastIndexOf(ref searchSpace, value2, num3);
				if (num4 == -1)
				{
					return -1;
				}
				if (SpanHelpers.SequenceEqual<byte>(Unsafe.Add<byte>(ref searchSpace, num4 + 1), ref second, num))
				{
					break;
				}
				num2 += num3 - num4;
			}
			return num4;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000062B8 File Offset: 0x000044B8
		public unsafe static int LastIndexOf(ref byte searchSpace, byte value, int length)
		{
			IntPtr intPtr = (IntPtr)length;
			IntPtr intPtr2 = (IntPtr)length;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count * 2)
			{
				int num = Unsafe.AsPointer<byte>(ref searchSpace) & Vector<byte>.Count - 1;
				intPtr2 = (IntPtr)((length & Vector<byte>.Count - 1) + num & Vector<byte>.Count - 1);
			}
			Vector<byte> vector2;
			for (;;)
			{
				if ((void*)intPtr2 < 8)
				{
					if ((void*)intPtr2 >= 4)
					{
						intPtr2 -= 4;
						intPtr -= 4;
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3))
						{
							goto IL_278;
						}
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2))
						{
							goto IL_26A;
						}
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1))
						{
							goto IL_25C;
						}
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr))
						{
							break;
						}
					}
					while ((void*)intPtr2 != null)
					{
						intPtr2 -= 1;
						intPtr -= 1;
						if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr))
						{
							goto IL_254;
						}
					}
					if (!Vector.IsHardwareAccelerated || (void*)intPtr == null)
					{
						return -1;
					}
					intPtr2 = (IntPtr)((void*)intPtr & ~(Vector<byte>.Count - 1));
					Vector<byte> vector = SpanHelpers.GetVector(value);
					while ((void*)intPtr2 != Vector<byte>.Count - 1)
					{
						vector2 = Vector.Equals<byte>(vector, Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr - Vector<byte>.Count)));
						if (!Vector<byte>.Zero.Equals(vector2))
						{
							goto IL_21C;
						}
						intPtr -= Vector<byte>.Count;
						intPtr2 -= Vector<byte>.Count;
					}
					if ((void*)intPtr == null)
					{
						return -1;
					}
					intPtr2 = intPtr;
				}
				else
				{
					intPtr2 -= 8;
					intPtr -= 8;
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 7))
					{
						goto IL_2B0;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 6))
					{
						goto IL_2A2;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 5))
					{
						goto IL_294;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 4))
					{
						goto IL_286;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3))
					{
						goto IL_278;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2))
					{
						goto IL_26A;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1))
					{
						goto IL_25C;
					}
					if (value == *Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr))
					{
						break;
					}
				}
			}
			goto IL_254;
			IL_21C:
			return (int)intPtr - Vector<byte>.Count + SpanHelpers.LocateLastFoundByte(vector2);
			IL_254:
			return (void*)intPtr;
			IL_25C:
			return (void*)(intPtr + 1);
			IL_26A:
			return (void*)(intPtr + 2);
			IL_278:
			return (void*)(intPtr + 3);
			IL_286:
			return (void*)(intPtr + 4);
			IL_294:
			return (void*)(intPtr + 5);
			IL_2A2:
			return (void*)(intPtr + 6);
			IL_2B0:
			return (void*)(intPtr + 7);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00006584 File Offset: 0x00004784
		public unsafe static int IndexOfAny(ref byte searchSpace, byte value0, byte value1, int length)
		{
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)length;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count * 2)
			{
				int num = Unsafe.AsPointer<byte>(ref searchSpace) & Vector<byte>.Count - 1;
				intPtr2 = (IntPtr)(Vector<byte>.Count - num & Vector<byte>.Count - 1);
			}
			Vector<byte> vector3;
			for (;;)
			{
				if ((void*)intPtr2 < 8)
				{
					if ((void*)intPtr2 >= 4)
					{
						intPtr2 -= 4;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_2FF;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_307;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_315;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_323;
						}
						intPtr += 4;
					}
					while ((void*)intPtr2 != null)
					{
						intPtr2 -= 1;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_2FF;
						}
						intPtr += 1;
					}
					if (!Vector.IsHardwareAccelerated || (void*)intPtr >= length)
					{
						return -1;
					}
					intPtr2 = (IntPtr)(length - (void*)intPtr & ~(Vector<byte>.Count - 1));
					Vector<byte> vector = SpanHelpers.GetVector(value0);
					Vector<byte> vector2 = SpanHelpers.GetVector(value1);
					while ((void*)intPtr2 != (void*)intPtr)
					{
						Vector<byte> left = Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						vector3 = Vector.BitwiseOr<byte>(Vector.Equals<byte>(left, vector), Vector.Equals<byte>(left, vector2));
						if (!Vector<byte>.Zero.Equals(vector3))
						{
							goto IL_2C1;
						}
						intPtr += Vector<byte>.Count;
					}
					if ((void*)intPtr >= length)
					{
						return -1;
					}
					intPtr2 = (IntPtr)(length - (void*)intPtr);
				}
				else
				{
					intPtr2 -= 8;
					uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_2FF;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_307;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_315;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_323;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 4));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_331;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 5));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_33F;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 6));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_34D;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 7));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_35B;
					}
					intPtr += 8;
				}
			}
			IL_2C1:
			return (void*)intPtr + SpanHelpers.LocateFirstFoundByte(vector3);
			IL_2FF:
			return (void*)intPtr;
			IL_307:
			return (void*)(intPtr + 1);
			IL_315:
			return (void*)(intPtr + 2);
			IL_323:
			return (void*)(intPtr + 3);
			IL_331:
			return (void*)(intPtr + 4);
			IL_33F:
			return (void*)(intPtr + 5);
			IL_34D:
			return (void*)(intPtr + 6);
			IL_35B:
			return (void*)(intPtr + 7);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000068FC File Offset: 0x00004AFC
		public unsafe static int IndexOfAny(ref byte searchSpace, byte value0, byte value1, byte value2, int length)
		{
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)length;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count * 2)
			{
				int num = Unsafe.AsPointer<byte>(ref searchSpace) & Vector<byte>.Count - 1;
				intPtr2 = (IntPtr)(Vector<byte>.Count - num & Vector<byte>.Count - 1);
			}
			Vector<byte> vector4;
			for (;;)
			{
				if ((void*)intPtr2 < 8)
				{
					if ((void*)intPtr2 >= 4)
					{
						intPtr2 -= 4;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_393;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_39B;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_3A9;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_3B7;
						}
						intPtr += 4;
					}
					while ((void*)intPtr2 != null)
					{
						intPtr2 -= 1;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_393;
						}
						intPtr += 1;
					}
					if (!Vector.IsHardwareAccelerated || (void*)intPtr >= length)
					{
						return -1;
					}
					intPtr2 = (IntPtr)(length - (void*)intPtr & ~(Vector<byte>.Count - 1));
					Vector<byte> vector = SpanHelpers.GetVector(value0);
					Vector<byte> vector2 = SpanHelpers.GetVector(value1);
					Vector<byte> vector3 = SpanHelpers.GetVector(value2);
					while ((void*)intPtr2 != (void*)intPtr)
					{
						Vector<byte> left = Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						vector4 = Vector.BitwiseOr<byte>(Vector.BitwiseOr<byte>(Vector.Equals<byte>(left, vector), Vector.Equals<byte>(left, vector2)), Vector.Equals<byte>(left, vector3));
						if (!Vector<byte>.Zero.Equals(vector4))
						{
							goto IL_351;
						}
						intPtr += Vector<byte>.Count;
					}
					if ((void*)intPtr >= length)
					{
						return -1;
					}
					intPtr2 = (IntPtr)(length - (void*)intPtr);
				}
				else
				{
					intPtr2 -= 8;
					uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_393;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_39B;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3A9;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3B7;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 4));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3C5;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 5));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3D3;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 6));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3E1;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 7));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3EF;
					}
					intPtr += 8;
				}
			}
			IL_351:
			return (void*)intPtr + SpanHelpers.LocateFirstFoundByte(vector4);
			IL_393:
			return (void*)intPtr;
			IL_39B:
			return (void*)(intPtr + 1);
			IL_3A9:
			return (void*)(intPtr + 2);
			IL_3B7:
			return (void*)(intPtr + 3);
			IL_3C5:
			return (void*)(intPtr + 4);
			IL_3D3:
			return (void*)(intPtr + 5);
			IL_3E1:
			return (void*)(intPtr + 6);
			IL_3EF:
			return (void*)(intPtr + 7);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00006D08 File Offset: 0x00004F08
		public unsafe static int LastIndexOfAny(ref byte searchSpace, byte value0, byte value1, int length)
		{
			IntPtr intPtr = (IntPtr)length;
			IntPtr intPtr2 = (IntPtr)length;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count * 2)
			{
				int num = Unsafe.AsPointer<byte>(ref searchSpace) & Vector<byte>.Count - 1;
				intPtr2 = (IntPtr)((length & Vector<byte>.Count - 1) + num & Vector<byte>.Count - 1);
			}
			Vector<byte> vector3;
			for (;;)
			{
				if ((void*)intPtr2 < 8)
				{
					if ((void*)intPtr2 >= 4)
					{
						intPtr2 -= 4;
						intPtr -= 4;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_338;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_32A;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_31C;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2)
						{
							break;
						}
						if ((uint)value1 == num2)
						{
							break;
						}
					}
					while ((void*)intPtr2 != null)
					{
						intPtr2 -= 1;
						intPtr -= 1;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							goto IL_314;
						}
					}
					if (!Vector.IsHardwareAccelerated || (void*)intPtr == null)
					{
						return -1;
					}
					intPtr2 = (IntPtr)((void*)intPtr & ~(Vector<byte>.Count - 1));
					Vector<byte> vector = SpanHelpers.GetVector(value0);
					Vector<byte> vector2 = SpanHelpers.GetVector(value1);
					while ((void*)intPtr2 != Vector<byte>.Count - 1)
					{
						Vector<byte> left = Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr - Vector<byte>.Count));
						vector3 = Vector.BitwiseOr<byte>(Vector.Equals<byte>(left, vector), Vector.Equals<byte>(left, vector2));
						if (!Vector<byte>.Zero.Equals(vector3))
						{
							goto IL_2D9;
						}
						intPtr -= Vector<byte>.Count;
						intPtr2 -= Vector<byte>.Count;
					}
					if ((void*)intPtr == null)
					{
						return -1;
					}
					intPtr2 = intPtr;
				}
				else
				{
					intPtr2 -= 8;
					intPtr -= 8;
					uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 7));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_370;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 6));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_362;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 5));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_354;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 4));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_346;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_338;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_32A;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						goto IL_31C;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
					if ((uint)value0 == num2 || (uint)value1 == num2)
					{
						break;
					}
				}
			}
			goto IL_314;
			IL_2D9:
			return (int)intPtr - Vector<byte>.Count + SpanHelpers.LocateLastFoundByte(vector3);
			IL_314:
			return (void*)intPtr;
			IL_31C:
			return (void*)(intPtr + 1);
			IL_32A:
			return (void*)(intPtr + 2);
			IL_338:
			return (void*)(intPtr + 3);
			IL_346:
			return (void*)(intPtr + 4);
			IL_354:
			return (void*)(intPtr + 5);
			IL_362:
			return (void*)(intPtr + 6);
			IL_370:
			return (void*)(intPtr + 7);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007094 File Offset: 0x00005294
		public unsafe static int LastIndexOfAny(ref byte searchSpace, byte value0, byte value1, byte value2, int length)
		{
			IntPtr intPtr = (IntPtr)length;
			IntPtr intPtr2 = (IntPtr)length;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count * 2)
			{
				int num = Unsafe.AsPointer<byte>(ref searchSpace) & Vector<byte>.Count - 1;
				intPtr2 = (IntPtr)((length & Vector<byte>.Count - 1) + num & Vector<byte>.Count - 1);
			}
			Vector<byte> vector4;
			for (;;)
			{
				if ((void*)intPtr2 < 8)
				{
					if ((void*)intPtr2 >= 4)
					{
						intPtr2 -= 4;
						intPtr -= 4;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_3CF;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_3C1;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_3B3;
						}
						num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2 || (uint)value1 == num2)
						{
							break;
						}
						if ((uint)value2 == num2)
						{
							break;
						}
					}
					while ((void*)intPtr2 != null)
					{
						intPtr2 -= 1;
						intPtr -= 1;
						uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
						if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
						{
							goto IL_3AB;
						}
					}
					if (!Vector.IsHardwareAccelerated || (void*)intPtr == null)
					{
						return -1;
					}
					intPtr2 = (IntPtr)((void*)intPtr & ~(Vector<byte>.Count - 1));
					Vector<byte> vector = SpanHelpers.GetVector(value0);
					Vector<byte> vector2 = SpanHelpers.GetVector(value1);
					Vector<byte> vector3 = SpanHelpers.GetVector(value2);
					while ((void*)intPtr2 != Vector<byte>.Count - 1)
					{
						Vector<byte> left = Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr - Vector<byte>.Count));
						vector4 = Vector.BitwiseOr<byte>(Vector.BitwiseOr<byte>(Vector.Equals<byte>(left, vector), Vector.Equals<byte>(left, vector2)), Vector.Equals<byte>(left, vector3));
						if (!Vector<byte>.Zero.Equals(vector4))
						{
							goto IL_36E;
						}
						intPtr -= Vector<byte>.Count;
						intPtr2 -= Vector<byte>.Count;
					}
					if ((void*)intPtr == null)
					{
						return -1;
					}
					intPtr2 = intPtr;
				}
				else
				{
					intPtr2 -= 8;
					intPtr -= 8;
					uint num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 7));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_407;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 6));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3F9;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 5));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3EB;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 4));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3DD;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 3));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3CF;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 2));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3C1;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr + 1));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						goto IL_3B3;
					}
					num2 = (uint)(*Unsafe.AddByteOffset<byte>(ref searchSpace, intPtr));
					if ((uint)value0 == num2 || (uint)value1 == num2 || (uint)value2 == num2)
					{
						break;
					}
				}
			}
			goto IL_3AB;
			IL_36E:
			return (int)intPtr - Vector<byte>.Count + SpanHelpers.LocateLastFoundByte(vector4);
			IL_3AB:
			return (void*)intPtr;
			IL_3B3:
			return (void*)(intPtr + 1);
			IL_3C1:
			return (void*)(intPtr + 2);
			IL_3CF:
			return (void*)(intPtr + 3);
			IL_3DD:
			return (void*)(intPtr + 4);
			IL_3EB:
			return (void*)(intPtr + 5);
			IL_3F9:
			return (void*)(intPtr + 6);
			IL_407:
			return (void*)(intPtr + 7);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000074B8 File Offset: 0x000056B8
		public unsafe static bool SequenceEqual(ref byte first, ref byte second, NUInt length)
		{
			if (!Unsafe.AreSame<byte>(ref first, ref second))
			{
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)((void*)length);
				if (Vector.IsHardwareAccelerated && (void*)intPtr2 >= Vector<byte>.Count)
				{
					intPtr2 -= Vector<byte>.Count;
					while ((void*)intPtr2 != (void*)intPtr)
					{
						if (Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref first, intPtr)) != Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref second, intPtr)))
						{
							return false;
						}
						intPtr += Vector<byte>.Count;
					}
					return Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref first, intPtr2)) == Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref second, intPtr2));
				}
				if ((void*)intPtr2 >= sizeof(UIntPtr))
				{
					intPtr2 -= sizeof(UIntPtr);
					while ((void*)intPtr2 != (void*)intPtr)
					{
						if (Unsafe.ReadUnaligned<UIntPtr>(Unsafe.AddByteOffset<byte>(ref first, intPtr)) != Unsafe.ReadUnaligned<UIntPtr>(Unsafe.AddByteOffset<byte>(ref second, intPtr)))
						{
							return false;
						}
						intPtr += sizeof(UIntPtr);
					}
					return Unsafe.ReadUnaligned<UIntPtr>(Unsafe.AddByteOffset<byte>(ref first, intPtr2)) == Unsafe.ReadUnaligned<UIntPtr>(Unsafe.AddByteOffset<byte>(ref second, intPtr2));
				}
				while ((void*)intPtr2 != (void*)intPtr)
				{
					if (*Unsafe.AddByteOffset<byte>(ref first, intPtr) != *Unsafe.AddByteOffset<byte>(ref second, intPtr))
					{
						return false;
					}
					intPtr += 1;
				}
				return true;
			}
			return true;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00007608 File Offset: 0x00005808
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateFirstFoundByte(Vector<byte> match)
		{
			Vector<ulong> vector = Vector.AsVectorUInt64<byte>(match);
			ulong num = 0UL;
			int i;
			for (i = 0; i < Vector<ulong>.Count; i++)
			{
				num = vector[i];
				if (num != 0UL)
				{
					break;
				}
			}
			return i * 8 + SpanHelpers.LocateFirstFoundByte(num);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00007648 File Offset: 0x00005848
		public unsafe static int SequenceCompareTo(ref byte first, int firstLength, ref byte second, int secondLength)
		{
			if (!Unsafe.AreSame<byte>(ref first, ref second))
			{
				IntPtr value = (IntPtr)((firstLength < secondLength) ? firstLength : secondLength);
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)((void*)value);
				if (Vector.IsHardwareAccelerated && (void*)intPtr2 != Vector<byte>.Count)
				{
					intPtr2 -= Vector<byte>.Count;
					while ((void*)intPtr2 != (void*)intPtr)
					{
						if (Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref first, intPtr)) != Unsafe.ReadUnaligned<Vector<byte>>(Unsafe.AddByteOffset<byte>(ref second, intPtr)))
						{
							break;
						}
						intPtr += Vector<byte>.Count;
					}
				}
				else if ((void*)intPtr2 != sizeof(UIntPtr))
				{
					intPtr2 -= sizeof(UIntPtr);
					while ((void*)intPtr2 != (void*)intPtr)
					{
						if (Unsafe.ReadUnaligned<UIntPtr>(Unsafe.AddByteOffset<byte>(ref first, intPtr)) != Unsafe.ReadUnaligned<UIntPtr>(Unsafe.AddByteOffset<byte>(ref second, intPtr)))
						{
							break;
						}
						intPtr += sizeof(UIntPtr);
					}
				}
				while ((void*)value != (void*)intPtr)
				{
					int num = Unsafe.AddByteOffset<byte>(ref first, intPtr).CompareTo(*Unsafe.AddByteOffset<byte>(ref second, intPtr));
					if (num != 0)
					{
						return num;
					}
					intPtr += 1;
				}
			}
			return firstLength - secondLength;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00007770 File Offset: 0x00005970
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateLastFoundByte(Vector<byte> match)
		{
			Vector<ulong> vector = Vector.AsVectorUInt64<byte>(match);
			ulong num = 0UL;
			int i;
			for (i = Vector<ulong>.Count - 1; i >= 0; i--)
			{
				num = vector[i];
				if (num != 0UL)
				{
					break;
				}
			}
			return i * 8 + SpanHelpers.LocateLastFoundByte(num);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000077B0 File Offset: 0x000059B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateFirstFoundByte(ulong match)
		{
			ulong num = match ^ match - 1UL;
			return (int)(num * 283686952306184UL >> 57);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000077D4 File Offset: 0x000059D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateLastFoundByte(ulong match)
		{
			int num = 7;
			while (match > 0UL)
			{
				match <<= 8;
				num--;
			}
			return num;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000077F4 File Offset: 0x000059F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector<byte> GetVector(byte vectorByte)
		{
			return Vector.AsVectorByte<uint>(new Vector<uint>((uint)vectorByte * 16843009U));
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00007808 File Offset: 0x00005A08
		public unsafe static int SequenceCompareTo(ref char first, int firstLength, ref char second, int secondLength)
		{
			int result = firstLength - secondLength;
			if (!Unsafe.AreSame<char>(ref first, ref second))
			{
				IntPtr intPtr = (IntPtr)((firstLength < secondLength) ? firstLength : secondLength);
				IntPtr intPtr2 = (IntPtr)0;
				if ((void*)intPtr >= sizeof(UIntPtr) / 2)
				{
					if (Vector.IsHardwareAccelerated && (void*)intPtr >= Vector<ushort>.Count)
					{
						IntPtr value = intPtr - Vector<ushort>.Count;
						while (!(Unsafe.ReadUnaligned<Vector<ushort>>(Unsafe.As<char, byte>(Unsafe.Add<char>(ref first, intPtr2))) != Unsafe.ReadUnaligned<Vector<ushort>>(Unsafe.As<char, byte>(Unsafe.Add<char>(ref second, intPtr2)))))
						{
							intPtr2 += Vector<ushort>.Count;
							if ((void*)value < (void*)intPtr2)
							{
								break;
							}
						}
					}
					while ((void*)intPtr >= (void*)(intPtr2 + sizeof(UIntPtr) / 2) && !(Unsafe.ReadUnaligned<UIntPtr>(Unsafe.As<char, byte>(Unsafe.Add<char>(ref first, intPtr2))) != Unsafe.ReadUnaligned<UIntPtr>(Unsafe.As<char, byte>(Unsafe.Add<char>(ref second, intPtr2)))))
					{
						intPtr2 += sizeof(UIntPtr) / 2;
					}
				}
				if (sizeof(UIntPtr) > 4 && (void*)intPtr >= (void*)(intPtr2 + 2) && Unsafe.ReadUnaligned<int>(Unsafe.As<char, byte>(Unsafe.Add<char>(ref first, intPtr2))) == Unsafe.ReadUnaligned<int>(Unsafe.As<char, byte>(Unsafe.Add<char>(ref second, intPtr2))))
				{
					intPtr2 += 2;
				}
				while ((void*)intPtr2 < (void*)intPtr)
				{
					int num = Unsafe.Add<char>(ref first, intPtr2).CompareTo(*Unsafe.Add<char>(ref second, intPtr2));
					if (num != 0)
					{
						return num;
					}
					intPtr2 += 1;
				}
			}
			return result;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000798C File Offset: 0x00005B8C
		public unsafe static int IndexOf(ref char searchSpace, char value, int length)
		{
			fixed (char* ptr = &searchSpace)
			{
				char* ptr2 = ptr;
				char* ptr3 = ptr2;
				char* ptr4 = ptr3 + length;
				if (Vector.IsHardwareAccelerated && length >= Vector<ushort>.Count * 2)
				{
					int num = (ptr3 & Unsafe.SizeOf<Vector<ushort>>() - 1) / 2;
					length = (Vector<ushort>.Count - num & Vector<ushort>.Count - 1);
				}
				Vector<ushort> vector;
				for (;;)
				{
					if (length < 4)
					{
						while (length > 0)
						{
							length--;
							if (*ptr3 == value)
							{
								goto IL_127;
							}
							ptr3++;
						}
						if (!Vector.IsHardwareAccelerated || ptr3 >= ptr4)
						{
							return -1;
						}
						length = (int)((long)(ptr4 - ptr3) & (long)(~(long)(Vector<ushort>.Count - 1)));
						Vector<ushort> left = new Vector<ushort>((ushort)value);
						while (length > 0)
						{
							vector = Vector.Equals<ushort>(left, Unsafe.Read<Vector<ushort>>((void*)ptr3));
							if (!Vector<ushort>.Zero.Equals(vector))
							{
								goto IL_F3;
							}
							ptr3 += Vector<ushort>.Count;
							length -= Vector<ushort>.Count;
						}
						if (ptr3 >= ptr4)
						{
							return -1;
						}
						length = (int)((long)(ptr4 - ptr3));
					}
					else
					{
						length -= 4;
						if (*ptr3 == value)
						{
							goto IL_127;
						}
						if (ptr3[1] == value)
						{
							goto IL_123;
						}
						if (ptr3[2] == value)
						{
							goto IL_11F;
						}
						if (ptr3[3] == value)
						{
							goto IL_11B;
						}
						ptr3 += 4;
					}
				}
				IL_F3:
				return (int)((long)(ptr3 - ptr2)) + SpanHelpers.LocateFirstFoundChar(vector);
				IL_11B:
				ptr3++;
				IL_11F:
				ptr3++;
				IL_123:
				ptr3++;
				IL_127:
				return (int)((long)(ptr3 - ptr2));
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00007AC8 File Offset: 0x00005CC8
		public unsafe static int LastIndexOf(ref char searchSpace, char value, int length)
		{
			fixed (char* ptr = &searchSpace)
			{
				char* ptr2 = ptr;
				char* ptr3 = ptr2 + length;
				char* ptr4 = ptr2;
				if (Vector.IsHardwareAccelerated && length >= Vector<ushort>.Count * 2)
				{
					length = (ptr3 & Unsafe.SizeOf<Vector<ushort>>() - 1) / 2;
				}
				char* ptr5;
				Vector<ushort> vector;
				for (;;)
				{
					if (length < 4)
					{
						while (length > 0)
						{
							length--;
							ptr3--;
							if (*ptr3 == value)
							{
								goto IL_11D;
							}
						}
						if (!Vector.IsHardwareAccelerated || ptr3 == ptr4)
						{
							return -1;
						}
						length = (int)((long)(ptr3 - ptr4) & (long)(~(long)(Vector<ushort>.Count - 1)));
						Vector<ushort> left = new Vector<ushort>((ushort)value);
						while (length > 0)
						{
							ptr5 = ptr3 - Vector<ushort>.Count;
							vector = Vector.Equals<ushort>(left, Unsafe.Read<Vector<ushort>>((void*)ptr5));
							if (!Vector<ushort>.Zero.Equals(vector))
							{
								goto IL_F4;
							}
							ptr3 -= Vector<ushort>.Count;
							length -= Vector<ushort>.Count;
						}
						if (ptr3 == ptr4)
						{
							return -1;
						}
						length = (int)((long)(ptr3 - ptr4));
					}
					else
					{
						length -= 4;
						ptr3 -= 4;
						if (ptr3[3] == value)
						{
							goto IL_139;
						}
						if (ptr3[2] == value)
						{
							goto IL_12F;
						}
						if (ptr3[1] == value)
						{
							goto IL_125;
						}
						if (*ptr3 == value)
						{
							goto IL_11D;
						}
					}
				}
				IL_F4:
				return (int)((long)(ptr5 - ptr4)) + SpanHelpers.LocateLastFoundChar(vector);
				IL_11D:
				return (int)((long)(ptr3 - ptr4));
				IL_125:
				return (int)((long)(ptr3 - ptr4)) + 1;
				IL_12F:
				return (int)((long)(ptr3 - ptr4)) + 2;
				IL_139:
				return (int)((long)(ptr3 - ptr4)) + 3;
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00007C18 File Offset: 0x00005E18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateFirstFoundChar(Vector<ushort> match)
		{
			Vector<ulong> vector = Vector.AsVectorUInt64<ushort>(match);
			ulong num = 0UL;
			int i;
			for (i = 0; i < Vector<ulong>.Count; i++)
			{
				num = vector[i];
				if (num != 0UL)
				{
					break;
				}
			}
			return i * 4 + SpanHelpers.LocateFirstFoundChar(num);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00007C58 File Offset: 0x00005E58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateFirstFoundChar(ulong match)
		{
			ulong num = match ^ match - 1UL;
			return (int)(num * 4295098372UL >> 49);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00007C7C File Offset: 0x00005E7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateLastFoundChar(Vector<ushort> match)
		{
			Vector<ulong> vector = Vector.AsVectorUInt64<ushort>(match);
			ulong num = 0UL;
			int i;
			for (i = Vector<ulong>.Count - 1; i >= 0; i--)
			{
				num = vector[i];
				if (num != 0UL)
				{
					break;
				}
			}
			return i * 4 + SpanHelpers.LocateLastFoundChar(num);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00007CBC File Offset: 0x00005EBC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateLastFoundChar(ulong match)
		{
			int num = 3;
			while (match > 0UL)
			{
				match <<= 16;
				num--;
			}
			return num;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static int IndexOf<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
		{
			if (valueLength == 0)
			{
				return 0;
			}
			T value2 = value;
			ref T second = ref Unsafe.Add<T>(ref value, 1);
			int num = valueLength - 1;
			int num2 = 0;
			for (;;)
			{
				int num3 = searchSpaceLength - num2 - num;
				if (num3 <= 0)
				{
					return -1;
				}
				int num4 = SpanHelpers.IndexOf<T>(Unsafe.Add<T>(ref searchSpace, num2), value2, num3);
				if (num4 == -1)
				{
					return -1;
				}
				num2 += num4;
				if (SpanHelpers.SequenceEqual<T>(Unsafe.Add<T>(ref searchSpace, num2 + 1), ref second, num))
				{
					break;
				}
				num2++;
			}
			return num2;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00007D4C File Offset: 0x00005F4C
		public unsafe static int IndexOf<T>(ref T searchSpace, T value, int length) where T : IEquatable<T>
		{
			IntPtr intPtr = (IntPtr)0;
			while (length >= 8)
			{
				length -= 8;
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr)))
				{
					IL_202:
					return (void*)intPtr;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 1)))
				{
					IL_20A:
					return (void*)(intPtr + 1);
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 2)))
				{
					IL_218:
					return (void*)(intPtr + 2);
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 3)))
				{
					IL_226:
					return (void*)(intPtr + 3);
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 4)))
				{
					return (void*)(intPtr + 4);
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 5)))
				{
					return (void*)(intPtr + 5);
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 6)))
				{
					return (void*)(intPtr + 6);
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 7)))
				{
					return (void*)(intPtr + 7);
				}
				intPtr += 8;
			}
			if (length >= 4)
			{
				length -= 4;
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr)))
				{
					goto IL_202;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 1)))
				{
					goto IL_20A;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 2)))
				{
					goto IL_218;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr + 3)))
				{
					goto IL_226;
				}
				intPtr += 4;
			}
			while (length > 0)
			{
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, intPtr)))
				{
					goto IL_202;
				}
				intPtr += 1;
				length--;
			}
			return -1;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007FC4 File Offset: 0x000061C4
		public unsafe static int IndexOfAny<T>(ref T searchSpace, T value0, T value1, int length) where T : IEquatable<T>
		{
			int i = 0;
			while (length - i >= 8)
			{
				T other = *Unsafe.Add<T>(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return i;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other))
				{
					IL_2CB:
					return i + 1;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other))
				{
					IL_2CF:
					return i + 2;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 3);
				if (value0.Equals(other) || value1.Equals(other))
				{
					IL_2D3:
					return i + 3;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 4);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return i + 4;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 5);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return i + 5;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 6);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return i + 6;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 7);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return i + 7;
				}
				i += 8;
			}
			if (length - i >= 4)
			{
				T other = *Unsafe.Add<T>(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return i;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_2CB;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_2CF;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 3);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_2D3;
				}
				i += 4;
			}
			while (i < length)
			{
				T other = *Unsafe.Add<T>(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000082B8 File Offset: 0x000064B8
		public unsafe static int IndexOfAny<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : IEquatable<T>
		{
			int i = 0;
			while (length - i >= 8)
			{
				T other = *Unsafe.Add<T>(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return i;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					IL_3C2:
					return i + 1;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					IL_3C6:
					return i + 2;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 3);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					IL_3CA:
					return i + 3;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 4);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return i + 4;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 5);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return i + 5;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 6);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return i + 6;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 7);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return i + 7;
				}
				i += 8;
			}
			if (length - i >= 4)
			{
				T other = *Unsafe.Add<T>(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return i;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_3C2;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_3C6;
				}
				other = *Unsafe.Add<T>(ref searchSpace, i + 3);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_3CA;
				}
				i += 4;
			}
			while (i < length)
			{
				T other = *Unsafe.Add<T>(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000086A4 File Offset: 0x000068A4
		public unsafe static int IndexOfAny<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
		{
			if (valueLength == 0)
			{
				return 0;
			}
			int num = -1;
			for (int i = 0; i < valueLength; i++)
			{
				int num2 = SpanHelpers.IndexOf<T>(ref searchSpace, *Unsafe.Add<T>(ref value, i), searchSpaceLength);
				if (num2 < num)
				{
					num = num2;
					searchSpaceLength = num2;
					if (num == 0)
					{
						break;
					}
				}
			}
			return num;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000086E8 File Offset: 0x000068E8
		public static int LastIndexOf<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
		{
			if (valueLength == 0)
			{
				return 0;
			}
			T value2 = value;
			ref T second = ref Unsafe.Add<T>(ref value, 1);
			int num = valueLength - 1;
			int num2 = 0;
			int num4;
			for (;;)
			{
				int num3 = searchSpaceLength - num2 - num;
				if (num3 <= 0)
				{
					return -1;
				}
				num4 = SpanHelpers.LastIndexOf<T>(ref searchSpace, value2, num3);
				if (num4 == -1)
				{
					return -1;
				}
				if (SpanHelpers.SequenceEqual<T>(Unsafe.Add<T>(ref searchSpace, num4 + 1), ref second, num))
				{
					break;
				}
				num2 += num3 - num4;
			}
			return num4;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000874C File Offset: 0x0000694C
		public unsafe static int LastIndexOf<T>(ref T searchSpace, T value, int length) where T : IEquatable<T>
		{
			while (length >= 8)
			{
				length -= 8;
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 7)))
				{
					return length + 7;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 6)))
				{
					return length + 6;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 5)))
				{
					return length + 5;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 4)))
				{
					return length + 4;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 3)))
				{
					IL_1C2:
					return length + 3;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 2)))
				{
					IL_1BE:
					return length + 2;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 1)))
				{
					IL_1BA:
					return length + 1;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length)))
				{
					return length;
				}
			}
			if (length >= 4)
			{
				length -= 4;
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 3)))
				{
					goto IL_1C2;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 2)))
				{
					goto IL_1BE;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length + 1)))
				{
					goto IL_1BA;
				}
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length)))
				{
					return length;
				}
			}
			while (length > 0)
			{
				length--;
				if (value.Equals(*Unsafe.Add<T>(ref searchSpace, length)))
				{
					return length;
				}
			}
			return -1;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00008930 File Offset: 0x00006B30
		public unsafe static int LastIndexOfAny<T>(ref T searchSpace, T value0, T value1, int length) where T : IEquatable<T>
		{
			while (length >= 8)
			{
				length -= 8;
				T other = *Unsafe.Add<T>(ref searchSpace, length + 7);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return length + 7;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 6);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return length + 6;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 5);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return length + 5;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 4);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return length + 4;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 3);
				if (value0.Equals(other) || value1.Equals(other))
				{
					IL_2CD:
					return length + 3;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 2);
				if (value0.Equals(other) || value1.Equals(other))
				{
					IL_2C9:
					return length + 2;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 1);
				if (value0.Equals(other) || value1.Equals(other))
				{
					IL_2C5:
					return length + 1;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return length;
				}
			}
			if (length >= 4)
			{
				length -= 4;
				T other = *Unsafe.Add<T>(ref searchSpace, length + 3);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_2CD;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 2);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_2C9;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 1);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_2C5;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length);
				if (value0.Equals(other))
				{
					return length;
				}
				if (value1.Equals(other))
				{
					return length;
				}
			}
			while (length > 0)
			{
				length--;
				T other = *Unsafe.Add<T>(ref searchSpace, length);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return length;
				}
			}
			return -1;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008C20 File Offset: 0x00006E20
		public unsafe static int LastIndexOfAny<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : IEquatable<T>
		{
			while (length >= 8)
			{
				length -= 8;
				T other = *Unsafe.Add<T>(ref searchSpace, length + 7);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return length + 7;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 6);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return length + 6;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 5);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return length + 5;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 4);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return length + 4;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 3);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					IL_3DA:
					return length + 3;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 2);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					IL_3D5:
					return length + 2;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 1);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					IL_3D0:
					return length + 1;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return length;
				}
			}
			if (length >= 4)
			{
				length -= 4;
				T other = *Unsafe.Add<T>(ref searchSpace, length + 3);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_3DA;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 2);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_3D5;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length + 1);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_3D0;
				}
				other = *Unsafe.Add<T>(ref searchSpace, length);
				if (value0.Equals(other) || value1.Equals(other))
				{
					return length;
				}
				if (value2.Equals(other))
				{
					return length;
				}
			}
			while (length > 0)
			{
				length--;
				T other = *Unsafe.Add<T>(ref searchSpace, length);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					return length;
				}
			}
			return -1;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00009020 File Offset: 0x00007220
		public unsafe static int LastIndexOfAny<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
		{
			if (valueLength == 0)
			{
				return 0;
			}
			int num = -1;
			for (int i = 0; i < valueLength; i++)
			{
				int num2 = SpanHelpers.LastIndexOf<T>(ref searchSpace, *Unsafe.Add<T>(ref value, i), searchSpaceLength);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000905C File Offset: 0x0000725C
		public unsafe static bool SequenceEqual<T>(ref T first, ref T second, int length) where T : IEquatable<T>
		{
			if (!Unsafe.AreSame<T>(ref first, ref second))
			{
				IntPtr intPtr = (IntPtr)0;
				while (length >= 8)
				{
					length -= 8;
					if (!Unsafe.Add<T>(ref first, intPtr).Equals(*Unsafe.Add<T>(ref second, intPtr)) || !Unsafe.Add<T>(ref first, intPtr + 1).Equals(*Unsafe.Add<T>(ref second, intPtr + 1)) || !Unsafe.Add<T>(ref first, intPtr + 2).Equals(*Unsafe.Add<T>(ref second, intPtr + 2)) || !Unsafe.Add<T>(ref first, intPtr + 3).Equals(*Unsafe.Add<T>(ref second, intPtr + 3)) || !Unsafe.Add<T>(ref first, intPtr + 4).Equals(*Unsafe.Add<T>(ref second, intPtr + 4)) || !Unsafe.Add<T>(ref first, intPtr + 5).Equals(*Unsafe.Add<T>(ref second, intPtr + 5)) || !Unsafe.Add<T>(ref first, intPtr + 6).Equals(*Unsafe.Add<T>(ref second, intPtr + 6)) || !Unsafe.Add<T>(ref first, intPtr + 7).Equals(*Unsafe.Add<T>(ref second, intPtr + 7)))
					{
						return false;
					}
					intPtr += 8;
				}
				if (length >= 4)
				{
					length -= 4;
					if (!Unsafe.Add<T>(ref first, intPtr).Equals(*Unsafe.Add<T>(ref second, intPtr)) || !Unsafe.Add<T>(ref first, intPtr + 1).Equals(*Unsafe.Add<T>(ref second, intPtr + 1)) || !Unsafe.Add<T>(ref first, intPtr + 2).Equals(*Unsafe.Add<T>(ref second, intPtr + 2)) || !Unsafe.Add<T>(ref first, intPtr + 3).Equals(*Unsafe.Add<T>(ref second, intPtr + 3)))
					{
						return false;
					}
					intPtr += 4;
				}
				while (length > 0)
				{
					if (!Unsafe.Add<T>(ref first, intPtr).Equals(*Unsafe.Add<T>(ref second, intPtr)))
					{
						return false;
					}
					intPtr += 1;
					length--;
				}
			}
			return true;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000092F8 File Offset: 0x000074F8
		public unsafe static int SequenceCompareTo<T>(ref T first, int firstLength, ref T second, int secondLength) where T : IComparable<T>
		{
			int num = firstLength;
			if (num > secondLength)
			{
				num = secondLength;
			}
			for (int i = 0; i < num; i++)
			{
				int num2 = Unsafe.Add<T>(ref first, i).CompareTo(*Unsafe.Add<T>(ref second, i));
				if (num2 != 0)
				{
					return num2;
				}
			}
			return firstLength.CompareTo(secondLength);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00009348 File Offset: 0x00007548
		public unsafe static void CopyTo<T>(ref T dst, int dstLength, ref T src, int srcLength)
		{
			IntPtr value = Unsafe.ByteOffset<T>(ref src, Unsafe.Add<T>(ref src, srcLength));
			IntPtr value2 = Unsafe.ByteOffset<T>(ref dst, Unsafe.Add<T>(ref dst, dstLength));
			IntPtr value3 = Unsafe.ByteOffset<T>(ref src, ref dst);
			if (!((sizeof(IntPtr) == 4) ? ((int)value3 < (int)value || (int)value3 > -(int)value2) : ((long)value3 < (long)value || (long)value3 > -(long)value2)) && !SpanHelpers.IsReferenceOrContainsReferences<T>())
			{
				ref byte source = ref Unsafe.As<T, byte>(ref dst);
				ref byte source2 = ref Unsafe.As<T, byte>(ref src);
				ulong num = (ulong)((long)value);
				uint num3;
				for (ulong num2 = 0UL; num2 < num; num2 += (ulong)num3)
				{
					num3 = ((num - num2 > (ulong)-1) ? uint.MaxValue : ((uint)(num - num2)));
					Unsafe.CopyBlock(Unsafe.Add<byte>(ref source, (IntPtr)((long)num2)), Unsafe.Add<byte>(ref source2, (IntPtr)((long)num2)), num3);
				}
				return;
			}
			bool flag = (sizeof(IntPtr) == 4) ? ((int)value3 > -(int)value2) : ((long)value3 > -(long)value2);
			int num4 = flag ? 1 : -1;
			int num5 = flag ? 0 : (srcLength - 1);
			int i;
			for (i = 0; i < (srcLength & -8); i += 8)
			{
				*Unsafe.Add<T>(ref dst, num5) = *Unsafe.Add<T>(ref src, num5);
				*Unsafe.Add<T>(ref dst, num5 + num4) = *Unsafe.Add<T>(ref src, num5 + num4);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 2) = *Unsafe.Add<T>(ref src, num5 + num4 * 2);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 3) = *Unsafe.Add<T>(ref src, num5 + num4 * 3);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 4) = *Unsafe.Add<T>(ref src, num5 + num4 * 4);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 5) = *Unsafe.Add<T>(ref src, num5 + num4 * 5);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 6) = *Unsafe.Add<T>(ref src, num5 + num4 * 6);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 7) = *Unsafe.Add<T>(ref src, num5 + num4 * 7);
				num5 += num4 * 8;
			}
			if (i < (srcLength & -4))
			{
				*Unsafe.Add<T>(ref dst, num5) = *Unsafe.Add<T>(ref src, num5);
				*Unsafe.Add<T>(ref dst, num5 + num4) = *Unsafe.Add<T>(ref src, num5 + num4);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 2) = *Unsafe.Add<T>(ref src, num5 + num4 * 2);
				*Unsafe.Add<T>(ref dst, num5 + num4 * 3) = *Unsafe.Add<T>(ref src, num5 + num4 * 3);
				num5 += num4 * 4;
				i += 4;
			}
			while (i < srcLength)
			{
				*Unsafe.Add<T>(ref dst, num5) = *Unsafe.Add<T>(ref src, num5);
				num5 += num4;
				i++;
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00009674 File Offset: 0x00007874
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static IntPtr Add<T>(this IntPtr start, int index)
		{
			if (sizeof(IntPtr) == 4)
			{
				uint num = (uint)(index * Unsafe.SizeOf<T>());
				return (IntPtr)((void*)((byte*)((void*)start) + num));
			}
			ulong num2 = (ulong)((long)index * (long)Unsafe.SizeOf<T>());
			return (IntPtr)((void*)((byte*)((void*)start) + num2));
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000096B9 File Offset: 0x000078B9
		public static bool IsReferenceOrContainsReferences<T>()
		{
			return SpanHelpers.PerTypeValues<T>.IsReferenceOrContainsReferences;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000096C0 File Offset: 0x000078C0
		private static bool IsReferenceOrContainsReferencesCore(Type type)
		{
			if (type.GetTypeInfo().IsPrimitive)
			{
				return false;
			}
			if (!type.GetTypeInfo().IsValueType)
			{
				return true;
			}
			Type underlyingType = Nullable.GetUnderlyingType(type);
			if (underlyingType != null)
			{
				type = underlyingType;
			}
			if (type.GetTypeInfo().IsEnum)
			{
				return false;
			}
			foreach (FieldInfo fieldInfo in type.GetTypeInfo().DeclaredFields)
			{
				if (!fieldInfo.IsStatic && SpanHelpers.IsReferenceOrContainsReferencesCore(fieldInfo.FieldType))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00009768 File Offset: 0x00007968
		public unsafe static void ClearLessThanPointerSized(byte* ptr, UIntPtr byteLength)
		{
			if (sizeof(UIntPtr) == 4)
			{
				Unsafe.InitBlockUnaligned((void*)ptr, 0, (uint)byteLength);
				return;
			}
			ulong num = (ulong)byteLength;
			uint num2 = (uint)(num & (ulong)-1);
			Unsafe.InitBlockUnaligned((void*)ptr, 0, num2);
			num -= (ulong)num2;
			ptr += num2;
			while (num > 0UL)
			{
				num2 = ((num >= (ulong)-1) ? uint.MaxValue : ((uint)num));
				Unsafe.InitBlockUnaligned((void*)ptr, 0, num2);
				ptr += num2;
				num -= (ulong)num2;
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000097D4 File Offset: 0x000079D4
		public static void ClearLessThanPointerSized(ref byte b, UIntPtr byteLength)
		{
			if (sizeof(UIntPtr) == 4)
			{
				Unsafe.InitBlockUnaligned(ref b, 0, (uint)byteLength);
				return;
			}
			ulong num = (ulong)byteLength;
			uint num2 = (uint)(num & (ulong)-1);
			Unsafe.InitBlockUnaligned(ref b, 0, num2);
			num -= (ulong)num2;
			long num3 = (long)((ulong)num2);
			while (num > 0UL)
			{
				num2 = ((num >= (ulong)-1) ? uint.MaxValue : ((uint)num));
				ref byte startAddress = ref Unsafe.Add<byte>(ref b, (IntPtr)num3);
				Unsafe.InitBlockUnaligned(ref startAddress, 0, num2);
				num3 += (long)((ulong)num2);
				num -= (ulong)num2;
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00009848 File Offset: 0x00007A48
		public unsafe static void ClearPointerSizedWithoutReferences(ref byte b, UIntPtr byteLength)
		{
			IntPtr intPtr = IntPtr.Zero;
			while (intPtr.LessThanEqual(byteLength - sizeof(SpanHelpers.Reg64)))
			{
				*Unsafe.As<byte, SpanHelpers.Reg64>(Unsafe.Add<byte>(ref b, intPtr)) = default(SpanHelpers.Reg64);
				intPtr += sizeof(SpanHelpers.Reg64);
			}
			if (intPtr.LessThanEqual(byteLength - sizeof(SpanHelpers.Reg32)))
			{
				*Unsafe.As<byte, SpanHelpers.Reg32>(Unsafe.Add<byte>(ref b, intPtr)) = default(SpanHelpers.Reg32);
				intPtr += sizeof(SpanHelpers.Reg32);
			}
			if (intPtr.LessThanEqual(byteLength - sizeof(SpanHelpers.Reg16)))
			{
				*Unsafe.As<byte, SpanHelpers.Reg16>(Unsafe.Add<byte>(ref b, intPtr)) = default(SpanHelpers.Reg16);
				intPtr += sizeof(SpanHelpers.Reg16);
			}
			if (intPtr.LessThanEqual(byteLength - 8))
			{
				*Unsafe.As<byte, long>(Unsafe.Add<byte>(ref b, intPtr)) = 0L;
				intPtr += 8;
			}
			if (sizeof(IntPtr) == 4 && intPtr.LessThanEqual(byteLength - 4))
			{
				*Unsafe.As<byte, int>(Unsafe.Add<byte>(ref b, intPtr)) = 0;
				intPtr += 4;
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000994C File Offset: 0x00007B4C
		public unsafe static void ClearPointerSizedWithReferences(ref IntPtr ip, UIntPtr pointerSizeLength)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			while ((intPtr2 = intPtr + 8).LessThanEqual(pointerSizeLength))
			{
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 0) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 1) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 2) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 3) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 4) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 5) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 6) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 7) = 0;
				intPtr = intPtr2;
			}
			if ((intPtr2 = intPtr + 4).LessThanEqual(pointerSizeLength))
			{
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 0) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 1) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 2) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 3) = 0;
				intPtr = intPtr2;
			}
			if ((intPtr2 = intPtr + 2).LessThanEqual(pointerSizeLength))
			{
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 0) = 0;
				*Unsafe.Add<IntPtr>(ref ip, intPtr + 1) = 0;
				intPtr = intPtr2;
			}
			if ((intPtr + 1).LessThanEqual(pointerSizeLength))
			{
				*Unsafe.Add<IntPtr>(ref ip, intPtr) = 0;
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00009ACC File Offset: 0x00007CCC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool LessThanEqual(this IntPtr index, UIntPtr length)
		{
			if (sizeof(UIntPtr) != 4)
			{
				return (long)index <= (long)((ulong)length);
			}
			return (int)index <= (int)((uint)length);
		}

		// Token: 0x0400005F RID: 95
		private const ulong XorPowerOfTwoToHighByte = 283686952306184UL;

		// Token: 0x04000060 RID: 96
		private const ulong XorPowerOfTwoToHighChar = 4295098372UL;

		// Token: 0x02000035 RID: 53
		internal struct ComparerComparable<T, TComparer> : IComparable<T> where TComparer : IComparer<T>
		{
			// Token: 0x060002AA RID: 682 RVA: 0x0001286D File Offset: 0x00010A6D
			public ComparerComparable(T value, TComparer comparer)
			{
				this._value = value;
				this._comparer = comparer;
			}

			// Token: 0x060002AB RID: 683 RVA: 0x00012880 File Offset: 0x00010A80
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public int CompareTo(T other)
			{
				TComparer comparer = this._comparer;
				return comparer.Compare(this._value, other);
			}

			// Token: 0x040000DA RID: 218
			private readonly T _value;

			// Token: 0x040000DB RID: 219
			private readonly TComparer _comparer;
		}

		// Token: 0x02000036 RID: 54
		private struct Reg64
		{
		}

		// Token: 0x02000037 RID: 55
		private struct Reg32
		{
		}

		// Token: 0x02000038 RID: 56
		private struct Reg16
		{
		}

		// Token: 0x02000039 RID: 57
		public static class PerTypeValues<T>
		{
			// Token: 0x060002AC RID: 684 RVA: 0x000128A8 File Offset: 0x00010AA8
			private static IntPtr MeasureArrayAdjustment()
			{
				T[] array = new T[1];
				return Unsafe.ByteOffset<T>(ref Unsafe.As<Pinnable<T>>(array).Data, ref array[0]);
			}

			// Token: 0x040000DC RID: 220
			public static readonly bool IsReferenceOrContainsReferences = SpanHelpers.IsReferenceOrContainsReferencesCore(typeof(T));

			// Token: 0x040000DD RID: 221
			public static readonly T[] EmptyArray = new T[0];

			// Token: 0x040000DE RID: 222
			public static readonly IntPtr ArrayAdjustment = SpanHelpers.PerTypeValues<T>.MeasureArrayAdjustment();
		}
	}
}
