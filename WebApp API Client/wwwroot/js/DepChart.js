/*var xValues = [100, 200, 300, 400, 500, 600, 700, 800, 900, 1000];

new Chart("myChart", {
    type: "line",
    data: {
        labels: xValues,
        datasets: [{
            data: [860, 1140, 1060, 1060, 1070, 1110, 1330, 2210, 7830, 2478],
            borderColor: "red",
            fill: false
        }, {
            data: [1600, 1700, 1700, 1900, 2000, 2700, 4000, 5000, 6000, 7000],
            borderColor: "green",
            fill: false
        }, {
            data: [300, 700, 2000, 5000, 6000, 4000, 2000, 1000, 200, 100],
            borderColor: "blue",
            fill: false
        }]
    },
    options: {
        legend: { display: false }
    }
});*/
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:7183/api/Departments',
        method: 'GET',
        success: function(data) {
            console.log(data);
            length = data.data.length;
            console.log(length);
            label = [];
            value = [];
            for (i = 0; i < length; i++) {
                label.push(data.data[i].Name);
                value.push(data.data[i].Id);
            }
            var ctx = document.getElementById('myChart');
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: label,
                    datasets: [
                        {
                            label: "Population",
                            backgroundColor: [
                                "#3a90cd",
                                "#8e5ea2",
                                "#3bba9f",
                                "#e8c3b9",
                                "#c45850",
                                "#CD9C5C"],
                            data: value
                        }
                    ]
                },
                options: {
                    legend: { display: false },
                    title: {
                        display: true,
                        text: 'Department'
                    }
                }
            })
            var ctx = document.getElementById('myChart2');
            var chart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: label,
                    datasets: [
                        {
                            label: "Population",
                            backgroundColor: [
                                "#3a90cd",
                                "#8e5ea2",
                                "#3bba9f",
                                "#e8c3b9",
                                "#c45850",
                                "#CD9C5C"],
                            data: value
                        }
                    ]
                },
                options: {
                    legend: { display: false },
                    title: {
                        display: true,
                        text: 'Department'
                    }
                }
            })
        }
    })
})