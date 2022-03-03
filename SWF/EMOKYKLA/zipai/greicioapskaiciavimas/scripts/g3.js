g3 = {};

g3.initializeObjects = function(objects) {
	for (var i = 0; i < objects.length; i++) {
		nodes = jQuery(objects[i][0]);
		if (nodes.length > 0) {
			for (var ii = 0; ii < nodes.length; ii++) {
				eval("new " + objects[i][1] + "(jQuery(nodes[ii]))");
			}
		}
	}
}


g3.initialize = function() {
	g3.initializeObjects([
		["*[data-top-bar]", "g3.topBar"],
		["*[data-matrix]", "g3.matrix"],
		["*[data-matrix-map]", "g3.matrixMap"],
		["*[data-message]", "g3.message"],
		["*[data-slider=container]", "g3.slider"],
		["*[data-dropdown-child]", "g3.dropdownParent"],
                ["*[data-scrollTo]", "g3.scrollToElement"]
	]);
	nodes = jQuery('*[data-map-highlight]');
	if (nodes.length > 0) {
		nodes.maphilight({fill: true, fillColor: 'FFEC79', fillOpacity: 1, stroke: false});
	}
	jQuery("*[data-dropdown-child]").trigger("change");
}
jQuery(document).ready(g3.initialize);


g3.scrollToElement = function(node) {
jQuery('html, body').animate({
        scrollTop: jQuery(node).offset().top
    }, 500);
}

g3.topBar = function(node) {	
	this.node = node;	
	this.width = this.node.width();
	this.nodeHandles = this.node.children("a");	
	this.nodeHandles.mouseover(jQuery.proxy(this.over, this));
	this.node.mouseout(jQuery.proxy(this.out, this));
	this.margin = 2;
	this.paddings = parseInt(jQuery(this.nodeHandles.get(0)).css("paddingLeft")) * 2;
	this.widthTab = Math.floor(this.width/ (this.nodeHandles.length + 1)) - this.paddings;
	this.widthTabActive = this.widthTab * 2;
	this.nodeDefaultActive = this.nodeHandles.filter(".active-tab");
	this.reset();	
}

g3.topBar.prototype.reset = function(animate) {
	var x = 0;
	for (var i = 0; i < this.nodeHandles.length; i++) {
		var node = jQuery(this.nodeHandles[i]);
		var targetWidth = this.widthTab;
		if (node.hasClass("active-tab")) {					
			targetWidth = this.widthTabActive;
		}
		if (animate) {
			node.animate({left : x, width : targetWidth}, {queue : false, duration : 1000});
		} else {
			node.css("left", x + "px");
			node.width(targetWidth);
		}
		var nodeNext = i < this.nodeHandles.length - 1 ? jQuery(this.nodeHandles[i + 1]) : null;
		x += targetWidth + this.paddings + this.margin + (nodeNext !== null && nodeNext.hasClass("active-tab") ? -1 : 0);		
	}
}

g3.topBar.prototype.over = function(event) {
	var node = jQuery(event.target);
	if (node.get(0).nodeName !== "A") {
		node = node.parent();
	}
	this.nodeHandles.removeClass("active-tab");
	node.addClass("active-tab");
	this.reset(true);
}

g3.topBar.prototype.out = function() {
	this.nodeHandles.removeClass("active-tab");
	this.nodeDefaultActive.addClass("active-tab");
	this.reset(true);
}

g3.matrix = function(node) {
	this.node = node;
	this.nodeTable = this.node.find("*[data-matrix-table]");
	this.nodesTr = this.nodeTable.find("tr");
	this.nodesTd = this.nodeTable.find("td");
	this.nodesTd.mouseenter(jQuery.proxy(this.over, this));	
	this.node.find("*[data-matrix-table-container]").mouseleave(jQuery.proxy(this.out, this));
	this.nodePopup = this.node.find("*[data-matrix-popup]");
	this.data = {};
	this.nodeActive = null;
	this.node.find("*[data-matrix-handle]").click(jQuery.proxy(this.toggle, this));
	this.nodeContainerContent = this.node.find("*[data-matrix-container-content]");
	this.nodeContainerContentHeight = this.nodeContainerContent.height();
	this.height = this.node.height();
	this.cookie = "__matrix__";
	if (this.node.find("*[data-matrix-handle=show]").length > 0 && getCookie(this.cookie) === "1") {
		this.hidden(null);
	}
	var nodes = this.node.find("*[data-matric-redirect]");
	nodes.css("cursor", "pointer");
	nodes.filter("*[data-matric-redirect]").click(jQuery.proxy(this.clicked, this));
}

g3.matrix.prototype.clicked = function(event) {
	var node = jQuery(event.target);
	if (node.get(0).nodeName !== "TD") {
		node = jQuery(node.parents("TD").get(0));
	}	
	document.location = node.attr("data-matric-redirect");
}

