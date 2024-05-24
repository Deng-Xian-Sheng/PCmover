using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200039E RID: 926
	public abstract class ColorSpace : Resource
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06002781 RID: 10113 RVA: 0x0016B080 File Offset: 0x0016A080
		public static ColorSpace DeviceGray
		{
			get
			{
				return ColorSpace.a;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06002782 RID: 10114 RVA: 0x0016B098 File Offset: 0x0016A098
		public static ColorSpace DeviceRgb
		{
			get
			{
				return ColorSpace.b;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06002783 RID: 10115 RVA: 0x0016B0B0 File Offset: 0x0016A0B0
		public static ColorSpace DeviceCmyk
		{
			get
			{
				return ColorSpace.c;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06002784 RID: 10116 RVA: 0x0016B0C8 File Offset: 0x0016A0C8
		public static ColorSpace Pattern
		{
			get
			{
				if (ColorSpace.d == null)
				{
					ColorSpace.d = new x8(new byte[]
					{
						80,
						97,
						116,
						116,
						101,
						114,
						110
					});
				}
				return ColorSpace.d;
			}
		}

		// Token: 0x06002785 RID: 10117 RVA: 0x0016B109 File Offset: 0x0016A109
		public override void Draw(DocumentWriter writer)
		{
			throw new GeneratorException("Device or pattern color spaces cannot be drawn as a resource.");
		}

		// Token: 0x06002786 RID: 10118
		public abstract void DrawName(PageWriter writer);

		// Token: 0x06002787 RID: 10119
		public abstract void DrawColorSpace(DocumentWriter writer);

		// Token: 0x04001119 RID: 4377
		private new static ColorSpace a = new x8(new byte[]
		{
			68,
			101,
			118,
			105,
			99,
			101,
			71,
			114,
			97,
			121
		});

		// Token: 0x0400111A RID: 4378
		private new static ColorSpace b = new x8(new byte[]
		{
			68,
			101,
			118,
			105,
			99,
			101,
			82,
			71,
			66
		});

		// Token: 0x0400111B RID: 4379
		private new static ColorSpace c = new x8(new byte[]
		{
			68,
			101,
			118,
			105,
			99,
			101,
			67,
			77,
			89,
			75
		});

		// Token: 0x0400111C RID: 4380
		private new static ColorSpace d = null;
	}
}
