function showAddModal(sender) {
    let sendingUrl = $(sender).attr("data-action");
    $.get(sendingUrl, null, function (rd) {
        $("#dvContent").html(rd);
        $("#myModal").modal('show');
    });
}

function AddNewItem(sender) {
    let sendingUrl = $(sender).attr("data-action");
    let BindGridAction = $(sender).attr("data-action-BindGrid");
    let RefreshGridAction = $(sender).attr("data-action-RefreshGrid");
    let form = "#" + $(sender).attr("data-form");
    let sendingData = $(form).serialize();

    $.post(sendingUrl, sendingData, function (op) {
        if (op.success.toString() == "true") {
            $("#myModal").modal("hide");
            SuccessMessage(op.message);
            BindGrid(BindGridAction);
            RefreshSearchBox(RefreshGridAction);
        }
        else {
            ErrorMessage(op.message);
        }
    });
}

function Delete(sender) {

    var name = $(this).attr("data-name");
    if (confirm(`آیا از حذف ${name} مطمئن هستید ؟`)) {
        var id = $(this).attr("data-id");
        var sendingData = "id=" + id;
        let sendingUrl = $(sender).attr("data-action");

        let BindGridAction = $(sender).attr("data-action-BindGrid");
        let RefreshGridAction = $(sender).attr("data-action-RefreshGrid");
        $.post(sendingUrl, sendingData, function (op) {
            if (op.success.toString() == "true") {
                var rowID = "#tr_" + id;
                $(rowID).slideUp(500);
                BindGrid(BindGridAction);
                RefreshSearchBox(RefreshGridAction);
            }
            else {
                ErrorMessage(op.message);
            }
        });
    }


}


function BindGrid(action) {

    console.log("-------");
    console.log(action);
    console.log("-------");

    var sendingData = $("#frmSearch").serialize();;
    $.get(action, sendingData, function (grd) {
        $("#dvContentList").html(grd);
    });
};
function RefreshSearchBox(action) {
    var sendingUrl = action;
    var sendingData = $("#frmSearch").serialize();
    $.get(sendingUrl, sendingData, function (frmSearch) {
        $("#dvSearchBox").html(frmSearch);
    });
}


$(document).on("keyup", "#UserName", function () {
    BindGrid();
});
$(document).on("keyup", "#FirstName", function () {
    BindGrid();
});
$(document).on("keyup", "#LastName", function () {
    BindGrid();
});
$(document).on("change", "#RoleID", function () {
    BindGrid();
});

$(document).on("keyup", "#ProjectActionName", function () {
    BindGrid();
});
$(document).on("keyup", "#PersianTitle", function () {
    BindGrid();
});
$(document).on("change", "#ProjectControllerID", function () {
    BindGrid();
});

function SuccessMessage(SuccessTxt) {
    Swal.fire({
        icon: 'success',
        title: 'وضعیت ثبت',
        text: SuccessTxt,
    });
}
function ErrorMessage(ErrorTxt) {
    Swal.fire({
        icon: 'error',
        title: 'خطا',
        text: ErrorTxt,
    });
}

