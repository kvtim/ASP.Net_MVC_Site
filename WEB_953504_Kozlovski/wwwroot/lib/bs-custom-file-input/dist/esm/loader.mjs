import { a as patchEsm, b as bootstrapLazy } from './core-f572c876.js';

const defineCustomElements = (win, options) => {
  return patchEsm().then(() => {
    bootstrapLazy([["bs-icon",[[1,"bs-icon",{"mode":[1025],"color":[1],"ariaLabel":[1537,"aria-label"],"ios":[1],"md":[1],"flipRtl":[4,"flip-rtl"],"name":[1],"src":[1],"icon":[8],"size":[1],"lazy":[4],"svgContent":[32],"isVisible":[32]}]]]], options);
  });
};

export { defineCustomElements };
