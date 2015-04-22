$(document).ready(function () {
    $('input[ng-model="dirCtrl.directory.Name"').on('input', function () {
        var $this = $(this);
        if ($this.val()) {
            $('.directory-new').show();
            $('.add-dir-btn').prop('disabled', false);
        } else {
            $('.directory-new').hide();
            $('.add-dir-btn').prop('disabled', true);
        }

    });
});