let urlGetData = "/Estadistica/getChartData"

$(document).ready(function () {
    getChartData();
});

function getChartData() {
    $.ajax({
        url: urlGetData,
        type: 'post',
        success: function (result) {
            generateChart(result.partidosVotos,result.cargos)
            
        }
    });
}

function generateChart(votos, cargopublico) {
    console.log(cargopublico)
    var options = {
        chart: {
            type: 'bar',
            stacked: true,
            height: '100%'
        },
        series: votos,
        xaxis: {
            categories: cargopublico
        }
    }

    var chart = new ApexCharts(document.querySelector("#chart"), options);

    chart.render();
}