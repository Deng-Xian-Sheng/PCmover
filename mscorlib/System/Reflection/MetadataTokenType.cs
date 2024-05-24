using System;

namespace System.Reflection
{
	// Token: 0x020005F9 RID: 1529
	[Serializable]
	internal enum MetadataTokenType
	{
		// Token: 0x04001D2C RID: 7468
		Module,
		// Token: 0x04001D2D RID: 7469
		TypeRef = 16777216,
		// Token: 0x04001D2E RID: 7470
		TypeDef = 33554432,
		// Token: 0x04001D2F RID: 7471
		FieldDef = 67108864,
		// Token: 0x04001D30 RID: 7472
		MethodDef = 100663296,
		// Token: 0x04001D31 RID: 7473
		ParamDef = 134217728,
		// Token: 0x04001D32 RID: 7474
		InterfaceImpl = 150994944,
		// Token: 0x04001D33 RID: 7475
		MemberRef = 167772160,
		// Token: 0x04001D34 RID: 7476
		CustomAttribute = 201326592,
		// Token: 0x04001D35 RID: 7477
		Permission = 234881024,
		// Token: 0x04001D36 RID: 7478
		Signature = 285212672,
		// Token: 0x04001D37 RID: 7479
		Event = 335544320,
		// Token: 0x04001D38 RID: 7480
		Property = 385875968,
		// Token: 0x04001D39 RID: 7481
		ModuleRef = 436207616,
		// Token: 0x04001D3A RID: 7482
		TypeSpec = 452984832,
		// Token: 0x04001D3B RID: 7483
		Assembly = 536870912,
		// Token: 0x04001D3C RID: 7484
		AssemblyRef = 587202560,
		// Token: 0x04001D3D RID: 7485
		File = 637534208,
		// Token: 0x04001D3E RID: 7486
		ExportedType = 654311424,
		// Token: 0x04001D3F RID: 7487
		ManifestResource = 671088640,
		// Token: 0x04001D40 RID: 7488
		GenericPar = 704643072,
		// Token: 0x04001D41 RID: 7489
		MethodSpec = 721420288,
		// Token: 0x04001D42 RID: 7490
		String = 1879048192,
		// Token: 0x04001D43 RID: 7491
		Name = 1895825408,
		// Token: 0x04001D44 RID: 7492
		BaseType = 1912602624,
		// Token: 0x04001D45 RID: 7493
		Invalid = 2147483647
	}
}
