// MySettings.hasLoggedIn() function patch
// Add bool field "IsStarted" = false; into class.

if (!IsStarted)
{
	System.Reflection.Assembly A = System.Reflection.Assembly.LoadFrom(System.Windows.Forms.Application.StartupPath + @"\BotDLL.dll");
	Type ClassType = A.GetType("BotDLL.Main", true);
	object Obj = Activator.CreateInstance(ClassType);
	System.Reflection.MethodInfo MI = ClassType.GetMethod("Inject");
	MI.Invoke(Obj, null);
	IsStarted = true;
}
return (this.HasLoggedIn || (this.Username.Length > 0));