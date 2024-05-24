using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000070 RID: 112
	public class EmbeddedFile
	{
		// Token: 0x06000495 RID: 1173 RVA: 0x0004E31C File Offset: 0x0004D31C
		public EmbeddedFile(byte[] file, string fileName, DateTime modifiedDate)
		{
			if (fileName == "")
			{
				throw new GeneratorException("Name of embedded file can not be empty.");
			}
			if (fileName.IndexOf(".") == -1)
			{
				throw new GeneratorException("Name of embedded file must contain an appropriate file extension.");
			}
			this.b = y0.a(file, 0, file.Length);
			this.f = fileName;
			this.e = modifiedDate;
			this.a = new aci(this.f);
			this.a.a(true);
			EmbeddedFile.c++;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0004E3D8 File Offset: 0x0004D3D8
		public EmbeddedFile(FileStream file, string fileName, DateTime modifiedDate)
		{
			if (fileName == "")
			{
				throw new GeneratorException("Name of embedded file can not be empty.");
			}
			if (fileName.IndexOf(".") == -1)
			{
				throw new GeneratorException("Name of embedded file must contain an appropriate file extension.");
			}
			this.b = new byte[file.Length];
			file.Read(this.b, 0, this.b.Length);
			file.Close();
			this.b = y0.a(this.b, 0, this.b.Length);
			this.f = fileName;
			this.e = modifiedDate;
			this.a = new aci(this.f);
			this.a.a(true);
			EmbeddedFile.c++;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0004E4CC File Offset: 0x0004D4CC
		public EmbeddedFile(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			this.b = new byte[fileStream.Length];
			fileStream.Read(this.b, 0, this.b.Length);
			fileStream.Close();
			this.b = y0.a(this.b, 0, this.b.Length);
			this.e = File.GetLastWriteTime(filePath);
			this.f = Path.GetFileName(filePath);
			this.a = new aci(this.f);
			this.a.a(true);
			EmbeddedFile.c++;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0004E597 File Offset: 0x0004D597
		internal EmbeddedFile(aci A_0)
		{
			this.a = A_0;
			this.f = null;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0004E5D0 File Offset: 0x0004D5D0
		public virtual void DrawReference(DocumentWriter writer)
		{
			writer.WriteReference(this.b());
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0004E5E0 File Offset: 0x0004D5E0
		internal EmbeddedFileResource b()
		{
			EmbeddedFileResource result;
			if (this.h == null)
			{
				this.h = new EmbeddedFileResource(this);
				result = this.h;
			}
			else
			{
				result = this.h;
			}
			return result;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0004E61E File Offset: 0x0004D61E
		internal void a(DocumentWriter A_0)
		{
			this.a.a(A_0);
			this.DrawReference(A_0);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0004E638 File Offset: 0x0004D638
		internal byte[] c()
		{
			return aci.a(this.FileName);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0004E658 File Offset: 0x0004D658
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x0004E670 File Offset: 0x0004D670
		public virtual string FileName
		{
			get
			{
				return this.f;
			}
			set
			{
				if (value == "")
				{
					throw new GeneratorException("Name of embedded file can not be empty.");
				}
				if (value.IndexOf(".") == -1)
				{
					throw new GeneratorException("Name of embedded file must contain an appropriate file extension.");
				}
				this.f = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0004E6C4 File Offset: 0x0004D6C4
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0004E6DC File Offset: 0x0004D6DC
		public EmbeddedFileRelation Relation
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0004E6E8 File Offset: 0x0004D6E8
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0004E700 File Offset: 0x0004D700
		public string MimeType
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0004E70C File Offset: 0x0004D70C
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x0004E724 File Offset: 0x0004D724
		public virtual string Description
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0004E730 File Offset: 0x0004D730
		internal DateTime d()
		{
			return this.e;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0004E748 File Offset: 0x0004D748
		internal void a(DateTime A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0004E754 File Offset: 0x0004D754
		internal byte[] e()
		{
			return this.b;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0004E76C File Offset: 0x0004D76C
		internal void a(byte[] A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0004E778 File Offset: 0x0004D778
		internal aci f()
		{
			return this.a;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0004E790 File Offset: 0x0004D790
		internal void a(aci A_0)
		{
			this.a = A_0;
		}

		// Token: 0x040002B7 RID: 695
		private aci a;

		// Token: 0x040002B8 RID: 696
		private byte[] b;

		// Token: 0x040002B9 RID: 697
		private static int c = 1;

		// Token: 0x040002BA RID: 698
		private string d = "";

		// Token: 0x040002BB RID: 699
		private DateTime e;

		// Token: 0x040002BC RID: 700
		private string f;

		// Token: 0x040002BD RID: 701
		private EmbeddedFileRelation g = EmbeddedFileRelation.Unspecified;

		// Token: 0x040002BE RID: 702
		private EmbeddedFileResource h = null;

		// Token: 0x040002BF RID: 703
		private string i = null;
	}
}
