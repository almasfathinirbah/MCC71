let table = null;

$(document).ready(function () {
    table = $('#tableDivision').DataTable({
        ajax: {
            url: 'https://localhost:7183/api/Divisions',
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
                }
            },
            {
                data: "Name",
                render: (data) => {
                    return data;
                }
            },
            {
                data: "Id",
                render: (data) => {
                    return `
                    <a class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#editDivisionModal" onclick="editDivision(${data})">Edit</a> |
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#detailsDivisionModal" onclick="showDetail(${data})"> Details</a> |
                    <a class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#deleteDivisionModal" onclick="showDelete(${data})">Delete</a>
                `;
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'copy', 'pdf', 'excel']
    })
});

function newDivisions() {
    let data;
    let Id = 0;
    let Name = $('#DivisionName').val();

    data = {
        "Id": Id,
        "Name": Name
    }

    console.log(data);

    $.ajax({
        url: 'https://localhost:7183/api/Divisions',
        type: "POST",
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            Swal.fire(
                'Done!',
                'Create Data Successfull' + data,
                'Success'
            );
            location.reload();
        }
    });
}

function editDivision(Id) {
    $.ajax({
        url: `https://localhost:7183/api/Divisions/GetById?Id=${Id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";

        $('#edit').html(`
        <input type = "hidden" class= "form-control" id = "hidenId" readonly placeholder = "" value = "0">
        <p> Id: <input type="text" class="form-control" id="Id" readonly placeholder="${res.data.Id}" value="${res.data.Id}">
        <p> Name: <input type="text" class="form-control" id="DivName" placeholder="${res.data.Name}" value="${res.data.Name}">
        `)
        console.log(res);
    }).fail((err) => {
        console.log(err);
    });
}

function updateDivisions() {
    let data;
    let Id = parseInt($('#Id').val());
    let Name = $('#DivName').val();

    data = {
        "Id": Id,
        "Name": Name
    }

    console.log(data);

    $.ajax({
        url: 'https://localhost:7183/api/Divisions',
        type: "PUT",
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            Swal.fire(
                'Done!',
                'Update Data Successfull',
                'Success'
            )
            location.reload();
        }
    });
}

function showDetail(divisionId) {
    $.ajax({
        url: `https://localhost:7183/api/Divisions/GetById?Id=${divisionId}`,
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
    
                `)
    }).fail(err => {
        console.log(err)
    })
}

function showDelete(Id) {
    $.ajax({
        url: `https://localhost:7183/api/Divisions?Id=${Id}`,
        method: 'DELETE',
        dataType: 'json',
        success: function (data) {
            Swal.fire(
                'Done!',
                'Delete Data Successfull' + data,
                'Success'
            );
            location.reload();
        }
    })
}
