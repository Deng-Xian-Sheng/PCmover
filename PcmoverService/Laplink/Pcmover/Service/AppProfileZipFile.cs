using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000002 RID: 2
	public class AppProfileZipFile : IDisposable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public bool Open(string fileName)
		{
			this.Close();
			try
			{
				this._archive = ZipFile.OpenRead(fileName);
			}
			catch (Exception)
			{
			}
			return this._archive != null;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002090 File Offset: 0x00000290
		public void Close()
		{
			ZipArchive archive = this._archive;
			if (archive != null)
			{
				archive.Dispose();
			}
			this._archive = null;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020AA File Offset: 0x000002AA
		public void Dispose()
		{
			this.Close();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020B4 File Offset: 0x000002B4
		public byte[] GetFile(string path, string name)
		{
			if (this._archive == null)
			{
				return null;
			}
			string fullPath = string.IsNullOrWhiteSpace(path) ? name : (path + "/" + name);
			ZipArchiveEntry zipArchiveEntry = (from e in this._archive.Entries
			where string.Compare(e.FullName, fullPath, true) == 0
			select e).FirstOrDefault<ZipArchiveEntry>();
			if (zipArchiveEntry == null)
			{
				return null;
			}
			byte[] result;
			try
			{
				ZipArchive archive = this._archive;
				lock (archive)
				{
					using (Stream stream = zipArchiveEntry.Open())
					{
						if (stream == null)
						{
							result = null;
						}
						else
						{
							int num = (int)zipArchiveEntry.Length;
							byte[] array = new byte[num];
							stream.Read(array, 0, num);
							result = array;
						}
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021A4 File Offset: 0x000003A4
		public IEnumerable<string> GetFileList(string path)
		{
			if (this._archive == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(path))
			{
				return from e in this._archive.Entries
				where e.FullName.IndexOf('/') < 0
				select e.Name;
			}
			string fullStart = path + "/";
			return from e in this._archive.Entries
			where e.FullName.StartsWith(fullStart, StringComparison.InvariantCultureIgnoreCase)
			select e.Name;
		}

		// Token: 0x04000001 RID: 1
		private ZipArchive _archive;
	}
}
