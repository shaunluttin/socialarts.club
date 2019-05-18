document
  .querySelectorAll("input[type='time']")
  .forEach((domContainer: HTMLInputElement) => {
    const date = new Date();
    const currentTime = date.getHours() + ":" + date.getMinutes();
    domContainer.value = currentTime;
  });
