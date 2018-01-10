using System;
using UIKit;
using ActionComponents;
using CoreGraphics;

namespace ActionAlertSample
{
	public partial class ViewController : UIViewController
	{
		#region Private Variables
		private ACAlert _alert;
		#endregion

		#region Constructors
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		#endregion

		#region Override Methods
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Initialize Interface
			SetAlertTitle();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Sets the alert title.
		/// </summary>
		private void SetAlertTitle()
		{
			string[] titles = {"Default", "Title Only", "Description Only", "Default with Icon", "OK", @"OK & Image", "OK/Cancel", "Custom Buttons", "Activity Alert",
				"Activity Title Only", "Activity Desc Only", "Activity Cancel", "Medium Activity Alert", "Med Activity Cancel", "Progress Alert",
				"Progress Title", "Progress Desc", "Progress Icon", "Progress Cancel", "Progress Custom Btns", "iOS 7 Style", "Customized", "Custom Subview"};

			// Set new title
			AlertTypeLabel.Text = titles[(int)AlertSelection.Value];
		}

		/// <summary>
		/// Shows the alert.
		/// </summary>
		private void AlertUser()
		{

			// Close any existing alert
			if (_alert != null)
			{
				_alert.Hide();
				_alert = null;
			}

			// Take action based on the stepper value
			switch ((int)AlertSelection.Value)
			{
				case 0:
					ACAlert.ShowAlert("ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 1:
					ACAlert.ShowAlert("ActionAlert", "");
					break;
				case 2:
					ACAlert.ShowAlert("", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 3:
					ACAlert.ShowAlert(UIImage.FromBundle("ActionAlertIcon"), "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 4:
					ACAlert.ShowAlertOK("ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 5:
					ACAlert.ShowAlertOK(UIImage.FromBundle("ActionAlertIcon"), "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 6:
					_alert = ACAlert.ShowAlertOKCancel("ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");

					//Respond to the OK button being tapped
					_alert.ButtonReleased += (button) =>
					{
						if (button.title == "OK")
						{
							ACAlert.ShowAlert(ACAlertLocation.Top, "You tapped the OK button.", "");
						}
					};
					break;
				case 7:
					_alert = ACAlert.ShowAlert("ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.", "Cancel,Maybe,OK");

					//Respond to any button being tapped
					_alert.ButtonReleased += (button) =>
					{
						_alert.Hide();
						ACAlert.ShowAlert(ACAlertLocation.Top, String.Format("You tapped the {0} button.", button.title), "");
					};
					break;
				case 8:
					_alert = ACAlert.ShowActivityAlert("Activity Alert", "Displays a notification to the user that some long running process has started. This one is being displayed non-modal so the user can still interact with the app.", false);
					break;
				case 9:
					_alert = ACAlert.ShowActivityAlert("Activity Alert", "", false);
					break;
				case 10:
					_alert = ACAlert.ShowActivityAlert("", "Displays a notification to the user that some long running process has started. This alert has been set to be movable by the user.", false);
					_alert.draggable = true;
					break;
				case 11:
					_alert = ACAlert.ShowActivityAlertCancel("Activity Alert", "Displays a notification to the user that some long running process has started and allows the user to cancel the process.", true);
					break;
				case 12:
					_alert = ACAlert.ShowActivityAlertMedium("Waiting...", false);
					break;
				case 13:
					_alert = ACAlert.ShowActivityAlertMediumCancel("Waiting...", true);
					break;
				case 14:
					_alert = ACAlert.ShowProgressAlert("Progress Alert", "Displays an Alert for a process with a known length and gives feedback to the user.", false);
					_alert.progressView.Progress = 0.5f;
					break;
				case 15:
					_alert = ACAlert.ShowProgressAlert("Waiting on Process...", "", false);
					_alert.progressView.Progress = 0.1f;
					break;
				case 16:
					_alert = ACAlert.ShowProgressAlert("", "Displays an Alert for a process with a known length and gives feedback to the user.", false);
					_alert.progressView.Progress = 0.8f;
					break;
				case 17:
					_alert = ACAlert.ShowProgressAlert(UIImage.FromBundle("ActionAlertIcon"), "Progress Alert", "Displays an Alert for a process with a known length and gives feedback to the user.", false);
					_alert.progressView.Progress = 0.8f;
					break;
				case 18:
					_alert = ACAlert.ShowProgressAlertCancel("Progress Alert", "Displays an Alert for a process with a known length and allos the user to cancel the process.", false);
					_alert.progressView.Progress = 0.2f;
					break;
				case 19:
					_alert = ACAlert.ShowProgressAlert("Progress Alert", "Displays an Alert for a process with a known length and allos the user to cancel the process.", "Abort,Pause", true);
					_alert.progressView.Progress = 0.3f;

					//Respond to any button being tapped
					_alert.ButtonReleased += (button) =>
					{
						_alert.Hide();
					};
					break;
				case 20:
					_alert = ACAlert.ShowAlert("ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.", "Cancel,Maybe,OK");
					_alert.Flatten();

					//Respond to any button being tapped
					_alert.ButtonReleased += (button) =>
					{
						_alert.Hide();
					};
					break;
				case 21:
					_alert = ACAlert.ShowAlert(UIImage.FromBundle("ActionAlertIcon"), "ActionAlert is Customizable", "You can 'square off' one or more of the corners and ajust all of the colors and styles by using properties of the alert.", "No,Yes");
					_alert.appearance.background = UIColor.Orange;
					_alert.buttonAppearance.background = UIColor.Orange;
					_alert.buttonAppearanceHighlighted.titleColor = UIColor.Orange;
					_alert.appearance.roundBottomLeftCorner = false;

					// Respond to any button being tapped
					_alert.ButtonReleased += (button) =>
					{
						_alert.Hide();
					};
					break;
				case 22:
					// Build a custom view for this alert
					UITextField field1 = new UITextField(new CGRect(13, 41, 278, 29))
					{
						BorderStyle = UITextBorderStyle.RoundedRect,
						TextColor = UIColor.DarkGray,
						Font = UIFont.SystemFontOfSize(14f),
						Placeholder = "Name",
						Text = "DefaultValue",
						BackgroundColor = UIColor.White,
						AutocorrectionType = UITextAutocorrectionType.No,
						KeyboardType = UIKeyboardType.Default,
						ReturnKeyType = UIReturnKeyType.Done,
						ClearButtonMode = UITextFieldViewMode.WhileEditing,
						Tag = 0,
						Enabled = true
					};
					field1.ShouldReturn = delegate (UITextField field)
					{
						field.ResignFirstResponder();
						return true;
					};
					field1.ShouldEndEditing = delegate (UITextField field)
					{
						field.ResignFirstResponder();
						return true;
					};

					// Create the new alert and attach the new field
					_alert = new ACAlert(ACAlertType.Subview, ACAlertLocation.Middle, "Custom Subview", field1, "Cancel,OK");
					_alert.Show();

					// Respond to any button being tapped
					_alert.ButtonReleased += (button) =>
					{
						field1.ResignFirstResponder();
						_alert.Hide();
					};
					break;
			}
		}
		#endregion

		#region Custom Actions
		partial void AlertSelectionChanged(Foundation.NSObject sender) {

			// Change the alert title
			SetAlertTitle();
		}

		partial void ShowAlert(Foundation.NSObject sender) {
			// Display the given alert
			AlertUser();
		}
		#endregion
	}
}
