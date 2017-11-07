app.controller("NewRegisterController", ['$scope', '$rootScope', 'AdminitrationFactory', '$location',
    function ($scope, $rootScope, AdminitrationFactory, $location) {

        var vm = this;
        vm.dataRequest = {};
        

        vm.listRegistros = [];      
        vm.newRegister = function (RegistroClinicoId, controller) {
         //   $rootScope.PacienteId = vm.pacienteId;
            $location.path('/NewRegister/Create'+controller);
        }
       

        var base = function () {
            return {

                getRegistros: function (PacienteId) {
                    debugger;
                    vm.dataRequest.PacienteId = PacienteId;
                    vm.dataRequest.CompanyClient = 1;
                    vm.dataRequest.UserId = 1;                   

                    var dataJson = JSON.stringify(vm.dataRequest);
                    
                            AdminitrationFactory.getRegistros(dataJson).then(function (data_) {
                        debugger;
                        if (data_.state) {

                            vm.listRegistros = data_.data;
                        }
                    });
                },
                init: function () {                
                    debugger;
                    base.getRegistros();
                    
                }
            }
        }();
        base.init();
        
    }]);