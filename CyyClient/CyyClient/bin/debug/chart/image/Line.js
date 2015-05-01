var FFLine = function(lColor,lWidth){
    this.color = lColor;
    this.width = lWidth;
}
FFLine.prototype = {
    DLine:function(CurrnetTd,PrevTd,tw,plw){
        var tid = $("#"+CurrnetTd);
        var fid = $("#"+PrevTd);
	    var f_width = fid.outerWidth();
	    var f_height = fid.outerHeight();
	    var f_offset = fid.offset();
	    var f_top = f_offset.top;
	    var f_left = f_offset.left;
	    var t_offset = tid.offset();
	    var t_top = t_offset.top;
	    var t_left = t_offset.left;
	    var cvs_left = Math.min(f_left,t_left);
	    var cvs_top = Math.min(f_top,t_top);
	    var cvs = document.createElement("canvas");
	    cvs.width = Math.abs(f_left - t_left) < this.width ? this.width : Math.abs(f_left - t_left);
	    cvs.height = Math.abs(f_top - t_top);
	    cvs.style.top = cvs_top + parseInt(f_height / 2) + "px";
	    cvs.style.left = cvs_left + parseInt(f_width / 2) + "px";
	    cvs.style.position = "absolute";
	    var cxt = cvs.getContext("2d");
	    cxt.save();
	    cxt.strokeStyle = this.color;
	    cxt.lineWidth = this.width;
	    cxt.beginPath();
	    cxt.moveTo(f_left - cvs_left,f_top - cvs_top);
	    cxt.lineTo(t_left - cvs_left,t_top - cvs_top);
	    cxt.closePath();
	    cxt.stroke();
	    cxt.restore();
	    $("body").append(cvs);
    }
}

var IELine = function(lColor,lWidth){
    this.color = lColor;
    this.width = lWidth;
}
IELine.prototype = {
    DLine:function(CurrnetTd,PrevTd,tw,plw){
        var tid=$("#"+CurrnetTd);
        var fid=$("#"+PrevTd);
        var a_array = PrevTd.split("_");
        var b_array = CurrnetTd.split("_");
	    var coordinate = (parseInt(b_array[1]) - parseInt(a_array[1])) * (tw+1) - plw;
	    var newLine = document.createElement("<vle:line></vle:line>");
	    newLine.from = -plw + ",7";
	    newLine.to = coordinate + ",32";
	    newLine.StrokeColor = this.color;
	    newLine.StrokeWeight = this.width;
	    newLine.style.cssText = "position:absolute;";
	    fid.append(newLine);
    }
}

var DrawLine = function(coords,tw,plw){
    var crd = coords.split("|");
    var tpwidth = tw.split("|");
    var tppl = plw.split("|");
    var len = crd.length;
    for(var i=0;i<len;i++)
    {
        var tp = crd[i];
        var lwidth = parseInt(tpwidth[i]);
        var lpw = parseInt(tppl[i]);
        if(len>1)
        {
            if(i==len-1)
            {DrawEverLine(tp,lwidth,lpw);}
            else
            { window.setTimeout("DrawEverLine('"+tp+"',"+lwidth+","+lpw+")",i*40);}
        }
        else
        {DrawEverLine(tp,lwidth,lpw);}
    }
}

var DrawEverLine=function(lids,lwth,lpw){
    var line;
    var wth = lwth;
    var pw = lpw;
    if($.browser.msie)
    {
        var version = parseFloat($.browser.version);
        if(version>=9)
        {line = new FFLine("#ff9999",2);}
        else
        {line = new IELine("#ff9999",2);}
    }
    else
    {line = new FFLine("#ff9999",2);}
    var tp = lids.split(",");
    for(var j=tp.length-1;j>0;j--)
    {
        line.DLine(tp[j],tp[j-1],wth,pw);
    }
}