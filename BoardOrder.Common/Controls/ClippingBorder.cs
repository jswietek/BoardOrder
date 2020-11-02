using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BoardOrder.Common.Controls {
	public class ClippingBorder : Border {

		private RectangleGeometry clipRect = new RectangleGeometry();
		private object oldClip;

		static ClippingBorder() {
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ClippingBorder), new FrameworkPropertyMetadata(typeof(ClippingBorder)));
		}

		public override UIElement Child {
			get {
				return base.Child;
			}
			set {
				if (this.Child != value) {
					if (this.Child != null) {
						this.Child.SetValue(UIElement.ClipProperty, this.oldClip);
					}

					if (value != null) {
						this.oldClip = value.ReadLocalValue(UIElement.ClipProperty);
					}
					else {
						// If we dont set it to null we could leak a Geometry object
						this.oldClip = null;
					}

					base.Child = value;
				}
			}
		}

		protected virtual void OnApplyChildClip() {
			UIElement child = this.Child;
			if (child != null) {
				this.clipRect.RadiusX = this.clipRect.RadiusY = Math.Max(0.0, this.CornerRadius.TopLeft - (this.BorderThickness.Left * 0.5));
				this.clipRect.Rect = new Rect(Child.RenderSize);
				child.Clip = clipRect;
			}
		}

		protected override void OnRender(DrawingContext dc) {
			OnApplyChildClip();
			base.OnRender(dc);
		}
	}
}
