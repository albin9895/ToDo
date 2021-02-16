var Product = {
    taskName: ""
}
var DeleteProduct = {
    id:""
}

function updateClick() {
    Product = new Object();
    Product.taskName = $("#TaskName").val();    
    if ($("#updateButton").text().trim() == "Add") {
        productAdd(Product);
    }
    else {
        productUpdate(Product);
    }
}
function productAdd(product) {
    $.ajax({
        url: "https://localhost:44327/api/ToDo",
        type: 'POST',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(product),
        success: function (product) {
            productAddSuccess(product);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}
function productAddSuccess(product) {
    productAddRow(product);
    formClear();
}
function formClear() {
    $("#taskname").val("");
   
}
function addClick() {
    formClear();
}

function productUpdate(product) {
    $.ajax({
        url: "https://localhost:44327/api/ToDo",
        type: 'PUT',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(product),
        success: function (product) {
            productUpdateSuccess(product);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}
function productUpdateSuccess(product) {
    productUpdateInTable(product);
}

function productUpdateInTable(product) {
   
    var row = $("#toDoTable button[data-id='" + product.id + "']").parents("tr")[0];   
    $(row).after(productBuildTableRow(product));
    $(row).remove();
    formClear();      
    $("#updateButton").text("Add");
}

function productDelete(ctl) {
    var id = $(ctl).data("id");

    $.ajax({
        url: "https://localhost:44327/api/ToDo",
        type: 'DELETE',
        data: id,
        success: function (product) {
            $(ctl).parents("tr").remove();
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}





function productList() {
    
    $.ajax({
        url: 'https://localhost:44327/api/ToDoList',
        type: 'GET',
        dataType: 'json',
        success: function (products) {
            productListSuccess(products);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function productListSuccess(products) {
    
    $.each(products, function (index, product) {
       
        productAddRow(product);
    });
}
function productAddRow(product) {
   
    if ($("#toDoTable tbody").length == 0) {
        $("#toDoTable").append("<tbody></tbody>");
    }
    
    $("#toDoTable tbody").append(
        productBuildTableRow(product));
}
function productBuildTableRow(product) {
    var ret =
        "<tr>" +
        "<td>" +
        "<button type='button' " +
        "onclick='productGet(this);' " +
        "class='btn btn-default' " +
        "data-id='" + product.id + "'>" +
        "<span class='glyphicon glyphicon-remove'</span> Edit" +
        "</button>" +
        "</td>" +        

        "<td>" + product.taskName + "</td>" +
        "<td>" + product.createdAt + "</td>"+  

        "<td>" +
        "<button type='button' " +
        "onclick='productDelete(this);' " +
        "class='btn btn-default' " +
        "data-id='" + product.id + "'>" +
        "<span class='glyphicon glyphicon-remove'</span> Delete" +
        "</button>" +
        "</td>" 
        "</tr>";
    return ret;
}
function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    alert(msg);
}
