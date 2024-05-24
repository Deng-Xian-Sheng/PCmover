using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000018 RID: 24
	public class ShellObjectCollection : IDisposable, IList<ShellObject>, ICollection<ShellObject>, IEnumerable<ShellObject>, IEnumerable
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x000050F4 File Offset: 0x000032F4
		internal ShellObjectCollection(IShellItemArray iArray, bool readOnly)
		{
			this.readOnly = readOnly;
			if (iArray != null)
			{
				try
				{
					uint num = 0U;
					iArray.GetCount(out num);
					this.content.Capacity = (int)num;
					for (uint num2 = 0U; num2 < num; num2 += 1U)
					{
						IShellItem nativeShellItem = null;
						iArray.GetItemAt(num2, out nativeShellItem);
						this.content.Add(ShellObjectFactory.Create(nativeShellItem));
					}
				}
				finally
				{
					Marshal.ReleaseComObject(iArray);
				}
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005190 File Offset: 0x00003390
		public static ShellObjectCollection FromDataObject(IDataObject dataObject)
		{
			Guid guid = new Guid("B63EA76D-1F85-456F-A19C-48159EFA858B");
			IShellItemArray iArray;
			ShellNativeMethods.SHCreateShellItemArrayFromDataObject(dataObject, ref guid, out iArray);
			return new ShellObjectCollection(iArray, true);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000051C5 File Offset: 0x000033C5
		public ShellObjectCollection()
		{
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000051DC File Offset: 0x000033DC
		~ShellObjectCollection()
		{
			this.Dispose(false);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005210 File Offset: 0x00003410
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005224 File Offset: 0x00003424
		protected virtual void Dispose(bool disposing)
		{
			if (!this.isDisposed)
			{
				if (disposing)
				{
					foreach (ShellObject shellObject in this.content)
					{
						shellObject.Dispose();
					}
					this.content.Clear();
				}
				this.isDisposed = true;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000DC RID: 220 RVA: 0x000052A8 File Offset: 0x000034A8
		public int Count
		{
			get
			{
				return this.content.Count;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005430 File Offset: 0x00003630
		public IEnumerator GetEnumerator()
		{
			foreach (ShellObject obj in this.content)
			{
				yield return obj;
			}
			yield break;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005450 File Offset: 0x00003650
		public MemoryStream BuildShellIDList()
		{
			if (this.content.Count == 0)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellObjectCollectionEmptyCollection);
			}
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				uint num = (uint)(this.content.Count + 1);
				IntPtr[] array = new IntPtr[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					if (num2 == 0)
					{
						array[num2] = ((ShellObject)KnownFolders.Desktop).PIDL;
					}
					else
					{
						array[num2] = this.content[num2 - 1].PIDL;
					}
					num2++;
				}
				uint[] array2 = new uint[num + 1U];
				num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					if (num2 == 0)
					{
						array2[0] = (uint)(4 * (array2.Length + 1));
					}
					else
					{
						array2[num2] = array2[num2 - 1] + ShellNativeMethods.ILGetSize(array[num2 - 1]);
					}
					num2++;
				}
				binaryWriter.Write(this.content.Count);
				foreach (uint value in array2)
				{
					binaryWriter.Write(value);
				}
				foreach (IntPtr intPtr in array)
				{
					byte[] array5 = new byte[ShellNativeMethods.ILGetSize(intPtr)];
					Marshal.Copy(intPtr, array5, 0, array5.Length);
					binaryWriter.Write(array5, 0, array5.Length);
				}
			}
			catch
			{
				memoryStream.Dispose();
				throw;
			}
			return memoryStream;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005648 File Offset: 0x00003848
		public int IndexOf(ShellObject item)
		{
			return this.content.IndexOf(item);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005668 File Offset: 0x00003868
		public void Insert(int index, ShellObject item)
		{
			if (this.readOnly)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellObjectCollectionInsertReadOnly);
			}
			this.content.Insert(index, item);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000056A0 File Offset: 0x000038A0
		public void RemoveAt(int index)
		{
			if (this.readOnly)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellObjectCollectionRemoveReadOnly);
			}
			this.content.RemoveAt(index);
		}

		// Token: 0x17000039 RID: 57
		public ShellObject this[int index]
		{
			get
			{
				return this.content[index];
			}
			set
			{
				if (this.readOnly)
				{
					throw new InvalidOperationException(LocalizedMessages.ShellObjectCollectionInsertReadOnly);
				}
				this.content[index] = value;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000572C File Offset: 0x0000392C
		public void Add(ShellObject item)
		{
			if (this.readOnly)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellObjectCollectionInsertReadOnly);
			}
			this.content.Add(item);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00005760 File Offset: 0x00003960
		public void Clear()
		{
			if (this.readOnly)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellObjectCollectionRemoveReadOnly);
			}
			this.content.Clear();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00005794 File Offset: 0x00003994
		public bool Contains(ShellObject item)
		{
			return this.content.Contains(item);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000057B4 File Offset: 0x000039B4
		public void CopyTo(ShellObject[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Length < arrayIndex + this.content.Count)
			{
				throw new ArgumentException(LocalizedMessages.ShellObjectCollectionArrayTooSmall, "array");
			}
			for (int i = 0; i < this.content.Count; i++)
			{
				array[i + arrayIndex] = this.content[i];
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00005830 File Offset: 0x00003A30
		int ICollection<ShellObject>.Count
		{
			get
			{
				return this.content.Count;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00005850 File Offset: 0x00003A50
		public bool IsReadOnly
		{
			get
			{
				return this.readOnly;
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00005868 File Offset: 0x00003A68
		public bool Remove(ShellObject item)
		{
			if (this.readOnly)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellObjectCollectionRemoveReadOnly);
			}
			return this.content.Remove(item);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005A08 File Offset: 0x00003C08
		IEnumerator<ShellObject> IEnumerable<ShellObject>.GetEnumerator()
		{
			foreach (ShellObject obj in this.content)
			{
				yield return obj;
			}
			yield break;
		}

		// Token: 0x0400002E RID: 46
		private List<ShellObject> content = new List<ShellObject>();

		// Token: 0x0400002F RID: 47
		private bool readOnly;

		// Token: 0x04000030 RID: 48
		private bool isDisposed;
	}
}
