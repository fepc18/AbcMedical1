app.factory('HistoryFactory', ['HistoryServices', '$log',
    function (HistoryServices, $log) {

        var saveRegistroHistoriaResponse = {};
        var getHistorialRegistrosResponse = {};
        var getResumenHistorialRegistrosResponse = {};

        var interfaz = {
            saveRegistroHistoria: function (data) {
                debugger;
                //  return PacienteId_;
                return HistoryServices.saveRegistroHistoria.post(data).$promise.then(function (data_) {
                    if (data_.State) {
                        saveRegistroHistoriaResponse.state = true;
                        saveRegistroHistoriaResponse.data = data_;
                    } else {
                        saveRegistroHistoriaResponse.state = false;
                        saveRegistroHistoriaResponse.data = data_.message;
                        $log.error(data_.message);
                    }
                    return saveRegistroHistoriaResponse;
                });
            },
            getHistorialRegistros: function (data) {
                debugger;
                //  return PacienteId_;
                return HistoryServices.getHistorialRegistros.post(data).$promise.then(function (data_) {
                    if (data_.State) {
                        getHistorialRegistrosResponse.state = true;
                        getHistorialRegistrosResponse.data = data_.RegistrosHistorial;
                    } else {
                        getHistorialRegistrosResponse.state = false;
                        getHistorialRegistrosResponse.data = data_.message;
                        $log.error(data_.message);
                    }
                    return getHistorialRegistrosResponse;
                });
            },
            getResumenHistorialRegistros: function (data) {
                debugger;
                //  return PacienteId_;
                return HistoryServices.getResumenHistorialRegistros.post(data).$promise.then(function (data_) {
                    if (data_.State) {
                        getResumenHistorialRegistrosResponse.state = true;
                        getResumenHistorialRegistrosResponse.data = data_.ResumenRegistroHistorial;
                    } else {
                        getResumenHistorialRegistrosResponse.state = false;
                        getResumenHistorialRegistrosResponse.data = data_.message;
                        $log.error(data_.message);
                    }
                    return getResumenHistorialRegistrosResponse;
                });
            },

        }
        return interfaz;
    }])