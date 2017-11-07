app.controller("ListRegisterController", ['$scope', '$rootScope', 'AdminitrationFactory','$location','HistoryFactory','$routeParams',
    function ($scope, $rootScope, AdminitrationFactory, $location, HistoryFactory,$routeParams) {

        var vm = this;

        vm.RegistroClinicoId = $routeParams.RegistroClinicoId;

        vm.documentFind = "";

        //******************//
        // DATOS PACIENTE   //
        //******************//

        vm.pacienteId = "0";
        vm.identificacion = "";
        vm.nombreCompleto = "";
        vm.genero = "";
        vm.edad = "";
        vm.direccion = "";
        vm.telefonos = "";


        vm.RequestHistorialRegistros = {};

        vm.generatePDF = function (RegistroHistoriaId) {

            window.open("/Api/RegistroHistoriaApi/getPDF?RegistroHistoriaId=" + RegistroHistoriaId);

        }
        vm.consultPaciente = function () {
            var PacienteDocument = vm.documentFind;
            base.getPaciente(PacienteDocument);
        }

        var base = function () {
            return {
               
                getHistorialRegistros: function () {
                    vm.RequestHistorialRegistros.PacienteId = $rootScope.PacienteId;
                    vm.RequestHistorialRegistros.CompanyCLientId = "1";
                    //vm.RegistroHistoria.CompanyCLientId = $rootScope.CompanyCLientId;
                    vm.RequestHistorialRegistros.UsuarioId = "1";
                    vm.RequestHistorialRegistros.RegistroClinicoId = vm.RegistroClinicoId;
                   
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
                init: function () {
                
                    base.getHistorialRegistros();
                }
            }
        }();
        base.init();
        
    }]);