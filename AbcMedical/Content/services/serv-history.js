app.factory('HistoryServices', ['$resource', function ($resource) {
    return {
        saveRegistroHistoria: $resource('Api/RegistroHistoriaApi/saveRegistroHistoria', {}, { "post": { method: "POST" } }),
        getHistorialRegistros: $resource('Api/RegistroHistoriaApi/getHistorialRegistros', {}, { "post": { method: "POST" } }),
        getResumenHistorialRegistros: $resource('Api/RegistroHistoriaApi/getResumenHistorialRegistros', {}, { "post": { method: "POST" } }),
       
    }
}]);