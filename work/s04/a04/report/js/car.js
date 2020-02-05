
"use strict";

(function () {
  var element = document.getElementById('car')

  element.addEventListener('click', function(){
       element.style.left = element.offsetLeft + 20 + 'px'
  })
    
  console.log(element)
  console.log('car ready')   
})();