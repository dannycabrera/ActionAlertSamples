package md5ae7111596668f12294b321a85bf370d9;


public class ACTableViewDataSource
	extends android.widget.BaseAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemId:(I)J:GetGetItemId_IHandler\n" +
			"n_isEmpty:()Z:GetIsEmptyHandler\n" +
			"n_getItem:(I)Ljava/lang/Object;:GetGetItem_IHandler\n" +
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"";
		mono.android.Runtime.register ("ActionComponents.ACTableViewDataSource, ActionComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ACTableViewDataSource.class, __md_methods);
	}


	public ACTableViewDataSource ()
	{
		super ();
		if (getClass () == ACTableViewDataSource.class)
			mono.android.TypeManager.Activate ("ActionComponents.ACTableViewDataSource, ActionComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public ACTableViewDataSource (android.app.Activity p0)
	{
		super ();
		if (getClass () == ACTableViewDataSource.class)
			mono.android.TypeManager.Activate ("ActionComponents.ACTableViewDataSource, ActionComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.App.Activity, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	public ACTableViewDataSource (md5ae7111596668f12294b321a85bf370d9.ACTableViewController p0)
	{
		super ();
		if (getClass () == ACTableViewDataSource.class)
			mono.android.TypeManager.Activate ("ActionComponents.ACTableViewDataSource, ActionComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "ActionComponents.ACTableViewController, ActionComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	public ACTableViewDataSource (android.app.Activity p0, md5ae7111596668f12294b321a85bf370d9.ACTableViewController p1)
	{
		super ();
		if (getClass () == ACTableViewDataSource.class)
			mono.android.TypeManager.Activate ("ActionComponents.ACTableViewDataSource, ActionComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.App.Activity, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:ActionComponents.ACTableViewController, ActionComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}


	public long getItemId (int p0)
	{
		return n_getItemId (p0);
	}

	private native long n_getItemId (int p0);


	public boolean isEmpty ()
	{
		return n_isEmpty ();
	}

	private native boolean n_isEmpty ();


	public java.lang.Object getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native java.lang.Object n_getItem (int p0);


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
