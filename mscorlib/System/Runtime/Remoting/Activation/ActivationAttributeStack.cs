﻿using System;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000897 RID: 2199
	internal class ActivationAttributeStack
	{
		// Token: 0x06005D1F RID: 23839 RVA: 0x00146903 File Offset: 0x00144B03
		internal ActivationAttributeStack()
		{
			this.activationTypes = new object[4];
			this.activationAttributes = new object[4];
			this.freeIndex = 0;
		}

		// Token: 0x06005D20 RID: 23840 RVA: 0x0014692C File Offset: 0x00144B2C
		internal void Push(Type typ, object[] attr)
		{
			if (this.freeIndex == this.activationTypes.Length)
			{
				object[] destinationArray = new object[this.activationTypes.Length * 2];
				object[] destinationArray2 = new object[this.activationAttributes.Length * 2];
				Array.Copy(this.activationTypes, destinationArray, this.activationTypes.Length);
				Array.Copy(this.activationAttributes, destinationArray2, this.activationAttributes.Length);
				this.activationTypes = destinationArray;
				this.activationAttributes = destinationArray2;
			}
			this.activationTypes[this.freeIndex] = typ;
			this.activationAttributes[this.freeIndex] = attr;
			this.freeIndex++;
		}

		// Token: 0x06005D21 RID: 23841 RVA: 0x001469C9 File Offset: 0x00144BC9
		internal object[] Peek(Type typ)
		{
			if (this.freeIndex == 0 || this.activationTypes[this.freeIndex - 1] != typ)
			{
				return null;
			}
			return (object[])this.activationAttributes[this.freeIndex - 1];
		}

		// Token: 0x06005D22 RID: 23842 RVA: 0x001469FC File Offset: 0x00144BFC
		internal void Pop(Type typ)
		{
			if (this.freeIndex != 0 && this.activationTypes[this.freeIndex - 1] == typ)
			{
				this.freeIndex--;
				this.activationTypes[this.freeIndex] = null;
				this.activationAttributes[this.freeIndex] = null;
			}
		}

		// Token: 0x040029EB RID: 10731
		private object[] activationTypes;

		// Token: 0x040029EC RID: 10732
		private object[] activationAttributes;

		// Token: 0x040029ED RID: 10733
		private int freeIndex;
	}
}
