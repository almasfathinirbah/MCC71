$(document).ready(function () {
    $('#tableSwapi').DataTable({
        ajax: {
            url: 'https://swapi.dev/api/planets',
            datatype: 'json',
            dataSrc: 'results'
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.name;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.terrain;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.population + 'jiwa';
                }
            }
        ]
    })
});

$.ajax({
    url: 'https://swapi.dev/api/planets',
    datatype: 'json',
    dataSrc: ''
}).done((success) => {
    console.log(success)
})