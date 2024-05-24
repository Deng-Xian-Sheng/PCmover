using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000797 RID: 1943
	[Serializable]
	internal sealed class IntSizedArray : ICloneable
	{
		// Token: 0x06005447 RID: 21575 RVA: 0x00128FE8 File Offset: 0x001271E8
		public IntSizedArray()
		{
		}

		// Token: 0x06005448 RID: 21576 RVA: 0x0012900C File Offset: 0x0012720C
		private IntSizedArray(IntSizedArray sizedArray)
		{
			this.objects = new int[sizedArray.objects.Length];
			sizedArray.objects.CopyTo(this.objects, 0);
			this.negObjects = new int[sizedArray.negObjects.Length];
			sizedArray.negObjects.CopyTo(this.negObjects, 0);
		}

		// Token: 0x06005449 RID: 21577 RVA: 0x00129082 File Offset: 0x00127282
		public object Clone()
		{
			return new IntSizedArray(this);
		}

		// Token: 0x17000DD9 RID: 3545
		internal int this[int index]
		{
			get
			{
				if (index < 0)
				{
					if (-index > this.negObjects.Length - 1)
					{
						return 0;
					}
					return this.negObjects[-index];
				}
				else
				{
					if (index > this.objects.Length - 1)
					{
						return 0;
					}
					return this.objects[index];
				}
			}
			set
			{
				if (index < 0)
				{
					if (-index > this.negObjects.Length - 1)
					{
						this.IncreaseCapacity(index);
					}
					this.negObjects[-index] = value;
					return;
				}
				if (index > this.objects.Length - 1)
				{
					this.IncreaseCapacity(index);
				}
				this.objects[index] = value;
			}
		}

		// Token: 0x0600544C RID: 21580 RVA: 0x00129114 File Offset: 0x00127314
		internal void IncreaseCapacity(int index)
		{
			try
			{
				if (index < 0)
				{
					int num = Math.Max(this.negObjects.Length * 2, -index + 1);
					int[] destinationArray = new int[num];
					Array.Copy(this.negObjects, 0, destinationArray, 0, this.negObjects.Length);
					this.negObjects = destinationArray;
				}
				else
				{
					int num2 = Math.Max(this.objects.Length * 2, index + 1);
					int[] destinationArray2 = new int[num2];
					Array.Copy(this.objects, 0, destinationArray2, 0, this.objects.Length);
					this.objects = destinationArray2;
				}
			}
			catch (Exception)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_CorruptedStream"));
			}
		}

		// Token: 0x0400264D RID: 9805
		internal int[] objects = new int[16];

		// Token: 0x0400264E RID: 9806
		internal int[] negObjects = new int[4];
	}
}
