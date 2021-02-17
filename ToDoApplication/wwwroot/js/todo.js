var Product = {
    taskName: "",
    id:""
}
var DeleteProduct = {
    id:""
}

var id = 0;

function productToFields(product) {
    var taskName = product[0].taskName
    $("#taskName").val(taskName);
    id = product[0].id;
    
}

function refreshPage() {
    location.reload();
}


function updateClick() {
    Product = new Object();
    Product.taskName = $("#taskName").val();    
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
            refreshPage();
            productAddSuccess(product);
            refreshPage();
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

function productGet(ctl) {    
    var id = $(ctl).data("id");    
    $("#productid").val(id);    
    $.ajax({
        url: "https://localhost:44327/api/ToDoList/" + id,
        type: 'GET',
        dataType: 'json',
        success: function (product) {
            productToFields(product);            
            $("#updateButton").text("Update");
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function productUpdate(product) {    
    $.ajax({
        url: "https://localhost:44327/api/ToDo/"+id,
        type: 'PUT',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(product),
        success: function (product) {            
            productUpdateSuccess(product);
            refreshPage();
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
    DeleteProduct.id = id;
    $.ajax({
        url: "https://localhost:44327/api/ToDo",
        type: 'DELETE',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(DeleteProduct),
        success: function (DeleteProduct) {
            $(ctl).parents("tr").remove();
            refreshPage();
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
    var d = product.createdAt;
    d = d.split('T')[0];
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
       
        "<td>" + d + "</td>"+  

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
