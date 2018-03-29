//'use strict';

//; (function (document, window, index) {
//    var inputs = document.querySelectorAll('.inputfile');
//    Array.prototype.forEach.call(inputs, function (input) {
//        var label = input.nextElementSibling,
//            labelVal = label.innerHTML;

//        input.addEventListener('change', function (e) {
//            var fileName = '';
//            if (this.files && this.files.length > 1)
//                fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
//            else
//                fileName = e.target.value.split('\\').pop();

//            if (fileName)
//                label.querySelector('span').innerHTML = fileName;
//            else
//                label.innerHTML = labelVal;
//        });
//        // Firefox bug fix
//        input.addEventListener('focus', function () { input.classList.add('has-focus'); });
//        input.addEventListener('blur', function () { input.classList.remove('has-focus'); });
//    });
//}(document, window, 0));

//var data = new FormData();
//JQuery.each(JQuery('#file-5')[0].files, function (i, file) {
//  data.append('file-5-' + i, file)
//});
//function saveData() {
//  jQuery.ajax({
//    url: '/Home/SaveText',
//    data: data,
//    cache: false,
//    contentType: false,
//    processData: false,
//    method: 'POST',
//    type: 'POST', // For jQuery < 1.9
//    success: function (data) {
//      debugger;
//      //alert(data);
//    }
//  });
//}

document.getElementById('uploader').onsubmit = function () {
  var formdata = new FormData();
  var fileInput = document.getElementById('fileInput');
  var word = $('#word').val();
  var url = '/Home/Upload?word=' + word;
  for (i = 0; i < fileInput.files.length; i++) {
    formdata.append(fileInput.files[i].name, fileInput.files[i]);
  }
  //Creating an XMLHttpRequest and sending
  var xhr = new XMLHttpRequest();
  xhr.open('POST', url);
  xhr.send(formdata);
  xhr.onreadystatechange = function () {
    if (xhr.readyState == 4 && xhr.status == 200) {
      alert(xhr.responseText);
      location.reload();
    }
  }
  return false;
}

