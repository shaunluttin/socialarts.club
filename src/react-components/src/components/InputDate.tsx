document
  .querySelectorAll("input[type='date']")
  .forEach((domContainer: HTMLInputElement) => {
    const date = new Date();
    const currentDate = date.toISOString().slice(0, 10);
    domContainer.value = currentDate;
  });
