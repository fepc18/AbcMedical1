app.factory('AdminitrationServices', ['$resource', function ($resource) {
    return {
      //  getRequisitions: $resource('api/requisition/getRequisitions', {}, { "post": { method: "POST" } }),
        getPaciente: $resource('Api/PacienteApi/getPaciente', {}, { "get": { method: "GET", isArray: false } }),
        getRegistros: $resource('Api/RegistroApi/getRegistros', {}, { "post": { method: "POST" } }),
       
    }
}]);