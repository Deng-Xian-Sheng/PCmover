using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000796 RID: 1942
	[Serializable]
	internal sealed class SizedArray : ICloneable
	{
		// Token: 0x06005440 RID: 21568 RVA: 0x00128E0B File Offset: 0x0012700B
		internal SizedArray()
		{
			this.objects = new object[16];
			this.negObjects = new object[4];
		}

		// Token: 0x06005441 RID: 21569 RVA: 0x00128E2C File Offset: 0x0012702C
		internal SizedArray(int length)
		{
			this.objects = new object[length];
			this.negObjects = new object[length];
		}

		// Token: 0x06005442 RID: 21570 RVA: 0x00128E4C File Offset: 0x0012704C
		private SizedArray(SizedArray sizedArray)
		{
			this.objects = new object[sizedArray.objects.Length];
			sizedArray.objects.CopyTo(this.objects, 0);
			this.negObjects = new object[sizedArray.negObjects.Length];
			sizedArray.negObjects.CopyTo(this.negObjects, 0);
		}

		// Token: 0x06005443 RID: 21571 RVA: 0x00128EA9 File Offset: 0x001270A9
		public object Clone()
		{
			return new SizedArray(this);
		}

		// Token: 0x17000DD8 RID: 3544
		internal object this[int index]
		{
			get
			{
				if (index < 0)
				{
					if (-index > this.negObjects.Length - 1)
					{
						return null;
					}
					return this.negObjects[-index];
				}
				else
				{
					if (index > this.objects.Length - 1)
					{
						return null;
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
				object obj = this.objects[index];
				this.objects[index] = value;
			}
		}

		// Token: 0x06005446 RID: 21574 RVA: 0x00128F40 File Offset: 0x00127140
		internal void IncreaseCapacity(int index)
		{
			try
			{
				if (index < 0)
				{
					int num = Math.Max(this.negObjects.Length * 2, -index + 1);
					object[] destinationArray = new object[num];
					Array.Copy(this.negObjects, 0, destinationArray, 0, this.negObjects.Length);
					this.negObjects = destinationArray;
				}
				else
				{
					int num2 = Math.Max(this.objects.Length * 2, index + 1);
					object[] destinationArray2 = new object[num2];
					Array.Copy(this.objects, 0, destinationArray2, 0, this.objects.Length);
					this.objects = destinationArray2;
				}
			}
			catch (Exception)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_CorruptedStream"));
			}
		}

		// Token: 0x0400264B RID: 9803
		internal object[] objects;

		// Token: 0x0400264C RID: 9804
		internal object[] negObjects;
	}
}
