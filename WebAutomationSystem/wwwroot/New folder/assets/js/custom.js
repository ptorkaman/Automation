function makeDatePicker() {
    $(".datetimepicker:not(.pwt-datepicker-input-element)").each(function () {
        $(this).pDatepicker({
            "initialValueType": 'gregorian',
            "inline": false,
            "format": "YYYY/MM/DD",
            "viewMode": "day",
            "initialValue": !!$(this).val(),
            "minDate": null,
            "maxDate": null,
            "autoClose": false,
            "position": "auto",
            "onlyTimePicker": false,
            "onlySelectOnDate": false,
            "calendarType": "persian",
            "inputDelay": 800,
            "observer": true,
            "persianDigit": false,
            "calendar": {
                "persian": {
                    "locale": "en",
                    "showHint": false,
                    "leapYearMode": "algorithmic"
                },
                "gregorian": {
                    "locale": "en",
                    "showHint": false
                }
            },
            "navigator": {
                "enabled": true,
                "scroll": {
                    "enabled": true
                },
                "text": {
                    "btnNextText": ">",
                    "btnPrevText": "<"
                }
            },
            "toolbox": {
                "enabled": true,
                "calendarSwitch": {
                    "enabled": true,
                    "format": "MMMM"
                },
                "todayButton": {
                    "enabled": true,
                    "text": {
                        "fa": "امروز",
                        "en": "امروز"
                    }
                },
                "submitButton": {
                    "enabled": true,
                    "text": {
                        "fa": "تایید",
                        "en": "تایید"
                    }
                },
                "text": {
                    "btnToday": "امروز"
                }
            },
            "timePicker": {
                "enabled": false,
                "step": "1",
                "hour": {
                    "enabled": true,
                    "step": null
                },
                "minute": {
                    "enabled": true,
                    "step": null
                },
                "second": {
                    "enabled": false,
                    "step": null
                },
                "meridian": {
                    "enabled": false
                }
            },
            "dayPicker": {
                "enabled": true,
                "titleFormat": "YYYY MMMM"
            },
            "monthPicker": {
                "enabled": true,
                "titleFormat": "YYYY"
            },
            "yearPicker": {
                "enabled": true,
                "titleFormat": "YYYY"
            },
            "responsive": true
        });
    });
}

function makeDatePickerGeorgian() {
    $(".datetimepickerGeorgian:not(.pwt-datepicker-input-element)").each(function () {
        $(this).pDatepicker({
            "initialValueType": 'gregorian',
            "inline": false,
            "format": "MM/DD/YYYY",
            "viewMode": "day",
            "initialValue": !!$(this).val(),
            "minDate": null,
            "maxDate": null,
            "autoClose": false,
            "position": "auto",
            "onlyTimePicker": false,
            "onlySelectOnDate": false,
            "calendarType": "gregorian",
            "inputDelay": 800,
            "observer": true,
            "persianDigit": false,
            "calendar": {
                "persian": {
                    "locale": "en",
                    "showHint": false,
                    "leapYearMode": "algorithmic"
                },
                "gregorian": {
                    "locale": "en",
                    "showHint": false
                }
            },
            "navigator": {
                "enabled": true,
                "scroll": {
                    "enabled": true
                },
                "text": {
                    "btnNextText": ">",
                    "btnPrevText": "<"
                }
            },
            "toolbox": {
                "enabled": true,
                "calendarSwitch": {
                    "enabled": true,
                    "format": "MMMM"
                },
                "todayButton": {
                    "enabled": true,
                    "text": {
                        "fa": "امروز",
                        "en": "امروز"
                    }
                },
                "submitButton": {
                    "enabled": true,
                    "text": {
                        "fa": "تایید",
                        "en": "تایید"
                    }
                },
                "text": {
                    "btnToday": "امروز"
                }
            },
            "timePicker": {
                "enabled": false,
                "step": "1",
                "hour": {
                    "enabled": true,
                    "step": null
                },
                "minute": {
                    "enabled": true,
                    "step": null
                },
                "second": {
                    "enabled": false,
                    "step": null
                },
                "meridian": {
                    "enabled": false
                }
            },
            "dayPicker": {
                "enabled": true,
                "titleFormat": "YYYY MMMM"
            },
            "monthPicker": {
                "enabled": true,
                "titleFormat": "YYYY"
            },
            "yearPicker": {
                "enabled": true,
                "titleFormat": "YYYY"
            },
            "responsive": true
        });
    });
}


$(document).ready(function () {
    makeDatePicker();

});

$(document).ready(function () {
    makeDatePickerGeorgian();
   
});



$(".custom-file-input").change(function () {
    let fileUpload = $(this).get(0);
    let files = fileUpload.files;
    let fileName = "";
    let label = $(this).siblings(".custom-file-label");

    for (let i = 0; i < files.length; i++) {
        fileName += files[i].name + ", ";
    }

    if (fileName) {
        label.text(fileName.slice(0, -2));
    } else {
        label.text("انتخاب کنید");
    }
});

$('.excelBtn').click(function () {
    let btn = $(this);
    window.open(btn.attr("data-url") + "?" + getQueryStringFromForm(document.getElementById(btn.attr("data-formId"))), '_blank').focus();
});

