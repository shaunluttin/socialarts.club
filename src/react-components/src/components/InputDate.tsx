document
  .querySelectorAll("input[type='date']")
  .forEach((domContainer: HTMLInputElement) => {
    domContainer.valueAsDate = new Date();
  });
