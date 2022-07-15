using System;

public delegate Object NonGenericDelegate(String arg);

public delegate T GenDelegateCo<out T>();
public delegate void GenDelegateContra<in T>(T arg);


class DelegateVariance {

	static String AORS(Object arg) { return null; }

	public static void Main() {
		NonGenericDelegate nGenDel = AORS;

		GenDelegateCo<String> genDelCoStr = () => null;
		GenDelegateCo<Object> genDelCoObj = genDelCoStr;

		GenDelegateContra<Object> genDelContraObj = (arg) => { };
		GenDelegateContra<String> genDelContraStr = genDelContraObj;
	}
}