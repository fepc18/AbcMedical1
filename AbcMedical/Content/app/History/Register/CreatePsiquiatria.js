app.controller("CreatePsiquiatriaController", ['$scope', '$rootScope', 'AdminitrationFactory', '$location', 'HistoryFactory', 
    function ($scope, $rootScope, AdminitrationFactory, $location, HistoryFactory ) {

        var vm = this;
        vm.dataRequest = {};
        vm.RegistroClinicoId = 6;

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
        vm.Registro.Acompanante = "Si";
        vm.Registro.Parentesco = "";
        vm.Registro.OrientacionSexual = "";
        vm.Registro.OrientacionSexualCual = "";
        vm.Registro.NivelEducativo = "";
        vm.Registro.NivelEducativoCual = "";
        vm.Registro.NivelSocioeconomico = "";
        vm.Registro.EstadoCivil = "";
        vm.Registro.Religion = "";
        vm.Registro.MotivoConsulta = "";
        vm.Registro.FactorDesencadenante = "";
        vm.Registro.AreaEscolar = "";
        vm.Registro.AreaPareja = "";
        vm.Registro.AreaLaboral = "";
        vm.Registro.AreaFamiliar = "";
        vm.Registro.AreaSexual = "";
        vm.Registro.AreaSocial = "";
        vm.Registro.VictimaViolencia = "";
        vm.Registro.Golpeada = "";
        vm.Registro.SienteRiesgo = "";
        vm.Registro.QuiereHablar = "";
        vm.Registro.ViolenciaFisica = "No";
        vm.Registro.ViolenciaPsicologica = "No";
        vm.Registro.ViolenciaSexual = "No";
        vm.Registro.ViolenciaEconomica = "No";
        vm.Registro.ViolenciaPatrimonial = "No";
        vm.Registro.Negligencia = "No";
        vm.Registro.AbusoSexual = "No";
        vm.Registro.AcosoSexual = "No";
        vm.Registro.AsaltoSexual = "No";
        vm.Registro.OtroTipoViolencia = "";
        vm.Registro.DenunciaMaltrato = "";
        vm.Registro.FechaMaltrato = "";
        vm.Registro.CiudadMaltrato = "";
        vm.Registro.Spa = "No";
        vm.Registro.Alcohol = "No";
        vm.Registro.Cigarrillo = "No";
        vm.Registro.OtroConsumo = "No";
        vm.Registro.CualConsumo = "";
        vm.Registro.HistoriaConductaSuicida = "";
        vm.Registro.RiesgoPresenteConductaSuicida = "";
        vm.Registro.RemisionConductaSuicida = "";
        vm.Registro.RedApoyoConductaSuicida = "";
        vm.Registro.PersonasCercanasConductaSuicida = "";
        vm.Registro.AparienciaExamenMental = "";
        vm.Registro.AgitacionExamenMental = "";
        vm.Registro.LentitudExamenMental = "";
        vm.Registro.InhibicionExamenMental = "";
        vm.Registro.OtraExamenMental = "No";
        vm.Registro.CualExamenMental = "";
        vm.Registro.AtencionExamenMental = "";
        vm.Registro.ConcienciaExamenMental = "";
        vm.Registro.TiempoOrientacion = "";
        vm.Registro.LugarOrientacion = "";
        vm.Registro.PersonaOrientacion = "";
        vm.Registro.VelocidadLenguaje = "";
        vm.Registro.CursoLenguaje = "";
        vm.Registro.TonoVozLenguaje = "";
        vm.Registro.CalidadLenguaje = "";
        vm.Registro.DescripcionMemoria = "";
        vm.Registro.DescripcionJuicioRaciocinio = "";
        vm.Registro.Pensamiento = "";
        vm.Registro.EstadoAnimo = "";
        vm.Registro.ImpresionDiagnosticaInteligencia = "";
        vm.Registro.SuenoHabitos = "";
        vm.Registro.AlimentacionHabitos = "";
        vm.Registro.InstrospeccionHabitos = "";
        vm.Registro.ProspeccionHabitos = "";
        vm.Registro.PrimerosAuxiliosPsicologicos = "";
        vm.Registro.RemisionTratamiento = "";
        vm.Registro.PlanIntervencion = "";
        vm.Registro.RemisionIntersectorial = "";
        vm.Registro.SeguimientoEvolucion = "";
        vm.Registro.InformacionEducacion = "";


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