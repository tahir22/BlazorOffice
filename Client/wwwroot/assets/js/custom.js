﻿

var states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California',
    'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii',
    'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana',
    'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota',
    'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire',
    'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
    'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island',
    'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
    'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'
];
window.autoComplete = (Id) => {
    var substringMatcher = function (strs) {

        return function findMatches(q, cb) {
            var matches, substringRegex;

            // an array that will be populated with substring matches
            matches = [];

            // regex used to determine if a string contains the substring `q`
            substrRegex = new RegExp(q, 'i');

            // iterate through the pool of strings and for any string that
            // contains the substring `q`, add it to the `matches` array
            $.each(strs, function (i, str) {
                if (substrRegex.test(str)) {
                    matches.push(str);
                }
            });

            cb(matches);
        };
    };

    $('#' + Id).typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    }, {
        // name: JSON.parse(values),
        name: 'source',
        source: substringMatcher(states)
    });
};

window.select2Component = {
    init: function (Id, modalId) {
        if (modalId === undefined || modalId === null) {
            $('#' + Id).select2({ width: '100%' });
        } else {
            $('#' + Id).select2({
                width: '100%',
                dropdownParent: $('#' + modalId)
            });
        }
    },
    onChange: function (id, dotnetHelper, nameFunc) {
        //alert(nameFunc)
        $('#' + id).on('change', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + id).val(), $(this).attr("data-key"));
        });
    },
    onCompanyChange: function (id, dotnetHelper, nameFunc) {
        $('#' + id).on('change', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + id).val()).then(data => {
                $.each(JSON.parse(data), function (key, entry) {
                    $('#CompanyUser_DDL').append($('<option></option>').attr('value', entry.Value).attr('disabled', entry.Disabled).text(entry.Text));
                });
            });
        });
    },
    onCompanyChangeTwo: function (id, dotnetHelper, nameFunc) {
        $('#' + id).on('change', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + id).val()).then(data => {
                $.each(JSON.parse(data), function (key, entry) {
                    $('#UserDevice_DDL').append($('<option></option>').attr('value', entry.Value).attr('disabled', entry.Disabled).text(entry.Text));
                });
            });
        });
    }
}

window.selectAjax2Component = {
    init: function (Id, modalId, ajaxUrl) {
        if (modalId === undefined || modalId === null) {
            $('#' + Id).select2({
                width: '100%',
                ajax: {
                    url: ajaxUrl,
                    data: function (params) {
                        var query = {
                            search: params.term,
                            type: 'public'
                        }

                        // Query parameters will be ?search=[term]&type=public
                        return query;
                    },
                    processResults: function (data) {
                        // Transforms the top-level key of the response object from 'items' to 'results'
                        return {
                            results: data
                        };
                    }
                }
            });
        } else {
            $('#' + Id).select2({
                width: '100%',
                dropdownParent: $('#' + modalId),
                ajax: {
                    url: ajaxUrl,
                    data: function (params) {
                      
                        var query = {
                            search: params.term,
                            type: 'public'
                        }

                        // Query parameters will be ?search=[term]&type=public
                        return query;
                    },
                    processResults: function (data) {
                        // Transforms the top-level key of the response object from 'items' to 'results'
                        return {
                            results: data
                        };
                    }
                }
            });
        }
    },
    onChange: function (id, dotnetHelper, nameFunc) {
        $('#' + id).on('change', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + id).val(), $(this).attr("data-key"));
        });
    }, 
}

window.KTDateTimePicker = {
    init: function (datetimeId, dotnetHelper, nameFunc) {
        $('#' + datetimeId).datetimepicker({
            todayHighlight: !0,
            autoclose: !0,
            pickerPosition: "bottom-left",
            format: "yyyy/mm/dd hh:ii",
            setDate: "2013-02-14 10:00",
        }).on("changeDate", function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + datetimeId).val());
        })
        $('#' + datetimeId).click(function () {
            $('#' + datetimeId).datetimepicker('show');
        });
    },
    set: function (datetimeId, datetimeData, dotnetHelper, nameFunc) {
        ;
        var datetime = new Date(datetimeData);
        var monthIndex = (datetime.getMonth());
        var yearIndex = datetime.getFullYear();
        var dateIndex = datetime.getDate();
        var hoursIndex = (datetime.getHours());
        var minutesIndex = (datetime.getMinutes());
        $('#' + datetimeId).datetimepicker({
            todayHighlight: !0,
            autoclose: !0,
            pickerPosition: "bottom-left",
            format: "yyyy/mm/dd hh:ii"
        });
        $('#' + datetimeId).datetimepicker("setDate", new Date(yearIndex, monthIndex, dateIndex, hoursIndex, minutesIndex)).on("changeDate", function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + datetimeId).val());
        });
        $('#' + datetimeId).click(function () {
            $('#' + datetimeId).datetimepicker('show');
        });
    }
};


// The function initialized and manages the clicks on header (small and large)
window.initializeHeader = {
    init: function () {
        $('body').click(function (e) {
            if (e.target.offsetParent?.id == 'kt_aside_mobile_toggler' || e.target?.id == 'kt_aside_mobile_toggler') {
                $('body').toggleClass("kt-aside--on");
                $('#kt_aside').toggleClass("kt-aside--on");
            } else if (e.target.parentElement?.id == 'kt_aside_toggler' || e.target?.id == 'kt_aside_toggler') {
                $('body').toggleClass("kt-aside--minimize");
                if ($("body").hasClass("kt-aside--minimize")) {
                    $("#kt_aside_toggler").css("transform", "rotate(180deg)");
                } else {
                    $("#kt_aside_toggler").css("transform", "rotate(0deg)");
                }
            }
            else {
                $('body').removeClass("kt-aside--minimize");
                $('body').removeClass("kt-aside--on");
                $('#kt_aside').removeClass("kt-aside--on");
            }
        });
    }
}

// The function initialized and manages the clicks on header (small and large)
window.datePicker = {
    init: function (id, dotnetHelper, nameFunc) {
        $('#' + id).datepicker({
            format: 'dd-mm-yyyy',
            autoclose: true,
        });
        $('#' + id).on('change', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + id).val(), $(this).attr("data-key"));

        });
    }
}

window.qrCode = {
    init: function (id, code) {
        $('#' + id).empty();
        new QRCode(document.getElementById(id), code);

    }
}

window.toast = {
    show: function (title, message, theme) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        if (theme === 'warning') {
            toastr.warning(message, title);
        }
        else {
            toastr.success(message, title)
        }
        var x = document.getElementById("myAudio");
        x.play();
    }
}

window.KTBootstrapSelect = {
    init: function ()
    {
        $('.selectpicker').selectpicker();
    }
}

window.KTTouchSpin =
{
    init: function ()
    {
        $('.num').TouchSpin({
            buttondown_class: 'btn btn-secondary',
            buttonup_class: 'btn btn-secondary',

            min: 0,
            max: 1000,
            step: 1,
            //decimals: 2,
            boostat: 5,
            maxboostedstep: 10,
        });
    }
}
