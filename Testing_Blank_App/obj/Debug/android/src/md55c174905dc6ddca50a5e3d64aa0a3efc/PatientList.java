package md55c174905dc6ddca50a5e3d64aa0a3efc;


public class PatientList
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Testing_Blank_App.PatientList, Testing_Blank_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PatientList.class, __md_methods);
	}


	public PatientList () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PatientList.class)
			mono.android.TypeManager.Activate ("Testing_Blank_App.PatientList, Testing_Blank_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