g3.matrix.prototype.over = function(event) {
	var node = jQuery(event.target);	
	if (node.get(0).nodeName !== "TD") {
		if (!node.getParents) {
			return false;
		}
		node = jQuery(node.getParents("td")[0]);
	}
	this.nodesTd.removeClass("active-td");
	this.nodesTd.removeClass("selected-td");
	var valid = false;
	if (!node.parent().hasClass("small-header")) {		
		var column = node.attr("data-matrix-column");
		if (column) {			
			node.addClass("selected-td");
			node.parent().children().addClass("active-td");
			node.parent().children("*[rowspan]").removeClass("active-td");
			this.node.find("td[data-matrix-column=" + column + "]").addClass("active-td");
			this.setPopupVisible(true, node);
			this.nodePopup.css("left", Math.min(node.position().left + 10, this.nodeTable.width() - 310));
			this.nodePopup.css(
				"top", 
					node.position().top + 
						(this.nodePopup.attr("data-matrix-top") ? parseInt(this.nodePopup.attr("data-matrix-top")) : 50)
			);
			valid = true;
		}		
	}
	if (!valid) {
		this.out();
	}
}

g3.matrix.prototype.out = function() {
	this.nodesTd.removeClass("active-td");
	this.nodesTd.removeClass("selected-td");
	this.setPopupVisible(false);
}

g3.matrix.prototype.setPopupVisible = function(visible, node) {
	if (visible) {
		this.nodeActive = node;
		this.loadPopupData();
		this.nodePopup.show();
	} else {
		this.nodeActive = null;
		this.loadPopupData();
		this.nodePopup.hide();
	}
}

g3.matrix.prototype.loadPopupData = function() {
	var content = "<br />";
	if (this.nodeActive) {
		var uri = this.nodeActive.attr("data-matrix-uri");
		if (this.data[uri]) {
			content = this.data[uri];
		} else {
			if (this.data[uri] === undefined) {
				this.data[uri] = false;
				var handler = {uri : uri, parent : this};
				handler.loaded = function(response) {
					this.parent.loadedPopupData(uri, response);
				}
				jQuery.get(uri, jQuery.proxy(handler.loaded, handler));
			}
			content = "Kraunasi...";
		}
	}
	this.nodePopup.find("*[data-matrix-content]").html(content);
}

g3.matrix.prototype.loadedPopupData = function(uri, response) {
	this.data[uri] = response;
	this.loadPopupData();
}

g3.matrix.prototype.toggle = function(event) {
	var hidden = this.node.hasClass("grid-hidden");
	if (hidden) {
		this.node.removeClass("grid-hidden");
		this.nodeContainerContent.animate(
			{height : this.nodeContainerContentHeight}, 
			{duration : 1000, complete : jQuery.proxy(this.shown, this)}
		);
		this.node.animate({height : this.height}, {duration : 1000});
	} else {
		this.nodeContainerContent.css({overflow : "hidden"});
		this.nodeContainerContent.animate(
			{height : 0}, {duration : 1000, complete : jQuery.proxy(this.hidden, this)}
		);
		this.node.animate({height : 31}, {duration : 1000});
	}
}

g3.matrix.prototype.shown = function(event) {
	this.nodeContainerContent.css({overflow : "visible"});
	this.node.css("height", "auto");
	setCookie(this.cookie, "0");
}

g3.matrix.prototype.hidden = function(event) {
	this.node.css("height", "auto");
	this.node.addClass("grid-hidden");
	this.nodeContainerContent.css({overflow : "hidden", height : 0});
	setCookie(this.cookie, "1");
}

g3.matrixMap = function(node) {
	this.node = node;	
	this.nodePopup = this.node.find("*[data-matrix-map=popup]");
	this.nodeActive = null;	
	this.data = {};
	this.node.find("area").mouseenter(jQuery.proxy(this.over, this));
	this.node.mouseleave(jQuery.proxy(this.out, this));
	this.nodeHiglighted = null;
	this.reset();
}

g3.matrixMap.prototype.over = function(event) {
	this.nodeActive = jQuery(event.target);
	if (this.nodeActive.attr("data-matrix-map-uri")) {
		
		data = this.nodeActive.data('maphilight') || {};
		data.alwaysOn = true;
		this.nodeActive.data('maphilight', data).trigger('alwaysOn.maphilight');
		
		if (this.nodeHiglighted && this.nodeHiglighted.attr("data-matrix-map-uri")) {
			data = this.nodeHiglighted.data('maphilight') || {};
			data.alwaysOn = false;
			this.nodeHiglighted.data('maphilight', data).trigger('alwaysOn.maphilight');
		}		
		this.nodeHiglighted = this.nodeActive;
		
		this.loadPopupData();
		this.nodePopup.show();
	}
	this.reset();
}

g3.matrixMap.prototype.out = function(event) {
	if (this.nodeActive !== null) {
		if (this.nodeHiglighted != null) {
			data = this.nodeHiglighted.data('maphilight') || {};
			data.alwaysOn = false;
			this.nodeHiglighted.data('maphilight', data).trigger('alwaysOn.maphilight');
			this.nodeHiglighted = null;
		}
		this.nodeActive = null;
		this.loadPopupData();
		this.nodePopup.hide();
	}
}

