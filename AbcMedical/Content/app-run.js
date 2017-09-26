app.run(
    [
        '$rootScope',
        '$location',
        '$filter',
       // 'breadcrumbs',
        'regex',
        'memory',
     //   'navigation',
       // 'parametrics',
      //  'configuration',
     //   'auth',
      //  'userResources',
       // 'toolsget',
        '$window',
        //'trace',
function (
    $rootScope,
    $location,
    $filter,
   // breadcrumbs,
   regex,
    memory,
  //  navigation,
   // parametrics,
  //  configuration,
    //auth,
  //  userResources,
  //  toolsget,
    $window
    //,
    //trace
    ) {

    $rootScope.titleApp = "Admisiones Web";
    $rootScope.storage = memory.storage;
    //$rootScope.navigate = navigation.navigate;
    //$rootScope.breadcrumbs = breadcrumbs;
    //$rootScope.regex = regex;
   // $rootScope.trace = trace.print;

    $rootScope.authorize = function (componentName_) {
        return auth.authorize(componentName_);
    };

  //  auth.load();

   
  //  $rootScope.configuration = configuration;
  //  $rootScope.paginationTables = toolsget.pagination;
  //  $rootScope.timerVerify = toolsget.timerVerify;
 //   $rootScope.dynamicFormLoaded = false;

  /*  $rootScope.$on('$routeChangeStart', function (event, next, current) {
        var path = next ? next.$$route.originalPath : "";

        if (!path.match("/verification")) {
            $rootScope.timerVerify.stop();
            $rootScope.dynamicFormLoaded = false;
        }
    });


    $rootScope.activateTimeVerifyFromMenuClick = function (sem) {
        if (sem != undefined) {
            if ($rootScope.timerVerify.state == $rootScope.timerVerify.states.FINALIZED)
                $rootScope.timerVerify.state = $rootScope.timerVerify.states.STOPPED;
        }
    }

    memory.storage.set('verification_activeFlowItems', []);

    //temporal
    $rootScope.simulateVerify = {
        state: [
                {
                    id: 0,
                    text: "Incompleto",
                },
                {
                    id: 1,
                    text: "Deshabilitado",
                },
                {
                    id: 2,
                    text: "Pendiente Oficina",
                },
                {
                    id: 3,
                    text: "Pendiente Transito",
                },
                {
                    id: 4,
                    text: "Completo",
                },
                {
                    id: 5,
                    text: "Rechazado",
                }
        ],

        click: function (pos, state) {
            $rootScope.configuration.verticalmenu[2].submenu[pos].semaphoreStatus = state;
        }
    }
    
    //Verificar Online/Offline
    /*$rootScope.online = navigator.onLine;
    $window.addEventListener("offline", function () {
        $rootScope.$apply(function () {
            $rootScope.online = false;
        });
    }, false);
    $window.addEventListener("online", function () {
        $rootScope.$apply(function () {
            $rootScope.online = true;
        });
    }, false);
    $rootScope.$watch('online', function (newStatus) {
        if (!newStatus) {
            console.log("Desconectado");
        } else {
            console.log("Conectado");
        }
    });*/
}]);
