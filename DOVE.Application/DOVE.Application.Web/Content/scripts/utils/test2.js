﻿<script>(function(a,b){a.fn.lrLayout=function(h){var e={blocks:[{target:".lr-layout-left",type:"right",size:203}]};a.extend(e,h||{});var c=a(this);if(c.length<=0){return false}c[0]._lrLayout={dfop:e};e.id="lrlayout"+new Date().getTime();for(var f=0,g=e.blocks.length;f<g;f++){var d=e.blocks[f];c.children(d.target).append('<div class="lr-layout-move lr-layout-move-'+d.type+' " path="'+f+'"  ></div>')}c.on("mousedown",function(m){var n=m.target||m.srcElement;var i=a(n);var j=a(this);var l=j[0]._lrLayout.dfop;if(i.hasClass("lr-layout-move")){var k=i.attr("path");l._currentBlock=l.blocks[k];l._ismove=true;l._pageX=m.pageX}});c.mousemove(function(l){var j=a(this);var k=j[0]._lrLayout.dfop;if(!!k._ismove){var i=j.children(k._currentBlock.target);i.css("width",k._currentBlock.size+(l.pageX-k._pageX));j.css("padding-left",k._currentBlock.size+(l.pageX-k._pageX))}});c.on("click",function(k){var i=a(this);var j=i[0]._lrLayout.dfop;if(!!j._ismove){j._currentBlock.size+=(k.pageX-j._pageX);j._ismove=false}})}})(jQuery,top.learun);(function(a,b){a.lrtree={getItem:function(f,d){var c=f.split(".");var g=d.data;for(var e=0;e<c.length;e++){if(e==0){g=g[c[e]]}else{g=g.ChildNodes[c[e]]}}return g},render:function(d){var g=d[0]._lrtree.dfop;var e=a('<ul class="lr-tree-root" ></ul>');var f=g.data.length;for(var h=0;h<f;h++){var c=a.lrtree.renderNode(g.data[h],0,h,g);e.append(c)}d.append(e);d.mCustomScrollbar({theme:"minimal-dark"});g=null},renderNode:function(v,p,w,q){v._deep=p;v._path=w;var u=v.id.replace(/[^\w]/gi,"_");var x=v.title||v.text;var g=a('<li class="lr-tree-node"></li>');var h=a('<div id="'+q.id+"_"+u+'" tpath="'+w+'" title="'+x+'"  dataId="'+q.id+'"  class="lr-tree-node-el" ></div>');if(v.hasChildren){var o=(v.isexpand||q.isAllExpand)?"lr-tree-node-expanded":"lr-tree-node-collapsed";h.addClass(o)}else{h.addClass("lr-tree-node-leaf")}var i=a('<span class="lr-tree-node-indent"></span>');if(p==1){i.append('<img class="lr-tree-icon" src="'+q.cbiconpath+'s.gif"/>')}else{if(p>1){i.append('<img class="lr-tree-icon" src="'+q.cbiconpath+'s.gif"/>');for(var r=1;r<p;r++){i.append('<img class="lr-tree-icon" src="'+q.cbiconpath+'s.gif"/>')}}}h.append(i);var f=a('<img class="lr-tree-ec-icon" src="'+q.cbiconpath+'s.gif"/>');h.append(f);if(v.showcheck){if(v.checkstate==null||v.checkstate==undefined){v.checkstate=0}var d=a('<img  id="'+q.id+"_"+u+'_cb" + class="lr-tree-node-cb" src="'+q.cbiconpath+q.icons[v.checkstate]+'" />');h.append(d)}if(v.icon!=-1){if(!!v.icon){h.append('<i class="'+v.icon+'"></i>&nbsp;')}else{if(v.hasChildren){if(v.isexpand||q.isAllExpand){h.append('<i class="fa fa-folder-open" style="width:15px">&nbsp;</i>')}else{h.append('<i class="fa fa-folder" style="width:15px">&nbsp;</i>')}}else{h.append('<i class="fa fa-file-o"></i>&nbsp;')}}}var n='<a class="lr-tree-node-anchor" href="javascript:void(0);">';n+='<span data-value="'+v.id+'" class="lr-tree-node-text" >'+v.text+"</span>";n+="</a>";h.append(n);h.on("click",a.lrtree.nodeClick);if(!v.complete){h.append('<div class="lr-tree-loading"><img class="lr-tree-ec-icon" src="'+q.cbiconpath+'loading.gif"/></div>')}g.append(h);if(v.hasChildren){var m=a('<ul  class="lr-tree-node-ct" >');if(!v.isexpand&&!q.isAllExpand){m.css("display","none")}if(v.ChildNodes){var t=v.ChildNodes.length;for(var s=0;s<t;s++){v.ChildNodes[s].parent=v;var e=a.lrtree.renderNode(v.ChildNodes[s],p+1,w+"."+s,q);m.append(e)}g.append(m)}}v.render=true;q=null;return g},renderNodeAsync:function(d,i,f){var e=a('<ul  class="lr-tree-node-ct" >');if(!i.isexpand&&!f.isAllExpand){e.css("display","none")}if(i.ChildNodes){var h=i.ChildNodes.length;for(var g=0;g<h;g++){i.ChildNodes[g].parent=i;var c=a.lrtree.renderNode(i.ChildNodes[g],i._deep+1,i._path+"."+g,f);e.append(c)}d.parent().append(e)}return e},renderToo:function(d){var g=d[0]._lrtree.dfop;var e=d.find(".lr-tree-root");e.html("");var f=g.data.length;for(var h=0;h<f;h++){var c=a.lrtree.renderNode(g.data[h],0,h,g);e.append(c)}g=null},nodeClick:function(i){var j=i.target||i.srcElement;var f=a(this);var d=a("#"+f.attr("dataId"));var h=d[0]._lrtree.dfop;if(j.tagName=="IMG"){var c=a(j);var g=f.next(".lr-tree-node-ct");if(c.hasClass("lr-tree-ec-icon")){if(f.hasClass("lr-tree-node-expanded")){g.slideUp(200,function(){f.removeClass("lr-tree-node-expanded");f.addClass("lr-tree-node-collapsed")})}else{if(f.hasClass("lr-tree-node-collapsed")){var l=f.attr("tpath");var k=a.lrtree.getItem(l,h);if(!k.complete){if(!k._loading){k._loading=true;f.find(".lr-tree-loading").show();b.httpAsync("GET",h.url,{parentId:k.id},function(e){if(!!e){k.ChildNodes=e;g=a.lrtree.renderNodeAsync(f,k,h);g.slideDown(200,function(){f.removeClass("lr-tree-node-collapsed");f.addClass("lr-tree-node-expanded")});k.complete=true;f.find(".lr-tree-loading").hide()}k._loading=false})}}else{g.slideDown(200,function(){f.removeClass("lr-tree-node-collapsed");f.addClass("lr-tree-node-expanded")})}}}}else{if(c.hasClass("lr-tree-node-cb")){var l=f.attr("tpath");var k=a.lrtree.getItem(l,h);if(k.checkstate==1){k.checkstate=0}else{k.checkstate=1}c.attr("src",h.cbiconpath+h.icons[k.checkstate]);a.lrtree.checkChild(a.lrtree.check,k,k.checkstate,h);a.lrtree.checkParent(a.lrtree.check,k,k.checkstate,h);h.nodeCheck(k,f)}}}else{var l=f.attr("tpath");var k=a.lrtree.getItem(l,h);h.currentItem=k;a("#"+h.id).find(".lr-tree-selected").removeClass("lr-tree-selected");f.addClass("lr-tree-selected");if(!!h.nodeClick){h.nodeClick(k,f)}}return false},check:function(h,n,o,e){var m=h.checkstate;if(o==1){h.checkstate=n}else{var d=h.ChildNodes;var j=d.length;var c=true;for(var g=0;g<j;g++){d[g].checkstate=d[g].checkstate||0;if((n==1&&d[g].checkstate!=1)||n==0&&d[g].checkstate!=0){c=false;break}}if(c){h.checkstate=n}else{h.checkstate=2}}if(h.render&&m!=h.checkstate){var k=h.id.replace(/[^\w]/gi,"_");var f=a("#"+e.id+"_"+k+"_cb");if(f.length==1){f.attr("src",e.cbiconpath+e.icons[h.checkstate])}}},checkParent:function(d,e,h,c){var f=e.parent;while(f){var g=d(f,h,0,c);if(g===false){break}f=f.parent}},checkChild:function(e,h,j,d){if(e(h,j,1,d)!=false){if(h.ChildNodes!=null&&h.ChildNodes.length>0){var c=h.ChildNodes;for(var f=0,g=c.length;f<g;f++){a.lrtree.checkChild(e,c[f],j,d)}}}},search:function(e,d){var c=[];a.each(d,function(g,k){var j={};for(var h in k){if(h!="ChildNodes"){j[h]=k[h]}}var f=false;if(j.text.indexOf(e)!=-1){f=true}if(j.hasChildren){j.ChildNodes=a.lrtree.search(e,k.ChildNodes);if(j.ChildNodes.length>0){f=true}else{j.hasChildren=false}}if(f){j.isexpand=true;c.push(j)}});return c},findItem:function(e,f,g){var d=null;c(e,f,g);function c(h,j,k){for(var m=0,n=h.length;m<n;m++){if(h[m][f]==g){d=h[m];return true}if(h[m].hasChildren&&h[m].ChildNodes.length>0){if(c(h[m].ChildNodes,j,k)){return true}}}return false}return d},listTotree:function(e,m,g,o,p,d){var n=[];var k={};for(var f=0,j=e.length;f<j;f++){var h=e[f];k[h[m]]=k[h[m]]||[];k[h[m]].push(h)}c(n,"0");function c(i,v){var u=k[v]||[];for(var s=0,t=u.length;s<t;s++){var q=u[s];var r={id:q[g],text:q[o],value:q[p],showcheck:d,checkstate:false,hasChildren:false,isexpand:false,complete:true,ChildNodes:[]};if(c(r.ChildNodes,q[g])){r.hasChildren=true;r.isexpand=true}i.push(r)}return i.length>0}return n},treeTotree:function(f,g,i,j,d,e){var h=[];c(h,f);function c(q,n){for(var o=0,p=n.length;o<p;o++){var k=n[o];var m={id:k[g],text:k[i],value:k[j],showcheck:d,checkstate:false,hasChildren:false,isexpand:true,complete:true,ChildNodes:[]};if(k[e].length>0){m.hasChildren=true;c(m.ChildNodes,k[e])}q.push(m)}}return h},addNode:function(e,i,g,h){var f=e[0]._lrtree.dfop;if(!!g){f.data.splice(h,0,i);var c=a.lrtree.renderNode(i,0,h,f);if(e.find(".lr-tree-root>li").length==0){e.find(".lr-tree-root>li").append(c)}else{e.find(".lr-tree-root>li").eq(h).before(c)}}else{var d=e.find("#"+f.id+"_"+g);var j=d.attr("tpath");var c=a.lrtree.renderNode(i,0,j+"."+h,f);if(d.next().children().length==0){d.next().children().append(c)}else{d.next().children().eq(h).before(c)}}},setValue:function(c){var d=c[0]._lrtree.dfop;if(d.data.length==0){setTimeout(function(){a.lrtree.setValue(c)},100)}else{c.find('span[data-value="'+d._value+'"]').trigger("click")}}};a.fn.lrtree=function(g){var d={icons:["checkbox_0.png","checkbox_1.png","checkbox_2.png"],method:"GET",url:false,param:null,data:[],isAllExpand:false,cbiconpath:"/Content/images/learuntree/",nodeClick:false,nodeCheck:false};a.extend(d,g);var c=a(this);d.id=c.attr("id");if(d.id==null||d.id==""){d.id="learuntree"+new Date().getTime();c.attr("id",d.id)}c.html("");c.addClass("lr-tree");c[0]._lrtree={dfop:d};c[0]._lrtree.dfop.backupData=d.data;if(d.url){b.httpAsync(d.method,d.url,d.param,function(h){c[0]._lrtree.dfop.data=h||[];c[0]._lrtree.dfop.backupData=c[0]._lrtree.dfop.data;a.lrtree.render(c)})}else{a.lrtree.render(c)}if(d.showcheck){for(var e=0;e<3;e++){var f=new Image();f.src=d.cbiconpath+d.icons[e]}}d=null;return c};a.fn.lrtreeSet=function(i,j){var c=a(this);var e=c[0]._lrtree.dfop;var f=function(p,m,n){for(var o=0,q=p.length;o<q;o++){if(c.find("#"+e.id+"_"+p[o].id.replace(/-/g,"_")).parent().css("display")!="none"){(p[o].showcheck==true&&(p[o].checkstate==1||p[o].checkstate==2))&&m.push(n(p[o]));if(!p[o].showcheck||(p[o].showcheck==true&&(p[o].checkstate==1||p[o].checkstate==2))){if(p[o].ChildNodes!=null&&p[o].ChildNodes.length>0){f(p[o].ChildNodes,m,n)}}}}};var g=function(p,m,n){for(var o=0,q=p.length;o<q;o++){if(c.find("#"+e.id+"_"+p[o].id.replace(/-/g,"_")).parent().css("display")!="none"){(p[o].showcheck==true&&(p[o].checkstate==1||p[o].checkstate==2)&&!p[o].hasChildren)&&m.push(n(p[o]));if(!p[o].showcheck||(p[o].showcheck==true&&(p[o].checkstate==1||p[o].checkstate==2))){if(p[o].ChildNodes!=null&&p[o].ChildNodes.length>0){g(p[o].ChildNodes,m,n)}}}}};var l=function(p,m,n){for(var o=0,q=p.length;o<q;o++){if(p[o].showcheck){p[o].checkstate=0}if(p[o].ChildNodes!=null&&p[o].ChildNodes.length>0){l(p[o].ChildNodes)}}};switch(i){case"allNoCheck":c.find(".lr-tree-node-cb").attr("src",e.cbiconpath+"checkbox_0.png");l(e.data);break;case"allCheck":c.find('.lr-tree-node-cb[src$="checkbox_0.png"]').trigger("click");break;case"setCheck":var h=j;a.each(h,function(n,o){var m=c.find("#"+e.id+"_"+o.replace(/-/g,"_"));if(m.next().length==0){m.find(".lr-tree-node-cb").trigger("click")}});break;case"setValue":e._value=j;a.lrtree.setValue(c);break;case"currentItem":return e.currentItem;break;case"getCheckNodesEx":var d=[];g(e.data,d,function(m){return m});return d;break;case"getCheckNodes":var d=[];f(e.data,d,function(m){return m});return d;break;case"getCheckNodeIds":var d=[];f(e.data,d,function(m){return m.id});return d;break;case"getCheckNodeIdsByPath":var d=[];var k;f(e.data,d,function(m){return m.id});return d;break;case"search":if(b.validator.isNotNull(j.keyword).code){e._isSearch=true;e.data=a.lrtree.search(j.keyword,e.backupData);a.lrtree.renderToo(c)}else{if(e._isSearch){e.data=e.backupData;a.lrtree.renderToo(c);e._isSearch=false}}break;case"refresh":a.extend(e,j||{});if(!!e.url){b.httpAsync(e.method,e.url,e.param,function(m){c[0]._lrtree.dfop.data=m||[];c[0]._lrtree.dfop.backupData=c[0]._lrtree.dfop.data;a.lrtree.renderToo(c);e._isSearch=false})}else{c[0]._lrtree.dfop.backupData=c[0]._lrtree.dfop.data;a.lrtree.renderToo(c);e._isSearch=false}break;case"addNode":break;case"updateNode":break}}})(jQuery,top.learun);(function(a,b){a.lrselect={htmlToData:function(c){var e=c[0]._lrselect.dfop;var d=c.find("ul");e.data=[];d.find("li").each(function(){var f=a(this);var g={id:f.attr("data-value"),text:f.html()};e.data.push(g)});d.remove();d=null;e=null},initRender:function(h,f){var c=a('<div class="lr-select-option" id="learun_select_option_'+h.id+'"></div>');var d=a('<div class="lr-select-option-content"></div>');var g=a('<ul id="learun_select_option_content'+h.id+'"></ul>');d.css("max-height",h.maxHeight+"px");c.hide();d.html(g);c.prepend(d);if(h.allowSearch){var e=a('<div class="lr-select-option-search"><input type="text" placeholder="搜索关键字"><span class="input-query" title="查询"><i class="fa fa-search"></i></span></div>');c.append(e);c.css("padding-bottom","25px");e.on("click",function(){return false});e.find("input").on("keypress",function(q){if(event.keyCode=="13"){var m=a(this);var s=m.val();var k=m.parents(".lr-select");var p=k[0]._lrselect.dfop;if(p.type=="tree"){var j=m.parent().prev();j.lrtreeSet("search",{keyword:s})}else{if(p.type=="default"){if(!!s){var n=[];for(var r=0,t=p.backdata.length;r<t;r++){var o=p.backdata[r];if(o[p.text].indexOf(s)!=-1){n.push(o)}}p.data=n}else{p.data=p.backdata}a.lrselect.render(p)}}}})}f.append(c);f.append('<div class="lr-select-placeholder" >=='+h.placeholder+"==</div>");f.attr("type","lrselect").addClass("lr-select");if(h.type!="tree"){d.mCustomScrollbar({theme:"minimal-dark"})}},render:function(c){switch(c.type){case"default":a.lrselect.defaultRender(c);break;case"tree":case"treemultiple":a.lrselect.treeRender(c);break;case"gird":break;case"multiple":break;default:break}c.isrender=true},defaultRender:function(e){var d=a("#learun_select_option_content"+e.id);d.html("");if(!!e.placeholder){d.append('<li data-value="-1" class="lr-selectitem-li" >=='+e.placeholder+"==</li>")}for(var f=0,h=e.data.length;f<h;f++){var g=e.data[f];var c=a('<li data-value="'+f+'" class="lr-selectitem-li" >'+g[e.text]+"</li>");d.append(c)}},treeRender:function(e){var c=a("#learun_select_option_"+e.id);c.find(".lr-select-option-content").remove();var d=a('<div class="lr-select-option-content"></div>');c.prepend(d);d.css("max-height",e.maxHeight+"px");e.data.unshift({id:"-1",text:"=="+e.placeholder+"==",value:"-1",icon:"-1",parentnodes:"0",showcheck:false,isexpand:false,complete:true,hasChildren:false,ChildNodes:[]});var f={data:e.data,nodeClick:a.lrselect.treeNodeClick};if(e.type=="treemultiple"){f.nodeClick=a.lrselect.treeNodeClick2;f.nodeCheck=a.lrselect.treeNodeCheck}d.lrtree(f)},bindEvent:function(c){c.unbind("click");c.on("click",a.lrselect.click);a(document).click(function(d){a(".lr-select-option").slideUp(150);a(".lr-select").removeClass("lr-select-focus")})},click:function(j){var g=a(this);if(g.attr("readonly")=="readonly"||g.attr("disabled")=="disabled"){return false}var i=g[0]._lrselect.dfop;if(!i.isload){return false}if(!i.isrender){a.lrselect.render(i)}var f=a("#learun_select_option_"+i.id);if(f.is(":hidden")){a(".lr-select-option").slideUp(150);a(".lr-select").removeClass("lr-select-focus");g.addClass("lr-select-focus");var l=i.width||g.parent().width();f.css("width",l).show();f.find(".lr-select-option-search").find("input").select()}else{f.slideUp(150);g.removeClass("lr-select-focus")}var k=j.target||j.srcElement;var c=a(k);if(c.hasClass("lr-selectitem-li")){var h=c.attr("data-value");if(i._index!=h){var d=g.find(".lr-select-placeholder");if(h==-1){d.css("color","#999");d.html("=="+i.placeholder+"==")}else{d.css("color","#000");d.html(i.data[h][i.text])}c.addClass("selected");if(i._index!=undefined&&i._index!=null){f.find('.lr-selectitem-li[data-value="'+i._index+'"]').removeClass("selected")}i._index=h;g.trigger("change");if(!!i.select){i.select(i.data[h])}}}i=null;j.stopPropagation()},treeNodeClick:function(g,d){d.parents(".lr-select-option").slideUp(150);var e=d.parents(".lr-select");var f=e[0]._lrselect.dfop;e.removeClass("lr-select-focus");f.currtentItem=g;var c=e.find(".lr-select-placeholder");c.html(f.currtentItem.text);if(g.value=="-1"){c.css("color","#999")}else{c.css("color","#000")}e.trigger("change");if(!!f.select){f.select(f.currtentItem)}},treeNodeClick2:function(g,d){$tree=d.parents(".lr-select-option-content");var e=d.parents(".lr-select");var f=e[0]._lrselect.dfop;e.removeClass("lr-select-focus");f.currtentItems=[];if(g.value=="-1"){d.parents(".lr-select-option").slideUp(150);$tree.lrtreeSet("allNoCheck");var c=e.find(".lr-select-placeholder");c.html(g.text);c.css("color","#999");e.trigger("change");if(!!f.select){f.select([])}}},treeNodeCheck:function(j,d){$tree=d.parents(".lr-select-option-content");var e=d.parents(".lr-select");var c=e.find(".lr-select-placeholder");e.removeClass("lr-select-focus");var g=e[0]._lrselect.dfop;var f=$tree.lrtreeSet("getCheckNodesEx");g.currtentItems=f;var n="";for(var h=0,k=f.length;h<k;h++){var m=f[h];if(n!=""){n+=","}n+=m.text}if(n==""){c.html("=="+g.placeholder+"==");c.css("color","#999")}else{c.text(n);c.css("color","#000")}e.trigger("change");if(!!g.select){g.select(g.currtentItems)}},defaultValue:function(d){var e=d[0]._lrselect.dfop;e.currtentItem=null;e._index=-1;var c=d.find(".lr-select-placeholder");c.css("color","#999");c.html("=="+e.placeholder+"==");d.trigger("change")}};a.fn.lrselect=function(e){var d={placeholder:"请选择",type:"default",value:"id",text:"text",title:"title",maxHeight:200,width:false,allowSearch:false,url:false,data:false,param:null,method:"GET",select:false,isload:false,isrender:false};a.extend(d,e||{});var c=a(this);if(c.length==0){return c}d.id=c.attr("id");if(!d.id){return false}if(!!c[0]._lrselect){return c}c[0]._lrselect={dfop:d};a.lrselect.bindEvent(c);if(!!d.url){b.httpAsync(d.method,d.url,d.param,function(f){c[0]._lrselect.dfop.data=f||[];c[0]._lrselect.dfop.backdata=f||[];d.isload=true})}else{if(!!d.data){d.isload=true;d.backdata=d.data}else{a.lrselect.htmlToData(c);d.isload=true;d.backdata=d.data}}a.lrselect.initRender(d,c);return c};a.fn.lrselectRefresh=function(e){var c=a(this);if(c.length==0){return c}if(!c[0]._lrselect){return false}var d=c[0]._lrselect.dfop;if(!d){return false}a.extend(d,e||{});d.isload=false;d.isrender=false;if(!!d.url){b.httpAsync(d.method,d.url,d.param,function(f){c[0]._lrselect.dfop.data=f||[];c[0]._lrselect.dfop.backdata=f||[];d.isload=true})}else{if(!!d.data){d.isload=true;d.backdata=d.data}}a.lrselect.defaultValue(c);if(d._setValue!=null&&d._setValue!=undefined){c.lrselectSet(d._setValue)}};a.fn.lrselectGet=function(){var c=a(this);if(c.length==0){return c}var d=c[0]._lrselect.dfop;var g="";switch(d.type){case"default":if(!!d.data[d._index]){g=d.data[d._index][d.value]}break;case"tree":if(!!d.currtentItem){g=d.currtentItem[d.value]}break;case"treemultiple":if(!!d.currtentItems){for(var e=0,f=d.currtentItems.length;e<f;e++){if(g!=""){g+=","}g+=d.currtentItems[e][d.value]}}break;case"gird":break;case"multiple":break;default:break}return g};a.fn.lrselectSet=function(f){var c=a(this);if(c.length==0){return c}f=f+"";if(f==""||f==undefined||f==null){a.lrselect.defaultValue(c);return c}var e=c[0]._lrselect.dfop;e._setValue=null;if(!e){return c}function d(j){if(j.isload==false){setTimeout(function(){d(j)},100)}else{if(j.isload==true){var h;switch(j.type){case"default":for(var k=0,m=j.data.length;k<m;k++){if(j.data[k][j.value]==f){j._index=k;h=j.data[k];break}}break;case"tree":h=a.lrtree.findItem(j.data,j.value,f);j.currtentItem=h;break;case"treemultiple":a.lrselect.render(j);c.find(".lr-select-option-content").lrtreeSet("setCheck",f.split(","));return false;break;case"gird":break;case"multiple":break;default:break}if(!!h){var g=c.find(".lr-select-placeholder");g.html(h[j.text]);g.css("color","#000");c.trigger("change");if(!!j.select){j.select(h)}}else{j._setValue=f}}}}d(e);return c}})(jQuery,top.learun);$.fn.lrtimeline=function(i){var h={nodelist:[]};$.extend(h,i||{});var e=$(this);if(e.length==0){return e}h.id=e.attr("id");if(!h.id){return false}e.addClass("lr-timeline");var g=$('<div class="lr-timeline-allwrap"></div>');var f=$("<ul></ul>");var a=$('<li class="lr-timeline-header"><div>当前</div></li>');f.append(a);var d=$('<li class="lr-timeline-item" ><div class="lr-timeline-wrap lr-timeline-current" ></div></li>');var c=d.find(".lr-timeline-wrap");var b=$('<div class="lr-timeline-content"><span class="arrow"></span></div>');b.append('<div class="lr--timeline-title">普通节点审核</div>');b.append('<div class="lr--timeline-body"><span>审核人</span>正在处理中!</div>');c.append('<span class="lr-timeline-date">2017-08-28 16:18:33</span>');c.append(b);f.append(d);f.append('<li class="lr-timeline-ender"><div>发起</div></li>');g.html(f);e.html(g)};(function(a,b){a.lrcustmerquery={init:function(c){var d=c[0]._lrcustmerquery.dfop;c.parent().append('<div class="learun-isearch-panel"  style="max-height:'+d.maxHeight+'px;" ><ul id="learunisearch_'+d.id+'" ></ul></div>')},bind:function(c){c.on("input propertychange",function(){var d=a(this);a.learunisearch.triggerSearch(c)})},triggerSearch:function(c){var f=c[0]._lrcustmerquery.dfop;var d=a("#learunisearch_"+f.id);d.parent().hide();var e=c.val();if(e){if(!f._isload){f._isSearchneed=true}else{f._first=true;f._value=e;f._begin=0;f._end=100>f.data.length?f.data.length:100;if(f._isSearched){f._isSearched=false;setTimeout(function(){a.learunisearch.search(c)})}}}else{f._isSearchneed=false;d.html("")}},search:function(c){var g=c[0]._lrcustmerquery.dfop;var k=g._value;var e=g._begin;var h=g._end;var f=g.data;for(var j=e;j<h;j++){var d=f[j];if(item[g.text].indexOf(k)!=-1){a.learunisearch.renderNone(c,item[g.text])}}if(h<f.length){g._begin=h;g._end=h+100;if(g._end>f.length){g._end=f.length}setTimeout(function(){a.learunisearch.search(c)})}else{g._isSearched=true}},renderNone:function(c,f){var e=c[0]._lrcustmerquery.dfop;var d=a("#learunisearch_"+e.id);if(e._first){e._first=false;d.html("");d.parent().show()}d.append("<li>"+f+"</li>")}};a.fn.lrcustmerquery=function(e){var d={dfData:[],Fields:[],moduleUrl:"",url:top.$.rootUrl+"/LR_SystemModule/CustmerQuery/GetList",data:[],_isload:false};a.extend(d,e||{});var c=a(this);d.id=c.attr("id");if(!d.id){return false}c[0]._lrcustmerquery={dfop:d};a.lrcustmerquery.init(c);if(!!d.url){b.httpAsync("GET",d.url,d.param,function(f){c[0]._lrcustmerquery.dfop.data=f||[];d._isload=true})}return c}})(jQuery,top.learun);(function(a,b){a.lrdate={init:function(j){var l=j[0]._lrdate.dfop;j.html("");j.addClass("lr-search-date");var k=a('<div class="lr-search-date-text" id="lr_search_date_'+l.id+'" ></div>');var d=a('<div class="lr-search-date-container" id="lr_search_date_container_'+l.id+'"><div class="lr-search-date-arrow"><div class="lr-search-date-inside"></div></div></div>');var c=a('<div class="lr-search-date-content-btns" id="lr_search_date_content_btns_'+l.id+'"></div>');var e=a('<div class="lr-search-date-btn-block"><a href="javascript:;" data-value="customDate">自定义</a></div>');c.append(e);d.append(c);var i=a('<div class="lr-search-date-datepicker-content"></div>');var f=a('<div class="lr-search-date-datepicker-container first" id="lr_search_date_datepicker1_'+l.id+'"  ></div>');var g=a('<div class="lr-search-date-datepicker-container" id="lr_search_date_datepicker2_'+l.id+'"  ></div>');var h=a('<div class="lr-search-date-datepicker-btn"><a class="btn btn-primary">确定</a></div>');i.append(f);i.append(g);i.append(h);d.append(i);j.append(k);j.append(d);WdatePicker({eCont:"lr_search_date_datepicker1_"+l.id,onpicked:function(m){l._begindate=m.cal.getDateStr()+" 00:00:00"}});WdatePicker({eCont:"lr_search_date_datepicker2_"+l.id,onpicked:function(m){l._enddate=m.cal.getDateStr()+" 23:59:59"}});k.on("click",function(q){var o=a(this);var n=o.parents(".lr-search-date");var p=n[0]._lrdate.dfop;var m=n.find("#lr_search_date_container_"+p.id);if(m.is(":hidden")){m.show()}else{m.hide()}});a(document).click(function(n){var o=n.target||n.srcElement;var m=a(o);if(!m.hasClass("lr-search-date")&&m.parents(".lr-search-date").length<=0){a(".lr-search-date-container").hide()}});e.find("a").on("click",function(p){var n=a(this);var m=n.parents(".lr-search-date");var o=m[0]._lrdate.dfop;m.find(".lr-search-date-content-btns a.active").removeClass("active");a("#lr_search_date_container_"+o.id).addClass("width");n.addClass("active");m.find(".lr-search-date-datepicker-content").show()});h.find("a").on("click",function(){var n=a(this).parents(".lr-search-date");var p=n[0]._lrdate.dfop;var m=n.find("#lr_search_date_container_"+p.id);var o=n.find("#lr_search_date_"+p.id);m.hide();var q=b.formatDate(p._begindate,"yyyy-MM-dd")+"~"+b.formatDate(p._enddate,"yyyy-MM-dd");o.html(q);if(!!p.selectfn){p.selectfn(p._begindate,p._enddate)}})},monthinit:function(e){var f=e[0]._lrdate.dfop;var d=a("#lr_search_date_content_btns_"+f.id);var c=a('<div class="lr-search-date-btn-block"></div>');if(f.premShow){c.append('<a href="javascript:;" class="datebtn" data-value="preM">上月</a>')}if(f.mShow){c.append('<a href="javascript:;" class="datebtn" data-value="currentM">本月</a>')}d.prepend(c);f=null},jinit:function(e){var f=e[0]._lrdate.dfop;var d=a("#lr_search_date_content_btns_"+f.id);var c=a('<div class="lr-search-date-btn-block"></div>');if(f.prejShow){c.append('<a href="javascript:;" class="datebtn" data-value="preJ">上季度</a>')}if(f.jShow){c.append('<a href="javascript:;" class="datebtn" data-value="currentJ">本季度</a>')}d.prepend(c);f=null},yinit:function(e){var f=e[0]._lrdate.dfop;var d=a("#lr_search_date_content_btns_"+f.id);var c=a('<div class="lr-search-date-btn-block"></div>');if(f.ysShow){c.append('<a href="javascript:;" class="datebtn" data-value="yS">上半年</a>')}if(f.yxShow){c.append('<a href="javascript:;" class="datebtn" data-value="yX">下半年</a>')}if(f.preyShow){c.append('<a href="javascript:;" class="datebtn" data-value="preY">去年</a>')}if(f.yShow){c.append('<a href="javascript:;" class="datebtn" data-value="currentY">今年</a>')}d.prepend(c);f=null},custmerinit:function(e){var f=e[0]._lrdate.dfop;var d=a("#lr_search_date_content_btns_"+f.id);var c=a('<div class="lr-search-date-btn-block"></div>');for(var g=0,j=f.dfdata.length;g<j;g++){var h=f.dfdata[g];c.append('<a href="javascript:;" class="datebtn" data-value="'+g+'">'+h.name+"</a>")}d.prepend(c);f=null},bindEvent:function(c){c.find(".datebtn").on("click",function(){var e=a(this);var d=e.parents(".lr-search-date");var f=e.attr("data-value");a.lrdate.select(d,f)})},select:function(f,n){var k=f[0]._lrdate.dfop;var e=f.find("#lr_search_date_container_"+k.id);var g=f.find("#lr_search_date_"+k.id);var c=a("#lr_search_date_content_btns_"+k.id);c.find(".active").removeClass("active");var h=c.find('.datebtn[data-value="'+n+'"]').addClass("active");switch(n){case"preM":var i=b.getPreMonth();k._begindate=i.begin;k._enddate=i.end;break;case"currentM":var i=b.getMonth();k._begindate=i.begin;k._enddate=i.end;break;case"preJ":var i=b.getPreQuarter();k._begindate=i.begin;k._enddate=i.end;break;case"currentJ":var i=b.getCurrentQuarter();k._begindate=i.begin;k._enddate=i.end;break;case"yS":var i=b.getFirstHalfYear();k._begindate=i.begin;k._enddate=i.end;break;case"yX":var i=b.getSecondHalfYear();k._begindate=i.begin;k._enddate=i.end;break;case"preY":var i=b.getPreYear();k._begindate=i.begin;k._enddate=i.end;break;case"currentY":var i=b.getYear();k._begindate=i.begin;k._enddate=i.end;break;default:var m=parseInt(n);var j=k.dfdata[m];k._begindate=j.begin();k._enddate=j.end();break}e.hide();var l=b.formatDate(k._begindate,"yyyy-MM-dd")+"~"+b.formatDate(k._enddate,"yyyy-MM-dd");g.html(l);a("#lr_search_date_container_"+k.id).removeClass("width");f.find(".lr-search-date-datepicker-content").hide();if(!!k.selectfn){k.selectfn(k._begindate,k._enddate)}}};a.fn.lrdate=function(e){var d={dfdata:[],mShow:true,premShow:true,jShow:true,prejShow:true,ysShow:true,yxShow:true,preyShow:true,yShow:true,dfvalue:false,selectfn:false};a.extend(d,e||{});var c=a(this);d.id=c.attr("id");if(!d.id){return false}c[0]._lrdate={dfop:d};a.lrdate.init(c);a.lrdate.yinit(c);a.lrdate.jinit(c);a.lrdate.monthinit(c);a.lrdate.custmerinit(c);a.lrdate.bindEvent(c);if(d.dfvalue!=false){a.lrdate.select(c,d.dfvalue)}return c}})(jQuery,top.learun);(function(a,b){a.lrValidformMessage=function(d,e){d.addClass("lr-field-error");d.parent().append('<div class="lr-field-error-info" title="'+e+'！"><i class="fa fa-info-circle"></i></div>');var f=d.parent().find(".form-item-title").text()+" "+e;b.alert.error("表单信息输入有误,请检查！</br>"+f);if(d.attr("type")=="lrselect"){d.on("change",function(){c(a(this))})}else{if(d.attr("type")=="formselect"){d.on("change",function(){c(a(this))})}else{if(d.hasClass("lr-input-wdatepicker")){d.on("change",function(){var g=a(this);if(g.val()){c(g)}})}else{d.on("input propertychange",function(){var g=a(this);if(g.val()){c(g)}})}}}};a.fn.lrRemoveValidMessage=function(){c(a(this))};a.fn.lrValidform=function(){var d=true;var e=b.validator;a(this).find("[isvalid=yes]").each(function(){var f=a(this);if(f.parent().find(".lr-field-error-info").length>0){d=false;return true}var g=a(this).attr("checkexpession");var h=e["is"+g];if(!g||!h){return false}var i=a(this).attr("errormsg")||"";var m;var l=f.attr("type");if(l=="lrselect"){m=f.lrselectGet()}else{if(l=="formselect"){m=f.lrformselectGet()}else{m=f.val()}}var k={code:true,msg:""};if(g=="LenNum"||g=="LenNumOrNull"||g=="LenStr"||g=="LenStrOrNull"){var j=f.attr("length");k=h(m,j)}else{k=h(m)}if(!k.code){d=false;a.lrValidformMessage(f,i+k.msg)}});return d};function c(d){d.removeClass("lr-field-error");d.parent().find(".lr-field-error-info").remove()}})(window.jQuery,top.learun);(function(a,b){a.fn.lrAuthorizeJfGrid=function(d){var c=[];a.each(d.headData,function(e,f){if(!!lrModuleColumnList[f.name.toLowerCase()]){c.push(f)}});d.headData=c;a(this).jfGrid(d)};a(function(){function c(){if(!!lrModuleButtonList){var d=a('[learun-authorize="yes"]');d.find("[id]").each(function(){var e=a(this);var f=e.attr("id");if(!lrModuleButtonList[f]){e.remove()}});d.find(".dropdown-menu").each(function(){var e=a(this);if(e.find("li").length==0){e.remove()}});d.css({display:"inline-block"})}else{setTimeout(c,100)}}c()})})(window.jQuery,top.learun);(function(a,b){a(function(){function c(){if(!!lrModule){b.httpAsync("GET",top.$.rootUrl+"/LR_SystemModule/ExcelImport/GetList",{moduleId:lrModule.F_ModuleId},function(f){if(!!f&&f.length>0){var e=a(".lr-layout-tool-right");var d=a('<div class=" btn-group btn-group-sm"></div>');var g=false;a.each(f,function(i,j){if(!!lrModuleButtonList[j.F_ModuleBtnId]){g=true;var h=a('<a id="'+j.F_ModuleBtnId+'" data-value="'+j.F_Id+'"  class="btn btn-default"><i class="fa fa-sign-in"></i>&nbsp;'+j.F_BtnName+"</a>");h.on("click",function(){var k=a(this).attr("data-value");var l=a(this).text();b.layerForm({id:"ImportForm",title:l,url:top.$.rootUrl+"/LR_SystemModule/ExcelImport/ImportForm?id="+k,width:600,height:400,maxmin:true,btn:null})});d.append(h)}});e.append(d)}});b.httpAsync("GET",top.$.rootUrl+"/LR_SystemModule/ExcelExport/GetList",{moduleId:lrModule.F_ModuleId},function(f){if(!!f&&f.length>0){var e=a(".lr-layout-tool-right");var d=a('<div class=" btn-group btn-group-sm"></div>');var g=false;a.each(f,function(i,j){if(!!lrModuleButtonList[j.F_ModuleBtnId]){g=true;var h=a('<a id="'+j.F_ModuleBtnId+'" class="btn btn-default"><i class="fa fa-sign-out"></i>&nbsp;'+j.F_BtnName+"</a>");h[0].dfop=j;h.on("click",function(){j=h[0].dfop;b.layerForm({id:"ExcelExportForm",title:"导出Excel数据",url:top.$.rootUrl+"/Utility/ExcelExportForm?gridId="+j.F_GridId+"&filename="+encodeURI(encodeURI(j.F_Name)),width:500,height:380,callBack:function(k){return top[k].acceptClick()},btn:["导出Excel","关闭"]})});d.append(h)}});e.append(d)}})}else{setTimeout(c,100)}}c()})})(window.jQuery,top.learun);(function(a,b){a.fn.lrGetFormData=function(c){var d={};a(this).find("input,select,textarea,.lr-select,.lr-formselect,.lrUploader-wrap,.lr-radio,.lr-checkbox").each(function(g){var f=a(this).attr("id");if(!!f){var h=a(this).attr("type");switch(h){case"radio":if(a("#"+f).is(":checked")){var e=a("#"+f).attr("name");d[e]=a("#"+f).val()}break;case"checkbox":if(a("#"+f).is(":checked")){d[f]=1}else{d[f]=0}break;case"lrselect":d[f]=a(this).lrselectGet();break;case"formselect":d[f]=a(this).lrformselectGet();break;case"lr-Uploader":d[f]=a(this).lrUploaderGet();break;case"lr-radio":d[f]=a(this).find("input:checked").val();break;default:var i=a("#"+f).val();d[f]=a.trim(i);break}d[f]+="";if(d[f]==""){d[f]="&nbsp;"}if(d[f]=="&nbsp;"&&!c){d[f]=""}}});return d};a.fn.lrSetFormData=function(d){for(var e in d){var h=d[e];var c=a("#"+e);if(c.length==0&&h!=null){c=a('[name="'+e+'"][value="'+h+'"]');if(c.length>0){if(!c.is(":checked")){c.trigger("click")}}}else{var g=c.attr("type");if(c.hasClass("lr-input-wdatepicker")){g="datepicker"}switch(g){case"checkbox":var f=0;if(c.is(":checked")){f=1}else{f=0}if(f!=parseInt(h)){c.trigger("click")}break;case"lrselect":c.lrselectSet(h);break;case"formselect":c.lrformselectSet(h);break;case"datepicker":c.val(b.formatDate(h,"yyyy-MM-dd"));break;case"lr-Uploader":c.lrUploaderSet(h);break;case"lr-radio":if(!c.find('input[value="'+h+'"]').is(":checked")){c.find('input[value="'+h+'"]').trigger("click")}break;default:c.val(h);break}}}};a.lrSetForm=function(d,c){b.loading(true,"正在获取数据");b.httpAsyncGet(d,function(e){b.loading(false);if(e.code==b.httpCode.success){c(e.data)}else{b.layerClose(window.name);b.alert.error("表单数据获取失败,请重新获取！");b.httpErrorLog(e.info)}})};a.lrSaveForm=function(f,e,c,d){e.__RequestVerificationToken=a.lrToken;b.loading(true,"正在保存数据");b.httpAsyncPost(f,e,function(g){b.loading(false);if(g.code==b.httpCode.success){if(!!c){c(g)}b.alert.success(g.info);if(!d){b.layerClose(window.name)}}else{b.alert.error(g.info);b.httpErrorLog(g.info)}})};a.lrPostForm=function(d,c){c.__RequestVerificationToken=a.lrToken;b.loading(true,"正在提交数据");b.httpAsyncPost(d,c,function(e){b.loading(false);if(e.code==b.httpCode.success){b.alert.success(e.info)}else{b.alert.error(e.info);b.httpErrorLog(e.info)}})};a.fn.lrFormTab=function(){var c=a(this);c.parent().css({"padding-top":"44px"});c.mCustomScrollbar({axis:"x",theme:"minimal-dark"});c.delegate("li","click",{$ul:c},function(h){var f=a(this);if(!f.hasClass("active")){var g=f.parent();var d=h.data.$ul.next();var i=f.find("a").attr("data-value");g.find("li.active").removeClass("active");f.addClass("active");d.find(".tab-pane.active").removeClass("active");d.find("#"+i).addClass("active")}})};a.fn.lrFormTabEx=function(d){var c=a(this);c.delegate("li","click",{$ul:c},function(i){var g=a(this);if(!g.hasClass("active")){var h=g.parent();var f=i.data.$ul.next();var j=g.find("a").attr("data-value");h.find("li.active").removeClass("active");g.addClass("active");f.find(".tab-pane.active").removeClass("active");f.find("#"+j).addClass("active");if(!!d){d(j)}}})};a.lrExistField=function(f,d,h,g){var c=a("#"+d);if(!c.val()){return false}var e={keyValue:f};e[d]=c.val();a.extend(e,g);b.httpAsync("GET",h,e,function(i){if(i==false){a.lrValidformMessage(c,"已存在,请重新输入")}})};a.fn.lrDataItemSelect=function(d){var c={value:"F_ItemValue",text:"F_ItemName",title:"F_ItemName",maxHeight:200,allowSearch:false,url:top.$.rootUrl+"/LR_SystemModule/DataItem/GetDetailListByParentId",param:{itemCode:"",parentId:"0"},};d=d||{};if(!d.code){return false}c.param.itemCode=d.code;c.param.parentId=d.parentId||"0";c.maxHeight=d.maxHeight||200;c.allowSearch=d.allowSearch;if(!!d.childId){a("#"+d.childId).lrselect({value:"F_ItemValue",text:"F_ItemName",title:"F_ItemName",maxHeight:c.maxHeight,allowSearch:c.allowSearch,});c.select=function(e){if(!e){a("#"+d.childId).lrselectRefresh({url:"",data:[]})}else{a("#"+d.childId).lrselectRefresh({url:top.$.rootUrl+"/LR_SystemModule/DataItem/GetDetailListByParentId",param:{itemCode:d.code,parentId:e.F_ItemDetailId},})}}}return a(this).lrselect(c)};a.fn.lrCompanySelect=function(d){var c={type:"tree",maxHeight:200,allowSearch:true,url:top.$.rootUrl+"/LR_OrganizationModule/Company/GetTree",param:{parentId:"0"},};d=d||{};c.param.parentId=d.parentId||"0";c.maxHeight=d.maxHeight||200;return a(this).lrselect(c)};a.fn.lrDepartmentSelect=function(d){var c={type:"tree",maxHeight:200,allowSearch:true,url:top.$.rootUrl+"/LR_OrganizationModule/Department/GetTree",param:{companyId:"",parentId:""},};d=d||{};c.param.companyId=d.companyId;c.param.parentId=d.parentId;c.maxHeight=d.maxHeight||200;return a(this).lrselect(c)};a.fn.lrUserSelect=function(c){if(c==0){a(this).lrformselect({layerUrl:top.$.rootUrl+"/LR_OrganizationModule/User/SelectOnlyForm",layerUrlW:400,layerUrlH:300,dataUrl:top.$.rootUrl+"/LR_OrganizationModule/User/GetListByUserIds"})}else{a(this).lrformselect({layerUrl:top.$.rootUrl+"/LR_OrganizationModule/User/SelectForm",layerUrlW:800,layerUrlH:520,dataUrl:top.$.rootUrl+"/LR_OrganizationModule/User/GetListByUserIds"})}};a.fn.lrAreaSelect=function(g){var e={value:"F_AreaCode",text:"F_AreaName",title:"F_AreaName",maxHeight:200,allowSearch:true,url:top.$.rootUrl+"/LR_SystemModule/Area/Getlist",param:{parentId:""},};g=g||{};if(!!g.parentId){e.param.parentId=g.parentId}e.maxHeight=g.maxHeight||200;var d=[],f=0;var c=a(this);a(this).find("div").each(function(){var h=a("<div></div>");var i=a(this);e.placeholder=i.attr("placeholder");h.addClass(i.attr("class"));i.removeAttr("class");i.removeAttr("placeholder");h.append(i);c.append(h);if(f==0){i.lrselect(e)}else{e.url="";e.parentId="";i.lrselect(e);d[f-1].on("change",function(){var j=a(this).lrselectGet();if(j==""){i.lrselectRefresh({url:"",param:{parentId:j},data:[]})}else{i.lrselectRefresh({url:top.$.rootUrl+"/LR_SystemModule/Area/Getlist",param:{parentId:j},})}})}f++;d.push(i)})};a.fn.lrDbSelect=function(d){var c={type:"tree",maxHeight:200,allowSearch:true,url:top.$.rootUrl+"/LR_SystemModule/DatabaseLink/GetTreeList"};d=d||{};c.maxHeight=d.maxHeight||200;return a(this).lrselect(c)};a.lrGetDataItem=function(d,c){b.httpAsyncGet(top.$.rootUrl+"/LR_SystemModule/DataItem/GetDetailList?itemCode="+d,function(e){if(e.code==b.httpCode.success){c(e.data)}else{b.alert.error("数据字典数据获取失败,请重新获取！");b.httpErrorLog(e.info)}})};a.lrGetDataSource=function(d,c){b.httpAsyncGet(top.$.rootUrl+"/LR_SystemModule/DataSource/GetDataTable?code="+d,function(e){if(e.code==b.httpCode.success){c(e.data)}else{b.alert.error("数据源数据获取失败,请重新获取！");b.httpErrorLog(e.info)}})};a.fn.lrRadioCheckbox=function(e){var d={type:"radio",dataType:"dataItem",code:"",text:"F_ItemName",value:"F_ItemValue"};a.extend(d,e||{});var c=a(this);c.addClass(d.type);c.addClass("lr-"+d.type);c.attr("type","lr-"+d.type);var f=c.attr("id");if(d.dataType=="dataItem"){a.lrGetDataItem(d.code,function(g){a.each(g,function(i,j){var h=a('<label><input name="'+f+'" value="'+j[d.value]+'"" type="'+d.type+'">'+j[d.text]+"</label>");c.append(h)});c.find("input").eq(0).trigger("click")})}else{a.lrGetDataSource(d.code,function(g){a.each(g,function(i,j){var h=a('<label><input name="'+f+'" value="'+j[d.value]+'"" type="'+d.type+'">'+j[d.text]+"</label>");c.append(h)});c.find("input").eq(0).trigger("click")})}};a.fn.lrMultipleQuery=function(g,f,h){var c=a(this);var e=c.html();c.addClass("lr-query-wrap");var d="";d+='<div class="lr-query-btn"><i class="fa fa-search"></i>&nbsp;多条件查询</div>';d+='<div class="lr-query-content">';d+=e;d+='<div class="lr-query-arrow"><div class="lr-query-inside"></div></div>';d+='<div class="lr-query-content-bottom">';d+='<a id="lr_btn_queryReset" class="btn btn-default">&nbsp;重&nbsp;&nbsp;置</a>';d+='<a id="lr_btn_querySearch" class="btn btn-primary">&nbsp;查&nbsp;&nbsp;询</a>';d+="</div>";d+="</div>";c.html(d);c.find(".lr-query-formcontent").show();c.find(".lr-query-content").css({width:h||400,height:f||300});c.find(".lr-query-btn").on("click",function(){var i=c.find(".lr-query-content");if(i.hasClass("active")){i.removeClass("active")}else{i.addClass("active")}});c.find("#lr_btn_querySearch").on("click",function(){var i=c.find(".lr-query-content");var j=i.lrGetFormData();i.removeClass("active");g(j)});c.find("#lr_btn_queryReset").on("click",function(){var i=c.find(".lr-query-content");var k=i.lrGetFormData();for(var j in k){k[j]=""}i.lrSetFormData(k)});a(document).click(function(j){var k=j.target||j.srcElement;var i=a(k);if(!i.hasClass("lr-query-wrap")&&i.parents(".lr-query-wrap").length<=0){a(".lr-query-content").removeClass("active")}})}})(jQuery,top.learun);</script>