g3.matrixMap.prototype.loadPopupData = function() {
	var content = "";
	if (this.nodeActive) {
		var uri = this.nodeActive.attr("data-matrix-map-uri");
		if (this.data[uri]) {
			content = this.data[uri];
		} else {
			if (this.data[uri] === undefined) {
				this.data[uri] = false;
				var handler = {uri : uri, parent : this};
				handler.loaded = function(response) {
					this.parent.loadedPopupData(uri, response);
				}
				jQuery.get(uri, jQuery.proxy(handler.loaded, handler));
			}
			content = "<li><p>Kraunasi...</p></li>";
		}
	}
	this.nodePopup.html(content);
}

g3.matrixMap.prototype.loadedPopupData = function(uri, response) {
	this.data[uri] = response;
	this.loadPopupData();
}

g3.matrixMap.prototype.reset = function() {
	var node = this.node.find("*[data-matrix-active=1]");
	if (node.length > 0) {
		data = node.data('maphilight') || {};
		data.alwaysOn = true;
		node.data('maphilight', data).trigger('alwaysOn.maphilight');
	}
}

g3.message = function(node) {
	this.node = node;
	this.node.find(".close").click(jQuery.proxy(this.close, this));
}

g3.message.prototype.close = function() {
	var cookie = getCookie("messages");
	if (cookie === null) {
		cookie = "";
	}
	setCookie("message", cookie + ";" + this.node.attr("data-message"), 360);
	this.node.remove();
}

g3.slider = function(node) {
	this.node = node;
	this.id = this.node.attr("data-slider-id");
	var nodeContainer = this.node.find("*[data-slider=content]");
	var nodes = nodeContainer.children();
	var width = 0;	
	for (var i = 0; i < nodes.length; i++) {
		width += jQuery(nodes[i]).outerWidth(true);
	}
	nodeContainer.width(width);
	this.node.find("*[data-slider=bar]").mCustomScrollbar({
		set_height : this.node.width() > width ? 96 : 130, horizontalScroll : true,
		callbacks : {onScroll : jQuery.proxy(this.scrolled, this)}
	});
	var parts = String(getCookie("scrollPosition")).split(";");
	var position = null;
	for (i = 0; i < parts.length; i++) {
		var parts2 = parts[i].split(":");
		if (parts2[0] == this.id) {
			position = parts2[1];
		}
	}
	this.nodeSliderContainer = this.node.find("*[data-slider=content]").parent();
	if (position) {		
		this.nodeSliderContainer.css("left", position);
		this.node.find("*[data-slider=bar]").mCustomScrollbar("update");	
	}
}

g3.slider.prototype.scrolled = function(event) {
	var parts = String(getCookie("scrollPosition")).split(";");
	var result = new Array();
	for (i = 0; i < parts.length; i++) {
		if (parts[i].split(":")[0] != this.id) {
			result.push(parts[i]);
		}
	}
	result.push(this.id + ":" + this.nodeSliderContainer.css("left"));
	setCookie("scrollPosition", result.join(";"));
}

g3.placeholder = function(node) {
	this.node = node;
	this.node.focus(jQuery.proxy(this.focus, this));
	this.node.blur(jQuery.proxy(this.blur, this));
	this.node.parents('form').submit(jQuery.proxy(this.submitted, this));
	this.blur();
}

g3.placeholder.prototype.focus = function() {
	if (this.node.val() == this.node.attr('placeholder')) {
		this.node.val('');
		this.node.removeClass('place-holder');
	}
}

g3.placeholder.prototype.blur = function() {
	if (this.node.val() == '' || this.node.val() == this.node.attr('placeholder')) {
		this.node.addClass('place-holder');
		this.node.val(this.node.attr('placeholder'));
	}
}

g3.placeholder.prototype.submitted = function() {
	if (this.node.val() == this.node.attr('placeholder')) {
		this.node.val('');
	}
}

g3.dropdownParent = function(node) {
	this.node = jQuery(node);
	this.nodesTarget = jQuery(this.node.attr("data-dropdown-child"));
	this.node.change(jQuery.proxy(this.changed, this));
};

g3.dropdownParent.prototype.prepareUri = function(uri) {
	return uri.split("[subject]").join(jQuery("#mo_subject").val())
		.split("[class]").join(jQuery("#for_classes").val())+ this.node.val();
}

g3.dropdownParent.prototype.changed = function(event) {
	this.nodesTarget.attr("disabled", "disabled");
	this.node.attr("disabled", "disabled");
	var uris = this.node.attr("data-dropdown-child-uri").split(";;");
	for (var i = 0; i < uris.length ; i++) {
		listener = {parent : this, target : jQuery(this.nodesTarget[i])};
		listener.complete = function(response) {						
			var value = this.target.val();
			this.target.html(response);
			this.target.val(value);
			this.target.removeAttr("disabled");
			this.parent.checkIfLoaded();
		};
		jQuery.get(this.prepareUri(uris[i]), jQuery.proxy(listener.complete, listener));
	}
};

g3.dropdownParent.prototype.checkIfLoaded = function() {
	if (this.nodesTarget.filter("*[disabled]").length === 0) {
		this.node.removeAttr("disabled");
		this.nodesTarget.trigger("change");
	}
};