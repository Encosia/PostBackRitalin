/// <reference name="MicrosoftAjax.js" />
function PBR_ApplicationInit() 
{
  Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(PBR_BeginRequest);
  Sys.WebForms.PageRequestManager.getInstance().add_endRequest(PBR_EndRequest);
  
  var PBR_oldText;
  var PBR_oldImage;
}

function PBR_BeginRequest(sender, args)
{
  var sendingPanel = sender._postBackSettings.panelID.split('|')[0];

  if (PBR_IsMonitoredRequest(sendingPanel))
  {
    if (args.get_postBackElement().type == 'submit')
    {
      args.get_postBackElement().disabled = true;
      args.get_postBackElement().blur();
      PBR_oldText = args.get_postBackElement().value;

      if (PBR_GetWaitText(sendingPanel) != null)
        args.get_postBackElement().value = PBR_GetWaitText(sendingPanel);
    }
    else if (args.get_postBackElement().type == 'image')
    {
      args.get_postBackElement().disabled = true;
      args.get_postBackElement().blur();
      PBR_oldImage = args.get_postBackElement().src;
      
      if (PBR_GetWaitImage(sendingPanel) != null)
        args.get_postBackElement().src = PBR_GetWaitImage(sendingPanel);
    }
  }
}

function PBR_EndRequest(sender, args)
{
  // Check to make sure the item hasn't been removed during the postback.
  if ($get(sender._postBackSettings.sourceElement.id) != null && PBR_IsMonitoredRequest(sender._postBackSettings.panelID))
  {
    $get(sender._postBackSettings.sourceElement.id).disabled = false;
    
    // Handles regular submit buttons.
    if (sender._postBackSettings.sourceElement.type == 'submit')
      $get(sender._postBackSettings.sourceElement.id).value = PBR_oldText;
      
    // Handles image buttons.
    if (sender._postBackSettings.sourceElement.type == 'image')
      $get(sender._postBackSettings.sourceElement.id).src = PBR_oldImage;
  }
}

function PBR_IsMonitoredRequest(panelID)
{
  if (typeof(PBR_MonitoredUpdatePanels) == 'undefined')
    return true;
    
  for (i = 0; i < PBR_MonitoredUpdatePanels.length; i++)
    if (panelID.match(PBR_MonitoredUpdatePanels[i]) != null)
      return true;
      
  return false;
}

function PBR_GetWaitImage(panelID)
{
  for (i in PBR_WaitImages)
    if (panelID.match(i) != null)
      return PBR_WaitImages[i];
  
  if (typeof(PBR_WaitImage) != 'undefined')
    return PBR_WaitImage;
  else
    return null;
}

function PBR_GetWaitText(panelID)
{
  for (i in PBR_WaitTexts)
    if (panelID.match(i) != null)
      return PBR_WaitTexts[i];
  
  if (typeof(PBR_WaitText) != 'undefined')
    return PBR_WaitText;
  else
    return null;
}