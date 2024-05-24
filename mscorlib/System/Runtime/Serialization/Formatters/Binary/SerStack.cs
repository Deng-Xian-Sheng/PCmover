using System;
using System.Diagnostics;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000795 RID: 1941
	internal sealed class SerStack
	{
		// Token: 0x06005436 RID: 21558 RVA: 0x00128C8E File Offset: 0x00126E8E
		internal SerStack()
		{
			this.stackId = "System";
		}

		// Token: 0x06005437 RID: 21559 RVA: 0x00128CB4 File Offset: 0x00126EB4
		internal SerStack(string stackId)
		{
			this.stackId = stackId;
		}

		// Token: 0x06005438 RID: 21560 RVA: 0x00128CD8 File Offset: 0x00126ED8
		internal void Push(object obj)
		{
			if (this.top == this.objects.Length - 1)
			{
				this.IncreaseCapacity();
			}
			object[] array = this.objects;
			int num = this.top + 1;
			this.top = num;
			array[num] = obj;
		}

		// Token: 0x06005439 RID: 21561 RVA: 0x00128D18 File Offset: 0x00126F18
		internal object Pop()
		{
			if (this.top < 0)
			{
				return null;
			}
			object result = this.objects[this.top];
			object[] array = this.objects;
			int num = this.top;
			this.top = num - 1;
			array[num] = null;
			return result;
		}

		// Token: 0x0600543A RID: 21562 RVA: 0x00128D58 File Offset: 0x00126F58
		internal void IncreaseCapacity()
		{
			int num = this.objects.Length * 2;
			object[] destinationArray = new object[num];
			Array.Copy(this.objects, 0, destinationArray, 0, this.objects.Length);
			this.objects = destinationArray;
		}

		// Token: 0x0600543B RID: 21563 RVA: 0x00128D94 File Offset: 0x00126F94
		internal object Peek()
		{
			if (this.top < 0)
			{
				return null;
			}
			return this.objects[this.top];
		}

		// Token: 0x0600543C RID: 21564 RVA: 0x00128DAE File Offset: 0x00126FAE
		internal object PeekPeek()
		{
			if (this.top < 1)
			{
				return null;
			}
			return this.objects[this.top - 1];
		}

		// Token: 0x0600543D RID: 21565 RVA: 0x00128DCA File Offset: 0x00126FCA
		internal int Count()
		{
			return this.top + 1;
		}

		// Token: 0x0600543E RID: 21566 RVA: 0x00128DD4 File Offset: 0x00126FD4
		internal bool IsEmpty()
		{
			return this.top <= 0;
		}

		// Token: 0x0600543F RID: 21567 RVA: 0x00128DE4 File Offset: 0x00126FE4
		[Conditional("SER_LOGGING")]
		internal void Dump()
		{
			for (int i = 0; i < this.Count(); i++)
			{
				object obj = this.objects[i];
			}
		}

		// Token: 0x04002647 RID: 9799
		internal object[] objects = new object[5];

		// Token: 0x04002648 RID: 9800
		internal string stackId;

		// Token: 0x04002649 RID: 9801
		internal int top = -1;

		// Token: 0x0400264A RID: 9802
		internal int next;
	}
}
