var PostBackRitalin = function(waitText, waitImage, monitoredUpdatePanels, waitTexts, waitImages, preload) {
  this._waitText = waitText;
  this._waitImage = waitImage;

  this._monitoredUpdatePanels = monitoredUpdatePanels;
  
  this._waitTexts = waitTexts;
  this._waitImages = waitImages;
  
  this._preload = preload;

  this._pageRequestManager = null;
  this._beginRequestHandler = null;
  this._endRequestHandler = null;
  
  this._oldText = null;
  this._oldImage = null;
  this._oldHref = null;
  
  this._initialize();
}

PostBackRitalin.prototype = {
  _isMonitoredRequest : function(panelID) {
    if (this._monitoredUpdatePanels == null)
      return true;
      
    for (i = 0; i < this._monitoredUpdatePanels.length; i++)
      if (panelID.match(this._monitoredUpdatePanels[i]) != null)
        return true;
        
    return false;
  },
  
  get_waitText : function(panelID) {
    if (this._waitTexts)
      for (var i in this._waitTexts)
        if (panelID.match(i) != null)
          return this._waitTexts[i];
    
    if (this._waitText != null)
      return this._waitText;
      
    return null;  
  },
   
  get_waitImage : function(panelID) {
    if (this._waitImages)
      for (var i in this._waitImages)
        if (panelID.match(i) != null)
          return this._waitImages[i];
    
    if (this._waitImage != null)
      return this._waitImage;
      
    return null;  
  },
           
  _beginRequest : function(sender, args) {
    var sendingPanel = sender._postBackSettings.panelID.split('|')[0];
    var element = args.get_postBackElement();

    if (this._isMonitoredRequest(sendingPanel))
    {
      if (element.type == 'submit')
      {
        element.disabled = true;
        element.blur();
        
        this._oldText = element.value;
        
        var waitText = this.get_waitText(sendingPanel);

        if (waitText != null)
          element.value = waitText;
      }
      else if (element.type == 'image')
      {
        element.disabled = true;
        element.blur();
        
        this._oldImage = element.src;
        
        var waitImage = this.get_waitImage(sendingPanel);
        
        if (waitImage != null)
          element.src = waitImage;
      }
      else if (element.tagName == 'A')
      {
        this._oldHref = element.href;
        element.href = '#';
      }
    }
  },
    
  _endRequest : function(sender, args) {
    var element = $get(sender._postBackSettings.sourceElement.id);
  
    // Check to make sure the item hasn't been removed during the postback.
    if (element != null && this._isMonitoredRequest(sender._postBackSettings.panelID))
    {
      element.disabled = false;
      
      // Handles regular submit buttons.
      if (element.type == 'submit')
      {
        element.value = this._oldText;
        this._oldText = null;
      }
      // Handles image buttons.
      else if (element.type == 'image')
      {
        element.src = this._oldImage;
        this._oldImage = null;
      }
      else if (element.tagName == 'A')
      {
        element.href = this._oldHref;
        this._oldHref = null;
      }
    }
  },

  _initialize : function() {
    this._pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();
    
    this._beginRequestHandler = Function.createDelegate(this, this._beginRequest);
    this._pageRequestManager.add_beginRequest(this._beginRequestHandler);
    
    this._endRequestHandler = Function.createDelegate(this, this._endRequest);
    this._pageRequestManager.add_endRequest(this._endRequestHandler);
    
    if (this._preload)
    {
      var image = new Image();
      
      for (var i in this._waitImages)
        image.src = this._waitImages[i];
    }
  }
};