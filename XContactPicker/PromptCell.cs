﻿using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace XContactPicker
{
	public class PromptCell: UICollectionViewCell
	{
		private string text;
		public string Text 
		{ 
			get { return text; }
			set 
			{ 
				text = value; 
				if (label != null) {
					label.Text = value;
				}
			}
		}

		public UIEdgeInsets Insets { get; set; }

		private UILabel label;

		public PromptCell ()
		{
			Setup ();
		}

		public PromptCell (RectangleF frame)
			: base (frame)
		{
			Setup ();
		}

		public PromptCell (IntPtr handle)
			: base (handle)
		{
			Setup ();
		}

		public float WidthForText (string text)
		{
			var rect = new NSString (text).GetBoundingRect (new SizeF (float.MaxValue, float.MaxValue), 
												NSStringDrawingOptions.UsesLineFragmentOrigin,
												new UIStringAttributes { Font = label.Font }, 
												null);
			return rect.Width;
		}

		private void Setup ()
		{
			Insets = new UIEdgeInsets (0, 5, 0, 5);
#if DEBUG_BORDERS
			Layer.BorderWidth = 1f;
			Layer.BorderColor = UIColor.Purple.CGColor;
#endif
			label = new UILabel () 
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.Black,

			};

			AddSubview (label);

			AddConstraints (NSLayoutConstraint.FromVisualFormat ("H:|[label]|", 
								(NSLayoutFormatOptions) 0, "label", label));
			AddConstraints (NSLayoutConstraint.FromVisualFormat ("V:|[label]|", 
								(NSLayoutFormatOptions) 0, "label", label));
		}
	}
}

