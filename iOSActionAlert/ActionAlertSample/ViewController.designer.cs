// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ActionAlertSample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIStepper AlertSelection { get; set; }

		[Outlet]
		UIKit.UILabel AlertTypeLabel { get; set; }

		[Action ("AlertSelectionChanged:")]
		partial void AlertSelectionChanged (Foundation.NSObject sender);

		[Action ("ShowAlert:")]
		partial void ShowAlert (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AlertTypeLabel != null) {
				AlertTypeLabel.Dispose ();
				AlertTypeLabel = null;
			}

			if (AlertSelection != null) {
				AlertSelection.Dispose ();
				AlertSelection = null;
			}
		}
	}
}
