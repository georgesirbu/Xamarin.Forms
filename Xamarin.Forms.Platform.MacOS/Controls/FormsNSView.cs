﻿using System;
using AppKit;

namespace Xamarin.Forms.Platform.MacOS
{
	public class FormsNSView : NSView
	{
		public override void DrawRect(CoreGraphics.CGRect dirtyRect)
		{
			if (BackgroundColor != NSColor.Clear && BackgroundColor != null)
			{
				BackgroundColor.Set();
				NSGraphics.RectFill(this.Bounds);
			}

			base.DrawRect(dirtyRect);
		}

		public override bool IsFlipped
		{
			get
			{
				return _isFlipped;
			}
		}

		public NSColor BackgroundColor
		{
			get;
			set;
		}

		bool _isFlipped;

	}
}

