using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x0200074B RID: 1867
	internal sealed class ObjectHolder
	{
		// Token: 0x06005283 RID: 21123 RVA: 0x00122526 File Offset: 0x00120726
		internal ObjectHolder(long objID) : this(null, objID, null, null, 0L, null, null)
		{
		}

		// Token: 0x06005284 RID: 21124 RVA: 0x00122538 File Offset: 0x00120738
		internal ObjectHolder(object obj, long objID, SerializationInfo info, ISerializationSurrogate surrogate, long idOfContainingObj, FieldInfo field, int[] arrayIndex)
		{
			this.m_object = obj;
			this.m_id = objID;
			this.m_flags = 0;
			this.m_missingElementsRemaining = 0;
			this.m_missingDecendents = 0;
			this.m_dependentObjects = null;
			this.m_next = null;
			this.m_serInfo = info;
			this.m_surrogate = surrogate;
			this.m_markForFixupWhenAvailable = false;
			if (obj is TypeLoadExceptionHolder)
			{
				this.m_typeLoad = (TypeLoadExceptionHolder)obj;
			}
			if (idOfContainingObj != 0L && ((field != null && field.FieldType.IsValueType) || arrayIndex != null))
			{
				if (idOfContainingObj == objID)
				{
					throw new SerializationException(Environment.GetResourceString("Serialization_ParentChildIdentical"));
				}
				this.m_valueFixup = new ValueTypeFixupInfo(idOfContainingObj, field, arrayIndex);
			}
			this.SetFlags();
		}

		// Token: 0x06005285 RID: 21125 RVA: 0x001225F4 File Offset: 0x001207F4
		internal ObjectHolder(string obj, long objID, SerializationInfo info, ISerializationSurrogate surrogate, long idOfContainingObj, FieldInfo field, int[] arrayIndex)
		{
			this.m_object = obj;
			this.m_id = objID;
			this.m_flags = 0;
			this.m_missingElementsRemaining = 0;
			this.m_missingDecendents = 0;
			this.m_dependentObjects = null;
			this.m_next = null;
			this.m_serInfo = info;
			this.m_surrogate = surrogate;
			this.m_markForFixupWhenAvailable = false;
			if (idOfContainingObj != 0L && arrayIndex != null)
			{
				this.m_valueFixup = new ValueTypeFixupInfo(idOfContainingObj, field, arrayIndex);
			}
			if (this.m_valueFixup != null)
			{
				this.m_flags |= 8;
			}
		}

		// Token: 0x06005286 RID: 21126 RVA: 0x0012267D File Offset: 0x0012087D
		private void IncrementDescendentFixups(int amount)
		{
			this.m_missingDecendents += amount;
		}

		// Token: 0x06005287 RID: 21127 RVA: 0x0012268D File Offset: 0x0012088D
		internal void DecrementFixupsRemaining(ObjectManager manager)
		{
			this.m_missingElementsRemaining--;
			if (this.RequiresValueTypeFixup)
			{
				this.UpdateDescendentDependencyChain(-1, manager);
			}
		}

		// Token: 0x06005288 RID: 21128 RVA: 0x001226AD File Offset: 0x001208AD
		internal void RemoveDependency(long id)
		{
			this.m_dependentObjects.RemoveElement(id);
		}

		// Token: 0x06005289 RID: 21129 RVA: 0x001226BC File Offset: 0x001208BC
		internal void AddFixup(FixupHolder fixup, ObjectManager manager)
		{
			if (this.m_missingElements == null)
			{
				this.m_missingElements = new FixupHolderList();
			}
			this.m_missingElements.Add(fixup);
			this.m_missingElementsRemaining++;
			if (this.RequiresValueTypeFixup)
			{
				this.UpdateDescendentDependencyChain(1, manager);
			}
		}

		// Token: 0x0600528A RID: 21130 RVA: 0x001226FC File Offset: 0x001208FC
		private void UpdateDescendentDependencyChain(int amount, ObjectManager manager)
		{
			ObjectHolder objectHolder = this;
			do
			{
				objectHolder = manager.FindOrCreateObjectHolder(objectHolder.ContainerID);
				objectHolder.IncrementDescendentFixups(amount);
			}
			while (objectHolder.RequiresValueTypeFixup);
		}

		// Token: 0x0600528B RID: 21131 RVA: 0x00122727 File Offset: 0x00120927
		internal void AddDependency(long dependentObject)
		{
			if (this.m_dependentObjects == null)
			{
				this.m_dependentObjects = new LongList();
			}
			this.m_dependentObjects.Add(dependentObject);
		}

		// Token: 0x0600528C RID: 21132 RVA: 0x00122748 File Offset: 0x00120948
		[SecurityCritical]
		internal void UpdateData(object obj, SerializationInfo info, ISerializationSurrogate surrogate, long idOfContainer, FieldInfo field, int[] arrayIndex, ObjectManager manager)
		{
			this.SetObjectValue(obj, manager);
			this.m_serInfo = info;
			this.m_surrogate = surrogate;
			if (idOfContainer != 0L && ((field != null && field.FieldType.IsValueType) || arrayIndex != null))
			{
				if (idOfContainer == this.m_id)
				{
					throw new SerializationException(Environment.GetResourceString("Serialization_ParentChildIdentical"));
				}
				this.m_valueFixup = new ValueTypeFixupInfo(idOfContainer, field, arrayIndex);
			}
			this.SetFlags();
			if (this.RequiresValueTypeFixup)
			{
				this.UpdateDescendentDependencyChain(this.m_missingElementsRemaining, manager);
			}
		}

		// Token: 0x0600528D RID: 21133 RVA: 0x001227D3 File Offset: 0x001209D3
		internal void MarkForCompletionWhenAvailable()
		{
			this.m_markForFixupWhenAvailable = true;
		}

		// Token: 0x0600528E RID: 21134 RVA: 0x001227DC File Offset: 0x001209DC
		internal void SetFlags()
		{
			if (this.m_object is IObjectReference)
			{
				this.m_flags |= 1;
			}
			this.m_flags &= -7;
			if (this.m_surrogate != null)
			{
				this.m_flags |= 4;
			}
			else if (this.m_object is ISerializable)
			{
				this.m_flags |= 2;
			}
			if (this.m_valueFixup != null)
			{
				this.m_flags |= 8;
			}
		}

		// Token: 0x17000D96 RID: 3478
		// (get) Token: 0x0600528F RID: 21135 RVA: 0x0012285C File Offset: 0x00120A5C
		// (set) Token: 0x06005290 RID: 21136 RVA: 0x00122869 File Offset: 0x00120A69
		internal bool IsIncompleteObjectReference
		{
			get
			{
				return (this.m_flags & 1) != 0;
			}
			set
			{
				if (value)
				{
					this.m_flags |= 1;
					return;
				}
				this.m_flags &= -2;
			}
		}

		// Token: 0x17000D97 RID: 3479
		// (get) Token: 0x06005291 RID: 21137 RVA: 0x0012288C File Offset: 0x00120A8C
		internal bool RequiresDelayedFixup
		{
			get
			{
				return (this.m_flags & 7) != 0;
			}
		}

		// Token: 0x17000D98 RID: 3480
		// (get) Token: 0x06005292 RID: 21138 RVA: 0x00122899 File Offset: 0x00120A99
		internal bool RequiresValueTypeFixup
		{
			get
			{
				return (this.m_flags & 8) != 0;
			}
		}

		// Token: 0x17000D99 RID: 3481
		// (get) Token: 0x06005293 RID: 21139 RVA: 0x001228A6 File Offset: 0x00120AA6
		// (set) Token: 0x06005294 RID: 21140 RVA: 0x001228DA File Offset: 0x00120ADA
		internal bool ValueTypeFixupPerformed
		{
			get
			{
				return (this.m_flags & 32768) != 0 || (this.m_object != null && (this.m_dependentObjects == null || this.m_dependentObjects.Count == 0));
			}
			set
			{
				if (value)
				{
					this.m_flags |= 32768;
				}
			}
		}

		// Token: 0x17000D9A RID: 3482
		// (get) Token: 0x06005295 RID: 21141 RVA: 0x001228F1 File Offset: 0x00120AF1
		internal bool HasISerializable
		{
			get
			{
				return (this.m_flags & 2) != 0;
			}
		}

		// Token: 0x17000D9B RID: 3483
		// (get) Token: 0x06005296 RID: 21142 RVA: 0x001228FE File Offset: 0x00120AFE
		internal bool HasSurrogate
		{
			get
			{
				return (this.m_flags & 4) != 0;
			}
		}

		// Token: 0x17000D9C RID: 3484
		// (get) Token: 0x06005297 RID: 21143 RVA: 0x0012290B File Offset: 0x00120B0B
		internal bool CanSurrogatedObjectValueChange
		{
			get
			{
				return this.m_surrogate == null || this.m_surrogate.GetType() != typeof(SurrogateForCyclicalReference);
			}
		}

		// Token: 0x17000D9D RID: 3485
		// (get) Token: 0x06005298 RID: 21144 RVA: 0x00122931 File Offset: 0x00120B31
		internal bool CanObjectValueChange
		{
			get
			{
				return this.IsIncompleteObjectReference || (this.HasSurrogate && this.CanSurrogatedObjectValueChange);
			}
		}

		// Token: 0x17000D9E RID: 3486
		// (get) Token: 0x06005299 RID: 21145 RVA: 0x0012294D File Offset: 0x00120B4D
		internal int DirectlyDependentObjects
		{
			get
			{
				return this.m_missingElementsRemaining;
			}
		}

		// Token: 0x17000D9F RID: 3487
		// (get) Token: 0x0600529A RID: 21146 RVA: 0x00122955 File Offset: 0x00120B55
		internal int TotalDependentObjects
		{
			get
			{
				return this.m_missingElementsRemaining + this.m_missingDecendents;
			}
		}

		// Token: 0x17000DA0 RID: 3488
		// (get) Token: 0x0600529B RID: 21147 RVA: 0x00122964 File Offset: 0x00120B64
		// (set) Token: 0x0600529C RID: 21148 RVA: 0x0012296C File Offset: 0x00120B6C
		internal bool Reachable
		{
			get
			{
				return this.m_reachable;
			}
			set
			{
				this.m_reachable = value;
			}
		}

		// Token: 0x17000DA1 RID: 3489
		// (get) Token: 0x0600529D RID: 21149 RVA: 0x00122975 File Offset: 0x00120B75
		internal bool TypeLoadExceptionReachable
		{
			get
			{
				return this.m_typeLoad != null;
			}
		}

		// Token: 0x17000DA2 RID: 3490
		// (get) Token: 0x0600529E RID: 21150 RVA: 0x00122980 File Offset: 0x00120B80
		// (set) Token: 0x0600529F RID: 21151 RVA: 0x00122988 File Offset: 0x00120B88
		internal TypeLoadExceptionHolder TypeLoadException
		{
			get
			{
				return this.m_typeLoad;
			}
			set
			{
				this.m_typeLoad = value;
			}
		}

		// Token: 0x17000DA3 RID: 3491
		// (get) Token: 0x060052A0 RID: 21152 RVA: 0x00122991 File Offset: 0x00120B91
		internal object ObjectValue
		{
			get
			{
				return this.m_object;
			}
		}

		// Token: 0x060052A1 RID: 21153 RVA: 0x00122999 File Offset: 0x00120B99
		[SecurityCritical]
		internal void SetObjectValue(object obj, ObjectManager manager)
		{
			this.m_object = obj;
			if (obj == manager.TopObject)
			{
				this.m_reachable = true;
			}
			if (obj is TypeLoadExceptionHolder)
			{
				this.m_typeLoad = (TypeLoadExceptionHolder)obj;
			}
			if (this.m_markForFixupWhenAvailable)
			{
				manager.CompleteObject(this, true);
			}
		}

		// Token: 0x17000DA4 RID: 3492
		// (get) Token: 0x060052A2 RID: 21154 RVA: 0x001229D6 File Offset: 0x00120BD6
		// (set) Token: 0x060052A3 RID: 21155 RVA: 0x001229DE File Offset: 0x00120BDE
		internal SerializationInfo SerializationInfo
		{
			get
			{
				return this.m_serInfo;
			}
			set
			{
				this.m_serInfo = value;
			}
		}

		// Token: 0x17000DA5 RID: 3493
		// (get) Token: 0x060052A4 RID: 21156 RVA: 0x001229E7 File Offset: 0x00120BE7
		internal ISerializationSurrogate Surrogate
		{
			get
			{
				return this.m_surrogate;
			}
		}

		// Token: 0x17000DA6 RID: 3494
		// (get) Token: 0x060052A5 RID: 21157 RVA: 0x001229EF File Offset: 0x00120BEF
		// (set) Token: 0x060052A6 RID: 21158 RVA: 0x001229F7 File Offset: 0x00120BF7
		internal LongList DependentObjects
		{
			get
			{
				return this.m_dependentObjects;
			}
			set
			{
				this.m_dependentObjects = value;
			}
		}

		// Token: 0x17000DA7 RID: 3495
		// (get) Token: 0x060052A7 RID: 21159 RVA: 0x00122A00 File Offset: 0x00120C00
		// (set) Token: 0x060052A8 RID: 21160 RVA: 0x00122A27 File Offset: 0x00120C27
		internal bool RequiresSerInfoFixup
		{
			get
			{
				return ((this.m_flags & 4) != 0 || (this.m_flags & 2) != 0) && (this.m_flags & 16384) == 0;
			}
			set
			{
				if (!value)
				{
					this.m_flags |= 16384;
					return;
				}
				this.m_flags &= -16385;
			}
		}

		// Token: 0x17000DA8 RID: 3496
		// (get) Token: 0x060052A9 RID: 21161 RVA: 0x00122A51 File Offset: 0x00120C51
		internal ValueTypeFixupInfo ValueFixup
		{
			get
			{
				return this.m_valueFixup;
			}
		}

		// Token: 0x17000DA9 RID: 3497
		// (get) Token: 0x060052AA RID: 21162 RVA: 0x00122A59 File Offset: 0x00120C59
		internal bool CompletelyFixed
		{
			get
			{
				return !this.RequiresSerInfoFixup && !this.IsIncompleteObjectReference;
			}
		}

		// Token: 0x17000DAA RID: 3498
		// (get) Token: 0x060052AB RID: 21163 RVA: 0x00122A6E File Offset: 0x00120C6E
		internal long ContainerID
		{
			get
			{
				if (this.m_valueFixup != null)
				{
					return this.m_valueFixup.ContainerID;
				}
				return 0L;
			}
		}

		// Token: 0x04002483 RID: 9347
		internal const int INCOMPLETE_OBJECT_REFERENCE = 1;

		// Token: 0x04002484 RID: 9348
		internal const int HAS_ISERIALIZABLE = 2;

		// Token: 0x04002485 RID: 9349
		internal const int HAS_SURROGATE = 4;

		// Token: 0x04002486 RID: 9350
		internal const int REQUIRES_VALUETYPE_FIXUP = 8;

		// Token: 0x04002487 RID: 9351
		internal const int REQUIRES_DELAYED_FIXUP = 7;

		// Token: 0x04002488 RID: 9352
		internal const int SER_INFO_FIXED = 16384;

		// Token: 0x04002489 RID: 9353
		internal const int VALUETYPE_FIXUP_PERFORMED = 32768;

		// Token: 0x0400248A RID: 9354
		private object m_object;

		// Token: 0x0400248B RID: 9355
		internal long m_id;

		// Token: 0x0400248C RID: 9356
		private int m_missingElementsRemaining;

		// Token: 0x0400248D RID: 9357
		private int m_missingDecendents;

		// Token: 0x0400248E RID: 9358
		internal SerializationInfo m_serInfo;

		// Token: 0x0400248F RID: 9359
		internal ISerializationSurrogate m_surrogate;

		// Token: 0x04002490 RID: 9360
		internal FixupHolderList m_missingElements;

		// Token: 0x04002491 RID: 9361
		internal LongList m_dependentObjects;

		// Token: 0x04002492 RID: 9362
		internal ObjectHolder m_next;

		// Token: 0x04002493 RID: 9363
		internal int m_flags;

		// Token: 0x04002494 RID: 9364
		private bool m_markForFixupWhenAvailable;

		// Token: 0x04002495 RID: 9365
		private ValueTypeFixupInfo m_valueFixup;

		// Token: 0x04002496 RID: 9366
		private TypeLoadExceptionHolder m_typeLoad;

		// Token: 0x04002497 RID: 9367
		private bool m_reachable;
	}
}
