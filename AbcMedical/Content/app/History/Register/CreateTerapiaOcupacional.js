    app.controller("CreateTerapiaOcupacionalController", ['$scope', '$rootScope', 'AdminitrationFactory', '$location', 'HistoryFactory', 
    function ($scope, $rootScope, AdminitrationFactory, $location, HistoryFactory ) {

        var vm = this;
        vm.dataRequest = {};
        vm.RegistroClinicoId = 4;

        vm.listRegistros = [];      
        

        /*********************************/
        //MODELO
        /*********************************/
        vm.savedOK = false;
        vm.savedFail = false;
        vm.messageFail = "";

        vm.Registro = {};
        vm.Registro.Fecha = "";
        vm.Registro.Hora = "";
        vm.Registro.CalidadInformacion = "";
        vm.Registro.Hijos = "";
        vm.Registro.MotivoConsulta = "";
        vm.Registro.EntornosRiesgo = "";
        vm.Registro.TablaConsumo = {};
        vm.Registro.PersonalidadPrevia = "";
        vm.Registro.PatologicosAntecedentes = "";
        vm.Registro.FarmacologicosAntecedentes = "";
        vm.Registro.QuirurgicosAntecedentes = "";
        vm.Registro.TraumaticosAntecedentes = "";
        vm.Registro.AlergicosAntecedentes = "";
        vm.Registro.FamiliaresAntecedentes = "";
        vm.Registro.MovimientosVoluntarios = "";
        vm.Registro.MovimientosAutomaticos = "";
        vm.Registro.MovimientosReflejos = "";
        vm.Registro.Dinamico = "";
        vm.Registro.Estatico = "";
        vm.Registro.ControlCabeza = "";
        vm.Registro.ControlTronco = "";
        vm.Registro.ControlMMII = "";
        vm.Registro.ControldeMMSS = "";
        vm.Registro.Precision = "";
        vm.Registro.ControlFuerza = "";
        vm.Registro.ManejoEspacial = "";
        vm.Registro.ManoCabeza = "";
        vm.Registro.ManoBoca = "";
        vm.Registro.ManoRodilla = "";
        vm.Registro.ManoPie = "";
        vm.Registro.PrensionDigital = "";
        vm.Registro.PrensionPalmar = "";
        vm.Registro.Tactil = "";
        vm.Registro.Propioceptivo = "";
        vm.Registro.Auditivo = "";
        vm.Registro.Vestibular = "";
        vm.Registro.Gustativo = "";
        vm.Registro.Olfatorio = "";
        vm.Registro.Visual = "";
        vm.Registro.Atencion = "";
        vm.Registro.Memoria = "";
        vm.Registro.Orientacion = "";
        vm.Registro.SeguimientoInstrucciones = "";
        vm.Registro.IniciaDesarrollaCulmina = "";
        vm.Registro.ResolucionProblemas = "";
        vm.Registro.ContactoVisual = "";
        vm.Registro.FormaComunicacion = "";
        vm.Registro.Autocontrol = "";
        vm.Registro.ManejoLimites = "";
        vm.Registro.AdaptacionContextosNuevos = "";
        vm.Registro.ValoresIntereses = "";
        vm.Registro.AutoConcepto = "";
        vm.Registro.ConductaSocial = "";
        vm.Registro.OrinarDefecar = "";
        vm.Registro.Vestido = "";
        vm.Registro.Alimentacion = "";
        vm.Registro.MantenimientoSalud = "";
        vm.Registro.CuidadoEnseresPersonales = "";
        vm.Registro.RutinaMedicamentosa = "";
        vm.Registro.MovilidadFuncional = "";
        vm.Registro.Escolaridad = "";
        vm.Registro.Empleo = "";
        vm.Registro.TrabajoVoluntario = "";
        vm.Registro.OrganizacionHogar = "";
        vm.Registro.CuidadoOtros = "";
        vm.Registro.Meta = "";
        vm.Registro.ObjetivoGeneral = "";
        vm.Registro.ObjetivosEspecificos = "";



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
            vm.RegistroHistoria.Asunto = vm.Registro.MotivoConsulta;
            vm.RegistroHistoria.UsuarioId = "1";
            //vm.RegistroHistoria.UsuarioId = $rootScope.UsuarioId;
            vm.RegistroHistoria.ProfesionalId = "1";
            //vm.RegistroHistoria.ProfesionalId = $rootScope.ProfesionalId;
            
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