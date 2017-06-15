<%@ Page  Title="kasg" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderRelatorio.aspx.cs" Inherits="WebApplication.Views.Vendedor.VenderRelatorio" %>
<asp:Content>
    <div>
        <script>
                var chartData; // globar variable for hold chart data
                google.load("visualization", "1", { packages: ["corechart"] });
 
                // Here We will fill chartData
 
                $(document).ready(function () {
           
                    $.ajax({
                        url: "VenderRelatorio.aspx/GetChartData",
                        data: "",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; chartset=utf-8",
                        success: function (data) {
                            chartData = data.d;
                        },
                        error: function () {
                            alert("Error loading data! Please try again.");
                        }
                    }).done(function () {
                        // after complete loading data
                        google.setOnLoadCallback(drawChart);
                        drawChart();
                    });
                });
 
 
                function drawChart() {
                    var data = google.visualization.arrayToDataTable(chartData);
 
                    var options = {
                        title: "Company Revenue",
                        pointSize: 5
                    };
 
                    var pieChart = new google.visualization.PieChart(document.getElementById('chart_div'));
                    pieChart.draw(data, options);
 
                }
 
            </script>
    </div>
</asp:Content>