function getQueryStringFromForm(form) {
    const formData = new FormData(form);

    let parameters = []
    for (let pair of formData.entries()) {
        if (pair[1]) {
            parameters.push(encodeURIComponent(pair[0]) + '=' + encodeURIComponent(pair[1]));
        }
    }

    return parameters.join('&');
}


$(function () {
    $('.search-form').submit(function () {
        $(this).find(':input').each(function () {
            let inp = $(this);
            if (!inp.val()) {
                inp.remove();
            } else {
                inp.attr("name", inp.attr("name").replace("SearchModel.", ""));
            }
        });
    });
});

$(function () {
    $(".prices").on('keyup focus', function () {
        var currentValue = $(this).val();

        var newValue = numberWithCommas(currentValue);

        $(this).val(newValue);
    });
    $(".prices").show( function () {
        var currentValue = $(this).val();

        var newValue = numberWithCommas(currentValue);

        $(this).val(newValue);
    });
});

//$(function () {
//    $(".richTextEditor").summernote({
//        placeholder: 'متن مورد نظر را وارد کنید',
//        lang: 'fa-IR',
//        height: 200,
//        toolbar:
//            [
//                ['style', ['underline']],
//            ]
//    });;
//});

//function ConfirmModal(refrenceId, status, action, controller) {
//    $("#ReferenceId").val(refrenceId);
//    $("#Status").val(status);
//    $("#modalForm").attr('action', '/' + controller + '/' + action + '');

//    $('#confirmModal').modal('show');
//};


function ConfirmModalTamdidServiceOrder(refrenceId, statusId, action, controller, flagShowCombo, submitBtnText, submitBtnClass, message, title = "") {

    console.log("confirmModal2");

    $("#ReferenceId").val(refrenceId);
    $("#StatusId").val(statusId);

    $("#modalForm").attr('action', '/' + controller + '/' + action + '');

    $("#SubmitBtn").text(submitBtnText);

    $("#SubmitBtn").removeClass();

    $("#SubmitBtn").addClass(submitBtnClass);

    $("#Message").html('');
    $("#Message").append(message);

    console.log("confirmModal");

    if (title != "") {
        $("#title").html('');
        $("#title").append("<strong>" + title + "</strong>");
    }

    if (flagShowCombo == true) {
        $("#Flag").removeAttr('hidden');
    }
    else {
        $("#Flag").attr('hidden', 'hidden');
    }
    console.log("confirmModal666");
    $('#TamdidServiceOrder_confirmModal').modal('show');
}



function ConfirmModal(refrenceId, statusId, action, controller, flagShowCombo, submitBtnText, submitBtnClass, message, title = "", beforePage = "") {
    debugger
    console.log("confirmModal2");
    
    $("#ReferenceId").val(refrenceId);
    $("#beforePageModal").val(beforePage);
    $("#StatusId").val(statusId);

    $("#modalForm").attr('action', '/' + controller + '/' + action + '');

    $("#SubmitBtn").text(submitBtnText);

    $("#SubmitBtn").removeClass();

    $("#SubmitBtn").addClass(submitBtnClass);

    $("#Message").html('');
    $("#Message").append(message);

    console.log("confirmModal");

    if (title != "") {
        $("#title").html('');
        $("#title").append("<strong>" + title + "</strong>");
    }

    if (flagShowCombo == true) {
        $("#Flag").removeAttr('hidden');
    }
    else {
        $("#Flag").attr('hidden', 'hidden');
    }
    console.log("confirmModal666");
    $('#confirmModal').modal('show');
}


function numberWithCommas(number) {
    var parts = number.toString().split(".");
    parts[0] = parts[0].replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}

function launchParaph(refrenceId, statusId) {
    $("#referenceId").val(refrenceId);
    $("#statusId").val(statusId);

    $('#paraphModal').modal('show');
}
function launchModal1(refrenceId, controller, action, refrence) {
    
    $("#referenceId").val(refrenceId);
    $("#reference").val(refrence);
    $("#controller").val(controller);
    $("#action").val(action);
    $('#modal').modal('show');
}

!function ($) {
    //eyeOpenClass: 'fa-eye',
    //eyeCloseClass: 'fa-eye-slash',
    'use strict';

    $(function () {
        $('[data-toggle="password"]').each(function () {
            var input = $(this);
            var eye_btn = $(this).parent().find('.input-group-text');
            eye_btn.css('cursor', 'pointer').addClass('input-password-hide');
            eye_btn.on('click', function () {
                if (eye_btn.hasClass('input-password-hide')) {
                    eye_btn.removeClass('input-password-hide').addClass('input-password-show');
                    eye_btn.find('.fa').removeClass('fa-eye').addClass('fa-eye-slash')
                    input.attr('type', 'text');
                } else {
                    eye_btn.removeClass('input-password-show').addClass('input-password-hide');
                    eye_btn.find('.fa').removeClass('fa-eye-slash').addClass('fa-eye')
                    input.attr('type', 'password');
                }
            });
        });
    });

}(window.jQuery);




$(function () {

    $(':input').each(function () {
        $this = $(this);

        if ($this.attr('data-val-required') != undefined) {
            //$label = $(this).parent().find('label');
            $label = $(this).prev('label');
            //console.log("11")
            //console.log($label)
            //console.log($label.text)
            $label.append($('<span>').css('color', "red").text("*"));

        }



    });
})