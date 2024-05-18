var slides = document.querySelectorAll('.slide-invisible');

slides.forEach(function(slide) {
  var filmInfoContainer = slide.querySelector('.film-info-container');

  if (filmInfoContainer) {
    var observer = new MutationObserver(function(mutationsList) {
      mutationsList.forEach(function(mutation) {
        if (mutation.type === 'attributes' && mutation.attributeName === 'class') {
          if (slide.classList.contains('slide-visible')) {
            filmInfoContainer.classList.add('your-custom-class');
          } else {
            filmInfoContainer.classList.remove('your-custom-class');
          }
        }
      });
    });

    observer.observe(slide, { attributes: ['class'] });
  }
});