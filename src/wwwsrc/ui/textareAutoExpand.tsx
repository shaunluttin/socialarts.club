let textareas = document.querySelectorAll('textarea');

if (textareas.length > 0) {
  textareas.forEach((textarea) => {
    textarea.addEventListener('keydown', autosize);
  });
}

function autosize(e) {
  const textarea = e.target;
  textarea.style.cssText = 'height:auto;';
  textarea.style.cssText = 'height:' + textarea.scrollHeight + 'px';
}
