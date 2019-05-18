/**
 * Credit to https://stackoverflow.com/a/25621277/1108891
 */

function onInput(this: HTMLTextAreaElement) {
  this.style.height = "auto";
  this.style.height = `${this.scrollHeight}px`;
}

document
  .querySelectorAll("textarea")
  .forEach((domContainer: HTMLTextAreaElement) => {
    console.debug(domContainer);

    domContainer.setAttribute(
      "style",
      `height: ${domContainer.scrollHeight} px;overflow-y:hidden;`
    );

    domContainer.addEventListener("input", onInput, false);
  });
