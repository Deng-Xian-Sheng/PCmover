using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000075 RID: 117
	[ContentProperty("Child")]
	public class Planerator : FrameworkElement
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00016F3A File Offset: 0x0001513A
		// (set) Token: 0x060005D9 RID: 1497 RVA: 0x00016F4C File Offset: 0x0001514C
		public double RotationX
		{
			get
			{
				return (double)base.GetValue(Planerator.RotationXProperty);
			}
			set
			{
				base.SetValue(Planerator.RotationXProperty, value);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x00016F5F File Offset: 0x0001515F
		// (set) Token: 0x060005DB RID: 1499 RVA: 0x00016F71 File Offset: 0x00015171
		public double RotationY
		{
			get
			{
				return (double)base.GetValue(Planerator.RotationYProperty);
			}
			set
			{
				base.SetValue(Planerator.RotationYProperty, value);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x00016F84 File Offset: 0x00015184
		// (set) Token: 0x060005DD RID: 1501 RVA: 0x00016F96 File Offset: 0x00015196
		public double RotationZ
		{
			get
			{
				return (double)base.GetValue(Planerator.RotationZProperty);
			}
			set
			{
				base.SetValue(Planerator.RotationZProperty, value);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x00016FA9 File Offset: 0x000151A9
		// (set) Token: 0x060005DF RID: 1503 RVA: 0x00016FBB File Offset: 0x000151BB
		public double FieldOfView
		{
			get
			{
				return (double)base.GetValue(Planerator.FieldOfViewProperty);
			}
			set
			{
				base.SetValue(Planerator.FieldOfViewProperty, value);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x00016FCE File Offset: 0x000151CE
		// (set) Token: 0x060005E1 RID: 1505 RVA: 0x00016FD8 File Offset: 0x000151D8
		public FrameworkElement Child
		{
			get
			{
				return this._originalChild;
			}
			set
			{
				if (this._originalChild == value)
				{
					return;
				}
				base.RemoveVisualChild(this._visualChild);
				base.RemoveLogicalChild(this._logicalChild);
				this._originalChild = value;
				this._logicalChild = new LayoutInvalidationCatcher
				{
					Child = this._originalChild
				};
				this._visualChild = this.CreateVisualChild();
				base.AddVisualChild(this._visualChild);
				base.AddLogicalChild(this._logicalChild);
				base.InvalidateMeasure();
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x0001704F File Offset: 0x0001524F
		protected override int VisualChildrenCount
		{
			get
			{
				if (this._visualChild != null)
				{
					return 1;
				}
				return 0;
			}
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001705C File Offset: 0x0001525C
		protected override Size MeasureOverride(Size availableSize)
		{
			Size desiredSize;
			if (this._logicalChild != null)
			{
				this._logicalChild.Measure(availableSize);
				desiredSize = this._logicalChild.DesiredSize;
				this._visualChild.Measure(desiredSize);
			}
			else
			{
				desiredSize = new Size(0.0, 0.0);
			}
			return desiredSize;
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x000170B1 File Offset: 0x000152B1
		protected override Size ArrangeOverride(Size finalSize)
		{
			if (this._logicalChild != null)
			{
				this._logicalChild.Arrange(new Rect(finalSize));
				this._visualChild.Arrange(new Rect(finalSize));
				this.Update3D();
			}
			return base.ArrangeOverride(finalSize);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000170EA File Offset: 0x000152EA
		protected override Visual GetVisualChild(int index)
		{
			return this._visualChild;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x000170F4 File Offset: 0x000152F4
		private FrameworkElement CreateVisualChild()
		{
			MeshGeometry3D geometry = new MeshGeometry3D
			{
				Positions = new Point3DCollection(Planerator.Mesh),
				TextureCoordinates = new PointCollection(Planerator.TexCoords),
				TriangleIndices = new Int32Collection(Planerator.Indices)
			};
			Material material = new DiffuseMaterial(Brushes.White);
			material.SetValue(Viewport2DVisual3D.IsVisualHostMaterialProperty, true);
			VisualBrush visualBrush = new VisualBrush(this._logicalChild);
			this.SetCachingForObject(visualBrush);
			Material backMaterial = new DiffuseMaterial(visualBrush);
			this._rotationTransform.Rotation = this._quaternionRotation;
			Transform3DGroup transform = new Transform3DGroup
			{
				Children = 
				{
					this._scaleTransform,
					this._rotationTransform
				}
			};
			GeometryModel3D value = new GeometryModel3D
			{
				Geometry = geometry,
				Transform = transform,
				BackMaterial = backMaterial
			};
			Model3DGroup content = new Model3DGroup
			{
				Children = 
				{
					new DirectionalLight(Colors.White, new Vector3D(0.0, 0.0, -1.0)),
					new DirectionalLight(Colors.White, new Vector3D(0.1, -0.1, 1.0)),
					value
				}
			};
			ModelVisual3D value2 = new ModelVisual3D
			{
				Content = content
			};
			if (this._frontModel != null)
			{
				this._frontModel.Visual = null;
			}
			this._frontModel = new Viewport2DVisual3D
			{
				Geometry = geometry,
				Visual = this._logicalChild,
				Material = material,
				Transform = transform
			};
			this.SetCachingForObject(this._frontModel);
			this._viewport3D = new Viewport3D
			{
				ClipToBounds = false,
				Children = 
				{
					value2,
					this._frontModel
				}
			};
			this.UpdateRotation();
			return this._viewport3D;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000172DA File Offset: 0x000154DA
		private void SetCachingForObject(DependencyObject d)
		{
			RenderOptions.SetCachingHint(d, CachingHint.Cache);
			RenderOptions.SetCacheInvalidationThresholdMinimum(d, 0.5);
			RenderOptions.SetCacheInvalidationThresholdMaximum(d, 2.0);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00017304 File Offset: 0x00015504
		private void UpdateRotation()
		{
			Quaternion left = new Quaternion(Planerator.XAxis, this.RotationX);
			Quaternion right = new Quaternion(Planerator.YAxis, this.RotationY);
			Quaternion right2 = new Quaternion(Planerator.ZAxis, this.RotationZ);
			this._quaternionRotation.Quaternion = left * right * right2;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00017360 File Offset: 0x00015560
		private void Update3D()
		{
			Rect descendantBounds = VisualTreeHelper.GetDescendantBounds(this._logicalChild);
			double width = descendantBounds.Width;
			double height = descendantBounds.Height;
			double num = this.FieldOfView * 0.017453292519943295;
			double z = width / Math.Tan(num / 2.0) / 2.0;
			this._viewport3D.Camera = new PerspectiveCamera(new Point3D(width / 2.0, height / 2.0, z), -Planerator.ZAxis, Planerator.YAxis, this.FieldOfView);
			this._scaleTransform.ScaleX = width;
			this._scaleTransform.ScaleY = height;
			this._rotationTransform.CenterX = width / 2.0;
			this._rotationTransform.CenterY = height / 2.0;
		}

		// Token: 0x04000247 RID: 583
		public static readonly DependencyProperty RotationXProperty = DependencyProperty.Register("RotationX", typeof(double), typeof(Planerator), new UIPropertyMetadata(0.0, delegate(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			((Planerator)d).UpdateRotation();
		}));

		// Token: 0x04000248 RID: 584
		public static readonly DependencyProperty RotationYProperty = DependencyProperty.Register("RotationY", typeof(double), typeof(Planerator), new UIPropertyMetadata(0.0, delegate(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			((Planerator)d).UpdateRotation();
		}));

		// Token: 0x04000249 RID: 585
		public static readonly DependencyProperty RotationZProperty = DependencyProperty.Register("RotationZ", typeof(double), typeof(Planerator), new UIPropertyMetadata(0.0, delegate(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			((Planerator)d).UpdateRotation();
		}));

		// Token: 0x0400024A RID: 586
		public static readonly DependencyProperty FieldOfViewProperty = DependencyProperty.Register("FieldOfView", typeof(double), typeof(Planerator), new UIPropertyMetadata(45.0, delegate(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			((Planerator)d).Update3D();
		}, (DependencyObject d, object val) => Math.Min(Math.Max((double)val, 0.5), 179.9)));

		// Token: 0x0400024B RID: 587
		private static readonly Point3D[] Mesh = new Point3D[]
		{
			new Point3D(0.0, 0.0, 0.0),
			new Point3D(0.0, 1.0, 0.0),
			new Point3D(1.0, 1.0, 0.0),
			new Point3D(1.0, 0.0, 0.0)
		};

		// Token: 0x0400024C RID: 588
		private static readonly Point[] TexCoords = new Point[]
		{
			new Point(0.0, 1.0),
			new Point(0.0, 0.0),
			new Point(1.0, 0.0),
			new Point(1.0, 1.0)
		};

		// Token: 0x0400024D RID: 589
		private static readonly int[] Indices = new int[]
		{
			0,
			2,
			1,
			0,
			3,
			2
		};

		// Token: 0x0400024E RID: 590
		private static readonly Vector3D XAxis = new Vector3D(1.0, 0.0, 0.0);

		// Token: 0x0400024F RID: 591
		private static readonly Vector3D YAxis = new Vector3D(0.0, 1.0, 0.0);

		// Token: 0x04000250 RID: 592
		private static readonly Vector3D ZAxis = new Vector3D(0.0, 0.0, 1.0);

		// Token: 0x04000251 RID: 593
		private readonly QuaternionRotation3D _quaternionRotation = new QuaternionRotation3D();

		// Token: 0x04000252 RID: 594
		private readonly RotateTransform3D _rotationTransform = new RotateTransform3D();

		// Token: 0x04000253 RID: 595
		private readonly ScaleTransform3D _scaleTransform = new ScaleTransform3D();

		// Token: 0x04000254 RID: 596
		private FrameworkElement _logicalChild;

		// Token: 0x04000255 RID: 597
		private FrameworkElement _originalChild;

		// Token: 0x04000256 RID: 598
		private Viewport3D _viewport3D;

		// Token: 0x04000257 RID: 599
		private FrameworkElement _visualChild;

		// Token: 0x04000258 RID: 600
		private Viewport2DVisual3D _frontModel;
	}
}
