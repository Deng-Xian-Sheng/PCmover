using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200066E RID: 1646
	public abstract class Destination : Action
	{
		// Token: 0x06003F3E RID: 16190 RVA: 0x0021AD97 File Offset: 0x00219D97
		protected Destination(int pageNumber)
		{
			this.a = pageNumber;
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06003F3F RID: 16191 RVA: 0x0021ADAC File Offset: 0x00219DAC
		// (set) Token: 0x06003F40 RID: 16192 RVA: 0x0021ADC4 File Offset: 0x00219DC4
		public int PageNumber
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x0400220D RID: 8717
		private new int a;

		// Token: 0x0400220E RID: 8718
		internal new static byte[] b = new byte[]
		{
			68,
			101,
			115,
			116
		};

		// Token: 0x0400220F RID: 8719
		internal new static byte[] c = new byte[]
		{
			88,
			89,
			90
		};
	}
}
