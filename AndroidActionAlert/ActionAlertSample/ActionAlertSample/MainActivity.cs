using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Animation;
using ActionComponents;

namespace ActionAlertSample
{
	[Activity(Label = "ActionAlertSample", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		#region Private Constants
		private const int MaxAlerts = 22;
		private ACAlert _alert;
		#endregion

		#region Private Variables
		private TextView alertName;
		private Button plusButton, minusButton, alertButton;
		private int alertNum = 0;
		#endregion

		#region Override Methods
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Grab all required resources
			alertName = FindViewById<TextView>(Resource.Id.alertName);
			alertButton = FindViewById<Button>(Resource.Id.alertButton);
			plusButton = FindViewById<Button>(Resource.Id.plusButton);
			minusButton = FindViewById<Button>(Resource.Id.minusButton);

			// Display the currently selected alert
			SetAlertName();

			// Wire-up the minus button
			minusButton.Click += (sender, e) => {
				// Decrement index
				if (--alertNum < 0) alertNum = MaxAlerts;

				// Update name display
				SetAlertName();
			};

			// Wire-up the plus button
			plusButton.Click += (sender, e) => {
				// Increment index
				if (++alertNum > MaxAlerts) alertNum = 0;

				// Update name display
				SetAlertName();
			};

			// Wire-up the alert display button
			alertButton.Click += (sender, e) => {
				// Display the current alert type
				DisplayAlert();
			};
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Displays the name of the current alert type selected
		/// </summary>
		private void SetAlertName()
		{
			string[] titles = {"Default", "Title Only", "Description Only", "Default with Icon", "OK", @"OK & Image", "OK/Cancel", "Custom Buttons", "Activity Alert",
				"Activity Title Only", "Activity Desc Only", "Activity Cancel", "Medium Activity Alert", "Med Activity Cancel", "Progress Alert",
				"Progress Title", "Progress Desc", "Progress Icon", "Progress Cancel", "Progress Custom Btns", "iOS 7 Style", "Customized", "Custom Subview"};

			// Set the current name
			alertName.Text = titles[alertNum];
		}

		/// <summary>
		/// Displays the alert for the current alertNum
		/// </summary>
		private void DisplayAlert()
		{

			// Close any existing alert
			if (_alert != null)
			{
				_alert.Hide();
				_alert = null;
			}

			// Take action based on the current alert selected
			switch (alertNum)
			{
				case 0:
					ACAlert.ShowAlert(this, "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 1:
					ACAlert.ShowAlert(this, "ActionAlert", "");
					break;
				case 2:
					ACAlert.ShowAlert(this, "", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 3:
					ACAlert.ShowAlert(this, Resource.Drawable.ActionAlert_57, "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 4:
					ACAlert.ShowAlertOK(this, "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 5:
					ACAlert.ShowAlertOK(this, Resource.Drawable.ActionAlert_57, "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");
					break;
				case 6:
					_alert = ACAlert.ShowAlertOKCancel(this, "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.");

					//Respond to the OK button being tapped
					_alert.ButtonReleased += (button) => {
						if (button.title == "OK")
						{
							ACAlert.ShowAlert(this, ACAlertLocation.Top, "You tapped the OK button.", "");
						}
					};
					break;
				case 7:
					_alert = ACAlert.ShowAlert(this, "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.", "Cancel,Maybe,OK");

					//Respond to any button being tapped
					_alert.ButtonReleased += (button) => {
						_alert.Hide();
						ACAlert.ShowAlert(this, ACAlertLocation.Top, String.Format("You tapped the {0} button.", button.title), "");
					};
					break;
				case 8:
					_alert = ACAlert.ShowActivityAlert(this, "Activity Alert", "Displays a notification to the user that some long running process has started. This one is being displayed non-modal so the user can still interact with the app.", false);
					break;
				case 9:
					_alert = ACAlert.ShowActivityAlert(this, "Activity Alert", "", false);
					break;
				case 10:
					_alert = ACAlert.ShowActivityAlert(this, "", "Displays a notification to the user that some long running process has started. This alert has been set to be movable by the user.", false);

					//Adjust the alert so it can be moved by the user
					var layout = new RelativeLayout.LayoutParams(_alert.LayoutWidth, _alert.LayoutHeight);
					layout.LeftMargin = 20;
					layout.TopMargin = 20;
					_alert.LayoutParameters = layout;
					_alert.draggable = true;
					break;
				case 11:
					_alert = ACAlert.ShowActivityAlertCancel(this, "Activity Alert", "Displays a notification to the user that some long running process has started and allows the user to cancel the process.", true);
					break;
				case 12:
					_alert = ACAlert.ShowActivityAlertMedium(this, "Waiting...", false);
					break;
				case 13:
					_alert = ACAlert.ShowActivityAlertMediumCancel(this, "Waiting...", true);
					break;
				case 14:
					_alert = ACAlert.ShowProgressAlert(this, "Progress Alert", "Displays an Alert for a process with a known length and gives feedback to the user.", false);
					_alert.progressView.Progress = 50;
					break;
				case 15:
					_alert = ACAlert.ShowProgressAlert(this, "Waiting on Process...", "", false);
					_alert.progressView.Progress = 10;
					break;
				case 16:
					_alert = ACAlert.ShowProgressAlert(this, "", "Displays an Alert for a process with a known length and gives feedback to the user.", false);
					_alert.progressView.Progress = 80;
					break;
				case 17:
					_alert = ACAlert.ShowProgressAlert(this, Resource.Drawable.ActionAlert_57, "Progress Alert", "Displays an Alert for a process with a known length and gives feedback to the user.", false);
					_alert.progressView.Progress = 80;
					break;
				case 18:
					_alert = ACAlert.ShowProgressAlertCancel(this, "Progress Alert", "Displays an Alert for a process with a known length and allos the user to cancel the process.", false);
					_alert.progressView.Progress = 20;
					break;
				case 19:
					_alert = ACAlert.ShowProgressAlert(this, "Progress Alert", "Displays an Alert for a process with a known length and allos the user to cancel the process.", "Abort,Pause", true);
					_alert.progressView.Progress = 30;

					// Respond to any button being tapped
					_alert.ButtonReleased += (button) => {
						_alert.Hide();
					};
					break;
				case 20:
					_alert = ACAlert.ShowAlert(this, "ActionAlert", "A cross platform Alert, Dialog and Notification system for iOS and Android.", "Cancel,Maybe,OK");
					_alert.Flatten();

					// Respond to any button being tapped
					_alert.ButtonReleased += (button) => {
						_alert.Hide();
					};
					break;
				case 21:
					_alert = ACAlert.ShowAlert(this, Resource.Drawable.ActionAlert_57, "ActionAlert is Customizable", "You can 'square off' one or more of the corners and ajust all of the colors and styles by using properties of the alert.", "No,Yes");
					_alert.appearance.background = Color.Orange;
					_alert.buttonAppearance.background = Color.Orange;
					_alert.buttonAppearanceHighlighted.titleColor = Color.Orange;
					_alert.appearance.roundBottomLeftCorner = false;

					// Respond to any button being tapped
					_alert.ButtonReleased += (button) => {
						_alert.Hide();
					};
					break;
				case 22:
					// Create subview
					var lp = new RelativeLayout.LayoutParams(278, 50);
					var flp = new RelativeLayout.LayoutParams(278, 50);
					var rl = new RelativeLayout(this);
					var field1 = new EditText(this);

					// Initialize subview
					rl.LayoutParameters = lp;

					// Initialize field and add to subview
					flp.TopMargin = 0;
					flp.RightMargin = 0;
					field1.LayoutParameters = flp;
					field1.Text = "Default Value";
					rl.AddView(field1);

					// Create alert
					_alert = new ACAlert(this, ACAlertType.Subview, ACAlertLocation.Middle, "Custom Subview", rl, "Cancel,OK");
					_alert.Show();

					// Respond to any button being tapped
					_alert.ButtonReleased += (button) => {
						_alert.Hide();
					};
					break;
			}

		}
		#endregion
	}
}

