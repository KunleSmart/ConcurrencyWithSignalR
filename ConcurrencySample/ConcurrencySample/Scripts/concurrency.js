$(function () {
    var hub = $.connection.concurencyHub;
    var timeout = null;
    var interval = 10000;

    $.extend(hub, {
        itemUpdated: function (result, pry) {
            var id = parseInt($("#" + pry).val());
            var ts = $("#Timestamp").val();

            if ($.attr(result, pry) == id && result.Timestamp != ts) {
                $.modal('<div id="concurrency-modal"><p>This record has been modified or deleted in another instance and thus may not be updated. You may reload this page to try again.</p><p>You may also click on \'log\' to view the update history.</p><hr /><div id="close-concurrency"> OK</div></div>',
                        {
                            modal: true,
                            closeHTML: '',
                            backgroundColor: "#fff",
                            borderColor: "#fff",
                            padding: 0,
                            overlayClose: false
                        }
                );

                $("#close-concurrency").click(function () {
                    $.modal.close();
                });
            }
        }
    });

    $.connection.hub.start();
});
