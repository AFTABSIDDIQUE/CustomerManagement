$(function () {
    // These values will be injected by Razor into a script tag
    if (typeof toastrMessages !== 'undefined') {
        if (toastrMessages.success) {
            toastr.success(toastrMessages.success);
        }
        if (toastrMessages.error) {
            toastr.error(toastrMessages.error);
        }
        if (toastrMessages.info) {
            toastr.info(toastrMessages.info);
        }
        if (toastrMessages.warning) {
            toastr.warning(toastrMessages.warning);
        }
    }

    // Optional Toastr Settings
    toastr.options = {
        "closeButton": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "timeOut": "4000"
    };
});
