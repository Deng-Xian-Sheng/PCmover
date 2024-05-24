using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace System.Resources
{
	// Token: 0x0200039B RID: 923
	[ComVisible(true)]
	public sealed class ResourceWriter : IResourceWriter, IDisposable
	{
		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06002D79 RID: 11641 RVA: 0x000AD816 File Offset: 0x000ABA16
		// (set) Token: 0x06002D7A RID: 11642 RVA: 0x000AD81E File Offset: 0x000ABA1E
		public Func<Type, string> TypeNameConverter
		{
			get
			{
				return this.typeConverter;
			}
			set
			{
				this.typeConverter = value;
			}
		}

		// Token: 0x06002D7B RID: 11643 RVA: 0x000AD828 File Offset: 0x000ABA28
		public ResourceWriter(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			this._output = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
			this._resourceList = new Dictionary<string, object>(1000, FastResourceComparer.Default);
			this._caseInsensitiveDups = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		}

		// Token: 0x06002D7C RID: 11644 RVA: 0x000AD880 File Offset: 0x000ABA80
		public ResourceWriter(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanWrite)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_StreamNotWritable"));
			}
			this._output = stream;
			this._resourceList = new Dictionary<string, object>(1000, FastResourceComparer.Default);
			this._caseInsensitiveDups = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		}

		// Token: 0x06002D7D RID: 11645 RVA: 0x000AD8E8 File Offset: 0x000ABAE8
		public void AddResource(string name, string value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (this._resourceList == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceWriterSaved"));
			}
			this._caseInsensitiveDups.Add(name, null);
			this._resourceList.Add(name, value);
		}

		// Token: 0x06002D7E RID: 11646 RVA: 0x000AD938 File Offset: 0x000ABB38
		public void AddResource(string name, object value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (this._resourceList == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceWriterSaved"));
			}
			if (value != null && value is Stream)
			{
				this.AddResourceInternal(name, (Stream)value, false);
				return;
			}
			this._caseInsensitiveDups.Add(name, null);
			this._resourceList.Add(name, value);
		}

		// Token: 0x06002D7F RID: 11647 RVA: 0x000AD99F File Offset: 0x000ABB9F
		public void AddResource(string name, Stream value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (this._resourceList == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceWriterSaved"));
			}
			this.AddResourceInternal(name, value, false);
		}

		// Token: 0x06002D80 RID: 11648 RVA: 0x000AD9D0 File Offset: 0x000ABBD0
		public void AddResource(string name, Stream value, bool closeAfterWrite)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (this._resourceList == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceWriterSaved"));
			}
			this.AddResourceInternal(name, value, closeAfterWrite);
		}

		// Token: 0x06002D81 RID: 11649 RVA: 0x000ADA04 File Offset: 0x000ABC04
		private void AddResourceInternal(string name, Stream value, bool closeAfterWrite)
		{
			if (value == null)
			{
				this._caseInsensitiveDups.Add(name, null);
				this._resourceList.Add(name, value);
				return;
			}
			if (!value.CanSeek)
			{
				throw new ArgumentException(Environment.GetResourceString("NotSupported_UnseekableStream"));
			}
			this._caseInsensitiveDups.Add(name, null);
			this._resourceList.Add(name, new ResourceWriter.StreamWrapper(value, closeAfterWrite));
		}

		// Token: 0x06002D82 RID: 11650 RVA: 0x000ADA68 File Offset: 0x000ABC68
		public void AddResource(string name, byte[] value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (this._resourceList == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceWriterSaved"));
			}
			this._caseInsensitiveDups.Add(name, null);
			this._resourceList.Add(name, value);
		}

		// Token: 0x06002D83 RID: 11651 RVA: 0x000ADAB8 File Offset: 0x000ABCB8
		public void AddResourceData(string name, string typeName, byte[] serializedData)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			if (serializedData == null)
			{
				throw new ArgumentNullException("serializedData");
			}
			if (this._resourceList == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceWriterSaved"));
			}
			this._caseInsensitiveDups.Add(name, null);
			if (this._preserializedData == null)
			{
				this._preserializedData = new Dictionary<string, ResourceWriter.PrecannedResource>(FastResourceComparer.Default);
			}
			this._preserializedData.Add(name, new ResourceWriter.PrecannedResource(typeName, serializedData));
		}

		// Token: 0x06002D84 RID: 11652 RVA: 0x000ADB3F File Offset: 0x000ABD3F
		public void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x06002D85 RID: 11653 RVA: 0x000ADB48 File Offset: 0x000ABD48
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this._resourceList != null)
				{
					this.Generate();
				}
				if (this._output != null)
				{
					this._output.Close();
				}
			}
			this._output = null;
			this._caseInsensitiveDups = null;
		}

		// Token: 0x06002D86 RID: 11654 RVA: 0x000ADB7C File Offset: 0x000ABD7C
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06002D87 RID: 11655 RVA: 0x000ADB88 File Offset: 0x000ABD88
		[SecuritySafeCritical]
		public void Generate()
		{
			if (this._resourceList == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceWriterSaved"));
			}
			BinaryWriter binaryWriter = new BinaryWriter(this._output, Encoding.UTF8);
			List<string> list = new List<string>();
			binaryWriter.Write(ResourceManager.MagicNumber);
			binaryWriter.Write(ResourceManager.HeaderVersionNumber);
			MemoryStream memoryStream = new MemoryStream(240);
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream);
			binaryWriter2.Write(MultitargetingHelpers.GetAssemblyQualifiedName(typeof(ResourceReader), this.typeConverter));
			binaryWriter2.Write(ResourceManager.ResSetTypeName);
			binaryWriter2.Flush();
			binaryWriter.Write((int)memoryStream.Length);
			binaryWriter.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
			binaryWriter.Write(2);
			int num = this._resourceList.Count;
			if (this._preserializedData != null)
			{
				num += this._preserializedData.Count;
			}
			binaryWriter.Write(num);
			int[] array = new int[num];
			int[] array2 = new int[num];
			int num2 = 0;
			MemoryStream memoryStream2 = new MemoryStream(num * 40);
			BinaryWriter binaryWriter3 = new BinaryWriter(memoryStream2, Encoding.Unicode);
			Stream stream = null;
			PermissionSet permissionSet = new PermissionSet(PermissionState.None);
			permissionSet.AddPermission(new EnvironmentPermission(PermissionState.Unrestricted));
			permissionSet.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
			try
			{
				permissionSet.Assert();
				string tempFileName = Path.GetTempFileName();
				File.SetAttributes(tempFileName, FileAttributes.Temporary | FileAttributes.NotContentIndexed);
				stream = new FileStream(tempFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read, 4096, FileOptions.DeleteOnClose | FileOptions.SequentialScan);
			}
			catch (UnauthorizedAccessException)
			{
				stream = new MemoryStream();
			}
			catch (IOException)
			{
				stream = new MemoryStream();
			}
			finally
			{
				PermissionSet.RevertAssert();
			}
			using (stream)
			{
				BinaryWriter binaryWriter4 = new BinaryWriter(stream, Encoding.UTF8);
				IFormatter objFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File | StreamingContextStates.Persistence));
				SortedList sortedList = new SortedList(this._resourceList, FastResourceComparer.Default);
				if (this._preserializedData != null)
				{
					foreach (KeyValuePair<string, ResourceWriter.PrecannedResource> keyValuePair in this._preserializedData)
					{
						sortedList.Add(keyValuePair.Key, keyValuePair.Value);
					}
				}
				IDictionaryEnumerator enumerator2 = sortedList.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					array[num2] = FastResourceComparer.HashFunction((string)enumerator2.Key);
					array2[num2++] = (int)binaryWriter3.Seek(0, SeekOrigin.Current);
					binaryWriter3.Write((string)enumerator2.Key);
					binaryWriter3.Write((int)binaryWriter4.Seek(0, SeekOrigin.Current));
					object value = enumerator2.Value;
					ResourceTypeCode resourceTypeCode = this.FindTypeCode(value, list);
					ResourceWriter.Write7BitEncodedInt(binaryWriter4, (int)resourceTypeCode);
					ResourceWriter.PrecannedResource precannedResource = value as ResourceWriter.PrecannedResource;
					if (precannedResource != null)
					{
						binaryWriter4.Write(precannedResource.Data);
					}
					else
					{
						this.WriteValue(resourceTypeCode, value, binaryWriter4, objFormatter);
					}
				}
				binaryWriter.Write(list.Count);
				for (int i = 0; i < list.Count; i++)
				{
					binaryWriter.Write(list[i]);
				}
				Array.Sort<int, int>(array, array2);
				binaryWriter.Flush();
				int num3 = (int)binaryWriter.BaseStream.Position & 7;
				if (num3 > 0)
				{
					for (int j = 0; j < 8 - num3; j++)
					{
						binaryWriter.Write("PAD"[j % 3]);
					}
				}
				foreach (int value2 in array)
				{
					binaryWriter.Write(value2);
				}
				foreach (int value3 in array2)
				{
					binaryWriter.Write(value3);
				}
				binaryWriter.Flush();
				binaryWriter3.Flush();
				binaryWriter4.Flush();
				int num4 = (int)(binaryWriter.Seek(0, SeekOrigin.Current) + memoryStream2.Length);
				num4 += 4;
				binaryWriter.Write(num4);
				binaryWriter.Write(memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length);
				binaryWriter3.Close();
				stream.Position = 0L;
				stream.CopyTo(binaryWriter.BaseStream);
				binaryWriter4.Close();
			}
			binaryWriter.Flush();
			this._resourceList = null;
		}

		// Token: 0x06002D88 RID: 11656 RVA: 0x000AE010 File Offset: 0x000AC210
		private ResourceTypeCode FindTypeCode(object value, List<string> types)
		{
			if (value == null)
			{
				return ResourceTypeCode.Null;
			}
			Type type = value.GetType();
			if (type == typeof(string))
			{
				return ResourceTypeCode.String;
			}
			if (type == typeof(int))
			{
				return ResourceTypeCode.Int32;
			}
			if (type == typeof(bool))
			{
				return ResourceTypeCode.Boolean;
			}
			if (type == typeof(char))
			{
				return ResourceTypeCode.Char;
			}
			if (type == typeof(byte))
			{
				return ResourceTypeCode.Byte;
			}
			if (type == typeof(sbyte))
			{
				return ResourceTypeCode.SByte;
			}
			if (type == typeof(short))
			{
				return ResourceTypeCode.Int16;
			}
			if (type == typeof(long))
			{
				return ResourceTypeCode.Int64;
			}
			if (type == typeof(ushort))
			{
				return ResourceTypeCode.UInt16;
			}
			if (type == typeof(uint))
			{
				return ResourceTypeCode.UInt32;
			}
			if (type == typeof(ulong))
			{
				return ResourceTypeCode.UInt64;
			}
			if (type == typeof(float))
			{
				return ResourceTypeCode.Single;
			}
			if (type == typeof(double))
			{
				return ResourceTypeCode.Double;
			}
			if (type == typeof(decimal))
			{
				return ResourceTypeCode.Decimal;
			}
			if (type == typeof(DateTime))
			{
				return ResourceTypeCode.DateTime;
			}
			if (type == typeof(TimeSpan))
			{
				return ResourceTypeCode.TimeSpan;
			}
			if (type == typeof(byte[]))
			{
				return ResourceTypeCode.ByteArray;
			}
			if (type == typeof(ResourceWriter.StreamWrapper))
			{
				return ResourceTypeCode.Stream;
			}
			string text;
			if (type == typeof(ResourceWriter.PrecannedResource))
			{
				text = ((ResourceWriter.PrecannedResource)value).TypeName;
				if (text.StartsWith("ResourceTypeCode.", StringComparison.Ordinal))
				{
					text = text.Substring(17);
					return (ResourceTypeCode)Enum.Parse(typeof(ResourceTypeCode), text);
				}
			}
			else
			{
				text = MultitargetingHelpers.GetAssemblyQualifiedName(type, this.typeConverter);
			}
			int num = types.IndexOf(text);
			if (num == -1)
			{
				num = types.Count;
				types.Add(text);
			}
			return num + ResourceTypeCode.StartOfUserTypes;
		}

		// Token: 0x06002D89 RID: 11657 RVA: 0x000AE214 File Offset: 0x000AC414
		private void WriteValue(ResourceTypeCode typeCode, object value, BinaryWriter writer, IFormatter objFormatter)
		{
			switch (typeCode)
			{
			case ResourceTypeCode.Null:
				return;
			case ResourceTypeCode.String:
				writer.Write((string)value);
				return;
			case ResourceTypeCode.Boolean:
				writer.Write((bool)value);
				return;
			case ResourceTypeCode.Char:
				writer.Write((ushort)((char)value));
				return;
			case ResourceTypeCode.Byte:
				writer.Write((byte)value);
				return;
			case ResourceTypeCode.SByte:
				writer.Write((sbyte)value);
				return;
			case ResourceTypeCode.Int16:
				writer.Write((short)value);
				return;
			case ResourceTypeCode.UInt16:
				writer.Write((ushort)value);
				return;
			case ResourceTypeCode.Int32:
				writer.Write((int)value);
				return;
			case ResourceTypeCode.UInt32:
				writer.Write((uint)value);
				return;
			case ResourceTypeCode.Int64:
				writer.Write((long)value);
				return;
			case ResourceTypeCode.UInt64:
				writer.Write((ulong)value);
				return;
			case ResourceTypeCode.Single:
				writer.Write((float)value);
				return;
			case ResourceTypeCode.Double:
				writer.Write((double)value);
				return;
			case ResourceTypeCode.Decimal:
				writer.Write((decimal)value);
				return;
			case ResourceTypeCode.DateTime:
			{
				long value2 = ((DateTime)value).ToBinary();
				writer.Write(value2);
				return;
			}
			case ResourceTypeCode.TimeSpan:
				writer.Write(((TimeSpan)value).Ticks);
				return;
			case ResourceTypeCode.ByteArray:
			{
				byte[] array = (byte[])value;
				writer.Write(array.Length);
				writer.Write(array, 0, array.Length);
				return;
			}
			case ResourceTypeCode.Stream:
			{
				ResourceWriter.StreamWrapper streamWrapper = (ResourceWriter.StreamWrapper)value;
				if (streamWrapper.m_stream.GetType() == typeof(MemoryStream))
				{
					MemoryStream memoryStream = (MemoryStream)streamWrapper.m_stream;
					if (memoryStream.Length > 2147483647L)
					{
						throw new ArgumentException(Environment.GetResourceString("ArgumentOutOfRange_StreamLength"));
					}
					int index;
					int num;
					memoryStream.InternalGetOriginAndLength(out index, out num);
					byte[] buffer = memoryStream.InternalGetBuffer();
					writer.Write(num);
					writer.Write(buffer, index, num);
					return;
				}
				else
				{
					Stream stream = streamWrapper.m_stream;
					if (stream.Length > 2147483647L)
					{
						throw new ArgumentException(Environment.GetResourceString("ArgumentOutOfRange_StreamLength"));
					}
					stream.Position = 0L;
					writer.Write((int)stream.Length);
					byte[] array2 = new byte[4096];
					int count;
					while ((count = stream.Read(array2, 0, array2.Length)) != 0)
					{
						writer.Write(array2, 0, count);
					}
					if (streamWrapper.m_closeAfterWrite)
					{
						stream.Close();
						return;
					}
					return;
				}
				break;
			}
			}
			objFormatter.Serialize(writer.BaseStream, value);
		}

		// Token: 0x06002D8A RID: 11658 RVA: 0x000AE4BC File Offset: 0x000AC6BC
		private static void Write7BitEncodedInt(BinaryWriter store, int value)
		{
			uint num;
			for (num = (uint)value; num >= 128U; num >>= 7)
			{
				store.Write((byte)(num | 128U));
			}
			store.Write((byte)num);
		}

		// Token: 0x0400127D RID: 4733
		private Func<Type, string> typeConverter;

		// Token: 0x0400127E RID: 4734
		private const int _ExpectedNumberOfResources = 1000;

		// Token: 0x0400127F RID: 4735
		private const int AverageNameSize = 40;

		// Token: 0x04001280 RID: 4736
		private const int AverageValueSize = 40;

		// Token: 0x04001281 RID: 4737
		private Dictionary<string, object> _resourceList;

		// Token: 0x04001282 RID: 4738
		private Stream _output;

		// Token: 0x04001283 RID: 4739
		private Dictionary<string, object> _caseInsensitiveDups;

		// Token: 0x04001284 RID: 4740
		private Dictionary<string, ResourceWriter.PrecannedResource> _preserializedData;

		// Token: 0x04001285 RID: 4741
		private const int _DefaultBufferSize = 4096;

		// Token: 0x02000B67 RID: 2919
		private class PrecannedResource
		{
			// Token: 0x06006C22 RID: 27682 RVA: 0x00176291 File Offset: 0x00174491
			internal PrecannedResource(string typeName, byte[] data)
			{
				this.TypeName = typeName;
				this.Data = data;
			}

			// Token: 0x0400344C RID: 13388
			internal string TypeName;

			// Token: 0x0400344D RID: 13389
			internal byte[] Data;
		}

		// Token: 0x02000B68 RID: 2920
		private class StreamWrapper
		{
			// Token: 0x06006C23 RID: 27683 RVA: 0x001762A7 File Offset: 0x001744A7
			internal StreamWrapper(Stream s, bool closeAfterWrite)
			{
				this.m_stream = s;
				this.m_closeAfterWrite = closeAfterWrite;
			}

			// Token: 0x0400344E RID: 13390
			internal Stream m_stream;

			// Token: 0x0400344F RID: 13391
			internal bool m_closeAfterWrite;
		}
	}
}
