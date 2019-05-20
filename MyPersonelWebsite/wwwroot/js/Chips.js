$(".chips").click(function () {
    $(this).remove();
});

$(".chips-input").click(function () {
    $('.chips-input input[name="Tag"],input[name="User"]').focus();
});

$(document).on("keydown", "input[name='Tag'], input[name='User']", function (e) {
    if ($(document.activeElement).is('.chips-input input') && e.keyCode == 9) {
        let value = $('.chips-input input').val();
        if (value != "") {
            let d = true;

            $(".chips-input .chipsSpace a").each(function () {
                if ($(this).attr("data-value") == value) {
                    d = false;
                }
            });
            if (d) {
                var $input = $(this),
                    val = $input.val();
                list = $input.attr('list'),
                    match = $('#' + list + ' option').filter(function () {
                        return ($(this).val() === val);
                    });
                if ($(this).attr("name") === "User" && match.length > 0) {
                    $('.chips-input .chipsSpace input[name="User"]').before(
                        "<a class='chips' data-value='" + value + "'>" + value + " <span class='fas fa-times'></span></a>"
                    );
                    console.log(match.length);
                }
                else {
                    $('.chips-input .chipsSpace input[name="Tag"]').before(
                        "<a class='chips' data-value='" + value + "'>" + value + " <span class='fas fa-times'></span></a>"
                    );
                }
                $(document).on("click", ".chips", function () {
                    $(this).remove();
                });
            }

            $('.chips-input input').val("");
        }
        return false;
    }
});

$("input[name='Tag'], input[name='User']").focusin(function () {
    $(this).parents(".chips-input").addClass("infocus");
}).focusout(function () {
    $(this).parents(".chips-input").removeClass("infocus");
});