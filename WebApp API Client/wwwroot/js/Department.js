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
                    <a class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#editDepartmentModal" onclick="showEdit(${data})">Edit</a> |
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#detailsDepartmentModal" onclick="showDetail(${data})"> Detail</a> |
                    <a class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#deleteDepartmentModal" onclick="showDelete(${data})">Delete</a>
                `;
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'pdf', 'excel']
    })
});

function createDepartement() {

    const DepartementName = $("#InputDepartementName").val();
    const DivisionIdDepartement = $("#InputDivisionIdDepartment").val();

    $.ajax({
        url: 'https://localhost:7183/api/Departments',
        method: 'POST',
        dataType: 'json',
        data: {
            Name: DepartementName,
            DivisionId: parseInt(DivisionIdDepartement)
        },
        success: function (data) {
            Swal.fire(
                'Done!',
                'Create New Data Successfull' + data,
                'success'
            )
        },
        error: function (data) {
            getAlertError();
        }
    })
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
