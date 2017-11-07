app.factory('AdminitrationFactory', ['AdminitrationServices', '$log',
    function (AdminitrationServices, $log) {

        var pacienteResponse = {};
        var registrosResponse = {};
        

        var interfaz = {
          /*  getPaciente: function (data) {
                return AdminitrationResources.getPaciente.post(data).$promise.then(function (data_) {
                    if (data_.state) {
                        requisitionsResponse.status = true;
                        requisitionsResponse.data = data_.info;
                    } else {
                        requisitionsResponse.status = false;
                        requisitionsResponse.data = data_.message;
                        $log.error(data_.message);
                    }
                    return requisitionsResponse;
                });
            },*/

            
            getPaciente: function (PacienteDocument_) {
                debugger;
              //  return PacienteId_;
                return AdminitrationServices.getPaciente.get({ PacienteDocument: PacienteDocument_ }).$promise.then(function (data_) {
                    if (data_.State) {
                        pacienteResponse.state = true;
                        pacienteResponse.data = data_.paciente;
                    } else {
                        pacienteResponse.state = false;
                        pacienteResponse.data = data_.message;
                        $log.error(data_.message);
                    }
                    return pacienteResponse;
                });
            },
            getRegistros: function (data) {
                debugger;
                //  return PacienteId_;
                return AdminitrationServices.getRegistros.post(data).$promise.then(function (data_) {
                    if (data_.State) {
                        registrosResponse.state = true;
                        registrosResponse.data = data_.RegistrosClinicos;
                    } else {
                        registrosResponse.state = false;
                        registrosResponse.data = data_.message;
                        $log.error(data_.message);
                    }
                    return registrosResponse;
                });
            },

        }
        return interfaz;
    }])