using System;
using System.IO;
using zz93;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x0200087C RID: 2172
	public class TiffFile
	{
		// Token: 0x06005873 RID: 22643 RVA: 0x00336250 File Offset: 0x00335250
		public TiffFile(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			this.d = fileStream;
			byte[] array = new byte[16];
			fileStream.Read(array, 0, 16);
			if (TiffFile.IsValid(array))
			{
				fileStream.Seek(0L, SeekOrigin.Begin);
				this.a(fileStream);
				return;
			}
			fileStream.Close();
			throw new ImageParsingException("Invalid TIFF File.");
		}

		// Token: 0x06005874 RID: 22644 RVA: 0x003362C7 File Offset: 0x003352C7
		public TiffFile(Stream stream)
		{
			this.d = stream;
			this.a(stream);
		}

		// Token: 0x06005875 RID: 22645 RVA: 0x003362E8 File Offset: 0x003352E8
		public TiffFile(byte[] data) : this(new MemoryStream(data))
		{
		}

		// Token: 0x06005876 RID: 22646 RVA: 0x003362FC File Offset: 0x003352FC
		public void Close()
		{
			try
			{
				this.d.Close();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06005877 RID: 22647 RVA: 0x00336330 File Offset: 0x00335330
		public Document GetDocument()
		{
			Document document = new Document();
			foreach (object obj in this.Images)
			{
				TiffImageData tiffImageData = (TiffImageData)obj;
				document.Pages.Add(tiffImageData.GetPage());
			}
			return document;
		}

		// Token: 0x06005878 RID: 22648 RVA: 0x003363B4 File Offset: 0x003353B4
		public static bool IsValid(string fileExtension)
		{
			return fileExtension == "tiff" || fileExtension == "tif";
		}

		// Token: 0x06005879 RID: 22649 RVA: 0x003363E4 File Offset: 0x003353E4
		public static bool IsValid(byte[] header)
		{
			return (header[0] == 73 && header[1] == 73 && header[2] == 42 && header[3] == 0) || (header[0] == 77 && header[1] == 77 && header[2] == 0 && header[3] == 42);
		}

		// Token: 0x0600587A RID: 22650 RVA: 0x00336434 File Offset: 0x00335434
		private void a(Stream A_0)
		{
			bool a_ = true;
			if (A_0.Position != 0L)
			{
				A_0.Seek(0L, SeekOrigin.Begin);
			}
			byte[] array = new byte[4];
			A_0.Read(array, 0, 4);
			if (array[0] == 73 && array[1] == 73 && array[2] == 42 && array[3] == 0)
			{
				this.a = new yp(A_0);
			}
			else
			{
				if (array[0] != 77 || array[1] != 77 || array[2] != 0 || array[3] != 42)
				{
					throw new ImageParsingException("Invalid TIFF Image.");
				}
				this.a = new yf(A_0);
				a_ = false;
			}
			this.b = new TiffImageData(this.a.gu(4U), this.a, a_);
		}

		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x0600587B RID: 22651 RVA: 0x00336504 File Offset: 0x00335504
		public TiffImageDataList Images
		{
			get
			{
				if (this.c == null)
				{
					this.c = new TiffImageDataList(this.b);
				}
				return this.c;
			}
		}

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x0600587C RID: 22652 RVA: 0x00336540 File Offset: 0x00335540
		public TiffImageData FirstImage
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002EFC RID: 12028
		private ye a;

		// Token: 0x04002EFD RID: 12029
		private TiffImageData b;

		// Token: 0x04002EFE RID: 12030
		private TiffImageDataList c;

		// Token: 0x04002EFF RID: 12031
		private Stream d = null;
	}
}
