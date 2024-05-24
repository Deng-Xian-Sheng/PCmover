using System;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200071B RID: 1819
	public class AreaGroup : Group, IArea, ICoordinate
	{
		// Token: 0x06004847 RID: 18503 RVA: 0x00255ECE File Offset: 0x00254ECE
		public AreaGroup(float width, float height)
		{
			this.a = width;
			this.b = height;
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06004848 RID: 18504 RVA: 0x00255EE8 File Offset: 0x00254EE8
		// (set) Token: 0x06004849 RID: 18505 RVA: 0x00255EFF File Offset: 0x00254EFF
		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
				throw new GeneratorException("X cannot be set on an Area Group.");
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x0600484A RID: 18506 RVA: 0x00255F0C File Offset: 0x00254F0C
		// (set) Token: 0x0600484B RID: 18507 RVA: 0x00255F23 File Offset: 0x00254F23
		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
				throw new GeneratorException("Y cannot be set on an Area Group.");
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x0600484C RID: 18508 RVA: 0x00255F30 File Offset: 0x00254F30
		// (set) Token: 0x0600484D RID: 18509 RVA: 0x00255F48 File Offset: 0x00254F48
		public float Width
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

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x0600484E RID: 18510 RVA: 0x00255F54 File Offset: 0x00254F54
		// (set) Token: 0x0600484F RID: 18511 RVA: 0x00255F6C File Offset: 0x00254F6C
		public float Height
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x04002791 RID: 10129
		private new float a;

		// Token: 0x04002792 RID: 10130
		private float b;
	}
}
