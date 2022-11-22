let table = null;

$(document).ready(function () {
    table = $('#tableDepartment').DataTable({
        ajax: {
            url: 'https://localhost:7183/api/Departments',
            dataSrc: 'data'
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
            },
            {
                data: "Id",
                render: (data) => {
                    return data;
                },
            },
            {
                data: "Name",
                render: (data) => {
                    return data;
                }
            },
            {
                data: "DivisionId",
                render: (data) => {
                    return data;
                }
            },
            {
                data: "Id",
                render: (data) => {
                    return `
                    <a class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#editDepartmentModal" onclick="editDepartment(${data})">Edit</a> |
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#detailsDepartmentModal" onclick="showDetail(${data})"> Detail</a> |
                    <a class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#deleteDepartmentModal" onclick="showDelete(${data})">Delete</a>
                `;
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'copy', 'pdf', 'excel']
    })
})

function newDepartments() {
    let data;
    let Id = 0;
    let Name = $('#DepartmentName').val();
    let DivisionId = parseInt($('#DivisionId').val());

    data = {
        "Id": Id,
        "Name": Name,
        "DivisionId": DivisionId
    }

    console.log(data);

    $.ajax({
        url: 'https://localhost:7183/api/Departments',
        type: "POST",
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            Swal.fire(
                'DATA DITAMBAHKAN',
                '+_+_+_+_' + data,
                'success'
            );
            location.reload();
        }
    });
}

function editDepartment(Id) {
    $.ajax({
        url: `https://localhost:7183/api/Departments/GetById?Id=${Id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        
        $('#edit').html(`
        <input type = "hidden" class= "form-control" id = "hidenId" readonly placeholder = "" value = "0">
        <p> Id: <input type="text" class="form-control" id="Id" readonly placeholder="${res.data.Id}" value="${res.data.Id}">
        <p> Name: <input type="text" class="form-control" id="DeptName" placeholder="${res.data.Name}" value="${res.data.Name}">
        <p> DivisionId: <input type="text" class="form-control" id="DivisID" placeholder="${res.data.DivisionId}" value="${res.data.DivisionId}">
        `)
        console.log(res);
    }).fail((err) => {
        console.log(err);
    });
}

function updateDepartments() {
    let data;
    let Id = parseInt($('#Id').val());
    let Name = $('#DeptName').val();
    let DivisionId = parseInt($('#DivisID').val());

    data = {
        "Id": Id,
        "Name": Name,
        "DivisionId": DivisionId
    }

    console.log(data);

    $.ajax({
        url: 'https://localhost:7183/api/Departments',
        type: "PUT",
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            Swal.fire(
                'Data Diupdate',
                'sedang proses!!',
                'success'
            )
            location.reload();
        }
    });
}

function showDetail(departementId) {
    $.ajax({
        url: `https://localhost:7183/api/Departments/GetById?Id=${departementId}`,
        type: "GET"
    }).done(res => {
        console.log(res)

        let temp = '';

        $('#modalDetail').html(`
        
        <div class=" row my-2">
          <div class="col-4 text-end text-dark fw-semibold">
              ID :
          </div>
          <div class="col-8">
               <input class="form-control form-control-sm" type="text" value="${res.data.Id}" aria-label="readonly input example" readonly>
          </div>
        </div>

        <div class="row my-2">
          <div class="col-4 text-end text-dark fw-semibold">
              Nama :
          </div>
          <div class="col-8 text-capitalize">
              <input class="form-control form-control-sm" type="text" value="${res.data.Name}" aria-label="readonly input example" readonly>
          </div>
        </div>

        <div class="row my-2">
          <div class="col-4 text-end text-dark fw-semibold">
              Division ID :
          </div>
          <div class="col">
               <input class="form-control form-control-sm" type="text" value="${res.data.DivisionId}" aria-label="readonly input example" readonly>
          </div>
        </div>
    
                `)
    }).fail(err => {
        console.log(err)
    })
}

function showDelete(Id) {
    $.ajax({
        url: `https://localhost:7183/api/Departments?Id=${Id}`,
        method: 'DELETE',
        dataType: 'json',
        success: function (data) {
            Swal.fire(
                'Done!',
                'Delete Data Successfull' + data,
                'success'
            );
            location.reload();
        }
    })
}
