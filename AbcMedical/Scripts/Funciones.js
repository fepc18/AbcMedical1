$(function() {
    $("#lnkAdd").click(function() {
       var uri = '<%: Url.Action("Listado","Listado", new {id=xxxx})%>';
       uri = uri.replace('xxxx', $("#PacienteId").val());
       var path = '/CargarArchivoDigital/Listado' + "?id=" + $("#PacienteId").val()

        $(this).attr("href",path);
    });
});