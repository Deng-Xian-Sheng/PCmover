using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200008E RID: 142
	public class StructureElement : Tag
	{
		// Token: 0x060006C8 RID: 1736 RVA: 0x0005E851 File Offset: 0x0005D851
		internal StructureElement()
		{
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0005E890 File Offset: 0x0005D890
		public StructureElement(TagType tag)
		{
			this.p = tag;
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0005E8E0 File Offset: 0x0005D8E0
		public StructureElement(TagType tag, bool includeDefaultAttributes)
		{
			this.p = tag;
			this.ab = includeDefaultAttributes;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0005E938 File Offset: 0x0005D938
		internal StructureElement(TagType A_0, int A_1)
		{
			this.p = A_0;
			this.q = A_1;
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0005E990 File Offset: 0x0005D990
		internal bool k()
		{
			return this.ad;
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0005E9A8 File Offset: 0x0005D9A8
		internal new void a(bool A_0)
		{
			this.ad = A_0;
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0005E9B4 File Offset: 0x0005D9B4
		internal virtual int l()
		{
			return 0;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0005E9C7 File Offset: 0x0005D9C7
		internal new virtual void b(int A_0)
		{
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0005E9CC File Offset: 0x0005D9CC
		internal int m()
		{
			return this.af;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0005E9E4 File Offset: 0x0005D9E4
		internal new void d(int A_0)
		{
			this.af = A_0;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0005E9F0 File Offset: 0x0005D9F0
		internal cv n()
		{
			if (this.z == null)
			{
				this.z = new cv(3);
			}
			return this.z;
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0005EA24 File Offset: 0x0005DA24
		internal new void a(cv A_0)
		{
			this.z = A_0;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0005EA30 File Offset: 0x0005DA30
		internal HybridDictionary o()
		{
			if (this.ae == null)
			{
				this.ae = new HybridDictionary(1);
			}
			return this.ae;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0005EA66 File Offset: 0x0005DA66
		internal new void a(HybridDictionary A_0)
		{
			this.ae = A_0;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x0005EA70 File Offset: 0x0005DA70
		// (set) Token: 0x060006D7 RID: 1751 RVA: 0x0005EA88 File Offset: 0x0005DA88
		public StructureElement Parent
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x0005EA94 File Offset: 0x0005DA94
		// (set) Token: 0x060006D9 RID: 1753 RVA: 0x0005EAAC File Offset: 0x0005DAAC
		public int Order
		{
			get
			{
				return this.aa;
			}
			set
			{
				this.aa = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x0005EAB8 File Offset: 0x0005DAB8
		public override TagType TagType
		{
			get
			{
				return this.p;
			}
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0005EAD0 File Offset: 0x0005DAD0
		internal new void a(TagType A_0)
		{
			this.p = A_0;
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0005EADC File Offset: 0x0005DADC
		internal int p()
		{
			return this.q;
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0005EAF4 File Offset: 0x0005DAF4
		internal new void e(int A_0)
		{
			this.q = A_0;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x0005EB00 File Offset: 0x0005DB00
		// (set) Token: 0x060006DF RID: 1759 RVA: 0x0005EB18 File Offset: 0x0005DB18
		public string Title
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060006E0 RID: 1760 RVA: 0x0005EB24 File Offset: 0x0005DB24
		// (set) Token: 0x060006E1 RID: 1761 RVA: 0x0005EB3C File Offset: 0x0005DB3C
		public string Identifier
		{
			get
			{
				return this.s;
			}
			set
			{
				this.s = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060006E2 RID: 1762 RVA: 0x0005EB48 File Offset: 0x0005DB48
		// (set) Token: 0x060006E3 RID: 1763 RVA: 0x0005EB60 File Offset: 0x0005DB60
		public string Language
		{
			get
			{
				return this.t;
			}
			set
			{
				this.t = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060006E4 RID: 1764 RVA: 0x0005EB6C File Offset: 0x0005DB6C
		// (set) Token: 0x060006E5 RID: 1765 RVA: 0x0005EB84 File Offset: 0x0005DB84
		public string AlternateText
		{
			get
			{
				return this.u;
			}
			set
			{
				this.u = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060006E6 RID: 1766 RVA: 0x0005EB90 File Offset: 0x0005DB90
		// (set) Token: 0x060006E7 RID: 1767 RVA: 0x0005EBA8 File Offset: 0x0005DBA8
		public string Abbreviation
		{
			get
			{
				return this.v;
			}
			set
			{
				this.v = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060006E8 RID: 1768 RVA: 0x0005EBB4 File Offset: 0x0005DBB4
		// (set) Token: 0x060006E9 RID: 1769 RVA: 0x0005EBCC File Offset: 0x0005DBCC
		public string ActualText
		{
			get
			{
				return this.w;
			}
			set
			{
				this.w = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060006EA RID: 1770 RVA: 0x0005EBD8 File Offset: 0x0005DBD8
		public AttributeClassList Classes
		{
			get
			{
				if (this.x == null)
				{
					this.x = new AttributeClassList(1);
				}
				return this.x;
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0005EC0C File Offset: 0x0005DC0C
		internal AttributeClassList q()
		{
			return this.x;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0005EC24 File Offset: 0x0005DC24
		internal AttributeTypeList r()
		{
			return this.y;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0005EC3C File Offset: 0x0005DC3C
		internal new void a(AttributeClassList A_0)
		{
			this.x = A_0;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0005EC46 File Offset: 0x0005DC46
		internal new void a(AttributeTypeList A_0)
		{
			this.y = A_0;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x0005EC50 File Offset: 0x0005DC50
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x0005EC68 File Offset: 0x0005DC68
		public bool IncludeDefaultAttributes
		{
			get
			{
				return this.ab;
			}
			set
			{
				this.ab = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x0005EC74 File Offset: 0x0005DC74
		public AttributeTypeList AttributeLists
		{
			get
			{
				if (this.y == null)
				{
					this.y = new AttributeTypeList(1);
				}
				return this.y;
			}
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0005ECA8 File Offset: 0x0005DCA8
		public override string ToString()
		{
			return this.s;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0005ECC0 File Offset: 0x0005DCC0
		internal override void e(PageWriter A_0, TaggablePageElement A_1)
		{
			if (A_0.k() != null && A_1 != null)
			{
				this.Parent = A_0.k();
			}
			this.q = A_0.Page.f();
			if (A_0.Page.fg() == null || A_0.k() != null)
			{
				A_0.a(A_0.j() + 1);
			}
			else
			{
				A_0.a(A_0.Page.fg().o() + 1);
				A_0.Page.fg().a(A_0.Page.fg().o() + 1);
			}
			this.n().a(new cx(A_0.j(), A_0.Page.f(), (A_1 == null) ? 0 : A_1.TagOrder, A_0.DocumentWriter.ae()));
			A_0.Document.j().e(this);
			A_0.Document.j().a(A_0.Page.f(), A_0.j(), this);
			if (A_1 != null)
			{
				this.a(A_0, A_1, A_0.Document.j());
			}
			A_0.a(this.p);
			A_0.b(A_0.j());
			A_0.aa();
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0005EE1C File Offset: 0x0005DE1C
		internal new void a(acx A_0, Cell A_1)
		{
			PageWriter pageWriter = A_0.c();
			if (pageWriter.Page.fg() == null || pageWriter.k() != null)
			{
				pageWriter.a(pageWriter.j() + 1);
			}
			else
			{
				pageWriter.a(pageWriter.Page.fg().o() + 1);
				pageWriter.Page.fg().a(pageWriter.Page.fg().o() + 1);
			}
			this.q = pageWriter.Page.f();
			this.n().a(new cx(pageWriter.j(), pageWriter.Page.f(), 0, pageWriter.DocumentWriter.ae()));
			pageWriter.Document.j().e(this);
			pageWriter.Document.j().a(pageWriter.Page.f(), pageWriter.j(), this);
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, A_1, true);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).a(A_0, A_1, true);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					pageWriter.Document.j().b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0, true);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							pageWriter.Document.j().b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0, true);
							}
						}
					}
				}
			}
			pageWriter.a(this.p);
			pageWriter.b(pageWriter.j());
			pageWriter.aa();
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0005F118 File Offset: 0x0005E118
		internal new void a(PageWriter A_0, TaggablePageElement A_1, Resource A_2)
		{
			if (A_0.k() != null)
			{
				this.Parent = A_0.k();
			}
			this.q = A_0.Page.f();
			this.n().a(new cw(A_1.TagOrder, A_0.DocumentWriter.ae(), A_2, A_0.Page.f()));
			A_0.Document.j().e(this);
			this.a(A_0, A_1, A_0.Document.j());
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0005F1A8 File Offset: 0x0005E1A8
		internal new void a(DocumentWriter A_0, int A_1)
		{
			A_0.WriteName(StructureElement.n);
			A_0.WriteNumber(A_1);
			A_0.Document.j().a(A_1, A_0.GetObjectNumber(), true);
			A_0.Document.j().a(A_1, 0, this);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0005F1F8 File Offset: 0x0005E1F8
		internal override void f(PageWriter A_0, ListItem A_1, float A_2, float A_3)
		{
			if (A_0.Page.fg() == null || A_0.k() != null)
			{
				A_0.a(A_0.j() + 1);
			}
			else
			{
				A_0.a(A_0.Page.fg().o() + 1);
				A_0.Page.fg().a(A_0.Page.fg().o() + 1);
			}
			this.q = A_0.Page.f();
			this.n().a(new cx(A_0.j(), A_0.Page.f(), A_1.TagOrder, A_0.DocumentWriter.ae()));
			A_0.Document.j().e(this);
			A_0.Document.j().a(A_0.Page.f(), A_0.j(), this);
			if (A_1 != null)
			{
				this.a(A_0, A_1, A_2, A_3, A_0.Document.j(), false, false);
			}
			A_0.a(this.p);
			A_0.b(A_0.j());
			A_0.aa();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0005F330 File Offset: 0x0005E330
		internal new void a(PageWriter A_0, ListItem A_1, float A_2, float A_3, r2 A_4, bool A_5, bool A_6)
		{
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, A_1, A_2, A_3, A_5);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).a(A_0, A_1, A_2, A_3, A_5);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					A_4.b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.b(A_0, A_1, A_2, A_3, A_6);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							A_4.b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.b(A_0, A_1, A_2, A_3, A_6);
							}
						}
					}
				}
			}
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0005F518 File Offset: 0x0005E518
		internal new void a(PageWriter A_0, TaggablePageElement A_1, r2 A_2)
		{
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || this.AttributeLists[0].Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.b(A_1, A_0);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).b(A_1, A_0);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					A_2.b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							A_2.b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0);
							}
						}
					}
				}
			}
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0005F6E4 File Offset: 0x0005E6E4
		internal new void a(acx A_0, Row A_1)
		{
			PageWriter pageWriter = A_0.c();
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, A_1);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).a(A_0, A_1);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					pageWriter.Document.j().b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							pageWriter.Document.j().b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0);
							}
						}
					}
				}
			}
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0005F8D8 File Offset: 0x0005E8D8
		internal new void a(acx A_0, Cell A_1, bool A_2)
		{
			PageWriter pageWriter = A_0.c();
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, A_1, A_2);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).a(A_0, A_1, A_2);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					pageWriter.Document.j().b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0, A_2);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							pageWriter.Document.j().b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0, A_2);
							}
						}
					}
				}
			}
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0005FAD0 File Offset: 0x0005EAD0
		internal new void a(q0 A_0, Cell2 A_1)
		{
			PageWriter pageWriter = A_0.c();
			if (pageWriter.Page.fg() == null || pageWriter.k() != null)
			{
				pageWriter.a(pageWriter.j() + 1);
			}
			else
			{
				pageWriter.a(pageWriter.Page.fg().o() + 1);
				pageWriter.Page.fg().a(pageWriter.Page.fg().o() + 1);
			}
			this.q = pageWriter.Page.f();
			this.n().a(new cx(pageWriter.j(), pageWriter.Page.f(), 0, pageWriter.DocumentWriter.ae()));
			pageWriter.Document.j().e(this);
			pageWriter.Document.j().a(pageWriter.Page.f(), pageWriter.j(), this);
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, A_1, true);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).a(A_0, A_1, true);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					pageWriter.Document.j().b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0, true);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							pageWriter.Document.j().b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0, true);
							}
						}
					}
				}
			}
			pageWriter.a(this.p);
			pageWriter.b(pageWriter.j());
			pageWriter.aa();
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0005FDCC File Offset: 0x0005EDCC
		internal new void a(PageWriter A_0, Table2 A_1, r2 A_2)
		{
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || this.AttributeLists[0].Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.b(A_1, A_0);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).b(A_1, A_0);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					A_2.b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							A_2.b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0);
							}
						}
					}
				}
			}
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0005FF98 File Offset: 0x0005EF98
		internal new void a(q0 A_0, Row2 A_1)
		{
			PageWriter pageWriter = A_0.c();
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, A_1);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).a(A_0, A_1);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					pageWriter.Document.j().b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							pageWriter.Document.j().b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0);
							}
						}
					}
				}
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0006018C File Offset: 0x0005F18C
		internal new void a(q0 A_0, Cell2 A_1, bool A_2)
		{
			PageWriter pageWriter = A_0.c();
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (this.ab)
			{
				if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject;
					if (A_1.ColumnSpan > 1 || A_1.RowSpan > 1)
					{
						attributeObject = new AttributeObject(AttributeOwner.Table);
						if (A_1.ColumnSpan > 1)
						{
							attributeObject.SetColumnSpan(A_1.ColumnSpan);
						}
						if (A_1.RowSpan > 1)
						{
							attributeObject.SetRowSpan(A_1.RowSpan);
						}
					}
					else
					{
						attributeObject = new AttributeObject(AttributeOwner.Layout);
					}
					attributeObject.a(A_0, A_1, A_2);
					this.AttributeLists.Add(attributeObject);
				}
				else
				{
					((AttributeObject)this.AttributeLists[0]).a(A_0, A_1, A_2);
				}
			}
			for (int i = 0; i < num; i++)
			{
				if (this.AttributeLists[i].Owner == AttributeOwner.UserProperties)
				{
					pageWriter.Document.j().b(true);
				}
				else
				{
					AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
					if (attributeObject.d())
					{
						attributeObject.a(A_1, A_0, A_2);
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						if (attributeObjects[i].Owner == AttributeOwner.UserProperties)
						{
							pageWriter.Document.j().b(true);
						}
						else
						{
							AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
							if (attributeObject.d())
							{
								attributeObject.a(A_1, A_0, A_2);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x000603F4 File Offset: 0x0005F3F4
		internal new void a(FormattedTextAreaStyle A_0, TaggablePageElement A_1, PageWriter A_2, float A_3, float A_4, float A_5, float A_6)
		{
			this.ac = true;
			int num = (this.y == null) ? 0 : this.AttributeLists.Count;
			if (num == 0 || ((AttributeObject)this.AttributeLists[0]).Owner == AttributeOwner.UserProperties)
			{
				AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
				if (A_0.Underline || A_0.TextRise != 0f)
				{
					attributeObject.a(A_0);
					this.AttributeLists.Add(attributeObject);
				}
			}
			else
			{
				((AttributeObject)this.AttributeLists[0]).a(A_0);
			}
			for (int i = 0; i < num; i++)
			{
				AttributeObject attributeObject = (AttributeObject)this.AttributeLists[i];
				if (attributeObject.d())
				{
					attributeObject.a(A_0, A_1, A_2, A_3, A_4, A_5, A_6);
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				for (int j = 0; j < this.x.Count; j++)
				{
					AttributeTypeList attributeObjects = this.x[j].AttributeObjects;
					for (int i = 0; i < attributeObjects.Count; i++)
					{
						AttributeObject attributeObject = (AttributeObject)attributeObjects[i];
						if (attributeObject.d())
						{
							attributeObject.a(A_0, A_1, A_2, A_3, A_4, A_5, A_6);
						}
					}
				}
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00060590 File Offset: 0x0005F590
		internal AttributeTypeList s()
		{
			AttributeTypeList result;
			if (this.y != null)
			{
				this.y.b();
				AttributeTypeList attributeTypeList = new AttributeTypeList(this.y.Count);
				for (int i = 0; i < this.y.Count; i++)
				{
					if (this.y[i].Owner != AttributeOwner.UserProperties)
					{
						AttributeObject attributeObject = ((AttributeObject)this.y[i]).a(this.ae);
						if (attributeObject != null)
						{
							attributeTypeList.Add(attributeObject);
						}
					}
				}
				result = ((attributeTypeList.Count != 0) ? attributeTypeList : null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00060650 File Offset: 0x0005F650
		internal AttributeClassList t()
		{
			AttributeClassList result;
			if (this.x != null)
			{
				this.x.b();
				AttributeClassList attributeClassList = new AttributeClassList(this.x.Count);
				for (int i = 0; i < this.x.Count; i++)
				{
					AttributeClass attributeClass = this.x[i].a(this.ae);
					if (attributeClass != null)
					{
						attributeClassList.Add(attributeClass);
					}
				}
				result = ((attributeClassList.Count != 0) ? attributeClassList : null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000606E8 File Offset: 0x0005F6E8
		internal bool u()
		{
			return this.ac;
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00060700 File Offset: 0x0005F700
		internal new void b(bool A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0006070C File Offset: 0x0005F70C
		public override void Draw(DocumentWriter writer)
		{
			if (this.z != null && this.z.b() > 1)
			{
				cu[] array = this.z.a();
				Array.Sort<cu>(array, 0, this.z.b());
				this.z.a(r2.a(array, this.z.b()));
			}
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			if (writer.Document.j().e())
			{
				writer.WriteName(Resource.a);
				writer.WriteName(StructureElement.a);
			}
			if (this.p != null)
			{
				writer.WriteName(StructureElement.b);
				writer.WriteName(this.p.ToString());
			}
			if (this.s != null)
			{
				writer.WriteName(StructureElement.c);
				writer.WriteText(this.s);
			}
			if (this.r != null)
			{
				writer.WriteName(StructureElement.l);
				writer.WriteText(this.r);
			}
			writer.WriteName(StructureElement.d);
			writer.WriteReferenceShallow((this.o == null) ? writer.Document.j().c() : Convert.ToInt32(writer.Document.j().f()[this.o]));
			if (this.z != null)
			{
				for (int i = 0; i < this.z.b(); i++)
				{
					if (this.z.a(i).bb() && this.q != -1)
					{
						writer.WriteName(StructureElement.e);
						writer.WriteReferenceShallow(writer.Document.j().a(this.q));
						break;
					}
				}
			}
			if (this.x != null && this.x.Count > 0)
			{
				writer.WriteName(StructureElement.f);
				if (this.x.Count == 1)
				{
					writer.WriteName(this.x[0].a());
				}
				else
				{
					writer.WriteArrayOpen();
					for (int i = 0; i < this.x.Count; i++)
					{
						writer.WriteName(this.x[i].a());
					}
					writer.WriteArrayClose();
				}
			}
			if (this.y != null && this.y.Count > 0)
			{
				if (this.y.Count == 1)
				{
					if (this.y[0].i() > 0)
					{
						writer.WriteName(StructureElement.g);
						this.y[0].j(writer);
					}
				}
				else
				{
					writer.WriteName(StructureElement.g);
					writer.WriteArrayOpen();
					for (int i = 0; i < this.y.Count; i++)
					{
						this.y[i].j(writer);
					}
					writer.WriteArrayClose();
				}
			}
			if (this.z != null)
			{
				writer.WriteName(StructureElement.h);
				if (this.z.b() == 1)
				{
					this.z.a(0).a9(writer, this.q);
				}
				else
				{
					writer.WriteArrayOpen();
					for (int j = 0; j < this.z.b(); j++)
					{
						this.z.a(j).a9(writer, this.q);
					}
					writer.WriteArrayClose();
				}
			}
			if (this.t != null)
			{
				writer.WriteName(StructureElement.i);
				writer.WriteText(this.t);
			}
			if (this.w != null)
			{
				writer.WriteName(StructureElement.m);
				writer.WriteText(this.w);
			}
			if (this.v != null)
			{
				writer.WriteName(StructureElement.k);
				writer.WriteText(this.v);
			}
			if (this.u != null)
			{
				writer.WriteName(StructureElement.j);
				writer.WriteText(this.u);
			}
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00060BAC File Offset: 0x0005FBAC
		internal override Tag h()
		{
			StructureElement structureElement = new StructureElement(this.TagType, this.p());
			structureElement.o = this.o;
			structureElement.p = this.p;
			structureElement.q = this.q;
			structureElement.r = this.r;
			structureElement.s = this.s;
			structureElement.t = this.t;
			structureElement.u = this.u;
			structureElement.v = this.v;
			structureElement.w = this.w;
			if (this.AttributeLists.Count > 0)
			{
				structureElement.a(this.AttributeLists.a());
				structureElement.AttributeLists.b();
			}
			if (this.Classes.Count > 0)
			{
				structureElement.a(this.Classes.a());
				structureElement.Classes.b();
			}
			structureElement.z = this.z;
			structureElement.aa = this.aa;
			structureElement.ab = this.ab;
			structureElement.ac = this.ac;
			structureElement.a(new HybridDictionary(1));
			return structureElement;
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00060CE4 File Offset: 0x0005FCE4
		internal virtual void bp(Resource A_0, int A_1)
		{
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00060CE8 File Offset: 0x0005FCE8
		internal virtual bool bq()
		{
			return true;
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00060CFC File Offset: 0x0005FCFC
		internal virtual bool br()
		{
			return false;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00060D10 File Offset: 0x0005FD10
		internal virtual bool bu()
		{
			return true;
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00060D23 File Offset: 0x0005FD23
		internal virtual void bs(StructureElement A_0)
		{
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00060D28 File Offset: 0x0005FD28
		internal virtual bool bt()
		{
			return true;
		}

		// Token: 0x040003A2 RID: 930
		private new static byte[] a = new byte[]
		{
			83,
			116,
			114,
			117,
			99,
			116,
			69,
			108,
			101,
			109
		};

		// Token: 0x040003A3 RID: 931
		private new static byte b = 83;

		// Token: 0x040003A4 RID: 932
		private new static byte[] c = new byte[]
		{
			73,
			68
		};

		// Token: 0x040003A5 RID: 933
		internal new static byte d = 80;

		// Token: 0x040003A6 RID: 934
		internal new static byte[] e = new byte[]
		{
			80,
			103
		};

		// Token: 0x040003A7 RID: 935
		private new static byte f = 67;

		// Token: 0x040003A8 RID: 936
		private new static byte g = 65;

		// Token: 0x040003A9 RID: 937
		internal new static byte h = 75;

		// Token: 0x040003AA RID: 938
		private new static byte[] i = new byte[]
		{
			76,
			97,
			110,
			103
		};

		// Token: 0x040003AB RID: 939
		private static byte[] j = new byte[]
		{
			65,
			108,
			116
		};

		// Token: 0x040003AC RID: 940
		private static byte k = 69;

		// Token: 0x040003AD RID: 941
		private static byte l = 84;

		// Token: 0x040003AE RID: 942
		private static byte[] m = new byte[]
		{
			65,
			99,
			116,
			117,
			97,
			108,
			84,
			101,
			120,
			116
		};

		// Token: 0x040003AF RID: 943
		private static byte[] n = new byte[]
		{
			83,
			116,
			114,
			117,
			99,
			116,
			80,
			97,
			114,
			101,
			110,
			116
		};

		// Token: 0x040003B0 RID: 944
		private StructureElement o;

		// Token: 0x040003B1 RID: 945
		private TagType p;

		// Token: 0x040003B2 RID: 946
		private int q = -1;

		// Token: 0x040003B3 RID: 947
		private string r;

		// Token: 0x040003B4 RID: 948
		private string s;

		// Token: 0x040003B5 RID: 949
		private string t;

		// Token: 0x040003B6 RID: 950
		private string u;

		// Token: 0x040003B7 RID: 951
		private string v;

		// Token: 0x040003B8 RID: 952
		private string w;

		// Token: 0x040003B9 RID: 953
		private AttributeClassList x;

		// Token: 0x040003BA RID: 954
		private AttributeTypeList y;

		// Token: 0x040003BB RID: 955
		private cv z;

		// Token: 0x040003BC RID: 956
		private int aa = 0;

		// Token: 0x040003BD RID: 957
		private bool ab = false;

		// Token: 0x040003BE RID: 958
		private bool ac = false;

		// Token: 0x040003BF RID: 959
		private bool ad = true;

		// Token: 0x040003C0 RID: 960
		private HybridDictionary ae = null;

		// Token: 0x040003C1 RID: 961
		private int af = -1;
	}
}
