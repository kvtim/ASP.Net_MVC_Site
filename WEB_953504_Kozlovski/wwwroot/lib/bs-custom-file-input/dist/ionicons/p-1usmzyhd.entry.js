import{r as t,h as s,H as i,c as n}from"./p-23d2b8a2.js";import{i as o,g as r,b as e}from"./p-0dfd1204.js";const c=t=>{if(1===t.nodeType){if("script"===t.nodeName.toLowerCase())return!1;for(let s=0;s<t.attributes.length;s++){const i=t.attributes[s].value;if(o(i)&&0===i.toLowerCase().indexOf("on"))return!1}for(let s=0;s<t.childNodes.length;s++)if(!c(t.childNodes[s]))return!1}return!0},h=new Map,a=new Map,l=class{constructor(s){t(this,s),this.isVisible=!1,this.mode=d(),this.lazy=!1}connectedCallback(){this.waitUntilVisible(this.el,"50px",()=>{this.isVisible=!0,this.loadIcon()})}disconnectedCallback(){this.io&&(this.io.disconnect(),this.io=void 0)}waitUntilVisible(t,s,i){if(this.lazy&&"undefined"!=typeof window&&window.IntersectionObserver){const n=this.io=new window.IntersectionObserver(t=>{t[0].isIntersecting&&(n.disconnect(),this.io=void 0,i())},{rootMargin:s});n.observe(t)}else i()}loadIcon(){if(this.isVisible){const t=r(this);t&&(h.has(t)?this.svgContent=h.get(t):(t=>{let s=a.get(t);return s||(s=fetch(t).then(s=>{if(s.ok)return s.text().then(s=>{h.set(t,(t=>{if(t){const s=document.createElement("div");s.innerHTML=t;for(let t=s.childNodes.length-1;t>=0;t--)"svg"!==s.childNodes[t].nodeName.toLowerCase()&&s.removeChild(s.childNodes[t]);const i=s.firstElementChild;if(i&&"svg"===i.nodeName.toLowerCase()){const t=i.getAttribute("class")||"";if(i.setAttribute("class",(t+" s-ion-icon").trim()),c(i))return s.innerHTML}}return""})(s))});h.set(t,"")}),a.set(t,s)),s})(t).then(()=>this.svgContent=h.get(t)))}if(!this.ariaLabel){const t=e(this.name,this.icon,this.mode,this.ios,this.md);t&&(this.ariaLabel=t.replace(/\-/g," "))}}render(){const t=this.mode||"md",n=this.flipRtl||this.ariaLabel&&this.ariaLabel.indexOf("arrow")>-1&&!1!==this.flipRtl;return s(i,{role:"img",class:Object.assign(Object.assign({[t]:!0},f(this.color)),{[`icon-${this.size}`]:!!this.size,"flip-rtl":!!n&&"rtl"===this.el.ownerDocument.dir})},s("div",this.svgContent?{class:"icon-inner",innerHTML:this.svgContent,style:{height:"100%"}}:{class:"icon-inner"}))}static get assetsDirs(){return["svg"]}get el(){return n(this)}static get watchers(){return{name:["loadIcon"],src:["loadIcon"],icon:["loadIcon"]}}static get style(){return":host{display:inline-block;width:100%;height:100%;contain:strict;fill:currentColor;-webkit-box-sizing:content-box!important;box-sizing:content-box!important}:host .stroke{stroke:currentColor}.ionicon-fill-none{fill:none}.ionicon-stroke-width{stroke-width:32px;stroke-width:var(--ionicon-stroke-width,32px)}.icon-inner,.ionicon{display:block;height:100%;width:100%}:host(.flip-rtl) .icon-inner{-webkit-transform:scaleX(-1);transform:scaleX(-1)}:host(.icon-small){font-size:18px!important}:host(.icon-large){font-size:32px!important}:host(.ion-color){color:var(--ion-color-base)!important}:host(.ion-color-primary){--ion-color-base:var(--ion-color-primary,#3880ff)}:host(.ion-color-secondary){--ion-color-base:var(--ion-color-secondary,#0cd1e8)}:host(.ion-color-tertiary){--ion-color-base:var(--ion-color-tertiary,#f4a942)}:host(.ion-color-success){--ion-color-base:var(--ion-color-success,#10dc60)}:host(.ion-color-warning){--ion-color-base:var(--ion-color-warning,#ffce00)}:host(.ion-color-danger){--ion-color-base:var(--ion-color-danger,#f14141)}:host(.ion-color-light){--ion-color-base:var(--ion-color-light,#f4f5f8)}:host(.ion-color-medium){--ion-color-base:var(--ion-color-medium,#989aa2)}:host(.ion-color-dark){--ion-color-base:var(--ion-color-dark,#222428)}"}},d=()=>document.documentElement.getAttribute("mode")||"md",f=t=>t?{"ion-color":!0,[`ion-color-${t}`]:!0}:null;export{l as bs_icon};