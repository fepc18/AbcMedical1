app.controller("CreateNotaController", ['$scope', '$rootScope', 'AdminitrationFactory', '$location', 'HistoryFactory', 
    function ($scope, $rootScope, AdminitrationFactory, $location, HistoryFactory ) {

        var vm = this;
        vm.dataRequest = {};
        vm.RegistroClinicoId = 1;

        vm.listRegistros = [];      
        vm.newRegister = function (controller) {
         //   $rootScope.PacienteId = vm.pacienteId;
            $location.path('/NewRegister/Create'+controller);
        }
       

        /*********************************/
        //MODELO
        /*********************************/
        vm.savedOK = false;
        vm.savedFail = false;
        vm.messageFail = "";


        vm.Registro = {};
        vm.Registro.Asunto = "";
        vm.Registro.Fecha = "";
        vm.Registro.Hora = "";
        vm.Registro.Descripcion = "";





        vm.RegistroHistoria = {};

        vm.fechaActual = function () {
            var hoy = new Date();
            var dd = hoy.getDate();
            var mm = hoy.getMonth() + 1; //hoy es 0!
            var yyyy = hoy.getFullYear();

            if (dd < 10) {
                dd = '0' + dd
            }

            if (mm < 10) {
                mm = '0' + mm
            }

            hoy = dd + '/' + mm + '/' + yyyy;
            return hoy;
        }
        vm.horaActual = function () {
            var hoy = new Date();
            var hora=hoy.getHours();
            if (hora < 10) {
                hora = '0' + hora
            }
            var minuto = hoy.getMinutes();
            if (minuto < 10) {
                minuto = '0' + minuto
            }

            horaActual = hora + ":" + minuto;
            return horaActual;
        }

        vm.save = function () {
            debugger;
            vm.RegistroHistoria.CompanyCLientId = "1";
            //vm.RegistroHistoria.CompanyCLientId = $rootScope.CompanyCLientId;
            vm.RegistroHistoria.CompanyCLientId = "1";
            vm.RegistroHistoria.PacienteId = $rootScope.PacienteId;
            vm.RegistroHistoria.RegistroClinicoId = vm.RegistroClinicoId;
            vm.RegistroHistoria.Asunto = vm.Registro.Asunto;
            vm.RegistroHistoria.UsuarioId = $rootScope.UserId;
            //vm.RegistroHistoria.UsuarioId = $rootScope.UsuarioId;
            //vm.RegistroHistoria.ProfesionalId = "1";
            vm.RegistroHistoria.ProfesionalId = $rootScope.ProfesionalId;
            
            vm.RegistroHistoria.Diagnostico = "0";
            vm.RegistroHistoria.DiagnosticoRelacionado1 = "0";
            vm.RegistroHistoria.DiagnosticoRelacionado2 = "0";
            vm.RegistroHistoria.DiagnosticoRelacionado3 = "0";
            vm.RegistroHistoria.DiagnosticoRelacionado4 = "0";
            vm.RegistroHistoria.DiagnosticoRelacionado5 = "0";
            vm.RegistroHistoria.Contenido = JSON.stringify(vm.Registro);
            
            var dataJson = JSON.stringify(vm.RegistroHistoria);

            HistoryFactory.saveRegistroHistoria(dataJson).then(function (data_) {
                debugger;
                if (data_.state) {
                  //  HistoryController.getResumenHistorialRegistros();
                    //MOSTRAR MENSAJE
                    vm.savedOK = true;
                    vm.listRegistros = data_.data;
                }
            });

        }

        vm.LoadHistory = function () {
            $location.path("/ListRegister?RegistroClinicoId=" + vm.RegistroClinicoId);
            $location.url($location.path());
        }
        
        var base = function () {
            return {


                getRegistros: function (PacienteId) {
                    debugger;
                   

                    var dataJson = JSON.stringify(vm.dataRequest);
                    
                            AdminitrationFactory.getRegistros(dataJson).then(function (data_) {
                        debugger;
                        if (data_.state) {

                            vm.listRegistros = data_.data;
                        }
                    });
                },
                inicializarDatos: function () {
                    debugger;
                    vm.Registro.Fecha = vm.fechaActual();
                    vm.Registro.Hora = vm.horaActual();
                },
                init: function () {                
                    debugger;
                    base.getRegistros();
                    base.inicializarDatos();
                }
            }
        }();
        base.init();
    }]);