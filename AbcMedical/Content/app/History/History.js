app.controller("HistoryController", ['$scope', '$rootScope', 'AdminitrationFactory','$location','HistoryFactory','$routeParams',
    function ($scope, $rootScope, AdminitrationFactory, $location, HistoryFactory, $routeParams) {

        var vm = this;

        vm.documentFind = "";

        //******************//
        // DATOS PACIENTE   //
        //******************//
        
        vm.Username = $("#hdnUserName").val();
        vm.UserId = $("#hdnUserId").val();
        vm.ProfesionalId = $("#hdnProfesionalId").val();

        $rootScope.UserId = vm.UserId;
        $rootScope.ProfesionalId = vm.ProfesionalId;
        vm.pacienteId = "0";
        vm.identificacion = "";
        vm.nombreCompleto = "";
        vm.genero = "";
        vm.edad = "";
        vm.direccion = "";
        vm.telefonos = "";
        vm.Fail=false;
        vm.messageFail="";

        vm.RequestHistorialRegistros = {};

        
        
        vm.newRegister = function () {
            $location.path('/NewRegister');
        }
        vm.openFiles = function () {
          //  $location.url($location.path());
            //$location(window.location+"/CargarArchivoDigital/ListadoPublico?id=" + $rootScope.PacienteId);
           // window.location.href = "/CargarArchivoDigital/ListadoPublico?id=" + $rootScope.PacienteId;

            window.open("/CargarArchivoDigital/ListadoPublico?id=" + $rootScope.PacienteId, '_blank');
        }
        

        vm.ListRegister = function (RegistroClinicoId) {
            $location.path("/ListRegister?RegistroClinicoId=" + RegistroClinicoId);
            $location.url($location.path());
        }
        vm.consultPaciente = function () {
            var PacienteDocument = vm.documentFind;
            base.getPaciente(PacienteDocument);
        }

        var base = function () {
            return {
                getPaciente: function (PacienteDocument) {
                    // var PacienteId = 1;//$rootScope.IdRequisitionEdit;

                    AdminitrationFactory.getPaciente(PacienteDocument).then(function (data_) {
                        
                        vm.Fail = false;
                        if (data_.state) {
                            vm.identificacion = data_.data.Identificacion;
                            vm.pacienteId = data_.data.PacienteId;
                            $rootScope.PacienteId = data_.data.PacienteId;
                            vm.nombreCompleto = data_.data.PrimerNombre + " " + data_.data.SegundoNombre + " " + data_.data.PrimerApellido + " " + data_.data.SegundoApellido;
                            vm.genero = data_.data.Sexo==='M'?'Masculino': 'Femenino';
                           // vm.edad = "29 años 7 meses";
                            vm.calcularEdad(data_.data.FechaNacimiento);
                            vm.direccion = data_.data.Direccion;
                            vm.telefonos = data_.data.TelefonoResidencia + " " + data_.data.TelefonoOficina;
                            base.getResumenHistorialRegistros();
                            $location.path("/");
                            $location.url($location.path());
                        }
                        else {
                            vm.Fail = true;
                            vm.messageFail = "El paciente buscado no existe.";
                        }
                    });
                },
                getHistorialRegistros: function () {
                    vm.RequestHistorialRegistros.PacienteId = $rootScope.PacienteId;
                    vm.RequestHistorialRegistros.CompanyCLientId = "1";
                    //vm.RegistroHistoria.CompanyCLientId = $rootScope.CompanyCLientId;
                    vm.RequestHistorialRegistros.UsuarioId = vm.UserId;
                    //vm.RegistroHistoria.UsuarioId = $rootScope.UsuarioId;
                    var dataJson = JSON.stringify(vm.RequestHistorialRegistros);
                    debugger;
                    // var PacienteId = 1;//$rootScope.IdRequisitionEdit;
                    HistoryFactory.getHistorialRegistros(dataJson).then(function (data_) {
                        debugger;
                        if (data_.state) {
                            vm.ListHistorialRegistros = data_.data;
                        }
                    });
                },
                getResumenHistorialRegistros: function () {
                    var request = {};
                    request.PacienteId = $rootScope.PacienteId;
                    var dataJson = JSON.stringify(request);
                    debugger;
                    // var PacienteId = 1;//$rootScope.IdRequisitionEdit;
                    HistoryFactory.getResumenHistorialRegistros(dataJson).then(function (data_) {
                        debugger;
                        if (data_.state) {
                            vm.ListHistorialRegistros = data_.data;
                        }
                    });
                },
                init: function () {
                 //   vm.countries = base.getCountries();
                //    base.getPaciente();

                 //   vm.data_formbasicdata = angular.fromJson($rootScope.storage.get("form_basic_data"));

                    /*if ($rootScope.operationRequisition == "Edit") {
                        base.ePreload();
                    }*/

                    
                }
            }
        }();
        base.init();
        vm.calcularEdad = function (fecha) {

            //  if(validate_fecha(fecha)==true)
            //            {
            // Si la fecha es correcta, calculamos la edad
            var values = fecha.split("-");
            var dia = values[2];
            var mes = values[1];
            var ano = values[0];

            // cogemos los valores actuales
            var fecha_hoy = new Date();
            var ahora_ano = fecha_hoy.getYear();
            var ahora_mes = fecha_hoy.getMonth() + 1;
            var ahora_dia = fecha_hoy.getDate();

            // realizamos el calculo
            var edad = (ahora_ano + 1900) - ano;
            if (ahora_mes < mes) {
                edad--;
            }
            if ((mes == ahora_mes) && (ahora_dia < dia)) {
                edad--;
            }
            if (edad > 1900) {
                edad -= 1900;
            }

            // calculamos los meses
            var meses = 0;
            if (ahora_mes > mes)
                meses = ahora_mes - mes;
            if (ahora_mes < mes)
                meses = 12 - (mes - ahora_mes);
            if (ahora_mes == mes && dia > ahora_dia)
                meses = 11;

            // calculamos los dias
            var dias = 0;
            if (ahora_dia > dia)
                dias = ahora_dia - dia;
            if (ahora_dia < dia) {
                ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
                dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
            }

            // document.getElementById("result").innerHTML="Tienes "+edad+" años, "+meses+" meses y "+dias+" días";
            vm.edad = "" + edad + " años, " + meses + " meses y " + dias + " días";
            // }else{
            //     document.getElementById("result").innerHTML="La fecha "+fecha+" es incorrecta";
            // }

        }
    }]);