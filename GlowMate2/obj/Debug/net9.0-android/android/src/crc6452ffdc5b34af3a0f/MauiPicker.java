package crc6452ffdc5b34af3a0f;


public class MauiPicker
	extends crc6452ffdc5b34af3a0f.MauiPickerBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.MauiPicker, Microsoft.Maui", MauiPicker.class, __md_methods);
	}

	public MauiPicker (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MauiPicker.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiPicker, Microsoft.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public MauiPicker (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MauiPicker.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiPicker, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public MauiPicker (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MauiPicker.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiPicker, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

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
