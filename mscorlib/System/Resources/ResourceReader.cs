using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;

namespace System.Resources
{
	// Token: 0x02000398 RID: 920
	[ComVisible(true)]
	public sealed class ResourceReader : IResourceReader, IEnumerable, IDisposable
	{
		// Token: 0x06002D43 RID: 11587 RVA: 0x000ABAAC File Offset: 0x000A9CAC
		[SecuritySafeCritical]
		public ResourceReader(string fileName)
		{
			this._resCache = new Dictionary<string, ResourceLocator>(FastResourceComparer.Default);
			this._store = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.RandomAccess, Path.GetFileName(fileName), false), Encoding.UTF8);
			try
			{
				this.ReadResources();
			}
			catch
			{
				this._store.Close();
				throw;
			}
		}

		// Token: 0x06002D44 RID: 11588 RVA: 0x000ABB20 File Offset: 0x000A9D20
		[SecurityCritical]
		public ResourceReader(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_StreamNotReadable"));
			}
			this._resCache = new Dictionary<string, ResourceLocator>(FastResourceComparer.Default);
			this._store = new BinaryReader(stream, Encoding.UTF8);
			this._ums = (stream as UnmanagedMemoryStream);
			this.ReadResources();
		}

		// Token: 0x06002D45 RID: 11589 RVA: 0x000ABB8C File Offset: 0x000A9D8C
		[SecurityCritical]
		internal ResourceReader(Stream stream, Dictionary<string, ResourceLocator> resCache)
		{
			this._resCache = resCache;
			this._store = new BinaryReader(stream, Encoding.UTF8);
			this._ums = (stream as UnmanagedMemoryStream);
			this.ReadResources();
		}

		// Token: 0x06002D46 RID: 11590 RVA: 0x000ABBBE File Offset: 0x000A9DBE
		public void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x06002D47 RID: 11591 RVA: 0x000ABBC7 File Offset: 0x000A9DC7
		public void Dispose()
		{
			this.Close();
		}

		// Token: 0x06002D48 RID: 11592 RVA: 0x000ABBD0 File Offset: 0x000A9DD0
		[SecuritySafeCritical]
		private void Dispose(bool disposing)
		{
			if (this._store != null)
			{
				this._resCache = null;
				if (disposing)
				{
					BinaryReader store = this._store;
					this._store = null;
					if (store != null)
					{
						store.Close();
					}
				}
				this._store = null;
				this._namePositions = null;
				this._nameHashes = null;
				this._ums = null;
				this._namePositionsPtr = null;
				this._nameHashesPtr = null;
			}
		}

		// Token: 0x06002D49 RID: 11593 RVA: 0x000ABC34 File Offset: 0x000A9E34
		[SecurityCritical]
		internal unsafe static int ReadUnalignedI4(int* p)
		{
			return (int)(*(byte*)p) | (int)((byte*)p)[1] << 8 | (int)((byte*)p)[2] << 16 | (int)((byte*)p)[3] << 24;
		}

		// Token: 0x06002D4A RID: 11594 RVA: 0x000ABC5C File Offset: 0x000A9E5C
		private void SkipInt32()
		{
			this._store.BaseStream.Seek(4L, SeekOrigin.Current);
		}

		// Token: 0x06002D4B RID: 11595 RVA: 0x000ABC74 File Offset: 0x000A9E74
		private void SkipString()
		{
			int num = this._store.Read7BitEncodedInt();
			if (num < 0)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_NegativeStringLength"));
			}
			this._store.BaseStream.Seek((long)num, SeekOrigin.Current);
		}

		// Token: 0x06002D4C RID: 11596 RVA: 0x000ABCB5 File Offset: 0x000A9EB5
		[SecuritySafeCritical]
		private int GetNameHash(int index)
		{
			if (this._ums == null)
			{
				return this._nameHashes[index];
			}
			return ResourceReader.ReadUnalignedI4(this._nameHashesPtr + index);
		}

		// Token: 0x06002D4D RID: 11597 RVA: 0x000ABCDC File Offset: 0x000A9EDC
		[SecuritySafeCritical]
		private int GetNamePosition(int index)
		{
			int num;
			if (this._ums == null)
			{
				num = this._namePositions[index];
			}
			else
			{
				num = ResourceReader.ReadUnalignedI4(this._namePositionsPtr + index);
			}
			if (num < 0 || (long)num > this._dataSectionOffset - this._nameSectionOffset)
			{
				throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourcesNameInvalidOffset", new object[]
				{
					num
				}));
			}
			return num;
		}

		// Token: 0x06002D4E RID: 11598 RVA: 0x000ABD43 File Offset: 0x000A9F43
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06002D4F RID: 11599 RVA: 0x000ABD4B File Offset: 0x000A9F4B
		public IDictionaryEnumerator GetEnumerator()
		{
			if (this._resCache == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("ResourceReaderIsClosed"));
			}
			return new ResourceReader.ResourceEnumerator(this);
		}

		// Token: 0x06002D50 RID: 11600 RVA: 0x000ABD6B File Offset: 0x000A9F6B
		internal ResourceReader.ResourceEnumerator GetEnumeratorInternal()
		{
			return new ResourceReader.ResourceEnumerator(this);
		}

		// Token: 0x06002D51 RID: 11601 RVA: 0x000ABD74 File Offset: 0x000A9F74
		internal int FindPosForResource(string name)
		{
			int num = FastResourceComparer.HashFunction(name);
			int i = 0;
			int num2 = this._numResources - 1;
			int num3 = -1;
			bool flag = false;
			while (i <= num2)
			{
				num3 = i + num2 >> 1;
				int nameHash = this.GetNameHash(num3);
				int num4;
				if (nameHash == num)
				{
					num4 = 0;
				}
				else if (nameHash < num)
				{
					num4 = -1;
				}
				else
				{
					num4 = 1;
				}
				if (num4 == 0)
				{
					flag = true;
					break;
				}
				if (num4 < 0)
				{
					i = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
			}
			if (!flag)
			{
				return -1;
			}
			if (i != num3)
			{
				i = num3;
				while (i > 0 && this.GetNameHash(i - 1) == num)
				{
					i--;
				}
			}
			if (num2 != num3)
			{
				num2 = num3;
				while (num2 < this._numResources - 1 && this.GetNameHash(num2 + 1) == num)
				{
					num2++;
				}
			}
			lock (this)
			{
				int j = i;
				while (j <= num2)
				{
					this._store.BaseStream.Seek(this._nameSectionOffset + (long)this.GetNamePosition(j), SeekOrigin.Begin);
					if (this.CompareStringEqualsName(name))
					{
						int num5 = this._store.ReadInt32();
						if (num5 < 0 || (long)num5 >= this._store.BaseStream.Length - this._dataSectionOffset)
						{
							throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourcesDataInvalidOffset", new object[]
							{
								num5
							}));
						}
						return num5;
					}
					else
					{
						j++;
					}
				}
			}
			return -1;
		}

		// Token: 0x06002D52 RID: 11602 RVA: 0x000ABEE8 File Offset: 0x000AA0E8
		[SecuritySafeCritical]
		private unsafe bool CompareStringEqualsName(string name)
		{
			int num = this._store.Read7BitEncodedInt();
			if (num < 0)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_NegativeStringLength"));
			}
			if (this._ums == null)
			{
				byte[] array = new byte[num];
				int num2;
				for (int i = num; i > 0; i -= num2)
				{
					num2 = this._store.Read(array, num - i, i);
					if (num2 == 0)
					{
						throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourceNameCorrupted"));
					}
				}
				return FastResourceComparer.CompareOrdinal(array, num / 2, name) == 0;
			}
			byte* positionPointer = this._ums.PositionPointer;
			this._ums.Seek((long)num, SeekOrigin.Current);
			if (this._ums.Position > this._ums.Length)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesNameTooLong"));
			}
			return FastResourceComparer.CompareOrdinal(positionPointer, num, name) == 0;
		}

		// Token: 0x06002D53 RID: 11603 RVA: 0x000ABFB4 File Offset: 0x000AA1B4
		[SecurityCritical]
		private unsafe string AllocateStringForNameIndex(int index, out int dataOffset)
		{
			long num = (long)this.GetNamePosition(index);
			int num2;
			byte[] array;
			lock (this)
			{
				this._store.BaseStream.Seek(num + this._nameSectionOffset, SeekOrigin.Begin);
				num2 = this._store.Read7BitEncodedInt();
				if (num2 < 0)
				{
					throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_NegativeStringLength"));
				}
				if (this._ums != null)
				{
					if (this._ums.Position > this._ums.Length - (long)num2)
					{
						throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesIndexTooLong", new object[]
						{
							index
						}));
					}
					char* positionPointer = (char*)this._ums.PositionPointer;
					string result = new string(positionPointer, 0, num2 / 2);
					this._ums.Position += (long)num2;
					dataOffset = this._store.ReadInt32();
					if (dataOffset < 0 || (long)dataOffset >= this._store.BaseStream.Length - this._dataSectionOffset)
					{
						throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourcesDataInvalidOffset", new object[]
						{
							dataOffset
						}));
					}
					return result;
				}
				else
				{
					array = new byte[num2];
					int num3;
					for (int i = num2; i > 0; i -= num3)
					{
						num3 = this._store.Read(array, num2 - i, i);
						if (num3 == 0)
						{
							throw new EndOfStreamException(Environment.GetResourceString("BadImageFormat_ResourceNameCorrupted_NameIndex", new object[]
							{
								index
							}));
						}
					}
					dataOffset = this._store.ReadInt32();
					if (dataOffset < 0 || (long)dataOffset >= this._store.BaseStream.Length - this._dataSectionOffset)
					{
						throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourcesDataInvalidOffset", new object[]
						{
							dataOffset
						}));
					}
				}
			}
			return Encoding.Unicode.GetString(array, 0, num2);
		}

		// Token: 0x06002D54 RID: 11604 RVA: 0x000AC1B4 File Offset: 0x000AA3B4
		private object GetValueForNameIndex(int index)
		{
			long num = (long)this.GetNamePosition(index);
			object result;
			lock (this)
			{
				this._store.BaseStream.Seek(num + this._nameSectionOffset, SeekOrigin.Begin);
				this.SkipString();
				int num2 = this._store.ReadInt32();
				if (num2 < 0 || (long)num2 >= this._store.BaseStream.Length - this._dataSectionOffset)
				{
					throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourcesDataInvalidOffset", new object[]
					{
						num2
					}));
				}
				if (this._version == 1)
				{
					result = this.LoadObjectV1(num2);
				}
				else
				{
					ResourceTypeCode resourceTypeCode;
					result = this.LoadObjectV2(num2, out resourceTypeCode);
				}
			}
			return result;
		}

		// Token: 0x06002D55 RID: 11605 RVA: 0x000AC280 File Offset: 0x000AA480
		internal string LoadString(int pos)
		{
			this._store.BaseStream.Seek(this._dataSectionOffset + (long)pos, SeekOrigin.Begin);
			string result = null;
			int num = this._store.Read7BitEncodedInt();
			if (this._version == 1)
			{
				if (num == -1)
				{
					return null;
				}
				if (this.FindType(num) != typeof(string))
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Type", new object[]
					{
						this.FindType(num).FullName
					}));
				}
				result = this._store.ReadString();
			}
			else
			{
				ResourceTypeCode resourceTypeCode = (ResourceTypeCode)num;
				if (resourceTypeCode != ResourceTypeCode.String && resourceTypeCode != ResourceTypeCode.Null)
				{
					string text;
					if (resourceTypeCode < ResourceTypeCode.StartOfUserTypes)
					{
						text = resourceTypeCode.ToString();
					}
					else
					{
						text = this.FindType(resourceTypeCode - ResourceTypeCode.StartOfUserTypes).FullName;
					}
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Type", new object[]
					{
						text
					}));
				}
				if (resourceTypeCode == ResourceTypeCode.String)
				{
					result = this._store.ReadString();
				}
			}
			return result;
		}

		// Token: 0x06002D56 RID: 11606 RVA: 0x000AC36C File Offset: 0x000AA56C
		internal object LoadObject(int pos)
		{
			if (this._version == 1)
			{
				return this.LoadObjectV1(pos);
			}
			ResourceTypeCode resourceTypeCode;
			return this.LoadObjectV2(pos, out resourceTypeCode);
		}

		// Token: 0x06002D57 RID: 11607 RVA: 0x000AC394 File Offset: 0x000AA594
		internal object LoadObject(int pos, out ResourceTypeCode typeCode)
		{
			if (this._version == 1)
			{
				object obj = this.LoadObjectV1(pos);
				typeCode = ((obj is string) ? ResourceTypeCode.String : ResourceTypeCode.StartOfUserTypes);
				return obj;
			}
			return this.LoadObjectV2(pos, out typeCode);
		}

		// Token: 0x06002D58 RID: 11608 RVA: 0x000AC3CC File Offset: 0x000AA5CC
		internal object LoadObjectV1(int pos)
		{
			object result;
			try
			{
				result = this._LoadObjectV1(pos);
			}
			catch (EndOfStreamException inner)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_TypeMismatch"), inner);
			}
			catch (ArgumentOutOfRangeException inner2)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_TypeMismatch"), inner2);
			}
			return result;
		}

		// Token: 0x06002D59 RID: 11609 RVA: 0x000AC424 File Offset: 0x000AA624
		[SecuritySafeCritical]
		private object _LoadObjectV1(int pos)
		{
			this._store.BaseStream.Seek(this._dataSectionOffset + (long)pos, SeekOrigin.Begin);
			int num = this._store.Read7BitEncodedInt();
			if (num == -1)
			{
				return null;
			}
			RuntimeType left = this.FindType(num);
			if (left == typeof(string))
			{
				return this._store.ReadString();
			}
			if (left == typeof(int))
			{
				return this._store.ReadInt32();
			}
			if (left == typeof(byte))
			{
				return this._store.ReadByte();
			}
			if (left == typeof(sbyte))
			{
				return this._store.ReadSByte();
			}
			if (left == typeof(short))
			{
				return this._store.ReadInt16();
			}
			if (left == typeof(long))
			{
				return this._store.ReadInt64();
			}
			if (left == typeof(ushort))
			{
				return this._store.ReadUInt16();
			}
			if (left == typeof(uint))
			{
				return this._store.ReadUInt32();
			}
			if (left == typeof(ulong))
			{
				return this._store.ReadUInt64();
			}
			if (left == typeof(float))
			{
				return this._store.ReadSingle();
			}
			if (left == typeof(double))
			{
				return this._store.ReadDouble();
			}
			if (left == typeof(DateTime))
			{
				return new DateTime(this._store.ReadInt64());
			}
			if (left == typeof(TimeSpan))
			{
				return new TimeSpan(this._store.ReadInt64());
			}
			if (left == typeof(decimal))
			{
				int[] array = new int[4];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this._store.ReadInt32();
				}
				return new decimal(array);
			}
			return this.DeserializeObject(num);
		}

		// Token: 0x06002D5A RID: 11610 RVA: 0x000AC67C File Offset: 0x000AA87C
		internal object LoadObjectV2(int pos, out ResourceTypeCode typeCode)
		{
			object result;
			try
			{
				result = this._LoadObjectV2(pos, out typeCode);
			}
			catch (EndOfStreamException inner)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_TypeMismatch"), inner);
			}
			catch (ArgumentOutOfRangeException inner2)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_TypeMismatch"), inner2);
			}
			return result;
		}

		// Token: 0x06002D5B RID: 11611 RVA: 0x000AC6D8 File Offset: 0x000AA8D8
		[SecuritySafeCritical]
		private object _LoadObjectV2(int pos, out ResourceTypeCode typeCode)
		{
			this._store.BaseStream.Seek(this._dataSectionOffset + (long)pos, SeekOrigin.Begin);
			typeCode = (ResourceTypeCode)this._store.Read7BitEncodedInt();
			switch (typeCode)
			{
			case ResourceTypeCode.Null:
				return null;
			case ResourceTypeCode.String:
				return this._store.ReadString();
			case ResourceTypeCode.Boolean:
				return this._store.ReadBoolean();
			case ResourceTypeCode.Char:
				return (char)this._store.ReadUInt16();
			case ResourceTypeCode.Byte:
				return this._store.ReadByte();
			case ResourceTypeCode.SByte:
				return this._store.ReadSByte();
			case ResourceTypeCode.Int16:
				return this._store.ReadInt16();
			case ResourceTypeCode.UInt16:
				return this._store.ReadUInt16();
			case ResourceTypeCode.Int32:
				return this._store.ReadInt32();
			case ResourceTypeCode.UInt32:
				return this._store.ReadUInt32();
			case ResourceTypeCode.Int64:
				return this._store.ReadInt64();
			case ResourceTypeCode.UInt64:
				return this._store.ReadUInt64();
			case ResourceTypeCode.Single:
				return this._store.ReadSingle();
			case ResourceTypeCode.Double:
				return this._store.ReadDouble();
			case ResourceTypeCode.Decimal:
				return this._store.ReadDecimal();
			case ResourceTypeCode.DateTime:
			{
				long dateData = this._store.ReadInt64();
				return DateTime.FromBinary(dateData);
			}
			case ResourceTypeCode.TimeSpan:
			{
				long ticks = this._store.ReadInt64();
				return new TimeSpan(ticks);
			}
			case ResourceTypeCode.ByteArray:
			{
				int num = this._store.ReadInt32();
				if (num < 0)
				{
					throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourceDataLengthInvalid", new object[]
					{
						num
					}));
				}
				if (this._ums == null)
				{
					if ((long)num > this._store.BaseStream.Length)
					{
						throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourceDataLengthInvalid", new object[]
						{
							num
						}));
					}
					return this._store.ReadBytes(num);
				}
				else
				{
					if ((long)num > this._ums.Length - this._ums.Position)
					{
						throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourceDataLengthInvalid", new object[]
						{
							num
						}));
					}
					byte[] array = new byte[num];
					int num2 = this._ums.Read(array, 0, num);
					return array;
				}
				break;
			}
			case ResourceTypeCode.Stream:
			{
				int num3 = this._store.ReadInt32();
				if (num3 < 0)
				{
					throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourceDataLengthInvalid", new object[]
					{
						num3
					}));
				}
				if (this._ums == null)
				{
					byte[] array2 = this._store.ReadBytes(num3);
					return new PinnedBufferMemoryStream(array2);
				}
				if ((long)num3 > this._ums.Length - this._ums.Position)
				{
					throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourceDataLengthInvalid", new object[]
					{
						num3
					}));
				}
				return new UnmanagedMemoryStream(this._ums.PositionPointer, (long)num3, (long)num3, FileAccess.Read, true);
			}
			}
			if (typeCode < ResourceTypeCode.StartOfUserTypes)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_TypeMismatch"));
			}
			int typeIndex = typeCode - ResourceTypeCode.StartOfUserTypes;
			return this.DeserializeObject(typeIndex);
		}

		// Token: 0x06002D5C RID: 11612 RVA: 0x000ACA60 File Offset: 0x000AAC60
		[SecurityCritical]
		private object DeserializeObject(int typeIndex)
		{
			RuntimeType runtimeType = this.FindType(typeIndex);
			if (this._safeToDeserialize == null)
			{
				this.InitSafeToDeserializeArray();
			}
			object obj;
			if (this._safeToDeserialize[typeIndex])
			{
				this._objFormatter.Binder = this._typeLimitingBinder;
				this._typeLimitingBinder.ExpectingToDeserialize(runtimeType);
				obj = this._objFormatter.UnsafeDeserialize(this._store.BaseStream, null);
			}
			else
			{
				this._objFormatter.Binder = null;
				obj = this._objFormatter.Deserialize(this._store.BaseStream);
			}
			if (obj.GetType() != runtimeType)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResType&SerBlobMismatch", new object[]
				{
					runtimeType.FullName,
					obj.GetType().FullName
				}));
			}
			return obj;
		}

		// Token: 0x06002D5D RID: 11613 RVA: 0x000ACB24 File Offset: 0x000AAD24
		[SecurityCritical]
		private void ReadResources()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File | StreamingContextStates.Persistence));
			this._typeLimitingBinder = new ResourceReader.TypeLimitingDeserializationBinder();
			binaryFormatter.Binder = this._typeLimitingBinder;
			this._objFormatter = binaryFormatter;
			try
			{
				this._ReadResources();
			}
			catch (EndOfStreamException inner)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"), inner);
			}
			catch (IndexOutOfRangeException inner2)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"), inner2);
			}
		}

		// Token: 0x06002D5E RID: 11614 RVA: 0x000ACBA8 File Offset: 0x000AADA8
		[SecurityCritical]
		private unsafe void _ReadResources()
		{
			int num = this._store.ReadInt32();
			if (num != ResourceManager.MagicNumber)
			{
				throw new ArgumentException(Environment.GetResourceString("Resources_StreamNotValid"));
			}
			int num2 = this._store.ReadInt32();
			int num3 = this._store.ReadInt32();
			if (num3 < 0 || num2 < 0)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
			}
			if (num2 > 1)
			{
				this._store.BaseStream.Seek((long)num3, SeekOrigin.Current);
			}
			else
			{
				string text = this._store.ReadString();
				AssemblyName asmName = new AssemblyName(ResourceManager.MscorlibName);
				if (!ResourceManager.CompareNames(text, ResourceManager.ResReaderTypeName, asmName))
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_WrongResourceReader_Type", new object[]
					{
						text
					}));
				}
				this.SkipString();
			}
			int num4 = this._store.ReadInt32();
			if (num4 != 2 && num4 != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ResourceFileUnsupportedVersion", new object[]
				{
					2,
					num4
				}));
			}
			this._version = num4;
			this._numResources = this._store.ReadInt32();
			if (this._numResources < 0)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
			}
			int num5 = this._store.ReadInt32();
			if (num5 < 0)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
			}
			this._typeTable = new RuntimeType[num5];
			this._typeNamePositions = new int[num5];
			for (int i = 0; i < num5; i++)
			{
				this._typeNamePositions[i] = (int)this._store.BaseStream.Position;
				this.SkipString();
			}
			long position = this._store.BaseStream.Position;
			int num6 = (int)position & 7;
			if (num6 != 0)
			{
				for (int j = 0; j < 8 - num6; j++)
				{
					this._store.ReadByte();
				}
			}
			if (this._ums == null)
			{
				this._nameHashes = new int[this._numResources];
				for (int k = 0; k < this._numResources; k++)
				{
					this._nameHashes[k] = this._store.ReadInt32();
				}
			}
			else
			{
				if (((long)this._numResources & (long)((ulong)-536870912)) != 0L)
				{
					throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
				}
				int num7 = 4 * this._numResources;
				this._nameHashesPtr = (int*)this._ums.PositionPointer;
				this._ums.Seek((long)num7, SeekOrigin.Current);
				byte* positionPointer = this._ums.PositionPointer;
			}
			if (this._ums == null)
			{
				this._namePositions = new int[this._numResources];
				for (int l = 0; l < this._numResources; l++)
				{
					int num8 = this._store.ReadInt32();
					if (num8 < 0)
					{
						throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
					}
					this._namePositions[l] = num8;
				}
			}
			else
			{
				if (((long)this._numResources & (long)((ulong)-536870912)) != 0L)
				{
					throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
				}
				int num9 = 4 * this._numResources;
				this._namePositionsPtr = (int*)this._ums.PositionPointer;
				this._ums.Seek((long)num9, SeekOrigin.Current);
				byte* positionPointer2 = this._ums.PositionPointer;
			}
			this._dataSectionOffset = (long)this._store.ReadInt32();
			if (this._dataSectionOffset < 0L)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
			}
			this._nameSectionOffset = this._store.BaseStream.Position;
			if (this._dataSectionOffset < this._nameSectionOffset)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResourcesHeaderCorrupted"));
			}
		}

		// Token: 0x06002D5F RID: 11615 RVA: 0x000ACF34 File Offset: 0x000AB134
		private RuntimeType FindType(int typeIndex)
		{
			if (typeIndex < 0 || typeIndex >= this._typeTable.Length)
			{
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_InvalidType"));
			}
			if (this._typeTable[typeIndex] == null)
			{
				long position = this._store.BaseStream.Position;
				try
				{
					this._store.BaseStream.Position = (long)this._typeNamePositions[typeIndex];
					string typeName = this._store.ReadString();
					this._typeTable[typeIndex] = (RuntimeType)Type.GetType(typeName, true);
				}
				finally
				{
					this._store.BaseStream.Position = position;
				}
			}
			return this._typeTable[typeIndex];
		}

		// Token: 0x06002D60 RID: 11616 RVA: 0x000ACFE8 File Offset: 0x000AB1E8
		[SecurityCritical]
		private void InitSafeToDeserializeArray()
		{
			this._safeToDeserialize = new bool[this._typeTable.Length];
			int i = 0;
			while (i < this._typeTable.Length)
			{
				long position = this._store.BaseStream.Position;
				string text;
				try
				{
					this._store.BaseStream.Position = (long)this._typeNamePositions[i];
					text = this._store.ReadString();
				}
				finally
				{
					this._store.BaseStream.Position = position;
				}
				RuntimeType runtimeType = (RuntimeType)Type.GetType(text, false);
				if (runtimeType == null)
				{
					AssemblyName assemblyName = null;
					string typeName = text;
					goto IL_E5;
				}
				if (!(runtimeType.BaseType == typeof(Enum)))
				{
					string typeName = runtimeType.FullName;
					AssemblyName assemblyName = new AssemblyName();
					RuntimeAssembly runtimeAssembly = (RuntimeAssembly)runtimeType.Assembly;
					assemblyName.Init(runtimeAssembly.GetSimpleName(), runtimeAssembly.GetPublicKey(), null, null, runtimeAssembly.GetLocale(), AssemblyHashAlgorithm.None, AssemblyVersionCompatibility.SameMachine, null, AssemblyNameFlags.PublicKey, null);
					goto IL_E5;
				}
				this._safeToDeserialize[i] = true;
				IL_11B:
				i++;
				continue;
				IL_E5:
				foreach (string asmTypeName in ResourceReader.TypesSafeForDeserialization)
				{
					AssemblyName assemblyName;
					string typeName;
					if (ResourceManager.CompareNames(asmTypeName, typeName, assemblyName))
					{
						this._safeToDeserialize[i] = true;
					}
				}
				goto IL_11B;
			}
		}

		// Token: 0x06002D61 RID: 11617 RVA: 0x000AD134 File Offset: 0x000AB334
		public void GetResourceData(string resourceName, out string resourceType, out byte[] resourceData)
		{
			if (resourceName == null)
			{
				throw new ArgumentNullException("resourceName");
			}
			if (this._resCache == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("ResourceReaderIsClosed"));
			}
			int[] array = new int[this._numResources];
			int num = this.FindPosForResource(resourceName);
			if (num == -1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ResourceNameNotExist", new object[]
				{
					resourceName
				}));
			}
			lock (this)
			{
				for (int i = 0; i < this._numResources; i++)
				{
					this._store.BaseStream.Position = this._nameSectionOffset + (long)this.GetNamePosition(i);
					int num2 = this._store.Read7BitEncodedInt();
					if (num2 < 0)
					{
						throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourcesNameInvalidOffset", new object[]
						{
							num2
						}));
					}
					this._store.BaseStream.Position += (long)num2;
					int num3 = this._store.ReadInt32();
					if (num3 < 0 || (long)num3 >= this._store.BaseStream.Length - this._dataSectionOffset)
					{
						throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourcesDataInvalidOffset", new object[]
						{
							num3
						}));
					}
					array[i] = num3;
				}
				Array.Sort<int>(array);
				int num4 = Array.BinarySearch<int>(array, num);
				long num5 = (num4 < this._numResources - 1) ? ((long)array[num4 + 1] + this._dataSectionOffset) : this._store.BaseStream.Length;
				int num6 = (int)(num5 - ((long)num + this._dataSectionOffset));
				this._store.BaseStream.Position = this._dataSectionOffset + (long)num;
				ResourceTypeCode resourceTypeCode = (ResourceTypeCode)this._store.Read7BitEncodedInt();
				if (resourceTypeCode < ResourceTypeCode.Null || resourceTypeCode >= ResourceTypeCode.StartOfUserTypes + this._typeTable.Length)
				{
					throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_InvalidType"));
				}
				resourceType = this.TypeNameFromTypeCode(resourceTypeCode);
				num6 -= (int)(this._store.BaseStream.Position - (this._dataSectionOffset + (long)num));
				byte[] array2 = this._store.ReadBytes(num6);
				if (array2.Length != num6)
				{
					throw new FormatException(Environment.GetResourceString("BadImageFormat_ResourceNameCorrupted"));
				}
				resourceData = array2;
			}
		}

		// Token: 0x06002D62 RID: 11618 RVA: 0x000AD394 File Offset: 0x000AB594
		private string TypeNameFromTypeCode(ResourceTypeCode typeCode)
		{
			if (typeCode < ResourceTypeCode.StartOfUserTypes)
			{
				return "ResourceTypeCode." + typeCode.ToString();
			}
			int num = typeCode - ResourceTypeCode.StartOfUserTypes;
			long position = this._store.BaseStream.Position;
			string result;
			try
			{
				this._store.BaseStream.Position = (long)this._typeNamePositions[num];
				result = this._store.ReadString();
			}
			finally
			{
				this._store.BaseStream.Position = position;
			}
			return result;
		}

		// Token: 0x04001252 RID: 4690
		private const int DefaultFileStreamBufferSize = 4096;

		// Token: 0x04001253 RID: 4691
		private BinaryReader _store;

		// Token: 0x04001254 RID: 4692
		internal Dictionary<string, ResourceLocator> _resCache;

		// Token: 0x04001255 RID: 4693
		private long _nameSectionOffset;

		// Token: 0x04001256 RID: 4694
		private long _dataSectionOffset;

		// Token: 0x04001257 RID: 4695
		private int[] _nameHashes;

		// Token: 0x04001258 RID: 4696
		[SecurityCritical]
		private unsafe int* _nameHashesPtr;

		// Token: 0x04001259 RID: 4697
		private int[] _namePositions;

		// Token: 0x0400125A RID: 4698
		[SecurityCritical]
		private unsafe int* _namePositionsPtr;

		// Token: 0x0400125B RID: 4699
		private RuntimeType[] _typeTable;

		// Token: 0x0400125C RID: 4700
		private int[] _typeNamePositions;

		// Token: 0x0400125D RID: 4701
		private BinaryFormatter _objFormatter;

		// Token: 0x0400125E RID: 4702
		private int _numResources;

		// Token: 0x0400125F RID: 4703
		private UnmanagedMemoryStream _ums;

		// Token: 0x04001260 RID: 4704
		private int _version;

		// Token: 0x04001261 RID: 4705
		private bool[] _safeToDeserialize;

		// Token: 0x04001262 RID: 4706
		private ResourceReader.TypeLimitingDeserializationBinder _typeLimitingBinder;

		// Token: 0x04001263 RID: 4707
		private static readonly string[] TypesSafeForDeserialization = new string[]
		{
			"System.String[], mscorlib, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.DateTime[], mscorlib, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.Bitmap, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.Imaging.Metafile, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.Point, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.PointF, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.Size, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.SizeF, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.Font, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.Icon, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Drawing.Color, System.Drawing, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
			"System.Windows.Forms.Cursor, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.Padding, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.LinkArea, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.ImageListStreamer, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.ListViewGroup, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.ListViewItem, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.ListViewItem+ListViewSubItem, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.ListViewItem+ListViewSubItem+SubItemStyle, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.OwnerDrawPropertyBag, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089",
			"System.Windows.Forms.TreeNode, System.Windows.Forms, Culture=neutral, PublicKeyToken=b77a5c561934e089"
		};

		// Token: 0x02000B65 RID: 2917
		internal sealed class TypeLimitingDeserializationBinder : SerializationBinder
		{
			// Token: 0x17001248 RID: 4680
			// (get) Token: 0x06006C15 RID: 27669 RVA: 0x00175F10 File Offset: 0x00174110
			// (set) Token: 0x06006C16 RID: 27670 RVA: 0x00175F18 File Offset: 0x00174118
			internal ObjectReader ObjectReader
			{
				get
				{
					return this._objectReader;
				}
				set
				{
					this._objectReader = value;
				}
			}

			// Token: 0x06006C17 RID: 27671 RVA: 0x00175F21 File Offset: 0x00174121
			internal void ExpectingToDeserialize(RuntimeType type)
			{
				this._typeToDeserialize = type;
			}

			// Token: 0x06006C18 RID: 27672 RVA: 0x00175F2C File Offset: 0x0017412C
			[SecuritySafeCritical]
			public override Type BindToType(string assemblyName, string typeName)
			{
				AssemblyName asmName = new AssemblyName(assemblyName);
				bool flag = false;
				foreach (string asmTypeName in ResourceReader.TypesSafeForDeserialization)
				{
					if (ResourceManager.CompareNames(asmTypeName, typeName, asmName))
					{
						flag = true;
						break;
					}
				}
				Type type = this.ObjectReader.FastBindToType(assemblyName, typeName);
				if (type.IsEnum)
				{
					flag = true;
				}
				if (flag)
				{
					return null;
				}
				throw new BadImageFormatException(Environment.GetResourceString("BadImageFormat_ResType&SerBlobMismatch", new object[]
				{
					this._typeToDeserialize.FullName,
					typeName
				}));
			}

			// Token: 0x04003444 RID: 13380
			private RuntimeType _typeToDeserialize;

			// Token: 0x04003445 RID: 13381
			private ObjectReader _objectReader;
		}

		// Token: 0x02000B66 RID: 2918
		internal sealed class ResourceEnumerator : IDictionaryEnumerator, IEnumerator
		{
			// Token: 0x06006C1A RID: 27674 RVA: 0x00175FBB File Offset: 0x001741BB
			internal ResourceEnumerator(ResourceReader reader)
			{
				this._currentName = -1;
				this._reader = reader;
				this._dataPosition = -2;
			}

			// Token: 0x06006C1B RID: 27675 RVA: 0x00175FDC File Offset: 0x001741DC
			public bool MoveNext()
			{
				if (this._currentName == this._reader._numResources - 1 || this._currentName == -2147483648)
				{
					this._currentIsValid = false;
					this._currentName = int.MinValue;
					return false;
				}
				this._currentIsValid = true;
				this._currentName++;
				return true;
			}

			// Token: 0x17001249 RID: 4681
			// (get) Token: 0x06006C1C RID: 27676 RVA: 0x00176038 File Offset: 0x00174238
			public object Key
			{
				[SecuritySafeCritical]
				get
				{
					if (this._currentName == -2147483648)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
					}
					if (!this._currentIsValid)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					if (this._reader._resCache == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("ResourceReaderIsClosed"));
					}
					return this._reader.AllocateStringForNameIndex(this._currentName, out this._dataPosition);
				}
			}

			// Token: 0x1700124A RID: 4682
			// (get) Token: 0x06006C1D RID: 27677 RVA: 0x001760AE File Offset: 0x001742AE
			public object Current
			{
				get
				{
					return this.Entry;
				}
			}

			// Token: 0x1700124B RID: 4683
			// (get) Token: 0x06006C1E RID: 27678 RVA: 0x001760BB File Offset: 0x001742BB
			internal int DataPosition
			{
				get
				{
					return this._dataPosition;
				}
			}

			// Token: 0x1700124C RID: 4684
			// (get) Token: 0x06006C1F RID: 27679 RVA: 0x001760C4 File Offset: 0x001742C4
			public DictionaryEntry Entry
			{
				[SecuritySafeCritical]
				get
				{
					if (this._currentName == -2147483648)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
					}
					if (!this._currentIsValid)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					if (this._reader._resCache == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("ResourceReaderIsClosed"));
					}
					object obj = null;
					ResourceReader reader = this._reader;
					string key;
					lock (reader)
					{
						Dictionary<string, ResourceLocator> resCache = this._reader._resCache;
						lock (resCache)
						{
							key = this._reader.AllocateStringForNameIndex(this._currentName, out this._dataPosition);
							ResourceLocator resourceLocator;
							if (this._reader._resCache.TryGetValue(key, out resourceLocator))
							{
								obj = resourceLocator.Value;
							}
							if (obj == null)
							{
								if (this._dataPosition == -1)
								{
									obj = this._reader.GetValueForNameIndex(this._currentName);
								}
								else
								{
									obj = this._reader.LoadObject(this._dataPosition);
								}
							}
						}
					}
					return new DictionaryEntry(key, obj);
				}
			}

			// Token: 0x1700124D RID: 4685
			// (get) Token: 0x06006C20 RID: 27680 RVA: 0x001761F4 File Offset: 0x001743F4
			public object Value
			{
				get
				{
					if (this._currentName == -2147483648)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
					}
					if (!this._currentIsValid)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					if (this._reader._resCache == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("ResourceReaderIsClosed"));
					}
					return this._reader.GetValueForNameIndex(this._currentName);
				}
			}

			// Token: 0x06006C21 RID: 27681 RVA: 0x00176264 File Offset: 0x00174464
			public void Reset()
			{
				if (this._reader._resCache == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("ResourceReaderIsClosed"));
				}
				this._currentIsValid = false;
				this._currentName = -1;
			}

			// Token: 0x04003446 RID: 13382
			private const int ENUM_DONE = -2147483648;

			// Token: 0x04003447 RID: 13383
			private const int ENUM_NOT_STARTED = -1;

			// Token: 0x04003448 RID: 13384
			private ResourceReader _reader;

			// Token: 0x04003449 RID: 13385
			private bool _currentIsValid;

			// Token: 0x0400344A RID: 13386
			private int _currentName;

			// Token: 0x0400344B RID: 13387
			private int _dataPosition;
		}
	}
}
