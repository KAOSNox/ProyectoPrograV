let urlDetails = "/home/Details";

function clickDetailsBtn(id) {
    $.ajax({
        method: "POST",
        url: urlDetails,
        data: { id: id },
        dataType: "json",
        success: (response) => {
            $(".text-id-pais").text(response.id);
            $(".text-id-nombre").text(response.nombre);
        }
    });
}

let table = new DataTable('#paisesTable');