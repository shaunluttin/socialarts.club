document
  .querySelectorAll("input[type='time']")
  .forEach((domContainer: HTMLInputElement) => {
    domContainer.value = "12:00";
  });
