using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200005B RID: 91
	internal class by : Resource
	{
		// Token: 0x06000305 RID: 773 RVA: 0x0004015E File Offset: 0x0003F15E
		internal by(FileOpenAction A_0)
		{
			this.a = A_0.a();
			this.b = A_0.b();
			this.c = A_0.NextAction;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00040194 File Offset: 0x0003F194
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			if (this.a != null)
			{
				writer.WriteName(70);
				writer.WriteReferenceUnique(new bh(this.a));
			}
			writer.WriteName(83);
			writer.WriteName(by.e);
			if (this.b != FileLaunchMode.UserPreference)
			{
				writer.WriteName(by.d);
			}
			if (this.b == FileLaunchMode.NewWindow)
			{
				writer.WriteBoolean(true);
			}
			else if (this.b == FileLaunchMode.ExistingWindow)
			{
				writer.WriteBoolean(false);
			}
			if (this.c != null)
			{
				writer.WriteName(by.f);
				this.c.Draw(writer);
			}
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x0400020A RID: 522
		private new string a;

		// Token: 0x0400020B RID: 523
		private new FileLaunchMode b = FileLaunchMode.UserPreference;

		// Token: 0x0400020C RID: 524
		private new ceTe.DynamicPDF.Action c;

		// Token: 0x0400020D RID: 525
		private new static byte[] d = new byte[]
		{
			78,
			101,
			119,
			87,
			105,
			110,
			100,
			111,
			119
		};

		// Token: 0x0400020E RID: 526
		private new static byte[] e = new byte[]
		{
			76,
			97,
			117,
			110,
			99,
			104
		};

		// Token: 0x0400020F RID: 527
		internal new static byte[] f = new byte[]
		{
			78,
			101,
			120,
			116
		};
	}
}
