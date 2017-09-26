app.config(['$httpProvider', '$routeProvider', '$locationProvider', function ($httpProvider, $routeProvider, $locationProvider) {

    $locationProvider.hashPrefix('!');

    $routeProvider
         .when('/', {
             templateUrl: '/content/app_views/History/History.html',
             //templateUrl: '/content/app_views/History/NewRegister.html',
             controller: 'HistoryController',
             controllerAs: 'History'
         })
        /*.when('/', {
            templateUrl: '/content/app_views/dashboard/index.html',
            controller: 'dashboardController'
        })
        .when('/requisition', {
            templateUrl: '/content/app_views/requisition/index.html',
            controller: 'requisitionController',
            controllerAs: 'requisition'
        })
        .when('/requisition/product', {
            templateUrl: '/content/app_views/requisition/product/index.html',
            controller: 'productController',
            controllerAs: 'product'
        })
        .when('/requisition/product/basic-data', {
            templateUrl: '/content/app_views/requisition/product/order/form/basic-data.html',
            controller: 'formBasicDataController',
            controllerAs: 'formBasicData'
        })

        .when('/requisition/nonpresential/fingeringreq', {
            templateUrl: '/content/app_views/requisition/product/nonPresential/fingeringReq.html',
            controller: 'fingeringReqController',
            controllerAs: 'fingeringReq'
        })
        .when('/requisition/nonpresential/preapproved', {
            templateUrl: '/content/app_views/requisition/product/nonPresential/preApproved.html',
            controller: 'preapprovedController',
            controllerAs: 'preapproved'
        })
        .when('/requisition/nonpresential/vbopreapproved', {
            templateUrl: '/content/app_views/requisition/product/nonPresential/vboPreApproved.html',
            controller: 'vboPreapprovedController',
            controllerAs: 'vboPreapproved'
        })

        .when('/requisition/consult', {
            templateUrl: '/content/app_views/requisition/consult/consultView.html',
            controller: 'consultController',
            controllerAs: 'consult'
        })
         .when('/requisition/pending-requests', {
             templateUrl: '/content/app_views/requisition/pending-requests/pending-requests.html',
             controller: 'pendingrequestsController',
             controllerAs: 'pendingrequests'
         })
        .when('/requisition/pending-requests-details', {
            templateUrl: '/content/app_views/requisition/pending-requests/pending-requests-detail.html',
            controller: 'pendingrequestsDetailsController',
            controllerAs: 'pendingrequestsDetails'
        })
        .when('/requisition/print', {
            templateUrl: '/content/app_views/requisition/consult/print/printReqView.html',
            controller: 'printController',
            controllerAs: 'print'
        })
        .when('/requisition/answer/:idConsulta', {
            templateUrl: '/content/app_views/requisition/consult/answer/consultAnswerView.html',
            controller: 'consultAnswerController',
            controllerAs: 'consultAnswer'
        })
        .when('/requisition/consult/:idConsulta/:newAdmissions', {
            templateUrl: '/content/app_views/requisition/consult/consultDetailView.html',
            controller: 'consultDetailController',
            controllerAs: 'consultDetail'
        })
        .when('/requisition/reconsider', {
            templateUrl: '/content/app_views/requisition/reconsider/index.html',
            controller: 'reconsiderController',
            controllerAs: 'reconsider'
        })
        .when('/requisition/reconsider-edit', {
            templateUrl: '/content/app_views/requisition/reconsider/reconsider-edit.html',
            controller: 'reconsiderEditController',
            controllerAs: 'reconsiderEdit'
        })
        .when('/verification', {
            templateUrl: '/content/app_views/verification/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/verification/special-brands', {
            templateUrl: '/content/app_views/verification/special-brands/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/verification/biometrics', {
            templateUrl: '/content/app_views/verification/biometrics/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/verification/identity', {
            templateUrl: '/content/app_views/verification/identity/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/verification/customer', {
            templateUrl: '/content/app_views/verification/customer/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/verification/activity', {
            templateUrl: '/content/app_views/verification/activity/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/verification/income', {
            templateUrl: '/content/app_views/verification/income/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/verification/google-sarlaft', {
            templateUrl: '/content/app_views/verification/google-sarlaft/index.html',
            controller: 'verificationController',
            controllerAs: 'verification'
        })
        .when('/center-risk/shortframe', {
            templateUrl: '/content/app_views/center-risk/index.html',
            controller: 'centerRiskController',
            controllerAs: 'risk'
        })
        .when('/center-risk/shortframe/result', {
            templateUrl: '/content/app_views/center-risk/short-frame.html',
            controller: 'shortFrameController',
            controllerAs: 'shortframe'
        })
        .when('/center-risk/history', {
            templateUrl: '/content/app_views/center-risk/index.html',
            controller: 'centerRiskController',
            controllerAs: 'risk'
        })
        .when('/center-risk/history/:idConsulta', {
            templateUrl: '/content/app_views/center-risk/history.html',
            controller: 'historyRiskController',
            controllerAs: 'history'
        })
        .when('/center-risk/ondemand', {
            templateUrl: '/content/app_views/center-risk/index.html',
            controller: 'centerRiskController',
            controllerAs: 'risk'
        })
        .when('/center-risk/ondemand/result', {
            templateUrl: '/content/app_views/center-risk/on-demand.html',
            controller: 'onDemandRiskController',
            controllerAs: 'ondemand'
        })
        .when('/center-risk/ofac', {
            templateUrl: '/content/app_views/center-risk/o-fac.html',
            controller: 'oFacController',
            controllerAs: 'ofac'
        })
        .when('/center-risk/evident', {
            templateUrl: '/content/app_views/center-risk/evident.html',
            controller: 'evidentRiskController',
            controllerAs: 'evident'
        })
        .when('/center-risk/recognize', {
            templateUrl: '/content/app_views/center-risk/index.html',
            controller: 'centerRiskController',
            controllerAs: 'risk'
        })
        .when('/center-risk/recognize/result', {
            templateUrl: '/content/app_views/center-risk/recognize.html',
            controller: 'recognizeRiskController',
            controllerAs: 'recognize'
        })

        .when('/credit-committee', {
            templateUrl: '/content/app_views/credit-committee/index.html',
            controller: 'creditComIndexController',
            controllerAs: 'creditComIndex'
        })
        .when('/credit-committee/edit-requisition-credit', {
            templateUrl: '/content/app_views/credit-committee/edit.html',
            controller: 'creditComEditController',
            controllerAs: 'creditComEdit'
        })

        .when('/compliance-unit', {
            templateUrl: '/content/app_views/compliance-unit/index.html',
            controller: 'compliUnitIndexController',
            controllerAs: 'compliUnitIndex'
        })
        .when('/compliance-unit/sarlaft-template', {
            templateUrl: '/content/app_views/compliance-unit/sarlaft.html',
            controller: 'compliUnitSarlaftController',
            controllerAs: 'compliUnitSarlaft'
        })
        .when('/administration/questions', {
            templateUrl: '/content/app_views/administration/questions.html',
            controller: 'questionsController',
            controllerAs: 'questions'
        })
        .when('/administration/modules', {
            templateUrl: '/content/app_views/administration/modules.html',
            controller: 'modulesController',
            controllerAs: 'modules'
        })
        .when('/administration/sections', {
            templateUrl: '/content/app_views/administration/sections.html',
            controller: 'sectionsController',
            controllerAs: 'sections'
        })
        .when('/404', {
            templateUrl: '/content/style/templates/404.html'
        })
        .when('/500', {
            templateUrl: '/content/style/templates/500.html'
        })
        .otherwise({
            redirectTo: '/404'
        });*/
}]);

