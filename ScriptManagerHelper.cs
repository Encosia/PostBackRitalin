using System;

/// <summary>
/// Utility class to provide easy access to registration of script files and
/// startup scripts. Uses the Microsoft AJAX Script Manager through reflection if 
/// available or the Page.ClientScript object.
/// 
/// The ScriptManager instance is obtained through reflection and does not require
/// linking in the System.Web.Extensions assembly.
/// </summary>
internal class ScriptManagerHelper
{

  //Adapted from: http://forums.asp.net/thread/1466486.aspx
  private static object reflectionLock = new object();
  private static bool methodsInitialized;
  private static System.Reflection.MethodInfo registerClientScriptResourceMethod;
  private static System.Reflection.MethodInfo registerStartupScriptMethod;
  private static System.Reflection.PropertyInfo enableScriptLocalization;
  private static bool isMicrosoftAjaxAvailable = false;
  private static Type scriptManager;

  /// <summary>
  /// Initialize the access to the Script Manager and the associated methods
  /// for registering script resources and startup scripts.
  /// </summary>
  private static void InitializeHelper()
  {

    //Only initialize once.
    if (!methodsInitialized)
    {
      lock (reflectionLock)
      {
        //Create a reference to the ScriptManager object using reflection.
        scriptManager = Type.GetType("System.Web.UI.ScriptManager, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", false);

        //If successful creating the ScriptManager instance.
        if (scriptManager != null)
        {

          isMicrosoftAjaxAvailable = true;

          //Get an instance of the RegisterClientScriptResource method for invocation later.
          registerClientScriptResourceMethod = scriptManager.GetMethod(
           "RegisterClientScriptResource",
            new Type[] { typeof(System.Web.UI.Control), typeof(Type), typeof(System.String) }
          );

          //Get an instance of the RegisterStartupScript method for invocation later.
          registerStartupScriptMethod = scriptManager.GetMethod(
           "RegisterStartupScript",
            new Type[] { typeof(System.Web.UI.Control), typeof(Type), typeof(System.String), typeof(System.String), typeof(System.Boolean) }
          );

          //Get an instance of the RegisterStartupScript method for invocation later.
          enableScriptLocalization = scriptManager.GetProperty(
           "EnableScriptLocalization",
            new Type[] { typeof(System.Boolean) }
          );

          methodsInitialized = true;
        }

      }
    }
  }

  /// <summary>
  /// Registers the client script either through the ScriptManager or the Page.ClientScript.
  /// </summary>
  /// <param name="control">Control associated with the script.</param>
  /// <param name="type">Type of object.</param>
  /// <param name="resourceName">Name of the resource.</param>
  public static void RegisterClientScriptResource(System.Web.UI.Control control, Type type, string resourceName)
  {
    InitializeHelper();

    if (registerClientScriptResourceMethod != null)
    {
      try
      {
        registerClientScriptResourceMethod.Invoke(null, new Object[] { control, type, resourceName });
      }
      catch (Exception exc)
      {
        //Error handling here.
      }
    }
    else
    {
      try
      {
        control.Page.ClientScript.RegisterClientScriptResource(type, resourceName);
      }
      catch (Exception exc)
      {
        //Error handling here.
      }
    }
  }

  /// <summary>
  /// Registers a script to be executed
  /// </summary>
  /// <param name="control">Control associated with the script.</param>
  /// <param name="type">Type of object.</param>
  /// <param name="key">key identifier for the startup script.</param>
  /// <param name="script">Script literal to be executed.</param>
  /// <param name="addScriptTags">T/F whether to add Script tags for the script literal.</param>
  public static void RegisterStartupScript(System.Web.UI.Control control, Type type, string key, string script, bool addScriptTags)
  {
    InitializeHelper();
    if (registerStartupScriptMethod != null)
    {
      try
      {
        registerStartupScriptMethod.Invoke(null, new Object[] { control, type, key, script, addScriptTags });
      }
      catch (Exception exc)
      {
        //Error handling here.
      }
    }
    else
    {
      try
      {

        control.Page.ClientScript.RegisterStartupScript(type, key, script, addScriptTags);
      }
      catch (Exception exc)
      {
        //Error handling here.
      }
    }
  }

  /// <summary>
  /// Indicates whether or not Microsoft AJAX is available.
  /// </summary>
  /// <returns>T/F</returns>
  public static bool IsMicrosoftAjaxAvailable
  {
    get
    {
      InitializeHelper();
      return isMicrosoftAjaxAvailable;
    }
  }

  /// <summary>
  /// Whether or not to enable script localization for the control.
  /// </summary>
  /// <value>T/F</value>
  /// <returns>T/F</returns>
  public static bool EnableScriptLocalization
  {
    get
    {
      InitializeHelper();
      return Convert.ToBoolean(enableScriptLocalization.GetValue(null, null));
    }
    set
    {
      enableScriptLocalization.SetValue(null, value, null);
    }
  }
}