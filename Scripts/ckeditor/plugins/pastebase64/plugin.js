(function () {
    'use strict';

    CKEDITOR.plugins.add('pastebase64', {
        init: init
    });

    function init(editor) {
        if (editor.addFeature) {
            editor.addFeature({
                allowedContent: 'img[alt,id,!src]{width,height};'
            });
        }

        editor.on("contentDom", function () {
            var editableElement = editor.editable ? editor.editable() : editor.document;
            editableElement.on("paste", onPaste, null, { editor: editor });
        });


    }

    function onPaste(event) {
        //alert('In pastebase64 onpaste method')


        var editor = event.listenerData && event.listenerData.editor;
        var $event = event.data.$;
        var clipboardData = $event.clipboardData;
        var found = false;
        var imageType = /^image/;

        if (!clipboardData) {
            return;
        }

        return Array.prototype.forEach.call(clipboardData.types, function (type, i) {
            //console.log(type + " log_pastebase64");
            if (found) {
                return;
            }
            if (type.match(imageType) || clipboardData.items[i].type.match(imageType)) {

                readImageAsBase64(clipboardData.items[i], editor);
                return found = true;
            }
        });
    }

    //function readImageAsBase64(item, editor) {
    //    if (!item || typeof item.getAsFile !== 'function') {
    //        return;
    //    }

    //    var file = item.getAsFile();
    //    var reader = new FileReader();
    //    try {
    //        reader.onload = function (evt) {
    //            var element = editor.document.createElement('img', {
    //                attributes: {
    //                    src: evt.target.result
    //                }
    //            });

    //            // We use a timeout callback to prevent a bug where insertElement inserts at first caret
    //            // position
    //            setTimeout(function () {
    //                editor.insertElement(element);
    //            }, 10);
    //        };

    //        reader.readAsDataURL(file);
    //    }
    //    catch(e)
    //    {

    //        var rd = event.clipboardData.getData('text/rtf');
    //        $.ajax({
    //            type: "POST",
    //            contentType: 'application/json',
    //            url: "/DemoPaper.aspx/GetHtmlfromRTFStr",
    //            dataType: 'json',
    //            data: JSON.stringify({ 'RTFString': rd }),
    //            success: function (data) {
    //                //txt.value = data;
    //                //alert(data);                    
    //                var element = editor.document.createElement('div');


    //                element.innerHtml = data;

    //                // We use a timeout callback to prevent a bug where insertElement inserts at first caret
    //                // position
    //                setTimeout(function () {
    //                    editor.insertElement(element);
    //                }, 10);
    //            }

    //        });
    //    }
    //}


    //function readImageAsBase64(item, editor) {
    //    if (!item || typeof item.getAsFile !== 'function') {
    //        return;
    //    }

    //    var file = item.getAsFile();
    //    var reader = new FileReader();
    //    var drtf = event.clipboardData.getData('text/rtf');
    //    $("#dialog-confirm").dialog({
    //        resizable: false,
    //        height: "auto",
    //        width: 400,
    //        modal: true,
    //        buttons: {
    //            "Content With Images": function () {
    //                reader.onload = function (evt) {
    //                    var element = editor.document.createElement('img', {
    //                        attributes: {
    //                            src: evt.target.result
    //                        }
    //                    });

    //                    // We use a timeout callback to prevent a bug where insertElement inserts at first caret
    //                    // position
    //                    setTimeout(function () {
    //                        editor.insertElement(element);
    //                    }, 10);
    //                };
    //                //reader.onerror = function (event) {
    //                //    $(this).dialog("close");
    //                //    reader.abort();
    //                //};
    //                try {
    //                    reader.readAsDataURL(file);
    //                } catch (e) {
    //                    $(this).dialog("close");
    //                }
    //                console.log(CKEDITOR.instances.ckStudentAnswer.document.getById("vu-paste"));
    //                CKEDITOR.instances.ckStudentAnswer.document.getById("vu-paste").removeAttribute("id");
    //                $(this).dialog("close");

    //            },
    //            "Content With Images and Equation": function () {
    //                var rd = drtf;
    //                //rd = "asd";
    //                if (drtf == "") {
    //                    alert("We do not found equation in copied content");
    //                    $(this).dialog("close");
    //                    return;
    //                }
    //                //$(this).dialog("close");
    //                //return;
    //                $.ajax({
    //                    type: "POST",
    //                    //contentType: "text/plain",
    //                    //contentType: 'application/json',
    //                    //contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
    //                   //url: "/DemoPaper.aspx/GetHtmlfromRTFStr",
    //                    url: "/DemoPaper.aspx",
    //                    //headers: {
    //                    //    'Access-Control-Allow-Origin': '*'
    //                    //},

    //                    //dataType: 'json',
    //                  //data: JSON.stringify({ 'RTFString': rd }),
    //                    data: { rtfdata:rd},
    //                    success: function (data) {
    //                        //txt.value = data;
    //                        //alert(data);  
    //                        //console.log(data);

    //                        CKEDITOR.instances.ckStudentAnswer.document.getById("vu-paste").remove();
    //                        //CKEDITOR.instances.ckStudentAnswer.lockSelection(CKEDITOR.instances.ckStudentAnswer.getSelection());
    //                        //CKEDITOR.instances.ckStudentAnswer.insertHtml("<p>" + data.d + "</p>");

    //                        CKEDITOR.instances.ckStudentAnswer.insertHtml("<p>" + data + "</p>");

    //                        //var element = editor.document.createElement('div');


    //                        //element.innerHtml = data;

    //                        //// We use a timeout callback to prevent a bug where insertElement inserts at first caret
    //                        //// position
    //                        //setTimeout(function () {
    //                        //    editor.insertElement(element);
    //                        //}, 10);
    //                    }

    //                });
    //                $(this).dialog("close");

    //            }
    //        }
    //    });


    //}


    function readImageAsBase64(item, editor) {
        if (!item || typeof item.getAsFile !== 'function') {
            return;
        }
        if (rtfFound) {
            return;
        }

        var file = item.getAsFile();
        if (file != null) {
            //return true;
            var reader = new FileReader();

            reader.onload = function (evt) {
                var element = editor.document.createElement('img', {
                    attributes: {
                        src: evt.target.result
                    }
                });

                // We use a timeout callback to prevent a bug where insertElement inserts at first caret
                // position
                setTimeout(function () {
                    editor.insertElement(element);
                }, 10);
            };

            reader.readAsDataURL(file);

        }
        
    }

})();
