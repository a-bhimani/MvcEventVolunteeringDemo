function NumValidation(e) { var a = (e.keyCode) ? e.keyCode : e.which; return ((a == 8) || (a == 9) || (a == 37) || (a == 39) || (a == 46) || ((a > 47) && (a <= 58))) }

window.addLoadEvent(function () {
	$('body').on('keypress', 'input.numeric', function (e) {
		return NumValidation(e);
	});

	$("body").on("focusin", "input.datebox:text", function () {
		if (!($(this).val())) {
			var toDate = (new Date());
			//$(this).is(":data(datepicker)") || $(this).datepicker();
			//$(this).val((toDate.getMonth() + 1) + '/' + toDate.getDate() + '/' + toDate.getFullYear());
		}
	});
});

$(document).on("keyup", "textarea", function () {
	var t = 255;
	t = $(this).attr("data-maxlen") ? $(this).attr("data-maxlen") : t, $(this).val($(this).val().substr(0, t).replace(/\s{2,}/g, " "));
}).on("change", "textarea", function () {
	$(this).keyup();
});

$(document).ready(function () {
	try {
		if ($('input.datebox').length > 0) {
			$('input.datebox').attr('readonly', true);
			$.datepicker.setDefaults({
				changeMonth: true,
				changeYear: true,
				minDate: "-100Y",
				maxDate: "-0",
				dateFormat: "mm/dd/yy",
				yearRange: "-80:-0",
				showAnim: "fadeIn",
				onSelect: function (selectedDate) { if ($(this).attr('onchange')) eval($(this).attr('onchange')); }
			});
			//$('body').on('focusin', 'input.datebox:text', function(){
			$('input.datebox:text').bind('focusin', function () {
				if ($(this).hasClass('datebox_ltrace')) {
					$(this).datepicker('option', 'disabled', true)
							.datepicker("destroy")
							.removeClass("hasDatepicker")
							.removeClass('datebox')
							.removeClass('datebox_ltrace')
							.unbind('focusin')
							.focusin(function (e) { e.preventDefault(); });
				} else {
					if (!$(this).is(':data(datepicker)')) {
						if ($(this).hasClass('bdate')) {
							if (!($(this).hasClass('child'))) {
								$(this).datepicker("destroy");
								$(this).datepicker({ maxDate: "-18Y", yearRange: "-65:-18" });
								$(this).datepicker("refresh");
							}
						}
						if ($(this).hasClass('xdate')) {
							$(this).datepicker("destroy");
							$(this).datepicker({ maxDate: "+15Y", yearRange: "-15:+15" });
							$(this).datepicker("refresh");
						}
						if ($(this).hasClass('month-only')) {
							$(this).datepicker("destroy");
							$(this).datepicker({
								dateFormat: "mm/yy",
								yearRange: "-65",
								showButtonPanel: true,
								beforeShow: function (input, inst) {
									if ($(this).datepicker('getDate')) {

									}
								},
								onClose: function (date) {
									var M = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
									var yy = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
									$(this).datepicker('option', 'defaultDate', new Date(yy, M, 1))
												.datepicker('setDate', $(this).datepicker('option', 'defaultDate'));
								}
							});
							$(this).datepicker("refresh");
							$(this).focus(function () {
								$(".ui-datepicker-calendar").detach();
								$("#ui-datepicker-div").position({
									my: "center top",
									at: "center bottom",
									of: $(this)
								});
							});
						}
						$(this).datepicker();
					}
				}
				return;
			});
		}
	} catch (ex) {; }
});

